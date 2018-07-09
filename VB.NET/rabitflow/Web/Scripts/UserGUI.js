///<reference path="../Scripts/common.js" />

// <summary>
// 600系のスクリプト
// </summary>
$(function () {
    // 事前チェックボタンクリック時のイベント
    $("#usrFLW06021_btnBeforeChk").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmBeforeChk, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            800, 600,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            function (ev, sender, value) {
                if (value == null) {
                    return false;
                }
                else {
                    //submit
                    $(sender).triggerServerClick();
                }
            });
        return false;
    });

    // 事前チェック一覧ボタンクリック時のイベント
    $("#usrFLW06021_btnBeforeChkLook").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmBeforeChkLook, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            800, 600,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            function (ev, sender, value) {
                if (!value || value == "") {
                    return false;
                }
                else {
                    //submit
                    $(sender).triggerServerClick();
                }
            });
        return false;
    });

    // サブフォーム登録ボタンクリック時のイベント
    $("#usrFLW06021_btnContribSub").click(function () {
        return QuestionMessages.Entry.Show();
    });

    // 削除ボタンクリック時のイベント
    $("#usrFLW06021_btnDelete").click(function () {
        if (QuestionMessages.Remove.Show()) {
            $("#usrFLW06021_hdnClose").val("1");
            return true;
        } else {
            return false;
        }
    });

    // 一時保存ボタンクリック時のイベント
    $("#usrFLW06021_btnSaveDC").click(function () {
        return QuestionMessages.Save.Show();
    });

    // コメント表示ボタンクリック時のイベント
    $("#usrFLW06021_btnCommnt").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmComment, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            800, 620,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);

        return false;
    });

    // ルート選択ボタンクリック時のイベント
    $("#usrFLW06021_btnRoutef").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmRoutef, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            1000, 690,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            function (ev, sender, value) {
                if (value == null) {
                    return false;
                } else {
                    $("#usrFLW06021_hdnRoutef").val(value[0]);
                    $("#usrFLW06021_hdnUserSd").val(value[1]);
                    $("#usrFLW06021_hdnIdRecog").val(value[2]);
                    $("#usrFLW06021_hdnUnoinRoutef").val(value[3]);
                    $("#usrFLW06021_hdnFgRecognum").val(value[4]);
                    $("#usrFLW06021_hdnFgAndor").val(value[5]);
                    $("#usrFLW06021_hdnNoPersons").val(value[6]);
                    $("#usrFLW06021_hdnNoSeq").val(value[7]);

                    if (value.length > 8) {
                        $("#usrFLW06021_hdnBeforeSeed").val(value[8]);
                        $("#usrFLW06021_hdnEditRoutef").val(value[10]);
                    }

                    //submit
                    $(sender).triggerServerClick();
                }
            });

        return false;
    });

    // ルートの途中変更ボタンクリック時のイベント
    $("#usrFLW06021_ButtonChangeRoute").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        var page;
        if ($("#usrFLW06021_hdnMoveNewPage").val() == "0") {
            page = Rabit.Pages.frmChageRoute;
        } else {
            page = Rabit.Pages.frmNewChageRoute;
        }

        $(this).modalDialog(
            //url,queryString
            page, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            1000, 690,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            function (ev, sender, value) {
                if (value == null) {
                    return false;
                } else {
                    $("#usrFLW06021_hdnRoutef").val(value[0]);
                    $("#usrFLW06021_hdnUserSd").val(value[1]);
                    $("#usrFLW06021_hdnIdRecog").val(value[2]);
                    $("#usrFLW06021_hdnUnoinRoutef").val(value[3]);
                    $("#usrFLW06021_hdnFgRecognum").val(value[4]);
                    $("#usrFLW06021_hdnFgAndor").val(value[5]);
                    $("#usrFLW06021_hdnNoPersons").val(value[6]);
                    $("#usrFLW06021_hdnNoSeq").val(value[7]);

                    if (value.length > 8) {
                        $("#usrFLW06021_hdnBeforeSeed").val(value[8]);
                        $("#usrFLW06021_hdnEditRoutef").val(value[10]);
                    }

                    //submit
                    $(sender).triggerServerClick();
                }
            });

        return false;
    });

    // ルート表示ボタンクリック時のイベント
    $("#usrFLW06021_btnRouted").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        var param = $("#usrFLW06021_hdnDocSed").val() + "&IDDOC=" + $("#usrFLW06021_hdnDocSed").val();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmRouted, param,
            //width,height
            1000, 690,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);

        return false;
    });

    // コメント履歴ボタンクリック時のイベント
    $("#usrFLW06021_btnHistory").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmHistory, $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            830, 650,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);

        return false;
    });

    // チェックインボタンクリック時のイベント
    $("#usrFLW06021_ButtonCheckIn").click(function () {
        return QuestionMessages.CheckIn.Show();
    });

    // チェックアウトボタンクリック時のイベント
    $("#usrFLW06021_ButtonCheckOut").click(function () {
        return QuestionMessages.CheckOut.Show();
    });

    // 共同作成ボタンクリック時のイベント
    $("#usrFLW06021_ButtonShare").click(function (event) {
        var ev = event || window.event;
        ev.preventDefault();

        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmSelectUser, "Param=7&FormSeed=0&" + $("#usrFLW06021_hdnDocSed").val(),
            //width,height
            1000, 960,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);

        return false;
    });

    //印刷
    $("#usrFLW06021_btnPrintf").click(function (event) {
        var param = $("#usrFLW06021_hdnPrnSd").val();
        //$(this).windowOpen(Rabit.Pages.frmPrintf, param, 830, 650, null, "");
        $(this).modalDialog(Rabit.Pages.frmPrintf, param, 830, 650,{ title: 'Print' });
        return false;
    });
});

