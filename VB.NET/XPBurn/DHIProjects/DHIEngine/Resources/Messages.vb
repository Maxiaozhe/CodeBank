Public Class Messages
    '''<summary>
    '''  CDを書き込みしています。（{0}%） に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property BlockProgress() As String
        Get
            Return My.Resources.Messages.BlockProgress
        End Get
    End Property

    '''<summary>
    '''  CDの書き込みが完了しました。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property BurnComplete() As String
        Get
            Return My.Resources.Messages.BurnComplete
        End Get
    End Property

    '''<summary>
    '''  XMLデータにエラーがあります。処理を引続きますか？ に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property IsContinue() As String
        Get
            Return My.Resources.Messages.IsContinue
        End Get
    End Property

    '''<summary>
    '''  ファイル{0}が存在しません。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property NotFindFile() As String
        Get
            Return My.Resources.Messages.NotFindFile
        End Get
    End Property

    '''<summary>
    '''  出力ファイルを選択してください。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property NotSelectedFile() As String
        Get
            Return My.Resources.Messages.NotSelectedFile
        End Get
    End Property

    '''<summary>
    '''  CD書き込みを準備しています。しばらくおまちください。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property PreparingBurn() As String
        Get
            Return My.Resources.Messages.PreparingBurn
        End Get
    End Property

    '''<summary>
    '''  XMLデータの整合性チェックを完了しました。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property XmlCheckComplete() As String
        Get
            Return My.Resources.Messages.XmlCheckComplete
        End Get
    End Property

    '''<summary>
    '''  XMLデータの整合性チェックを完了しました。エラーが発生しました。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property XmlCheckFailed() As String
        Get
            Return My.Resources.Messages.XmlCheckFailed
        End Get
    End Property

    '''<summary>
    '''  XMLデータの整合性をチェックしています。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property XMLChecking() As String
        Get
            Return My.Resources.Messages.XMLChecking
        End Get
    End Property
    '''<summary>
    '''  ファイルを読み取りできません。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property CantReadFile() As String
        Get
            Return My.Resources.Messages.CantReadFile
        End Get
    End Property
    '''<summary>
    '''  このシステムにCD-ROMドライブがありません。 に類似しているローカライズされた文字列を検索します。
    '''</summary>
    Public Shared ReadOnly Property NotCDROM() As String
        Get
            Return My.Resources.Messages.NotCDROM
        End Get
    End Property
End Class
