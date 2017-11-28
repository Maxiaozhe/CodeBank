Option Compare Binary
Option Explicit On
Option Strict On

Imports System

'
' 警告
'
Namespace Exclamation
#Region " Common "

    ''' <summary>
    ''' アプリケーション共通の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [Common]

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3010001

        ''' <summary>
        ''' 人事情報を取り込み中のため、現在 R@bitFlow を利用することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        CoordinationWithPersonnel = 3010002

        ''' <summary>
        ''' 条件を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        ConditionError = 3010003

        ''' <summary>
        ''' 項目{0}は既に削除されました。
        ''' </summary>
        ''' <remarks></remarks>
        DeletedCondition = 3010004

        ''' <summary>
        ''' 削除した項目が存在しています。
        ''' </summary>
        ''' <remarks></remarks>
        DeletedCondition2 = 3010005
    End Enum

#End Region

#Region " RFLW "

    ''' <summary>
    ''' R@bitFlow クライアントの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFLW]

        '''' <summary>
        ''''ユーザーIDを入力して下さい。
        '''' </summary>
        '''' <remarks></remarks>
        'UserID = 3020001

        '''' <summary>
        ''''パスワードを入力して下さい。
        '''' </summary>
        '''' <remarks></remarks>
        'Password = 3020002

        '''' <summary>
        ''''ユーザーIDが正しくありません。
        '''' </summary>
        '''' <remarks></remarks>
        'UserIDMistake = 3020003

        '''' <summary>
        ''''パスワードが正しくありません。
        '''' </summary>
        '''' <remarks></remarks>
        'PasswordMistake = 3020004

        ''' <summary>
        '''この文書に参照権がありません。
        ''' </summary>
        ''' <remarks></remarks>
        DoumentAuthority = 3020005

        '''' <summary>
        ''''管理者ではログインできません。
        '''' </summary>
        '''' <remarks></remarks>
        'LoginAdministrator = 3020006

        '''' <summary>
        ''''キャビネットのパスワードが正しくありません。
        '''' </summary>
        '''' <remarks></remarks>
        'CabPassMistake = 3020007

        ''' <summary>
        '''入力項目をすべて入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChangePassword = 3020008

        ''' <summary>
        '''新しいパスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeNewPassword = 3020009

        ''' <summary>
        '''新しいパスワードは２０文字以内で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeNewPassLen = 3020010

        ''' <summary>
        '''新しいパスワードは前回のパスワードと同じものは使えません。
        ''' </summary>
        ''' <remarks></remarks>
        ComparePassword = 3020011

        ''' <summary>
        '''旧パスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        OldPassError = 3020012

        '''' <summary>
        ''''ユーザーが存在しません。
        '''' </summary>
        '''' <remarks></remarks>
        'UserError = 3020013

        '''' <summary>
        ''''選択されたキャビネットには保存できません。
        '''' </summary>
        '''' <remarks></remarks>
        'SaveCabinetError = 3020014

        ''' <summary>
        '''現在のパスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        NowPasswordError = 3020015

        ''' <summary>
        '''登録番号が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoNotInput = 3020016

        ''' <summary>
        '''この公開者は削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        PublicationCanNotDelete = 3020017

        ''' <summary>
        '''この参照者は削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ReferenceCanNotDelete = 3020018

        ''' <summary>
        '''指定した登録番号は既に使用されています。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicatedException = 3020019

        ''' <summary>
        '''連番が有効桁数を超えました。
        ''' </summary>
        ''' <remarks></remarks>
        NumberOutOfRangeException = 3020020

        ''' <summary>
        '''最終保存先・最終否認先が未設定です。
        ''' </summary>
        ''' <remarks></remarks>
        NonInputRidocDirectory = 3020021

        ''' <summary>
        '''文書名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonInputDocName = 3020022

        ''' <summary>
        '''版番号を数値で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CreateVersionNoFailed = 3020023

        ''' <summary>
        '''版番号は現在の版より大きい値を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        OverPresentVersion = 3020024

        ''' <summary>
        '''このフォームは代理{0}ができません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotMakeDocument = 3020025

        ''' <summary>
        '''登録番号の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberNotAppointBound = 3020026

        ''' <summary>
        '''管理番号の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ControlNumberNotAppointBound = 3020027

        ''' <summary>
        '''作成日の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotAppointBound = 3020028

        ''' <summary>
        '''回答期限の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotAppointBound = 3020029

        ''' <summary>
        '''承認日の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotAppointBound = 3020030

        ''' <summary>
        '''開始作成日付が終了作成日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateExcess = 3020031

        ''' <summary>
        '''開始回答期限が終了回答期限を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateExcess = 3020032

        ''' <summary>
        '''開始承認日付が終了承認日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateExcess = 3020033

        ''' <summary>
        '''作成日は日付項目のため、『YYYY/MM/DD』形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotIsDate = 3020034

        ''' <summary>
        '''回答期限は日付項目のため、『YYYY/MM/DD』形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotIsDate = 3020035

        ''' <summary>
        '''承認日は日付項目のため、『YYYY/MM/DD』形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotIsDate = 3020036

        ''' <summary>
        '''作成日の入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateOutOfBound = 3020037

        ''' <summary>
        '''承認日の入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateOutOfBound = 3020038

        ''' <summary>
        '''期間は日付項目のため、『YYYY/MM/DD』形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateNotIsDate = 3020039

        ''' <summary>
        '''開始日付が終了日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateExcess = 3020040

        ''' <summary>
        '''開始日を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDunInputStartDate = 3020041

        ''' <summary>
        '''入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        ProxyDateOutOfBound = 3020042

        ''' <summary>
        '''コメントを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CommentDunInput = 3020043

        ''' <summary>
        '''回答期限を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermDunInput = 3020044

        ''' <summary>
        '''回答期限は日付項目のため、『YYYY/MM/DD』形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermNotIsDate = 3020045

        ''' <summary>
        '''入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        ReplayTermOutOfBound = 3020046

        ''' <summary>
        '''代理者の有効期間が代理者当人の所属期間を超えているため登録できません。{0}期間を再入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ProxyOverRangeBelong = 3020047

        ''' <summary>
        '''選択された文書がありません。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptNoData = 3020048

        ''' <summary>
        '''この文書は改訂できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotRevision = 3020049

        ''' <summary>
        '''このファイルはサポートされていません。
        ''' </summary>
        ''' <remarks></remarks>
        RidocNoSupportFormat = 3020050

        ''' <summary>
        '''すでに選択されています。
        ''' </summary>
        ''' <remarks></remarks>
        SameFileSaved = 3020051

        ''' <summary>
        '''選択された文書はすでに選択されています。別の文書を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RidocFileSelected = 3020052

        ''' <summary>
        '''0バイトのファイルは添付できません。別のファイルを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck = 3020053

        ''' <summary>
        '''添付ファイルのサイズが大きすぎます。
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck_sizeOver = 3020054

        ''' <summary>
        '''99ファイルを超えて添付できません
        ''' </summary>
        ''' <remarks></remarks>
        FileLengthCheck_tenpuSuuOver = 3020055

        ''' <summary>
        '''ファイル名に無効な文字が含まれています。{0}  文字 %
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck = 3020056

        ''' <summary>
        '''ファイル名に無効な文字が含まれています。{0}  文字 ＆＃
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck2 = 3020057

        ''' <summary>
        '''ファイル名に無効な文字が含まれています。{0}  文字 ,
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck3 = 3020058

        ''' <summary>
        '''ファイル名に無効な文字が含まれています。{0}  文字 '
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck4 = 3020059

        ''' <summary>
        '''ファイル名に無効な文字が含まれています。{0}  文字 #
        ''' </summary>
        ''' <remarks></remarks>
        FileNameCheck5 = 3020060

        ''' <summary>
        '''公開者に設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetPublic = 3020061

        ''' <summary>
        '''編集者に設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetEdit = 3020062

        ''' <summary>
        '''参照者に設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetRefer = 3020063

        ''' <summary>
        '''確認者に設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetChecker = 3020064

        ''' <summary>
        '''メール送信者に設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetMailUser = 3020065

        ''' <summary>
        '''ルートに設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetAccepter = 3020066

        ''' <summary>
        '''確認者を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CheckerNotSetup = 3020067

        ''' <summary>
        '''申立者は１人以上指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkMin = 3020068

        ''' <summary>
        '''申立者は１０人以上指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkMax = 3020069

        ''' <summary>
        '''同一の申立者が指定されています。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkRepeat = 3020070

        ''' <summary>
        '''タイトル選択、タイトル入力が両方とも設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkTitle = 3020071

        ''' <summary>
        '''本体金額に不正な文字が入力されています。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkKingaku = 3020072

        ''' <summary>
        '''税金に不正な文字が入力されています。
        ''' </summary>
        ''' <remarks></remarks>
        ClamorChkZeikin = 3020073

        ''' <summary>
        '''年に不正な値が入力されています。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearCHKErr = 3020074

        ''' <summary>
        '''年は来年より大きい年は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearOverErr = 3020075

        ''' <summary>
        '''年は去年より小さい年は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearUnderErr = 3020076

        ''' <summary>
        '''年に値が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNumYearNoInput = 3020077

        ''' <summary>
        '''金額が登録できる値を超えています。登録できません。
        ''' </summary>
        ''' <remarks></remarks>
        InputMoneyOverErr = 3020078

        ''' <summary>
        '''金額が登録できる値を下回っています。登録できません。
        ''' </summary>
        ''' <remarks></remarks>
        InputMoneyUnderErr = 3020079

        ''' <summary>
        '''タイトル金額に不正な値が入力されています。
        ''' </summary>
        ''' <remarks></remarks>
        NumericMoneyErr = 3020080

        ''' <summary>
        '''予算超過金額に不正な値が入力されています。
        ''' </summary>
        ''' <remarks></remarks>
        NumericOverMoneyErr = 3020081

        ''' <summary>
        '''既に別ユーザーが開いています。
        ''' </summary>
        ''' <remarks></remarks>
        ExclusiveChk = 3020082

        ''' <summary>
        '''入力された検索キーでは該当文書が多い可能性があります。再度、検索キーを設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IgnoreWord = 3020083

        ''' <summary>
        '''表示できるビューがありません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetViewInfo = 3020084

        ''' <summary>
        '''只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3020085

        ''' <summary>
        '''選択された文書は、既に削除されています。
        ''' </summary>
        ''' <remarks></remarks>
        ExiStenceDocChk = 3020086

        ''' <summary>
        '''文書の新規作成の権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeNewDoc = 3020087

        ''' <summary>
        '''この文書は、既に審査・承認をされました。
        ''' </summary>
        ''' <remarks></remarks>
        NotActionDoc = 3020088

        ''' <summary>
        '''選択されている申立者が、ルート上に存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkNoRouteErr = 3020089

        ''' <summary>
        '''選択されている申立者が、ルート上の最終者になっています。
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkEndRouteErr = 3020090

        ''' <summary>
        '''選択されている申立者が、申立者として条件を満たしていません。
        ''' </summary>
        ''' <remarks></remarks>
        RequestChkLvPowerErr = 3020091

        ''' <summary>
        '''このルートは使用できません。{0}新規作成ボタンでルートを設定するか、管理者ツールで再定義する必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        RouteMenberNoData = 3020092

        ''' <summary>
        '''このルートは使用できません。{0}新規作成ボタンでルートを設定するか、管理者ツールで再定義する必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        RouteGroupNoData = 3020093

        ''' <summary>
        '''選択されたルートは、条件分岐を使用しているため、編集できません。
        ''' </summary>
        ''' <remarks></remarks>
        RouteTermsPointChk = 3020094

        ''' <summary>
        '''有効日に達していないため、処理を行うことはできません。
        ''' </summary>
        ''' <remarks></remarks>
        DireCtorDayChk = 3020095

        ''' <summary>
        '''使用しているフォームのルート設定が変更されています。再度、ルート変更を行って下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnionRouteChk = 3020096

        ''' <summary>
        '''現在、設定されているルートは別の担当者で設定されています{0}再度、ルート変更ボタンでルートを再設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocUser = 3020097

        ''' <summary>
        '''項目「{0}」は必須項目です。値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        GUIMustInputCHKErr = 3020098

        ''' <summary>
        '''審査･承認数が可決数より下回るため、削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ChkNoPersons = 3020099

        ''' <summary>
        '''メール送信者を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChkMailUser = 3020100

        ''' <summary>
        '''この文書は、既に他のユーザーにより更新されています。{0}文書を再度、開き直して下さい。{0}注：編集された項目については、メモ帳又はワードパットに保存し、{0}再度、文書を再作成して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocItemValue = 3020101

        ''' <summary>
        '''この文書は、返信文書が設定されているため、削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ChkDocDelete = 3020102

        ''' <summary>
        '''レスフォームの項目を表示するビューをここで使用することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotUseResFormView = 3020103

        ''' <summary>
        '''同一の所属者での並行審査設定はできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotRouteSameLevelChk = 3020104

        ''' <summary>
        '''設備申立書の割込修正・差戻しです。{0}社内トップページの「設備申立作成」で該当申立を選択し、[承認フローへ]ボタンを押して下さい。{0}その後、この画面より承認フローを再開して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotCutIntoOn = 3020105

        ''' <summary>
        '''組織は選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectOrg = 3020106

        ''' <summary>
        '''グループは選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectGrp = 3020107

        ''' <summary>
        '''このアカウントは現在ロックされています。
        ''' </summary>
        ''' <remarks></remarks>
        AccountLockMessage = 3020108

        ''' <summary>
        '''入力されたパスワードは最小文字列長を満たしていません。{1}{0}文字以上に設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MinPasswordMessage = 3020109

        ''' <summary>
        '''入力されたパスワードは最大文字列長を超えています。{1}{0}文字以内に設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MaxPasswordMessage = 3020110

        ''' <summary>
        '''入力されたパスワードに数値が含まれていません。
        ''' </summary>
        ''' <remarks></remarks>
        NumberPasswordMessage = 3020111

        ''' <summary>
        '''入力されたパスワードに記号が含まれていません。
        ''' </summary>
        ''' <remarks></remarks>
        MarkPasswordMessage = 3020112

        ''' <summary>
        '''入力されたパスワードに大文字小文字が混在されていません。
        ''' </summary>
        ''' <remarks></remarks>
        CapsPasswordMessage = 3020113

        ''' <summary>
        '''入力されたパスワードに利用者ＩＤが含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        UserIdPasswordMessage = 3020114

        ''' <summary>
        '''入力されたパスワードに同一文字が繰り返されています。{1}{0}文字以上の繰り返しがない設定をして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RepeatStringPasswordMessage = 3020115

        ''' <summary>
        '''入力されたパスワードに禁則文字が含まれています。{1}「{0}」はパスワードに設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        WrapPasswordMessage = 3020116

        ''' <summary>
        '''入力されたパスワードは過去に使われたパスワードです。
        ''' </summary>
        ''' <remarks></remarks>
        HistoryPasswordMessage = 3020117

        ''' <summary>
        '''連携項目の更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        DataTransferAbortMessage = 3020118

        ''' <summary>
        '''保存可能なファイルのサイズを超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverSizeMessage = 3020119

        ''' <summary>
        '''選択したファイルはサポートされていません。
        ''' </summary>
        ''' <remarks></remarks>
        FileNoSupportMessage = 3020120

        ''' <summary>
        '''一括印刷を行う文書が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        PrintFileNoSelectMessage = 3020121

        ''' <summary>
        ''' 既に{0}が開いています。
        ''' </summary>
        ''' <remarks></remarks>
        UserOpenedMessage = 3020122

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        OtherMessage = 3020123

        ''' <summary>
        ''' 代理者として自分を指定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        SystemOwnChk = 3020124

        ''' <summary>
        ''' 同一の代理者で代理権限が指定されています。
        ''' </summary>
        ''' <remarks></remarks>
        DaiSameChk = 3020125

        ''' <summary>
        ''' 項目「{0}」の入力値は「922,337,203,685,477.5807」から「-922,337,203,685,477.5808」の範囲にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DecimalOverFlow = 3020126

        ''' <summary>
        ''' 項目「{0}」の入力値は「2,147,483,647」から「-2,147,483,648」の範囲にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Int32OverFlow = 3020127

        ''' <summary>
        ''' ルートが指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSettingRoute = 3020128

        ''' <summary>
        ''' 一つの承認階層に同じ個人は追加できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSamePerson = 3020129

        ''' <summary>
        ''' 本人は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSelfUser = 3020130

        ''' <summary>
        ''' ユーザIDまたはパスワードが間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        LoginFailed = 3020131

        ''' <summary>
        ''' 代理者による処理はできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotProcessByDuplicator = 3020132

        ''' <summary>
        ''' 処理できない文書が含まれています。ビュー画面から文書を選択し直してください。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotProcessInDocument = 3020133

        ''' <summary>
        ''' ユーザＩＤまたはメールアドレスが間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        NonUserMessage = 3020134

        ''' <summary>
        '''選択されたフォームが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        FormNotExisted = 3020135

        ''' <summary>
        ''' 初回ログインです。パスワードを変更してください。
        ''' </summary>
        ''' <remarks></remarks>
        InitPasswordMessage = 3020136

        ''' <summary>
        ''' パスワードの有効期限が切れました。パスワードを変更してください。
        ''' </summary>
        ''' <remarks></remarks>
        ChangePasswodMessage = 3020137

        ''' <summary>
        ''' 文書閲覧がありません。
        ''' </summary>
        ''' <remarks></remarks>
        RGUINoDocumentReadAccess = 3020138
        ''' <summary>
        ''' フォームを利用できないユーザーまたは組織/グループは追加できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectUserForRoute = 3020139

        ''' <summary>
        ''' 認証に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ErrorInLogin = 3020140

        ''' <summary>
        ''' 指定された承認者は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectRouteChange = 3020141

        ''' <summary>
        ''' 権限がないためルートに指定することは出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        NoRightOfAccess = 3020142

    End Enum

