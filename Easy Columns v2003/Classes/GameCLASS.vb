Imports System.Drawing
Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

'the game class stores info that is used in the game section. also
'processes the rendering and manages elements and inputs
Public Class GameCLASS

    'here are constants for a current game, but flexible in the application
#Region " Semi-constants "
    Public GameElementCountX As Integer
    Public GameElementCountY As Integer

    Public GameElementCountInPiece As Integer 'how many elements should be placed in a normal piece

    Public GameFallingSpeedIncreasing As Single

    Public GameInitialFallingSpeed As Single
    Public GameInitialAccelerateSpeed As Single 'only for speeding games
    Public GameInitialMovementSpeed As Single
    Public GameInitialRotationSpeed As Single

    Public GameFallingMethod As Enums.FallingMethod

    Public GameLineElementCount As Integer 'how many elements in line disappear

    Public LineFallingMultiply As Single


    Public Dr3D_ElementSpaceX As Single
    Public Dr3D_ElementSpaceY As Single
    Public Dr3D_ElementSpaceZ As Single
    Public Dr3D_ElementSizeX As Single
    Public Dr3D_ElementSizeY As Single
    Public Dr3D_ElementSizeZ As Single

    Public Dr3D_ElementCubicEdgeSize As Single

    Public Dr3d_ELementTopColor As Color
    Public Dr3d_ELementBottomColor As Color

    Public Dr3D_BackColorDA As Color
    Public Dr3D_BackColorDB As Color

    Public Dr3D_BoardColor As Color 'maybe texture too

    Public Dr3D_BoardZAdding As Single

    ' Public Shared tex1 As Texture
#End Region





#Region " Variables "
    'virtual
    Private win As Easy_Columns.mFORM

    Public Paused As Boolean

    Public Type As Enums.GameType
    Public AnimatedRotation As Boolean
    Public Colors As Collection 'of colors / what colors are beeing used

    Public Score As Long

    Public Elem(100, 100) As ElementCLASS 'the static elements of the game, that have allready been placed on the board
    Private ElemCollection As Collection 'of ElementCLASS - the dynamic elements of the game, falling usually
    Private ElemPiece As Collection 'of ElementCLASS 'refering to the elements that are in a piece (max 10) and can be controlled from inputs
    Private ElemNext As Collection 'of ElementCLASS

    Private FallingSpeed As Single
    Private AccelerateSpeed As Single
    Private MovementSpeed As Single
    Private RotationSpeed As Single


    'D3D
    Private Cam As CameraCL

    Public Shared DeviceA As Device
    Public DeviceB As Device

    Private Board As BoardCL


    Public AllowInput As Boolean
    Public AllowAccelerate As Boolean

    Public Over As Boolean


    Public NextRotateAngle As Single

    Public RendNext As Boolean
#End Region





#Region " Other Classes "

    Public Class BoardCL
        Public BottomVB, LeftVB, RightVB, BackVB As VertexBuffer 'like CV_PosNTex - the faces
        Public TopPointsVB As VertexBuffer 'CV_PosCol - points to represent the top of the board

        'when creating a board
        Public Sub New(ByVal g As GameCLASS)
            Dim mx, my, mz As Single

            GetMaxSpaceFromGame(g, mx, my, mz)

            _3D.CreateFaceTextured(g.DeviceA, BottomVB, 0, 0, mz, mx, 0, mz, 0, 0, 0, mx, 0, 0, 0, 1, 0)
            _3D.CreateFaceTextured(g.DeviceA, LeftVB, 0, my, 0, 0, my, mz, 0, 0, 0, 0, 0, mz, 1, 0, 0)
            _3D.CreateFaceTextured(g.DeviceA, RightVB, mx, my, mz, mx, my, 0, mx, 0, mz, mx, 0, 0, -1, 0, 0)
            _3D.CreateFaceTextured(g.DeviceA, BackVB, 0, my, mz, mx, my, mz, 0, 0, mz, mx, 0, mz, 0, 0, -1)
        End Sub


        Public Sub Render(ByVal g As GameCLASS, ByVal d As Device)
            d.Transform.World = Matrix.Identity

            d.VertexFormat = CustomVertex.PositionNormalTextured.Format

            Dim m As New Material()
            m.Diffuse = g.Dr3D_BoardColor
            m.Specular = Color.White
            m.SpecularSharpness = 2
            d.Material = m

            d.SamplerState(0).AddressU = TextureAddress.Wrap
            d.SamplerState(0).AddressV = TextureAddress.Wrap
            d.SamplerState(0).AddressW = TextureAddress.Wrap
            'd.SetTexture(0, tex1)
            d.TextureState(0).ColorOperation = TextureOperation.Modulate
            d.TextureState(0).ColorArgument1 = TextureArgument.TextureColor
            d.TextureState(0).ColorArgument2 = TextureArgument.Diffuse

            d.SetStreamSource(0, BottomVB, 0)
            d.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

            d.SetStreamSource(0, LeftVB, 0)
            d.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

            'no need of this ;)
            'd.SetStreamSource(0, RightVB, 0)
            'd.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

            d.SetStreamSource(0, BackVB, 0)
            d.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

        End Sub
    End Class







    Public Class CameraCL
        Public MX As Matrix
        Public Cp, Ct, Cuv As Vector3


        Public Sub New()
            MX = Matrix.Identity
            Cp = New Vector3()
            Ct = New Vector3()
            Cuv = New Vector3()
        End Sub
        '
        '
        Public Sub New(ByVal CpP As Vector3, ByVal CtP As Vector3, ByVal CuvP As Vector3)
            MX = Matrix.LookAtLH(CpP, CtP, CuvP)
            Cp = CpP
            Ct = CtP
            Cuv = CuvP
        End Sub



        'sets the camera's parameters cp, ct, cuv for a game it centers the camera in the middle of the board
        Public Sub SetCameraDefaultParametersFromGame(ByVal g As GameCLASS)
            Dim mx, my, mz As Single
            Funcs.GetMaxSpaceFromGame(g, mx, my, mz)

            Cp.X = mx / 2
            Cp.Y = my / 2
            Cp.Z = -5
            Ct.X = mx / 2
            Ct.Y = 5 * my / 9
            Ct.Z = mz / 2
            Cuv.X = 0
            Cuv.Y = 1
            Cuv.Z = 0

            SetCameraParametersToMatrix()
        End Sub



        'sets parameters in the matrix
        Public Sub SetCameraParametersToMatrix()
            MX = Matrix.LookAtLH(Cp, Ct, Cuv)
        End Sub



        Public Sub Translate(ByVal x As Single, ByVal y As Single, ByVal z As Single)
            Cp.X += x
            Cp.Y += y
            Cp.Z += z
            SetCameraParametersToMatrix()
        End Sub
    End Class



