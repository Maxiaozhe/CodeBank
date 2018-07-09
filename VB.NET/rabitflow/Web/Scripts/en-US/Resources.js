﻿var cstrOnProcessing = "Processing by Server...";
var WaitImgSrc = "../Images/waiting.gif";

var InforMationMessages = {
    FinishedPasswordChange: new AlertMessageType("Password is altered."),
    ChampionSubmit: new AlertMessageType("Processing by Server..."),
    NotChkDoc: new AlertMessageType("Select documents.")
}

var QuestionMessages = {
    Quit: new ConfirmMessageType("Are you sure you want to end?"),
    Remove: new ConfirmMessageType("Are you sure you want to delete?"),
    Save: new ConfirmMessageType("Are you sure you want to save?"),
    AddNew: new ConfirmMessageType("Are you sure you want to enregister?"),
    AllAccept: new ConfirmMessageType("Are you sure you want to run all documents what you select?"),
    Revision: new ConfirmMessageType("Are you sure you want to revision?"),
    SendMail: new ConfirmMessageType("Are you sure you want to send?"),
    Update: new ConfirmMessageType("Are you sure you want to update?"),
    Contribute: new ConfirmMessageType("Are you sure you want to post?"),
    Reply: new ConfirmMessageType("Are you sure you want to send back?"),
    Entry: new ConfirmMessageType("Are you sure you want to enregister?"),
    RemandMaker: new ConfirmMessageType("Are you sure you want to refer this document to author?"),
    RemandPrevAdmit: new ConfirmMessageType("Are you sure you want to refer this document to previous reviewer?"),
    RemandUnionPrevAdmit: new ConfirmMessageType("Are you sure you want to refer this document to previous section?"),
    ChgSysBlg: new ConfirmMessageType("Are you sure you want to alter default department?"),
    DelRidocDoc: new ConfirmMessageType("If you delete this,your previous setting will be lost. \n Are you sure you want to delete? "),
    PlusYearCheck: new ConfirmMessageType("Are you sure you want to set next year?"),
    NegYearCheck: new ConfirmMessageType("Are you sure you want to set last year?"),
    CheckIn: new ConfirmMessageType("Are you sure you want to check in this document?"),
    CheckOut: new ConfirmMessageType("Are you sure you want to check out this document?"),
    PasswordChangeExecCheck: new ConfirmMessageType("Are you sure you want to alter password?"),
    ExecuteMessage: new ConfirmMessageType("Are you sure you want to run?"),
    DeleteRouteConfirmer: new ConfirmMessageType("Are you sure you want to delte reviewer/approver?"),
    DeleteConfirm: new ConfirmMessageType("Are you sure you want to delete?"),
    DeleteTarget: new ConfirmMessageType("Are you sure you want to delete?")
}

var ExclamationMessages = {
    YearErr: new AlertMessageType("The year setting is invalid.Set +-1 year from this year."),
    SaveFolderNotSelected: new AlertMessageType("Select final save destination."),
    DunInputPassword: new AlertMessageType("Input password!"),
    DunInputOldPassword: new AlertMessageType("Input current password."),
    DunInputNewPassword: new AlertMessageType("Input new password."),
    DunInputCheckPassword: new AlertMessageType("Input confirm password."),
    DunInputOldCheckPassword: new AlertMessageType("The verification password is invalid."),
    DunInputOldNewPassword: new AlertMessageType("Password you inputed is used by other User."),
    DunInputUserID: new AlertMessageType("Input UserID."),
    DunInputComment: new AlertMessageType("Input comment."),
    BeforeDateCanNotSelected: new AlertMessageType("Not select date before start date."),
    AfterDateCanNotSelected: new AlertMessageType("Not select date after end date."),
    ProxyUserCanNotSelected: new AlertMessageType("Not set business agent."),
    DunInputProxyUser: new AlertMessageType("Select business agent."),
    DunInputStartDate: new AlertMessageType("Input start date."),
    ProxyDateExcess: new AlertMessageType("Start date is after end date."),
    ProxyDateNotIsDate: new AlertMessageType("Input [YYYY/MM/DD] type for period is date item."),
    CanNotSelected: new AlertMessageType("Not select."),
    DunInputData: new AlertMessageType("Select."),
    DunSelectDocumet: new AlertMessageType("Select document."),
    SelectedDirCanNotSave: new AlertMessageType("System can't save in selected cabinet."),
    SaveCabNotSelected: new AlertMessageType("Select destination for save."),
    FalseOldPassword: new AlertMessageType("Old password is not correct."),
    FalseNewPassword: new AlertMessageType("New password is not correct."),
    LimitBreakPassword: new AlertMessageType("Input in 20 character."),
    NotUseBeforePassword: new AlertMessageType("Not use new password as previous password."),
    CanNotAddNewGroup: new AlertMessageType("Not register as group."),
    CanNotAddNew: new AlertMessageType("Failed to register."),
    CanNotAddNewRoute: new AlertMessageType("Select person."),
    NotSelectedAddFile: new AlertMessageType("Select attached file."),
    NotRevisionMessage: new AlertMessageType("Not set edition over 99.99."),
    ExistForbiddenChr: new AlertMessageType("Invalid string is included.\nNot use [/:*?\"<>|&'%;,\\+[]=]."),
    ExistForbiddenChr2: new AlertMessageType("Invalid string is included.\nNot use [&#]."),
    ExistForbiddenChr3: new AlertMessageType("Invalid string is included.\nNot use [!:()`^~:*?\"<>|&'%;,\\+[]=]."),
    ExistForbiddenChr4: new AlertMessageType("Invalid string is included.\nNot use [AND/OR/NOT]."),
    MoneyNumericErr: new AlertMessageType("Input numeric in title's money."),
    OMoneyNumericErr: new AlertMessageType("Input numeric in overbudget money."),
    ClamorCanNotSelected: new AlertMessageType("Not set author."),
    DunInputClamor: new AlertMessageType("Select author."),
    NotChangeRoute: new AlertMessageType("Not set ROUTE on only author."),
    StopTheForm: new AlertMessageType("Selected FORM is stopping."),
    MaxLengthOver_InLain: new AlertMessageType("Not exceed length to input."),
    MastInputTitle_InLain: new AlertMessageType("Input title of attached document."),
    InputError: new AlertMessageType("Entried value is incorrect."),
    CanNotAddOrgGroup: new AlertMessageType("Not select organization/group."),
    DunInputMailAddress: new AlertMessageType("Input mail address."),
    PrintReport: new AlertMessageType("Do you want to run and print this document?"),
    NoSubDoc: new AlertMessageType("SubFORM ducument is not created."),
    NoMakeSubDocRight: new AlertMessageType("You have no apply authority of subFORM document."),
    OverLengthRiferItem: new AlertMessageType("Input in 30 length."),
    ProxyUserCanNotSelectedMOSS: new AlertMessageType("Not set orgnization/group to proxy.\nSelect person."),
    ProxyUserNotSelectedMOSS: new AlertMessageType("Select business agent."),
}

var CriticalMessages = {
    DeadlySystemError: new AlertMessageType("System error. Contact manager.")
}