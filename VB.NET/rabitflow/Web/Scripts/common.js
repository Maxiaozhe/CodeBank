///<reference path="jquery-1.12.4.js" />
///<reference path="UI/jquery-ui.js" />
///<reference path="UI/jquery.datetimepicker.full.js" />
///<reference path="MessageTypes.js" />
///<reference path="Resources.js" />
var UseTextForbitChar;
var ForbitPattern;
var isDebug = false;
/*Rabitflow JavaScript Library v1.0.0*/
var Rabit = {
    //システムページのURL変数定義
    Pages: {
        ModalDialog: "../SysPage/frmDummy.aspx",
        DialogHtmlPage: "../SysPage/Dialog.aspx",
        DialogHtmlPage2: "../SysPage/Dialog2.html",
        DialogHtmlPage3: "../SysPage/Dialog3.html",
        frmName01: "../SysPage/frmFLW1010.aspx",
        frmName02: "../SysPage/frmFLW1020.aspx",
        /* 参照者、承認者とかの選択画面 */
        frmSelectUser: "../SysPage/frmFLW3080.aspx",
        // 所属選択画面
        frmBelongSelect: "../SysPage/frmFLW3010.aspx",
        // 絞込み検索画面
        frmNarrowSearch: "../SysPage/frmFLW3020.aspx",
        // パスワード変更画面
        frmChangePassword: "../SysPage/frmFLW3030.aspx",
        // 代理者設定画面
        frmDeputySetup: "../SysPage/frmFLW3040.aspx",
        //代理者選択画面
        frmDeputySelect: "../SysPage/frmFLW3050.aspx",
        //一括代理設定画面
        frmDeputyBulkSetup: "../SysPage/frmFLW3600.aspx",
        //コメント表示画面
        frmComment: "../SysPage/frmFLW3060.aspx",
        //グループメンテナンス選択画面
        frmGpMaintenanceSelect: "../SysPage/frmFLW3120.aspx",
        //グループメンテナンス画面
        frmGpMaintenance: "../SysPage/frmFLW3121.aspx",
        //ルート変更画面
        frmRoutef: "../SysPage/frmFLW1080.aspx",
        //ルート変更画面(途中ね)
        frmChageRoute: "../SysPage/frmFLW1081.aspx",
        //ルート表示画面
        frmRouted: "../SysPage/frmFLW4020.aspx",
        //カレンダー画面
        frmCalPage: "../SysPage/frmFLW3041.aspx",
        frmPrintf: "../SysPage/frmFLW0102.aspx",
        //WebNavi
        frmWebNavi: "../SysPage/frmFLW4010.aspx",
        //色選択画面
        frmSelColorPage: "../SysPage/frmFLW3042.aspx",
        frmRidocDir: "../UsrPage/frmFLW8010.aspx",
        frmRidocLocalFile: "../UsrPage/frmFLW8020.aspx",
        frmAddFile: "../UsrPage/frmFLW8025.aspx",
        frmRidocFile: "../UsrPage/frmFLW8030.aspx",
        //View
        frmView: "../UsrPage/frmFLW0100.aspx",
        frmFormSelect: "../SysPage/frmFLW2010.aspx",
        //申立者設定画面（申立者GUIからの呼出）
        frmClamorSetup: "../SysPage/frmFLW3100.aspx",
        //所属選択画面（BS連携申立者GUIからの呼出）
        frmSelectUserBS: "../SysPage/frmFLW3110.aspx",
        //事前チェック依頼画面
        frmBeforeChk: "../SysPage/frmFLW4030.aspx",
        //事前チェック一覧画面
        frmBeforeChkLook: "../SysPage/frmFLW4040.aspx",
        //履歴画面
        frmHistory: "../SysPage/frmFLW4050.aspx",
        //文書表示画面
        frmDocDisp: "../SysPage/frmFLW0104.aspx",
        //ルート詳細
        frmFullDisp: "../SysPage/frmFLW4070.aspx",
        //ルート新規作成画面
        frmMakeRoute: "../SysPage/frmFLW1090.aspx",
        //個人ルート呼出し
        frmMakeRouteSelf: "../SysPage/frmFLW1091.aspx",
        //承認履歴一覧画面
        frmRecogList: "../SysPage/frmFLW3200.aspx",
        //承認履歴一覧画面
        frmMoushitateMoney: "../SysPage/frmFLW3210.aspx",
        //既存ルート変更画面
        frmEditRoute: "../SysPage/frmFLW1100.aspx",
        //見積一覧画面
        frmEstimationList: "../SysPage/frmFLW3220.aspx",
        //社員検索画面
        frmSearchEmplyee: "../SysPage/frmFLW3300.aspx",
        //住所検索画面
        frmSearchAddress: "../SysPage/frmFLW3400.aspx",
        //組織検索画面   組織検索GUI対応 追加
        frmSearchOrgani: "../SysPage/frmFLW3500.aspx",
        //インライン添付（UpLoad画面）
        frmInLineUpLoad: "../UsrPage/frmFLW1291.aspx",
        //インライン添付（閲覧画面）
        frmInLineUpView: "../UsrPage/frmFLW1292.aspx",
        //一括更新項目選択画面
        frmLumpUpdate1: "../SysPage/frmFLW3150.aspx",
        //一括更新変更内容設定画面
        frmLumpUpdate2: "../SysPage/frmFLW3151.aspx",
        //一括更新確認＆実行画面
        frmLumpUpdate3: "../SysPage/frmFLW3152.aspx",
        //ステータス更新実行画面
        frmLumpUpdate4: "../SysPage/frmFLW3153.aspx",
        frmViewDialog: "../SysPage/frmFLW3230.aspx",
        //ファイル選択ダイアログページ
        FileSelectDialogPage: "../UsrPage/frmFLW1320.aspx",
        //リファードロップダウン項目追加画面
        frmAddItem: "../UsrPage/frmFLW0106.aspx",
        //既存ルート変更画面(ルート変更機能対応)
        frmNewEditRoute: "../SysPage/frmFLW1101.aspx",
        //ルート変更画面(途中ね)(ルート変更機能対応)
        frmNewChageRoute: "../SysPage/frmFLW1102.aspx",
        //言語切り替え画面
        frmChangeLanguage: "../SysPage/frmFLW0043.aspx",
        //ポータル所属選択画面
        frmPortalDefaulBLG: "../SysPage/frmRFLW0020.aspx",
        //イメージ挿入画面
        frmUploadImage: "../UsrPage/frmFLW8035.aspx"
    },
    //言語コード
    lang: null,
    //ブラウザのデフォルトの高さ
    defBrowserHeight: 690,
    //ブラウザのデフォルトの幅
    defBrowserWidth: 1020,
    //メッセージデータ({Message:'message',Type:'alert|confirm'})
    JsonMessage: null,
    //処理中フラグ
    submiting: false,
    //Date Format List
    DATE_FORMATS: [
        /^(\d{4})(\d{2})(\d{2})$/g,
        /^(\d{4})\/(\d{1,2})\/(\d{1,2})$/g,
        /^(\d{4})-(\d{1,2})-(\d{1,2})$/g
    ],
    //Control KeyCodes(BS,ESC etc.)
    CONTROL_KEYS: [8, 9, 16, 27, 35, 36, 37, 38, 39, 40, 45, 46],
    //web browser info
    Browser: null,
    //画面処理化処理
    init: function () {
        if (isDebug != true) {
            //右クリック禁止
            $(document).bind("contextmenu", function (ev) {
                ev.returnValue = false;
                return false;
            });
            //キーイベントを無効化
            $(window).keydown(function (ev) {
                return Rabit.Events.document_onkeydown(ev);
            });
        }
        //F1キーを無効化
        $(window).on("help", function (ev) { return false; });
        //ページロード
        $(window).bind("load", function (ev) {
            return Rabit.Events.window_onload(ev);
        });
        //Form
        $("form").each(function () {
            this.onsubmit = function (event) {
                return Rabit.Events.form_submit(event);
            };
        });
        //Window閉じる
        //$(window).bind("beforeunload", function (ev) {
        //    return Rabit.Events.window_close(ev);
        //});
        //既定のキャンセルボタン
        $("#btnCancel,.btnCancel").click(function (ev) {
            return Rabit.Events.btnCancel_onclick(this, ev);
        });
        //既定の閉じるボタン
        $("#btnClosef,.btnClosef").click(function (ev) {
            return Rabit.Events.btnClosef_onclick(this, ev);
        });
        //子画面を開くしている場合、親画面を閉じるとき、メッセージ表示
        $(window).bind("beforeunload", function (event) {
            var ev = event || window.event;
            if (Rabit.submiting) { return; }
            try {
                if (window.openedWindow) {
                    ev.returnValue = cstrOnProcessing;
                    return cstrOnProcessing;
                }
            } catch (e) {
                //skip
            }
        });
        //OpenWindowを閉じる前、親画面のロックを解除する
        $(window).bind("unload", function (event) {
            var ev = event || window.event;
            if (Rabit.submiting) { return; }
            try {
                if (window.opener && Rabit.fn.isWindow(window.opener)) {
                    var jQ = window.opener.$;
                    jQ(window.opener).trigger("openwindowclosed");
                }
            } catch (e) {
                //skip
            }
        });

        //Browser 情報取得する
        this.Browser = new BrowserInfo();
    },
    // Javascriptでフォームsubmit時、この関数を呼び出します。
    // document.forms[0].submit()を直接使用しないでください。
    submit: function () {
        var form = $("form").get(0);
        if (!form.onsubmit || (form.onsubmit() != false)) {
            form.submit();
        }
    },
    //ページロード時のメッセージ表示
    showMessage: function (msg) {
        var msgJson = msg || {};
        var msgClass;
        if (msgJson.Message && msgJson.Type) {
            if (msgJson.Type == 'alert') {
                msgClass = new AlertMessageType(msgJson.Message);
            } else {
                msgClass = new ConfirmMessageType(msgJson.Message)
            }
            var result = msgClass.Show();
            if (result != null && Rabit.Action_Confirm && $.isFunction(Rabit.Action_Confirm)) {
                Rabit.Action_Confirm(result);
            }
            Rabit.JsonMessage = null;
        }
    },
    // 拡張 Action Eventハンドローラ定義
    // onLoadイベントハンドローラ
    Action_Onload: null,
    // Enterキー押すイベントハンドローラ
    Action_Enter: null,
    // 確認メッセージのコールバックハンドローラ
    Action_Confirm: null,
    // Submit個別処理のイベントハンドローラ
    Action_Onsubmit: null
}