#End Region







    'constructor of game and initializations
#Region " Constructor "

    Public Sub New(ByVal WinSupport As Easy_Columns.mFORM, Optional ByVal typeP As Enums.GameType = Enums.GameType.Classic, Optional ByVal AnimatedRotationP As Boolean = False)
        Over = False

        win = WinSupport 'the mFORM which controls this game

        Paused = True

        Type = typeP

        Colors = New Collection()

        Score = 0

        'different sets on different types
        If typeP = Enums.GameType.Classic Then
            AnimatedRotation = False
            GameElementCountX = 6
            GameElementCountY = 18
            GameElementCountInPiece = 3
            GameInitialFallingSpeed = 0.03
            GameFallingSpeedIncreasing = -0.0008 'this means that speeds are calculated in function on how many static objects are in the scene
            GameInitialMovementSpeed = 0.5
            GameInitialAccelerateSpeed = 0.25
            GameFallingMethod = Enums.FallingMethod.DropDown
            GameLineElementCount = 3
        Else
            AnimatedRotation = AnimatedRotationP
            GameElementCountX = 8
            GameElementCountY = 16
            GameElementCountInPiece = 3
            GameInitialFallingSpeed = 0.03
            GameFallingSpeedIncreasing = -0.0008
            GameInitialMovementSpeed = 0.5
            GameInitialAccelerateSpeed = 0.25
            GameInitialRotationSpeed = Math.PI / 4
            GameFallingMethod = Enums.FallingMethod.DropDown
            GameLineElementCount = 3
        End If

        LineFallingMultiply = 2 'how fast would the line-elements fall (*fallingspeed)

        FallingSpeed = GameInitialFallingSpeed
        AccelerateSpeed = GameInitialAccelerateSpeed
        MovementSpeed = GameInitialMovementSpeed
        RotationSpeed = GameInitialRotationSpeed

        'set 3d default options
        Dr3D_ElementSpaceX = 0.2F
        Dr3D_ElementSpaceY = 0.2F
        Dr3D_ElementSpaceZ = 0.2F

        Dr3D_ElementSizeX = 0.8F
        Dr3D_ElementSizeY = 0.8F
        Dr3D_ElementSizeZ = 0.8F

        Dr3D_ElementCubicEdgeSize = 0.2F

        Dr3d_ELementBottomColor = Color.DarkGray
        Dr3d_ELementTopColor = Color.DarkGray

        Dr3D_BackColorDA = Color.DarkCyan
        Dr3D_BackColorDB = Color.LavenderBlush

        Dr3D_BoardColor = Color.LightSalmon

        Dr3D_BoardZAdding = 1.5



        'camera
        Cam = New CameraCL()
        Cam.SetCameraDefaultParametersFromGame(Me)
        Cam.Cp.X += GameElementCountY / 2
        Cam.Cp.Y += GameElementCountY / 2
        Cam.Cp.Z += -GameElementCountY
        Cam.SetCameraParametersToMatrix()

        Cam.Translate(0, 1, 2)




        'elements clean
        ElemCollection = New Collection()

        Dim i, j As Integer
        'make sure everything is clear all array
        For i = 0 To 100 'GameElementCountX
            For j = 0 To 100 'GameElementCountY
                Elem(i, j) = Nothing
            Next
        Next


        ElemPiece = New Collection()
        ElemNext = New Collection()

        NextRotateAngle = Math.PI / 128

        'the main device
        InitDeviceA()

        'the board
        Board = New BoardCL(Me)

        'lights for device a
        InitLights(DeviceA)

        'secondary device
        InitDeviceB()


        AllowInput = False

        RendNext = True
    End Sub