// <summary>
// サブフォーム呼び出し
// </summary>
function usrFLW0250_OpenWindow(
    DialogStatesNone,
    DialogStatesBeforeOpen,
    DialogStatesAfterClose,
    baseName,
    DocSd,
    ShowDialogClientID,
    newDocFlag) {

    var WM_NONE = DialogStatesNone;
    var WM_OPEN = DialogStatesBeforeOpen;
    var WM_CLOSE = DialogStatesAfterClose;

    if ($("#" + baseName + "hdnSubFrmFlg").val() == "-999") {
        $("#" + baseName + "hdnSubFrmFlg").val("0");
        ExclamationMessages.NoSubDoc.Show();
    } else if ($("#" + baseName + "hdnSubFrmFlg").val() == "-888") {
        $("#" + baseName + "hdnSubFrmFlg").val("0");
        ExclamationMessages.NoMakeSubDocRight.Show();
    }

    if ($("#" + ShowDialogClientID).val() == WM_OPEN &&
        $("#" + baseName + "hdnSubFrmFlg").val() == "1") {

        $("#" + baseName + "hdnSubFrmFlg").val("0");

        var param = "UserSd=" + $("#" + baseName + "hdnUserSeed").val();
        param += "&PUserSd=" + $("#" + baseName + "hdnPUserSd").val();
        param += "&FmMode=1";
        param += "&DocSd=" + $("#" + baseName + "hdnDocId").val();
        param += "&FormSd=" + $("#" + baseName + "hdnNewFrmSeed").val();
        param += "&SysBlg=" + $("#" + baseName + "hdnUserSeed").val();
        param += "&Type=0";
        param += "&DocType=" + $("#" + baseName + "hdnDocType").val();
        param += "&FrmType=" + $("#" + baseName + "hdnFormType").val();
        param += "&Admin=" + $("#" + baseName + "hdnAdminMode").val();
        param += "&AdminDel=" + $("#" + baseName + "hdnDocWfAdminDel").val();
        param += "&readonly=" + $("#" + baseName + "hdnSubReadOnly").val();
        param += "&ParFrmType=" + $("#" + baseName + "hdnParFrmType").val();
        param += "&ParFormSd=" + $("#" + baseName + "hdnparFrmSeed").val();
        param += "&ParDocSd=" + $("#" + baseName + "hdnParDocID").val();
        param += "&NDF=" + newDocFlag;
        param += "&DAM=3";
        param += "&ADM=" + $("#" + baseName + "encodeAdmHidden").val();

        $(this).windowOpen(Rabit.Pages.frmDocDisp, param, 1020, 690, function (sender, returnValue) {
            $("#" + baseName + "hdnShowSubDialog").val("2");
            Rabit.submit();
        }, "frm" + DocSd);
    }
}

