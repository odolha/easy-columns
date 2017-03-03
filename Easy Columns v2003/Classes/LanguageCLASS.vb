'A class that stores language information and supports loading a 
'language form a file and setting it on a main form mFORM object
Public Class LanguageCLASS
    Public Name As String 'language name - usually the language file
    Public Text(200) As String 'information that will be used in the game
    Public TextCount As Integer 'number of infos in the file


    'Loads a specified language from a file
    Public Sub LoadLanguage(ByVal language As String, Optional ByRef ErrorCode As ErrorCode = Enums.ErrorCode.NoError)
        Try
            FileSystem.FileOpen(1, Consts.LanguagesPath + language + Consts.LanguageFileExtention, OpenMode.Input, OpenAccess.Read)
        Catch
            ErrorCode = Enums.ErrorCode.CouldNotLoadLanguageFile
            Exit Sub
        End Try

        Name = language

        Dim i As Integer
        i = 0
        While Not FileSystem.EOF(1)
            i = i + 1
            Text(i) = FileSystem.LineInput(1)
        End While
        TextCount = i

        FileSystem.FileClose(1)
    End Sub



    'Sets the info that the language contains on the controls within 
    'the specified main form
    Public Sub SetInfoOnConstrols(ByVal f As Easy_Columns.mFORM, a as AboutFORM )
        f.Text = Text(1)
        f.LanguageSettingGB.Text = Text(2)
        f.ExitLanguageSettingB.Text = Text(3)
        f.EnterLanguageSettingB.Text = Text(4)
        f.SettingsGB.Text = Text(5)
        f.PlayerNameL.Text = Text(6)
        f.GameTypeL.Text = Text(7)
        f.GameType1RB.Text = Text(8)
        f.GameType2RB.Text = Text(9)
        f.ColorCountL.Text = Text(10)
        f.ColorsL.Text = Text(11)
        f.ColorsRandomRB.Text = Text(12)
        f.ColorsCustomRB.Text = Text(13)
        '        f.AnimatedCB.Text = Text(14)
        f.PlayB.Text = Text(15)
        f.PlayerL_.Text = Text(16)
        f.ScoreL_.Text = Text(17)
        f.NextL.Text = Text(18)
        f.ClassicColorsB.Text = Text(19)

        f.HighScoresGB.Text = Text(21)
        f.HighScoresL.Text = Text(22)
        f.HighScore_ClassicT.Text = Text(23)
        f.HighScore_RotativeT.Text = Text(24)
        f.HighScore_Classic_NoCH.Text = Text(25)
        f.HighScore_Classic_PlayerNameCH.Text = Text(26)
        f.HighScore_Classic_ScoreCH.Text = Text(27)
        f.HighScore_Rotative_NoCH.Text = Text(29)
        f.HighScore_Rotative_PlayerNameCH.Text = Text(30)
        f.HighScore_Rotative_ScoreCH.Text = Text(31)

        f.Label1.Text = Text(32)
        f.Label2.Text = Text(33)
        f.Label3.Text = Text(34)

        f.PlayAgainB.Text = Text(35)
        f.ExitB.Text = Text(36)

        a.Text = Text(37)
        a.Label1.Text = Text(38)
        a.CloseB.Text = Text(39)

    End Sub

End Class