/** Rabitflow JavaScript Library 共通イベント処理 */
Rabit.Events = {
    //Document onKeydown イベント処理
    document_onkeydown: function (e) {
        /* window.event属性はIEのみのため、
           event objectを使う場合下記のように使用してください。 */
        var ev = e || window.event;
        var elem = ev.target || window.event.srcElement;
        if (elem == null) {
            ev.keyCode = 0;
            ev.returnValue = false;
            return false;
        }
        switch (ev.keyCode) {

            case 112: case 113: case 114: case 115: case 116: case 117:
            case 118: case 119: case 120: case 121: case 122: case 123:
                //Functionキー(F1～F12)
                ev.keyCode = 0;
                ev.returnValue = false;
                return false;
            case 8:
                //BackSpaceキー TextArea,input以外無効にする
                var allowFilter = "textarea,input:not(readonly)";
                var forbidFilter = ":submit,:reset,:button,:image,:radio,:checkbox,:file,[type=color],[type=range]";
                var length = $(elem).filter(allowFilter).not(forbidFilter).size();
                if (length == 0) {
                    ev.keyCode = 0;
                    ev.returnValue = false;
                    return false;
                }
                break;
            case 13:
                //Enterキー textarea,submit,button,password系以外無効
                var allowFilter = "textarea,:submit,:button,:reset,:image,:password";
                var length = $(elem).filter(allowFilter).size();
                if (length == 0) {
                    ev.keyCode = 0;
                    ev.returnValue = false;
                }
                if (Rabit.Action_Enter && typeof (Rabit.Action_Enter) == "function") {
                    Rabit.Action_Enter(ev);
                }
                return ev.returnValue;
            case 27:
                // ESCキー
                ev.keyCode = 0;
                ev.returnValue = false;
                return false;
            case 65:
                // Ctrl + A （全選択)
            case 66:
                // Ctrl + B （お気に入りの整理ダイアログ出力）
            case 68:
                // Ctrl + D （お気に入りに追加）
            case 69:
                // Ctrl + E （検索フレーム表示）
            case 72:
                // Ctrl + H （履歴の表示）
            case 73:
                // Ctrl + I （お気に入りフレーム表示）
            case 76:
                // Ctrl + L （ファイルを開くダイアログ出力）
            case 77:
                // Ctrl + M
            case 78:
                // Ctrl + N （現在のページを別ウィンドウで開く）
            case 82:
                // Ctrl + R （ページの再読み込み）
                if (ev.ctrlKey) {
                    ev.preventDefault();
                    ev.stopPropagation();
                    ev.returnValue = false;
                    return false;
                }
                break;
            case 79:
                // Ctrl + O （ファイルを開くダイアログ出力）
            case 80:
                // Ctrl + P （印刷）
                if (ev.ctrlKey) {
                    ev.preventDefault();
                    ev.stopPropagation();
                    ev.returnValue = false;
                    return false;
                }
                break;
                // 以下のショットカットキーを許可する
            case 67:
                // Ctrl + C （コピー）
            case 86:
                // Ctrl + V （貼り付け）
            case 88:
                // Ctrl + X （切り取り）
                if (ev.ctrlKey) {
                    return;
                }
                break;
            default:
                break;
        }
    },
    // window Load エベント
    window_onload: function (e) {
        //show Message
        if (Rabit.JsonMessage) {
            window.setTimeout(function () {
                Rabit.showMessage(Rabit.JsonMessage);
                Rabit.JsonMessage = null;
            }, 100);
        }
        //前回の位置を保持する
        var hdnPos = $("#hdnChampionPosition");
        if (hdnPos.size() > 0 && hdnPos.val() != "") {
            var pos = $("#hdnChampionPosition").val().split(",");
            if (pos.length >= 2) {
                $(window).scrollTop(pos[0])
                         .scrollLeft(pos[1]);
            }
        }
        //Action_Onloadイベント
        //if (Rabit.Action_Onload && $.isFunction(Rabit.Action_Onload)) {
            window.setTimeout(function () {
                $(Rabit).trigger("Action_Onload");
            }, 100);
       //}
       // $(Rabit).trigger("Action_Onload");
    },
    //form_submit
    form_submit: function (e) {
        var ev = e || window.event;
        if (Rabit.submiting == true) {
            InforMationMessages.ChampionSubmit.Show();
            ev.returnValue = false;
            return false;
        } else {
            Rabit.submiting = true;
            //位置保持
            var hdnPos = $("#hdnChampionPosition");
            if (hdnPos.size() > 0) {
                var pos = $(window).scrollTop() + "," + $(window).scrollLeft();
                hdnPos.val(pos);
            }
            //複数イベントバインドする場合、最後のハンドローラの戻り値を取得
            var ret = $(Rabit).triggerHandler('Action_Onsubmit');
            if (ret == false) {
                //submit canceled
                ev.returnValue = false;
                Rabit.submiting = false;
                return false;
            }
            Rabit.fn.showWaiting();
            return true;
        }
    },
    //キャンセルボタン
    btnCancel_onclick: function (obj, e) {
        var ev = e || window.event;
        ev.returnValue = false;
        window.closeWindow(window);
        return false;
    },
    //閉じるボタン
    btnClosef_onclick: function (obj, e) {
        var ev = e || window.event;
        ev.returnValue = false;
        if (QuestionMessages.Quit.Show()) {
            window.closeWindow(window);
        }
        return false;
    }
};

