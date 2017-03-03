'Enumerations useful in the program
Public Module Enums

    Public Enum ApplicationMode
        Fatality = -1
        Finalized = 0
        OnLanguageSetting = 1
        OnSettings = 2
        OnPlaying = 3
        OnHighScore = 4
    End Enum

    Enum SubEnterMode
        None = 0
        FirstTime = 1
    End Enum

    Enum ErrorCode
        NoError = 0
        CouldNotLoadLanguageFile = 1
        CouldNotMovePiece = 2
    End Enum

    Enum GameType
        Classic = 1
        Rotative = 2
    End Enum


    Enum LightingMode
        None = 0
        FrontLeftRightTop = 1
        All = 9
    End Enum

    Enum ModelType
        NoModelAllocation = 0
        Cubic = 1
        Simple = 2
    End Enum

    Enum CubicFaceTransitionMode
        ColoredEdges = 1
        Smooth = 2
    End Enum

    Enum PieceMovement
        MoveLeft = 1
        MoveRight = 2
        Accelerate = 3
        Change = 4
    End Enum


    Enum Side
        Left = 1
        Right = 2
        Down = 3
        Up = 4
    End Enum


    Enum FallingMethod
        DropDown = 1
        Accelerate = 2
    End Enum
End Module
