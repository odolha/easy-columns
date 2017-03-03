Imports System.Drawing
Imports System.Math


'Functions to be used from anyowhere in the program
Public Module Funcs

    'Given a path and optionally an extention it returns a collection 
    'of strings that signify all the files found
    Public Function GetFileList(ByVal path As String, Optional ByVal extention As String = ".*") As Collection
        Dim tc As New Collection() 'temporary collection to store files

        Dim f As Types.File
        f = New Types.File()
        f.Split(Dir(path + "*" + extention))
        If f.name <> "" Then tc.Add(f)

        While f.name <> ""
            f = New Types.File()
            f.Split(Dir())
            If f.name <> "" Then tc.Add(f)
        End While

        Return tc
    End Function




    'Given two colors it returns the distance between them
    Public Function GetColorDifference(ByVal c1 As Color, ByVal c2 As Color) As Integer
        Dim r, g, b As Integer
        r = CType(c1.R, Short) - CType(c2.R, Short)
        g = CType(c1.G, Short) - CType(c2.G, Short)
        b = CType(c1.B, Short) - CType(c2.B, Short)

        Return Abs(r) + Abs(g) + Abs(b)
    End Function




    'Gets the bounds of the space for a given game
    Public Sub GetMaxSpaceFromGame(ByVal g As GameCLASS, ByRef mx As Single, ByRef my As Single, ByRef mz As Single)
        mx = g.GameElementCountX * g.Dr3D_ElementSizeX + (g.GameElementCountX + 1) * g.Dr3D_ElementSpaceX
        my = g.GameElementCountY * g.Dr3D_ElementSizeY + (g.GameElementCountY + 1) * g.Dr3D_ElementSpaceY
        mz = g.Dr3D_ElementSizeZ + 2 * g.Dr3D_ElementSpaceZ + g.Dr3D_BoardZAdding
    End Sub

    Public Function GetMaxSpaceFromGameX(ByVal g As GameCLASS) As Single
        Return g.GameElementCountX * g.Dr3D_ElementSizeX + (g.GameElementCountX + 1) * g.Dr3D_ElementSpaceX
    End Function





    'returns a real value for the x coord. given an integer value (column) and a game
    Public Function GetRealX(ByVal g As GameCLASS, ByVal xA As Integer) As Single
        Return g.Dr3D_ElementSpaceX * xA + g.Dr3D_ElementSizeX * (xA - 1) + g.Dr3D_ElementSizeX / 2
    End Function

    'returns a real value for the y coord. given an integer value (row) and a game
    Public Function GetRealY(ByVal g As GameCLASS, ByVal yA As Integer) As Single
        Return g.Dr3D_ElementSpaceY * yA + g.Dr3D_ElementSizeY * (yA - 1) + g.Dr3D_ElementSizeY / 2
    End Function

    'gets the z real coord for a game in the middle of the board
    Public Function GetRealZ(ByVal g As GameCLASS) As Single
        Return g.Dr3D_ElementSpaceZ + g.Dr3D_ElementSizeZ / 2 + g.Dr3D_BoardZAdding / 2
    End Function



    Public Function GetStaticX(ByVal g As GameCLASS, ByVal xA As Single) As Integer
        Return Ceiling((xA + g.Dr3D_ElementSpaceX / 2) / (g.Dr3D_ElementSizeX + g.Dr3D_ElementSpaceX))
    End Function

    Public Function GetStaticY(ByVal g As GameCLASS, ByVal yA As Single) As Integer
        Return Ceiling((yA + g.Dr3D_ElementSpaceY / 2) / (g.Dr3D_ElementSizeY + g.Dr3D_ElementSpaceY))
    End Function


    'returns whether an element is on grid given a game and two positions: old and new
    Public Function OnGridY(ByVal g As GameCLASS, ByVal oldy As Single, ByVal newy As Single, Optional ByRef m As Single = Nothing) As Boolean
        Dim os, ns As Integer
        os = Funcs.GetStaticY(g, oldy)
        ns = Funcs.GetStaticY(g, newy)

        If os <> ns Then Return False
        m = Funcs.GetRealY(g, os)

        If ((m >= oldy) And (m <= newy)) Or ((m >= newy) And (m <= oldy)) Then Return True
    End Function







    'returns a color selected randomly form all the colors possible in a game
    Public Function GetRandomColor(ByVal g As GameCLASS) As Color
        If g.Colors.Count > 0 Then
            Return g.Colors.Item(Funcs.GetRandom(1, g.Colors.Count))
        Else
            Return Color.FromArgb(0, 0, 0)
        End If
    End Function



    Public Function GetRandom(ByVal lowerbound, ByVal upperbound) As Integer
        Return Int((upperbound - lowerbound + 1) * Rnd() + lowerbound)
    End Function





    'sort elements by y
    Public Function SortElementsY(ByVal c As Collection) As Collection
        Dim s As Collection = New Collection()
        Dim e As ElementCLASS
        Dim my As Single
        Dim i, ind As Integer

        While c.Count > 0
            my = Single.MaxValue
            i = 0

            For Each e In c
                i = i + 1
                If e.y < my Then
                    my = e.y
                    ind = i
                End If
            Next

            s.Add(c.Item(ind))
            c.Remove(ind)
        End While

        Return s
    End Function



    Function GetNumberOfStaticElements(ByVal g As GameCLASS) As Integer
        Dim i, j, n As Integer
        n = 0

        For i = 1 To g.GameElementCountY
            For j = 1 To g.GameElementCountX
                If Not (g.Elem(i, j) Is Nothing) Then n += 1
            Next
        Next

        Return n
    End Function




    Function GetShadow(ByVal g As GameCLASS, ByVal sx As Integer) As Integer
        Dim i As Integer

        For i = 1 To g.GameElementCountY + g.GameElementCountInPiece
            If g.Elem(sx, i) Is Nothing Then Return i
        Next
    End Function




    Function GetNumberOfElementsInLine(ByVal g As GameCLASS, ByVal x As Integer, ByVal y As Integer, ByVal xi As Integer, ByVal yi As Integer) As Integer
        If g.Elem(x, y) Is Nothing Then Return 0

        Dim n, hx, hy As Integer
        Dim c As Color

        n = 0
        hx = x
        hy = y
        c = g.Elem(hx, hy).FrontColor

        While Not (g.Elem(hx, hy) Is Nothing) And (hx > 0) And (hx <= g.GameElementCountX) And (hy > 0) And (hy <= g.GameElementCountY)
            If g.Elem(hx, hy).FrontColor.Equals(c) Then n = n + 1 Else Return n
            hx += xi
            hy += yi
        End While
        Return n
    End Function

End Module