/** Rabitflow JavaScript Library 内部使用関数定義 */
Rabit.fn = {
    // Submit時、画面マスクと読み取り中動画を追加します
    createWaitingPanel: function () {
        $("body").append("<div class='maskdiv'></div>");
        $(".maskdiv").css({
            width: '100%',
            height: '100%',
            position: "absolute",
            left: 0, top: 0,
            backgroundColor: "#aaaaaa",
            zIndex: "9998",
            opacity: 0.3,
            display: "none"
        });
        $("body").append("<div class='waiting'></div>");
        $(".waiting").css({
            position: "absolute", zIndex: "9999"
        });
        $(".waiting").append("<img src='" + WaitImgSrc + "' border='0'  />");
        $(".waiting").css("display", "none");
    },

    // 画面マスクと読み取り中動画を非表示する
    hideWaiting: function () {
        $(".maskdiv").hide();
        $(".waiting").hide();
        $(".maskdiv").off();
        if (Rabit.Browser.isMs) {
            $(".maskdiv").remove();
            $(".waiting").remove();
        }
    },
    // Windows画面サイズ変更およびスクロール時のイベントハンドローラ
    resetPosition: function () {
        var maskDiv = $(".maskdiv");
        var waitDiv = $(".waiting");
        var body = $(window);
        var left = ((body.width() - waitDiv.width()) / 2) + body.scrollLeft();
        var top = ((body.height() - waitDiv.height()) / 2) + body.scrollTop();
        maskDiv.width(body.width());
        maskDiv.height(body.height());
        maskDiv.css({ left: body.scrollLeft(), top: body.scrollTop() });
        waitDiv.css({ left: left, top: top });
    },
    // 画面マスクと読み取り中動画を表示します
    showWaiting: function () {
        if (Rabit.Browser.isMs) {
            Rabit.fn.createWaitingPanel();
        }
        Rabit.fn.resetPosition();
        $(".maskdiv").css("display", "block");
        $(".waiting").css("display", "block");
        $(window).resize(Rabit.fn.resetPosition)
                 .scroll(Rabit.fn.resetPosition);
    },
    //画面マスクを表示します
    showLocker: function () {
        if (Rabit.Browser.isMs) {
            Rabit.fn.createWaitingPanel();
        }
        Rabit.fn.resetPosition();
        $(".maskdiv").css("display", "block");
        $(".maskdiv").click(function () {
            Rabit.fn.popupChildWindow(window);
        });
        $(window).resize(Rabit.fn.resetPosition)
                 .scroll(Rabit.fn.resetPosition);
    },
    //親画面クリック時、子画面をFocusする（Edge無効）
    popupChildWindow: function (win) {
        if (win.openedWindow && Rabit.fn.isWindow(win.openedWindow.popWin)) {
            win.openedWindow.popWin.focus();
            Rabit.fn.popupChildWindow(win.openedWindow.popWin);
        }
    },
    isWindow: function (win) {
        try {
            return win && win.document;
        } catch (e) {
            return false;
        }
    }
}


