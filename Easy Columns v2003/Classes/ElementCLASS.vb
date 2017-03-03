Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.Drawing

'the most important class that stores and handles one 3d element in the
'game
Public Class ElementCLASS

    Public slx, sly As Integer 'if is sliding then the object on which / -1,-1 means on bottom
    Public x, y, z, ry As Single
    Public vx, vy, vz, vry, vyS As Single
    Public stopx, stopry As Single
    Public Model As ModelCLASS
    Public FrontColor, LeftColor, RightColor, TopColor, BottomColor, BackColor As Color

    Public dis As Boolean 'only used when processing disappearing elements


    Public Sub New(ByVal g As GameCLASS, ByVal dev As Device, ByVal modeltypeP As Enums.ModelType)
        Dim tc As Color 'just a temp color until the owner changes them
        tc = Color.White

        If modeltypeP = Enums.ModelType.Cubic Then Model = New ModelCLASS(dev, modeltypeP, g.Dr3D_ElementSizeX, g.Dr3D_ElementSizeY, g.Dr3D_ElementSizeZ, g.Dr3D_ElementCubicEdgeSize, tc, tc, tc, tc, tc, tc, Enums.CubicFaceTransitionMode.Smooth)
        If modeltypeP = Enums.ModelType.Simple Then Model = New ModelCLASS(dev, modeltypeP, g.Dr3D_ElementSizeX, g.Dr3D_ElementSizeY, g.Dr3D_ElementSizeZ, tc, tc, tc, tc, tc, tc)

        vx = 0
        vy = 0
        vyS = 0
        vz = 0
        ry = 0

        stopx = -99
        stopry = -99

        dis = False
    End Sub


    Public Sub SetIt(ByVal xP As Single, ByVal yP As Single, ByVal zP As Single, ByVal FrontColorP As Color, ByVal RightColorP As Color, ByVal BackColorP As Color, ByVal LeftColorP As Color, ByVal TopColorP As Color, ByVal BottomColorP As Color)
        x = xP : y = yP : z = zP
        FrontColor = FrontColorP
        RightColor = RightColorP
        BackColor = BackColorP
        LeftColor = LeftColorP
        TopColor = TopColorP
        BottomColor = BottomColorP

        If Model.Type = Enums.ModelType.Cubic Then Model.SetColors(FrontColorP, LeftColorP, BackColorP, LeftColorP, TopColorP, BottomColorP)
    End Sub



    'rotate faces - for modern type of game
    Public Sub RotateFaces(ByVal dir As Cull)
        Dim auxc As Color

        If dir = Cull.Clockwise Then
            auxc = FrontColor
            FrontColor = RightColor
            RightColor = BackColor
            BackColor = LeftColor
            LeftColor = auxc
        End If
        If dir = Cull.CounterClockwise Then
            auxc = FrontColor
            FrontColor = LeftColor
            LeftColor = BackColor
            BackColor = RightColor
            RightColor = auxc
        End If


        If Model.Type = Enums.ModelType.Cubic Then Model.SetColors(FrontColor, LeftColor, BackColor, LeftColor, TopColor, BottomColor)
    End Sub




    Public Sub Render(ByVal dev As Device)
        'dev.Transform.World = Matrix.Multiply(Matrix.RotationY(Environment.TickCount / 1000), Matrix.Translation(New Vector3(x, y, z)))
        dev.Transform.World = Matrix.Multiply(Matrix.RotationY(ry), Matrix.Translation(New Vector3(x, y, z)))

        Model.Render(dev, Me)
    End Sub


    Public Sub ChangeDevice(ByVal g As GameCLASS, ByVal dev As Device)
        If Model.Type = Enums.ModelType.Simple Then Model = New ModelCLASS(dev, Model.Type, g.Dr3D_ElementSizeX, g.Dr3D_ElementSizeY, g.Dr3D_ElementSizeZ, FrontColor, LeftColor, RightColor, TopColor, BottomColor, BackColor)
    End Sub
End Class