#End Region










#Region " Running "

    'The most important sub. It controls the physics of the game
    Public Sub Process()
        If Not Paused Then
            '--things that happen only when not paused--

            'check if a new piece should be inserted
            If ElemCollection.Count = 0 Then
                '!!!verify if any of the game elements are in a line and should be removed
                'add new piece
                If RemoveLines() = False Then
                    If ElemNext.Count > 0 Then AddNewPiece()
                    AddNewNext()
                End If

                'calculate speeding if needed
                If GameFallingSpeedIncreasing < 0 Then
                    Dim o As Integer
                    o = Funcs.GetNumberOfStaticElements(Me)
                    FallingSpeed = GameInitialFallingSpeed - o * GameFallingSpeedIncreasing
                    AccelerateSpeed = GameInitialAccelerateSpeed - o * GameFallingSpeedIncreasing * GameInitialAccelerateSpeed / GameInitialFallingSpeed
                    MovementSpeed = GameInitialMovementSpeed - o * GameFallingSpeedIncreasing
                    RotationSpeed = GameInitialRotationSpeed - o * GameFallingSpeedIncreasing
                End If

            End If

        End If
        '--things that happen anyway--

        'Rendering
        RenderA()

        If RendNext Then RenderB()
    End Sub






    'sign elements which will be removed
    Public Sub SetAsEliminateElements(ByVal stx As Integer, ByVal sty As Integer, ByVal xi As Integer, ByVal yi As Integer, ByVal n As Integer)
        Dim x, y, i As Integer

        x = stx
        y = sty

        For i = 1 To n
            Elem(x, y).dis = True

            x += xi
            y += yi
        Next
    End Sub


    'the actual elimination
    Public Sub EliminateElements()
        Dim i, j As Integer

        'make elements dissapear
        For i = 1 To GameElementCountY
            For j = 1 To GameElementCountX
                If Not (Elem(j, i) Is Nothing) Then
                    If Elem(j, i).dis Then
                        Elem(j, i) = Nothing
                        'increase points
                        Score += 1
                    End If
                End If
            Next
        Next

        'also set elemenst which need to fall now
        For i = 2 To GameElementCountY
            For j = 1 To GameElementCountX
                If Not (Elem(j, i) Is Nothing) And (Elem(j, i - 1) Is Nothing) Then
                    Elem(j, i).vy = -FallingSpeed * LineFallingMultiply
                    ElemCollection.Add(Elem(j, i))
                    Elem(j, i) = Nothing
                End If
            Next
        Next

    End Sub


    'remove elements in lines
    Public Function RemoveLines() As Boolean
        Dim i, j As Integer
        Dim n As Integer
        Dim b As Boolean

        b = False
        For i = 1 To GameElementCountY
            For j = 1 To GameElementCountX
                'horizontal lines check
                n = Funcs.GetNumberOfElementsInLine(Me, j, i, 1, 0)
                If n >= GameLineElementCount Then
                    SetAsEliminateElements(j, i, 1, 0, n)
                    b = True
                End If

                'vertical lines check
                n = Funcs.GetNumberOfElementsInLine(Me, j, i, 0, 1)
                If n >= GameLineElementCount Then
                    SetAsEliminateElements(j, i, 0, 1, n)
                    b = True
                End If

                'diagonal1 lines check
                n = Funcs.GetNumberOfElementsInLine(Me, j, i, 1, 1)
                If n >= GameLineElementCount Then
                    SetAsEliminateElements(j, i, 1, 1, n)
                    b = True
                End If

                'diagonal2 lines check
                n = Funcs.GetNumberOfElementsInLine(Me, j, i, -1, 1)
                If n >= GameLineElementCount Then
                    SetAsEliminateElements(j, i, -1, 1, n)
                    b = True
                End If
            Next
        Next

        If b Then EliminateElements()
        Return b
    End Function





    Public Sub AddNewNext()
        Dim i As Integer
        Dim px, py, pz As Single


        'gets a random x location for all of the elements
        px = 0

        For i = 1 To GameElementCountInPiece
            Dim e As ElementCLASS
            e = New ElementCLASS(Me, DeviceB, Enums.ModelType.Cubic)


            py = (i - 1 - GameElementCountInPiece / 2) * (Dr3D_ElementSizeY + Dr3D_ElementSpaceY) + Dr3D_ElementSizeY / 2 + Dr3D_ElementSpaceY / 2
            pz = 0


            'each type differently sets colors
            Select Case Type
                Case Enums.GameType.Classic
                    Dim c As Color
                    c = Funcs.GetRandomColor(Me) 'gets a random color for all the faces of the element

                    e.SetIt(px, py, pz, c, c, c, c, Dr3d_ELementTopColor, Dr3d_ELementBottomColor)

                Case Enums.GameType.Rotative

                    Dim cf, cr, cb, cl As Color
                    'gets a random colors for each face
                    cf = Funcs.GetRandomColor(Me)
                    cr = Funcs.GetRandomColor(Me)
                    cb = Funcs.GetRandomColor(Me)
                    cl = Funcs.GetRandomColor(Me)

                    e.SetIt(px, py, pz, cf, cr, cb, cl, Dr3d_ELementTopColor, Dr3d_ELementBottomColor)
            End Select


            e.vy = -FallingSpeed
            e.vyS = e.vy

            e.vry = NextRotateAngle

            ElemNext.Add(e)
        Next
    End Sub




    Public Sub AddNewPiece()
        Dim i As Integer
        Dim e As ElementCLASS
        Dim px As Single


        px = GetRealX(Me, Funcs.GetRandom(1, GameElementCountX))
        For i = 1 To ElemNext.Count
            e = ElemNext.Item(1)

            e.ChangeDevice(Me, DeviceA)

            e.x = px
            e.y = Funcs.GetRealY(Me, GameElementCountY + i + 1)
            e.z = Funcs.GetRealZ(Me)

            e.ry = 0
            e.vry = 0

            e.vy = -FallingSpeed

            ElemPiece.Add(e)
            ElemCollection.Add(e)

            ElemNext.Remove(1)
        Next

        AllowInput = True
        AllowAccelerate = True
    End Sub






    'adds a new piece in the game
    'Public Sub AddNewPiece(ByVal g As GameCLASS)
    '    Dim i As Integer
    '    Dim px, py, pz As Single


    '    'gets a random x location for all of the elements
    '    px = GetRealX(Me, Funcs.GetRandom(1, GameElementCountX))

    '    For i = 1 To GameElementCountInPiece
    '        Dim e As ElementCLASS
    '        e = New ElementCLASS(Me, DeviceA, Enums.ModelType.Simple)


    '        py = Funcs.GetRealY(Me, GameElementCountY + i + 1)
    '        pz = Funcs.GetRealZ(Me)


    '        'each type differently sets colors
    '        Select Case g.Type
    '            Case Enums.GameType.Classic
    '                Dim c As Color
    '                c = Funcs.GetRandomColor(Me) 'gets a random color for all the faces of the element

    '                e.SetIt(px, py, pz, c, c, c, c, Dr3d_ELementTopColor, Dr3d_ELementBottomColor)

    '            Case Enums.GameType.Rotative

    '                Dim cf, cr, cb, cl As Color
    '                'gets a random colors for each face
    '                cf = Funcs.GetRandomColor(Me)
    '                cr = Funcs.GetRandomColor(Me)
    '                cb = Funcs.GetRandomColor(Me)
    '                cl = Funcs.GetRandomColor(Me)

    '                e.SetIt(px, py, pz, cf, cr, cb, cl, Dr3d_ELementTopColor, Dr3d_ELementBottomColor)
    '        End Select


    '        e.vy = -FallingSpeed
    '        e.vyS = e.vy

    '        ElemPiece.Add(e)
    '        ElemCollection.Add(e)
    '    Next

    '    AllowInput = True
    '    AllowAccelerate = True
    'End Sub





    Public Sub Compute()
        Dim e As ElementCLASS
        Dim ox, oy, ory, ovy As Single


        'nexts

        For Each e In ElemNext
            e.ry += e.vry
            If e.ry > 2 * Math.PI Then e.ry = 2 * Math.PI - e.ry
        Next







        GoTo over
        'static that aren't settled
        Dim ii, jj As Integer
        For ii = 1 To GameElementCountY
            For jj = 1 To GameElementCountX
                e = Elem(jj, ii)

                If Not (e Is Nothing) Then
                    ox = e.x
                    e.x += e.vx

                    If ((e.stopx > e.x) And (e.stopx < ox)) Or ((e.stopx > ox) And (e.stopx < e.x)) Then
                        e.vx = 0
                        e.x = e.stopx
                        e.x = Funcs.GetRealX(Me, Funcs.GetStaticX(Me, e.x))
                        e.stopx = -99

                        AllowInput = True
                    End If


                    e.ry += e.vry
                    If ((e.stopry >= e.ry) And (e.stopry <= ory)) Or ((e.stopry >= ory) And (e.stopry <= e.ry)) Then
                        e.vry = 0
                        'rotate it back and change colors on faces
                        e.ry = 0
                        e.RotateFaces(Cull.Clockwise)

                        AllowInput = True
                    End If

                    RemoveLines()
                End If
            Next
        Next