/*以下共通関数*/

/**
* 文字列は日付かどうかをチェックする
* @param {String} strDate チェックする文字列
*/
function IsDate(strDate) {
    if (strDate && strDate == "") {
        return false;
    }
    for (var i in Rabit.DATE_FORMATS) {
        var reg = new RegExp(Rabit.DATE_FORMATS[i]);
        if (reg.test(strDate)) {
            reg.lastIndex = 0;
            var m = null;
            m = reg.exec(strDate);
            var year = m[1];
            var month = m[2];
            var day = m[3];
            var strTemp = year + "/" + month + "/" + day;
            if (!isNaN(Date.parse(strTemp))) {
                var date = new Date(Date.parse(strTemp));
                return (date.getFullYear() == year
                    && (date.getMonth() + 1) == month
                    && date.getDate() == day);
            } else {
                return false;
            }
        }
    }
    return false;
}
/**
* 文字列は数値かどうかをチェックする
* @param {String} strVal チェックする文字列
*/
function IsNumeric(strVal) {
    if (strVal == null || typeof strVal !== 'string' || strVal == '') {
        return false;
    }
    return !isNaN(parseFloat(strVal));
}

/**
* 文字列からDateへ変換する
*@param {String} strDate 日付文字列 */
function ParseDate(strDate) {
    if (strDate && strDate == "") {
        return null;
    }
    for (var i in Rabit.DATE_FORMATS) {
        var reg = new RegExp(Rabit.DATE_FORMATS[i]);
        if (reg.test(strDate)) {
            reg.lastIndex = 0;
            var m = null;
            m = reg.exec(strDate);
            var year = m[1];
            var month = m[2];
            var day = m[3];
            var strTemp = year + "/" + month + "/" + day;
            if (!isNaN(Date.parse(strTemp))) {
                var date = new Date(Date.parse(strTemp));
                if (date.getFullYear() == year && (date.getMonth() + 1) == month && date.getDate() == day) {
                    return date;
                }
            } else {
                return null;
            }
        }
    }
    return null;
}

