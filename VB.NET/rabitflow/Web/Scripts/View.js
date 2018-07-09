/*
 * <summary>
 * ビュー画面で使用する静的なクライアントスクリプトです。
 * </summary>
 */
///<reference path="../Scripts/common.js" />
///<reference path="../Scripts/UI/fixHeadTable.js" />
$(window).on("load resize", function () {
    var width;
    var height;
    // メインテーブルの高さ
    height = $(window).height() - 85;
    if (height > 0) {
        $("#mainTable").height(height);
    }

    // 文書一覧の幅と高さ
    width = $(window).width() - 214;
    if (width > 0) {
        $("#divDocList").width(width);
    }
    height = $(window).height() - 218;
    if (height > 0) {
        $("#divDocList").height(height);
    }
    // カテゴリツリーの高さ
    height = $(window).height() - 122;
    if (height > 0) {
        $("#DivMain").height(height);
    }
});

Rabit.Action_Onload = function () {
    // 所属選択ボタンクリック時のイベント
    $("#btnSelectBLG").click(function (event) {
        var ev = event || window.event;
        // 所属選択画面を表示する
        var param = "LUS=" + $("#hdnUserSeed").val() +
            "&DP=2&IDFRM=" + $("#hdnSelectForm").val();
        ev.preventDefault();

        // 所属選択画面を表示する
        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmBelongSelect, param,
            //width,height
            1024, 742,
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
                    $("#hdnUserSeed").val(value);
                }
                //submit
                $(sender).triggerServerClick();
            });
        return false;
    });

    // 代理業務選択ボタンクリック時のイベント
    $("#proxySelectButton").click(function (event) {
        var ev = event || window.event;
        // 所属選択画面を表示する
        var param = "LUS=" + $("#hdnUserSeed").val() +
            "&FS=" + $("#hdnSelectForm").val();
        ev.preventDefault();

        // 所属選択画面を表示する
        $(this).modalDialog(
            //url,queryString
            "../SysPage/frmFLW3055.aspx", param,
            //width,height
            1024, 690,
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
                    var returnValues = value.split(",");
                    $("#hdnUserSeed").val(returnValues[0]);
                    $("#hdnProxyType").val(returnValues[1]);
                }
                //submit
                $(sender).triggerServerClick();
            });
        return false;
    });

    // 代理者設定ボタンクリック時のイベント
    $("#proxySettingButton").click(function (event) {
        var ev = event || window.event;
        // 所属選択画面を表示する
        var param = "LUS=" + $("#hdnUserSeed").val() +
            "&FS=" + $("#hdnSelectForm").val();
        ev.preventDefault();

        // 所属選択画面を表示する
        $(this).modalDialog(
            //url,queryString
            "../SysPage/frmFLW3045.aspx", param,
            //width,height
            1024, 742,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);

        return false;
    });

    // 詳細検索ボタンクリック時のイベント
    $("#btnSearch").click(function (event) {
        var ev = event || window.event;
        // 詳細検索画面を表示する
        var param = "IDFINFRM=" + $("#hdnSelectForm").val();
        ev.preventDefault();

        // 所属選択画面を表示する
        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmNarrowSearch, param,
            //width,height
            800, 700,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            getSearchStrings(),
            //callback
            function (ev, sender, value) {
                if (!value || value == "") {
                    return false;
                }
                else {
                    // ここで戻り値をセットする
                    setSearchStrings(value);
                }
                //submit
                $(sender).triggerServerClick();
            });
        return false;
    });

    // 再表示ボタンクリック時のイベント
    $("#btnViewAct").click(function () {
        if (!validate()) {
            return false;
        }

        // 現在のページとページ番号の一致チェック
        if (parseInt($("#hiddenBeforeViewCount").val()) == parseInt($("#TxtViewCnt").val()) &&
            parseInt($("#textPageNo").val()) > parseInt($("#hiddenPageCnt").val())) {
            ExclamationMessages.InputError.Show();
            $("#textPageNo").focus().select();
            return false;
        }

        return true;
    });

    //文書ビューのヘッダを固定化する
    $("#dl").fixTable($("#divDocList"));
    $("#dl").on("view_DoExpand", function () {
        $("#dl").resetFixTable($("#divDocList"));
    });
}

// 現在画面上に設定されている詳細検索用文字列を、詳細検索画面に渡せるパラメータとして返す
function getSearchStrings() {
    // 全文検索文字列
    var strFindText = "";
    if ($("#txtFindtext") != null) {
        strFindText = $("#txtFindtext").val();
    }
    // 添付ファイルチェックボックス
    var strAttachedFile = "";
    if ($("#chkTemp") != null) {
        if ($("#chkTemp").prop("checked")) {
            strAttachedFile = "1";
        } else {
            strAttachedFile = "0";
        }
    }

    // 検索文字列（詳細検索画面からもどってきた文字列が格納されているhiddenコントロールから取得）
    var param = $("#hdnSearch").val();
    if (param.trim().length != 0) {
        // 全文検索用の文字列を、画面で設定されている文字列に変更
        var parts = param.split(";");
        if (parts.length > 1) {
            param = param.substring(0, param.length - parts[parts.length - 1].length);
        }
    } else {
        param = ";;";
    }

    if (strFindText != "" || strAttachedFile != "") {
        param += strFindText + "\t" + strAttachedFile;
    }

    // QueryStringとして使用できる文字列として返す
    return param;
}