over:



        Dim vc, vl, vr As Boolean
        Dim ind As Integer 'index of e in collection

        'sort them from bottom to top
        ElemCollection = Funcs.SortElementsY(ElemCollection)

        ind = 0
        'these are the falling elements
        For Each e In ElemCollection
            Dim sx, sy, stox As Integer

            sx = Funcs.GetStaticX(Me, e.x)
            'sy = Funcs.GetStaticY(Me, e.y)
            stox = Funcs.GetStaticX(Me, e.stopx)
            If e.vx = 0 Then vc = True Else vc = False
            If e.vx < 0 Then vl = True Else vl = False
            If e.vx > 0 Then vr = True Else vr = False
            If sx = stox Then
                vl = False
                vr = False
                vc = True
            End If


            ind = ind + 1

            'save old position 
            ox = e.x
            oy = e.y
            ory = e.ry
            ovy = e.vy

            'input movment; check if need to be stopped
            e.x += e.vx
            If ((e.stopx >= e.x) And (e.stopx <= ox)) Or ((e.stopx >= ox) And (e.stopx <= e.x)) Then
                e.vx = 0
                e.x = e.stopx
                'e.x = Funcs.GetRealX(Me, Funcs.GetStaticX(Me, e.x))
                e.stopx = -99

                AllowInput = True
            End If


            e.ry += e.vry
            If ((e.stopry >= e.ry) And (e.stopry <= ory)) Or ((e.stopry >= ory) And (e.stopry <= e.ry)) Then
                e.vry = 0
                'rotate it back and change colors on faces
                e.ry = 0
                e.RotateFaces(Cull.Clockwise)

                AllowInput = True
            End If



            'falling; check if is on grid and if stops on something then make it static
            'falling only if nothing is under
            e.y += e.vy

            Dim m As Single

            If (Funcs.OnGridY(Me, oy, e.y, m)) Then
                sy = Funcs.GetStaticY(Me, e.y)

                If SolidNear(sx, sy, Enums.Side.Down, True, vc, vl, vr) Then
                    If sy > GameElementCountY Then
                        Over = True
                        Pause()
                    End If
                    e.vy = 0


                    If vl Then sx = sx - 1
                    If vr Then sx = sx + 1

                    e.y = Funcs.GetRealY(Me, sy)

                    If Elem(sx, sy) Is Nothing Then Elem(sx, sy) = ElemCollection.Item(ind)

                    'remove if is a piece member
                    Dim ep As ElementCLASS
                    Dim i As Integer
                    i = 0
                    For Each ep In ElemPiece
                        i = i + 1
                        If e Is ep Then
                            ElemPiece.Remove(i)
                            i = i - 1
                        End If
                    Next


                    ElemCollection.Remove(ind)

                    ind = ind - 1
                End If
            End If

            'If SolidNear(sx, sy, Enums.Side.Down, True, True, False, False) Then
            'e.vy = 0
            'Else
            'e.vy = e.vyS
            'End If

        Next

    End Sub








    Public Function MovePiece(ByVal Movement As Enums.PieceMovement) As Enums.ErrorCode
        Dim i As Integer
        Dim ok As Boolean
        Dim sx, sy As Integer
        Dim e As ElementCLASS

        Select Case Movement
            Case Enums.PieceMovement.MoveLeft
                'check if movement is possible
                ok = True
                For i = 1 To ElemPiece.Count
                    sx = Funcs.GetStaticX(Me, ElemPiece(i).x)
                    sy = Funcs.GetStaticX(Me, ElemPiece(i).y)
                    If SolidNear(ElemPiece(i).x, ElemPiece(i).y, Enums.Side.Left, True, True, True, True) Then Return Enums.ErrorCode.CouldNotMovePiece
                Next
                'move
                For i = 1 To ElemPiece.Count
                    ElemPiece(i).vx = -MovementSpeed
                    ElemPiece(i).stopx = ElemPiece(i).x - Dr3D_ElementSizeX - Dr3D_ElementSpaceX
                Next
                AllowInput = False
                Return Enums.ErrorCode.NoError
                '------------------------------
            Case Enums.PieceMovement.MoveRight
                'check if movement is possible
                ok = True
                For i = 1 To ElemPiece.Count
                    sx = Funcs.GetStaticX(Me, ElemPiece(i).x)
                    sy = Funcs.GetStaticX(Me, ElemPiece(i).y)
                    If SolidNear(ElemPiece(i).x, ElemPiece(i).y, Enums.Side.Right, True, True, True, True) Then Return Enums.ErrorCode.CouldNotMovePiece
                Next
                'move
                For i = 1 To ElemPiece.Count
                    ElemPiece(i).vx = MovementSpeed
                    ElemPiece(i).stopx = ElemPiece(i).x + Dr3D_ElementSizeX + Dr3D_ElementSpaceX
                Next
                AllowInput = False
                Return Enums.ErrorCode.NoError
                '------------------------------
            Case Enums.PieceMovement.Accelerate
                Select Case GameFallingMethod
                    Case Enums.FallingMethod.DropDown
                        'just drop down
                        ElemPiece = Funcs.SortElementsY(ElemPiece)
                        For Each e In ElemPiece
                            sx = Funcs.GetStaticX(Me, e.x)
                            sy = Funcs.GetShadow(Me, sx)
                            e.y = Funcs.GetRealY(Me, sy) - e.vy
                            Elem(sx, sy) = e
                            If sy > GameElementCountY Then
                                Over = True
                                Pause()
                            End If
                        Next
                        Compute()
                    Case Enums.FallingMethod.Accelerate
                        For i = 1 To ElemPiece.Count
                            ElemPiece(i).vy = -AccelerateSpeed 'accelerate piece
                            ElemPiece(i).vyS = ElemPiece(i).vy
                        Next
                End Select

                AllowAccelerate = False
                Return Enums.ErrorCode.NoError
                '------------------------------
            Case Enums.PieceMovement.Change
                Dim j As Integer
                Dim auxy As Single
                'each type of game differently
                Select Case Type
                    Case Enums.GameType.Classic
                        ElemPiece = Funcs.SortElementsY(ElemPiece)
                        auxy = ElemPiece.Item(ElemPiece.Count).y

                        For i = ElemPiece.Count To 1 Step -1
                            If i = 1 Then
                                ElemPiece.Item(i).y = auxy
                            Else
                                ElemPiece.Item(i).y = ElemPiece.Item(i - 1).y
                            End If
                        Next

                    Case Enums.GameType.Rotative
                        For i = 1 To ElemPiece.Count
                            ElemPiece.Item(i).vry = RotationSpeed
                            ElemPiece.Item(i).stopry = Math.PI / 2
                        Next

                        AllowInput = False
                End Select



        End Select

    End Function







    Public Function SolidNear(ByVal sx As Integer, ByVal sy As Integer, ByVal side As Enums.Side, ByVal verbound As Boolean, ByVal vercenter As Boolean, ByVal vermin As Boolean, ByVal vermax As Boolean, Optional ByVal nearness As Integer = 1) As Boolean
        Select Case side
            Case Enums.Side.Left
                'bounds check
                If verbound Then If sx - Dr3D_ElementSizeX - Dr3D_ElementSpaceX < 0 Then Return True
                'static element check / check both up and down elements in the left of this item
                If vercenter Then If Not (Elem(sx - 1, sy) Is Nothing) Then Return True
                If vermin Then If Not (Elem(sx - 1, sy - 1) Is Nothing) Then Return True
                If vermax Then If Not (Elem(sx - 1, sy + 1) Is Nothing) Then Return True
            Case Enums.Side.Right
                'bounds check
                If verbound Then If sx + Dr3D_ElementSizeX + Dr3D_ElementSpaceX > Funcs.GetMaxSpaceFromGameX(Me) Then Return True
                'static element check / check both up and down elements in the left of this item
                If vercenter Then If Not (Elem(sx + 1, sy) Is Nothing) Then Return True
                If vermin Then If Not (Elem(sx + 1, sy - 1) Is Nothing) Then Return True
                If vermax Then If Not (Elem(sx + 1, sy + 1) Is Nothing) Then Return True
            Case Enums.Side.Down
                'bounds check
                If verbound Then If sy - Dr3D_ElementSizeY - Dr3D_ElementSpaceY < 0 Then Return True
                'static element check / check both left and right and center elements in the bottom of this item
                If vercenter Then If Not (Elem(sx, sy - 1) Is Nothing) Then Return True
                If vermin Then If Not (Elem(sx - 1, sy - 1) Is Nothing) Then Return True
                If vermax Then If Not (Elem(sx + 1, sy - 1) Is Nothing) Then Return True
        End Select

        Return False
    End Function