// <summary>
// 住所検索
// </summary>
function usrFLW0220_BtnSearch(target, controlId) {

    var param = "PropID=" + $("#" + controlId + "_hdnPropID").val();
    param += "&DocSd=" + $("#" + controlId + "_hdnIDDOC").val();
    param += "&FormSd=" + $("#" + controlId + "_hdnIDFRM").val();

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.frmSearchAddress, param,
        //width,height
        1024, 742,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null || value == "") {
                return false;
            }
            else {
                $("#" + controlId + "_hdnParamStr").val(value);

                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

// <summary>
// ビューリンク
// </summary>
function usrFLW0260_OpenViewDialog(
    DialogStatesNone,
    DialogStatesBeforeOpen,
    DialogStatesAfterClose,
    ShowDialogClientID,
    LoginUserSeed,
    GuiSeed,
    DialogArgumentsClientID,
    DialogReturnValueClientID) {

    var WM_NONE = DialogStatesNone;
    var WM_OPEN = DialogStatesBeforeOpen;
    var WM_CLOSE = DialogStatesAfterClose;

    if ($("#" + ShowDialogClientID).val() != WM_OPEN) {
        return false;
    }

    var param = "UserSd=" + LoginUserSeed;
    param += "&PUserSd=0&PType=0";
    param += "&GuiSd=" + GuiSeed;

    $(this).modalDialog(
        //url,queryString
        Rabit.Pages.frmViewDialog, param,
        //width,height
        820, 690,
        //options
        { title: 'R@bitFlow'},
        //dialogArgs
        $("#" + DialogArgumentsClientID).val(),
        //callback
        function (ev, sender, value) {
            if (value == null || value == "") {
                $("#" + ShowDialogClientID).val(WM_NONE);
            }
            else {
                $("#" + DialogReturnValueClientID).val(value);
                $("#" + ShowDialogClientID).val(WM_CLOSE);
                Rabit.submit();
            }
        });
}

// <summary>
// 先頭に戻る
// </summary>
function usrFLW0207_MovePageTop() {

    var x1 = x2 = x3 = 0;
    var y1 = y2 = y3 = 0;
    if (document.documentElement) {
        x1 = document.documentElement.scrollLeft || 0;
        y1 = document.documentElement.scrollTop || 0;
    }
    if (document.body) {
        x2 = document.body.scrollLeft || 0;
        y2 = document.body.scrollTop || 0;
    }
    x3 = window.scrollX || 0;
    y3 = window.scrollY || 0;
    var x = Math.max(x1, Math.max(x2, x3));
    var y = Math.max(y1, Math.max(y2, y3));
    window.scrollTo(Math.floor(x / 2), Math.floor(y / 2));
    if (x > 0 || y > 0) {
        window.setTimeout("usrFLW0207_MovePageTop()", 30);
    }

    return false;
}

// <summary>
// インライン添付
// </summary>
function usrFLW1290_ButtonClick(target, clientId) {

    var commandName = clientId + "_hdnCommand";
    if ($("#" + commandName).val() == "Delete" || $("#" + commandName).val() == "Delete Cancel") {
        if (QuestionMessages.DeleteConfirm.Show()) {
            $("#" + commandName).val("Delete OK");
            return true;
        } else {
            $("#" + commandName).val("Delete Cancel");
            return false;
        }
    }

    var param = "ClickBTN=" + clientId;
    param += "&DocSeed=" + $("#" + clientId + "_hdnDcSeed").val();
    param += "&UserSeed=" + $("#" + clientId + "_hdnUserSd").val();
    param += "&FormSeed=" + $("#" + clientId + "_hdnFormSeed").val();
    param += "&Guid01=" + $("#" + clientId + "_hdnGuid01").val();
    param += "&MeGuid=" + $("#" + clientId + "_hdnGUIID").val();

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.frmInLineUpLoad, param,
        //width,height
        580, 340,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null || value.length == 0 || value[0] != "Add") {
                $("#" + commandName).val("Add Cancel");
                return false;
            }
            else {
                $("#" + commandName).val("Add OK");
                $("#" + clientId + "_hdnAdFile").val(value[1]);
                $("#" + clientId + "_hdnDirPath").val(value[2]);
                $("#" + clientId + "_hdnAdFilelbl").val(value[3]);

                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

function usrFLW1290_ImageClick(target, controlName) {

    var clientId = target.id.replace("ibtnFileDisp", "");
    if ($("#" + clientId + "hdnAdFilelbl").val() == "") {
        return false;
    }
    
    var docSeed = $("#" + clientId + "hdnDcSeed").val();
    if (docSeed != "") {
        var param = "SEED=" + docSeed + "&BUTTON=" + controlName;
        $(target).windowOpen(Rabit.Pages.frmInLineUpView, param, 800, 600, null, "frmInLineUpView");
    }

    return false;
}

function usrFLW1290_NameChanged(target) {

    var clientId = target.id.replace("tbxAtName", "");
    if (target.value == "") {
        ExclamationMessages.MastInputTitle_InLain.Show();
        target.value = $("#" + clientId + "hdnAdFilelbl").val();
        target.select();
    } else {
        target.value = target.value.replace("<", " ").replace(">", " ");
        if (target.value.indexOf("&#") > 0) {
            ExclamationMessages.ExistForbiddenChr2.Show();
            target.select();
            return false;
        }

        if (target.value.length > 100) {
            ExclamationMessages.MaxLengthOver_InLain.Show();
            target.value = target.value.substring(0, 100);
            target.select();
            return false;
        }
    }
}

// <summary>
// フレーム
// </summary>
function usrRGUI0230_Expand(frameId, hiddenId, imageId) {
    var target = document.getElementById(frameId);
    var hidden = document.getElementById(hiddenId);
    var image = document.getElementById(imageId);
    if (target.style.display != "none") {
        target.style.display = "none";
        hidden.value = "0";
        image.src = "../Images/plus.gif";
    } else {
        target.style.display = "block";
        hidden.value = "1";
        image.src = "../Images/minus.gif";
    }

    return false;
}

// <summary>
// 承認履歴（フォーム）
// </summary>
function RGUI0350_Expand(frameId, hiddenId, imageId) {
    var target = document.getElementById(frameId);
    var hidden = document.getElementById(hiddenId);
    var image = document.getElementById(imageId);
    if (target.style.display != "none") {
        target.style.display = "none";
        hidden.value = "0";
        image.src = "../Images/plus.gif";
    } else {
        target.style.display = "block";
        hidden.value = "1";
        image.src = "../Images/minus.gif";
    }

    return false;
}

// <summary>
// 簡易ルート
// </summary>
function RGUI0290_Expand(frameId, hiddenId, imageId) {
    var target = document.getElementById(frameId);
    var hidden = document.getElementById(hiddenId);
    var image = document.getElementById(imageId);
    if (target.style.display != "none") {
        target.style.display = "none";
        hidden.value = "0";
        image.src = "../Images/plus.gif";
    } else {
        target.style.display = "block";
        hidden.value = "1";
        image.src = "../Images/minus.gif";
    }

    return false;
}

function RGUI0290_SelectRoute(target, formId, fieldName, no, hiddenId, selectedSeeds, loginUser) {

    var args = formId + "\n" + fieldName + "\n" + no + "\n" + selectedSeeds + "\n" + loginUser;
    $(target).modalDialog(
        //url,queryString
        "../UsrPage/ucpRGUI0290.aspx", "DialogArgs=" + escape(args),
        //width,height
        1024, 742,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null) {
                return false;
            }
            else {
                $("#" + hiddenId).val(value);
                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

// <summary>
// 年月テキスト
// </summary>
function FLW0117_CheckPeriod(target) {

    var value = target.value;
    var expression = value;
    if (value.length == 5) {
        expression = value.substring(0, 4) + "/0" + value.substring(4);
    } else if (value.length == 6) {
        if (value.indexOf("/") > 0) {
            expression = value.substring(0, 5) + "0" + value.substring(5);
        } else {
            expression = value.substring(0, 4) + "/" + value.substring(4);
        }
    }

    if (expression.match(/\d{4}\/\d{2}/)) {
        var month = parseInt(expression.substring(5));
        if (1 <= month && month <= 12) {
            target.value = expression;
        } else {
            target.value = "";
        }
    } else {
        target.value = "";
    }

    return false;
}

// <summary>
// 添付ファイル
// </summary>
function FLW0821_ClickAddFile(target, ctrlName) {

    var param = "DcSeed=" + $("#" + ctrlName + "_hdnDcSeed").val();
    param += "&Guid=" + $("#" + ctrlName + "_hdnGuid01").val();;

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.frmRidocLocalFile, param,
        //width,height
        600, 450,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null || value == "") {
                return false;
            }
            else {
                $("#" + ctrlName + "_btnOpenFile").attr("disabled", true);
                $("#" + ctrlName + "_btnDelFile").attr("disabled", true);
                $("#" + ctrlName + "_hdnAdFile").val(value[0]);
                $("#" + ctrlName + "_hdnGuid01").val(value[1]);

                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

function FLW0821_CheckDocSelect(ctrlName) {
    return $("#" + ctrlName).val() != "-1";
}

// <summary>
// 文書リンク
// </summary>
function usrRGUI0070_OpenViewDialog(param) {

    $(this).modalDialog(
        //url,queryString
        "../UsrPage/ucpRGUI0070.aspx", param,
        //width,height
        820, 690,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        null);

    return false;
}

// <summary>
// 組織検索
// </summary>
function usrFLW1330_BtnSearch(target, ControlId) {

    var param = "Param=" + $("#" + ControlId + "_hdnFgRecSep").val();
    param += "&PropID=" + $("#" + ControlId + "_hdnPropID").val();
    param += "&DocSd=" + $("#" + ControlId + "_hdnIDDOC").val();
    param += "&FormSd=" + $("#" + ControlId + "_hdnIDFRM").val();

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.frmSearchOrgani, param,
        //width,height
        1024, 742,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null || value == "") {
                return false;
            }
            else {
                $("#" + ControlId + "_hdnParamStr").val(value);

                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

// <summary>
// 社員検索
// </summary>
function usrRGUI0090_BtnSearch(target, ControlId) {

    var param = "Param=" + $("#" + ControlId + "_hdnFgRecSep").val();
    param += "&PropID=" + $("#" + ControlId + "_hdnPropID").val();
    param += "&DocSd=" + $("#" + ControlId + "_hdnIDDOC").val();
    param += "&FormSd=" + $("#" + ControlId + "_hdnIDFRM").val();
    param += "&GroupSd=" + $("#" + ControlId + "_hdnIDGROUP").val();

    $(target).modalDialog(
        //url,queryString
        "../UsrPage/ucpRGUI0090.aspx", param,
        //width,height
        1024, 742,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value == null || value == "") {
                return false;
            }
            else {
                $("#" + ControlId + "_hdnParamStr").val(value);

                //submit
                $(sender).triggerServerClick();
            }
        });

    return false;
}

// <summary>
// 写真
// </summary>
function usrFLW1320_OpenFileSelectDialog(target, DocId, FldId) {

    var param = "DI=" + DocId + "&FI=" + FldId;

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.FileSelectDialogPage, param,
        //width,height
        650, 340,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        function (ev, sender, value) {
            if (value != null || value == "1") {
                //submit
                $(sender).triggerServerClick();
            }
            else {
                return false;
            }
        });

    return false;
}

// <summary>
// 承認履歴一覧
// </summary>
function usrFLW0518_btnRecogListClick(target, ctrlName) {

    var param = "IDDOC=" + $("#" + ctrlName + "_hdnDocSd").val() + "&ACLCHK=" + $("#" + ctrlName + "_chkACLCHK").prop("checked");

    $(target).modalDialog(
        //url,queryString
        Rabit.Pages.frmRecogList, param,
        //width,height
        800, 600,
        //options
        { title: 'R@bitFlow' },
        //dialogArgs
        null,
        //callback
        null);

    return false;
}