#End Region

#Region " NGUI "

    ''' <summary>
    ''' NGUI プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [NGUI]

        ''' <summary>
        '''項目「{0}」の設計情報が不完全です。
        ''' </summary>
        ''' <remarks></remarks>
        FieldParamIncompleteExclamationMessage = 3030001

        ''' <summary>
        '''項目「{0}」は必須項目です。値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MustInputUnsatedExceptionExclamationMessage = 3030002

        ''' <summary>
        '''項目「{0}」の入力値は「922,337,203,685,477.5807」から「-922,337,203,685,477.5808」の範囲にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MonneyOverFlow = 3030003

        ''' <summary>
        '''項目「{0}」の入力値は「2,147,483,647」から「-2,147,483,648」の範囲にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IntOverFlow = 3030004

        ''' <summary>
        '''項目「{0}」は不正な日付です。正しい日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeGregorianExFailed = 3030005

        ''' <summary>
        '''添付ファイルを指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotAddFileExceptionExclamationMessage = 3030006

        ''' <summary>
        '''現在の版より大きい値を数値で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        OverPresenteVersion = 3030007

        ''' <summary>
        '''最終保存先・最終否認先を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotCabSelectedExceptionExclamationMessage = 3030008

        ''' <summary>
        '''99.99を超えて版を更新することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotRevisionMessage = 3030009

        ''' <summary>
        '''フォームの設定情報が不十分です。
        ''' </summary>
        ''' <remarks></remarks>
        NoSetRidocEntryMessage = 3030010

        ''' <summary>
        '''複数添付不可のファイルが含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        UnjustAttachedFileMessage = 3030011

        ''' <summary>
        '''版番号は必須項目です。値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotInputVersionMessage = 3030012

        ''' <summary>
        '''項目「{0}」の入力値は「1753年1月1日」から「9999年12月31日」の範囲で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        InputDateOutOfRange = 3030013

        ''' <summary>
        '''只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3030014

        ''' <summary>
        '''開始日、終了日いずれかが未入力での登録はできません。
        ''' </summary>
        ''' <remarks></remarks>
        AnotherNonInputItem = 3030015

        ''' <summary>
        '''開始日は終了日以前の日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateItem = 3030016

        ''' <summary>
        '''開始日から終了日の範囲は{0}日間以内にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemDay = 3030017

        ''' <summary>
        '''開始日から終了日の範囲は{0}ヶ月間以内にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemMonth = 3030018

        ''' <summary>
        '''開始日から終了日の範囲は{0}年間以内にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemYear = 3030019

        ''' <summary>
        '''開始日から終了日の範囲は{0}年以内にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RangeOverDateItemOneYear = 3030020

        ''' <summary>
        '''項目「氏名」は必須項目です。値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NameMustInput = 3030021

        ''' <summary>
        '''項目「ＦＡＸ番号」は必須項目です。値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        FaxMustInput = 3030022

        ''' <summary>
        '''項目「{0}」は不正な時間です。正しい時間を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        TimeInputError = 3030023

        ''' <summary>
        '''帳票レイアウトが存在しない文書が含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        NotLayoutFileInDocument = 3030024

        ''' <summary>
        ''' 印刷できるデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NonPrintDataMessage = 3030025

        ''' <summary>
        '''項目「{0}」は不正な数値です。正しい数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NumericErrorMessage = 3030026

        ''' <summary>
        '''選択された文書は帳票レイアウトが見つかりませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        NoReportLayout = 3030027

    End Enum

#End Region