#End Region







    '------------ D3D stuff here ------------
#Region " Direct 3D "

#Region " DeviceA "
    'The render sub of deviceA
    Public Sub RenderA()
        DeviceA.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Dr3D_BackColorDA, 1.0F, 0)
        DeviceA.BeginScene()


        SetViewAndProjection(DeviceA, Cam)

        ChangeLightSeting(DeviceA, Consts.OnPieceMultiply)
        SetLighting(DeviceA, True, True, False, False, True, False, True, False)
        RenderElements()

        ChangeLightSeting(DeviceA, 1 / Consts.OnPieceMultiply)
        SetLighting(DeviceA, True, True, True, True, True, True, False, False)
        Board.Render(Me, DeviceA)

        DeviceA.EndScene()
        DeviceA.Present()
    End Sub




    Public Sub RenderElements()
        Dim e As ElementCLASS

        'render dynamic
        For Each e In ElemCollection
            e.Render(DeviceA)
        Next

        'render static
        Dim i, j As Integer
        For i = 1 To GameElementCountY
            For j = 1 To GameElementCountX
                If Not (Elem(j, i) Is Nothing) Then Elem(j, i).Render(DeviceA)
            Next
        Next
    End Sub




    Public Sub SetViewAndProjection(ByVal dev As Device, ByVal c As CameraCL)
        dev.Transform.View = c.MX
        'dev.Transform.View = Matrix.LookAtLH(New Vector3(10, 10, -20), New Vector3(0, 0, 0), New Vector3(0, 1, 0))

        Dim aspc As Single
        aspc = CSng(dev.PresentationParameters.BackBufferWidth) / dev.PresentationParameters.BackBufferHeight

        dev.Transform.Projection = Matrix.PerspectiveFovLH(Math.PI / 4.0F, aspc, 1.0F, 500.0F)
    End Sub


    'lights