/** 日付変換
*@param {Element} HtmlElement*/
function ChangeDate(elem) {
    var strDate = $(elem).val();
    if (IsDate(strDate)) {
        var dt = ParseDate(strDate);
        var year = dt.getFullYear();
        var month = dt.getMonth() + 1;
        var day = dt.getDate();
        var strTemp;
        strTemp = year + "/" + ((month >= 10) ? month : "0" + month);
        strTemp = strTemp + "/" + ((day >= 10) ? day : "0" + day);
        $(elem).val(strTemp);
    } else {
        $(elem).val("");
    }
}

/** 時間変換
*@param {Element} HtmlElement
*/
function ChangeTime(elem) {
    var isTime = true;
    var tempTime = $(elem).val();
    var hh = "", mm = "";
    var rep = new RegExp(/(\d{1,4})|(\d{1,2}:\d{1,2})/g);
    tempTime = tempTime.trim();

    if (tempTime == "" || rep.test(tempTime) == false) {
        isTime = false;
    }
    if (tempTime.indexOf(':') > 0) {
        var parts = tempTime.split(":");
        if (parts.length < 2) {
            isTime = false;
        } else {
            hh = parts[0].trim();
            mm = parts[1].trim();
        }
    }
    else {
        var len = tempTime.length;
        if (len == 1) {
            tempTime = "0" + tempTime + "00";
        } else if (len == 2) {
            tempTime = tempTime + "00";
        } else if (len == 3) {
            tempTime = "0" + tempTime;
        }
        hh = tempTime.substr(0, 2);
        mm = tempTime.substr(2, 2);
    }
    if (hh != "" && hh.length < 2) { hh = "0" + hh; }
    if (mm != "" && mm.length < 2) { mm = "0" + mm; }
    if (parseInt(hh) > 23 || parseInt(mm) > 59) {
        isTime = false;
    }
    var timeStr = isTime ? hh + ":" + mm : "";
    if (isTime && isNaN(Date.parse("1970/01/01 " + timeStr + ":00"))) {
        isTime = false;
    }
    if (isTime) {
        $(elem).val(timeStr);
    } else {
        $(elem).val("")
    }
}

/** 数値のみ制御
*@param {Event} e
*/
function NumericOnly(e) {
    var ev = e || window.event;
    var strValue = $(ev.target).val();
    var keyCode = ev.keyCode;

    //Control keys
    if (Rabit.CONTROL_KEYS.indexOf(keyCode) >= 0) {
        return true;
    }
    //Number Key 0-9
    if (keyCode >= 96 && keyCode <= 105) {
        return true;
    }
    //Number 0-9 
    if (ev.shiftKey == false && keyCode >= 48 && keyCode <= 57) {
        return true;
    }
    //+,-
    if (strValue.length == 0 && (keyCode == 109 || keyCode == 189)) {
        return true;
    }
    //.
    if (keyCode == 110 || keyCode == 190) {
        if (ev.shiftKey || strValue.indexOf(".", 0) >= 0) {
            ev.returnValue = false;
            return false;
        }
        return true;
    }
    //コピーと切り取りのみ有効にする
    if (ev.ctrlKey && [67, 88].indexOf(keyCode) >= 0) {
        return true;
    }
    //other key is disable
    ev.returnValue = false;
    return false;
}