// 詳細検索画面から取得した文字列を画面上のコントロールへ割り付ける
function setSearchStrings(strSearch) {
    // 取得した文字列をすべてそのまま格納
    $("#hdnSearch").val(strSearch);

    // 検索文字列に全文検索用の部分があるかどうかチェック
    var strSearchParts = strSearch.split(";");
    if (strSearchParts.length != 3) {
        return false;
    }

    // 全文検索部分からコントロールへの値の割り付け
    var strParts = strSearchParts[2].split("\t");
    if ($("#txtFindtext") != null) {
        $("#txtFindtext").val(strParts[0]);
    }
    if ($("#chkTemp") != null) {
        $("#chkTemp").prop("checked", strParts[1] == "1");
    }
}

// 前ページ、次ページボタンクリック時のイベント
$("#imgBack #imgNext").click(function () {
    return validate();
});

// 入力内容の妥当性を検証
function validate() {

    // 表示件数チェック
    var pageSize = $("#TxtViewCnt").val();
    if (pageSize != "") {
        // 数値チェック
        if (!$.isNumeric(pageSize)) {
            ExclamationMessages.InputError.Show();
            $("#TxtViewCnt").focus().select();
            return false;
        }

        // 下限値チェック
        if (parseInt(pageSize) < 1) {
            ExclamationMessages.InputError.Show();
            $("#TxtViewCnt").focus().select();
            return false;
        }
    }

    // ページ番号チェック
    var pageNo = $("#textPageNo").val();
    if (pageNo != "") {
        // 数値チェック
        if (!$.isNumeric(pageNo)) {
            ExclamationMessages.InputError.Show();
            $("#textPageNo").focus().select();
            return false;
        }

        // 下限値チェック
        if (parseInt(pageNo) < 1) {
            ExclamationMessages.InputError.Show();
            $("#textPageNo").focus().select();
            return false;
        }
    }

    return true;
}

// すべてのチェックボックスのチェック状態を変更
function checkDocument(checked) {
    $("input[type='checkbox']", "#dl").prop("checked", checked);
}

// 文書を起動
function DocOpen(WkDocSd, DocSd, FormSd, SysBlg, DocType, OpenKey) {

    // パラメータの設定
    var param = "";
    param += "UserSd=" + $("#hdnUserSeed").val();
    param += "&PUserSd=" + $("#hdnProxyUserSeed").val();
    param += "&FmMode=1";
    param += "&Adm=" + $("#hiddenDocWfAdminEncode").val();
    param += "&ViewSysBlg=" + $("#hdnViewUseSysBlg").val();
    param += "&OpenKey=" + OpenKey;
    param += "&SelBlg=" + $("#hiddenSelectedUser").val();
    param += "&FrmType=" + $("#hdnfrmType").val();

    var windowName;
    if (FormSd == "0") {
        // 新規作成の場合のパラメータ
        param += "&DocSd=";
        param += "&FormSd=" + $("#hdnSelectForm").val();
        param += "&SysBlg=";
        param += "&Type=1";
        param += "&DocType=" + $("#hdnDocType").val();

        var createCount = $("#hdnCreateCnt").val() == "" ? 1 : parseInt($("#hdnCreateCnt").val()) + 1;
        $("#hdnCreateCnt").val(createCount);
        windowName = "frmCre" + createCount;
    } else {
        // 選択された文書のパラメータ
        param += "&DocSd=" + DocSd;
        param += "&FormSd=" + FormSd;
        param += "&SysBlg=" + SysBlg;
        param += "&Type=0";
        param += "&DocType=" + DocType;

        windowName = "frm" + WkDocSd;
    }

    if ($("#hdnSelectViewId").val() != "0" && FormSd == 0) {
        // フォーム選択ダイアログを表示する
        param += "&ViewId=" + $("#hdnSelectViewId").val();
        param += "&ProxyType=" + $("#hdnProxyType").val();
        param += "&CreateCnt=" + $("#hdnCreateCnt").val();

        // フォーム選択画面を表示する
        $(this).modalDialog(
            //url,queryString
            Rabit.Pages.frmFormSelect, param,
            //width,height
            800, 730,
            //options
            { title: 'R@bitFlow' },
            //dialogArgs
            null,
            //callback
            null);
    } else {
        // 文書を起動する
        $(this).windowOpen(
            //url,queryString
            Rabit.Pages.frmDocDisp, param,
            //width,height
            1020, 690,
            //callback
            null,
            // windowName
            windowName);
    }

    return false;
}