#Region " Setting Lights "

    Public Sub InitLights(ByVal dev As Device)
        Dim i As Integer

        'dev.Lights(0).Direction = New Vector3(1, 1, 1)
        'dev.Lights(1).Direction = New Vector3(1, 1, -1)
        'dev.Lights(2).Direction = New Vector3(1, -1, 1)
        'dev.Lights(3).Direction = New Vector3(1, -1, -1)
        'dev.Lights(4).Direction = New Vector3(-1, 1, 1)
        'dev.Lights(5).Direction = New Vector3(-1, 1, -1)
        'dev.Lights(6).Direction = New Vector3(-1, -1, 1)
        'dev.Lights(7).Direction = New Vector3(-1, -1, -1)

        dev.Lights(0).Direction = New Vector3(0, 0, 1)
        dev.Lights(1).Direction = New Vector3(-1, 0, 0)
        dev.Lights(2).Direction = New Vector3(1, 0, 0)
        dev.Lights(3).Direction = New Vector3(0, -1, 0)
        dev.Lights(4).Direction = New Vector3(0, 1, 0)
        dev.Lights(5).Direction = New Vector3(0, 0, -1)
        dev.Lights(6).Direction = New Vector3(0, 0, 1)
        dev.Lights(7).Direction = New Vector3(0, 0, 1)
        For i = 0 To 7
            dev.Lights(i).Type = LightType.Directional
            dev.Lights(i).Diffuse = Color.FromArgb(Consts.LightsDiffuse, Consts.LightsDiffuse, Consts.LightsDiffuse)
            dev.Lights(i).Specular = Color.FromArgb(Consts.LightsSpecular, Consts.LightsSpecular, Consts.LightsSpecular)
            dev.Lights(i).Ambient = Color.FromArgb(Consts.LightsAmbient, Consts.LightsAmbient, Consts.LightsAmbient)
            dev.Lights(i).Update()
            dev.Lights(i).Enabled = False
        Next
    End Sub


    Public Sub ChangeLightSeting(ByVal dev As Device, ByVal multiply As Single)
        Dim i As Integer

        For i = 0 To 7
            dev.Lights(i).Diffuse = Color.FromArgb(Math.Round(dev.Lights(i).Diffuse.R * multiply), Math.Round(dev.Lights(i).Diffuse.G * multiply), Math.Round(dev.Lights(i).Diffuse.B * multiply))
            dev.Lights(i).Ambient = Color.FromArgb(Math.Round(dev.Lights(i).Ambient.R * multiply), Math.Round(dev.Lights(i).Ambient.G * multiply), Math.Round(dev.Lights(i).Ambient.B * multiply))
            dev.Lights(i).Specular = Color.FromArgb(Math.Round(dev.Lights(i).Specular.R * multiply), Math.Round(dev.Lights(i).Specular.G * multiply), Math.Round(dev.Lights(i).Specular.B * multiply))
        Next
    End Sub


    Public Sub SetLighting(ByVal dev As Device, ByVal l1 As Boolean, ByVal l2 As Boolean, ByVal l3 As Boolean, ByVal l4 As Boolean, ByVal l5 As Boolean, ByVal l6 As Boolean, ByVal l7 As Boolean, ByVal l8 As Boolean)
        dev.Lights(0).Enabled = l1
        dev.Lights(1).Enabled = l2
        dev.Lights(2).Enabled = l3
        dev.Lights(3).Enabled = l4
        dev.Lights(4).Enabled = l5
        dev.Lights(5).Enabled = l6
        dev.Lights(6).Enabled = l7
        'dev.Lights(7).Enabled = l8
    End Sub

