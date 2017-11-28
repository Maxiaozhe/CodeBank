Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' 確認
'
Namespace Question
#Region " Common "

    ''' <summary>
    ''' アプリケーション共通の確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 5010001

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5010002

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Quit = 5010003

        ''' <summary>
        ''' 登録します。よろしいですか？{0}{0}『変更内容を有効にするには、システムの再起動が必要です』
        ''' </summary>
        ''' <remarks></remarks>
        EntryReboot = 5010004

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 5010005

        ''' <summary>
        ''' 編集中の値は破棄されます。処理を中止しますか？
        ''' </summary>
        ''' <remarks></remarks>
        StopProc = 5010006

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow クライアントの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        '''登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        SaveCHK = 5020001

        ''' <summary>
        '''年が来年に設定されています。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearOverCHK = 5020002

        ''' <summary>
        '''年が去年に設定されています。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearUnderCHK = 5020003

        ''' <summary>
        '''最大同報数を超えています。同時に送信することができるのは {0}件 までです。
        ''' </summary>
        ''' <remarks></remarks>
        FaxCcCountOver = 5020004

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 5030000

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5040001

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Add = 5040002


        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5040003

        ''' <summary>
        ''' コピーします。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Copy = 5040004

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されているフォームは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        FormCategoryDelete = 5040005

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されているルートは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        RouteCategoryDelete = 5040006

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されているビューは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ViewCategoryDelete = 5040007

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されている結合ルートは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        UnionRouteCategoryDelete = 5040008

        ''' <summary>
        ''' まだ、Ridoc文書プロパティ設定の登録が完了していませんが、終了してもよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        EndPropa = 5040009

        ''' <summary>
        ''' レスフォームを解除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ResClear = 5040010

        ''' <summary>
        ''' サブフォームに紐づく文書も削除されますが、よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        SubFormDelete = 5040011

        ''' <summary>
        ''' 最適化を開始します。{0}文書数によっては処理に時間がかかる場合があります。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ExecuteOptimize = 5040012

        ''' <summary>
        ''' 元に戻します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ExecuteUndo = 5040013

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Confirm = 5040014

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Clear = 5040015

        ''' <summary>
        ''' 削除した文書は二度と元に戻すことができません。{0}本当に削除しますか？
        ''' </summary>
        ''' <remarks></remarks>
        ImportantDelete = 5040016


        ''' <summary>
        ''' 以下の内容で文書を検索します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Search = 5040017

        ''' <summary>
        ''' 以下の内容で文書を更新します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Modify = 5040018

        ''' <summary>
        ''' 以下の内容でRidocを復旧します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        RidocFailedCheck = 5040019

        ''' <summary>
        '''現在表示・編集されているビュー内容が失われますが、よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveData = 5040020

        ''' <summary>
        '''選択されている項目情報等はすべて削除されますがよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        DelAllData = 5040021

        ''' <summary>
        '''表示形式を一覧に設定すると、設定してあるグループ化の情報が消去されますがよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        DelGrpInfo = 5040022

        ''' <summary>
        '''登録後は、ビュータイプの変更はできなくなります。
        ''' </summary>
        ''' <remarks></remarks>
        NotModify = 5040023

        ''' <summary>
        '''カテゴリを削除します。なお、登録されているビューは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        DelCategory = 5040024

        ''' <summary>
        '''本番環境の「同じフォーム名－カテゴリなし」にコピーします。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        SameCategoryCopy = 5040025

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 5040026
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        '''終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Close = 5050001

        ''' <summary>
        '''{0}は変更されています。保存しますか？
        ''' </summary>
        ''' <remarks></remarks>
        CancleClose = 5050002

        ''' <summary>
        '''{0}の変更を保存しますか？
        ''' </summary>
        ''' <remarks></remarks>
        Preview = 5050003

        ''' <summary>
        '''登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Save = 5050004

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        AreYouEntry = 5060001

        ''' <summary>
        ''' サブフォームを変更した場合、設定されている情報がクリアされますがよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        SetInformationClear = 5060002

        ''' <summary>
        ''' 参照ビューを変更した場合、これまでの設定内容はクリアされますがよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ReferenceViewResetOkOrNot = 5060003

        ''' <summary>
        ''' これまでの設定内容がクリアされますがよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ClearOkOrNot = 5060004

        ''' <summary>
        ''' 既にデータ存在する場合、複数選択されているデータの一部が消失しますか？
        ''' </summary>
        ''' <remarks></remarks>
        DeleteExistedData = 5060005

        ''' <summary>
        ''' 現在表示・編集されている内容が失われますが、よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        FormReset = 5060006

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        AreYouDelete = 5060007

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' 追加します。よろしいですか？
        ''' </summary>
        AddNewConfirm = 5070001

        ''' <summary>
        ''' 修正します。よろしいですか？
        ''' </summary>
        ModifyConfirm = 5070002

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        RemoveConfirm = 5070003

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        EntryConfirm = 5070004

        ''' <summary>
        ''' 削除した{0}は二度と元に戻すことができません。本当に削除しますか？
        ''' </summary>
        WarningRemoveConirm = 5070005

        ''' <summary>
        ''' 表示件数を 0 に指定すると該当するすべての{0}を表示します。
        ''' この処理には時間がかかる場合があります。
        ''' 検索を開始しますか？
        ''' 
        ''' 該当する{0}が多数存在する場合は、検索条件を指定するか表示件数を入力してください。
        ''' </summary>
        SearchConfirm = 5070006

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        TerminationConfirm = 5070007

        ''' <summary>
        ''' ロックを解除します。よろしいですか？
        ''' </summary>
        UnLockTerminationConfirm = 5070008

        ''' <summary>
        '''現在編集されている内容が失われますが、よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveData = 5070009

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]
        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 5080001

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5080002

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Quit = 5080003

        ''' <summary>
        ''' 登録します。よろしいですか？{0}{0}『変更内容を有効にするには、システムの再起動が必要です』
        ''' </summary>
        ''' <remarks></remarks>
        EntryReboot = 5080004

        ''' <summary>
        ''' 電報発行ファイルを取り込みます。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        UploadDenpo = 5080005

        ''' <summary>
        ''' 会場マスターファイルを取り込みます。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        UploadHall = 5080006

        ''' <summary>
        ''' 表示している年度の休日・祝日をすべて削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        RemoveAllHoliday = 5080007

        ''' <summary>
        ''' 辞書ファイルを作成作成します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        CreateDictionary = 5080008

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5090001

        ''' <summary>
        ''' ルートを削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ001 = 5090002

        ''' <summary>
        ''' 条件分岐を削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ002 = 5090003

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ003 = 5090004

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ004 = 5090005

        ''' <summary>
        ''' 一覧に表示されているすべての組織・グループを移動します。{0}処理時間は件数に比例します。それでも実行しますか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ005 = 5090006

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' 終了します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        AppicationEnd = 5100001

        ''' <summary>
        ''' ルートを削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ001 = 5100002

        ''' <summary>
        ''' 条件分岐を削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ002 = 5100003

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ003 = 5100004

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        routeQ004 = 5100005

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Add = 5100006

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5100007

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されているフォームは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        FormCategoryDelete = 5100008

        ''' <summary>
        ''' カテゴリを削除します。なお、登録されているルートは「カテゴリなし」に移動されます。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        RouteCategoryDelete = 5100009

        ''' <summary>
        ''' まだ、Ridoc文書プロパティ設定の登録が完了していませんが、終了してもよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        EndPropa = 5100010

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Confirm = 5100011

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Clear = 5100012

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' 処理中のデータが存在します。終了してよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ProcInClose = 5110001

        ''' <summary>
        ''' 処理中のデータが存在します。終了してよろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        ProcInClose2 = 5110002

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' 登録します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 5120001

    End Enum

#End Region

#Region " RFGC "

    ''' <summary>
    ''' R@bitFlow GuiComponents プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFGC]

        ''' <summary>
        ''' 送信します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        IsSendConfirm = 5130001

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB プロジェクトの確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''ログ表示用キー項目が設定されていませんが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyNoNotSelected = 5140001

        ''' <summary>
        '''定義ファイルを読込みますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        ReadMappingXML = 5140002

        ''' <summary>
        '''一時データ作成を実行します。{0}{0}以前作成のデータは消去されますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        MakeLocalData = 5140003

        ''' <summary>
        '''選択されたフォームのデータ件数を取得します。{0}処理に時間がかかる場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        GetNotesDataCount = 5140004

        ''' <summary>
        '''選択されたファイルのデータ件数を取得します。{0}処理に時間がかかる場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        GetCsvDataCount = 5140005

        ''' <summary>
        '''制約マスタを更新します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        MakeSeiyakuData = 5140006

        ''' <summary>
        '''終了します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        EndMessage = 5140007

        ''' <summary>
        '''アップロードを開始します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        StartUpLoad = 5140008

        ''' <summary>
        '''保存していない場合、現在編集中の情報は失われますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        IsErase = 5140009

        ''' <summary>
        '''現在の設定情報はクリアされますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CoutionCnt = 5140010

        ''' <summary>
        '''有効な一時データが作成されています。{0}データアップロード画面を開きますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        AUOpenUpLoadWindow = 5140011

        ''' <summary>
        '''一時データは正常に作成されました。{0}{0} 移行結果レポートを保存しますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CreateLocalDataComplete = 5140012

        ''' <summary>
        '''一時データを作成します。{0}{0}移行結果詳細ログを記録しますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        WriteConvertLog = 5140013

        ''' <summary>
        '''コピーを開始します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CopyStart = 5140014

        ''' <summary>
        '''一時データ作成を中断します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 5140015

        ''' <summary>
        '''テキスト修飾子「{0}」の場合、{1}正しいデータが読込めない場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        NonQualifier = 5140016

        ''' <summary>
        ''' アップロードを開始します。{0}{0}移行結果詳細ログを記録しますか？
        ''' </summary>
        ''' <remarks></remarks>
        WriteUploadLog = 5140017

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter の確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' 連携処理開始の確認メッセージ
        ''' </summary>
        Msg0001 = 5160001

        ''' <summary>
        ''' 人事データ復元開始の確認メッセージ
        ''' </summary>
        Msg0002 = 5160002

        ''' <summary>
        ''' 終了確認メッセージ
        ''' </summary>
        Msg0003 = 5160003

        ''' <summary>
        ''' 詳細設定の登録確認メッセージ。
        ''' </summary>
        Msg0004 = 5160004

        ''' <summary>
        ''' 移動先フォルダが入力されていない場合のメッセージ。
        ''' </summary>
        Msg0005 = 5160005

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter の確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''ログ表示用キー項目が設定されていませんが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyNoNotSelected = 5180001

        ''' <summary>
        '''定義ファイルを読込みますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        ReadMappingXML = 5180002

        ''' <summary>
        '''一時データ作成を実行します。{0}{0}以前作成のデータは消去されますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        MakeLocalData = 5180003

        ''' <summary>
        '''選択されたフォームのデータ件数を取得します。{0}処理に時間がかかる場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        GetNotesDataCount = 5180004

        ''' <summary>
        '''選択されたファイルのデータ件数を取得します。{0}処理に時間がかかる場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        GetCsvDataCount = 5180005

        ''' <summary>
        '''制約マスタを更新します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        MakeSeiyakuData = 5180006

        ''' <summary>
        '''終了します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        EndMessage = 5180007

        ''' <summary>
        '''アップロードを開始します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        StartUpLoad = 5180008

        ''' <summary>
        '''保存していない場合、現在編集中の情報は失われますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        IsErase = 5180009

        ''' <summary>
        '''現在の設定情報はクリアされますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CoutionCnt = 5180010

        ''' <summary>
        '''有効な一時データが作成されています。{0}データアップロード画面を開きますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        AUOpenUpLoadWindow = 5180011

        ''' <summary>
        '''一時データは正常に作成されました。{0}{0} 移行結果レポートを保存しますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CreateLocalDataComplete = 5180012

        ''' <summary>
        '''一時データを作成します。{0}{0}移行結果詳細ログを記録しますか？ 
        ''' </summary>
        ''' <remarks></remarks>
        WriteConvertLog = 5180013

        ''' <summary>
        '''コピーを開始します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        CopyStart = 5180014

        ''' <summary>
        '''一時データ作成を中断します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 5180015

        ''' <summary>
        '''テキスト修飾子「{0}」の場合、{1}正しいデータが読込めない場合がありますが、よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        NonQualifier = 5180016

        ''' <summary>
        ''' アップロードを開始します。{0}{0}移行結果詳細ログを記録しますか？
        ''' </summary>
        ''' <remarks></remarks>
        WriteUploadLog = 5180017

        ''' <summary>
        ''' 元のデータを削除しますか？
        ''' </summary>
        ''' <remarks></remarks>
        DeleteAllOldData = 5180018

        ''' <summary>
        ''' ユーザーのマッピングデータをローカルデータベースに登録します。{0}よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        QuestionBeforeUserDataInsert = 5180019

        ''' <summary>
        '''アップロードを中断します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpload = 5180020

        ''' <summary>
        '''設定内容を確定します。よろしいですか？ 
        ''' </summary>
        ''' <remarks></remarks>
        IsSave = 5180021
    End Enum

#End Region

#Region " VAGP "

    ''' <summary>
    ''' アプリケーション共通の確認メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VAGP]

        ''' <summary>
        ''' 変更します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Modify = 5190001

        ''' <summary>
        ''' 削除します。よろしいですか？
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 5190002

    End Enum

#End Region
End Namespace

