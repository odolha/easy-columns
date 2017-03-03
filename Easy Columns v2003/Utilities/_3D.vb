Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.Drawing

'utilities for 3d consturctions and managing
Public Module _3D

    'creates a non-colored, textured, 4-vertices flat face
    Public Sub CreateFaceTextured(ByVal dev As Device, ByRef vb As VertexBuffer, ByVal P1 As Vector3, ByVal P2 As Vector3, ByVal P3 As Vector3, ByVal P4 As Vector3, ByVal n As Vector3)
        vb = New VertexBuffer(GetType(CustomVertex.PositionNormalTextured), 4, dev, Usage.SoftwareProcessing, CustomVertex.PositionNormalTextured.Format, Pool.Default)

        Dim v() As CustomVertex.PositionNormalTextured = CType(vb.Lock(0, 0), CustomVertex.PositionNormalTextured())

        v(0).Position = P1
        v(1).Position = P2
        v(2).Position = P3
        v(3).Position = P4

        v(0).Normal = n
        v(1).Normal = n
        v(2).Normal = n
        v(3).Normal = n

        'to generate good coordinates for rectangel mapping
        Dim minh, minv, maxh, maxv, mx, my As Single
        minh = Math.Min(Math.Min(P1.X, P2.X), Math.Min(P3.X, P4.X)) 'gets the horisontal min value
        maxh = Math.Max(Math.Max(P1.X, P2.X), Math.Max(P3.X, P4.X)) 'gets the horisontal max value
        minv = Math.Min(Math.Min(P1.Y, P2.Y), Math.Min(P3.Y, P4.Y)) 'gets the vertical min value
        maxv = Math.Max(Math.Max(P1.Y, P2.Y), Math.Max(P3.Y, P4.Y)) 'gets the vertical max value
        If maxh - minh > maxv - minv Then
            maxv = minv + (maxh - minh)
        Else
            maxh = minh + (maxv - minv)
        End If


        Dim i As Integer
        For i = 0 To 3
            v(i).Tu = (v(i).X - minh) / (maxh - minh)
            v(i).Tv = (v(i).Y - minv) / (maxv - minv)
        Next


        vb.Unlock()
    End Sub
    '
    '
    Public Sub CreateFaceTextured(ByVal dev As Device, ByRef vb As VertexBuffer, ByVal P1x As Single, ByVal P1y As Single, ByVal P1z As Single, ByVal P2x As Single, ByVal P2y As Single, ByVal P2z As Single, ByVal P3x As Single, ByVal P3y As Single, ByVal P3z As Single, ByVal P4x As Single, ByVal P4y As Single, ByVal P4z As Single, ByVal nx As Single, ByVal ny As Single, ByVal nz As Single)
        CreateFaceTextured(dev, vb, New Vector3(P1x, P1y, P1z), New Vector3(P2x, P2y, P2z), New Vector3(P3x, P3y, P3z), New Vector3(P4x, P4y, P4z), New Vector3(nx, ny, nz))
    End Sub





    'make a vertical face with 8 vertices PosNorColTex
    Public Sub CreateVB8(ByVal dev As Device, ByRef VB As VertexBuffer, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3, ByVal p4 As Vector3, ByVal p5 As Vector3, ByVal p6 As Vector3, ByVal p7 As Vector3, ByVal p8 As Vector3, ByVal n1 As Vector3, ByVal n2 As Vector3, ByVal n3 As Vector3, ByVal n4 As Vector3, ByVal n5 As Vector3, ByVal n6 As Vector3, ByVal n7 As Vector3, ByVal n8 As Vector3, ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c4 As Color, ByVal c5 As Color, ByVal c6 As Color, ByVal c7 As Color, ByVal c8 As Color)
        VB = New VertexBuffer(GetType(Types.PosNorColTex), 8, dev, Usage.SoftwareProcessing, Types.PosNorColTexFORMAT, Pool.Default)
        Dim v As Types.PosNorColTex() = CType(VB.Lock(0, 0), Types.PosNorColTex())

        v(0).x = p1.X : v(0).y = p1.Y : v(0).z = p1.Z
        v(1).x = p2.X : v(1).y = p2.Y : v(1).z = p2.Z
        v(2).x = p3.X : v(2).y = p3.Y : v(2).z = p3.Z
        v(3).x = p4.X : v(3).y = p4.Y : v(3).z = p4.Z
        v(4).x = p5.X : v(4).y = p5.Y : v(4).z = p5.Z
        v(5).x = p6.X : v(5).y = p6.Y : v(5).z = p6.Z
        v(6).x = p7.X : v(6).y = p7.Y : v(6).z = p7.Z
        v(7).x = p8.X : v(7).y = p8.Y : v(7).z = p8.Z

        v(0).nx = n1.X : v(0).ny = n1.Y : v(0).nz = n1.Z
        v(1).nx = n2.X : v(1).ny = n2.Y : v(1).nz = n2.Z
        v(2).nx = n3.X : v(2).ny = n3.Y : v(2).nz = n3.Z
        v(3).nx = n4.X : v(3).ny = n4.Y : v(3).nz = n4.Z
        v(4).nx = n5.X : v(4).ny = n5.Y : v(4).nz = n5.Z
        v(5).nx = n6.X : v(5).ny = n6.Y : v(5).nz = n6.Z
        v(6).nx = n7.X : v(6).ny = n7.Y : v(6).nz = n7.Z
        v(7).nx = n8.X : v(7).ny = n8.Y : v(7).nz = n8.Z


        v(0).Color = c1.ToArgb
        v(1).Color = c2.ToArgb
        v(2).Color = c3.ToArgb
        v(3).Color = c4.ToArgb
        v(4).Color = c5.ToArgb
        v(5).Color = c6.ToArgb
        v(6).Color = c7.ToArgb
        v(7).Color = c8.ToArgb

        VB.Unlock()
    End Sub
    '
    '
    Public Sub CreateVB8(ByVal dev As Device, ByRef VB As VertexBuffer, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3, ByVal p4 As Vector3, ByVal p5 As Vector3, ByVal p6 As Vector3, ByVal p7 As Vector3, ByVal p8 As Vector3, ByVal n As Vector3, ByVal c As Color)
        CreateVB8(dev, VB, p1, p2, p3, p4, p5, p6, p7, p8, p1, p2, p3, p4, p5, p6, p7, p8, c, c, c, c, c, c, c, c)
    End Sub
    '
    '
    Public Sub CreateVB8(ByVal dev As Device, ByRef VB As VertexBuffer, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3, ByVal p4 As Vector3, ByVal p5 As Vector3, ByVal p6 As Vector3, ByVal p7 As Vector3, ByVal p8 As Vector3, ByVal n As Vector3, ByVal c1357 As Color, ByVal c2468 As Color)
        CreateVB8(dev, VB, p1, p2, p3, p4, p5, p6, p7, p8, p1, p2, p3, p4, p5, p6, p7, p8, c1357, c2468, c1357, c2468, c1357, c2468, c1357, c2468)
    End Sub

    'changes colors internally in the buffer
    Public Sub ChangeVB8Colors(ByRef VB As VertexBuffer, ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c4 As Color, ByVal c5 As Color, ByVal c6 As Color, ByVal c7 As Color, ByVal c8 As Color)
        Dim v As Types.PosNorColTex() = CType(VB.Lock(0, 0), Types.PosNorColTex())

        v(0).Color = c1.ToArgb
        v(1).Color = c2.ToArgb
        v(2).Color = c3.ToArgb
        v(3).Color = c4.ToArgb
        v(4).Color = c5.ToArgb
        v(5).Color = c6.ToArgb
        v(6).Color = c7.ToArgb
        v(7).Color = c8.ToArgb

        VB.Unlock()
    End Sub
    '
    '
    Public Sub ChangeVB8Colors(ByRef VB As VertexBuffer, ByVal c As Color)
        ChangeVB8Colors(VB, c, c, c, c, c, c, c, c)
    End Sub
    '
    '
    Public Sub ChangeVB8Colors(ByRef VB As VertexBuffer, ByVal c1357 As Color, ByVal c2468 As Color)
        ChangeVB8Colors(VB, c1357, c2468, c1357, c2468, c1357, c2468, c1357, c2468)
    End Sub






    Public Sub CreateVB4(ByVal dev As Device, ByRef VB As VertexBuffer, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3, ByVal p4 As Vector3, ByVal n1 As Vector3, ByVal n2 As Vector3, ByVal n3 As Vector3, ByVal n4 As Vector3)
        VB = New VertexBuffer(GetType(Types.PosNorTex), 4, dev, Usage.SoftwareProcessing, Types.PosNorTexFORMAT, Pool.Default)
        Dim v As Types.PosNorTex() = CType(VB.Lock(0, 0), Types.PosNorTex())

        v(0).x = p1.X : v(0).y = p1.Y : v(0).z = p1.Z
        v(1).x = p2.X : v(1).y = p2.Y : v(1).z = p2.Z
        v(2).x = p3.X : v(2).y = p3.Y : v(2).z = p3.Z
        v(3).x = p4.X : v(3).y = p4.Y : v(3).z = p4.Z

        v(0).nx = n1.X : v(0).ny = n1.Y : v(0).nz = n1.Z
        v(1).nx = n2.X : v(1).ny = n2.Y : v(1).nz = n2.Z
        v(2).nx = n3.X : v(2).ny = n3.Y : v(2).nz = n3.Z
        v(3).nx = n4.X : v(3).ny = n4.Y : v(3).nz = n4.Z

        VB.Unlock()
    End Sub
    '
    '
    Public Sub CreateVB4(ByVal dev As Device, ByRef VB As VertexBuffer, ByVal p1 As Vector3, ByVal p2 As Vector3, ByVal p3 As Vector3, ByVal p4 As Vector3, ByVal n As Vector3)
        CreateVB4(dev, VB, p1, p2, p3, p4, p1, p2, p3, p4)
    End Sub




End Module