#End Region

#End Region





#Region " Device B "

    Public Sub RenderB()
        DeviceB.Clear(ClearFlags.Target Or ClearFlags.ZBuffer, Dr3D_BackColorDB, 1.0, 0)
        DeviceB.BeginScene()

        DeviceB.Transform.View = Matrix.LookAtLH(New Vector3(0, 2, -5), New Vector3(0, 0, 0), New Vector3(0, 1, 0))
        Dim aspc As Single
        aspc = CSng(DeviceB.PresentationParameters.BackBufferWidth) / DeviceB.PresentationParameters.BackBufferHeight
        DeviceB.Transform.Projection = Matrix.PerspectiveFovLH(Math.PI / 4.0F, aspc, 1.0F, 500.0F)

        'DeviceB.Transform.World = Matrix.RotationY(NextRotateAngle)

        'lights
        DeviceB.Lights(0).Type = LightType.Directional
        DeviceB.Lights(0).Direction = New Vector3(0, 0, 1)
        DeviceB.Lights(0).Diffuse = Color.FromArgb(200, 200, 200)
        DeviceB.Lights(0).Specular = Color.FromArgb(70, 70, 70)
        DeviceB.Lights(0).Ambient = Color.FromArgb(20, 20, 20)
        DeviceB.Lights(0).Enabled = True
        DeviceB.Lights(0).Update()

        DeviceB.Lights(1).Type = LightType.Directional
        DeviceB.Lights(1).Direction = New Vector3(-1, 0, 0.2)
        DeviceB.Lights(1).Diffuse = Color.FromArgb(200, 200, 200)
        DeviceB.Lights(1).Specular = Color.FromArgb(70, 70, 70)
        DeviceB.Lights(1).Ambient = Color.FromArgb(20, 20, 20)
        DeviceB.Lights(1).Enabled = True
        DeviceB.Lights(1).Update()

        DeviceB.Lights(2).Type = LightType.Directional
        DeviceB.Lights(2).Direction = New Vector3(-0.2, -0.1, -0.3)
        DeviceB.Lights(2).Diffuse = Color.FromArgb(200, 200, 200)
        DeviceB.Lights(2).Specular = Color.FromArgb(70, 70, 70)
        DeviceB.Lights(2).Ambient = Color.FromArgb(20, 20, 20)
        DeviceB.Lights(2).Enabled = True
        DeviceB.Lights(2).Update()


        Dim e As ElementCLASS
        For Each e In ElemNext
            e.Render(DeviceB)
        Next

        DeviceB.EndScene()
        DeviceB.Present()
    End Sub


