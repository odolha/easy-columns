Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.Drawing

'a 3d object (just like a mesh)
Public Class ModelCLASS
    'cubic vars
    Public Type As Enums.ModelType = Enums.ModelType.NoModelAllocation
    Public FrontVB, LeftVB, RightVB, TopVB, BottomVB, BackVB As VertexBuffer
    Public LeftFrontVB, FrontRightVB, BackLeftVB, RightBackVB As VertexBuffer



#Region " Cubic "

    'initialize a cubic model
    Public Sub New(ByVal dev As Device, ByVal typeP As Enums.ModelType, ByVal SizeX As Single, ByVal SizeY As Single, ByVal SizeZ As Single, ByVal SizeEdge As Single, ByVal FrontColor As Color, ByVal LeftColor As Color, ByVal RightColor As Color, ByVal TopColor As Color, ByVal BottomColor As Color, ByVal BackColor As Color, ByVal TransitionMode As Enums.CubicFaceTransitionMode)
        If typeP = Enums.ModelType.Cubic Then
            Type = typeP

            'define temp points to use for all faces
            Dim p1, p2, p3, p4, p5, p6, p7, p8 As Vector3
            Dim p9, p10, p11, p12, p13, p14, p15, p16 As Vector3
            Dim p17, p18, p19, p20, p21, p22, p23, p24 As Vector3
            Dim p25, p26, p27, p28, p29, p30, p31, p32 As Vector3
            p1 = New Vector3(-SizeX / 2 + SizeEdge, SizeY / 2, -SizeZ / 2)
            p2 = New Vector3(+SizeX / 2 - SizeEdge, SizeY / 2, -SizeZ / 2)
            p3 = New Vector3(-SizeX / 2 + SizeEdge, -SizeY / 2, -SizeZ / 2)
            p4 = New Vector3(+SizeX / 2 - SizeEdge, -SizeY / 2, -SizeZ / 2)
            p5 = New Vector3(-SizeX / 2 + SizeEdge / 2, SizeY / 2 - SizeEdge, -SizeZ / 2)
            p6 = New Vector3(+SizeX / 2 - SizeEdge / 2, SizeY / 2 - SizeEdge, -SizeZ / 2)
            p7 = New Vector3(-SizeX / 2 + SizeEdge / 2, -SizeY / 2 + SizeEdge, -SizeZ / 2)
            p8 = New Vector3(+SizeX / 2 - SizeEdge / 2, -SizeY / 2 + SizeEdge, -SizeZ / 2)

            p9 = New Vector3(+SizeX / 2, SizeY / 2, -SizeZ / 2 + SizeEdge)
            p10 = New Vector3(+SizeX / 2, SizeY / 2, +SizeZ / 2 - SizeEdge)
            p11 = New Vector3(+SizeX / 2, -SizeY / 2, -SizeZ / 2 + SizeEdge)
            p12 = New Vector3(+SizeX / 2, -SizeY / 2, +SizeZ / 2 - SizeEdge)
            p13 = New Vector3(+SizeX / 2, SizeY / 2 - SizeEdge, -SizeZ / 2 + SizeEdge / 2)
            p14 = New Vector3(+SizeX / 2, SizeY / 2 - SizeEdge, +SizeZ / 2 - SizeEdge / 2)
            p15 = New Vector3(+SizeX / 2, -SizeY / 2 + SizeEdge, -SizeZ / 2 + SizeEdge / 2)
            p16 = New Vector3(+SizeX / 2, -SizeY / 2 + SizeEdge, +SizeZ / 2 - SizeEdge / 2)

            p17 = New Vector3(+SizeX / 2 - SizeEdge, SizeY / 2, SizeZ / 2)
            p18 = New Vector3(-SizeX / 2 + SizeEdge, SizeY / 2, SizeZ / 2)
            p19 = New Vector3(+SizeX / 2 - SizeEdge, -SizeY / 2, SizeZ / 2)
            p20 = New Vector3(-SizeX / 2 + SizeEdge, -SizeY / 2, SizeZ / 2)
            p21 = New Vector3(+SizeX / 2 - SizeEdge / 2, SizeY / 2 - SizeEdge, SizeZ / 2)
            p22 = New Vector3(-SizeX / 2 + SizeEdge / 2, SizeY / 2 - SizeEdge, SizeZ / 2)
            p23 = New Vector3(+SizeX / 2 - SizeEdge / 2, -SizeY / 2 + SizeEdge, SizeZ / 2)
            p24 = New Vector3(-SizeX / 2 + SizeEdge / 2, -SizeY / 2 + SizeEdge, SizeZ / 2)

            p25 = New Vector3(-SizeX / 2, SizeY / 2, +SizeZ / 2 - SizeEdge)
            p26 = New Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2 + SizeEdge)
            p27 = New Vector3(-SizeX / 2, -SizeY / 2, +SizeZ / 2 - SizeEdge)
            p28 = New Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2 + SizeEdge)
            p29 = New Vector3(-SizeX / 2, SizeY / 2 - SizeEdge, +SizeZ / 2 - SizeEdge / 2)
            p30 = New Vector3(-SizeX / 2, SizeY / 2 - SizeEdge, -SizeZ / 2 + SizeEdge / 2)
            p31 = New Vector3(-SizeX / 2, -SizeY / 2 + SizeEdge, +SizeZ / 2 - SizeEdge / 2)
            p32 = New Vector3(-SizeX / 2, -SizeY / 2 + SizeEdge, -SizeZ / 2 + SizeEdge / 2)


            _3D.CreateVB8(dev, FrontVB, p1, p2, p5, p6, p7, p8, p3, p4, New Vector3(0, 0, -1), FrontColor)
            _3D.CreateVB8(dev, RightVB, p9, p10, p13, p14, p15, p16, p11, p12, New Vector3(1, 0, 0), RightColor)
            _3D.CreateVB8(dev, LeftVB, p25, p26, p29, p30, p31, p32, p27, p28, New Vector3(-1, 0, 0), LeftColor)
            _3D.CreateVB8(dev, BackVB, p17, p18, p21, p22, p23, p24, p19, p20, New Vector3(0, 0, 1), BackColor)
            _3D.CreateVB8(dev, BottomVB, p3, p4, p28, p11, p27, p12, p20, p19, New Vector3(0, 1, 0), BottomColor)
            _3D.CreateVB8(dev, TopVB, p18, p17, p25, p10, p26, p9, p1, p2, New Vector3(0, -1, 0), TopColor)
            _3D.CreateVB8(dev, FrontRightVB, p2, p9, p6, p13, p8, p15, p4, p11, New Vector3(1, 0, -1), FrontColor, RightColor)
            _3D.CreateVB8(dev, LeftFrontVB, p26, p1, p30, p5, p32, p7, p28, p3, New Vector3(-1, 0, -1), LeftColor, FrontColor)
            _3D.CreateVB8(dev, RightBackVB, p10, p17, p14, p21, p16, p23, p12, p19, New Vector3(1, 0, 1), RightColor, BackColor)
            _3D.CreateVB8(dev, BackLeftVB, p18, p25, p22, p29, p24, p31, p20, p27, New Vector3(-1, 0, 1), BackColor, LeftColor)
        End If
    End Sub


    'for cubic only
    Public Sub SetColors(ByVal Fro As Color, ByVal Rig As Color, ByVal Bac As Color, ByVal Lef As Color, ByVal Top As Color, ByVal Bot As Color)
        _3D.ChangeVB8Colors(FrontVB, Fro)
        _3D.ChangeVB8Colors(RightVB, Rig)
        _3D.ChangeVB8Colors(BackVB, Bac)
        _3D.ChangeVB8Colors(LeftVB, Lef)
        _3D.ChangeVB8Colors(TopVB, Top)
        _3D.ChangeVB8Colors(BottomVB, Bot)

        _3D.ChangeVB8Colors(FrontRightVB, Fro, Rig)
        _3D.ChangeVB8Colors(RightBackVB, Rig, Bac)
        _3D.ChangeVB8Colors(BackLeftVB, Bac, Lef)
        _3D.ChangeVB8Colors(LeftFrontVB, Lef, Fro)
    End Sub