/** 整数のみ制御
*@param {Event} e
*/
function NumberOnly(e) {
    var ev = e || window.event;
    var keyCode = ev.keyCode;

    //Control keys
    if (Rabit.CONTROL_KEYS.indexOf(keyCode) >= 0) {
        return true;
    }
    //Number Key 0-9
    if (keyCode >= 96 && keyCode <= 105) {
        return true;
    }
    //Number 0-9
    if (ev.shiftKey == false && keyCode >= 48 && keyCode <= 57) {
        return true;
    }
    //コピーと切り取りのみ有効にする
    if (ev.ctrlKey && [67, 88].indexOf(keyCode) >= 0) {
        return true;
    }
    //other key is disable
    ev.returnValue = false;
    return false;
}
/**VBS関数FormatNumericの代わり
*@param {Number} val
*@return {String}
*/
function FormatNumeric(val) {
    var numberFormatObj = new Intl.NumberFormat();
    return numberFormatObj.format(val);
}

/** 整数文字列をフォーマットする
*@param {Element} elem HtmlElement
*/
function nmFormat(elem) {
    var value = $(elem).val();
    if (IsNumeric(value)) {
        $(elem).val(FormatNumeric(Math.floor(value)));
    } else {
        $(elem).val("0");
    }
}
/** 数値文字列をフォーマットする
*@param {Element} elem HtmlElement
*/
function nmFormatEx(elem) {
    var value = $(elem).val();
    if (IsNumeric(value)) {
        $(elem).val(parseFloat(value).toString());
    } else {
        $(elem).val("");
    }
}

/** 数値フォーマット記号を除く
*@param {Element} elem HtmlElement
*/
function noFormat(elem) {
    var val = $(elem).val();
    $(elem).val(val.replace(/[,/]/g, ""));
    $(elem).select();
}

/**入力文字をチェックする
*@param {Element} elem input Element
*/
function clEncode(elem) {
    if (UseTextForbitChar && elem != null) {
        var value = $(elem).val();
        $(elem).val(ReplaceForbidChar(value));
    }
}

/** 禁則文字を除くする
*@param {String} buf
*@return {String}
*/
function ReplaceForbidChar(buf) {
    if (ForbitPattern == "") {
        return buf;
    }
    var regex = new RegExp(ForbitPattern, "g");
    return buf.replace(regex, "");
}

