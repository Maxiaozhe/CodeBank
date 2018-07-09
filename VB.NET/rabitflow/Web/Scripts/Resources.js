///<reference path="MessageTypes.js" />
var cstrOnProcessing = "サーバ処理中です。";
var WaitImgSrc = "../Images/waiting.gif";

var InforMationMessages = {
    FinishedPasswordChange : new AlertMessageType("パスワードを変更しました。"),
    ChampionSubmit : new AlertMessageType("サーバで処理中です。"),
    NotChkDoc : new AlertMessageType("文書を選択してください。")
}

var QuestionMessages = {
    Quit : new ConfirmMessageType("終了します。よろしいですか？"),
    Remove : new ConfirmMessageType("削除します。よろしいですか？"),
    Save : new ConfirmMessageType("保存します。よろしいですか？"),
    AddNew : new ConfirmMessageType("登録します。よろしいですか？"),
    AllAccept : new ConfirmMessageType("選択されたすべての文書を処理します。よろしいですか？"),
    Revision : new ConfirmMessageType("改訂します。よろしいですか？"),
    SendMail : new ConfirmMessageType("送信します。よろしいですか？"),
    Update : new ConfirmMessageType("更新します。よろしいですか？"),
    Contribute : new ConfirmMessageType("投稿します。よろしいですか？"),
    Reply : new ConfirmMessageType("返信します。よろしいですか？"),
    Entry : new ConfirmMessageType("登録します。よろしいですか？"),
    RemandMaker : new ConfirmMessageType("作成者に差戻します。よろしいですか？"),
    RemandPrevAdmit : new ConfirmMessageType("一つ前の人に差戻します。よろしいですか？"),
    RemandUnionPrevAdmit : new ConfirmMessageType("一つ前のセクションに差戻します。よろしいですか？"),
    ChgSysBlg : new ConfirmMessageType("デフォルト所属を変更します。よろしいですか？"),
    DelRidocDoc : new ConfirmMessageType("削除すると元に戻せませんが、よろしいですか？"),
    PlusYearCheck : new ConfirmMessageType("今年より＋1の年が設定されています。よろしいですか？"),
    NegYearCheck : new ConfirmMessageType("今年より－1の年が設定されています。よろしいですか？"),
    CheckIn : new ConfirmMessageType("文書のチェックインを行います。よろしいですか？"),
    CheckOut : new ConfirmMessageType("文書のチェックアウトを行います。よろしいですか？"),
    PasswordChangeExecCheck : new ConfirmMessageType("パスワードを変更します。よろしいですか？"),
    ExecuteMessage : new ConfirmMessageType("実行します。よろしいですか？"),
    PrintReport : new ConfirmMessageType("文書の処理と印刷を行います。よろしいですか？"),
    DeleteRouteConfirmer : new ConfirmMessageType("審査・承認者を削除します。よろしいですか？"),
    DeleteConfirm: new ConfirmMessageType("削除してもよろしいですか？"),
    DeleteTarget: new ConfirmMessageType("該当データを削除します。よろしいですか？")
}

