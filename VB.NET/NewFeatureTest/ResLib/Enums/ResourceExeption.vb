Option Compare Binary
Option Explicit On
Option Strict On

Imports System

Namespace Exception
#Region " Common "

    ''' <summary>
    ''' MCOM プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        ''' カテゴリ拡張情報登録エラー
        ''' </summary>
        ''' <remarks></remarks>
        CategoryInsertError = 2010001

        ''' <summary>
        ''' 該当するデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        DataNothing = 2010002

    End Enum

#End Region

#Region " CEMV "

    ''' <summary>
    ''' CEMV プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [CENV]

        ''' <summary>
        ''' 該当するデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ExistDataNotFoundException = 2020001

        ''' <summary>
        ''' 該当する複数のデータが発見されました。
        ''' </summary>
        ''' <remarks></remarks>
        DuplicateDataFoundException = 2020002

        ''' <summary>
        ''' 永続化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2020003

        ''' <summary>
        ''' カテゴリの移動に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedMoveParentCategoryException = 2020004

        ''' <summary>
        ''' カテゴリの削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedRemoveCategoryException = 2020005

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2020006

        ''' <summary>
        ''' データの読込みに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2020007

        ''' <summary>
        ''' 新規インスタンスの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2020008

        ''' <summary>
        ''' レジストリに書き込む権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        LackingAuthority = 2020009

        ''' <summary>
        ''' レジストリ情報が間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        RegistryFailure = 2020010

        ''' <summary>
        ''' Rabit.Confが読み込めません。
        ''' </summary>
        ''' <remarks></remarks>
        NotReadRabitConf = 2020011

    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' RFLW プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        ''' <summary>
        ''' 必須項目に値が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        MustInputUnsatedException = 2030001

        ''' <summary>
        ''' アカウントがロックされました。
        ''' </summary>
        ''' <remarks></remarks>
        AccountLockException = 2030002

        ''' <summary>
        ''' 初回ログインです。
        ''' </summary>
        ''' <remarks></remarks>
        FirstLoginException = 2030003

        ''' <summary>
        ''' システム管理者によりパスワード変更の要求がありました。
        ''' </summary>
        ''' <remarks></remarks>
        ImpositionChangePasswordException = 2030004

        ''' <summary>
        ''' 設定したパスワードに数値が含まれていません。
        ''' </summary>
        ''' <remarks></remarks>
        NumberPasswordException = 2030005

        ''' <summary>
        ''' 設定したパスワードに記号が含まれいません。
        ''' </summary>
        ''' <remarks></remarks>
        MarkPasswordException = 2030006

        ''' <summary>
        ''' 設定したパスワードが英大小文字混在していません。
        ''' </summary>
        ''' <remarks></remarks>
        CapsPasswordException = 2030007

        ''' <summary>
        ''' 設定したパスワードにユーザＩＤが含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        UserIdPasswordException = 2030008

        ''' <summary>
        ''' 同一の文字が一定回数繰返されました。
        ''' </summary>
        ''' <remarks></remarks>
        RepeatStringPasswordException = 2030009

        ''' <summary>
        ''' 設定したパスワード長が最低桁数より小さい値です。
        ''' </summary>
        ''' <remarks></remarks>
        MinPasswordException = 2030010

        ''' <summary>
        ''' 設定したパスワード長が最大桁数より大きい値です。
        ''' </summary>
        ''' <remarks></remarks>
        MaxPasswordException = 2030011

        ''' <summary>
        ''' 設定したパスワードに禁則文字が含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        WrapPasswordException = 2030012

        ''' <summary>
        ''' 設定したパスワードが過去に使用されています。
        ''' </summary>
        ''' <remarks></remarks>
        HistoryPasswordException = 2030013

        ''' <summary>
        ''' パスワードの有効期限が切れました。
        ''' </summary>
        ''' <remarks></remarks>
        OutOfDateException = 2030014

        ''' <summary>
        ''' システムがサポートできる日付の範囲を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        InputDateOutOfRangeException = 2030015

        ''' <summary>
        ''' 正しい和暦が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianExFailedException = 2030016

        ''' <summary>
        ''' 入力桁が許容範囲を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        OverFlowException = 2030017

        ''' <summary>
        ''' 条件判断GUIコントロールでメッセージボックスが指定されました。
        ''' </summary>
        ''' <remarks></remarks>
        UserEstablishedMessageException = 2030018

        ''' <summary>
        ''' システムにより保存が中断されました。
        ''' </summary>
        ''' <remarks></remarks>
        StopSaveException = 2030019

        ''' <summary>
        ''' 開始日、終了日いずれかが未入力での登録はできません。
        ''' </summary>
        ''' <remarks></remarks>
        AnotherNonInputItemException = 2030020

        ''' <summary>
        ''' 開始日は終了日以前の日付を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateItemException = 2030021

        ''' <summary>
        ''' 開始日から終了日の範囲は{0}年未満にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemException = 2030022

        ''' <summary>
        ''' 設計時のパラメータが不完全です。
        ''' </summary>
        ''' <remarks></remarks>
        FieldParamIncompleteException = 2030023

        ''' <summary>
        ''' フィールドデータの取得に失敗しました
        ''' </summary>
        ''' <remarks></remarks>
        FieldValueGetException = 2030024

        ''' <summary>
        ''' フィールド情報の取得に失敗しました
        ''' </summary>
        ''' <remarks></remarks>
        FieldInfoGetException = 2030025

        ''' <summary>
        ''' ビューSQLが存在しません
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExistException = 2030026

        ''' <summary>
        ''' Typeプロパティに設定された値が適用されませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        TypePropUseException = 2030027

        ''' <summary>
        ''' DBGUI固有情報の設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DBGUISetException = 2030028

        ''' <summary>
        ''' レポートレイアウトファイルが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NonRPXFileException = 2030029

        ''' <summary>
        ''' 入力桁が許容範囲を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        Int32OverFlowException = 2030030

        ''' <summary>
        ''' 入力桁が許容範囲を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        DecimalOverFlowException = 2030031

        ''' <summary>
        ''' 印刷できるデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NonDataPrintException = 2030032

        ''' <summary>
        ''' 不正な数値です。
        ''' </summary>
        ''' <remarks></remarks>
        NumericErrorException = 2030033

        ''' <summary>
        ''' 入力された値は不正です。
        ''' </summary>
        ''' <remarks></remarks>
        ObliquityValueException = 2030034

    End Enum

#End Region

#Region " MEGG "

    ''' <summary>
    ''' MEGG プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MEGG]

        ''' <summary>
        ''' 文書階層データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        BbsDocLevelErrException = 2040001

        ''' <summary>
        ''' 返信ボタンの表示判断に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        BbsReplyDispErrException = 2040002

        ''' <summary>
        ''' このルートは使用できません。新規作成ボタンでルートを設定するか、管理者ツールで再定義する必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        CreateSnapShotFailedException = 2040003

        ''' <summary>
        ''' ルート単体が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        RoutingDataNotFindException = 2040004

        ''' <summary>
        ''' データの読込みに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2040005

        ''' <summary>
        ''' 申請者が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNUserNotFindException = 2040006

        ''' <summary>
        ''' 次の承認者が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NextNUserNotFindException = 2040007

        ''' <summary>
        ''' 前の承認者が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        PrevNUserNotFindException = 2040008

        ''' <summary>
        ''' フォーム詳細管理テーブルの更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedUpdateException = 2040009

        ''' <summary>
        ''' フォーム詳細管理テーブルの追加に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedInsertException = 2040010

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2040011

        ''' <summary>
        ''' ルートの一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteListNotFindException = 2040012

        ''' <summary>
        ''' ACLの一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ACLNotFindException = 2040013

        ''' <summary>
        ''' メール送信一覧の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        EntrySendMailListException = 2040014

        ''' <summary>
        ''' 結合ルート番号の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UninonRouteIDNotFindException = 2040015

        ''' <summary>
        ''' 承認者一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        NUserNotFindException = 2040016

        ''' <summary>
        ''' 検索条件の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SearchConditionCanNotMakeException = 2040017

        ''' <summary>
        ''' ビューデータ抽出SQLの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlCanNotMakeException = 2040018

        ''' <summary>
        ''' 新しい文書の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CreateDocumentFailedException = 2040019

        ''' <summary>
        ''' インデック情報登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocCreateIndexErrException = 2040020

        ''' <summary>
        ''' "インデック情報削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocDelIndexErrException = 2040021

        ''' <summary>
        ''' 永続化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2040022

        ''' <summary>
        ''' 連番が有効桁数を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        NumberOutOfRangeException = 2040023

        ''' <summary>
        ''' 指定した文書番号は既に使用されています。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicatedException = 2040024

        ''' <summary>
        ''' 指定されたカラムと変更値の属性が違います。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeErrException = 2040025

        ''' <summary>
        ''' 桁数オーバーです。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeOverException = 2040026

        ''' <summary>
        ''' 指定されたカラムが見つかりませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumNotFindException = 2040027

        ''' <summary>
        ''' 予期しないエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgAbnomalException = 2040028

        ''' <summary>
        ''' 受付担当者用の排他更新の処理を失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocLockUpdateException = 2040029

        ''' <summary>
        ''' 新規インスタンスの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2040030

        ''' <summary>
        ''' 結合ルート単体が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionRoutingDataNotFindException = 2040031

        ''' <summary>
        ''' 処理を実行する権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        PermissionDeniedException = 2040032

        ''' <summary>
        ''' 否認処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DenyFailedException = 2040033

        ''' <summary>
        ''' 文書が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNotFindException = 2040034

        ''' <summary>
        ''' 申請処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MakeFailedException = 2040035

        ''' <summary>
        ''' 審査処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptFailedException = 2040036

        ''' <summary>
        ''' 承認処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SubmitFailedException = 2040037

        ''' <summary>
        ''' 差戻し処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RemandFailedException = 2040038

        ''' <summary>
        ''' 更新設定の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetErrLumpUpdateItemSetException = 2040039

        ''' <summary>
        ''' 更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ErrLumpUpdateException = 2040040

        ''' <summary>
        ''' ルート情報の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MakeEggFailedException = 2040041

        ''' <summary>
        ''' 添付ファイル削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DelAddFileException = 2040042

        ''' <summary>
        ''' 添付ファイル追加に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InsAddFileException = 2040043

        ''' <summary>
        ''' ボタンの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MakeButtonFailedException = 2040044

        ''' <summary>
        ''' 登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveHolidayItemException = 2040045

        ''' <summary>
        ''' 文書ステータスが不正です。
        ''' </summary>
        ''' <remarks></remarks>
        InvalidStatusException = 2040046

        ''' <summary>
        ''' デフォルト所属IDの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DefaultSysBlgErrException = 2040047

        ''' <summary>
        ''' 条件分岐データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteTermsPointErrException = 2040048

        ''' <summary>
        ''' 申請者情報の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RequestDataNotException = 2040049

        ''' <summary>
        ''' 承認有効日の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        TdirectorDayErrException = 2040050

        ''' <summary>
        ''' メールの送信に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MailFailedException = 2040051

        ''' <summary>
        ''' 文書の一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentListNotFindException = 2040052

        ''' <summary>
        ''' 公開掲示板の判断に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocWfAndBbsErrException = 2040053

        ''' <summary>
        ''' 承認文書から投稿文書への更新が失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocWfAndBbsUpErrException = 2040054

        ''' <summary>
        ''' 参照権チェック処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PermissionCheckFailedException = 2040055

        ''' <summary>
        ''' 管理者モードの判断に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        WfAdminErrException = 2040056

        ''' <summary>
        ''' アセンブリのメソッド呼出しに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InvokeAbortException = 2040057

        ''' <summary>
        ''' 文書情報の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentDataNotFindException = 2040058

        ''' <summary>
        ''' 共通文書の最終更新日が取得できませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        ErrLumpGetLastUpdateException = 2040059

        ''' <summary>
        ''' デフォルト所属設定の処理を失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DefSysBlgUpdateException = 2040060

        ''' <summary>
        ''' 飛び越し承認判断処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocJumpErrException = 2040061

        ''' <summary>
        ''' 条件分岐のデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ConditionNotFindException = 2040062

        ''' <summary>
        ''' 投稿処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ContributionFailedException = 2040063

        ''' <summary>
        ''' 一括承認処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PackageAcceptFailedException = 2040064

        ''' <summary>
        ''' 一括差戻し処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PackageRemandFailedException = 2040065

        ''' <summary>
        ''' ルート番号の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteIDNotFindException = 2040066

        ''' <summary>
        ''' 結合ルートの一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UninonRouteListNotFindException = 2040067

        ''' <summary>
        ''' ベースクラスでリバイブに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        BaseClassReviveFailedException = 2040068

        ''' <summary>
        ''' ワークフロー上にユーザが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NUserNotFindOnRouteException = 2040069

        ''' <summary>
        ''' カレント承認者の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CurrentNUserNotFindException = 2040070

        ''' <summary>
        ''' ルートの再作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteRemakeFailedException = 2040071

        ''' <summary>
        ''' 指定された文書ＩＤが不正です。
        ''' </summary>
        ''' <remarks></remarks>
        DirtyDocumentSeedException = 2040072

        ''' <summary>
        ''' 割込み修正完了処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CutintoOnFailedException = 2040073

    End Enum

#End Region

#Region " MFRM "

    ''' <summary>
    ''' MFRM プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MFRM]

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2050001

        ''' <summary>
        ''' データの読込みに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataNotReadException = 2050002

        ''' <summary>
        ''' 新規インスタンスの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InstanceCanNotMakeException = 2050003

        ''' <summary>
        ''' 永続化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SyncFailedException = 2050004

        ''' <summary>
        ''' ビューＳＱＬ情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        EntryViewSqlFailedException = 2050005

        ''' <summary>
        ''' フォーム項目が削除されています。{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        DataNothingException = 2050006

        ''' <summary>
        ''' ビュー項目グループ化情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewGroupInfoSyncFailedException = 2050007

        ''' <summary>
        ''' ビューフォーム連結キー情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewJoinKeySyncFailedException = 2050008

        ''' <summary>
        ''' ビュー絞込みブロック情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineBlockSyncFailedException = 2050009

        ''' <summary>
        ''' ビュー絞込み項目情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineItemSyncFailedException = 2050010

        ''' <summary>
        ''' 結合ビュー属性関連情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAttrInfoSyncFailedException = 2050011

        ''' <summary>
        ''' 結合ビュー項目情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemInfoSyncFailedException = 2050012

        ''' <summary>
        ''' ビューサブアプリ情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewSubAppSyncFailedException = 2050013

        ''' <summary>
        ''' 文書がシステムで保持できるサイズを超えています。
        ''' </summary>
        ''' <remarks></remarks>
        RecordSizeOutOfRangeException = 2050014

        ''' <summary>
        ''' 文書がシステムで保持できる項目数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        FieldCountOutOfRangeException = 2050015

        ''' <summary>
        ''' フォームにワークフロー項目名もしくは重複した項目名を付ける事はできません。
        ''' </summary>
        ''' <remarks></remarks>
        FieldNameRepeatedException = 2050016

        ''' <summary>
        ''' フォームから削除された項目がビューで使用されています。ビューエディタで修正してください。
        ''' </summary>
        ''' <remarks></remarks>
        CheckViewSQLErrorException = 2050017

        ''' <summary>
        ''' ビューの設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewSetException = 2050018

        ''' <summary>
        ''' 指定されたフォームＩＤのデータが存在しません。{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        FormNotFoundException = 2050019

        ''' <summary>
        ''' 指定されたフォーム項目ＩＤのデータが存在しません。{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        FieldNotFoundException = 2050020

        ''' <summary>
        ''' ビュー絞込み条件情報の登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ViewRefineCondSyncFailedException = 2050021

        ''' <summary>
        ''' 予約語のパラメータに数値以外の値が設定されています。{0}
        ''' </summary>
        ''' <remarks></remarks>
        ReservedWordArgumentException = 2050022

        ''' <summary>
        ''' {0}の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FormDataNotReadException = 2050023

        ''' <summary>
        '''コピー先フォームが存在しません。{0}
        ''' </summary>
        ''' <remarks></remarks>
        CopyFormNotExist = 2050024

        ''' <summary>
        '''コピー先フォームが複数存在します。{0}
        ''' </summary>
        ''' <remarks></remarks>
        MultiCopyFormExisted = 2050025

        ''' <summary>
        '''システム項目名称の取得に失敗しました。{0}
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemFieldNameFailed = 2050026

        ''' <summary>
        '''項目IDの取得に失敗しました。{0}
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldIdFailed = 2050027

        ''' <summary>
        '''生成されるSQL文が正常に動作しませんでした。\n[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        SqlError = 2050028

        ''' <summary>
        '''結合されているビューのビューSQL情報が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewSqlError = 2050029

        ''' <summary>
        '''該当のブロック情報が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewBlockError = 2050030

        ''' <summary>
        '''ビュー絞込み項目の式の値が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewTPFormulaError = 2050031

        ''' <summary>
        '''結合されているビューの情報が存在しません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoNotExist = 2050032

        ''' <summary>
        '''設定されている結合ビュー項目情報が異常です。表示順=[{0}]のデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ViewSortDataNotExist = 2050033

        ''' <summary>
        '''設定されている結合ビューグループ項目情報が異常です。表示順=[{0}]のデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ViewGroupSortDataNotExist = 2050034

        ''' <summary>
        '''指定されたフォームＩＤのデータが存在しません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExist = 2050035

        ''' <summary>
        '''指定されたＧＵＩＩＤのデータが存在しません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        GuiidDataNotExist = 2050036

        ''' <summary>
        '''有効なRESフォームが複数存在します。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        MultiRESFormExisted = 2050037

        ''' <summary>
        '''選択されたGUIの詳細情報が取得できませんでした。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        GetGuiInfoFailed = 2050038


    End Enum

#End Region

#Region " MJNJ "

    ''' <summary>
    ''' MJNJ プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MJNJ]

        ''' <summary>
        ''' リストからのデータ格納に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SetDataFailedException = 2060001

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2060002

        ''' <summary>
        ''' キー情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetSeedFailedException = 2060003

        ''' <summary>
        ''' 新規インスタンスを作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InstanceFailedException = 2060004

        ''' <summary>
        ''' リストからのデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetDataFailedException = 2060005

        ''' <summary>
        ''' ＳＱＬ構文の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SqlSyntaxException = 2060006

        ''' <summary>
        ''' Ｗｅｂ用クラスへの変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ConvertFlowItemException = 2060007

        ''' <summary>
        ''' 所属データ取得時の変換処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffBreakInfoException = 2060008

        ''' <summary>
        ''' 所属データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemUserException = 2060009

        ''' <summary>
        ''' ルート存在チェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteCheckedExistenceExceptin = 2060010

        ''' <summary>
        ''' Listプロパティデータの初期化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InitPropertyException = 2060011

        ''' <summary>
        ''' 所属データのツリーノード登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserSelectedNodeException = 2060012

        ''' <summary>
        ''' 所属データのツリーノード更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserAddedNodeException = 2060013

        ''' <summary>
        ''' 所属データのツリーノード削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SystemUserRemoveedNodeException = 2060014

        ''' <summary>
        ''' ツリーノードから所属データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetSystemUserItemFromNodeException = 2060015

        ''' <summary>
        ''' 権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNoAuthorityException = 2060016

        ''' <summary>
        ''' 個人一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetUserListException = 2061001

        ''' <summary>
        ''' 個人データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UserInsertException = 2061002

        ''' <summary>
        ''' 個人データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UserUpdateException = 2061003

        ''' <summary>
        ''' 個人データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UserDeleteException = 2061004

        ''' <summary>
        ''' ログインＩＤのチェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        LoginIdException = 2061005

        ''' <summary>
        ''' 個人データと所属データの関連付けに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UserNodeNotConnectedException = 2061006

        ''' <summary>
        ''' 所属データ格納に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffStorageFailedException = 2061007

        ''' <summary>
        ''' 文書の存在チェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentCheckedExistenceExcepton = 2061008

        ''' <summary>
        ''' 所属データの関連付けに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        LinkedAffiliationException = 2061009

        ''' <summary>
        ''' 所属一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetAffiliationListException = 2061010

        ''' <summary>
        ''' 関連する所属データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetAffiliationException = 2061011

        ''' <summary>
        ''' 所属データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationInsertException = 2061012

        ''' <summary>
        ''' 所属データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationUpdateException = 2061013

        ''' <summary>
        ''' 所属データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationDeleteException = 2061014

        ''' <summary>
        ''' ツリーノードから代理者データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputySelectedNodeException = 2061015

        ''' <summary>
        ''' 代理者データのツリーノード登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputyAddedNodeException = 2061016

        ''' <summary>
        ''' 代理者データのツリーノード削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputyRemovedNodeException = 2061017

        ''' <summary>
        ''' 組織一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetGroupListException = 2062001

        ''' <summary>
        ''' 組織データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupInsertException = 2062002

        ''' <summary>
        ''' 組織データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupUpdateException = 2062003

        ''' <summary>
        ''' 組織データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupDeleteException = 2062004

        ''' <summary>
        ''' 組織データと所属データの関連付けに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupNodeNotConnectedException = 2062005

        ''' <summary>
        ''' グループクラスへの変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ConvertGroupException = 2062006

        ''' <summary>
        ''' 同一階層検索に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SameLevelSearchException = 2062007

        ''' <summary>
        ''' 組織図の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        OrgTreeNotCreatedException = 2062008

        ''' <summary>
        ''' グループ図の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GrpTreeNotCreatedException = 2062009

        ''' <summary>
        ''' ＡＣＬ図の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AclTreeNotCreatedException = 2062010

        ''' <summary>
        ''' 略称フルパスの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ShortNameFullException = 2062011

        ''' <summary>
        ''' グループＩＤの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupIdNotObtainedException = 2062012

        ''' <summary>
        ''' 英字フルパスの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        EnglishNameFullException = 2062013

        ''' <summary>
        ''' 該当グループから下の個人情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AllMemberOfGroupException = 2062014

        ''' <summary>
        ''' 所属データ存在チェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        AffiliationCheckedExistenceExcepton = 2062015

        ''' <summary>
        ''' 所属データからのグループと役職情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GrpAndPosNotObtainedException = 2062016

        ''' <summary>
        ''' 子ノード作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChildNodeNotCreatedException = 2062017

        ''' <summary>
        ''' 利用可能グループ一覧用バッファテーブル作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        UseGroupDatasetNotCreatedException = 2062018

        ''' <summary>
        ''' アドレス一覧用バッファテーブル作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MailDatasetNotCreatedException = 2062019

        ''' <summary>
        ''' 削除一括一覧用バッファテーブル作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeleteGroupDatasetNotCreatedException = 2062020

        ''' <summary>
        ''' 同一階層情報[ルート]取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CheckLevelDataException = 2062021

        ''' <summary>
        ''' 組織一括削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupTruncateException = 2062022

        ''' <summary>
        ''' 組織コード取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GroupCodeNotObtainedException = 2062023

        ''' <summary>
        ''' 役職一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetPositionListException = 2063001

        ''' <summary>
        ''' 役職データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PositionInsertException = 2063002

        ''' <summary>
        ''' 役職データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PositionUpdateException = 2063003

        ''' <summary>
        ''' 役職データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PositionDeleteException = 2063004

        ''' <summary>
        ''' 子ノード作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChildPositionNodeMakeFailedException = 2063005

        ''' <summary>
        ''' 役職図の作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PositionTreeNotCreatedException = 2063006

        ''' <summary>
        ''' 役職コード取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        PositionCodeNotObtainedException = 2063007

        ''' <summary>
        ''' 代理者一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetDeputyListException = 2064001

        ''' <summary>
        ''' 代理者データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputyInsertException = 2064002

        ''' <summary>
        ''' 代理者データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputyUpdateException = 2064003

        ''' <summary>
        ''' 代理者データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DeputyDeleteException = 2064004

        ''' <summary>
        ''' 代理者の有効期間が代理者当人の所属期間を越えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverRangeBelongException = 2065001

        ''' <summary>
        ''' 所属ＩＤからの個人データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserException = 2065002

        ''' <summary>
        ''' グループが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotExistGroupException = 2065003

        ''' <summary>
        ''' 該当グループから下の個人情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetAllMemberInfoFromGroupException = 2065004

        ''' <summary>
        ''' 該当データが見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNoDataException = 2065005

        ''' <summary>
        ''' ログインに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedLoginException = 2065006

        ''' <summary>
        ''' 組織改編処理が完了しない状態で改編日を迎えているため、ログインできません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorDateInReorganizationException = 2065007

        ''' <summary>
        ''' パスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorUnlikePasswordException = 2065008

        ''' <summary>
        ''' 本務が複数があります。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorManyMainException = 2065009

        ''' <summary>
        ''' 所属がありません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotBelongException = 2065010

        ''' <summary>
        ''' 本務がありません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorNotMainException = 2065011

        ''' <summary>
        ''' ログインチェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedCheckLoginUserException = 2065012

        ''' <summary>
        ''' ユーザーＩＤからの個人データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserByPersonException = 2065013

        ''' <summary>
        ''' 個人の所属一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetMyPositionException = 2065014

        ''' <summary>
        ''' 所属の代理者一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetMyDeputyException = 2065015

        ''' <summary>
        ''' 下位層グループ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWGroupListException = 2065016

        ''' <summary>
        ''' 上位グループ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetParentNFLOWGroupListException = 2065017

        ''' <summary>
        ''' カテゴリＩＤからのグループ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetCategoryNFLOWGroupListException = 2065018

        ''' <summary>
        ''' カテゴリ一覧取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetCategoryListException = 2065019

        ''' <summary>
        ''' 利用可能グループ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetUsefulGroupException = 2065020

        ''' <summary>
        ''' グループＩＤと役職ＩＤからの組織情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWGroupFromPositionException = 2065021

        ''' <summary>
        ''' グループＩＤと役職ＩＤからの所属情報取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetNFLOWUserListByGPException = 2065022

        ''' <summary>
        ''' パスワード更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedSetUserPasswordException = 2065023

        ''' <summary>
        ''' 改編履歴データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedInnovationDateException = 2065024

        ''' <summary>
        ''' ＡＤ認証に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCertifyActiveDirectryException = 2065025

        ''' <summary>
        ''' ローカルログインできるのは管理者だけです。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorLoginOnlyAdministratorException = 2065026

        ''' <summary>
        ''' R@bitFlow クライアントでは『WFAdmin』でのログインはできません。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorCannotLoginAdministratorException = 2065027

        ''' <summary>
        ''' ファイルが現在使用中です。
        ''' </summary>
        ''' <remarks></remarks>
        FileUsedException = 2069001

        ''' <summary>
        ''' 変換対象ファイルが見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        FileNotFoundException = 2069002

        ''' <summary>
        ''' ファイルフォーマットが不正です。
        ''' </summary>
        ''' <remarks></remarks>
        FileFormatUncorrectException = 2069003

        ''' <summary>
        ''' 変換対象ディレクトリが見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        DirectoryNotFoundException = 2069004

        ''' <summary>
        ''' 履歴データのプロパティセットに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationPropertyException = 2069005

        ''' <summary>
        ''' 履歴データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetReorganizationException = 2069006

        ''' <summary>
        ''' 履歴データの更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationUpdateException = 2069007

        ''' <summary>
        ''' 不整合データ削除処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SweepTrashFailedException = 2069008

        ''' <summary>
        ''' ルート関連終了処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReorganizationRouteConnectedException = 2069009

        ''' <summary>
        ''' 個人関連不正一覧取得処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        WrongUserException = 2069010

        ''' <summary>
        ''' ルート関連開始処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        StartRouteConnecedException = 2069011

        ''' <summary>
        ''' ルートコンバート処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        RouteConvertFailedException = 2069012

        ''' <summary>
        ''' 組織関連開始処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        StartOrganizationConnectedException = 2069013

        ''' <summary>
        ''' 組織関連コンバート処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        OrganizationConvertFailedException = 2069014

        ''' <summary>
        ''' 個人関連開始処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        StartMemberConnectedException = 2069015

        ''' <summary>
        ''' 個人関連終了処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FinishMemberConnectedException = 2069016

        ''' <summary>
        ''' 履歴一覧のデータ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        GetInnovationListException = 2069017

        ''' <summary>
        ''' 履歴データ新規登録に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InnovationInsertException = 2069018

        ''' <summary>
        ''' 履歴データ更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InnovationUpdateException = 2069019

        ''' <summary>
        ''' 履歴データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        InnovationDeleteException = 2069020

        ''' <summary>
        ''' 只今、組織改編中です。
        ''' </summary>
        ''' <remarks></remarks>
        EditingOrganizationNowException = 2069021

        ''' <summary>
        ''' 一意制約違反です。
        ''' {0}には重複した値を挿入することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        ViolatedUniqueConstraintException = 2069022

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' ルートの一覧の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetFormListException = 2070001

        ''' <summary>
        ''' フォームの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormeHeaderException = 2070002

        ''' <summary>
        ''' ルートの詳細データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetRouteHeaderException = 2070003

        ''' <summary>
        ''' ツリーの作成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledCreateTreeNodeException = 2070004

        ''' <summary>
        ''' 使用ルートの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinRouteException = 2070005

        ''' <summary>
        ''' 使用フォームの割当データ取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetJoinFormException = 2070006

        ''' <summary>
        ''' 運用設定データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledGetFormDetaileException = 2070007

        ''' <summary>
        ''' 運用設定データの取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddFormDetaileException = 2070008

        ''' <summary>
        ''' ルートの一覧の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FailedGetRouteListException = 2070009

        ''' <summary>
        ''' 使用ルート・フォームの割当データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledDeleteJoinDataException = 2070010

        ''' <summary>
        ''' 使用ルート・フォームの割当データ削除に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        FeiledAddJoinDataException = 2070011



        ''' <summary>
        ''' 生成されるSQL文が正常に動作しませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        SqlError = 2070012

        ''' <summary>
        ''' 入力文字は数字のみ有効です。
        ''' </summary>
        ''' <remarks></remarks>
        TypeErrorNumber = 2070013

        ''' <summary>
        ''' 表示項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorView = 2070014

        ''' <summary>
        ''' グループ項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorGroup = 2070015

        ''' <summary>
        ''' 条件項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectErrorCondition = 2070016

        ''' <summary>
        ''' 結合リセット対象のビュー項目情報が存在しません。[{0}][{1}][{2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC001 = 2070017

        ''' <summary>
        ''' 結合リセット対象のビューグループ項目情報が存在しません。[{0}][{1}][{2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC002 = 2070018

        ''' <summary>
        ''' 選択されたGUIの詳細情報が取得できませんでした。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC003 = 2070019

        ''' <summary>
        ''' デフォルトビューのＳＱＬ文生成に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC004 = 2070020

        ''' <summary>
        ''' デフォルトビューの設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        routeC005 = 2070021

        ''' <summary>
        ''' {0}：パラメータ異常[{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC006 = 2070022

        ''' <summary>
        ''' 選択された項目が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC007 = 2070023

        ''' <summary>
        ''' 選択されたGUIの詳細情報が取得できませんでした。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC008 = 2070024

        ''' <summary>
        ''' 結合対象のビュー項目情報が存在しません。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC009 = 2070025

        ''' <summary>
        ''' 連結タイプが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC010 = 2070026

        ''' <summary>
        ''' 選択されたGUIの詳細情報が取得できませんでした。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC011 = 2070027

        ''' <summary>
        ''' 選択された結合ビュー項目に設定されている値が異常です！[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC012 = 2070028

        ''' <summary>
        ''' 選択された結合ビュー項目（グループ化）に設定されている値が異常です！[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC013 = 2070029

        ''' <summary>
        ''' 結合ビュー項目選択異常！[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC014 = 2070030

        ''' <summary>
        ''' 結合対象ビュー制御エラー[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC015 = 2070031

        ''' <summary>
        ''' 結合対象ビューの値が不正です。
        ''' </summary>
        ''' <remarks></remarks>
        routeC016 = 2070032

        ''' <summary>
        ''' 表示名が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC017 = 2070033

        ''' <summary>
        ''' 選択された表示名は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeC018 = 2070034

        ''' <summary>
        ''' ビューサブアプリマスター情報が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC019 = 2070035

        ''' <summary>
        ''' 対象のRES情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC020 = 2070036

        ''' <summary>
        ''' 削除対象の項目一括更新項目が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC021 = 2070037

        ''' <summary>
        ''' 下位層に条件やブロックが存在しているものは削除することができません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC022 = 2070038

        ''' <summary>
        ''' 移動先が指定されませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        routeC023 = 2070039

        ''' <summary>
        ''' 同一階層で移動することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC024 = 2070040

        ''' <summary>
        ''' 移動先に同じブロックを指定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC025 = 2070041

        ''' <summary>
        ''' 移動先はブロックでなければなりません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC026 = 2070042

        ''' <summary>
        ''' 移動先に、移動させる項目の下位層を指定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeC027 = 2070043

        ''' <summary>
        ''' プロパティの入力に違があります。
        ''' </summary>
        ''' <remarks></remarks>
        routeC028 = 2070044

        ''' <summary>
        ''' {0}～{1}の間で設定してください。
        ''' </summary>
        ''' <remarks></remarks>
        routeC029 = 2070045

        ''' <summary>
        ''' 結合項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        routeC030 = 2070046

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 2070047

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        '''メインフォーム情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormInfoException = 2080001

        ''' <summary>
        '''メインフォーム項目情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormFieldInfoException = 2080002

        ''' <summary>
        '''指定されたビューの情報が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoException = 2080003

        ''' <summary>
        '''指定されたビューの項目情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewFieldInfoException = 2080004

        ''' <summary>
        '''ビューSQLが存在しません
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExisted = 2080005

        ''' <summary>
        '''DBGUI固有情報の設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SetDBGUIFailed = 2080006

        ''' <summary>
        '''指定されたフォームＩＤのデータが存在しません。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExisted = 2080007

        ''' <summary>
        '''フィールド情報の取得に失敗しました
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldInfoFailed = 2080008

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' まいと～くFAXに接続できませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        MFConnect = 2090001

        ''' <summary>
        ''' まいと～くFAXで送信先の初期化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFClearSendFax = 2090002


        ''' <summary>
        ''' まいと～くFAXで保存先の設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFSaveAs = 2090003

        ''' <summary>
        ''' まいと～くFAXでMFS変換処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFPrint = 2090004

        ''' <summary>
        ''' まいと～くFAXで送信先情報の設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFSendToV4 = 2090005

        ''' <summary>
        ''' まいと～くFAXで送付状の初期化、または設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFCoverPage = 2090006

        ''' <summary>
        ''' まいと～くFAXで送信データの設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFFaxFile = 2090007

        ''' <summary>
        ''' まいと～くFAXで送信処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFSendFaxExecute = 2090008

        ''' <summary>
        ''' まいと～くFAXで採番される受付番号が最大値を超過しました。
        ''' </summary>
        ''' <remarks></remarks>
        MFReceiptNumberOverflow = 2090009

        ''' <summary>
        ''' 文書の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFGetDoc = 2090010

        ''' <summary>
        ''' 送信ログの書き込みに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFUpdateLog = 2090011

        ''' <summary>
        ''' プリンタの設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFSetPrinter = 2090012

        ''' <summary>
        ''' 送信先情報の取得に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFSendData = 2090013

        ''' <summary>
        ''' メールの送信に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFSendMail = 2090014

        ''' <summary>
        ''' 結果未取得データの未確認ステータス化に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        VFUpdateUnConfirmedStatus = 2090015

    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]

        ''' <summary>
        ''' プロパティの入力に違があります。
        ''' </summary>
        ''' <remarks></remarks>
        PropertyInputError = 2100001

    End Enum

#End Region

#Region " MCAB "

    ''' <summary>
    ''' R@bitFlow TextConverter MCAB プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MCAB]

        ''' <summary>
        ''' 予期せぬ例外です。
        ''' </summary>
        ''' <remarks></remarks>
        UnkouwnException = 2110001

        ''' <summary>
        ''' ログの出力先が不明です。
        ''' </summary>
        ''' <remarks></remarks>
        UnknownLogDevice = 2110002

        ''' <summary>
        ''' '{0}'が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        XMLNotFoundException = 2110003

        ''' <summary>
        ''' CSVファイル以外の移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotCSVTransException = 2110004

        ''' <summary>
        ''' フィールドIDがセットされていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnSetIDFieldException = 2110005

        ''' <summary>
        ''' 制約の実行種別が不明です。
        ''' </summary>
        ''' <remarks></remarks>
        UnknownActivateTypeException = 2110006

        ''' <summary>
        ''' 制約マスターがユニークではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueRestrictionException = 2110007

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 2110008

        ''' <summary>
        ''' 定義ファイルが変更されています。
        ''' </summary>
        ''' <remarks></remarks>
        ChildXMLChangedException = 2110009

        ''' <summary>
        ''' スレッドが終了できません。
        ''' </summary>
        ''' <remarks></remarks>
        ThreadIsAliveException = 2110010

        ''' <summary>
        ''' 一時データのIDDOCがユニークではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueLocalIddocException = 2110011

        ''' <summary>
        ''' 取込可能なGUIではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSupportGUIException = 2110012

        ''' <summary>
        ''' 指定した番号に該当する R@bitFlow サーバーが見つかりませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        RabitFlowServerNotFoundException = 2110013

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' R@bitFlow TextConverter ACAB プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        ''' 最大文字数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 2120001

        ''' <summary>
        ''' 数値変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 2120002

        ''' <summary>
        ''' 数値変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 2120003

        ''' <summary>
        ''' 整数/金額変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 2120004

        ''' <summary>
        ''' 日付変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 2120005

        ''' <summary>
        ''' 日付フォーマットチェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 2120006

        ''' <summary>
        ''' 有効日付チェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 2120007

        ''' <summary>
        ''' 画面のキャンセルが選択されました。
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 2120008

        ''' <summary>
        ''' 文字列変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 2120009

        ''' <summary>
        ''' ログインしているサーバと異なるサーバへの移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 2120010

        ''' <summary>
        ''' 移行種別が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 2120011

        ''' <summary>
        ''' 移行元サーバが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 2120012

        ''' <summary>
        ''' 移行元ファイル名が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 2120013

        ''' <summary>
        ''' 移行元ファイルパスが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 2120014

        ''' <summary>
        ''' 移行先サーバーが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 2120015

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 2120016

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 2120017

        ''' <summary>
        ''' 移行先フォームが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 2120018

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 2120019

        ''' <summary>
        ''' 移行先フォームが、掲示板または公開掲示板ではありません。
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 2120020

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConveter プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' 環境設定値が見つからない場合のメッセージ。
        ''' </summary>
        Msg0001 = 2130001

        ''' <summary>
        ''' 連携オプションが見つからない場合のメッセージ。
        ''' </summary>
        Msg0002 = 2130002

        ''' <summary>
        ''' 連携処理が現在実行中の場合のメッセージ。
        ''' </summary>
        Msg0003 = 2130003

        ''' <summary>
        ''' 連携処理がロックされている場合のメッセージ。
        ''' </summary>
        Msg0004 = 2130004

        ''' <summary>
        ''' データベースのバックアップに失敗した場合のメッセージ。
        ''' </summary>
        Msg0005 = 2130005

        ''' <summary>
        ''' 作業用トランザクションへのデータコピーに失敗した場合のメッセージ。
        ''' </summary>
        Msg0006 = 2130006

        ''' <summary>
        ''' 一時データの作成に失敗した場合のメッセージ。
        ''' </summary>
        Msg0007 = 2130007

        ''' <summary>
        ''' データのマージに失敗した場合のメッセージ。
        ''' </summary>
        Msg0008 = 2130008

        ''' <summary>
        ''' テーブルのリネームに失敗した場合のメッセージ。
        ''' </summary>
        Msg0009 = 2130009

        ''' <summary>
        ''' 人事データのリストアに失敗した場合のメッセージ。
        ''' </summary>
        Msg0010 = 2130010

        ''' <summary>
        ''' 連携ファイルが見つからなかった場合のメッセージ。
        ''' </summary>
        Msg0011 = 2130011

        ''' <summary>
        ''' 連携ファイルにレコードが存在しない場合のメッセージ。
        ''' </summary>
        Msg0012 = 2130012

        ''' <summary>
        ''' 必須項目に値が設定されていない場合のメッセージ。
        ''' </summary>
        Msg0013 = 2130013

        ''' <summary>
        ''' 人事データの復元処理が現在実行中の場合のメッセージ。
        ''' </summary>
        Msg0014 = 2130014

        ''' <summary>
        ''' 値がフラグとして扱えない場合のメッセージ。
        ''' </summary>
        Msg0015 = 2130015

        ''' <summary>
        ''' 許可されていないコードが指定された場合のメッセージ。
        ''' </summary>
        Msg0016 = 2130016

        ''' <summary>
        ''' 一意制約に違反した場合のメッセージ。
        ''' </summary>
        Msg0017 = 2130017

        ''' <summary>
        ''' クラスインスタンスを復活させるためのレコードが存在しなかった場合のメッセージ。
        ''' </summary>
        Msg0018 = 2130018

        ''' <summary>
        ''' クラスインスタンスを復活させるためのレコードが複数存在する場合のメッセージ。
        ''' </summary>
        Msg0019 = 2130019

        ''' <summary>
        ''' 上位組織が変更された場合のメッセージ。
        ''' </summary>
        Msg0020 = 2130020

        ''' <summary>
        ''' 所属が存在するのに組織・グループ種別を変更しようとした場合のメッセージ。
        ''' </summary>
        Msg0021 = 2130021

        ''' <summary>
        ''' 配下に組織が存在するのに、組織・グループ種別を変更しようとした場合のメッセージ。
        ''' </summary>
        Msg0022 = 2130022

        ''' <summary>
        ''' 所属登録時に該当するリソースが存在しない場合のメッセージ。
        ''' </summary>
        Msg0023 = 2130023

        ''' <summary>
        ''' 上位組織が存在しない場合のメッセージ。
        ''' </summary>
        Msg0024 = 2130024

        ''' <summary>
        ''' 登録しようとしている人事データの有効期間が重複した場合のメッセージ。
        ''' </summary>
        Msg0025 = 2130025

        ''' <summary>
        ''' 個人以外の無効なデータを登録しようとした場合のメッセージ。
        ''' </summary>
        Msg0026 = 2130026

        ''' <summary>
        ''' 個人の無効なデータを登録しようとした場合のメッセージ。
        ''' </summary>
        Msg0027 = 2130027

        ''' <summary>
        ''' 個人以外の期限切れのデータを登録しようとした場合のメッセージ。
        ''' </summary>
        Msg0028 = 2130028

        ''' <summary>
        ''' 期限切れの個人データを登録しようとした場合のメッセージ。
        ''' </summary>
        Msg0029 = 2130029

        ''' <summary>
        ''' 送信元管理者メールアドレスが見つからなかった場合のメッセージ。
        ''' </summary>
        Msg0030 = 2130030

        ''' <summary>
        ''' 受信元管理者メールアドレスが見つからなかった場合のメッセージ。
        ''' </summary>
        Msg0031 = 2130031

        ''' <summary>
        ''' 詳細設定が見つからない場合のメッセージ。
        ''' </summary>
        Msg0032 = 2130032

        ''' <summary>
        ''' 上位組織が見つからなかった場合のメッセージ。
        ''' </summary>
        Msg0033 = 2130033

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter プロジェクトの例外メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        '''' <summary>
        '''' テンプレートのため後で削除してください。
        '''' </summary>
        'Tmp = 2140001

        ''' <summary>
        ''' 最大文字数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 2140001

        ''' <summary>
        ''' 数値変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 2140002

        ''' <summary>
        ''' 数値変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 2140003

        ''' <summary>
        ''' 整数/金額変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 2140004

        ''' <summary>
        ''' 日付変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 2140005

        ''' <summary>
        ''' 日付フォーマットチェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 2140006

        ''' <summary>
        ''' 有効日付チェックに失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 2140007

        ''' <summary>
        ''' 画面のキャンセルが選択されました。
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 2140008

        ''' <summary>
        ''' 文字列変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 2140009

        ''' <summary>
        ''' ログインしているサーバと異なるサーバへの移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 2140010

        ''' <summary>
        ''' 移行種別が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 2140011

        ''' <summary>
        ''' 移行元サーバが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 2140012

        ''' <summary>
        ''' 移行元ファイル名が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 2140013

        ''' <summary>
        ''' 移行元ファイルパスが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 2140014

        ''' <summary>
        ''' 移行先サーバーが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 2140015

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 2140016

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 2140017

        ''' <summary>
        ''' 移行先フォームが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 2140018

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 2140019

        ''' <summary>
        ''' 移行先フォームが、掲示板または公開掲示板ではありません。
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 2140020

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        EmptyException = 2140021

        ''' <summary>
        ''' ユーザーIDまたはパスワードが間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        UserIdOrPwdError = 2140022

    End Enum

#End Region

End Namespace