#End Region





#Region " Simple "

    Public Sub New(ByVal dev As Device, ByVal typeP As Enums.ModelType, ByVal SizeX As Single, ByVal SizeY As Single, ByVal SizeZ As Single, ByVal FrontColor As Color, ByVal LeftColor As Color, ByVal RightColor As Color, ByVal TopColor As Color, ByVal BottomColor As Color, ByVal BackColor As Color)
        Type = typeP

        Dim p1, p2, p3, p4, p5, p6, p7, p8 As Vector3

        p1 = New Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2)
        p2 = New Vector3(SizeX / 2, SizeY / 2, -SizeZ / 2)
        p3 = New Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2)
        p4 = New Vector3(SizeX / 2, -SizeY / 2, -SizeZ / 2)
        p5 = New Vector3(-SizeX / 2, SizeY / 2, SizeZ / 2)
        p6 = New Vector3(SizeX / 2, SizeY / 2, SizeZ / 2)
        p7 = New Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2)
        p8 = New Vector3(SizeX / 2, -SizeY / 2, SizeZ / 2)

        _3D.CreateVB4(dev, FrontVB, p1, p2, p3, p4, New Vector3(0, 0, -1))
        _3D.CreateVB4(dev, RightVB, p2, p6, p4, p8, New Vector3(1, 0, 0))
        _3D.CreateVB4(dev, BackVB, p6, p5, p8, p7, New Vector3(0, 0, 1))
        _3D.CreateVB4(dev, LeftVB, p5, p1, p7, p3, New Vector3(-1, 0, 0))
        _3D.CreateVB4(dev, BottomVB, p3, p4, p7, p8, New Vector3(0, 1, 0))
        _3D.CreateVB4(dev, TopVB, p5, p6, p1, p2, New Vector3(0, -1, 0))
    End Sub