var ExclamationMessages = {
    YearErr : new AlertMessageType("年の設定が不正です。今年＋－1の値を設定してください。"),
    SaveFolderNotSelected : new AlertMessageType("最終保存先が選択されていません。"),
    DunInputPassword : new AlertMessageType("パスワードを入力してください。"),
    DunInputOldPassword : new AlertMessageType("現在のパスワードを入力してください。"),
    DunInputNewPassword : new AlertMessageType("新しいパスワードを入力してください。"),
    DunInputCheckPassword : new AlertMessageType("パスワードの確認を入力してください。"),
    DunInputOldCheckPassword : new AlertMessageType("パスワードの確認が正しくありません。"),
    DunInputOldNewPassword : new AlertMessageType("入力されたパスワードは現在使われているパスワードです。"),
    DunInputUserID : new AlertMessageType("ユーザーＩＤを入力してください。"),
    DunInputComment : new AlertMessageType("コメントを入力してください。"),
    BeforeDateCanNotSelected : new AlertMessageType("開始日より前の日は選択できません。"),
    AfterDateCanNotSelected : new AlertMessageType("終了日より後の日は選択できません。"),
    ProxyUserCanNotSelected : new AlertMessageType("代理者に設定できません。"),
    DunInputProxyUser : new AlertMessageType("代理者を選択してください。"),
    DunInputStartDate : new AlertMessageType("開始日を入力して下さい。"),
    ProxyDateExcess : new AlertMessageType("開始日が終了日を超えています。"),
    ProxyDateNotIsDate : new AlertMessageType("期間は日付項目のため、『YYYY/MM/DD』形式で入力してください。"),
    CanNotSelected : new AlertMessageType("選択できません。"),
    DunInputData : new AlertMessageType("選択してください。"),
    DunSelectDocumet : new AlertMessageType("文書を選択してください。"),
    SelectedDirCanNotSave : new AlertMessageType("選択されたキャビネットには保存出来ません。"),
    SaveCabNotSelected : new AlertMessageType("保存先を選択して下さい。"),
    FalseOldPassword : new AlertMessageType("古いパスワードが正しくありません。"),
    FalseNewPassword : new AlertMessageType("新しいパスワードが正しくありません。"),
    LimitBreakPassword : new AlertMessageType("20文字以内で入力してください。"),
    NotUseBeforePassword : new AlertMessageType("新しいパスワードは前回のパスワードと同じものは使えません。"),
    CanNotAddNewGroup : new AlertMessageType("グループでは登録できません。"),
    CanNotAddNew : new AlertMessageType("登録できません。"),
    CanNotAddNewRoute : new AlertMessageType("個人を選択してください。"),
    NotSelectedAddFile : new AlertMessageType("添付するファイルを選択して下さい。"),
    NotRevisionMessage : new AlertMessageType("99.99を超えて版を更新することはできません。"),
    ExistForbiddenChr : new AlertMessageType("無効な文字が含まれています。\n「/:*?\"<>|&'%;,\\+[]=」は使用できません。"),
    ExistForbiddenChr2 : new AlertMessageType("無効な文字が含まれています。\n&#は使用できません。"),
    ExistForbiddenChr3 : new AlertMessageType("無効な文字が含まれています。\n「!:()`^~:*?\"<>|&'%;,\\+[]=」は使用できません。"),
    ExistForbiddenChr4 : new AlertMessageType("無効な文字が含まれています。\n「AND/OR/NOT」は使用できません。"),
    MoneyNumericErr : new AlertMessageType("タイトルの金額に数値以外の値が入力されています。"),
    OMoneyNumericErr : new AlertMessageType("予算超過分の金額に数値以外の値が入力されています。"),
    ClamorCanNotSelected : new AlertMessageType("申立者に設定できません。"),
    DunInputClamor : new AlertMessageType("申立者を選択してください。"),
    NotChangeRoute : new AlertMessageType("作成者だけのルートの設定はできません。"),
    StopTheForm : new AlertMessageType("選択されたフォームは現在停止中です。"),
    MaxLengthOver_InLain : new AlertMessageType("入力可能文字数を超えています。"),
    MastInputTitle_InLain : new AlertMessageType("添付文書タイトル入れてください。"),
    InputError : new AlertMessageType("入力された値に誤りがあります。"),
    CanNotAddOrgGroup : new AlertMessageType("組織・グループでは登録できません。"),
    DunInputMailAddress : new AlertMessageType("メールアドレスを入力してください。"),
    NoSubDoc : new AlertMessageType("サブフォーム文書が作られていません。"),
    NoMakeSubDocRight : new AlertMessageType("サブフォーム文書の新規作成権限がありません。"),
    OverLengthRiferItem : new AlertMessageType("30文字以内で入力してください。"),
    ProxyUserCanNotSelectedMOSS : new AlertMessageType("代理者には組織・グループは設定できません。\n個人 を選択してください。"),
    ProxyUserNotSelectedMOSS : new AlertMessageType("代理者を選択してください。")
}

var CriticalMessages = {
    DeadlySystemError : new AlertMessageType("システムエラーです。管理者に問い合わせてください。")
}