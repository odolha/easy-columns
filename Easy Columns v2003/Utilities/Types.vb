Imports System.Drawing
Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D

'Useful types that are not included in the .net interface
Public Module Types

    'FVF structure
    Public Structure PosNorColTex
        Public x, y, z As Single
        Public nx, ny, nz As Single
        Public Color As Int32
        Public tu, tv As Single

    End Structure
    Public Const PosNorColTexFORMAT As Short = (VertexFormats.Position Or VertexFormats.Normal Or VertexFormats.Diffuse Or VertexFormats.Texture1)



    'fvf 2
    Public Structure PosNorTex
        Public x, y, z As Single
        Public nx, ny, nz As Single
        Public tu, tv As Single
    End Structure
    Public Const PosNorTexFORMAT As Short = (VertexFormats.Position Or VertexFormats.Normal Or VertexFormats.Texture1)






    'Class that stores file information in two different variables
    Public Class File
        Public name As String
        Public ext As String


        Public Sub New()
            name = ""
            ext = ""
        End Sub


        Public Sub Split(ByVal fullname As String)
            Try
                name = fullname.Remove(fullname.Length - 4, 4)
                ext = fullname.Remove(0, fullname.Length - 5)
            Catch
            End Try
        End Sub


        Public Function IsEmpty() As Boolean
            If name = "" And ext = "" Then Return True Else Return False
        End Function
    End Class


End Module
