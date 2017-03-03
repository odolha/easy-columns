Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System.Windows.Forms
Imports System.Drawing


Public Class mFORM
    Inherits System.Windows.Forms.Form

    'Form design region - you don't want to open this :D
#Region " Design "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LanguageCB As System.Windows.Forms.ComboBox
    Friend WithEvents LanguageSettingGB As System.Windows.Forms.GroupBox
    Friend WithEvents ExitLanguageSettingB As System.Windows.Forms.Button
    Friend WithEvents EnterLanguageSettingB As System.Windows.Forms.Button
    Friend WithEvents SettingsGB As System.Windows.Forms.GroupBox
    Friend WithEvents PlayerNameL As System.Windows.Forms.Label
    Friend WithEvents PlayerNameTB As System.Windows.Forms.TextBox
    Friend WithEvents GameTypeL As System.Windows.Forms.Label
    Friend WithEvents GameType1RB As System.Windows.Forms.RadioButton
    Friend WithEvents GameType2RB As System.Windows.Forms.RadioButton
    Friend WithEvents ColorCountL As System.Windows.Forms.Label
    Friend WithEvents GameTypeP As System.Windows.Forms.Panel
    Friend WithEvents ColorCountP As System.Windows.Forms.Panel
    Friend WithEvents ColorsP As System.Windows.Forms.Panel
    Friend WithEvents ColorsL As System.Windows.Forms.Label
    Friend WithEvents ColorsRandomRB As System.Windows.Forms.RadioButton
    Friend WithEvents ColorsCustomRB As System.Windows.Forms.RadioButton
    Friend WithEvents Color1PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color2PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color3PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color4PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color5PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color6PB As System.Windows.Forms.PictureBox
    Friend WithEvents PlayB As System.Windows.Forms.Button
    Friend WithEvents ColorDIALOG As System.Windows.Forms.ColorDialog
    Friend WithEvents PlayingP As System.Windows.Forms.Panel
    Friend WithEvents NextPB As System.Windows.Forms.PictureBox
    Friend WithEvents NextL As System.Windows.Forms.Label
    Friend WithEvents PlayerL_ As System.Windows.Forms.Label
    Friend WithEvents PlayerL As System.Windows.Forms.Label
    Friend WithEvents ScoreL_ As System.Windows.Forms.Label
    Friend WithEvents ScoreL As System.Windows.Forms.Label
    Friend WithEvents MessageL As System.Windows.Forms.Label
    Friend WithEvents PlayP As System.Windows.Forms.Panel
    Friend WithEvents MessageT As System.Windows.Forms.Timer
    Friend WithEvents MessageTT As System.Windows.Forms.Timer
    Friend WithEvents Time As System.Windows.Forms.Timer
    Friend WithEvents Color7PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color8PB As System.Windows.Forms.PictureBox
    Friend WithEvents Color9PB As System.Windows.Forms.PictureBox
    Friend WithEvents ColorCount As System.Windows.Forms.TrackBar
    Friend WithEvents ClassicColorsB As System.Windows.Forms.Button
    Friend WithEvents HighScoresGB As System.Windows.Forms.GroupBox
    Friend WithEvents HighScoresTC As System.Windows.Forms.TabControl
    Friend WithEvents HighScore_ClassicT As System.Windows.Forms.TabPage
    Friend WithEvents HighScore_RotativeT As System.Windows.Forms.TabPage
    Friend WithEvents HighScore_ClassicLV As System.Windows.Forms.ListView
    Friend WithEvents HighScore_Classic_NoCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_Classic_PlayerNameCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_Classic_ScoreCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_Rotative_NoCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_Rotative_PlayerNameCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_Rotative_ScoreCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HighScore_RotativeLV As System.Windows.Forms.ListView
    Friend WithEvents HighScoresL As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PlayAgainB As System.Windows.Forms.Button
    Friend WithEvents ExitB As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mFORM))
        Me.LanguageSettingGB = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.EnterLanguageSettingB = New System.Windows.Forms.Button
        Me.ExitLanguageSettingB = New System.Windows.Forms.Button
        Me.LanguageCB = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SettingsGB = New System.Windows.Forms.GroupBox
        Me.PlayB = New System.Windows.Forms.Button
        Me.ColorCountP = New System.Windows.Forms.Panel
        Me.ColorCount = New System.Windows.Forms.TrackBar
        Me.ColorCountL = New System.Windows.Forms.Label
        Me.GameTypeP = New System.Windows.Forms.Panel
        Me.GameType1RB = New System.Windows.Forms.RadioButton
        Me.GameType2RB = New System.Windows.Forms.RadioButton
        Me.GameTypeL = New System.Windows.Forms.Label
        Me.PlayerNameTB = New System.Windows.Forms.TextBox
        Me.PlayerNameL = New System.Windows.Forms.Label
        Me.ColorsP = New System.Windows.Forms.Panel
        Me.ClassicColorsB = New System.Windows.Forms.Button
        Me.Color1PB = New System.Windows.Forms.PictureBox
        Me.ColorsRandomRB = New System.Windows.Forms.RadioButton
        Me.ColorsL = New System.Windows.Forms.Label
        Me.ColorsCustomRB = New System.Windows.Forms.RadioButton
        Me.Color2PB = New System.Windows.Forms.PictureBox
        Me.Color3PB = New System.Windows.Forms.PictureBox
        Me.Color4PB = New System.Windows.Forms.PictureBox
        Me.Color5PB = New System.Windows.Forms.PictureBox
        Me.Color6PB = New System.Windows.Forms.PictureBox
        Me.Color7PB = New System.Windows.Forms.PictureBox
        Me.Color8PB = New System.Windows.Forms.PictureBox
        Me.Color9PB = New System.Windows.Forms.PictureBox
        Me.ColorDIALOG = New System.Windows.Forms.ColorDialog
        Me.PlayingP = New System.Windows.Forms.Panel
        Me.PlayP = New System.Windows.Forms.Panel
        Me.PlayerL = New System.Windows.Forms.Label
        Me.PlayerL_ = New System.Windows.Forms.Label
        Me.NextL = New System.Windows.Forms.Label
        Me.NextPB = New System.Windows.Forms.PictureBox
        Me.ScoreL_ = New System.Windows.Forms.Label
        Me.ScoreL = New System.Windows.Forms.Label
        Me.MessageL = New System.Windows.Forms.Label
        Me.MessageT = New System.Windows.Forms.Timer(Me.components)
        Me.MessageTT = New System.Windows.Forms.Timer(Me.components)
        Me.Time = New System.Windows.Forms.Timer(Me.components)
        Me.HighScoresGB = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PlayAgainB = New System.Windows.Forms.Button
        Me.HighScoresTC = New System.Windows.Forms.TabControl
        Me.HighScore_ClassicT = New System.Windows.Forms.TabPage
        Me.HighScore_ClassicLV = New System.Windows.Forms.ListView
        Me.HighScore_Classic_NoCH = New System.Windows.Forms.ColumnHeader
        Me.HighScore_Classic_PlayerNameCH = New System.Windows.Forms.ColumnHeader
        Me.HighScore_Classic_ScoreCH = New System.Windows.Forms.ColumnHeader
        Me.HighScore_RotativeT = New System.Windows.Forms.TabPage
        Me.HighScore_RotativeLV = New System.Windows.Forms.ListView
        Me.HighScore_Rotative_NoCH = New System.Windows.Forms.ColumnHeader
        Me.HighScore_Rotative_PlayerNameCH = New System.Windows.Forms.ColumnHeader
        Me.HighScore_Rotative_ScoreCH = New System.Windows.Forms.ColumnHeader
        Me.HighScoresL = New System.Windows.Forms.Label
        Me.ExitB = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.LanguageSettingGB.SuspendLayout()
        Me.SettingsGB.SuspendLayout()
        Me.ColorCountP.SuspendLayout()
        CType(Me.ColorCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GameTypeP.SuspendLayout()
        Me.ColorsP.SuspendLayout()
        Me.PlayingP.SuspendLayout()
        Me.HighScoresGB.SuspendLayout()
        Me.HighScoresTC.SuspendLayout()
        Me.HighScore_ClassicT.SuspendLayout()
        Me.HighScore_RotativeT.SuspendLayout()
        Me.SuspendLayout()
        '
        'LanguageSettingGB
        '
        Me.LanguageSettingGB.Controls.Add(Me.Label1)
        Me.LanguageSettingGB.Controls.Add(Me.EnterLanguageSettingB)
        Me.LanguageSettingGB.Controls.Add(Me.ExitLanguageSettingB)
        Me.LanguageSettingGB.Controls.Add(Me.LanguageCB)
        Me.LanguageSettingGB.Controls.Add(Me.Label2)
        Me.LanguageSettingGB.Controls.Add(Me.Label3)
        Me.LanguageSettingGB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LanguageSettingGB.Location = New System.Drawing.Point(5, 5)
        Me.LanguageSettingGB.Name = "LanguageSettingGB"
        Me.LanguageSettingGB.Size = New System.Drawing.Size(307, 163)
        Me.LanguageSettingGB.TabIndex = 0
        Me.LanguageSettingGB.TabStop = False
        Me.LanguageSettingGB.Text = "~2"
        Me.LanguageSettingGB.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "~32"
        '
        'EnterLanguageSettingB
        '
        Me.EnterLanguageSettingB.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(245, Byte))
        Me.EnterLanguageSettingB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.EnterLanguageSettingB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnterLanguageSettingB.Location = New System.Drawing.Point(184, 24)
        Me.EnterLanguageSettingB.Name = "EnterLanguageSettingB"
        Me.EnterLanguageSettingB.Size = New System.Drawing.Size(105, 35)
        Me.EnterLanguageSettingB.TabIndex = 2
        Me.EnterLanguageSettingB.Text = "~4"
        '
        'ExitLanguageSettingB
        '
        Me.ExitLanguageSettingB.BackColor = System.Drawing.Color.FromArgb(CType(245, Byte), CType(232, Byte), CType(232, Byte))
        Me.ExitLanguageSettingB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ExitLanguageSettingB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ExitLanguageSettingB.Location = New System.Drawing.Point(8, 120)
        Me.ExitLanguageSettingB.Name = "ExitLanguageSettingB"
        Me.ExitLanguageSettingB.Size = New System.Drawing.Size(105, 35)
        Me.ExitLanguageSettingB.TabIndex = 1
        Me.ExitLanguageSettingB.Text = "~3"
        '
        'LanguageCB
        '
        Me.LanguageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LanguageCB.ItemHeight = 16
        Me.LanguageCB.Location = New System.Drawing.Point(5, 32)
        Me.LanguageCB.Name = "LanguageCB"
        Me.LanguageCB.Size = New System.Drawing.Size(163, 24)
        Me.LanguageCB.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "~33"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "~34"
        '
        'SettingsGB
        '
        Me.SettingsGB.Controls.Add(Me.PlayB)
        Me.SettingsGB.Controls.Add(Me.ColorCountP)
        Me.SettingsGB.Controls.Add(Me.GameTypeP)
        Me.SettingsGB.Controls.Add(Me.PlayerNameTB)
        Me.SettingsGB.Controls.Add(Me.PlayerNameL)
        Me.SettingsGB.Controls.Add(Me.ColorsP)
        Me.SettingsGB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.SettingsGB.Location = New System.Drawing.Point(235, 5)
        Me.SettingsGB.Name = "SettingsGB"
        Me.SettingsGB.Size = New System.Drawing.Size(360, 305)
        Me.SettingsGB.TabIndex = 1
        Me.SettingsGB.TabStop = False
        Me.SettingsGB.Text = "~5"
        Me.SettingsGB.Visible = False
        '
        'PlayB
        '
        Me.PlayB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayB.Location = New System.Drawing.Point(230, 260)
        Me.PlayB.Name = "PlayB"
        Me.PlayB.Size = New System.Drawing.Size(120, 35)
        Me.PlayB.TabIndex = 7
        Me.PlayB.Text = "~15"
        '
        'ColorCountP
        '
        Me.ColorCountP.Controls.Add(Me.ColorCount)
        Me.ColorCountP.Controls.Add(Me.ColorCountL)
        Me.ColorCountP.Location = New System.Drawing.Point(5, 125)
        Me.ColorCountP.Name = "ColorCountP"
        Me.ColorCountP.Size = New System.Drawing.Size(350, 40)
        Me.ColorCountP.TabIndex = 5
        '
        'ColorCount
        '
        Me.ColorCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ColorCount.LargeChange = 1
        Me.ColorCount.Location = New System.Drawing.Point(160, 5)
        Me.ColorCount.Maximum = 9
        Me.ColorCount.Minimum = 1
        Me.ColorCount.Name = "ColorCount"
        Me.ColorCount.Size = New System.Drawing.Size(190, 45)
        Me.ColorCount.TabIndex = 1
        Me.ColorCount.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.ColorCount.Value = 1
        '
        'ColorCountL
        '
        Me.ColorCountL.BackColor = System.Drawing.Color.Transparent
        Me.ColorCountL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ColorCountL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ColorCountL.Location = New System.Drawing.Point(5, 5)
        Me.ColorCountL.Name = "ColorCountL"
        Me.ColorCountL.Size = New System.Drawing.Size(155, 35)
        Me.ColorCountL.TabIndex = 0
        Me.ColorCountL.Text = "~10"
        Me.ColorCountL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GameTypeP
        '
        Me.GameTypeP.Controls.Add(Me.GameType1RB)
        Me.GameTypeP.Controls.Add(Me.GameType2RB)
        Me.GameTypeP.Controls.Add(Me.GameTypeL)
        Me.GameTypeP.Location = New System.Drawing.Point(5, 55)
        Me.GameTypeP.Name = "GameTypeP"
        Me.GameTypeP.Size = New System.Drawing.Size(350, 65)
        Me.GameTypeP.TabIndex = 4
        '
        'GameType1RB
        '
        Me.GameType1RB.BackColor = System.Drawing.Color.Transparent
        Me.GameType1RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GameType1RB.Image = CType(resources.GetObject("GameType1RB.Image"), System.Drawing.Image)
        Me.GameType1RB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.GameType1RB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GameType1RB.Location = New System.Drawing.Point(115, 5)
        Me.GameType1RB.Name = "GameType1RB"
        Me.GameType1RB.Size = New System.Drawing.Size(115, 55)
        Me.GameType1RB.TabIndex = 3
        Me.GameType1RB.Text = "~8"
        '
        'GameType2RB
        '
        Me.GameType2RB.BackColor = System.Drawing.Color.Transparent
        Me.GameType2RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GameType2RB.Image = CType(resources.GetObject("GameType2RB.Image"), System.Drawing.Image)
        Me.GameType2RB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.GameType2RB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GameType2RB.Location = New System.Drawing.Point(230, 5)
        Me.GameType2RB.Name = "GameType2RB"
        Me.GameType2RB.Size = New System.Drawing.Size(115, 55)
        Me.GameType2RB.TabIndex = 3
        Me.GameType2RB.Text = "~9"
        '
        'GameTypeL
        '
        Me.GameTypeL.BackColor = System.Drawing.Color.Transparent
        Me.GameTypeL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GameTypeL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GameTypeL.Location = New System.Drawing.Point(5, 5)
        Me.GameTypeL.Name = "GameTypeL"
        Me.GameTypeL.Size = New System.Drawing.Size(110, 55)
        Me.GameTypeL.TabIndex = 2
        Me.GameTypeL.Text = "~7"
        Me.GameTypeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlayerNameTB
        '
        Me.PlayerNameTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.PlayerNameTB.Location = New System.Drawing.Point(175, 25)
        Me.PlayerNameTB.MaxLength = 50
        Me.PlayerNameTB.Name = "PlayerNameTB"
        Me.PlayerNameTB.Size = New System.Drawing.Size(175, 22)
        Me.PlayerNameTB.TabIndex = 1
        Me.PlayerNameTB.Text = ""
        '
        'PlayerNameL
        '
        Me.PlayerNameL.BackColor = System.Drawing.Color.Transparent
        Me.PlayerNameL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.PlayerNameL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerNameL.Location = New System.Drawing.Point(10, 25)
        Me.PlayerNameL.Name = "PlayerNameL"
        Me.PlayerNameL.Size = New System.Drawing.Size(165, 25)
        Me.PlayerNameL.TabIndex = 0
        Me.PlayerNameL.Text = "~6"
        Me.PlayerNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColorsP
        '
        Me.ColorsP.Controls.Add(Me.ClassicColorsB)
        Me.ColorsP.Controls.Add(Me.Color1PB)
        Me.ColorsP.Controls.Add(Me.ColorsRandomRB)
        Me.ColorsP.Controls.Add(Me.ColorsL)
        Me.ColorsP.Controls.Add(Me.ColorsCustomRB)
        Me.ColorsP.Controls.Add(Me.Color2PB)
        Me.ColorsP.Controls.Add(Me.Color3PB)
        Me.ColorsP.Controls.Add(Me.Color4PB)
        Me.ColorsP.Controls.Add(Me.Color5PB)
        Me.ColorsP.Controls.Add(Me.Color6PB)
        Me.ColorsP.Controls.Add(Me.Color7PB)
        Me.ColorsP.Controls.Add(Me.Color8PB)
        Me.ColorsP.Controls.Add(Me.Color9PB)
        Me.ColorsP.Location = New System.Drawing.Point(5, 170)
        Me.ColorsP.Name = "ColorsP"
        Me.ColorsP.Size = New System.Drawing.Size(350, 80)
        Me.ColorsP.TabIndex = 5
        '
        'ClassicColorsB
        '
        Me.ClassicColorsB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ClassicColorsB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ClassicColorsB.Location = New System.Drawing.Point(135, 50)
        Me.ClassicColorsB.Name = "ClassicColorsB"
        Me.ClassicColorsB.Size = New System.Drawing.Size(130, 25)
        Me.ClassicColorsB.TabIndex = 3
        Me.ClassicColorsB.Text = "~19"
        '
        'Color1PB
        '
        Me.Color1PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color1PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color1PB.Location = New System.Drawing.Point(270, 5)
        Me.Color1PB.Name = "Color1PB"
        Me.Color1PB.Size = New System.Drawing.Size(20, 20)
        Me.Color1PB.TabIndex = 2
        Me.Color1PB.TabStop = False
        '
        'ColorsRandomRB
        '
        Me.ColorsRandomRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ColorsRandomRB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ColorsRandomRB.Location = New System.Drawing.Point(135, 5)
        Me.ColorsRandomRB.Name = "ColorsRandomRB"
        Me.ColorsRandomRB.Size = New System.Drawing.Size(130, 20)
        Me.ColorsRandomRB.TabIndex = 1
        Me.ColorsRandomRB.Text = "~12"
        '
        'ColorsL
        '
        Me.ColorsL.BackColor = System.Drawing.Color.Transparent
        Me.ColorsL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ColorsL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ColorsL.Location = New System.Drawing.Point(5, 5)
        Me.ColorsL.Name = "ColorsL"
        Me.ColorsL.Size = New System.Drawing.Size(130, 70)
        Me.ColorsL.TabIndex = 0
        Me.ColorsL.Text = "~11"
        Me.ColorsL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColorsCustomRB
        '
        Me.ColorsCustomRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ColorsCustomRB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ColorsCustomRB.Location = New System.Drawing.Point(135, 30)
        Me.ColorsCustomRB.Name = "ColorsCustomRB"
        Me.ColorsCustomRB.Size = New System.Drawing.Size(130, 20)
        Me.ColorsCustomRB.TabIndex = 1
        Me.ColorsCustomRB.Text = "~13"
        '
        'Color2PB
        '
        Me.Color2PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color2PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color2PB.Location = New System.Drawing.Point(295, 5)
        Me.Color2PB.Name = "Color2PB"
        Me.Color2PB.Size = New System.Drawing.Size(20, 20)
        Me.Color2PB.TabIndex = 2
        Me.Color2PB.TabStop = False
        '
        'Color3PB
        '
        Me.Color3PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color3PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color3PB.Location = New System.Drawing.Point(320, 5)
        Me.Color3PB.Name = "Color3PB"
        Me.Color3PB.Size = New System.Drawing.Size(20, 20)
        Me.Color3PB.TabIndex = 2
        Me.Color3PB.TabStop = False
        '
        'Color4PB
        '
        Me.Color4PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color4PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color4PB.Location = New System.Drawing.Point(270, 30)
        Me.Color4PB.Name = "Color4PB"
        Me.Color4PB.Size = New System.Drawing.Size(20, 20)
        Me.Color4PB.TabIndex = 2
        Me.Color4PB.TabStop = False
        '
        'Color5PB
        '
        Me.Color5PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color5PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color5PB.Location = New System.Drawing.Point(295, 30)
        Me.Color5PB.Name = "Color5PB"
        Me.Color5PB.Size = New System.Drawing.Size(20, 20)
        Me.Color5PB.TabIndex = 2
        Me.Color5PB.TabStop = False
        '
        'Color6PB
        '
        Me.Color6PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color6PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color6PB.Location = New System.Drawing.Point(320, 30)
        Me.Color6PB.Name = "Color6PB"
        Me.Color6PB.Size = New System.Drawing.Size(20, 20)
        Me.Color6PB.TabIndex = 2
        Me.Color6PB.TabStop = False
        '
        'Color7PB
        '
        Me.Color7PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color7PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color7PB.Location = New System.Drawing.Point(270, 55)
        Me.Color7PB.Name = "Color7PB"
        Me.Color7PB.Size = New System.Drawing.Size(20, 20)
        Me.Color7PB.TabIndex = 2
        Me.Color7PB.TabStop = False
        '
        'Color8PB
        '
        Me.Color8PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color8PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color8PB.Location = New System.Drawing.Point(295, 55)
        Me.Color8PB.Name = "Color8PB"
        Me.Color8PB.Size = New System.Drawing.Size(20, 20)
        Me.Color8PB.TabIndex = 2
        Me.Color8PB.TabStop = False
        '
        'Color9PB
        '
        Me.Color9PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color9PB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Color9PB.Location = New System.Drawing.Point(320, 55)
        Me.Color9PB.Name = "Color9PB"
        Me.Color9PB.Size = New System.Drawing.Size(20, 20)
        Me.Color9PB.TabIndex = 2
        Me.Color9PB.TabStop = False
        '
        'ColorDIALOG
        '
        Me.ColorDIALOG.AnyColor = True
        Me.ColorDIALOG.FullOpen = True
        '
        'PlayingP
        '
        Me.PlayingP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayingP.Controls.Add(Me.PlayP)
        Me.PlayingP.Controls.Add(Me.PlayerL)
        Me.PlayingP.Controls.Add(Me.PlayerL_)
        Me.PlayingP.Controls.Add(Me.NextL)
        Me.PlayingP.Controls.Add(Me.NextPB)
        Me.PlayingP.Controls.Add(Me.ScoreL_)
        Me.PlayingP.Controls.Add(Me.ScoreL)
        Me.PlayingP.Controls.Add(Me.MessageL)
        Me.PlayingP.Location = New System.Drawing.Point(10, 10)
        Me.PlayingP.Name = "PlayingP"
        Me.PlayingP.Size = New System.Drawing.Size(580, 600)
        Me.PlayingP.TabIndex = 3
        Me.PlayingP.Visible = False
        '
        'PlayP
        '
        Me.PlayP.BackColor = System.Drawing.Color.White
        Me.PlayP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PlayP.Location = New System.Drawing.Point(40, 40)
        Me.PlayP.Name = "PlayP"
        Me.PlayP.Size = New System.Drawing.Size(350, 520)
        Me.PlayP.TabIndex = 6
        '
        'PlayerL
        '
        Me.PlayerL.BackColor = System.Drawing.Color.Transparent
        Me.PlayerL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.PlayerL.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.PlayerL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerL.Location = New System.Drawing.Point(160, 10)
        Me.PlayerL.Name = "PlayerL"
        Me.PlayerL.Size = New System.Drawing.Size(230, 20)
        Me.PlayerL.TabIndex = 4
        Me.PlayerL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PlayerL_
        '
        Me.PlayerL_.BackColor = System.Drawing.Color.Transparent
        Me.PlayerL_.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.PlayerL_.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.PlayerL_.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerL_.Location = New System.Drawing.Point(40, 10)
        Me.PlayerL_.Name = "PlayerL_"
        Me.PlayerL_.Size = New System.Drawing.Size(115, 20)
        Me.PlayerL_.TabIndex = 3
        Me.PlayerL_.Text = "~16"
        Me.PlayerL_.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NextL
        '
        Me.NextL.BackColor = System.Drawing.Color.Transparent
        Me.NextL.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.NextL.ForeColor = System.Drawing.Color.Navy
        Me.NextL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NextL.Location = New System.Drawing.Point(395, 335)
        Me.NextL.Name = "NextL"
        Me.NextL.Size = New System.Drawing.Size(180, 35)
        Me.NextL.TabIndex = 2
        Me.NextL.Text = "~18"
        Me.NextL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NextPB
        '
        Me.NextPB.BackColor = System.Drawing.Color.White
        Me.NextPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NextPB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NextPB.Location = New System.Drawing.Point(435, 375)
        Me.NextPB.Name = "NextPB"
        Me.NextPB.Size = New System.Drawing.Size(105, 180)
        Me.NextPB.TabIndex = 1
        Me.NextPB.TabStop = False
        '
        'ScoreL_
        '
        Me.ScoreL_.BackColor = System.Drawing.Color.Transparent
        Me.ScoreL_.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ScoreL_.ForeColor = System.Drawing.Color.Navy
        Me.ScoreL_.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ScoreL_.Location = New System.Drawing.Point(390, 55)
        Me.ScoreL_.Name = "ScoreL_"
        Me.ScoreL_.Size = New System.Drawing.Size(90, 20)
        Me.ScoreL_.TabIndex = 3
        Me.ScoreL_.Text = "~17"
        Me.ScoreL_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScoreL
        '
        Me.ScoreL.BackColor = System.Drawing.Color.Transparent
        Me.ScoreL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ScoreL.ForeColor = System.Drawing.Color.Red
        Me.ScoreL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ScoreL.Location = New System.Drawing.Point(480, 55)
        Me.ScoreL.Name = "ScoreL"
        Me.ScoreL.Size = New System.Drawing.Size(100, 20)
        Me.ScoreL.TabIndex = 4
        Me.ScoreL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MessageL
        '
        Me.MessageL.BackColor = System.Drawing.Color.Transparent
        Me.MessageL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MessageL.ForeColor = System.Drawing.Color.IndianRed
        Me.MessageL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MessageL.Location = New System.Drawing.Point(395, 95)
        Me.MessageL.Name = "MessageL"
        Me.MessageL.Size = New System.Drawing.Size(180, 140)
        Me.MessageL.TabIndex = 5
        Me.MessageL.Text = "~50->"
        Me.MessageL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MessageT
        '
        '
        'MessageTT
        '
        '
        'Time
        '
        Me.Time.Interval = 10
        '
        'HighScoresGB
        '
        Me.HighScoresGB.Controls.Add(Me.PictureBox1)
        Me.HighScoresGB.Controls.Add(Me.PlayAgainB)
        Me.HighScoresGB.Controls.Add(Me.HighScoresTC)
        Me.HighScoresGB.Controls.Add(Me.HighScoresL)
        Me.HighScoresGB.Controls.Add(Me.ExitB)
        Me.HighScoresGB.Controls.Add(Me.Label4)
        Me.HighScoresGB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.HighScoresGB.Location = New System.Drawing.Point(5, 35)
        Me.HighScoresGB.Name = "HighScoresGB"
        Me.HighScoresGB.Size = New System.Drawing.Size(380, 485)
        Me.HighScoresGB.TabIndex = 4
        Me.HighScoresGB.TabStop = False
        Me.HighScoresGB.Text = "~21"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(296, 400)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PlayAgainB
        '
        Me.PlayAgainB.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(245, Byte))
        Me.PlayAgainB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PlayAgainB.Location = New System.Drawing.Point(16, 400)
        Me.PlayAgainB.Name = "PlayAgainB"
        Me.PlayAgainB.Size = New System.Drawing.Size(120, 32)
        Me.PlayAgainB.TabIndex = 2
        Me.PlayAgainB.Text = "~35"
        '
        'HighScoresTC
        '
        Me.HighScoresTC.Controls.Add(Me.HighScore_ClassicT)
        Me.HighScoresTC.Controls.Add(Me.HighScore_RotativeT)
        Me.HighScoresTC.ItemSize = New System.Drawing.Size(54, 21)
        Me.HighScoresTC.Location = New System.Drawing.Point(3, 56)
        Me.HighScoresTC.Name = "HighScoresTC"
        Me.HighScoresTC.SelectedIndex = 0
        Me.HighScoresTC.Size = New System.Drawing.Size(374, 336)
        Me.HighScoresTC.TabIndex = 1
        '
        'HighScore_ClassicT
        '
        Me.HighScore_ClassicT.Controls.Add(Me.HighScore_ClassicLV)
        Me.HighScore_ClassicT.Location = New System.Drawing.Point(4, 25)
        Me.HighScore_ClassicT.Name = "HighScore_ClassicT"
        Me.HighScore_ClassicT.Size = New System.Drawing.Size(366, 307)
        Me.HighScore_ClassicT.TabIndex = 0
        Me.HighScore_ClassicT.Text = "~23"
        '
        'HighScore_ClassicLV
        '
        Me.HighScore_ClassicLV.AllowColumnReorder = True
        Me.HighScore_ClassicLV.BackColor = System.Drawing.Color.GhostWhite
        Me.HighScore_ClassicLV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.HighScore_Classic_NoCH, Me.HighScore_Classic_PlayerNameCH, Me.HighScore_Classic_ScoreCH})
        Me.HighScore_ClassicLV.Enabled = False
        Me.HighScore_ClassicLV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HighScore_ClassicLV.FullRowSelect = True
        Me.HighScore_ClassicLV.GridLines = True
        Me.HighScore_ClassicLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.HighScore_ClassicLV.Location = New System.Drawing.Point(5, 5)
        Me.HighScore_ClassicLV.MultiSelect = False
        Me.HighScore_ClassicLV.Name = "HighScore_ClassicLV"
        Me.HighScore_ClassicLV.Size = New System.Drawing.Size(355, 335)
        Me.HighScore_ClassicLV.TabIndex = 0
        Me.HighScore_ClassicLV.View = System.Windows.Forms.View.Details
        '
        'HighScore_Classic_NoCH
        '
        Me.HighScore_Classic_NoCH.Text = "~25"
        Me.HighScore_Classic_NoCH.Width = 50
        '
        'HighScore_Classic_PlayerNameCH
        '
        Me.HighScore_Classic_PlayerNameCH.Text = "~26"
        Me.HighScore_Classic_PlayerNameCH.Width = 200
        '
        'HighScore_Classic_ScoreCH
        '
        Me.HighScore_Classic_ScoreCH.Text = "~27"
        Me.HighScore_Classic_ScoreCH.Width = 100
        '
        'HighScore_RotativeT
        '
        Me.HighScore_RotativeT.Controls.Add(Me.HighScore_RotativeLV)
        Me.HighScore_RotativeT.Location = New System.Drawing.Point(4, 25)
        Me.HighScore_RotativeT.Name = "HighScore_RotativeT"
        Me.HighScore_RotativeT.Size = New System.Drawing.Size(366, 307)
        Me.HighScore_RotativeT.TabIndex = 1
        Me.HighScore_RotativeT.Text = "~24"
        '
        'HighScore_RotativeLV
        '
        Me.HighScore_RotativeLV.BackColor = System.Drawing.Color.GhostWhite
        Me.HighScore_RotativeLV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.HighScore_Rotative_NoCH, Me.HighScore_Rotative_PlayerNameCH, Me.HighScore_Rotative_ScoreCH})
        Me.HighScore_RotativeLV.Enabled = False
        Me.HighScore_RotativeLV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HighScore_RotativeLV.FullRowSelect = True
        Me.HighScore_RotativeLV.GridLines = True
        Me.HighScore_RotativeLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.HighScore_RotativeLV.Location = New System.Drawing.Point(5, 5)
        Me.HighScore_RotativeLV.Name = "HighScore_RotativeLV"
        Me.HighScore_RotativeLV.Size = New System.Drawing.Size(355, 335)
        Me.HighScore_RotativeLV.TabIndex = 2
        Me.HighScore_RotativeLV.View = System.Windows.Forms.View.Details
        '
        'HighScore_Rotative_NoCH
        '
        Me.HighScore_Rotative_NoCH.Text = "~29"
        Me.HighScore_Rotative_NoCH.Width = 50
        '
        'HighScore_Rotative_PlayerNameCH
        '
        Me.HighScore_Rotative_PlayerNameCH.Text = "~30"
        Me.HighScore_Rotative_PlayerNameCH.Width = 200
        '
        'HighScore_Rotative_ScoreCH
        '
        Me.HighScore_Rotative_ScoreCH.Text = "~31"
        Me.HighScore_Rotative_ScoreCH.Width = 100
        '
        'HighScoresL
        '
        Me.HighScoresL.BackColor = System.Drawing.Color.Transparent
        Me.HighScoresL.Dock = System.Windows.Forms.DockStyle.Top
        Me.HighScoresL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.HighScoresL.ForeColor = System.Drawing.Color.BlueViolet
        Me.HighScoresL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HighScoresL.Location = New System.Drawing.Point(3, 18)
        Me.HighScoresL.Name = "HighScoresL"
        Me.HighScoresL.Size = New System.Drawing.Size(374, 40)
        Me.HighScoresL.TabIndex = 0
        Me.HighScoresL.Text = "~22"
        Me.HighScoresL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ExitB
        '
        Me.ExitB.BackColor = System.Drawing.Color.FromArgb(CType(245, Byte), CType(232, Byte), CType(232, Byte))
        Me.ExitB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ExitB.Location = New System.Drawing.Point(16, 440)
        Me.ExitB.Name = "ExitB"
        Me.ExitB.Size = New System.Drawing.Size(120, 32)
        Me.ExitB.TabIndex = 2
        Me.ExitB.Text = "~36"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(256, 432)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Click"
        '
        'mFORM
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(230, Byte))
        Me.ClientSize = New System.Drawing.Size(599, 618)
        Me.Controls.Add(Me.LanguageSettingGB)
        Me.Controls.Add(Me.HighScoresGB)
        Me.Controls.Add(Me.SettingsGB)
        Me.Controls.Add(Me.PlayingP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "mFORM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "~1"
        Me.LanguageSettingGB.ResumeLayout(False)
        Me.SettingsGB.ResumeLayout(False)
        Me.ColorCountP.ResumeLayout(False)
        CType(Me.ColorCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GameTypeP.ResumeLayout(False)
        Me.ColorsP.ResumeLayout(False)
        Me.PlayingP.ResumeLayout(False)
        Me.HighScoresGB.ResumeLayout(False)
        Me.HighScoresTC.ResumeLayout(False)
        Me.HighScore_ClassicT.ResumeLayout(False)
        Me.HighScore_RotativeT.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region







    'Global variables declaration
#Region " Global "

    'temporary used variables 'Prefix "_"
    Public _flH, _flS As Integer

    Public _NoOfColors As Short
    'game features and interactive data. these are moved in a game component
    Public _GameType As Enums.GameType 'the type of the game to be played
    Public _AnimatedRotations As Boolean 'whether animated rotation is enabled in a "Modern" game




    Public Language As LanguageCLASS 'The language used with the application

    Public PlayerName As String 'the name of the current player

    Public Mode As Enums.ApplicationMode = Enums.ApplicationMode.OnLanguageSetting 'Current application/game mode

    Public Shared Game As GameCLASS


    Public af As AboutFORM


#End Region







    'General subs (i.e. Loaders, Savers, Functions, Overall inits)
#Region " General "

    'Initialize vital elements for the application to run first time
    Public Sub FirstInitialization()
        'language inits
        Language = New LanguageCLASS()
        Language.LoadLanguage(Consts.DefaultLanguage)
        Language.SetInfoOnConstrols(Me, af)
    End Sub



    'Set the format of the layout for a current game mode
    Public Sub SetDisplayForm(ByVal CurrentMode As Enums.ApplicationMode)
        Select Case CurrentMode
            Case Enums.ApplicationMode.OnLanguageSetting
                'setting what needs to be visible
                Me.ClientSize = New Drawing.Size(Me.LanguageSettingGB.Size.Width + 6, Me.LanguageSettingGB.Size.Height + 6)
                Me.LanguageSettingGB.Left = 3
                Me.LanguageSettingGB.Top = 3
                Me.LanguageSettingGB.Show()

                'setting what need to be invisible
                Me.SettingsGB.Hide()
                Me.PlayingP.Hide()
                Me.HighScoresGB.Hide()


            Case Enums.ApplicationMode.OnSettings
                'setting what needs to be visible
                Me.ClientSize = New Size(Me.SettingsGB.Size.Width + 6, Me.SettingsGB.Size.Height + 6)
                Me.SettingsGB.Left = 3
                Me.SettingsGB.Top = 3
                Me.SettingsGB.Show()
                'setting what need to be invisible
                Me.LanguageSettingGB.Hide()
                Me.PlayingP.Hide()
                Me.HighScoresGB.Hide()


            Case Enums.ApplicationMode.OnPlaying
                'setting what needs to be visible
                Me.PlayingP.Show()
                Me.PlayingP.Width = Consts.PlayViewWidth
                Me.PlayingP.Height = Consts.PlayViewHeight
                Me.ClientSize = New Size(Me.PlayingP.Width + Consts.PlayViewVerticalMargin * 2, Me.PlayingP.Height + Consts.PlayViewHorizontalMargin * 2)
                Me.PlayingP.Left = Consts.PlayViewVerticalMargin
                Me.PlayingP.Top = Consts.PlayViewHorizontalMargin
                'If Not (Consts.PlayViewImage Is Nothing) Then Me.PlayingP.BackgroundImage = Bitmap.FromFile(Consts.PlayViewImage)
                Me.PlayingP.Cursor = New Cursor(Consts.CursorPath_No)
                'setting what need to be invisible
                Me.LanguageSettingGB.Hide()
                Me.SettingsGB.Hide()
                Me.HighScoresGB.Hide()


            Case Enums.ApplicationMode.OnHighScore
                Me.ClientSize = New Drawing.Size(Me.HighScoresGB.Size.Width + 4, Me.HighScoresGB.Size.Height + 4)
                Me.HighScoresGB.Left = 2
                Me.HighScoresGB.Top = 2
                Me.HighScoresGB.Show()

                'setting what need to be invisible
                Me.PlayingP.Hide()
                Me.SettingsGB.Hide()
                Me.PlayingP.Hide()

        End Select

        'center and focus
        Me.CenterToScreen()
        Me.Focus()
    End Sub

#End Region









    ' -------------------------- PLAYING --------------------------
    ' Contains the part of the program that runs when the application
    ' mode is OnPlaying
#Region " PLAYING REGION "

    'When the game is on. it manages the gaming environment
    Public Sub PlayingRunTime()
        SetDisplayForm(Enums.ApplicationMode.OnPlaying)
        'first time set a message for the player, telling him to press enter to start the game
        SetMessage(PlayerName + ", " + Language.Text(51), Color.Red, 1000, 500, 16, FontStyle.Bold)


        While Mode = Enums.ApplicationMode.OnPlaying
            'here it all happens :)
            ResetOuterAspect()

            Game.Process()

            If Game.Over Then
                Mode = Enums.ApplicationMode.OnHighScore
                SetMessage(Language.Text(53), Color.RosyBrown, 18, FontStyle.Bold, 800)
                Time.Stop()
                Me.PlayingP.Cursor = Cursors.Arrow
            End If

            Application.DoEvents()
        End While
    End Sub




    'input from the keyboard
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If (e.KeyCode = Keys.Enter) And Not (Game.Over) Then
                If Game.Paused Then
                    SetMessage()
                    Game.Start()
                Else
                    SetMessage(Language.Text(52), Color.Orange, 500, 300)
                    Game.Pause()
                End If
            End If

            If e.KeyCode = Keys.Tab And Not Game.Over Then
                Game.RendNext = Not Game.RendNext
                NextL.Visible = Game.RendNext
                NextPB.Visible = Game.RendNext
            End If


            'piece movement only if the game permits it
            If Game.AllowInput Then
                If e.KeyCode = Keys.Left Then
                    Game.MovePiece(Enums.PieceMovement.MoveLeft)
                End If
                If e.KeyCode = Keys.Right Then
                    Game.MovePiece(Enums.PieceMovement.MoveRight)
                End If
                If Game.AllowAccelerate And (e.KeyCode = Keys.Down) Then
                    Game.MovePiece(Enums.PieceMovement.Accelerate)
                End If
                If e.KeyCode = Keys.Up Then
                    Game.MovePiece(Enums.PieceMovement.Change)
                End If
            End If
        Catch
        End Try
    End Sub



    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        'nothing now
    End Sub



    'resets the exterior aspect, set the name of the player, score, etc
    Public Sub ResetOuterAspect()
        PlayerL.Text = PlayerName
        ScoreL.Text = Game.Score
    End Sub




    'time all physics must be calculated here
    Private Sub Time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time.Tick
        Game.Compute()
        If Game.Over Then
            Mode = Enums.ApplicationMode.OnHighScore
            SetMessage(Language.Text(53), Color.RosyBrown, 18, FontStyle.Bold, 800)
            Time.Stop()
            Me.PlayingP.Cursor = Cursors.Arrow
        End If
    End Sub

    'Procedures and functions usefull in the play section

    'to set messages on the window
#Region " Message Handling "
    Public Sub SetMessage(ByVal mes As String, ByVal textcolor As Color, Optional ByVal textsize As Integer = 14, Optional ByVal textstyle As FontStyle = FontStyle.Bold, Optional ByVal flick As Integer = 1000, Optional ByVal time As Integer = -1)
        MessageL.Text = mes
        MessageL.ForeColor = textcolor
        MessageL.Font = New System.Drawing.Font("times new roman", textsize, textstyle, GraphicsUnit.Pixel, 0)
        If flick <> 0 Then
            MessageT.Interval = flick
            MessageT.Start()
        End If
        _flS = -1
        If time >= 0 Then
            MessageTT.Interval = time
            MessageTT.Start()
        End If
        MessageL.Visible = True
    End Sub

    Public Sub setmessage(ByVal mes As String, ByVal textcolor As Color, ByVal flickSHOW As Integer, ByVal flickHIDE As Integer, Optional ByVal textsize As Integer = 14, Optional ByVal textstyle As FontStyle = FontStyle.Bold, Optional ByVal time As Integer = -1)
        SetMessage(mes, textcolor, textsize, textstyle, , time)
        MessageT.Interval = flickSHOW
        _flS = flickSHOW
        _flH = flickHIDE
        MessageT.Start()
        MessageL.Visible = True
    End Sub




    Public Sub SetMessage()
        MessageT.Stop()
        MessageTT.Stop()
        MessageL.Visible = False
    End Sub

    'timer for message to flick
    Private Sub MessageT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageT.Tick
        MessageL.Visible = Not (MessageL.Visible)
        If _flS <> -1 Then
            If MessageT.Interval = _flS Then
                MessageT.Interval = _flH
            Else
                If MessageT.Interval = _flH Then MessageT.Interval = _flS
            End If
        End If
    End Sub

    'timer for message to dissapear
    Private Sub MessageTT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageTT.Tick
        MessageT.Stop()
        MessageL.Visible = False
        MessageTT.Stop()
    End Sub
#End Region


#End Region
    ' ////////////////////////// PLAYING //////////////////////////











    ' -------------------------- SETTINGS --------------------------
    ' Contains the part of the program that runs when the application
    ' mode is OnSettings
#Region " SETTINGS REGION "

    'The entry point and the local loop
    Public Sub SettingsRunTime(Optional ByVal EnterMode As Enums.SubEnterMode = Enums.SubEnterMode.None)
        SetDisplayForm(Enums.ApplicationMode.OnSettings)

        While Mode = Enums.ApplicationMode.OnSettings
            Application.DoEvents()
        End While
    End Sub



    'Initializations at beginning, when the groupbox is showed
    Private Sub SettingsGB_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SettingsGB.VisibleChanged
        If SettingsGB.Visible Then
            'load the name from the environment (the user)
            PlayerNameTB.Text = Environment.UserName
            'set the default game type
            GameType1RB.Select()
            'set the default number of colors
            ColorCount.Value = 6
            'set the default color generation mode
            ColorsCustomRB.Select()
            'set the initial colors for the PB's
            Color1PB.BackColor = Color.Blue
            Color2PB.BackColor = Color.Red
            Color3PB.BackColor = Color.Lime
            Color4PB.BackColor = Color.Yellow
            Color5PB.BackColor = Color.Black
            Color6PB.BackColor = Color.LightGray
            Color7PB.BackColor = Color.Aquamarine
            Color8PB.BackColor = Color.Orange
            Color9PB.BackColor = Color.Magenta
        End If
    End Sub




    'When changing player's name
    Private Sub PlayerNameTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerNameTB.TextChanged
        PlayerName = PlayerNameTB.Text
    End Sub




    'When changing the type of game to be played
    Private Sub GameType1RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameType1RB.CheckedChanged
        If GameType1RB.Checked Then _GameType = Enums.GameType.Classic
        '        AnimatedCB.Visible = False
        If GameType1RB.Checked Then ClassicColorsB.PerformClick()
    End Sub
    Private Sub GameType2RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameType2RB.CheckedChanged
        If GameType2RB.Checked Then _GameType = Enums.GameType.Rotative
        '        AnimatedCB.Visible = True
    End Sub





    'Just events for changing colors in the settings panel
#Region " Color dealing "

    'This sub is called to change the aspect of the PB that show the
    'colors when a different nomber of colors is chosen
    Public Sub ResetColorsPB()
        Color1PB.Visible = False
        Color2PB.Visible = False
        Color3PB.Visible = False
        Color4PB.Visible = False
        Color5PB.Visible = False
        Color6PB.Visible = False
        Color7PB.Visible = False
        Color8PB.Visible = False
        Color9PB.Visible = False
        If ColorsCustomRB.Checked Then
            If _NoOfColors > 0 Then Color1PB.Visible = True
            If _NoOfColors > 1 Then Color2PB.Visible = True
            If _NoOfColors > 2 Then Color3PB.Visible = True
            If _NoOfColors > 3 Then Color4PB.Visible = True
            If _NoOfColors > 4 Then Color5PB.Visible = True
            If _NoOfColors > 5 Then Color6PB.Visible = True
            If _NoOfColors > 6 Then Color7PB.Visible = True
            If _NoOfColors > 7 Then Color8PB.Visible = True
            If _NoOfColors > 8 Then Color9PB.Visible = True
        End If
    End Sub



    'When changing the number of colors to play with
    Private Sub ColorCount_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorCount.ValueChanged
        _NoOfColors = ColorCount.Value
        If ColorsCustomRB.Checked Then ResetColorsPB()
    End Sub



    'When changing the color generation method
    Private Sub ColorsRandomRB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorsRandomRB.CheckedChanged
        If ColorsRandomRB.Checked Then
            ResetColorsPB()
        End If
    End Sub
    Private Sub ColorsCustomRB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorsCustomRB.CheckedChanged
        If ColorsCustomRB.Checked Then
            ResetColorsPB()
        End If
    End Sub


    'When picking the colors
    Private Sub Color1PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color1PB.Click
        ColorDIALOG.Color = Color1PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color1PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color2PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color2PB.Click
        ColorDIALOG.Color = Color2PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color2PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color3PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color3PB.Click
        ColorDIALOG.Color = Color3PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color3PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color4PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color4PB.Click
        ColorDIALOG.Color = Color4PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color4PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color5PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color5PB.Click
        ColorDIALOG.Color = Color5PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color5PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color6PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color6PB.Click
        ColorDIALOG.Color = Color6PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color6PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color7PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color7PB.Click
        ColorDIALOG.Color = Color7PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color7PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color8PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color8PB.Click
        ColorDIALOG.Color = Color8PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color8PB.BackColor = ColorDIALOG.Color
    End Sub
    Private Sub Color9PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color9PB.Click
        ColorDIALOG.Color = Color9PB.BackColor
        Dim res As DialogResult
        res = ColorDIALOG.ShowDialog()
        If res.OK Then Color9PB.BackColor = ColorDIALOG.Color
    End Sub



    Private Sub ClassicColorsB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassicColorsB.Click
        Color1PB.BackColor = Color.Blue
        Color2PB.BackColor = Color.Red
        Color3PB.BackColor = Color.Lime
        Color4PB.BackColor = Color.Yellow
        Color5PB.BackColor = Color.Black
        Color6PB.BackColor = Color.LightGray

        ColorCount.Value = 6

        ColorsCustomRB.Select()
    End Sub
#End Region



    'When changing the animated on rotation mode
    '    Private Sub AnimatedCB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        _AnimatedRotations = AnimatedCB.Checked
    '    End Sub



    'Change to playomode button; the colors are processed here and
    'placed in variables
    Private Sub PlayB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayB.Click
        'create a new game
        Game = New GameCLASS(Me, _GameType, _AnimatedRotations)

        'add the colors
        If ColorsCustomRB.Checked Then
            If Color1PB.Visible Then Game.AddColorInTheGame(Color1PB.BackColor)
            If Color2PB.Visible Then Game.AddColorInTheGame(Color2PB.BackColor)
            If Color3PB.Visible Then Game.AddColorInTheGame(Color3PB.BackColor)
            If Color4PB.Visible Then Game.AddColorInTheGame(Color4PB.BackColor)
            If Color5PB.Visible Then Game.AddColorInTheGame(Color5PB.BackColor)
            If Color6PB.Visible Then Game.AddColorInTheGame(Color6PB.BackColor)
            If Color7PB.Visible Then Game.AddColorInTheGame(Color7PB.BackColor)
            If Color8PB.Visible Then Game.AddColorInTheGame(Color8PB.BackColor)
            If Color9PB.Visible Then Game.AddColorInTheGame(Color9PB.BackColor)
        End If
        If ColorsRandomRB.Checked Then
            Dim i As Integer
            Dim ok As Boolean
            Dim ct, cr As Color
            Dim c As Collection 'of color
            c = New Collection()

            While c.Count < _NoOfColors
                cr = Color.FromArgb(Rnd() * 255, Rnd() * 255, Rnd() * 255)
                ok = True
                For Each ct In c
                    If Funcs.GetColorDifference(ct, cr) < (255 * 3 \ _NoOfColors) - Consts.NearColorSelectionFactor Then ok = False
                Next
                If ok Then c.Add(cr)
            End While

            Game.AddColorInTheGame(c)
        End If

        'now change the mode
        Mode = Enums.ApplicationMode.OnPlaying
    End Sub

#End Region
    ' /////////////////////////// SETTINGS //////////////////////////









    ' --------------------- LANGUAGE SETTING ---------------------
    ' Contains the part of the program that runs when the application
    ' mode is OnLanguageSetting (the player is choosing language)
#Region " LANGUAGE SETTING REGION "

    'The entry point and the runtime procedure
    Public Sub LanguageSettingRunTime(Optional ByVal EnterMode As Enums.SubEnterMode = Enums.SubEnterMode.None)
        SetDisplayForm(Enums.ApplicationMode.OnLanguageSetting)

        While Mode = Enums.ApplicationMode.OnLanguageSetting
            Application.DoEvents()
        End While
    End Sub


    'The Group Box is visible event: here the application initializes 
    'data needed in this section of the game
    Private Sub LanguageSettingsGB_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LanguageSettingGB.VisibleChanged
        If LanguageSettingGB.Visible Then
            'get all the languages files and put them in the combobox
            LanguageCB.Items.Clear()
            Dim c As Collection 'of types.file
            c = Funcs.GetFileList(Consts.LanguagesPath, Consts.LanguageFileExtention)
            Dim element As Types.File
            For Each element In c
                LanguageCB.Items.Add(element.name)
            Next
            'also set the defaultlanguage as the value for the combo
            LanguageCB.SelectedItem = Consts.DefaultLanguage
        End If
    End Sub


    'When changing the language
    Private Sub LanguageCB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LanguageCB.SelectedIndexChanged
        Language.LoadLanguage(LanguageCB.SelectedItem)
        Language.SetInfoOnConstrols(Me, af)
    End Sub


    'Exit button
    Private Sub ExitLanguageSettingB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitLanguageSettingB.Click
        Application.Exit()
    End Sub


    'Change to settings button
    Private Sub EnterLanguageSettingB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterLanguageSettingB.Click
        Mode = Enums.ApplicationMode.OnSettings
    End Sub

#End Region
    ' /////////////////////// LANGUAGE SETTING /////////////////////







#Region " HIGH SCORES REGION "

    Public Sub HighScoresRunTime()
        SetDisplayForm(Enums.ApplicationMode.OnHighScore)

        Me.HighScore_ClassicLV.Items.Clear()
        Me.HighScore_RotativeLV.Items.Clear()

        LoadHighScores()
        SaveHighScores()

        While Mode = Enums.ApplicationMode.OnHighScore

            Application.DoEvents()
        End While
    End Sub




    Public Class player
        Public name As String
        Public score As Integer

        Public Sub New(ByVal nameP As String, ByVal scoreP As Integer)
            name = nameP
            score = scoreP
        End Sub
    End Class




    Public Sub SaveHighScores()
        Dim i As Integer


        'classic
        FileSystem.FileOpen(1, "Classic6.hst", OpenMode.Output)

        FileSystem.PrintLine(1, Math.Min(HighScore_ClassicLV.Items.Count, Consts.MaxHighScores))

        For i = 1 To HighScore_ClassicLV.Items.Count
            If i > Consts.MaxHighScores Then
                GoTo 200
            End If

            FileSystem.PrintLine(1, HighScore_ClassicLV.Items(i - 1).SubItems(1).Text)
            FileSystem.PrintLine(1, HighScore_ClassicLV.Items(i - 1).SubItems(2).Text)
        Next
200:

        FileSystem.FileClose(1)


        'rotative
        FileSystem.FileOpen(1, "Rotative6.hst", OpenMode.Output)

        FileSystem.PrintLine(1, Math.Min(HighScore_RotativeLV.Items.Count, Consts.MaxHighScores))

        For i = 1 To HighScore_RotativeLV.Items.Count
            If i > Consts.MaxHighScores Then
                GoTo 201
            End If

            FileSystem.PrintLine(1, HighScore_RotativeLV.Items(i - 1).SubItems(1).Text)
            FileSystem.PrintLine(1, HighScore_RotativeLV.Items(i - 1).SubItems(2).Text)
        Next
201:

        FileSystem.FileClose(1)
    End Sub





    Public Sub LoadHighScores()
        Dim n, i, pi As Integer
        Dim c As Collection
        Dim name As String
        Dim score As Integer
        Dim p As player
        Dim o As Boolean


        'for classic
        FileSystem.FileOpen(1, "Classic6.hst", OpenMode.Input)

        n = FileSystem.LineInput(1)

        c = New Collection


        If (Game.Type = Enums.GameType.Classic) And (Game.Colors.Count = 6) Then
            o = False
            HighScoresTC.SelectedTab = HighScore_ClassicT
        Else
            o = True
        End If

        For i = 1 To n
            name = FileSystem.LineInput(1)
            score = FileSystem.LineInput(1)

            If (Game.Score > score) And Not o Then
                c.Add(New player(PlayerName, Game.Score))
                pi = i
                o = True
            End If

            c.Add(New player(name, score))
        Next

        If Not o Then
            c.Add(New player(PlayerName, Game.Score))
            pi = i
        End If


        FileSystem.FileClose(1)


        i = -1
        For Each p In c
            i = i + 1
            HighScore_ClassicLV.Items.Add(New ListViewItem(i + 1))
            If (i = pi - 1) And (_GameType = Enums.GameType.Classic) Then
                HighScore_ClassicLV.Items(i).Selected = True
                HighScore_ClassicLV.Items(i).ForeColor = Color.Red
                HighScore_ClassicLV.Items(i).BackColor = Color.Azure
            End If

            Dim it As ListViewItem
            For Each it In HighScore_ClassicLV.Items
                it.SubItems.Add(p.name)
                it.SubItems.Add(p.score)
            Next
        Next





        'for rotative
        FileSystem.FileOpen(1, "Rotative6.hst", OpenMode.Input)

        n = FileSystem.LineInput(1)

        c = New Collection


        If (Game.Type = Enums.GameType.Rotative) And (Game.Colors.Count = 6) Then
            o = False
            HighScoresTC.SelectedTab = HighScore_RotativeT
        Else
            o = True
        End If

        For i = 1 To n
            name = FileSystem.LineInput(1)
            score = FileSystem.LineInput(1)

            If (Game.Score > score) And Not o Then
                c.Add(New player(PlayerName, Game.Score))
                pi = i
                o = True
            End If

            c.Add(New player(name, score))
        Next

        If Not o Then
            c.Add(New player(PlayerName, Game.Score))
            pi = i
        End If


        FileSystem.FileClose(1)


        i = -1
        For Each p In c
            i = i + 1
            HighScore_RotativeLV.Items.Add(New ListViewItem(i + 1))
            If (i = pi - 1) And (_GameType = Enums.GameType.Rotative) Then
                HighScore_RotativeLV.Items(i).Selected = True
                HighScore_RotativeLV.Items(i).ForeColor = Color.Red
                HighScore_RotativeLV.Items(i).BackColor = Color.Azure
            End If

            Dim it As ListViewItem
            For Each it In HighScore_RotativeLV.Items
                it.SubItems.Add(p.name)
                it.SubItems.Add(p.score)
            Next
        Next

    End Sub






    Private Sub PlayAgainB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayAgainB.Click
        Me.Mode = Enums.ApplicationMode.OnSettings
    End Sub


    Private Sub ExitB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitB.Click
        Me.Mode = Enums.ApplicationMode.Finalized
    End Sub

#End Region








    'The main entry point for the application
    'Also manages the lobby by opening doors when Mode is changing
    Shared Sub Main()
        Randomize() 'can't do without

        Dim mf As New mFORM()

        mf.af = New AboutFORM

        mf.FirstInitialization()
        mf.Show()



        'Main loop
        While mf.Created
            Application.DoEvents()

            Select Case mf.Mode
                Case Enums.ApplicationMode.OnLanguageSetting
                    mf.LanguageSettingRunTime()
                Case Enums.ApplicationMode.OnSettings
                    mf.SettingsRunTime()
                Case Enums.ApplicationMode.OnPlaying
                    mf.PlayingRunTime()
                Case Enums.ApplicationMode.OnHighScore
                    mf.HighScoresRunTime()

                Case Enums.ApplicationMode.Finalized
                    Application.Exit()
            End Select
        End While
    End Sub




    'When the window is closed the mode is set to finalized so that it 
    'exits from any loop within the program; other feature could be
    'inserted here, like asking before exiting
    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        Mode = Enums.ApplicationMode.Finalized
    End Sub





    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.af.Show()
    End Sub
End Class