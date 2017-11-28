Option Compare Binary
Option Explicit On
Option Strict On

Imports System
'
' 情報
'
Namespace Information
#Region " Common "

    ''' <summary>
    ''' アプリケーション共通の情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' 処理が終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        ProcessComplete = 4010001

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks>例外の内容をそのまま表示する場合に使用します。</remarks>
        ExceptionMessage = 4010002

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow クライアントの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]
        ''' <summary>
        '''パスワードを変更しました。
        ''' </summary>
        ''' <remarks></remarks>
        InfoChangePass = 4020001

        ''' <summary>
        '''一括{0}が完了しました。
        ''' </summary>
        ''' <remarks></remarks>
        EndAllAccept = 4020002

        ''' <summary>
        '''デフォルト所属を変更しました。{0}次回のビュー画面へのログイン時より設定が有効になります。
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgCheEnd = 4020003

        ''' <summary>
        '''最大同報数を超えています。同時に送信することができるのは {0}件 までです。
        ''' </summary>
        ''' <remarks></remarks>
        FaxCcCountOver = 4020004

        ''' <summary>
        '''共同作成者を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectSharedUser = 4020005

        ''' <summary>
        '''選択された文書には、印刷許可されている文書が存在しません。{0}プレビュー表示することができませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotPrint = 4020006

        ''' <summary>
        '''選択された文書に、印刷許可されていない文書が含まれています。{0}許可されていない文書のプレビューは表示されません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotPreview = 4020007

        ''' <summary>
        ''' ルートを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionRoute = 4020008

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        ''' 欠番はありません。
        ''' </summary>
        ''' <remarks></remarks>
        MissingNumber = 4030001

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' 登録が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        Update = 4040001


        ''' <summary>
        ''' 削除が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 4040002

        ''' <summary>
        ''' 現在組織改編中です。ルートの編集できません(内容の参照のみ可能です)。
        ''' </summary>
        ''' <remarks></remarks>
        OnTheWayReOrganization = 4040003

        ''' <summary>
        ''' 登録が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        Entry = 4040004


        ''' <summary>
        ''' Ridoc連携の登録が正常に終了しました。{0}運用設定の登録ボタンを押して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Entry2 = 4040005

        ''' <summary>
        ''' コピーしたフォームのＧＵＩコンポーネントの属性設定が「未設定」となります。{0}フォームエディタより設定をして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        GUIConIsNoSetMessage = 4040006

        ''' <summary>
        ''' 結合ビューはコピーできません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewNotCopy = 4040007

        ''' <summary>
        '''コピーが完了しました。コピー先でカテゴリの移動を行ってください。
        ''' </summary>
        ''' <remarks></remarks>
        MoveCategory = 4040008
        ''' <summary>
        ''' ファイル取込みが完了ました。
        ''' </summary>
        ''' <remarks></remarks>
        ImportFinashed = 4040009
        ''' <summary>
        ''' ファイル出力が完了ました。
        ''' </summary>
        ''' <remarks></remarks>
        ExportFinashed = 4040010
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4050000

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' フォーム項目が選択されていないか、選択されている項目が選択不可になっています。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectFormField = 4060001

        ''' <summary>
        ''' 指定されたフォーム項目がフォームに存在していません。
        ''' </summary>
        ''' <remarks></remarks>
        NotExistsFormField = 4060002

        ''' <summary>
        ''' 開始日から終了日までの範囲が期間の最大範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverMaxRangeItem = 4060003

        ''' <summary>
        ''' 設定を登録しました。
        ''' </summary>
        ''' <remarks></remarks>
        RegistOK = 4060004

        ''' <summary>
        ''' 計算式のチェックが正常完了します。
        ''' </summary>
        ''' <remarks></remarks>
        ExpressCheckOK = 4060005

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' 有効開始日付が変更されました。
        ''' 
        ''' 新しく登録する有効開始日付以前に設定されている下位の組織・グループおよび、組織・グループに属する
        ''' 所属の有効開始日付は、新しい日付で更新されます。
        ''' 変更した有効開始日付が有効期限日付以降となる組織・グループおよび所属は削除されます。
        ''' 削除された組織・グループおよび所属は、元に戻すことができません。
        ''' </summary>
        GroupMsg0001 = 4070001

        ''' <summary>
        ''' 有効期限日付が変更されました。
        ''' 
        ''' 新しく登録する有効期限日付以降に設定されている下位の組織・グループおよび、組織・グループに属する
        ''' 所属の有効期限日付は、新しい日付で更新されます。
        ''' 変更した有効期限日付が有効開始日付以前となる組織・グループおよび所属は削除されます。
        ''' 削除された組織・グループおよび所属は、元に戻すことができません。
        ''' </summary>
        GroupMsg0002 = 4070002

        ''' <summary>
        ''' 組織・グループ名、略名、英字名が変更されました。
        ''' この場合、下位組織・グループの名称も変更するため、処理に時間が掛かります。
        ''' </summary>
        GroupMsg0003 = 4070003

        ''' <summary>
        ''' 利用開始日付が変更されました。
        ''' 
        ''' 個人の利用開始日付を変更した場合、既に登録されている所属の有効開始日付は、
        ''' 個人の利用開始日付で変更されます。
        ''' 変更の対象となる所属は、新しく変更する個人の有効開始日付以前の所属です。
        ''' 変更した有効開始日付が有効期限日付以降となる所属は削除されます。
        ''' 削除された所属は、元に戻すことができません。
        ''' </summary>
        PersonMsg0001 = 4071001

        ''' <summary>
        ''' 利用終了日付が変更されました。
        ''' 
        ''' 個人の利用終了日付を変更した場合、既に登録されている所属の有効期限日付、
        ''' 個人の利用終了日付で変更されます。
        ''' 変更の対象となる所属は、新しく変更する個人の有効期限日付以降の所属です。
        ''' 変更した有効期限日付が有効開始日付以前となる所属は削除されます。
        ''' 削除された所属は、元に戻すことができません。
        ''' </summary>
        PersonMsg0002 = 4071002

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        ''' <summary>
        ''' 登録処理が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        AddDataOk = 4080001

        ''' <summary>
        ''' 更新処理が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        UpdDataOk = 4080002

        ''' <summary>
        ''' 削除処理が正常に終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        DelDataOk = 4080003

        ''' <summary>
        ''' 対象データが一件もありませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        NotData = 4080004


        ''' <summary>
        ''' 取り込み処理が完了しました。
        ''' </summary>
        ''' <remarks></remarks>
        DenpoOK = 4080005

        ''' <summary>
        ''' 社員を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionUser = 4080006

        ''' <summary>
        ''' ルートを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectionRoute = 4080007

        ''' <summary>
        ''' 組織・役職またはグループを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectioGroup = 4080008

        ''' <summary>
        ''' 辞書ファイルを作成しました。
        ''' 作成した辞書ファイルを有効にする場合は、全文検索サービスを再起動してください。
        ''' </summary>
        ''' <remarks></remarks>
        CreatedDictionary = 4080009

        ''' <summary>
        ''' CSVファイルの出力が完了しました。
        ''' </summary>
        ''' <remarks></remarks>
        OutputCsvCompleted = 4080010

        ''' <summary>
        ''' CSVファイルの取込が完了しました。
        ''' </summary>
        ''' <remarks></remarks>
        InputCsvCompleted = 4080011

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' このルートは整合性が無くなってしまった為、使用できません。{0} ルートを再作成して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeI001 = 4090001

        ''' <summary>
        ''' ルートチェックが終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeI002 = 4090002

        ''' <summary>
        ''' 削除対象を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeI003 = 4090003

        ''' <summary>
        ''' 選択された組織に社員が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeI004 = 4090004

        ''' <summary>
        ''' 削除しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeI005 = 4090005

        ''' <summary>
        ''' 選択された組織に社員が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeI006 = 4090006

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' 選択された組織に社員が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeI001 = 4100001

        ''' <summary>
        ''' ルートチェックが終了しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeI002 = 4100002

        ''' <summary>
        ''' 削除対象を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeI003 = 4100003

        ''' <summary>
        ''' 選択対象に組織・グループが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeI004 = 4100004

        ''' <summary>
        ''' 削除しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeI005 = 4100005

        ''' <summary>
        ''' 登録が正常に終了しました。
        ''' </summary>
        ''' <remarks>
        '''フォーム/ルート割当データ・フォーム詳細管理データ正常終了時
        '''</remarks>
        Update = 4100006

        ''' <summary>
        ''' 削除が正常に終了しました。
        ''' </summary>
        ''' <remarks>
        '''フォーム情報・ルートデータ削除正常終了時
        '''</remarks>
        Delete = 4100007

        ''' <summary>
        ''' 現在組織改編中です。ルートの編集できません(内容の参照のみ可能です)。
        ''' </summary>
        ''' <remarks>
        '''フォーム情報・ルートデータ削除正常終了時
        '''</remarks>
        OnTheWayReOrganization = 4100008

        ''' <summary>
        ''' 登録が正常に終了しました。
        ''' </summary>
        ''' <remarks>
        '''文書プロパティ設定登録正常終了時
        '''</remarks>
        Entry = 4100009

        ''' <summary>
        ''' Ridoc連携の登録が正常に終了しました。{0}運用設定の登録ボタンを押して下さい。
        ''' </summary>
        ''' <remarks>
        '''Ridoc連携の登録終了時
        '''</remarks>
        Entry2 = 4100010

        ''' <summary>
        ''' 選択対象に組織・グループが存在しません。
        ''' </summary>
        ''' <remarks>
        '''Ridoc連携の登録終了時
        '''</remarks>
        RUN_I004 = 4100011

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 4120000

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB プロジェクトの情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''フォーム定義ファイルは正常に保存されました。 
        ''' </summary>
        ''' <remarks></remarks>
        WriteXMLComplete = 4140001

        ''' <summary>
        '''データアップロード定義ファイルは正常に保存されました。{0}一時データ作成を実行して下さい。 
        ''' </summary>
        ''' <remarks></remarks>
        WriteDataXMLComplete = 4140002

        ''' <summary>
        '''アップロードが終了しました。 
        ''' </summary>
        ''' <remarks></remarks>
        UploadComplete = 4140003

        ''' <summary>
        '''制約マスタには一件もデータが存在しません。 
        ''' </summary>
        ''' <remarks></remarks>
        SelectNoSeiyakuData = 4140004

        ''' <summary>
        '''制約マスタの更新が失敗しました。 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataErr = 4140005

        ''' <summary>
        '''制約マスタの更新が終了しました。 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataComplete = 4140006

        ''' <summary>
        '''処理が中断されました。 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpdate = 4140007

        ''' <summary>
        '''一時データと設定ファイルの内容が異なります。{0}一時データ作成からやり直してください。 
        ''' </summary>
        ''' <remarks></remarks>
        ChengedMappingFiles = 4140008

        ''' <summary>
        '''一時データが存在しないため、アップロードできません。 
        ''' </summary>
        ''' <remarks></remarks>
        NothingTempData = 4140009

        ''' <summary>
        '''移行先フォームを呼び出すGUIが存在しません。 
        ''' </summary>
        ''' <remarks></remarks>
        NothingCallSubFrmGui = 4140010

        ''' <summary>
        '''一時データ作成は中断されました。 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 4140011

        ''' <summary>
        '''一時データ作成は終了しています。 
        ''' </summary>
        ''' <remarks></remarks>
        AlreadyCreateed = 4140012

        ''' <summary>
        '''フォームのコピーが終了しました。{0}新フォームＩＤは「{1}」です。
        ''' </summary>
        ''' <remarks></remarks>
        CopyEnd = 4140013

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter の情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' 詳細設定が実行されていない場合のメッセージ。
        ''' </summary>
        Msg0001 = 4160001

        ''' <summary>
        ''' 連携処理が実行中のため開始できないメッセージ。
        ''' </summary>
        Msg0002 = 4160002

        ''' <summary>
        ''' 連携処理がロックされているため開始できないメッセージ。
        ''' </summary>
        Msg0003 = 4160003

        ''' <summary>
        ''' 連携処理の成功を示すメッセージ。
        ''' </summary>
        Msg0004 = 4160004

        ''' <summary>
        ''' 連携処理の失敗を示すメッセージ。
        ''' </summary>
        Msg0005 = 4160005

        ''' <summary>
        ''' 人事データの復元成功を示すメッセージ。
        ''' </summary>
        Msg0006 = 4160006

        ''' <summary>
        ''' 人事データの復元に失敗した場合のメッセージ。
        ''' </summary>
        Msg0007 = 4160007

        ''' <summary>
        ''' 人事データの復元処理が実行中のため開始できないメッセージ。
        ''' </summary>
        Msg0008 = 4160008

        ''' <summary>
        ''' ログインユーザーにより取込が開始されたメッセージ。
        ''' </summary>
        Msg0009 = 4160009

        ''' <summary>
        ''' 詳細設定が行われていない場合のメッセージ。
        ''' </summary>
        Msg0010 = 4160010

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter の情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' バックアップの開始メッセージ
        ''' </summary>
        Msg0001 = 4170001

        ''' <summary>
        ''' バックアップの終了メッセージ
        ''' </summary>
        Msg0002 = 4170002

        ''' <summary>
        ''' ワークテーブルへコピー開始のメッセージ
        ''' </summary>
        Msg0003 = 4170003

        ''' <summary>
        ''' ワークテーブルへコピー終了のメッセージ
        ''' </summary>
        Msg0004 = 4170004

        ''' <summary>
        ''' 一時データ作成開始のメッセージ
        ''' </summary>
        Msg0005 = 4170005

        ''' <summary>
        ''' 一時データ作成終了のメッセージ
        ''' </summary>
        Msg0006 = 4170006

        ''' <summary>
        ''' マージ開始のメッセージ
        ''' </summary>
        Msg0007 = 4170007

        ''' <summary>
        ''' マージ終了のメッセージ
        ''' </summary>
        Msg0008 = 4170008

        ''' <summary>
        ''' リネーム開始のメッセージ
        ''' </summary>
        Msg0009 = 4170009

        ''' <summary>
        ''' リネーム終了のメッセージ
        ''' </summary>
        Msg0010 = 4170010

        ''' <summary>
        ''' アーカイブ開始のメッセージ
        ''' </summary>
        Msg0011 = 4170011

        ''' <summary>
        ''' アーカイブ終了のメッセージ
        ''' </summary>
        Msg0012 = 4170012

        ''' <summary>
        ''' 復元開始のメッセージ
        ''' </summary>
        Msg0013 = 4170013

        ''' <summary>
        ''' 復元終了のメッセージ
        ''' </summary>
        Msg0014 = 4170014

        ''' <summary>
        ''' アーカイブから復元を開始する場合のメッセージ
        ''' </summary>
        Msg0015 = 4170015

        ''' <summary>
        ''' 登録済みレコードのため、一時テーブルへの登録をスキップした場合のメッセージ
        ''' </summary>
        Msg0016 = 4170016

        ''' <summary>
        ''' 各人事データのマージ開始メッセージ
        ''' </summary>
        Msg0017 = 4170017

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter の情報メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''フォーム定義ファイルは正常に保存されました。 
        ''' </summary>
        ''' <remarks></remarks>
        WriteXMLComplete = 4180001

        ''' <summary>
        '''データアップロード定義ファイルは正常に保存されました。{0}一時データ作成を実行して下さい。 
        ''' </summary>
        ''' <remarks></remarks>
        WriteDataXMLComplete = 4180002

        ''' <summary>
        '''アップロードが終了しました。 
        ''' </summary>
        ''' <remarks></remarks>
        UploadComplete = 4180003

        ''' <summary>
        '''制約マスタには一件もデータが存在しません。 
        ''' </summary>
        ''' <remarks></remarks>
        SelectNoSeiyakuData = 4180004

        ''' <summary>
        '''制約マスタの更新が失敗しました。 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataErr = 4180005

        ''' <summary>
        '''制約マスタの更新が終了しました。 
        ''' </summary>
        ''' <remarks></remarks>
        CreateSeiyakuDataComplete = 4180006

        ''' <summary>
        '''処理が中断されました。 
        ''' </summary>
        ''' <remarks></remarks>
        AbortUpdate = 4180007

        ''' <summary>
        '''一時データと設定ファイルの内容が異なります。{0}一時データ作成からやり直してください。 
        ''' </summary>
        ''' <remarks></remarks>
        ChengedMappingFiles = 4180008

        ''' <summary>
        '''移行先フォームを呼び出すGUIが存在しません。 
        ''' </summary>
        ''' <remarks></remarks>
        NothingCallSubFrmGui = 4180010

        ''' <summary>
        '''一時データ作成は中断されました。 
        ''' </summary>
        ''' <remarks></remarks>
        AbortCreate = 4180011

        ''' <summary>
        '''一時データ作成は完了しました。 
        ''' </summary>
        ''' <remarks></remarks>
        AlreadyCreateed = 4180012

        ''' <summary>
        '''フォームのコピーが終了しました。{0}新フォームＩＤは「{1}」です。
        ''' </summary>
        ''' <remarks></remarks>
        CopyEnd = 4180013

        ''' <summary>
        '''データの登録が完了しました。{0}成功：{1}件、失敗：{2}件
        ''' </summary>
        ''' <remarks></remarks>
        UpdatedUserMapping = 4180014

        ''' <summary>
        '''一時データは正常に作成されました。
        ''' </summary>
        ''' <remarks></remarks>
        DataCreated = 4180015

        ''' <summary>
        '''データのアップロードが完了しました！
        ''' </summary>
        ''' <remarks></remarks>
        DataUploaded = 4180016

        '''' <summary>
        ''''登録するデータが存在しません。
        '''' </summary>
        '''' <remarks></remarks>
        'EmptyData = 4180017

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 4180018

        ''' <summary>
        '''バッチ定義ファイルは正常に保存されました。
        ''' </summary>
        ''' <remarks></remarks>
        FileSaved = 4180019

        ''' <summary>
        '''{0}件目登録完了。{1}成功：{2}件、失敗：{3}件
        ''' </summary>
        ''' <remarks></remarks>
        MappingDataInsertedInfo = 4180020

        ''' <summary>
        '''アップロードが中断されました。 
        ''' </summary>
        ''' <remarks></remarks>
        UploadAborted = 4180021
    End Enum

#End Region
End Namespace