#End Region








    'render for any type
    Public Sub Render(ByVal dev As Device, ByVal sender As ElementCLASS)
        Select Case Type
            Case Enums.ModelType.Cubic
                Dim m As New Material()
                m.Ambient = Color.FromArgb(Consts.PieceAmbient, Consts.PieceAmbient, Consts.PieceAmbient)
                m.Specular = Color.FromArgb(Consts.PieceSpecular, Consts.PieceSpecular, Consts.PieceSpecular)
                dev.Material = m

                dev.VertexFormat = Types.PosNorColTexFORMAT


                dev.SetStreamSource(0, FrontVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, FrontRightVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, TopVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, RightVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, LeftFrontVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, LeftVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, RightBackVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, BackLeftVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, BottomVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                dev.SetStreamSource(0, BackVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 6)

                '---
            Case Enums.ModelType.Simple
                Dim m As New Material()
                m.Ambient = Color.FromArgb(Consts.PieceAmbient, Consts.PieceAmbient, Consts.PieceAmbient)
                m.Specular = Color.FromArgb(Consts.PieceSpecular, Consts.PieceSpecular, Consts.PieceSpecular)

                dev.VertexFormat = Types.PosNorTexFORMAT

                m.Diffuse = sender.FrontColor
                dev.Material = m
                dev.SetStreamSource(0, FrontVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

                m.Diffuse = sender.TopColor
                dev.Material = m
                dev.SetStreamSource(0, TopVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

                m.Diffuse = sender.RightColor
                dev.Material = m
                dev.SetStreamSource(0, RightVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

                m.Diffuse = sender.LeftColor
                dev.Material = m
                dev.SetStreamSource(0, LeftVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

                m.Diffuse = sender.BottomColor
                dev.Material = m
                dev.SetStreamSource(0, BottomVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

                m.Diffuse = sender.BackColor
                dev.Material = m
                dev.SetStreamSource(0, BackVB, 0)
                dev.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2)

        End Select
    End Sub


End Class
