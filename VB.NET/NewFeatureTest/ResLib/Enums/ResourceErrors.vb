Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' エラー
'
Namespace [Error]
#Region " Common "
    ''' <summary>
    ''' アプリケーション共通のエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' 予期せぬエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        UnKnownSystemError = 1010001

        ''' <summary>
        ''' データ登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataEntryFailed = 1010002

        ''' <summary>
        ''' データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataDeleteFailed = 1010003
        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1010004

    End Enum
#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow クライアントのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        '''Ridocエラーです。管理者に問い合わせて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RidocError = 1020001

        ''' <summary>
        '''申請文書がRidocにて使用中です。
        ''' </summary>
        ''' <remarks></remarks>
        RidocDocumentLockedError = 1020002

        ''' <summary>
        '''鑑作成に失敗しました。{0}処理をやり直して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MakeCopyStampSubmitError = 1020003

        ''' <summary>
        '''鑑作成に失敗しました。{0}処理をやり直して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MakeCopyStampDenyError = 1020004

        ''' <summary>
        '''文書のＡＣＬ登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SetACLError = 1020005

        ''' <summary>
        '''システムエラーです。管理者に問い合わせて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1020006

        ''' <summary>
        '''初期化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InitFailed = 1020007

        ''' <summary>
        '''{0}処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MakeFailed = 1020008

        ''' <summary>
        '''{0}処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptFailed = 1020009

        ''' <summary>
        '''{0}処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SubmitFailed = 1020010

        ''' <summary>
        '''{0}処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DenyFailed = 1020011

        ''' <summary>
        '''{0}処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RemandFailed = 1020012

        ''' <summary>
        '''処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ProcessFailed = 1020013

        ''' <summary>
        '''メール送信に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SendMailFailed = 1020014

        ''' <summary>
        '''公開者の追加に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AddPublicationFailed = 1020015

        ''' <summary>
        '''公開者の削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DelPublicationFailed = 1020016

        ''' <summary>
        '''参照者の追加に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AddReferenceFailed = 1020017

        ''' <summary>
        '''参照者の削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DelReferenceFailed = 1020018

        ''' <summary>
        '''次の{0}者が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        NextNUserNotFind = 1020019

        ''' <summary>
        '''前の{0}者が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        PrevNUserNotFind = 1020020

        ''' <summary>
        '''{0}が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNUserNotFind = 1020021

        ''' <summary>
        '''前のページに戻れません。
        ''' </summary>
        ''' <remarks></remarks>
        PageBackToFailed = 1020022

        ''' <summary>
        '''次のページに進めません。
        ''' </summary>
        ''' <remarks></remarks>
        PageGoToFailed = 1020023

        ''' <summary>
        '''フォームの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetFormFailed = 1020024

        ''' <summary>
        '''ビューの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetViewFailed = 1020025

        ''' <summary>
        '''文書の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetDocumentFailed = 1020026

        ''' <summary>
        '''一括{0}に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AllAcceptFalied = 1020027

        ''' <summary>
        '''ＣＳＶファイルの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CreateCSVFailed = 1020028

        ''' <summary>
        '''ルートの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CreateRouteFailed = 1020029

        ''' <summary>
        '''日付の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetCalFailed = 1020030

        ''' <summary>
        '''フォーム起動処理に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        CallFailed = 1020031

        ''' <summary>
        '''排他解除処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocReleaseUpdate = 1020032

        ''' <summary>
        '''割込修正依頼処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocCutIntoErr = 1020033

        ''' <summary>
        '''割込修正完了処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocCutIntoOnErr = 1020034

        ''' <summary>
        '''申請処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocMakeErr = 1020035

        ''' <summary>
        '''審査処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocAcceptErr = 1020036

        ''' <summary>
        '''承認処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocSubmitErr = 1020037

        ''' <summary>
        '''差戻し処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocRemandErr = 1020038

        ''' <summary>
        '''否認処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocDenyErr = 1020039

        ''' <summary>
        '''デフォルト所属設定の処理を失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgUpdateErr = 1020040

        ''' <summary>
        '''チェックイン処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CheckInProcessFailed = 1020041

        ''' <summary>
        '''チェックアウト処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CheckOutProcessFailed = 1020042

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1020043

        ''' <summary>
        ''' 社員情報の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UserInfoGetException = 1020044

        ''' <summary>
        '''フォーム異常が発生されました。管理者に問い合わせてください
        ''' </summary>
        ''' <remarks></remarks>
        NonBasePage = 1020045

        ''' <summary>
        '''一覧表示に異常発生しました。管理者に問い合わせてください。
        ''' </summary>
        ''' <remarks></remarks>
        FailedDBGrid = 1020046

        ''' <summary>
        '''奨励金科目の設定に異常発生しました。管理者に問い合わせてください
        ''' </summary>
        ''' <remarks></remarks>
        FailedIncent = 1020047

        ''' <summary>
        '''登録データ取得失敗しました。管理者に問い合わせてください。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetProperty = 1020048

        ''' <summary>
        '''項目{0}に数値を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        illegalDataInput = 1020049

        ''' <summary>
        '''計算式の設定に誤りがあります。{1}項目{0}はありません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldInExpress = 1020050

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        '''フォーム起動時に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        FormInitFailed = 1030001

        ''' <summary>
        '''項目「{0}」のフォーム構成時に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        InitFailed = 1030002

        ''' <summary>
        '''項目「{0}」のデータ取得時に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        LoadFailed = 1030003

        ''' <summary>
        '''項目「{0}」のデータ保存時に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        SaveFailed = 1030004

        ''' <summary>
        '''項目「{0}」で西暦変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianClFailed = 1030005

        ''' <summary>
        '''項目「{0}」で和暦変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeJapaneseEraFailed = 1030006

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' データ登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedAdd = 1040001

        ''' <summary>
        ''' データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedDelete = 1040002

        ''' <summary>
        ''' 組織改編履歴の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetInnavationDate = 1040003

        ''' <summary>
        ''' カテゴリデータの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetCategory = 1040004


        ''' <summary>
        ''' データコピーに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedCopy = 1040005


        ''' <summary>
        ''' 運用設定データの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddFormDetaile = 1040006

        ''' <summary>
        ''' フォームの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormHeader = 1040007


        ''' <summary>
        ''' ルートの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetRouteHeader = 1040008


        ''' <summary>
        ''' 使用フォームのデータ割当に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledUpdateJoinForm = 1040009

        ''' <summary>
        ''' 使用ルートのデータ割当に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledUpdateJoinRoute = 1040010

        ''' <summary>
        ''' ビュー情報データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetView = 1040011

        ''' <summary>
        ''' 採番項目データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetDocumentNumber = 1040012

        ''' <summary>
        ''' システムエラーです。予期せぬエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        SystemUnKnownError = 1040013


        ''' <summary>
        ''' フォームを公開中の為、削除できませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        FailedNotDelete = 1040014

        ''' <summary>
        ''' 文書プロパティ情報登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocPropEntryFailed = 1040015

        ''' <summary>
        ''' 文書プロパティ情報登録用データ作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>

        DocPropEntryDataFailed = 1040016

        ''' <summary>
        ''' 文書タイプ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetDocPropListFailed = 1040017

        ''' <summary>
        ''' 文書プロパティ連携情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetDataFailed = 1040018

        ''' <summary>
        ''' フォームデータ報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetFormDataFailed = 1040019

        ''' <summary>
        ''' キャビネット一覧情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetCabListFailed = 1040020

        ''' <summary>
        ''' システムエラーです。管理者に問い合わせて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1040021

        ''' <summary>
        ''' 使用フォームの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinForm = 1040022

        ''' <summary>
        ''' 使用ルートの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinRoute = 1040023


        ''' <summary>
        ''' 使用ルート・フォームの割当データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledDeleteJoinData = 1040024

        ''' <summary>
        ''' 使用ルート・フォームの割当データ登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddJoinData = 1040025

        ''' <summary>
        ''' 運用設定データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormDetaile = 1040026

        ''' <summary>
        ''' レポートエディタの起動に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReportEditorAbonMessage = 1040027

        ''' <summary>
        ''' 管理帳票の起動に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReportToolAbonMessage = 1040028


        ''' <summary>
        ''' カテゴリを読み込むことができません。
        ''' </summary>
        ''' <remarks></remarks>
        CategoryCanNotRead = 1040029

        ''' <summary>
        ''' フォームを読み込むことができません。
        ''' </summary>
        ''' <remarks></remarks>
        FormCanNotRead = 1040030

        ''' <summary>
        ''' ビューを読み込むことができません。
        ''' </summary>
        ''' <remarks></remarks>
        ViewCanNotRead = 1040031

        ''' <summary>
        ''' 文書を読み込むことができません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentCanNotRead = 1040032

        ''' <summary>
        ''' 文書の更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentModifyFailed = 1040033

        ''' <summary>
        ''' 文書の削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentDeleteFailed = 1040034

        ''' <summary>
        ''' Ridocの復旧に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RidocFailed = 1040035

        ''' <summary>
        ''' 表示項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorView = 1040036

        ''' <summary>
        ''' グループ項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorGroup = 1040037

        ''' <summary>
        ''' 条件項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorCondition = 1040038

        ''' <summary>
        ''' 結合項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC030 = 1040039

        ''' <summary>
        ''' 表示名が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC017 = 1040040

        ''' <summary>
        ''' 選択された表示名は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeC018 = 1040041
        ''' <summary>
        ''' ファイルの取り込み中に異常が発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        FormConvertFailed = 1040042
    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        '''<summary>
        '''登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedSave = 1050001

        ''' <summary>
        '''プロパティの設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PropertySetFailed = 1050002

        ''' <summary>
        '''フォームは見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        FailedOpen = 1050003

        ''' <summary>
        '''システムエラーです。
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1050004

        ''' <summary>
        '''フォーム情報の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotRead = 1050005

        ''' <summary>
        '''{0}の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotReadFor = 1050006

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherError = 1050007

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks>6</remarks>
    Public Enum [VGUI]

        ''' <summary>
        '''既存プロパティの読込みに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReadPropertyFailed = 1060001

        ''' <summary>
        '''新規プロパティを作成できません。
        ''' </summary>
        ''' <remarks></remarks>
        NewInstanceNotMake = 1060002

        ''' <summary>
        '''プロパティの登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailed = 1060003

        ''' <summary>
        '''処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCatchVGUI0001 = 1060004

        ''' <summary>
        '''予期せぬエラーが発生しました。管理者にお問い合わせ下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SystemError = 1060005

        ''' <summary>
        '''項目の設定が誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        ItemSetError = 1060006

    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' アプリケーションの継続が不可能な例外が発生しました。
        ''' 詳しくはシステム管理者にお問い合わせください。
        ''' </summary>
        CommonMsg0000 = 1070001

        ''' <summary>
        ''' 所属設定画面の起動に失敗しました。
        ''' </summary>
        AffiliationMsg0001 = 1071001

        ''' <summary>
        ''' 組織・グループを表示することができません。
        ''' </summary>
        AffiliationMsg0002 = 1071002

        ''' <summary>
        ''' 所属を表示することができません。
        ''' </summary>
        AffiliationMsg0003 = 1071003

        ''' <summary>
        ''' 組織・グループ別所属設定画面を開くことができません。
        ''' </summary>
        AffiliationMsg0004 = 1071004

        ''' <summary>
        ''' 個人別所属設定画面を開くことができません。
        ''' </summary>
        AffiliationMsg0005 = 1071005

        ''' <summary>
        ''' 個人一覧を表示することができません。
        ''' </summary>
        AffiliationMsg0006 = 1071006

        ''' <summary>
        ''' 個人の検索に失敗しました。
        ''' </summary>
        AffiliationMsg0007 = 1071007

        ''' <summary>
        ''' 所属に追加できません。
        ''' </summary>
        AffiliationMsg0008 = 1071008

        ''' <summary>
        ''' 所属を削除できません。
        ''' </summary>
        AffiliationMsg0009 = 1071009

        ''' <summary>
        ''' 所属情報を表示できません。
        ''' </summary>
        AffiliationMsg0010 = 1071010

        ''' <summary>
        ''' 所属の登録に失敗しました。
        ''' </summary>
        AffiliationMsg0011 = 1071011

        ''' <summary>
        ''' 部門登録画面の起動に失敗しました。
        ''' </summary>
        BranchMsg0001 = 1072001

        ''' <summary>
        ''' 部門を追加することができません。
        ''' </summary>
        BranchMsg0002 = 1072002

        ''' <summary>
        ''' 部門を削除することができません。
        ''' </summary>
        BranchMsg0003 = 1072003

        ''' <summary>
        ''' 部門の登録に失敗しました。
        ''' </summary>
        BranchMsg0004 = 1072004

        ''' <summary>
        ''' 組織・グループ登録画面の起動に失敗しました。
        ''' </summary>
        GroupMsg0001 = 1073001

        ''' <summary>
        ''' 組織・グループを表示することができません。
        ''' </summary>
        GroupMsg0002 = 1073002

        ''' <summary>
        ''' 選択した組織・グループの情報を表示することができません。
        ''' </summary>
        GroupMsg0003 = 1073003

        ''' <summary>
        ''' ドメインからグループを取得することができません。
        ''' </summary>
        GroupMsg0004 = 1073004

        ''' <summary>
        ''' 組織・グループの登録に失敗しました。
        ''' </summary>
        GroupMsg0005 = 1073005

        ''' <summary>
        ''' 組織の削除に失敗しました。
        ''' </summary>
        GroupMsg0006 = 1073006

        ''' <summary>
        ''' 個人登録画面の起動に失敗しました。
        ''' </summary>
        PersonMsg0001 = 1074001

        ''' <summary>
        ''' 個人一覧を表示することができません。
        ''' </summary>
        PersonMsg0002 = 1074002

        ''' <summary>
        ''' 個人登録画面の起動に失敗しました。
        ''' </summary>
        PersonMsg0003 = 1074003

        ''' <summary>
        ''' 個人の登録に失敗しました。
        ''' </summary>
        PersonMsg0004 = 1074004

        ''' <summary>
        ''' 個人の削除に失敗しました。
        ''' </summary>
        PersonMsg0005 = 1074005

        ''' <summary>
        ''' 役職登録画面の起動に失敗しました。
        ''' </summary>
        PositionMsg0001 = 1075001

        ''' <summary>
        ''' 役職を表示することができません。
        ''' </summary>
        PositionMsg0002 = 1075002

        ''' <summary>
        ''' 選択した役職の情報を表示することができません。
        ''' </summary>
        PositionMsg0003 = 1075003

        ''' <summary>
        ''' 役職の登録に失敗しました。
        ''' </summary>
        PositionMsg0004 = 1075004

        ''' <summary>
        ''' 役職の削除に失敗しました。
        ''' </summary>
        PositionMsg0005 = 1075005

        ''' <summary>
        ''' 代理者設定画面の起動に失敗しました。
        ''' </summary>
        ProxyMsg0001 = 1076001

        ''' <summary>
        ''' 組織・グループを表示することができません。
        ''' </summary>
        ProxyMsg0002 = 1076002

        ''' <summary>
        ''' 所属を表示することができません。
        ''' </summary>
        ProxyMsg0003 = 1076003

        ''' <summary>
        ''' 代理者設定画面を開くことができません。
        ''' </summary>
        ProxyMsg0004 = 1076004

        ''' <summary>
        ''' 所属の検索に失敗しました。
        ''' </summary>
        ProxyMsg0005 = 1076005

        ''' <summary>
        ''' 代理者を追加することができません。
        ''' </summary>
        ProxyMsg0006 = 1076006

        ''' <summary>
        ''' 代理者を削除することができません。
        ''' </summary>
        ProxyMsg0007 = 1076007

        ''' <summary>
        ''' 代理者の登録に失敗しました。
        ''' </summary>
        ProxyMsg0008 = 1076008

        ''' <summary>
        ''' 代理者情報を表示することができません。
        ''' </summary>
        ProxyMsg0009 = 1076009

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        ''' <summary>
        ''' データベースの接続に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DbConnectFailure = 1080001

        ''' <summary>
        ''' データ登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AddFailure = 1080002

        ''' <summary>
        ''' データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DelFailure = 1080003

        ''' <summary>
        ''' レジストリに書き込む権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        LackingAuthority = 1080004

        ''' <summary>
        ''' レジストリ情報が間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailure = 1080005

        ''' <summary>
        ''' {0}がレジストリ情報に不足しています。
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailureAt = 1080006

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' 組織情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 1090001

        ''' <summary>
        ''' 組織情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 1090002

        ''' <summary>
        ''' 社員情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 1090003

        ''' <summary>
        ''' 社員情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 1090004

        ''' <summary>
        ''' 単体ルート取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 1090005

        ''' <summary>
        ''' 単体ルート取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 1090006

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 1090007

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 1090008

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 1090009

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 1090010

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 1090011

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 1090012

        ''' <summary>
        ''' 登録処理でエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 1090013

        ''' <summary>
        ''' 更新処理でエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 1090014

        ''' <summary>
        ''' 予期せぬエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeEX00 = 1090015

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' 組織情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 1100001

        ''' <summary>
        ''' 組織情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 1100002

        ''' <summary>
        ''' 社員情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 1100003

        ''' <summary>
        ''' 社員情報が取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 1100004

        ''' <summary>
        ''' 単体ルート取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 1100005

        ''' <summary>
        ''' 単体ルート取得ができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 1100006

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 1100007

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 1100008

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 1100009

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 1100010

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 1100011

        ''' <summary>
        ''' 予期せぬエラーが発生しました。再度、作成しないて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 1100012

        ''' <summary>
        ''' 登録処理でエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 1100013

        ''' <summary>
        ''' 更新処理でエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 1100014

        ''' <summary>
        ''' データ登録に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' データ登録失敗汎用メッセージ
        ''' </remarks>
        FailedAdd = 1100015

        ''' <summary>
        ''' データ削除に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' 削除失敗汎用メッセージ
        ''' </remarks>
        FailedDelete = 1100016

        ''' <summary>
        ''' 組織改編履歴の取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' コンボボックスに格納する組織改編履歴データの取得に失敗
        ''' </remarks>
        FailedGetInnavationDate = 1100017

        ''' <summary>
        ''' カテゴリデータの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' カテゴリデータの作成に失敗
        ''' </remarks>
        FeiledGetCategory = 1100018

        ''' <summary>
        ''' データコピーに失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' データのコピーに失敗
        ''' </remarks>
        FailedCopy = 1100019

        ''' <summary>
        ''' 運用設定データの作成に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの作成に失敗
        ''' </remarks>
        FeiledAddFormDetaile = 1100020

        ''' <summary>
        ''' フォームの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの作成に失敗
        ''' </remarks>
        FeiledGetFormHeader = 1100021

        ''' <summary>
        ''' ルートの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの作成に失敗
        ''' </remarks>
        FeiledGetRouteHeader = 1100022

        ''' <summary>
        ''' 使用フォームのデータ割当に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の更新に失敗
        ''' </remarks>
        FeiledUpdateJoinForm = 1100023

        ''' <summary>
        ''' 使用ルートのデータ割当に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の更新に失敗
        ''' </remarks>
        FeiledUpdateJoinRoute = 1100024

        ''' <summary>
        ''' ビュー情報データの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの作成に失敗
        ''' </remarks>
        FeiledGetView = 1100025

        ''' <summary>
        ''' 採番項目データの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの作成に失敗
        ''' </remarks>
        FeiledGetDocumentNumber = 1100026

        ''' <summary>
        ''' システムエラーです。予期せぬエラーが発生しました。
        ''' </summary>
        ''' <remarks>
        ''' その他のシステムエラーに
        ''' </remarks>
        SystemUnKnownError = 1100027

        ''' <summary>
        ''' フォームを公開中の為、削除できませんでした。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定画面で、フォームを「◎公開する」に設定しているときは、
        ''' ルートフォーム画面から、削除チェックをする
        ''' </remarks>
        FailedNotDelete = 1100028

        ''' <summary>
        ''' 文書プロパティ情報登録に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' 登録ボタンクリックでRidoc文書プロパティ情報登録に失敗
        ''' </remarks>
        DocPropEntryFailed = 1100029

        ''' <summary>
        ''' 文書プロパティ情報登録用データ作成に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' 登録ボタンクリックでRidoc文書プロパティ情報登録用データ作成に失敗
        ''' </remarks>
        DocPropEntryDataFailed = 1100030

        ''' <summary>
        ''' 文書タイプ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' 文書タイプ一覧コンボ用のデータ取得に失敗
        ''' </remarks>
        GetDocPropListFailed = 1100031

        ''' <summary>
        ''' 文書プロパティ連携情報取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォームロード時に文書プロパティ・フォーム情報取得し、
        ''' ユーザーコントロール表示に失敗
        ''' </remarks>
        GetDataFailed = 1100032

        ''' <summary>
        ''' フォームデータ報取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォームロード時に文書プロパティ・フォーム情報取得し、
        ''' ユーザーコントロール表示に失敗
        ''' </remarks>
        GetFormDataFailed = 1100033

        ''' <summary>
        ''' キャビネット一覧情報取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' キャビネット一覧情報取得時の得エラー
        ''' </remarks>
        GetCabListFailed = 1100034

        ''' <summary>
        ''' システムエラーです。管理者に問い合わせて下さい。
        ''' </summary>
        ''' <remarks>
        ''' フォーム上のその他のエラー
        ''' </remarks>
        SystemError = 1100035

        ''' <summary>
        ''' 予期せぬエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeEX00 = 1100036

        ''' <summary>
        ''' 使用フォームの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の取得に失敗
        ''' </remarks>
        FeiledGetJoinForm = 1100037

        ''' <summary>
        ''' 使用ルートの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の取得に失敗
        ''' </remarks>
        FeiledGetJoinRoute = 1100038

        ''' <summary>
        ''' 使用ルート・フォームの割当データ削除に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の削除に失敗
        ''' </remarks>
        FeiledDeleteJoinData = 1100039

        ''' <summary>
        ''' 使用ルート・フォームの割当データ登録に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当データ(EGGA0007)の登録に失敗
        ''' </remarks>
        FeiledAddJoinData = 1100040

        ''' <summary>
        ''' 運用設定データの取得に失敗しました。
        ''' </summary>
        ''' <remarks>
        ''' フォーム詳細データの取得に失敗
        ''' </remarks>
        FeiledGetFormDetaile = 1100041

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 1110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 1120000

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' ACAB プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        '''アプリケーション実行中にエラーが発生しました。{0}管理者に問合せてください。
        ''' </summary>
        ''' <remarks></remarks>
        SytemError = 1140001

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' 連携処理失敗のメッセージ
        ''' </summary>
        Msg0001 = 1160001

        ''' <summary>
        ''' 復元処理失敗のメッセージ
        ''' </summary>
        Msg0002 = 1160002


    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter プロジェクトのエラーメッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''アプリケーション実行中にエラーが発生しました。{0}管理者に問合せてください。
        ''' </summary>
        ''' <remarks></remarks>
        SytemError = 1180001

    End Enum

#End Region
End Namespace