#Region " VEGG "

    ''' <summary>
    ''' VEGG プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VEGG]

        ''' <summary>
        ''' カテゴリは選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        MustNotCategorySelected = 3040001

        ''' <summary>
        ''' 追加するルートを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AddRouteUnSelected = 3040002

        ''' <summary>
        ''' 削除するルートを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RemoveRouteUnSelected = 3040003

        ''' <summary>
        ''' すでに同じルートが選択されています。
        ''' </summary>
        ''' <remarks></remarks>
        SameRouteExist = 3040004

        ''' <summary>
        ''' 追加するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AddFormUnSelected = 3040005

        ''' <summary>
        ''' 削除するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RemoveFormUnSelected = 3040006

        ''' <summary>
        ''' すでに同じフォームが選択されています。
        ''' </summary>
        ''' <remarks></remarks>
        SameFormExist = 3040007

        ''' <summary>
        ''' ビューの名を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SetNoViewName = 3040008

        ''' <summary>
        ''' 出力する項目を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SetNoViewColumn = 3040009

        ''' <summary>
        ''' 数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnNumeric = 3040010

        ''' <summary>
        ''' 採番を行う際の有効桁数は1～10桁です。
        ''' </summary>
        ''' <remarks></remarks>
        VlDocNoFigOver10 = 3040011

        ''' <summary>
        ''' 採番項目に指定可能な項目は20項目までです。
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructOver20 = 3040012

        ''' <summary>
        ''' 採番項目に連番を登録して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructNoCounter = 3040013

        ''' <summary>
        ''' 採番項目の削除はできません。
        ''' </summary>
        ''' <remarks></remarks>
        DocColStructCounterNotDelete = 3040014

        ''' <summary>
        ''' 承認時保存先は必須入力です。{0}保存先を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SetFullPassLblNmPubDoc = 3040015

        ''' <summary>
        ''' 否認時保存先は必須入力です。{0}保存先を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SetFullPassLblNmNyDoc = 3040016

        ''' <summary>
        ''' カテゴリ名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnInputCategoryName = 3040017

        ''' <summary>
        ''' 表示順序を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnInputCategoryDispNo = 3040018

        ''' <summary>
        ''' カテゴリを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CategoryUnSelcted = 3040019

        ''' <summary>
        ''' 入力可能な範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverRange = 3040020

        ''' <summary>
        ''' 現在このフォームは使用中です。削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        FormExecutingNotDelte = 3040021


        ''' <summary>
        ''' フォームの名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnInputFormName = 3040022

        ''' <summary>
        ''' このルートは条件分岐を保持します。{0}他のフォームと併用したり、使用フォームを変更することは出来ません。
        ''' {0}使用フォームの変更をする場合は『ルート修正』ボタンをクリックし、{0}このルートを条件分岐の無い状態にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RuteHasBranch = 3040023

        ''' <summary>
        ''' 選択されたルートは条件分岐に他のフォームの項目が指定されています。{0}このフォームで使用することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        SelectedRuteHasBranch = 3040024

        ''' <summary>
        ''' 選択されたルートは条件分岐にこのフォームの項目が指定されています。{0}削除することはできません。
        ''' {0}削除する場合はメイン画面の『ルート修正』ボタンをクリックし、{0}このルートを条件分岐の無い状態にして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RemoveRuteHasBranch = 3040025

        ''' <summary>
        ''' 滞留期間の入力は１営業日以上を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        OverRengeVlttl = 3040026

        ''' <summary>
        ''' Ridoc連携で文書プロパティ設定の登録を行って下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocNotAddPropatyChk = 3040027

        ''' <summary>
        ''' フォームを公開中の為、削除できませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        FailedNotDelete = 3040028

        ''' <summary>
        ''' 既に選択されています。
        ''' </summary>
        ''' <remarks></remarks>
        DupSelect = 3040029

        ''' <summary>
        ''' レスフォームは既に登録されています。{0}新規作成する場合は、既存のレスフォームを削除して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ResOnlyOne = 3040030

        ''' <summary>
        ''' 使用対象ＧＵＩが設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NoGuiSelect = 3040031

        ''' <summary>
        ''' レス階層には数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ResUnNumeric = 3040032


        ''' <summary>
        ''' 選択した項目で検索するにはすべてのビューを再登録する必要があります。{0}ビューを選択して登録ボタンをクリックして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReSetupView = 3040033


        ''' <summary>
        ''' 最適化を実行することができません。{0}選択項目を確認してから再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotExecuteOptimize = 3040034

        ''' <summary>
        ''' 元に戻すことができません。{0}選択項目を確認してから再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotExecuteUndo = 3040035

        ''' <summary>
        ''' 選択されたキャビネットのパスワードを設定画面で登録して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CabPassNotRegistration = 3040036

        ''' <summary>
        ''' 保存先を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CabinetNotSelected = 3040037

        ''' <summary>
        ''' 任意文字列は半角英数で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnjustTxtFree = 3040038

        ''' <summary>
        ''' 連携するプロパティを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocPropNotSelected = 3040039

        ''' <summary>
        ''' 書込み対象プロパティが重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        DocPropDuplication = 3040040


        ''' <summary>
        ''' Ridocプロパティ「文書名」への「書込み設定」は必須です。{0}フォームに貼付してある項目を、Ridocプロパティ「文書名」に「書込み設定」して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocNamePropNonSet = 3040041

        ''' <summary>
        ''' 選択された文書プロパティは予約プロパティが設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        DocPropNonSet = 3040042


        ''' <summary>
        ''' 文書管理ツールにて文書タイプの登録を行って下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocTypeNonSet = 3040043

        ''' <summary>
        ''' 印刷設定位置が重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        PrintDataDuplication = 3040044

        ''' <summary>
        ''' 回答期限を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimit = 3040045

        ''' <summary>
        ''' 回答期限の入力は1営業日以上を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimitOutOfRange = 3040046


        ''' <summary>
        ''' 権限情報が重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        DupAuthInfo = 3040047

        ''' <summary>
        ''' コピー情報が重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        DupCopyInfo = 3040048

        ''' <summary>
        ''' コピー情報がありません。
        ''' </summary>
        ''' <remarks></remarks>
        NoCopyinfo = 3040049


        ''' <summary>
        ''' 選択された割当データを削除する権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        AssignNoAuth = 3040050

        ''' <summary>
        ''' 只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3040051

        ''' <summary>
        ''' 文書を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedDocumentList = 3040052

        ''' <summary>
        ''' {0}文書のみ選択可能です。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedDraftOnly = 3040053


        ''' <summary>
        ''' ワークフローまたは公開掲示板のみ選択可能です。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedRouteForm = 3040054

        ''' <summary>
        ''' 受付窓口文書のみ選択可能です。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedReferData = 3040055

        ''' <summary>
        ''' 受付窓口担当を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedAddReferData = 3040056

        ''' <summary>
        ''' １文書のみ選択可能です。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectedOneOnly = 3040057

        ''' <summary>
        ''' 開始と終了は違う時間で登録して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        TimeAbonMessage = 3040058

        ''' <summary>
        ''' フォームから削除された項目がビューで使用されています。{0}ビューエディタで修正して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CheckViewSQLErrorMessage = 3040059

        ''' <summary>
        ''' 人事登録で{0}が行われていないため、カテゴリを登録することはできません。{1}カテゴリを登録するには、人事登録メニューより{0}を行って下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotSettingBranch = 3040060

        ''' <summary>
        ''' 文書が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoSelected = 3040061

        ''' <summary>
        ''' 入力された登録番号は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberDuplicate = 3040062

        ''' <summary>
        ''' 文書が複数選択されています。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManySelected = 3040063
        ''' <summary>
        ''' 権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManagementNoAuth = 3040064


        ''' <summary>
        ''' 設計者にはすべての文書を参照する権限はありません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentManagementNoAuthAllDocument = 3040065


        ''' <summary>
        ''' 出力する文書がありません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNoOutput = 3040066

        ''' <summary>
        ''' 登録番号の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        DocumentNumberNotAppointBound = 3040067

        ''' <summary>
        ''' 管理番号の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ControlNumberNotAppointBound = 3040068

        ''' <summary>
        ''' 作成日の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateNotAppointBound = 3040069

        ''' <summary>
        ''' 回答期限の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ResponseDateNotAppointBound = 3040070

        ''' <summary>
        ''' 承認日の範囲が指定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateNotAppointBound = 3040071

        ''' <summary>
        ''' 開始作成日付が終了作成日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        MakeDateExcess = 3040072

        ''' <summary>
        ''' 開始承認日付が終了承認日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptDateExcess = 3040073

        ''' <summary>
        ''' 採番有効桁数を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        DocUnNumeric = 3040074

        ''' <summary>
        ''' 数値の桁数がオーバーしています。
        ''' </summary>
        ''' <remarks></remarks>
        OverFlowNumeric = 3040075


        ''' <summary>
        '''SQLの生成に失敗しました。{0}（{1}）
        ''' </summary>
        ''' <remarks></remarks>
        NotCreateSql = 3040076

        ''' <summary>
        '''生成されるSQL文が正常に動作しませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        NotExcuteSql = 3040077

        ''' <summary>
        '''一覧出力項目のソート順番が指定されていません。{1}[ {0} ]
        ''' </summary>
        ''' <remarks></remarks>
        SetNoSort = 3040078

        ''' <summary>
        '''一覧出力項目の {0} が重複しています。{1}重複している項目名を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        DupViewField = 3040079

        ''' <summary>
        '''一覧出力項目の同一結合項目の表示名称が異なっています。{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        DifViewFieldName = 3040080

        ''' <summary>
        '''グループ出力項目の {0} が重複しています。{1}重複している項目名を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        DupGroupField = 3040081

        ''' <summary>
        '''グループ出力項目の同一結合項目の表示名称が異なっています。{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        DifGroupFildName = 3040082

        ''' <summary>
        '''一覧・グループ出力項目の {0} が重複しています。{1}重複している項目名を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        DupViewGroupField = 3040083

        ''' <summary>
        '''結合項目としての設定に誤りがあります。{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        NotSetUnion = 3040084

        ''' <summary>
        '''結合項目として指定した場合には、計算指定は無効です。{2}[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        InvalidCalculation = 3040085

        ''' <summary>
        '''結合項目チェック時にエラーを検出しました。
        ''' </summary>
        ''' <remarks></remarks>
        NotChkUnion = 3040086

        ''' <summary>
        '''入力された分割開始位置が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkDivStartPosError = 3040087

        ''' <summary>
        '''入力された分割文字数が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkDivSizeError = 3040088

        ''' <summary>
        '''入力された幅が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkWidthError = 3040089

        ''' <summary>
        '''表示項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkItemError = 3040090

        ''' <summary>
        '''グループに対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkGrpItemError = 3040091

        ''' <summary>
        '''条件項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkIfItemError = 3040092

        ''' <summary>
        '''結合項目に対象以外のフォームの項目が選択されています。[FORM={0}][VIEW={1}][FIELD={2}]
        ''' </summary>
        ''' <remarks></remarks>
        ChkUnionItemError = 3040093


        ''' <summary>
        '''RESボタン設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        NotSetResBtn = 3040094

        ''' <summary>
        '''グループ化項目が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSetGrp = 3040095

        ''' <summary>
        '''グループ化項目として指定されている項目が最大（{0}項目）を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        MaxGrpFiled = 3040096

        ''' <summary>
        '''削除対象のビューが下記結合ビューで使用されている為、削除できません。{0}{1}
        ''' </summary>
        ''' <remarks></remarks>
        NotDelView = 3040097

        ''' <summary>
        '''ビューのコピーに失敗しました。{0}
        ''' </summary>
        ''' <remarks></remarks>
        FailedViewCopy = 3040098

        ''' <summary>
        '''入力されたページ内表示件数が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        PageMaxChk = 3040099

        ''' <summary>
        '''入力された最大読込件数が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ReadMaxChk = 3040100

        ''' <summary>
        '''入力された最大返信表示階層が正しくありません。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ResMaxChk = 3040101

        ''' <summary>
        '''一覧表示項目が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSetView = 3040102

        ''' <summary>
        '''フォーム連結情報に設定されている {0}フォームは、一覧出力項目にもグループ化項目にも設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        RelationalChk = 3040103

        ''' <summary>
        '''{0}のフォームのみ指定が可能です。
        ''' </summary>
        ''' <remarks></remarks>
        DispFormChk = 3040104

        ''' <summary>
        '''結合ビュー{0}で使用されているビューの為、操作はできません。
        ''' </summary>
        ''' <remarks></remarks>
        ItemUserUnionErr = 3040105

        ''' <summary>
        '''[{0}({1})]の項目が結合ビュー{2}で使用されている為、削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ItemUserErr = 3040106

        ''' <summary>
        '''選択された項目がフォームから削除されています。
        ''' </summary>
        ''' <remarks></remarks>
        SelectedFiledDel = 3040107

        ''' <summary>
        '''選択された項目が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        SelectedFiledErr = 3040108

        ''' <summary>
        '''40文字までで入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        MaxTxtLen40 = 3040109

        ''' <summary>
        '''G_からはじまる項目名を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSetGFiled = 3040110

        ''' <summary>
        '''分割開始位置が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSetDivPos = 3040111

        ''' <summary>
        '''条件ブロックだけの登録はできません。
        ''' </summary>
        ''' <remarks></remarks>
        OnlyIfBloc = 3040112

        ''' <summary>
        '''条件が設定されていないブロックの登録はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSaveIfBloc = 3040113

        ''' <summary>
        '''有効な値が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        VaildDataNotSelected = 3040114

        ''' <summary>
        '''入力されている値を{0}として認識できません。
        ''' </summary>
        ''' <remarks></remarks>
        NotUnderstandValue = 3040115

        ''' <summary>
        '''指定された予約語の時は、「{0}」「{1}」のみ指定可能です。
        ''' </summary>
        ''' <remarks></remarks>
        RsvKindChk = 3040116

        ''' <summary>
        '''正しく登録されませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        AddDataError = 3040117

        ''' <summary>
        '''入力された表示名は既に登録されています。
        ''' </summary>
        ''' <remarks></remarks>
        HasNMExist = 3040118

        ''' <summary>
        '''半角50文字・全角25文字までで入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        MaxTxtLen50 = 3040119

        ''' <summary>
        '''選択されたビューは既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        HasViewExist = 3040120

        ''' <summary>
        '''結合対象ビュー一覧リストの追加に失敗しました！
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAddErr = 3040121

        ''' <summary>
        '''結合対象ビュー項目一覧リストの追加に失敗しました！
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewListAddErr = 3040122

        ''' <summary>
        '''結合対象ビュー項目一覧（ＡＬＬ）リストの追加に失敗しました！
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewAllAddErr = 3040123

        ''' <summary>
        '''結合対象ビュー項目一覧リストの修正に失敗しました！
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewMidifyErr = 3040124

        ''' <summary>
        '''結合対象ビューグループ化項目一覧（ＡＬＬ）リストの追加に失敗しました！
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewGrpErr = 3040125

        ''' <summary>
        '''表示名が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NMMustInput = 3040126

        ''' <summary>
        '''選択された表示名は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        SelectedNMExist = 3040127

        ''' <summary>
        '''結合ビュー項目が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewFieldMustSelect = 3040128

        ''' <summary>
        '''結合ビューとして指定されたビューで項目が選択されていないビューが存在します。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewNotExist = 3040129

        ''' <summary>
        '''結合対象のビューが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewMustSelect = 3040130

        ''' <summary>
        '''結合対象ビュー項目の共通定義がされていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemMustDef = 3040131

        ''' <summary>
        '''結合対象ビュー項目が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemMustSelect = 3040132

        ''' <summary>
        '''結合対象ビュー項目の数が異なっています。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewItemDif = 3040133

        ''' <summary>
        '''結合対象ビューグループ項目の数が異なっています。
        ''' </summary>
        ''' <remarks></remarks>
        UnionViewGrpItemDIf = 3040134

        ''' <summary>
        '''選択された項目がフォームから削除されています。
        ''' </summary>
        ''' <remarks></remarks>
        DelSelectedItem = 3040135

        ''' <summary>
        '''表示できるのは最大{0}ボタンまでです。
        ''' </summary>
        ''' <remarks></remarks>
        MaxBtnCount = 3040136

        ''' <summary>
        '''登録処理に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotAdd = 3040137

        ''' <summary>
        '''項目一括更新一覧リストの追加に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        NotAddItemList = 3040138

        ''' <summary>
        '''入力された値を数値として認識できません。
        ''' </summary>
        ''' <remarks></remarks>
        InvaidNumeric = 3040139

        ''' <summary>
        '''入力された値が有効範囲外です。
        ''' </summary>
        ''' <remarks></remarks>
        InvaidValue = 3040140

        ''' <summary>
        '''入力された値を日付として認識できません。
        ''' </summary>
        ''' <remarks></remarks>
        InvaidDate = 3040141

        ''' <summary>
        '''選択された項目は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        SelectedItemExist = 3040142

        ''' <summary>
        ''' 表示名が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NameEmpty = 3040143

        ''' <summary>
        ''' 選択された表示名は既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        NameExisted = 3040144

        ''' <summary>
        ''' 個人が正しく選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        UserListSelect = 3040145

        ''' <summary>
        ''' グループが正しく選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        GroupTp2SelectChk = 3040146

        ''' <summary>
        ''' {0}の表示名が入力されていません。
        ''' </summary>
        ''' <remarks></remarks>
        EmptyViewShowField = 3040147

        ''' <summary>
        ''' 条件分岐が存在するルートが既に登録されています。{0}このフォームで使用することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        ExistBranchRoute = 3040148
        'ヘルプ設定
        ''' <summary>
        ''' リンク先を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotHelpLinkUrl = 3040149
        ''' <summary>
        ''' リンクの表示名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotHelpLinkName = 3040150

        ''' <summary>
        ''' ビューが存在するため解除することはできません。
        ''' 解除するには、このレスフォームを利用しているすべてのビューを削除する必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        ExistsResView = 3040151

        ''' <summary>
        ''' 組織・グループまたは個人を選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReferData = 3040152

        ''' <summary>
        ''' 選択された組織・グループは既に追加されています。
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySelectedOrgReferData = 3040153

        ''' <summary>
        ''' 選択された個人は既に追加されています。
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySelectedSelfReferData = 3040154

        ''' <summary>
        ''' 「{0}」の「{1}」は既に引継ぎ項目に設定済みです。
        ''' </summary>
        ''' <remarks></remarks>
        AddedAcceptanceField = 3040155

        ''' <summary>
        ''' 引継ぎ項目にフォームから削除された項目が含まれています。
        ''' </summary>
        ''' <remarks></remarks>
        IncludeRemovedMapping = 3040156

    End Enum

#End Region

#Region " VFRM "

    ''' <summary>
    ''' VFRM プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFRM]
        ''' <summary>
        '''フォーム名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotFormName = 3050001

        ''' <summary>
        '''項目表示名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldName = 3050002

        ''' <summary>
        '''文字長さを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotMaxLength = 3050003

        ''' <summary>
        '''文字長さの入力に誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        MaxLengthError = 3050004

        ''' <summary>
        '''Ridoc添付を追加して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotRidoc = 3050005

        ''' <summary>
        '''既定値の入力に誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        DefaultValueError = 3050006

        ''' <summary>
        '''「{0}」が入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OutofRange = 3050007

        ''' <summary>
        '''セルの結合ができません。
        ''' </summary>
        ''' <remarks></remarks>
        FailedMerge = 3050008

        ''' <summary>
        '''項目幅の設定に誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        WidthEntryError = 3050009

        ''' <summary>
        '''項目高さの設定に誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        HeightEntryError = 3050010

        ''' <summary>
        '''同じ項目設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        ListitemError = 3050011

        ''' <summary>
        '''一項目30文字以内で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LengthOverflow = 3050012

        ''' <summary>
        '''項目「{0}」のプロパティを設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotProperty = 3050013

        ''' <summary>
        '''項目「{0}」のリスト項目を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotListItems = 3050014

        ''' <summary>
        '''リスト項目を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotListItems2 = 3050015

        ''' <summary>
        '''項目「{0}」がすでに存在している為、追加を行う事ができません。
        ''' </summary>
        ''' <remarks></remarks>
        OnlyOneInsert = 3050016

        ''' <summary>
        '''フォームに一つしか作成できないコントロールがあります。
        ''' </summary>
        ''' <remarks></remarks>
        OnlyOneCopy = 3050017

        ''' <summary>
        '''項目「{0}」は複数配置することができません。削除して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IllegalCopy = 3050018

        ''' <summary>
        '''フォームにワークフロー項目名もしくは重複した項目名を付ける事はできません。
        ''' </summary>
        ''' <remarks></remarks>
        FieldNameRepeated = 3050019

        ''' <summary>
        '''入力可能範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OutofRangeNoObj = 3050020

    End Enum

#End Region

#Region " VGUI "

    ''' <summary>
    ''' VGUI プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VGUI]

        ''' <summary>
        ''' 基数項目が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectBaseItem = 3060001

        ''' <summary>
        ''' 被数項目が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectCoverItem = 3060002

        ''' <summary>
        ''' 算術式が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectexpressionItem = 3060003

        ''' <summary>
        ''' 結果項目が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectresultItem = 3060004

        ''' <summary>
        ''' 出力項目を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectOutput = 3060005

        ''' <summary>
        ''' 登録できるプロパティがありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonProperty = 3060006

        ''' <summary>
        ''' 固定値を入力するかフィールドを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ValueOrField = 3060007

        ''' <summary>
        ''' 比較項目を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CompareSelect = 3060008

        ''' <summary>
        ''' 比較演算子を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        OperatorSelect = 3060009

        ''' <summary>
        ''' 比較に項目の値を使用する場合は、比較する項目を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CompareFieldSelect = 3060010

        ''' <summary>
        ''' 比較する項目の属性が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        AttributeAgreement = 3060011

        ''' <summary>
        ''' 比較項目は文字列型ではないので比較することができません。
        ''' </summary>
        ''' <remarks></remarks>
        NoString = 3060012

        ''' <summary>
        ''' 比較項目は数値型ではないので比較することができません。
        ''' </summary>
        ''' <remarks></remarks>
        NoNumeric = 3060013

        ''' <summary>
        ''' 比較項目は日付型ではないので比較することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NoDate = 3060014

        ''' <summary>
        ''' 出力内容を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ContentMustInput = 3060015

        ''' <summary>
        ''' 出力先の項目は文字型でなければなりません。
        ''' </summary>
        ''' <remarks></remarks>
        OutColumnsMustString = 3060016

        ''' <summary>
        ''' 数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        InputNumeric = 3060017

        ''' <summary>
        ''' 日付はYYYY/MM/DD形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        InputDate = 3060018

        ''' <summary>
        '''範囲を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AppointRange = 3060019

        ''' <summary>
        '''開始日付が終了日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverFlow = 3060020

        ''' <summary>
        '''只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3060021

        ''' <summary>
        '''必須設定対象のコントロールが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectMustInputControl = 3060022

        ''' <summary>
        '''条件設定対象のコントロールが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectConditionControl = 3060023

        ''' <summary>
        '''必須設定対象と条件設定対象のコントロールを同じにすることはできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSetSameControl = 3060024

        ''' <summary>
        '''条件の判断値が入力されていません。「値がないとき」という条件の場合は「""""」と入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonInputConditionalText = 3060025

        ''' <summary>
        '''既に同一の組み合わせが存在します。
        ''' </summary>
        ''' <remarks></remarks>
        NonSameCombination = 3060026

        ''' <summary>
        '''指定された項目に、複数の項目の値を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotCombinableFormField = 3060027

        ''' <summary>
        '''参照フォーム・ビューが選択されていないか、フォーム・ビューが削除されています。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReferenceForm = 3060028

        ''' <summary>
        '''項目区切文字と行区切文字を同じにすることはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectSameSeparator = 3060029

        ''' <summary>
        '''指定可能な内容が選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectReservItem = 3060030

        ''' <summary>
        '''開始日から終了日までの範囲が期間の最大範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverMaxRangeItem = 3060031

        ''' <summary>
        '''0以上の数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MinErr1 = 3060032

        ''' <summary>
        '''1以上の数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MinErr2 = 3060033

        ''' <summary>
        '''整数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MinErr3 = 3060034

        ''' <summary>
        '''一括更新項目設定がありません。
        ''' </summary>
        ''' <remarks></remarks>
        LumpItemNothing = 3060035

        ''' <summary>
        '''指定されたカラムが見つかりませんでした。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumNotFind = 3060036

        ''' <summary>
        '''指定されたカラムと属性が違います。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeErr = 3060037

        ''' <summary>
        '''桁数オーバーです。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgClumTypeOver = 3060038

        ''' <summary>
        '''予期しないエラーが発生しました。
        ''' </summary>
        ''' <remarks></remarks>
        ClmChkErrMsgAbnomal = 3060039

        ''' <summary>
        '''入力可能文字数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        OverInputCharcterLength = 3060040

        ''' <summary>
        '''添付文書タイトル入れて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        InputCharcterForAddFile = 3060041

        ''' <summary>
        '''ファイルを添付して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MustInputInlineGUI = 3060042

        ''' <summary>
        '''サブフォームが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSelectSubForm = 3060043

        ''' <summary>
        '''{0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3060044

        ''' <summary>
        '''同一のフィールドを指定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectSameField = 3060045

        ''' <summary>
        '''メインフォーム情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormInfoException = 3060046

        ''' <summary>
        '''メインフォーム項目情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        MainFormFieldInfoException = 3060047

        ''' <summary>
        '''指定されたビューの情報が異常です。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewInfoException = 3060048

        ''' <summary>
        '''指定されたビューの項目情報が異常です。[{0}]
        ''' </summary>
        ''' <remarks></remarks>
        ViewFieldInfoException = 3060049

        ''' <summary>
        '''ビューSQLが存在しません
        ''' </summary>
        ''' <remarks></remarks>
        ViewSqlNotExisted = 3060050

        ''' <summary>
        '''DBGUI固有情報の設定に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SetDBGUIFailed = 3060051

        ''' <summary>
        '''指定されたフォームＩＤのデータが存在しません。[{0}][{1}]
        ''' </summary>
        ''' <remarks></remarks>
        FormIdDataNotExisted = 3060052

        ''' <summary>
        '''フィールド情報の取得に失敗しました
        ''' </summary>
        ''' <remarks></remarks>
        GetFieldInfoFailed = 3060053

        ''' <summary>
        '''項目が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        ItemIsNotSetUp = 3060054

        ''' <summary>
        '''項目の設定が誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        ItemSetError = 3060055

        ''' <summary>
        '''条件値はYYYY/MM/DDの形式で入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        DateTypeError = 3060056

        ''' <summary>
        '''条件値は数値で入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NumberTypeError = 3060057

        ''' <summary>
        '''採番項目に指定可能な項目は20項目までです。
        ''' </summary>
        ''' <remarks></remarks>
        ItemOverflow = 3060058

        ''' <summary>
        '''採番項目の削除はできません。
        ''' </summary>
        ''' <remarks></remarks>
        DelSeqitem = 3060059

        ''' <summary>
        '''数値を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        illegalInput = 3060060

        ''' <summary>
        '''計算式を設定してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotExpress = 3060061

        ''' <summary>
        '''出力項目を選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotOutputitem = 3060062

        ''' <summary>
        '''計算式の設定に誤りがあります。
        ''' </summary>
        ''' <remarks></remarks>
        ExpressCheckError = 3060063

        ''' <summary>
        '''計算式の設定に誤りがあります。{1}項目{0}はありません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFieldInExpress = 3060064

        ''' <summary>
        '''比較条件を追加してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotAddCheckCondition = 3060065

        ''' <summary>
        '''比較項目を選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotCompareItem = 3060066

        ''' <summary>
        '''比較元を選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotCompareItem2 = 3060067

        ''' <summary>
        '''比較演算子を選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotOperator = 3060068

        ''' <summary>
        '''メッセージを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotMessage = 3060069

        ''' <summary>
        '''比較項目と比較元が重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        HaveSameItems = 3060070

        ''' <summary>
        '''項目「{0}」はありません。
        ''' </summary>
        ''' <remarks></remarks>
        FieldDeleted = 3060071

        ''' <summary>
        ''' 比較元を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CompareSrcSelect = 3060072

        ''' <summary>
        ''' 特定日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotFixDate = 3060073

        ''' <summary>
        ''' 開始日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotStartDate = 3060074

        ''' <summary>
        ''' 終了日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotEndDate = 3060075

        ''' <summary>
        ''' 開始日付が終了日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        EndDateError = 3060076

        ''' <summary>
        ''' 加算日付の単位を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotUnit = 3060077

        ''' <summary>
        ''' 分岐を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotBunki = 3060078

        ''' <summary>
        ''' 条件分岐を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotCondition = 3060079

        ''' <summary>
        ''' ビューが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnSelectedView = 3060080

        ''' <summary>
        ''' 同じ項目の組み合わせは二つ以上登録できません。
        ''' </summary>
        ''' <remarks></remarks>
        CannotMultiEntry = 3060081

        ''' <summary>
        ''' データタイプが異なるため登録できません。
        ''' </summary>
        ''' <remarks></remarks>
        NotEntryDiffField = 3060082

        ''' <summary>
        ''' 条件式が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsCompare = 3060083

        ''' <summary>
        ''' 表示項目が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsDispField = 3060084

        ''' <summary>
        ''' 初期値が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSettingsDefValue = 3060085

        ''' <summary>
        ''' 表示件数に1以上の数字を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        MustInputOver1 = 3060086

        ''' <summary>
        ''' 権限情報が重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        DupAuthInfo = 3060087

        ''' <summary>
        '''社員コードを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NoUserIDFLD = 3060088
    End Enum

#End Region

#Region " VJNJ "

    ''' <summary>
    ''' VJNJ プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VJNJ]

        ''' <summary>
        ''' パスワードが一致しません。
        ''' </summary>
        CommonMsg0001 = 3070001

        ''' <summary>
        ''' 表示件数には 0 以上の半角整数を入力してください。
        ''' </summary>
        CommonMsg0002 = 3070002

        ''' <summary>
        ''' 役職を選択してください。
        ''' </summary>
        AffiliationMsg0001 = 3071001

        ''' <summary>
        ''' 本務または兼務を選択してください。
        ''' </summary>
        AffiliationMsg0002 = 3071002

        ''' <summary>
        ''' 有効期限日付に有効開始日付より小さな日付を選択することはできません。
        ''' </summary>
        AffiliationMsg0003 = 3071003

        ''' <summary>
        ''' 複数割当が許可されていない役職が複数割り当てられています。
        ''' </summary>
        AffiliationMsg0004 = 3071004

        ''' <summary>
        ''' 役職が登録されていないため、所属を設定することができません。
        ''' 所属を設定するためには役職を登録してください。
        ''' </summary>
        AffiliationMsg0005 = 3071005

        ''' <summary>
        ''' 個人の利用終了日付以降に所属の有効開始日付を設定することはできません。
        ''' </summary>
        AffiliationMsg0006 = 3071006

        ''' <summary>
        ''' 組織の有効開始日付が {0} のため、利用終了日付が {1} の個人を所属に追加することはできません。
        ''' </summary>
        AffiliationMsg0007 = 3071007

        ''' <summary>
        ''' 組織の有効期限日付が {0} のため、利用開始日付が {1} の個人を所属に追加することはできません。
        ''' </summary>
        AffiliationMsg0008 = 3071008

        ''' <summary>
        ''' 個人の利用開始日付が {0} のため、有効期限日付が {1} の組織を所属に追加することはできません。
        ''' </summary>
        AffiliationMsg0009 = 3071009

        ''' <summary>
        ''' 個人の利用終了日付が {0} のため、有効開始日付が {1} の組織を所属に追加することはできません。
        ''' </summary>
        AffiliationMsg0010 = 3071010

        ''' <summary>
        ''' 選択した部門は結合ルートのカテゴリに設定されているため削除することができません。
        ''' </summary>
        BranchMsg0001 = 3072001

        ''' <summary>
        ''' 有効期限日付に有効開始日付より小さな日付を選択することはできません。
        ''' </summary>
        GroupMsg0001 = 3073001

        ''' <summary>
        ''' 組織・グループ種別を選択してください。
        ''' </summary>
        GroupMsg0002 = 3073002

        ''' <summary>
        ''' 組織・グループコードを入力してください。
        ''' </summary>
        GroupMsg0003 = 3073003

        ''' <summary>
        ''' 組織・グループ名を入力してください。
        ''' </summary>
        GroupMsg0004 = 3073004

        ''' <summary>
        ''' 表示順は 0 以上の正の整数を入力してください。
        ''' </summary>
        GroupMsg0005 = 3073005

        ''' <summary>
        ''' Windows アカウントのドメイン名が入力されていません参照ボタンよりグループを選択してください。
        ''' </summary>
        GroupMsg0006 = 3073006

        ''' <summary>
        ''' Windows アカウントのグループ名が入力されていません参照ボタンよりグループを選択してください。
        ''' </summary>
        GroupMsg0007 = 3073007

        ''' <summary>
        ''' 入力された組織・グループコードは他の組織・グループにより既に使用されています。
        ''' </summary>
        GroupMsg0008 = 3073008

        ''' <summary>
        ''' 上位組織・グループの有効開始日付は {0} です。
        ''' これ以前の有効開始日付を持つ組織・グループを登録することはできません。
        ''' </summary>
        GroupMsg0009 = 3073009

        ''' <summary>
        ''' 上位組織・グループの有効期限日付は {0} です。
        ''' これ以降の有効開始日付を持つ組織・グループを登録することはできません。
        ''' </summary>
        GroupMsg0010 = 3073010

        ''' <summary>
        ''' 上位組織・グループの有効期限日付は {0} です。
        ''' これ以降の有効期限日付を持つ組織・グループを登録することはできません。
        ''' </summary>
        GroupMsg0011 = 3073011

        ''' <summary>
        ''' グループの配下に組織を作成することはできません。
        ''' </summary>
        GroupMsg0012 = 3073012

        ''' <summary>
        ''' 配下に組織が存在するため、組織・グループ種別を組織からグループに変更することはできません。
        ''' 組織・グループ種別を変更するには、下位の組織を削除するかグループに変更してください。
        ''' </summary>
        GroupMsg0013 = 3073013

        ''' <summary>
        ''' 配下に所属が存在するため、組織・グループ種別を変更することはできません。
        ''' 組織・グループ種別を変更するには、すべての所属を削除してから行ってください。
        ''' </summary>
        GroupMsg0014 = 3073014

        ''' <summary>
        ''' 組織・グループコードは半角英数字で入力してください。
        ''' </summary>
        GroupMsg0015 = 3073015

        ''' <summary>
        ''' 個人コードを入力してください。
        ''' </summary>
        PersonMsg0001 = 3074001

        ''' <summary>
        ''' 氏名を入力してください。
        ''' </summary>
        PersonMsg0002 = 3074002

        ''' <summary>
        ''' 氏名（カナ）を入力してください。
        ''' </summary>
        PersonMsg0003 = 3074003

        ''' <summary>
        ''' 利用終了日付に利用開始日付日より小さな日付を選択することはできません。
        ''' </summary>
        PersonMsg0004 = 3074004

        ''' <summary>
        ''' ユーザーＩＤを入力してください。
        ''' </summary>
        PersonMsg0005 = 3074005

        ''' <summary>
        ''' パスワードを入力してください。
        ''' </summary>
        PersonMsg0006 = 3074006

        ''' <summary>
        ''' パスワードが一致しません。パスワードを両方のテキストボックスに入力してください。
        ''' </summary>
        PersonMsg0007 = 3074007

        ''' <summary>
        ''' ドメイン名が入力されていません。参照ボタンよりユーザーを選択してください。
        ''' </summary>
        PersonMsg0008 = 3074008

        ''' <summary>
        ''' ユーザーＩＤが入力されていません。参照ボタンよりユーザーを選択してください。
        ''' </summary>
        PersonMsg0009 = 3074009

        ''' <summary>
        ''' 印鑑が入力されていません。
        ''' </summary>
        PersonMsg0010 = 3074010

        ''' <summary>
        ''' 入力された個人コードは他のユーザーにより既に使用されています。
        ''' </summary>
        PersonMsg0011 = 3074011

        ''' <summary>
        ''' メールアドレスの形式が正しくありません。
        ''' </summary>
        PersonMsg0012 = 3074012

        ''' <summary>
        ''' ユーザーＩＤに禁則文字が含まれています。
        ''' 次の文字はユーザー名に使用することはできません。
        ''' </summary>
        PersonMsg0013 = 3074013

        ''' <summary>
        ''' 入力されたユーザーＩＤは他のユーザーにより既に使用されています。
        ''' </summary>
        PersonMsg0014 = 3074014

        ''' <summary>
        ''' 個人コードは半角英数字で入力してください。
        ''' </summary>
        PersonMsg0015 = 3074015

        ''' <summary>
        ''' ユーザーＩＤは半角英数および使用が許可されている記号で入力してください。
        ''' </summary>
        PersonMsg0016 = 3074016

        ''' <summary>
        ''' 有効期限日付に有効開始日付より小さな日付を選択することはできません。
        ''' </summary>
        PositionMsg0001 = 3075001

        ''' <summary>
        ''' 役職コードを入力してください。
        ''' </summary>
        PositionMsg0002 = 3075002

        ''' <summary>
        ''' 役職名を入力してください。
        ''' </summary>
        PositionMsg0003 = 3075003

        ''' <summary>
        ''' 役職種別を選択してください。
        ''' </summary>
        PositionMsg0004 = 3075004

        ''' <summary>
        ''' 表示順は 0 以上の正の整数を入力してください。
        ''' </summary>
        PositionMsg0005 = 3075005

        ''' <summary>
        ''' 入力された役職コードは他の役職により既に使用されています。
        ''' </summary>
        PositionMsg0006 = 3075006

        ''' <summary>
        ''' 権限レベルは 0 以上の正の整数を入力してください。
        ''' </summary>
        PositionMsg0007 = 3075007

        ''' <summary>
        ''' 役職コードは半角英数字で入力してください。
        ''' </summary>
        PositionMsg0008 = 3075008

        ''' <summary>
        ''' 代理権限を選択してください。
        ''' </summary>
        ProxyMsg0001 = 3076001

        ''' <summary>
        ''' 有効期限日付に有効開始日付より小さな日付を選択することはできません。
        ''' </summary>
        ProxyMsg0002 = 3076002

        ''' <summary>
        ''' 同一ユーザーで同じ代理権限を選択することはできません。
        ''' </summary>
        ProxyMsg0003 = 3076003

        ''' <summary>
        ''' 組織またグループを選択することはできません。
        ''' </summary>
        MuitlSelMsg01 = 3076004

        ''' <summary>
        ''' ユーザーが重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        MuitlSelMsg02 = 3076005

    End Enum

#End Region

#Region " VMNU "

    ''' <summary>
    ''' VMNU プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VMNU]

        '''' <summary>
        '''' 入力したユーザーが存在しません。
        '''' </summary>
        '''' <remarks></remarks>
        'LoginNoUser = 3080001


        '''' <summary>
        '''' 入力したパスワードが正しくありません。
        '''' </summary>
        '''' <remarks></remarks>
        'LoginUnPass = 3080002

        ''' <summary>
        ''' 編集権限がありません。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoAuth = 3080003

        '''' <summary>
        '''' AD認証に失敗しました。
        '''' </summary>
        '''' <remarks></remarks>
        'LoginNoAd = 3080004

        ''' <summary>
        ''' 所属がありません。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNotBelong = 3080005

        '''' <summary>
        '''' AD認証時ローカルログインできるのは管理者のみです。
        '''' </summary>
        '''' <remarks></remarks>
        'LoginAdLoacal = 3080006

        ''' <summary>
        ''' 組織改編処理が完了しない状態で改編日を迎えているため、ログインできません。{0}ログインできるのは管理者のみです。
        ''' </summary>
        ''' <remarks></remarks>
        LoginDateInReorganization = 3080007

        ''' <summary>
        ''' 組織改編処理が完了しない状態で改編日を迎えているため、ログインできません。{0}管理者に問い合わせて下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LoginDateInReorganizationByWeb = 3080008

        ''' <summary>
        ''' ユーザー情報を取得できません。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoUserInformation = 3080009

        ''' <summary>
        ''' 文書を参照する権限が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoReadDocPermission = 3080010

        ''' <summary>
        ''' メールを受け取ったのと同じ社員番号でWindowsへログインしなおして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoMatchMailUser = 3080011

        ''' <summary>
        ''' 本人のカードを使用するか、本人の社員番号でWindowsへログインしなおして下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoMatchGAUser = 3080012

        ''' <summary>
        '''指定されたフォームを参照する権限が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoShowFormPermission = 3080013


        ''' <summary>
        '''異動などの理由により文書を開く権限がなくなっています。{0} 業務上必要な場合は管理者までご連絡下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LoginNoSysBlg = 3080014

        ''' <summary>
        '''キャビネットのパスワードが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        NotCabPass = 3080015


        ''' <summary>
        '''キャビネットパスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        MissCabPass = 3080016

        ''' <summary>
        '''正しい開始月(数字)を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstChk = 3080017


        ''' <summary>
        '''数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstNMChk = 3080018


        ''' <summary>
        '''期名称を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MooNmtrmChk = 3080019


        ''' <summary>
        '''開始月が、重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        MooVltrmstDupChk = 3080020

        ''' <summary>
        '''期名称が、重複しています。
        ''' </summary>
        ''' <remarks></remarks>
        MooNmtrmDupChk = 3080021

        ''' <summary>
        '''対象日を正しい日付で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DayHolidayChk = 3080022

        ''' <summary>
        '''対象日をカレンダーから選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DayHolidayChk2 = 3080023

        ''' <summary>
        '''対象データが一件もありません。
        ''' </summary>
        ''' <remarks></remarks>
        DayNotData = 3080024

        ''' <summary>
        '''年号のNoを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        YerNoNull = 3080025

        ''' <summary>
        '''年号の名称を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        YerNMERANull = 3080026

        ''' <summary>
        '''年号の開始日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        YerVLSTDateChk = 3080027

        ''' <summary>
        '''年号の終了日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        YerEraVLEDDateChk = 3080028

        ''' <summary>
        '''１ページ表示件数を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViewCountChk = 3080029

        ''' <summary>
        '''正しい最大表示件数を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViewMaxCountChk = 3080030

        ''' <summary>
        '''作業用ホルダーを入力して下さい。{0}{0}最大１０００まで設定可能です。
        ''' </summary>
        ''' <remarks></remarks>
        RidocWorkFolderChk = 3080031

        ''' <summary>
        '''メールサーバーを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MailServerChk = 3080032

        ''' <summary>
        '''IISサーバーを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IISServerAddChk = 3080033

        ''' <summary>
        '''AD使用ユーザ取得ドメイン名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AdUseDomainUserChk = 3080034

        ''' <summary>
        '''AD使用グループ取得ドメイン名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AdUseDomainGrpChk = 3080035

        ''' <summary>
        '''DB接続文字列を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DbConnectStringChk = 3080036

        ''' <summary>
        '''ログ期日を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeChk = 3080037

        ''' <summary>
        '''管理者パスワードを正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AdminiPassChk = 3080038

        ''' <summary>
        '''システム開始日付を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AdminYDMChk = 3080039

        ''' <summary>
        '''項目を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        InCreChk = 3080040

        ''' <summary>
        '''管理システムは他のユーザが使用中です。{0}アプリケーションを終了します。
        ''' </summary>
        ''' <remarks></remarks>
        UsedAnotherUser = 3080041

        ''' <summary>
        '''開始月は１～１２の整数で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MonthOutOfRange = 3080042

        ''' <summary>
        '''開始月を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        TermOutOfRange = 3080043

        ''' <summary>
        '''ログ保存月数を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeMustInput = 3080044

        ''' <summary>
        '''ログ保存月数は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeNumericOnly = 3080045

        ''' <summary>
        '''ログ保存月数を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        LogLifeArgumentOutOfRange = 3080046

        ''' <summary>
        '''メールアドレス・名称を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MailAddressMustInput = 3080047

        ''' <summary>
        '''メールサーバーを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MailServerMustInput = 3080048

        ''' <summary>
        '''１ページの表示件数を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocCountMustInput = 3080049

        ''' <summary>
        '''１ページの表示件数は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        DocCountNumericOnly = 3080050

        ''' <summary>
        '''１ページの表示件数を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        DocCountArgumentOutOfRange = 3080051

        ''' <summary>
        '''最大表示件数を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountMustInput = 3080052

        ''' <summary>
        '''最大表示件数は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountNumericOnly = 3080053

        ''' <summary>
        '''最大表示件数を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountArgumentOutOfRange = 3080054

        ''' <summary>
        '''最大表示件数は1000件以上は指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        MaxCountOverflow = 3080055


        ''' <summary>
        '''作成の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ActionMakeMustInput = 3080056


        ''' <summary>
        '''審査の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ActionAcceptMustInput = 3080057


        ''' <summary>
        '''承認の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ActionSubmitMustInput = 3080058

        ''' <summary>
        '''否認の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ActionDenyMustInput = 3080059
        ''' <summary>
        '''差戻しの項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ActionRemandMustInput = 3080060

        ''' <summary>
        '''作成文書の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        MakeButtonCaptionMustInput = 3080061

        ''' <summary>
        '''審査すべき文書の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AcceptButtonCaptionMustInput = 3080062

        ''' <summary>
        '''一括審査の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        AllAcceptButtonCaptionMustInput = 3080063

        ''' <summary>
        '''承認すべき文書の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SubmitButtonCaptionMustInput = 3080064

        ''' <summary>
        '''差戻し文書の項目名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RemandButtonCaptionMustInput = 3080065

        ''' <summary>
        '''作成中の回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularDraftMustInput = 3080066

        ''' <summary>
        '''承認待ちの回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularAcceptMustInput = 3080067

        ''' <summary>
        '''承認の回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularSubmitMustInput = 3080068

        ''' <summary>
        '''否認の回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularDenyMustInput = 3080069

        ''' <summary>
        '''差戻しの回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularRemandMustInput = 3080070

        ''' <summary>
        '''改訂中の回覧状態を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        CircularDraftRevisionMustInput = 3080071

        ''' <summary>
        '''データ最適化の開始時間を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourMustInput = 3080072

        ''' <summary>
        '''テータ最適化の開始時間は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourNumericOnly = 3080073

        ''' <summary>
        '''データ最適化の開始時間を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SwatHourArgumentOutOfRange = 3080074

        ''' <summary>
        '''データ最適化の開始時間を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteMustInput = 3080075

        ''' <summary>
        '''テータ最適化の開始時間は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteNumericOnly = 3080076

        ''' <summary>
        '''データ最適化の開始時間を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        SwatMinuteArgumentOutOfRange = 3080077

        ''' <summary>
        '''滞留処理開始時間を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourMustInput = 3080078

        ''' <summary>
        '''滞留処理開始時間は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourNumericOnly = 3080079

        ''' <summary>
        '''滞留処理開始時間を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionHourArgumentOutOfRange = 3080080

        ''' <summary>
        '''滞留処理開始時間を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteMustInput = 3080081

        ''' <summary>
        '''滞留処理開始時間は数値項目です。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteNumericOnly = 3080082

        ''' <summary>
        '''滞留処理開始時間を正しく入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        RetentionMinuteArgumentOutOfRange = 3080083

        ''' <summary>
        '''パスワードが一致しません。{0}両方に新しいパスワードを入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        TwoPasswordDonotMuch = 3080084

        ''' <summary>
        '''システム開始日付が不正です。{0}正しい日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnknownSystemDate = 3080085

        ''' <summary>
        '''全社表示名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ZensyaDispMustInput = 3080086

        ''' <summary>
        '''各局表示名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        KakukyokuDispMustInput = 3080087

        ''' <summary>
        '''只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3080088

        ''' <summary>
        '''取込対象のファイルが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedDenpo = 3080089

        ''' <summary>
        '''取込対象のファイルが足りません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectDenpoFile = 3080090

        ''' <summary>
        '''取込プログラムが選択されていません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectDenpo = 3080091

        ''' <summary>
        '''電報発行に使用するファイルより多く設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        SelectDenpoFileNo = 3080092


        ''' <summary>
        '''販売 人事取込プログラムが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NonProgramMessage = 3080093

        ''' <summary>
        '''メールの件名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonSubjectMessage = 3080094

        ''' <summary>
        '''メールの内容を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonBodyMessage = 3080095

        ''' <summary>
        '''設定値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NonValueMessage = 3080096

        ''' <summary>
        '''アカウントをロックするまでの回数が不正です。{0}１回以上を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationAccountLockNumber = 3080097

        ''' <summary>
        '''有効期限の月数が不正です。{0}１ヶ月以上を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationLimitNumber = 3080098

        ''' <summary>
        '''パスワード長の最小桁数が不正です。{0}１文字以上20文字以下を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMinLengthPassword = 3080099

        ''' <summary>
        '''パスワード長の最大桁数が不正です。{0}１文字以上20文字以下を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMaxLengthPassword = 3080100

        ''' <summary>
        '''パスワード長の最小桁数と最大桁数の値が不正です。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationMinMaxLengthPassword = 3080101

        ''' <summary>
        '''同一文字の繰返し回数が不正です。{0}１文字以上を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationRepeatCharPassword = 3080102

        ''' <summary>
        '''パスワードの履歴回数が不正です。{0}１回以上を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationHistoryPassword = 3080103

        ''' <summary>
        '''禁則文字を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        ViolationWrapString = 3080104

        ''' <summary>
        '''接続先のサーバーが設定されていません。{0}環境設定より初期設定を行ってください。
        ''' </summary>
        ''' <remarks></remarks>
        ServerWasNotSet = 3080105

        ''' <summary>
        ''' ユーザーＩＤを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputLoginUser = 3080106

        ''' <summary>
        ''' パスワードを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputPassword = 3080107

        ''' <summary>
        ''' 期首月を変更します。
        ''' 登録していない休日設定は無効になります。
        ''' </summary>
        ''' <remarks></remarks>
        StartMonthChange = 3080108

        ''' <summary>
        ''' サーバーを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        SelectServer = 3080109

        ''' <summary>
        ''' ドメインを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        SelectDomain = 3080110

        ''' <summary>
        ''' ユーザIDまたはパスワードが間違っています。
        ''' </summary>
        ''' <remarks></remarks>
        LoginFailed = 3080111

        ''' <summary>
        ''' 指定したフォームが公開されてない。
        ''' </summary>
        ''' <remarks></remarks>
        FormNotPublic = 3080112

        ''' <summary>
        ''' キーワードを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotInputKeyword = 3080113

        ''' <summary>
        ''' 単語が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        WordEmpty = 3080114

        ''' <summary>
        ''' キーワードは既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        ExistKeyword = 3080115

    End Enum

#End Region

#Region " VRTE "

    ''' <summary>
    ''' VRTE プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTE]

        ''' <summary>
        ''' デフォルトルートは削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE001 = 3090001

        ''' <summary>
        ''' 入力された値が正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE002 = 3090002

        ''' <summary>
        ''' 起案ルートが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE003 = 3090003

        ''' <summary>
        ''' 条件分岐で終わるルートは作成できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE004 = 3090004

        ''' <summary>
        ''' 申請できるのは、起案ルートならびに階層ルートの人だけです。
        ''' </summary>
        ''' <remarks></remarks>
        routeE005 = 3090005

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE006 = 3090006

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE007 = 3090007

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE008 = 3090008

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE009 = 3090009

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE010 = 3090010

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE011 = 3090011

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE012 = 3090012

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE013 = 3090013

        ''' <summary>
        ''' 親ルートに条件分岐が割り当てられているため、ルート単体を関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE014 = 3090014

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE015 = 3090015

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE016 = 3090016

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE017 = 3090017

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE018 = 3090018

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE019 = 3090019

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE020 = 3090020

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE021 = 3090021

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE022 = 3090022

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE023 = 3090023

        ''' <summary>
        ''' 親ルートに条件分岐が割り当てられているため、ルート単体を関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE024 = 3090024

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE025 = 3090025

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE026 = 3090026

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE027 = 3090027

        ''' <summary>
        ''' 条件分岐の並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE028 = 3090028

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE029 = 3090029

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE030 = 3090030

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE031 = 3090031

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE032 = 3090032

        ''' <summary>
        ''' 条件分岐からグループへの設定はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE033 = 3090033

        ''' <summary>
        ''' 条件分岐（真）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE034 = 3090034

        ''' <summary>
        ''' 条件分岐（偽）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE035 = 3090035

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE036 = 3090036

        ''' <summary>
        ''' 条件分岐（真）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE037 = 3090037

        ''' <summary>
        ''' 条件分岐（偽）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE038 = 3090038

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE039 = 3090039

        ''' <summary>
        ''' 起案ルートは変更できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE040 = 3090040

        ''' <summary>
        ''' 起案ルートは変更できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE041 = 3090041

        ''' <summary>
        ''' 選択された組織に組織情報が存在しません。プログラムを再起動して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE042 = 3090042

        ''' <summary>
        ''' 組織・グループを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        routeE043 = 3090043

        ''' <summary>
        ''' 利用グループを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE044 = 3090044

        ''' <summary>
        ''' カテゴリが選択されています。フォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE045 = 3090045

        ''' <summary>
        ''' 同一フォームは選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE046 = 3090046

        ''' <summary>
        ''' 削除するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE047 = 3090047

        ''' <summary>
        ''' ルート名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE048 = 3090048

        ''' <summary>
        ''' ルート開始日付がルート終了日付より未来に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE049 = 3090049

        ''' <summary>
        ''' 既に登録済みです。別の項目を登録して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE050 = 3090050

        ''' <summary>
        ''' 最後の承認者は、申請権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE051 = 3090051

        ''' <summary>
        ''' 最後の承認者は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE052 = 3090052

        ''' <summary>
        ''' 条件分岐が設定されている場合は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE053 = 3090053

        ''' <summary>
        ''' 並行承認が設定されている場合は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE054 = 3090054

        ''' <summary>
        ''' 条件分岐に条件が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE055 = 3090055

        ''' <summary>
        ''' 桁数がオーバーしています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE056 = 3090056

        ''' <summary>
        ''' 数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE057 = 3090057

        ''' <summary>
        ''' yyyy/mm/dd形式で日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE058 = 3090058

        ''' <summary>
        ''' 必須項目です。
        ''' </summary>
        ''' <remarks></remarks>
        routeE059 = 3090059

        ''' <summary>
        ''' 最終承認での並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE060 = 3090060

        ''' <summary>
        ''' 並行承認での同一役職を割り当てることはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE061 = 3090061

        ''' <summary>
        ''' 関連付いていないルートが存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE062 = 3090062

        ''' <summary>
        ''' 実数の範囲をオーバーしてます。{0}922,337,203,685,477.5807 ～ -922,337,203,685,477.5808の範囲で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE063 = 3090063

        ''' <summary>
        ''' 整数の範囲をオーバーしてます。{0}2,147,483,647 ～ -2,147,483,648の範囲で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE064 = 3090064

        ''' <summary>
        ''' 小数の入力はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE065 = 3090065

        ''' <summary>
        ''' 組織と役職が起案者と同じルートは指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE066 = 3090066

        ''' <summary>
        ''' 本人は起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE067 = 3090067

        ''' <summary>
        ''' 作成者ルート以外起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE068 = 3090068

        ''' <summary>
        ''' 本人を含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE069 = 3090069

        ''' <summary>
        ''' 同一人物の並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE070 = 3090070

        ''' <summary>
        ''' 条件分岐もしくは複数承認後の申請区分は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE071 = 3090071

        ''' <summary>
        ''' 関連付いていない条件分岐が存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE072 = 3090072

        ''' <summary>
        ''' ２バイト文字が含まれています。２バイト文字は入力できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE073 = 3090073

        ''' <summary>
        ''' 桁数が超えています。有効桁数は11桁までです。
        ''' </summary>
        ''' <remarks></remarks>
        routeE074 = 3090074

        ''' <summary>
        ''' カンマの入力はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE075 = 3090075

        ''' <summary>
        ''' 入力形式に誤りがあります。{0}-9999999999の形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE076 = 3090076

        ''' <summary>
        ''' 無効な条件が設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE077 = 3090077

        ''' <summary>
        ''' ２０バイトを超える文字は条件分岐では設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE078 = 3090078

        ''' <summary>
        ''' 自由指定を含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE079 = 3090079

        ''' <summary>
        ''' 只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3090080

        ''' <summary>
        ''' 自由指定は起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNot1stSetFreeRoute = 3090081

        ''' <summary>
        ''' 条件分岐を含む自由指定ルートは設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        NotExecuteFreeRouteWithCondition = 3090082

        ''' <summary>
        ''' 自由指定を関連付けることはできません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectFreeRoute = 3090083

    End Enum

#End Region

#Region " VRUN "

    ''' <summary>
    ''' VRUN プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRUN]

        ''' <summary>
        ''' デフォルトルートは削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE001 = 3100001

        ''' <summary>
        ''' 入力された値が正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE002 = 3100002

        ''' <summary>
        ''' 起案ルートが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE003 = 3100003

        ''' <summary>
        ''' 条件分岐で終わるルートは作成できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE004 = 3100004

        ''' <summary>
        ''' 申請できるのは、起案ルートならびに階層ルートの人だけです。
        ''' </summary>
        ''' <remarks></remarks>
        routeE005 = 3100005

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE006 = 3100006

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE007 = 3100007

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE008 = 3100008

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE009 = 3100009

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE010 = 3100010

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE011 = 3100011

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE012 = 3100012

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE013 = 3100013

        ''' <summary>
        ''' 親ルートに条件分岐が割り当てられているため、ルート単体を関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE014 = 3100014

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE015 = 3100015

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE016 = 3100016

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE017 = 3100017

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE018 = 3100018

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE019 = 3100019

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE020 = 3100020

        ''' <summary>
        ''' グループを含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE021 = 3100021

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE022 = 3100022

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE023 = 3100023

        ''' <summary>
        ''' 親ルートに条件分岐が割り当てられているため、ルート単体を関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE024 = 3100024

        ''' <summary>
        ''' 起案ルートが既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE025 = 3100025

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE026 = 3100026

        ''' <summary>
        ''' 条件分岐に関連付けられているため、ルート単体には関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE027 = 3100027

        ''' <summary>
        ''' 条件分岐の並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE028 = 3100028

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE029 = 3100029

        ''' <summary>
        ''' 親ルートが既に他の承認順に割り当てられているため、関連付けできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE030 = 3100030

        ''' <summary>
        ''' 起案ルートに関連付けはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE031 = 3100031

        ''' <summary>
        ''' 役職上、承認権限なしの場合は起案ルートのみ設定できます。
        ''' </summary>
        ''' <remarks></remarks>
        routeE032 = 3100032

        ''' <summary>
        ''' 条件分岐からグループへの設定はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE033 = 3100033

        ''' <summary>
        ''' 条件分岐（真）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE034 = 3100034

        ''' <summary>
        ''' 条件分岐（偽）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE035 = 3100035

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE036 = 3100036

        ''' <summary>
        ''' 条件分岐（真）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE037 = 3100037

        ''' <summary>
        ''' 条件分岐（偽）の子ルートは既に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE038 = 3100038

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE039 = 3100039

        ''' <summary>
        ''' 結合ルートの起案ルートは変更できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE040 = 3100040

        ''' <summary>
        ''' 結合ルートの起案ルートは変更できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE041 = 3100041

        ''' <summary>
        ''' 選択された組織に組織情報が存在しません。プログラムを再起動して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE042 = 3100042

        ''' <summary>
        ''' ルート共有するグループをリストから選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE043 = 3100043

        ''' <summary>
        ''' 利用グループを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE044 = 3100044

        ''' <summary>
        ''' カテゴリが選択されています。フォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE045 = 3100045

        ''' <summary>
        ''' 同一フォームは選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE046 = 3100046

        ''' <summary>
        ''' 削除するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE047 = 3100047

        ''' <summary>
        ''' ルート名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE048 = 3100048

        ''' <summary>
        ''' ルート開始日付がルート終了日付より未来に設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE049 = 3100049

        ''' <summary>
        ''' 既に登録済みです。別の項目を登録して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE050 = 3100050

        ''' <summary>
        ''' 最後の承認者は、申請権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE051 = 3100051

        ''' <summary>
        ''' 最後の承認者は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE052 = 3100052

        ''' <summary>
        ''' 条件分岐が設定されている場合は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE053 = 3100053

        ''' <summary>
        ''' 並行承認が設定されている場合は、飛越し権限を付与できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE054 = 3100054

        ''' <summary>
        ''' 条件分岐に条件が設定されていません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE055 = 3100055

        ''' <summary>
        ''' 桁数がオーバーしています。
        ''' </summary>
        ''' <remarks></remarks>
        routeE056 = 3100056

        ''' <summary>
        ''' 数値を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE057 = 3100057

        ''' <summary>
        ''' yyyy/mm/dd形式で日付を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE058 = 3100058

        ''' <summary>
        ''' 必須項目です。
        ''' </summary>
        ''' <remarks></remarks>
        routeE059 = 3100059

        ''' <summary>
        ''' 最終承認での並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE060 = 3100060

        ''' <summary>
        ''' 並行承認での同一役職を割り当てることはできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE061 = 3100061

        ''' <summary>
        ''' 関連付いていないルートが存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE062 = 3100062

        ''' <summary>
        ''' 実数の範囲をオーバーしてます。{0}922,337,203,685,477.5807 ～ -922,337,203,685,477.5808の範囲で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE063 = 3100063

        ''' <summary>
        ''' 整数の範囲をオーバーしてます。{0}2,147,483,647 ～ -2,147,483,648の範囲で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE064 = 3100064

        ''' <summary>
        ''' 小数の入力はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE065 = 3100065

        ''' <summary>
        ''' 組織と役職が起案者と同じルートは指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE066 = 3100066

        ''' <summary>
        ''' 本人は起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE067 = 3100067

        ''' <summary>
        ''' 結合ルートでは作成者ルート以外起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE068 = 3100068

        ''' <summary>
        ''' 本人を含めた並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE069 = 3100069

        ''' <summary>
        ''' 同一人物の並行承認はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE070 = 3100070

        ''' <summary>
        ''' 条件分岐もしくは複数承認後の申請区分は設定できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE071 = 3100071

        ''' <summary>
        ''' 関連付いていない条件分岐が存在します。
        ''' </summary>
        ''' <remarks></remarks>
        routeE072 = 3100072

        ''' <summary>
        ''' ２バイト文字が含まれています。２バイト文字は入力できません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE073 = 3100073

        ''' <summary>
        ''' 桁数が超えています。有効桁数は11桁までです。
        ''' </summary>
        ''' <remarks></remarks>
        routeE074 = 3100074

        ''' <summary>
        ''' カンマの入力はできません。
        ''' </summary>
        ''' <remarks></remarks>
        routeE075 = 3100075

        ''' <summary>
        ''' 入力形式に誤りがあります。{0}-9999999999の形式で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        routeE076 = 3100076

        ''' <summary>
        ''' カテゴリは選択できません。
        ''' </summary>
        ''' <remarks>
        ''' ルート/フォーム割当画面--ツリービューよりカテゴリのノードが選択されていた場合
        ''' </remarks>
        MustNotCategorySelected = 3100077

        ''' <summary>
        ''' 追加するルートを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' ルート割当画面で割当てるべきルートデータがツリーより選択されていない場合
        ''' </remarks>
        AddRouteUnSelected = 3100078

        ''' <summary>
        ''' 削除するルートを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' ルート割当画面で削除するべきルートデータがリストビューより選択されていない場合
        ''' </remarks>
        RemoveRouteUnSelected = 3100079

        ''' <summary>
        ''' すでに同じルートが選択されています。
        ''' </summary>
        ''' <remarks>
        ''' ルート割当画面で選択ルートデータがすでに割当データとして選択されている場合
        ''' </remarks>
        SameRouteExist = 3100080

        ''' <summary>
        ''' 追加するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当画面で割当てるべきフォームデータがツリーより選択されていない場合
        ''' </remarks>
        AddFormUnSelected = 3100081

        ''' <summary>
        ''' 削除するフォームを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当画面で削除するべきフォームデータがリストビューより選択されていない場合
        ''' </remarks>
        RemoveFormUnSelected = 3100082

        ''' <summary>
        ''' すでに同じフォームが選択されています。
        ''' </summary>
        ''' <remarks>
        ''' フォーム割当画面で選択フォームデータがすでに割当データとして選択されている場合
        ''' </remarks>
        SameFormExist = 3100083

        ''' <summary>
        ''' ビューの名を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' ビューメンテナンス画面新規作成時にビュー名称が指定されていない場合
        ''' </remarks>
        SetNoViewName = 3100084

        ''' <summary>
        ''' 出力する項目を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' ビューメンテナンス画面にて出力項目が１件も指定されていない場合
        ''' </remarks>
        SetNoViewColumn = 3100085

        ''' <summary>
        ''' 数値を入力して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 数値入力項目に文字列が混在する場合
        ''' </remarks>
        UnNumeric = 3100086

        ''' <summary>
        ''' 採番を行う際の有効桁数は1～10桁です。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--採番項目入力部有効桁数の制御
        ''' </remarks>
        VlDocNoFigOver10 = 3100087

        ''' <summary>
        ''' 採番項目に指定可能な項目は20項目までです。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--採番項目入力項目が20項目以上指定されている場合
        ''' </remarks>
        DocColStructOver20 = 3100088

        ''' <summary>
        ''' 採番項目に連番を登録して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--採番項目入力項目に連番が指定されていない場合
        ''' </remarks>
        DocColStructNoCounter = 3100089

        ''' <summary>
        ''' 採番項目の削除はできません。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--採番項目入力項目を削除しようとした場合
        ''' </remarks>
        DocColStructCounterNotDelete = 3100090

        ''' <summary>
        ''' 承認時保存先は必須入力です。{0}保存先を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--承認時保存先の必須入力チェック
        ''' </remarks>
        SetFullPassLblNmPubDoc = 3100091

        ''' <summary>
        ''' 否認時保存先は必須入力です。{0}保存先を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定--承認時保存先の必須入力チェック
        ''' </remarks>
        SetFullPassLblNmNyDoc = 3100092

        ''' <summary>
        ''' カテゴリ名を入力して下さい。
        ''' </summary>
        ''' <remarks>
        ''' カテゴリ作成画面--カテゴリ名称に入力が無い場合
        ''' </remarks>
        UnInputCategoryName = 3100093

        ''' <summary>
        ''' 表示順序を入力して下さい。
        ''' </summary>
        ''' <remarks>
        ''' カテゴリ作成画面--表示順序に入力が無い場合
        ''' </remarks>
        UnInputCategoryDispNo = 3100094

        ''' <summary>
        ''' カテゴリを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' カテゴリ作成画面--表示順序に入力が無い場合
        ''' </remarks>
        CategoryUnSelcted = 3100095

        ''' <summary>
        ''' 入力可能な範囲を超えています。
        ''' </summary>
        ''' <remarks>
        ''' カテゴリ作成画面--表示順の指定が範囲値で無かった場合
        ''' </remarks>
        OverRange = 3100096

        ''' <summary>
        ''' 現在このフォームは使用中です。削除できません。
        ''' </summary>
        ''' <remarks>
        ''' フォーム削除時、当該フォームが実行中であった場合
        ''' </remarks>
        FormExecutingNotDelte = 3100097

        ''' <summary>
        ''' フォームの名を入力して下さい。
        ''' </summary>
        ''' <remarks>
        ''' フォームコピー画面にてフォーム名の入力が無い場合
        ''' </remarks>
        UnInputFormName = 3100098

        ''' <summary>
        ''' このルートは条件分岐を保持します。{0}他のフォームと併用したり、使用フォームを変更することは出来ません。{0}使用フォームの変更をする場合は『ルート修正』ボタンをクリックし、{0}このルートを条件分岐の無い状態にして下さい。
        ''' </summary>
        ''' <remarks>
        ''' 条件分岐を保持するルートの使用フォームを変更しようとした場合
        ''' </remarks>
        RuteHasBranch = 3100099

        ''' <summary>
        ''' 選択されたルートは条件分岐に他のフォームの項目が指定されています。{0}このフォームで使用することはできません。
        ''' </summary>
        ''' <remarks>
        ''' 条件分岐を保持するルートの使用フォームを変更しようとした場合
        ''' </remarks>
        SelectedRuteHasBranch = 3100100

        ''' <summary>
        ''' 選択されたルートは条件分岐にこのフォームの項目が指定されています。{0}削除することはできません。{0}削除する場合はメイン画面の『ルート修正』ボタンをクリックし、{0}このルートを条件分岐の無い状態にして下さい。
        ''' </summary>
        ''' <remarks>
        ''' 条件分岐を保持する使用ルートを削除しようとした場合
        ''' </remarks>
        RemoveRuteHasBranch = 3100101

        ''' <summary>
        ''' 滞留期間の入力は１営業日以上を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 滞留期間の営業日の入力が 0(営業日)以下である場合
        ''' </remarks>
        OverRengeVlttl = 3100102

        ''' <summary>
        ''' Ridoc連携で文書プロパティ設定の登録を行って下さい。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定画面の「登録」ボタン押下時、文書プロパティ設定が登録されているかのチェック時
        ''' </remarks>
        DocNotAddPropatyChk = 3100103

        ''' <summary>
        ''' フォームを公開中の為、削除できませんでした。
        ''' </summary>
        ''' <remarks>
        ''' 運用設定画面で、フォームを「◎公開する」に設定しているときは、ルートフォーム画面から、削除チェックをする
        ''' </remarks>
        FailedNotDelete = 3100104

        ''' <summary>
        ''' 選択されたキャビネットのパスワードを設定画面で登録して下さい。
        ''' </summary>
        ''' <remarks>
        ''' キャビネット選択時パスワードが未登録の時
        ''' </remarks>
        CabPassNotRegistration = 3100105

        ''' <summary>
        ''' 保存先を指定して下さい。
        ''' </summary>
        ''' <remarks>
        ''' フォルダ一覧TreeViewでノード未選択状態でOKボタンクリック時
        ''' </remarks>
        CabinetNotSelected = 3100106

        ''' <summary>
        ''' 任意文字列は半角英数で入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        UnjustTxtFree = 3100107

        ''' <summary>
        ''' 連携するプロパティを選択して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 文書タイプ設定時に全て”設定する”の状態で文書プロパティが未選択もしくは””の時
        ''' </remarks>
        DocPropNotSelected = 3100108

        ''' <summary>
        ''' 書込み対象プロパティが重複しています。
        ''' </summary>
        ''' <remarks>
        ''' 文書タイプ設定時に全て”書込み”設定されている文書プロパティが重複してる時
        ''' </remarks>
        DocPropDuplication = 3100109

        ''' <summary>
        ''' Ridocプロパティ「文書名」への「書込み設定」は必須です。{0}フォームに貼付してある項目を、Ridocプロパティ「文書名」に「書込み設定」して下さい。
        ''' </summary>
        ''' <remarks>
        ''' 文書プロパティ「文書名」への「書込み」が未設定の時
        ''' </remarks>
        DocNamePropNonSet = 3100110

        ''' <summary>
        ''' 選択された文書プロパティは予約プロパティが設定されていません。
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe 予約プロパティが設定されていない文書プロパティを選択した時
        ''' </remarks>
        DocPropNonSet = 3100111

        ''' <summary>
        ''' 文書管理ツールにて文書タイプの登録を行って下さい。
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe ユーザー設定文書プロパティが存在しない時
        ''' </remarks>
        DocTypeNonSet = 3100112

        ''' <summary>
        ''' 印刷設定位置が重複しています。
        ''' </summary>
        ''' <remarks>
        ''' 2003/09/09 Add watanobe ユーザー設定文書プロパティが存在しない時
        ''' </remarks>
        PrintDataDuplication = 3100113

        ''' <summary>
        ''' 回答期限を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimit = 3100114

        ''' <summary>
        ''' 回答期限の入力は1営業日以上を指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        ReplyLimitOutOfRange = 3100115

        ''' <summary>
        ''' 終端は起案ルートに指定できません。
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E001 = 3100116

        ''' <summary>
        ''' 終端から次のルート指定する事は出来ません
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E010 = 3100117

        ''' <summary>
        ''' 条件分岐以外から終端を次のルートに指定する事は出来ません
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E011 = 3100118

        ''' <summary>
        ''' 既に関連付けされています。
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E020 = 3100119

        ''' <summary>
        ''' 無効な条件が設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        RUN_E110 = 3100120

        ''' <summary>
        ''' 只今、組織改編中です。しばらく経った後、再度実行して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Reorganization = 3100121

    End Enum

#End Region

#Region " VFAX "

    ''' <summary>
    ''' VFAX プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VFAX]

        ''' <summary>
        ''' テンプレートのため後で削除してください。
        ''' </summary>
        ''' <remarks></remarks>
        Temp = 3110000

    End Enum

#End Region

#Region " VALP "

    ''' <summary>
    ''' VALP プロジェクトの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VALP]

        ''' <summary>
        ''' ［送信元メールアドレス］が［既定の送信者］に設定されている場合、［送信元メールアドレス］は入力必須項目です。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 3120001

        ''' <summary>
        ''' ［送信元メールアドレス］の形式が正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0002 = 3120002

        ''' <summary>
        ''' 利用者の編集を許可しない場合、［件名］は入力必須項目です。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0003 = 3120003

        ''' <summary>
        ''' 利用者の編集を許可しない場合、［本文］は入力必須項目です。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0004 = 3120004

    End Enum

#End Region

#Region " RFGC "

    ''' <summary>
    ''' ビューエージェントの警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [RFGC]

        ''' <summary>
        ''' ビューの運用設定で一括メール送信の詳細設定が行われていないため、この画面からメールを送信することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotDetailSetting = 3130001

        ''' <summary>
        ''' メールの件名に複数の予約語を設定することはできません。
        ''' </summary>
        ''' <remarks></remarks>
        MultiReserveWork = 3130002

        ''' <summary>
        ''' 件名を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotInputMailSubject = 3130003

        ''' <summary>
        ''' 本文を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotInputMailBody = 3130004

    End Enum

#End Region

#Region " ACAB "

    ''' <summary>
    ''' R@bitFlow TextConverter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [ACAB]

        ''' <summary>
        ''' 接続するサーバーを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotServerSelected = 3140001

        ''' <summary>
        ''' 設定するＣＳＶフィールドを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoselectCsvField = 3140002

        ''' <summary>
        ''' 半角スペースのみの入力は出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        SpaceOnly = 3140003

        ''' <summary>
        ''' ＣＳＶファイルを正しく読込めません。
        ''' 項目区切り文字・行区切り文字・テキスト修飾子を確認しください。
        ''' </summary>
        ''' <remarks></remarks>
        ReadCsvFieldError = 3140004

        ''' <summary>
        ''' 正しい数値を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 3140005

        ''' <summary>
        ''' フォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedForm = 3140006

        ''' <summary>
        ''' フォーム形式「ワークフロー」には移行できません。
        ''' </summary>
        ''' <remarks></remarks>
        NoTransForm = 3140007

        ''' <summary>
        ''' 選択されたフォームには移行できるフィールドがありません。
        ''' </summary>
        ''' <remarks></remarks>
        SelectFormNoData = 3140008

        ''' <summary>
        ''' 移行情報を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectTrans = 3140009

        ''' <summary>
        ''' キーを１つ選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedKey = 3140010

        ''' <summary>
        ''' キーを複数選択することは出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        KeySelectedOnly = 3140011

        ''' <summary>
        ''' 選択したキーは移行する項目に含める必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        AbsoluteSelectedKey = 3140012

        ''' <summary>
        ''' ログ出力項目として設定できるのは３フィールドまでです。
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyOverCount = 3140013

        ''' <summary>
        ''' 所属を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectGroup = 3140014

        ''' <summary>
        ''' 作成者を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectCreater = 3140015

        ''' <summary>
        ''' 正しい値を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 3140016

        ''' <summary>
        ''' 最大文字数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 3140017

        ''' <summary>
        ''' 有効な範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkRangeError = 3140018

        ''' <summary>
        ''' 正しい日付を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        chkDateError = 3140019

        ''' <summary>
        ''' 設定された日付のフォーマットに変換出来ません。
        ''' 設定値を確認し入力し直して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 3140020

        ''' <summary>
        ''' 有効日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 3140021

        ''' <summary>
        ''' 選択したフォーム定義ファイルの移行元のデータ種別が正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        MismatchedFile = 3140022

        ''' <summary>
        ''' ログインしているサーバと異なるサーバへの移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NoEqualTransServer = 3140023

        ''' <summary>
        ''' ログインしているサーバへのコピーはできません。
        ''' </summary>
        ''' <remarks></remarks>
        EqualTransServerError = 3140024

        ''' <summary>
        ''' {0}は、{1}には移行出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSetSubject = 3140025

        ''' <summary>
        ''' {0}を複数フィールドに移行することは来ません。
        ''' </summary>
        ''' <remarks></remarks>
        OneSelectNotesDocID = 3140026

        ''' <summary>
        ''' {0}, {1}以外で
        ''' 移行する項目を最低１つ以上選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldCountError = 3140027

        ''' <summary>
        ''' 保存できる定義ファイルの拡張子は.{0}のみです。
        ''' </summary>
        ''' <remarks></remarks>
        NoXMLFileType = 3140028

        ''' <summary>
        ''' コントロールマスタが見つかりません。
        ''' 連携オプションの環境設定タブで移行先サーバーを指定してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundEnvironmentSetting = 3140029

        ''' <summary>
        ''' 接続先のサーバーが設定されていません。
        ''' 環境設定ウィザードより初期設定を行ってください。
        ''' </summary>
        ''' <remarks></remarks>
        ServerWasNotSet = 3140030

        ''' <summary>
        ''' R@bitFlow サーバーを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputeRabitFlowServer = 3140031

        ''' <summary>
        ''' 検索する氏名を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotSearchName = 3140032

    End Enum

#End Region

#Region " VRTC "

    ''' <summary>
    ''' R@bitFlow TextConverter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRTC]

        ''' <summary>
        ''' ログの保存先を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputLogDir = 3150001

        ''' <summary>
        ''' ログの保存先が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundLogDir = 3150002

        ''' <summary>
        ''' 作業サーバーを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        SelectWorkServer = 3150003

        ''' <summary>
        ''' ユーザーＩＤを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputLoginId = 3150004

        ''' <summary>
        ''' パスワードを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputPassword = 3150005

        ''' <summary>
        ''' アーカイブフォルダを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputArchiveDir = 3150006

        ''' <summary>
        ''' アーカイブフォルダが見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundArchiveDir = 3150007

        ''' <summary>
        ''' データファイルの保存先を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputDataDir = 3150008

        ''' <summary>
        ''' トランザクションログファイルの保存先を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputTransactionLogDir = 3150009

        ''' <summary>
        ''' インスタンス名を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        InputNamedInstance = 3150010

        ''' <summary>
        ''' データファイルの保存先が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundDataDir = 3150011

        ''' <summary>
        ''' トランザクションログファイルの保存先が見つかりません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundTransactionLogDir = 3150012

        ''' <summary>
        ''' SQL Server に接続できません。
        ''' </summary>
        ''' <remarks></remarks>
        LocalServerConnectFailed = 3150013

    End Enum

#End Region

#Region " VRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VRAC]

        ''' <summary>
        ''' CSV 詳細設定画面で、選択または入力した CSV ファイルが存在しない場合のメッセージ。
        ''' </summary>
        Msg0001 = 3160001

        ''' <summary>
        ''' CSV 詳細設定画面で、重複したファイルを追加しようとした場合のメッセージ。
        ''' </summary>
        Msg0002 = 3160002

        ''' <summary>
        ''' CSV 詳細設定画面で、追加可能な件数を超えて連携ファイルを追加しようとした場合のメッセージ。
        ''' </summary>
        Msg0003 = 3160003

        ''' <summary>
        ''' CSV ファイル結合条件画面で、重複したファイルを追加しようとした場合のメッセージ。
        ''' </summary>
        Msg0004 = 3160004

        ''' <summary>
        ''' CSV ファイル結合条件画面で、選択したファイルが親ファイルの子ファイルに設定されている場合のメッセージ。
        ''' </summary>
        Msg0005 = 3160005

        ''' <summary>
        ''' CSV ファイル結合条件画面で、選択した子ファイルのフィールドが親ファイルの別のフィールドと既に結合している場合のメッセージ。
        ''' </summary>
        Msg0006 = 3160006

        ''' <summary>
        ''' 連携必須項目にフィールドが設定されていない場合のメッセージ。
        ''' </summary>
        Msg0007 = 3160007

        ''' <summary>
        ''' CSV フィールド結合条件画面で、結合条件が設定されていない場合のメッセージ。
        ''' </summary>
        Msg0008 = 3160008

        ''' <summary>
        ''' CSV 詳細設定画面で、関連付けするフィールドを持つファイルが、既に設定済みフィールドのファイルと結合していない場合のメッセージ。
        ''' </summary>
        Msg0009 = 3160009

        ''' <summary>
        ''' CSV ファイル結合条件画面で、選択した子ファイルが親ファイルのフィールドと連携項目に関連付けられている場合のメッセージ。
        ''' </summary>
        Msg0010 = 3160010

        ''' <summary>
        ''' 復元するバックアップが選択されていない場合のメッセージ。
        ''' </summary>
        Msg0011 = 3160011

        ''' <summary>
        ''' ログイン画面でユーザー ID が入力されていない場合のメッセージ。
        ''' </summary>
        Msg0012 = 3160012

        ''' <summary>
        ''' ログイン画面でパスワードが入力されていない場合のメッセージ。
        ''' </summary>
        Msg0013 = 3160013

        ''' <summary>
        ''' 作業フォルダが入力されていない場合のメッセージ。
        ''' </summary>
        Msg0014 = 3160014

        ''' <summary>
        ''' 入力された作業フォルダが存在しない場合のメッセージ。
        ''' </summary>
        Msg0015 = 3160015

        ''' <summary>
        ''' 登録時に連携ファイルが 1 件も追加されていない場合のメッセージ。
        ''' </summary>
        Msg0016 = 3160016

        ''' <summary>
        ''' 移動ファイルの保管期間が範囲を超えている場合のメッセージ。
        ''' </summary>
        Msg0017 = 3160017

    End Enum

#End Region

#Region " MRAC "

    ''' <summary>
    ''' R@bitFlow AccountConverter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [MRAC]

        ''' <summary>
        ''' 連携ファイルのレコードの取り込みに失敗した場合のメッセージ
        ''' </summary>
        Msg0001 = 3170001

        ''' <summary>
        ''' 一時テーブルへのレコード登録に失敗した場合のメッセージ
        ''' </summary>
        Msg0002 = 3170002

        ''' <summary>
        ''' CSV ファイルが見つからない場合のメッセージ
        ''' </summary>
        Msg0003 = 3170003

        ''' <summary>
        ''' 任意のレコードがマージに失敗した場合のメッセージ
        ''' </summary>
        Msg0004 = 3170004

        ''' <summary>
        ''' CSV ファイルから読み込んだ組織の有効開始日付が、上位組織の有効開始日付より小さいときの警告メッセージ
        ''' </summary>
        Msg0005 = 3170005

        ''' <summary>
        ''' CSV ファイルから読み込んだ組織の有効期限日付が、上位組織の有効期限日付より大きいときの警告メッセージ
        ''' </summary>
        Msg0006 = 3170006

        ''' <summary>
        ''' 所属する組織がグループの場合に、役職を（グループメンバ）に変更するときのメッセージ
        ''' </summary>
        Msg0007 = 3170007

    End Enum

#End Region

#Region " VANC "

    ''' <summary>
    ''' R@bitFlow NotesConveter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VANC]

        ''' <summary>
        '''選択されたnsfファイルには{0}移行できるフォームがありません。
        ''' </summary>
        ''' <remarks></remarks>
        SelectNsfNoForm = 3180001

        ''' <summary>
        '''選択されたフォームには{0}移行できるフィールドがありません。
        ''' </summary>
        ''' <remarks></remarks>
        SelectFormNoData = 3180002

        ''' <summary>
        '''選択されたnsfファイルには{0}移行できるデータがありません。
        ''' </summary>
        ''' <remarks></remarks>
        SelectNsfNoData = 3180003

        ''' <summary>
        '''接続するサーバーを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NotServerSelected = 3180004

        ''' <summary>
        '''パスワードが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        NotInputPassword = 3180005

        ''' <summary>
        '''ロータスノーツパスワードを確認できません。サーバーが使用できない可能性があります。
        ''' </summary>
        ''' <remarks></remarks>
        NotConnectederver = 3180006

        ''' <summary>
        '''保存できる定義ファイルの拡張子は.{0}のみです。
        ''' </summary>
        ''' <remarks></remarks>
        _NoXMLFileType = 3180007

        ''' <summary>
        '''定義ファイルを指定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedFilePath = 3180008

        ''' <summary>
        '''ノーツＤＢを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedNotesDB = 3180009

        ''' <summary>
        '''フォームを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectedForm = 3180010

        ''' <summary>
        '''ログ出力項目として設定できるのは{0}３フィールドまでです。
        ''' </summary>
        ''' <remarks></remarks>
        NotesKeyOverCount = 3180011

        ''' <summary>
        '''１フィールド以上を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectMappingInfo = 3180012

        ''' <summary>
        '''移行する項目を最低１つ以上選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldError = 3180013

        ''' <summary>
        '''移行情報を設定して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectTrans = 3180014

        ''' <summary>
        '''設定するノーツフィールドを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectNotesField = 3180015

        ''' <summary>
        '''設定するＣＳＶフィールドを選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoselectCsvField = 3180016

        ''' <summary>
        '''ＣＳＶファイルを正しく読込めません。{0}項目区切り文字・行区切り文字・テキスト修飾子を確認しください。
        ''' </summary>
        ''' <remarks></remarks>
        ReadCsvFieldError = 3180017

        ''' <summary>
        '''所属を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectGroup = 3180018

        ''' <summary>
        '''作成者を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectCreater = 3180019

        ''' <summary>
        '''半角スペースのみの入力は出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        SpaceOnly = 3180020

        ''' <summary>
        '''正しい値を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        chkStringError = 3180021

        ''' <summary>
        '''最大文字数を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkFigureError = 3180022

        ''' <summary>
        '''初期値は半角数字のみ設定可能です。
        ''' </summary>
        ''' <remarks></remarks>
        chkIntegerError = 3180023

        ''' <summary>
        '''有効な範囲を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        chkRangeError = 3180024

        ''' <summary>
        '''正しい日付を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        chkDateError = 3180025

        ''' <summary>
        '''設定された日付のフォーマットに変換出来ません。{0}設定値を確認し入力し直して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateFormatError = 3180026

        ''' <summary>
        '''有効日付を超えています。
        ''' </summary>
        ''' <remarks></remarks>
        IsDenyDateError = 3180027

        ''' <summary>
        '''項目区切り文字と行区切り文字に同じ区切り文字を指定することは出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        SameSeparatorError = 3180028

        ''' <summary>
        '''キーを１つ選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedKey = 3180029

        ''' <summary>
        '''キーを複数選択することは出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        KeySelectedOnly = 3180030

        ''' <summary>
        '''選択したキーは移行する項目に含める必要があります。
        ''' </summary>
        ''' <remarks></remarks>
        AbsoluteSelectedKey = 3180031

        ''' <summary>
        '''選択したフォーム定義ファイルの移行元のデータ種別が正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        MismatchedFile = 3180032

        ''' <summary>
        '''ログインしているサーバと異なるサーバへの移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NoEqualTransServer = 3180033

        ''' <summary>
        '''ログインしているサーバへのコピーはできません。
        ''' </summary>
        ''' <remarks></remarks>
        EqualTransServerError = 3180034

        ''' <summary>
        '''フォーム形式「ワークフロー」には移行できません。
        ''' </summary>
        ''' <remarks></remarks>
        NoTransForm = 3180035

        ''' <summary>
        '''保存できる定義ファイルの拡張子は.{0}のみです。
        ''' </summary>
        ''' <remarks></remarks>
        NoXMLFileType = 3180036

        ''' <summary>
        '''{0} 、{1}以外で{2}移行する項目を最低１つ以上選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        TransFieldCountError = 3180037

        ''' <summary>
        '''{0}は、{1}には移行出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        NonSetSubject = 3180038

        ''' <summary>
        '''{0}は選択されたフィールドには移行出来ません。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectFileldKey = 3180039

        ''' <summary>
        '''{0}は必須設定です。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectNotesDocID = 3180040

        ''' <summary>
        '''{0}を複数フィールドに移行することは来ません。
        ''' </summary>
        ''' <remarks></remarks>
        OneSelectNotesDocID = 3180041

        ''' <summary>
        '''ユーザーIDを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        UserIdEmpty = 3180042

        ''' <summary>
        '''パスワードを入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        PasswordEmpty = 3180043

        ''' <summary>
        ''' 検索する氏名を入力してください。
        ''' </summary>
        ''' <remarks></remarks>
        NotSearchName = 3180044

        ''' <summary>
        ''' {0}
        ''' </summary>
        ''' <remarks></remarks>
        Empty = 3180045

        ''' <summary>
        ''' 予期せぬ例外です。
        ''' </summary>
        ''' <remarks></remarks>
        UnknowException = 3180046

        ''' <summary>
        ''' フォームに紐づくUDテーブルがフォームと1対1ではありません。
        ''' </summary>
        ''' <remarks></remarks>
        OneToOneMapping4UDException = 3180047

        ''' <summary>
        ''' 制約マスターがユニークではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueRestrictionException = 3180048

        ''' <summary>
        ''' ログの出力先が不明です。
        ''' </summary>
        ''' <remarks></remarks>
        UnknownLogDevice = 3180049

        ''' <summary>
        ''' 制約の実行種別が不明です。
        ''' </summary>
        ''' <remarks></remarks>
        UnknownActivateTypeException = 3180050

        ''' <summary>
        ''' フィールドIDがセットされていません。
        ''' </summary>
        ''' <remarks></remarks>
        UnSetIDFieldException = 3180051

        ''' <summary>
        ''' フィールドIDがユニークではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NonuniqueIDFLDException = 3180052

        ''' <summary>
        ''' スレッドが終了できません
        ''' </summary>
        ''' <remarks></remarks>
        ThreadIsAliveException = 3180053

        ''' <summary>
        ''' {0}が存在しません
        ''' </summary>
        ''' <remarks></remarks>
        XMLNotFoundException = 3180054

        ''' <summary>
        ''' 定義ファイルが変更されています。
        ''' </summary>
        ''' <remarks></remarks>
        ChildXMLChangedException = 3180055

        ''' <summary>
        ''' レスフォームまたはサブフォームが存在するため削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ExistenceOfResOrSubException = 3180056

        ''' <summary>
        ''' サブフォームが存在するため削除できません。
        ''' </summary>
        ''' <remarks></remarks>
        ExistenceOfSubException = 3180057

        ''' <summary>
        ''' インスタンスの再生に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ReviveFailedException = 3180058

        ''' <summary>
        ''' 画面のキャンセルが選択されました。
        ''' </summary>
        ''' <remarks></remarks>
        CanceledFormLoadException = 3180059

        ''' <summary>
        ''' 件名処理に失敗。
        ''' </summary>
        ''' <remarks></remarks>
        CheckSubject = 3180060

        ''' <summary>
        ''' イメージタグ作成に失敗。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundTargetLinkException = 3180061

        ''' <summary>
        ''' 選択されたフォームにはデータが一件もありません。
        ''' </summary>
        ''' <remarks></remarks>
        NoDataInNsf = 3180062

        ''' <summary>
        ''' ログインキャンセル。
        ''' </summary>
        ''' <remarks></remarks>
        NotesLoginCancel = 3180063

        ''' <summary>
        ''' 指定されたTransInfoが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        SetTransInfoError = 3180064

        ''' <summary>
        ''' 制約マスタにデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        SeiyakuMasterNotFound = 3180065

        ''' <summary>
        ''' 制約マスターの更新に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        SeiyakuMasterUpdateErr = 3180066

        ''' <summary>
        ''' 数値変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkNumericError = 3180067

        ''' <summary>
        ''' 整数/金額変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        chkMoneyError = 3180068

        ''' <summary>
        ''' 日付変換に失敗しました。
        ''' </summary>
        ''' <remarks></remarks>
        ChangeDateError = 3180069

        ''' <summary>
        ''' ログインしているサーバと異なるサーバへの移行はできません。
        ''' </summary>
        ''' <remarks></remarks>
        NotIdentificationLoginServerException = 3180070

        ''' <summary>
        ''' 移行種別が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromDBTypeIdentificationException = 3180071

        ''' <summary>
        ''' 移行元サーバが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromMachineNameIdentificationException = 3180072

        ''' <summary>
        ''' 移行元ファイル名が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFileNameIdentificationException = 3180073

        ''' <summary>
        ''' 移行元ファイルパスが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        FromFilePathIdentificationException = 3180074

        ''' <summary>
        ''' 移行先サーバーが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        ToServerIdentificationException = 3180075

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateSysBlgIdentificationException = 3180076

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserIdentificationException = 3180077

        ''' <summary>
        ''' 作成者が一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        CreateUserNMIdentificationException = 3180078

        ''' <summary>
        ''' 移行先フォームが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        MainToFormIDIdentificationException = 3180079

        ''' <summary>
        ''' 移行先フォームが一致しません。
        ''' </summary>
        ''' <remarks></remarks>
        ResToFormIDIdentificationException = 3180080

        ''' <summary>
        ''' メインフォームの移行先が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        NotFoundMainformException = 3180081

        ''' <summary>
        ''' メインフォームに紐づかれたサブフォームではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedMainsSubFormException = 3180082

        ''' <summary>
        ''' メインフォームに紐づかれたレスフォームではありません。
        ''' </summary>
        ''' <remarks></remarks>
        NotSelectedMainsResFormException = 3180083

        ''' <summary>
        ''' メインフォーム内に本サブフォームを呼び出すGUI項目が存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        UnUniqSbuGuip = 3180084

        ''' <summary>
        ''' 選択されたサブフォームは既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        AlreadySetFormException = 3180085

        ''' <summary>
        ''' 移行先がレスフォームまたはサブフォームになっている定義ファイルは選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        MainFrmIsNotBBSAndWFBBSException = 3180086

        ''' <summary>
        ''' Notes データベースを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        PleaseSelectNotesDb = 3180087

        ''' <summary>
        ''' 読込み可能な定義ファイルではありません。
        ''' </summary>
        ''' <remarks></remarks>
        AdmFileError = 3180088

        ''' <summary>
        ''' 保存するデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        DataForSaveEmpty = 3180089

        ''' <summary>
        ''' サーバーに接続できません。
        ''' </summary>
        ''' <remarks></remarks>
        ConnToServerError = 3180090

        ''' <summary>
        ''' CSVファイルのレイアウトが正しくありません。
        ''' </summary>
        ''' <remarks></remarks>
        CSVFileError = 3180091

        ''' <summary>
        ''' 選択されたファイルは既に存在します。
        ''' </summary>
        ''' <remarks></remarks>
        ExistedFile = 3180092

        ''' <summary>
        '''登録するデータが存在しません。
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        EmptyData = 3180093

        ''' <summary>
        '''タスクを選択してください。
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        PlsSelectTask = 3180094

        ''' <summary>
        '''一時データが存在しないため、選択できません。
        ''' </summary>
        ''' <remarks></remarks>
        CanNotSelectEmpytTempData = 3180095

        ''' <summary>
        '''一時データが存在しないため、アップロードできません。 
        ''' </summary>
        ''' <remarks></remarks>
        NothingTempData = 3180096

        ''' <summary>
        '''承認者を選択して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        NoSelectAccepter = 3180097
    End Enum

#End Region

#Region " VAGP "

    ''' <summary>
    ''' R@bitFlow NotesConveter の警告メッセージを格納したリソースのリソース名を提供します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum [VAGP]

        ''' <summary>
        '''指定されたレポート名は長すぎです。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0001 = 3190001

        ''' <summary>
        '''帳票名を入力して下さい。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0002 = 3190002

        ''' <summary>
        '''指定された帳票名は既に存在しますので、指定し直してください。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0003 = 3190003

        ''' <summary>
        '''既にその条件は設定されています。
        ''' </summary>
        ''' <remarks></remarks>
        Msg0004 = 3190004
    End Enum

#End Region
End Namespace