/**禁則文字対応(:*?<>|';,\+[]=/"&% | &#)
*@param {Element} elem input Element
*/
function clAllEncode(elem) {
    if (elem) { return; }
    var regex = new RegExp(/[:\*\?<>\|';,\\\+\[\]=/\"&%]/g);
    var value = $(elem).val();
    if (value == "") { return; }
    if (regex.test(value)) {
        ExclamationMessages.ExistForbiddenChr.Show();
        $(elem).select();
        return;
    }
    if (value.indexOf("&#") >= 0) {
        ExclamationMessages.ExistForbiddenChr2.Show();
        $(elem).select();
        return;
    }
}


/** 禁則文字対応(:!*?<>|';~(),\+[]="&% | AND OR NOT)
*@param {Element} elem input Element
*/
function clFullEncode(elem) {
    if (elem) { return; }
    var regex = new RegExp(/[:!\*\?<>\|';~\(\)`^,\\\+\[\]=\"&%]/g);
    var value = $(elem).val();
    if (value == "") { return; }
    if (regex.test(value)) {
        ExclamationMessages.ExistForbiddenChr3.Show();
        $(elem).select();
        return;
    }
    clEncode(elem);
    value = $(elem).val();
    var sects = value.split(" ");
    for (var i in sects) {
        var sect = sects[i].toLowerCase();
        if (sect == "and" || sect == "or" || sect == "not") {
            ExclamationMessages.ExistForbiddenChr4.Show();
            $(elem).select();
            return;
        }
    }
}
/** Browser種別 */
function BrowserInfo() {
    var ua = navigator.userAgent;
    //Microsoft IE
    this.msie = /(MSIE)/.test(ua);
    //Edge
    this.edge = /(Edge)/.test(ua);
    //IE 11
    this.ie11 = /(Trident\/7.0)/.test(ua);
    //Firefox
    this.firefox = /(Firefox)/.test(ua);
    //chrome
    this.chrome = /(Chrome)/.test(ua);
    //Safari
    this.safari = /(Safari)/.test(ua);
    //Microsoft Browser
    this.isMs = this.msie || this.edge || this.ie11;
}

/** 高さを調整する */
function ResizeHeight(objectId, defaultHeight) {
    var height = ($("body").height() - Rabit.defBrowserHeight) + defaultHeight;
    if (height < 0) {
        return;
    }
    $(objectId).css("height", height);
}
/** JQueryの関数を拡張 */
$.fn.extend({
    /**
    *モーダルダイアログを表示する
    *@param {String} link ページURL
    *@param {String} params クエリパラメタ
    *@param {Number} width 幅
    *@param {Number} height 高さ
    *@param {Object|Object=} options
    *@param {Object|Object=} dialogArgs
    *@param {Function|Function=} callback(event,sender,returnValue)
    *@return {Dialog} jQuery UI Dialog object
    */
    modalDialog: function (link, params, width, height, options, dialogArgs, callback) {
        var url = Rabit.Pages.ModalDialog;
        var owner = this;
        if (callback && $.isFunction(callback)) {
            $(owner).one("returnValue", callback);
        }
        var winHeight = $(window).height() - 20,
            winWidth = $(window).width() - 20;
        var dlgOption = {
            modal: true,
            autoOpen: false,
            width: width > winWidth ? winWidth : width,
            height: height > winHeight ? winHeight : height,
            title: 'R@bitFlow',
            //resizable: false,
            close: function () {
                var retVal = $.hasData(this, "returnData") ? $(this).data("returnData") : null;
                var elem = $(owner).get(0);
                $(owner).trigger("returnValue", [elem, retVal]);
                //Dialogを解放する
                $(this).removeData();
            }
        };
        var opt = options || {};
        //'modal'と'autoOpen'以外のオプションを設定する
        for (var key in options) {
            if (key != 'modal' && key != 'autoOpen') {
                dlgOption[key] = options[key];
            }
        }
        var dlg = null;
        if ($("#mydialog").size() > 0) {
            dlg = $("#mydialog").dialog(dlgOption);
        } else {
            var dlg = $('<div/>', {
                'class': 'mydlgClass', id: 'mydialog'
            }).html($('<iframe/>', {
                'src': url,
                'style': 'border: none; width: 100%;height:99%; height: calc(100% - 3px); margin: 0px;'
            })).dialog(dlgOption);
        }
        //dialog パラメタを設定する
        dlg.data("sendData", {
            "action": link,
            "query": params,
            "dialogArgs": dialogArgs
        });

        //dialogを公開する
        window.currentDialog = dlg.get(0);

        //dialog表示する
        dlg.dialog("open");
        return dlg;
    },
    /** window open
    *@param {String} link ページURL
    *@param {String} params クエリパラメタ
    *@param {Number} width 幅
    *@param {Number} height 高さ
    *@param {Function|Function=} callback(sender,returnValue) Nullの場合、モーダルレスになる 
    *@param {String|String=} windowName Window名つける
    *@return {Window} opened window
    */
    windowOpen: function (link, params, width, height, callback, windowName) {
        var owner = this;
        var elem = $(owner).size() > 0 ? $(owner).get(0) : null;
        var option;
        var top, left;
        var winName = windowName && typeof windowName === 'String' ? windowName : "";
        top = (screen.availHeight - height) / 2;
        left = (screen.availWidth - width) / 2;
        top = top > 0 ? top : 0;
        left = left > 0 ? left : 0;
        option = "ToolBar=No,"
        option += "Location=No,"
        option += "Directories=No,"
        option += "Status=No,"
        option += "MenuBar=No,"
        option += "ScrollBars=Yes,"
        option += "ReSizable=Yes,"
        option += "width=" + width + "px,"
        option += "height=" + height + "px,"
        option += "top=" + top + "px,"
        option += "left=" + left + "px,"

        var childWnd = window.open("../SysPage/wait1.html", winName, option);
        childWnd.document.write('<form name=\"form1\" action=\"' + link + '\" method=\"post\"><input type=\"hidden\" name=\"PostQuery\" value=\"\"></form>');
        childWnd.form1.PostQuery.value = params;
        childWnd.form1.submit();
        if (callback && $.isFunction(callback)) {
            window.openedWindow = { popWin: childWnd, target: elem, 'callback': callback };
            $(window).one("openwindowclosed", function () {
                if (window.openedWindow) {
                    var obj = window.openedWindow;
                    if (obj.callback && $.isFunction(obj.callback)) {
                        obj.callback(obj.target,null);
                    }
                    window.openedWindow = obj = null;
                }
                Rabit.fn.hideWaiting();
            });
            Rabit.fn.showLocker();
        }
        childWnd.focus();
        return childWnd;
    },
    /**ボタンのServerClickイベントを発生させるためSubmitする
    *@param {String|String=} param POST時送信するパラメタ 
    */
    triggerServerClick: function (param) {
        var button = $(this).get(0);
        if (button && $(button).filter("a,:submit,:button,:image").size() > 0) {
            var name = $(button).attr('name');
            if (!name || name=='') {
                name = $(button).attr('id')||'';
                name = name.replace(/_/g, "$");
            }
            if ($("#__EVENTTARGET").size() > 0) {
                //__EventTarget存在する場合
                $("#__EVENTTARGET").val(name);
                if (param) {
                    $("#__EVENTARGUMENT").val(param);
                }
            } else {
                //hiddenを追加する
                $("<input/>", {
                    'type': 'hidden',
                    'id': $(button).attr("id"),
                    'name': $(button).attr("name"),
                    'value': $(button).val()
                }).appendTo("form:eq(0)");
            }
        }
        Rabit.submit();
    },
    /**
    *calender Picker display
    *@param {Boolean|Boolean=} showPanel
    *@return {datepicker} jQuery UI datepicker object
    */
    datetimeText: function (showPanel) {
        $(this).focus(function () {
            $(this).attr("maxlength", "8");
            noFormat(this);
        });
        $(this).blur(function () {
            $(this).removeAttr("maxlength");
            ChangeDate(this);
        });
        return $(this).datepicker({
            changeMonth: true,
            changeYear: true,
            showOn: "button",
            buttonImage: "../images/calender.gif",
            buttonImageOnly: true,
            gotoCurrent: true,
            dateFormat: 'yymmdd',
            showButtonPanel: showPanel == false ? showPanel : true,
            beforeShow: function (elem, inst) {
                noFormat(elem);
            },
            onClose: function (date, inst) {
                ChangeDate(this);
            }
        });
    },
    /**Timepicker show
    */
    timeText: function () {
        $("<input type='button' class='watch' />").insertAfter($(this));
        $(this).datetimepicker({ datepicker: false, format: 'H:i', step: 15, mask:'29:59' });
        $(this).each(function () {
            var timer = this;
            $(timer).next(".watch:eq(0)").click(function (ev) {
                $(timer).datetimepicker('show');
            });
        });
    },
    /**画面印刷*/
    printf: function () {
        var isSupport = document.queryCommandSupported('print');
        if (isSupport) {
            document.execCommand('print');
            closeWindow(window);
        } else {
            window.print();
            window.setTimeout(function () { closeWindow(window); },1000);
        }
    }

});

/**ダイアログの戻り値を設定する
*@param {Object} data 戻り値を設定する
*/
function setData(data) {
    var dlg = window.currentDialog;
    if (dlg) {
        return $(dlg).data("returnData", data);
    } else {
        return null;
    }
}

/*ダイアログを閉じる
*if target is dialog or openWindow,please use closeWindow
*/
function closeDialog() {
    var dlg = window.currentDialog;
    if (dlg) {
        $(dlg).dialog("close");
        window.currentDialog = null;
    }
}

/**open windowを閉じる
*if target is dialog or openWindow,please use closeWindow
*@param {Window} childWindow
*@param {Object|Object=} returnValue
*/
function closeOpenWindow(childWindow, returnValue) {
    if (window.openedWindow) {
        var obj = window.openedWindow;
        if (obj.callback && $.isFunction(obj.callback)) {
            obj.callback(obj.target, returnValue);
        }
        window.openedWindow = obj = null;
    }
    if (childWindow && Rabit.fn.isWindow(childWindow)) {
        childWindow.close();
        Rabit.fn.hideWaiting();
        window.focus();
    }
}

/**open window或いはDialogを閉じる場合
*@param {Window} targetWindow
*@param {Object|Object=} returnValue 引数ない場合、Callbackしない
*/
function closeWindow(targetWindow, returnValue) {
    if (!targetWindow || !Rabit.fn.isWindow(targetWindow)) { return; }
    var parentWin = targetWindow.parent;
    var openerWin = targetWindow.opener;
    if (parentWin && parentWin.currentDialog) {
        //dialogの場合
        if (typeof returnValue !== 'undefined') {
            parentWin.setData(returnValue);
        }
        parentWin.closeDialog();
    } else if (Rabit.fn.isWindow(openerWin) && openerWin.openedWindow) {
        openerWin.closeOpenWindow(targetWindow, returnValue);
    } else {
        targetWindow.close();
    }
}

/**ダイアログのパラメタ*/
function GetArgs() {
    var dlg = window.currentDialog;
    if (dlg && $.hasData(dlg, "sendData")) {
        return $(dlg).data("sendData").dialogArgs;
    } else {
        return null;
    }
}

/**ページ初期化*/
$(document).ready(function () {
    try {
        Rabit.init();
        if (!Rabit.Browser.isMs) {
            Rabit.fn.createWaitingPanel();
        }
    } catch (e) {
        new AlertMessageType(e.message).Show();
    } finally {
        Rabit.fn.hideWaiting();
    }
});