// グループ化の全展開/全縮小
function TreeAllExpand(expanded) {
    if (expanded) {
        $("#dl tbody > tr").each(function () {
            if ($(this).hasClass("hidden") || $(this).hasClass("show")) {
                $(this).attr("class", "show");
                $(this).attr("expand", "1");
            }

            $(this).find("img").each(function () {
                if ($(this).attr("src").toLowerCase().indexOf("plusmark.gif") > 0) {
                    $(this).attr("src", "../images/minusmark.gif");
                }
            });
        });
    } else {
        var minlevel = -1;
        var currentLevel;
        $("#dl tbody > tr").each(function () {
            var sumflg = $(this).attr("sumflg");
            if (minlevel == -1) {
                if (sumflg != 1) {
                    currentLevel = $(this).attr("level");
                    minlevel = currentLevel;
                }
            } else {
                currentLevel = $(this).attr("level");
                if (currentLevel < minlevel) {
                    minlevel = currentLevel;
                }

                if ($(this).hasClass("show")) {
                    if (currentLevel > minlevel) {
                        $(this).attr("class", "hidden");
                    }
                    $(this).attr("expand", 0);
                }
            }

            $(this).find("img").each(function () {
                if ($(this).attr("src").toLowerCase().indexOf("minusmark.gif") > 0) {
                    $(this).attr("src", "../images/plusmark.gif");
                }
            });
        });
    }
    $("#dl").trigger("view_DoExpand");
}

// グループ化の展開/縮小
function DocTree(elem) {
    try {
        DoExpand(elem);
        $(elem).parents("table").trigger("view_DoExpand");
    }
    catch (e) {
        alert(e);
        return;
    }
}
/**グループビューを展開する
* @param {HtmlElement} elem
*/
function DoExpand(elem) {
    var expanded, parnobleak, blnnobleak2;
    var eventSrc = elem;
    var activeRow = eventSrc.parentNode.parentNode;
    var parexpand = $(activeRow).attr("expand");
    var parsum = activeRow.nextSibling;
    if (parexpand == 1) {
        $(eventSrc).attr("src", "../images/plusmark.gif");
        $(activeRow).attr("expand", 0);
        $(activeRow).attr("block", 0);
        expanded = false;
        parnobleak = false;
        blnnobleak2 = false;

        if ($(parsum).attr("sumflg") == "1") {
            $(parsum).attr("expand", 0);
            $(parsum).attr("block", 0);
        }
    } else {
        $(eventSrc).attr("src", "../images/minusmark.gif");
        $(activeRow).attr("expand", 1);
        expanded = true;
        parnobleak = true;
        blnnobleak2 = true;

        if ($(parsum).attr("sumflg") == "1") {
            $(parsum).attr("expand", 1);
        }
    }

    var currentLevel = parlevel;
    var parlevel = $(activeRow).attr("level");
    var partopgroup = $(activeRow).attr("topgroup");
    var parid = $(activeRow).attr("id");
    var nextCtrl = activeRow.nextSibling;
    var hiddenflg = false;

    while (nextCtrl != null) {
        var vid = new String(nextCtrl.id);
        if (vid.indexOf("LIST", 0) < 0) {
            break;
        }

        var level = $(nextCtrl).attr("level");
        var maxlevel = $(nextCtrl).attr("maxlevel");
        var expand = $(nextCtrl).attr("expand");
        var topgroup = $(nextCtrl).attr("topgroup");
        var sumflg = $(nextCtrl).attr("sumflg");
        var block = $(nextCtrl).attr("block");
        var nextid = $(nextCtrl).attr("id");
        var blnnobleak = false;
        level.valueOf();

        if (level <= currentLevel) {
            blnnobleak2 = parnobleak;
            currentLevel = level;
        }

        if (sumflg == 0) {
            // Skip
            if (topgroup != partopgroup) {
                break;
            }
            if (parid != nextid) {
                if (level == parlevel ||
                    (level < parlevel && block == 0)) {
                    break;
                }
            }
        }

        if (expanded) {
            if (topgroup == partopgroup && !blnnobleak2) {
                //Parent is hidding
                blnnobleak = true;
            }
        }
        else {
            if (hiddenflg && topgroup != partopgroup && level < maxlevel) {
                blnnobleak = true;
            }
        }

        if (!blnnobleak) {
            if (!expanded) {
                if (level != parlevel || sumflg != 1) {
                    //Hidden rows;
                    if (level == maxlevel) {
                        hiddenflg = true;
                        $(nextCtrl).attr("block", "1");
                    } else if (expand == 1) {
                        $(nextCtrl).attr("block", "1");
                    }

                    $(nextCtrl).attr("class", "hidden");
                }
            } else {
                $(nextCtrl).attr("class", "show");
                // var img = nextCtrl.children(0).children(0);
                level = $(nextCtrl).attr("level");
                maxlevel = $(nextCtrl).attr("maxlevel");
                $(nextCtrl).attr("block", "0");

                if (maxlevel == level) {
                    hiddenflg = false;
                }

                if (blnnobleak2) {
                    if ($(nextCtrl).attr("expand") == 0) {
                        blnnobleak2 = false;
                        currentLevel = level;
                    }
                    else {
                        blnnobleak2 = true;
                    }

                }
            }
        } else {
            blnnobleak2 = false;
        }

        nextCtrl = nextCtrl.nextSibling;
    }
}