#End Region




#Region " Device Initialization "

    'Main device
    Public Sub InitDeviceA()
        Dim pp As PresentParameters = New PresentParameters()
        pp.Windowed = True
        pp.SwapEffect = SwapEffect.Discard
        pp.EnableAutoDepthStencil = True
        pp.AutoDepthStencilFormat = DepthFormat.D16

        DeviceA = New Device(0, DeviceType.Hardware, win.PlayP, CreateFlags.SoftwareVertexProcessing, pp)
        AddHandler DeviceA.DeviceReset, AddressOf InitDeviceA_OnReset
        InitDeviceA_OnReset(DeviceA, Nothing)
    End Sub

    Public Sub InitDeviceA_OnReset(ByVal sender As Object, ByVal e As EventArgs)
        Dim d As Device = CType(sender, Device)

        'd.RenderState.CullMode = Cull.Clockwise
        d.RenderState.Lighting = True
        d.RenderState.ZBufferEnable = True
        d.RenderState.SpecularEnable = True
        'd.RenderState.DitherEnable = True

        'RESOURCES LOADER HERE
        'tex1 = TextureLoader.FromFile(DeviceA, "board.jpg")
    End Sub




    'Secondary Device
    Public Sub InitDeviceB()
        Dim pp As PresentParameters = New PresentParameters()
        pp.Windowed = True
        pp.SwapEffect = SwapEffect.Discard
        pp.EnableAutoDepthStencil = True
        pp.AutoDepthStencilFormat = DepthFormat.D16

        DeviceB = New Device(0, DeviceType.Hardware, win.NextPB, CreateFlags.SoftwareVertexProcessing, pp)
        AddHandler DeviceB.DeviceReset, AddressOf InitDeviceB_OnReset
        InitDeviceB_OnReset(DeviceB, Nothing)
    End Sub

    Public Sub InitDeviceB_OnReset(ByVal sender As Object, ByVal e As EventArgs)
        Dim d As Device = CType(sender, Device)

        'd.RenderState.CullMode = Cull.Clockwise
        d.RenderState.Lighting = True
        d.RenderState.ZBufferEnable = True
        d.RenderState.SpecularEnable = True

        'RESOURCES LOADER HERE
        'textures
    End Sub

#End Region

#End Region
    '///////////// D3D stuff here /////////////




#Region " Other "

    Public Sub Start()
        Paused = False
        'other things when the game starts
        win.Time.Start()
        AllowInput = True
    End Sub
    Public Sub Pause()
        Paused = True
        'other things when the game stops
        win.Time.Stop()
        AllowInput = False
    End Sub






    Public Sub AddColorInTheGame(ByVal c As Color)
        Colors.Add(c)
        'other things can happen when a color is added
    End Sub
    '
    '
    Public Sub AddColorInTheGame(ByVal c As Collection)
        Dim co As Color
        For Each co In c
            AddColorInTheGame(CType(co, Color))
        Next
    End Sub

#End Region

End Class
