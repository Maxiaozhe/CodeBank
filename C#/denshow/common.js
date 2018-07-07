///<reference path="jquery-1.12.4.js" />
///<reference path="jquery-ui.js" />
(function ($) {
    /*JQueryの拡張メソッドを定義する*/
    $.fn.extend({
        /**高さ自動変更設定
        *@param offset{int|int=0} オフセット値
        */
        dockSet: function (offset) {
            offset = offset || 0;
            for (i = 0; i < $(this).size() ; i++) {
                var elem = $(this).get(i);
                setFill(elem, offset);
            }
            return $(this);
            /*resizeイベントbindする*/
            function setFill(elem, offset) {
                var parent = $(elem).parent();
                if (parent.size() == 0 || parent.is("body,form")) {
                    /*親はform及びBody時,Windowにする*/
                    parent = $(window);
                }
                /*同じ階層のelementを取得する*/
                var siblings = $(elem).prevAll("p,div,span,table,br").add($(elem).nextAll("p,div,span,table,br"));
                adjustHeight(parent, elem, siblings, offset);
                $(parent).resize(function (event) {
                    adjustHeight(parent, elem, siblings, offset);
                });
            }
            /*高さを調整する*/
            function adjustHeight(parent, elem, siblings, offset) {
                if ($(parent).size == 0) {
                    return;
                }
                var thisH = $(parent).innerHeight() - offset;
                if ($.isWindow($(parent)[0])) {
                    thisH -= getMargin($("body"));
                }
                for (var i = 0; i < siblings.size() ; i++) {
                    var offsetHeight = $(siblings[i]).outerHeight();
                    var offsetMargin = getMargin(siblings[i]);
                    if ($(siblings[i]).is(":hidden")) {
                        if (siblings[i].tagName.toLowerCase() == "br") {
                            offsetHeight = 20;
                            offsetMargin = 0;
                        } else {
                            offsetHeight = 0;
                            offsetMargin = 0;
                        }
                    }
                    thisH -= offsetHeight;
                    thisH -= offsetMargin;
                }
                thisH -= getMargin(elem);
                thisH -= getParding(elem);
                var orgH = $(elem).height();
                $(elem).height(thisH);
                if (orgH != $(elem).height()) {
                    if (!$.isWindow(elem)) {
                        /*resizeイベントを発生する*/
                        $(elem).trigger("resize");
                    }
                }
            }
            /*paddingサイズを取得する*/
            function getParding(elem) {
                var top = 0;
                var bottom = 0;
                var parding = $(elem).css("padding-left");
                if (parding && parding != "") {
                    top = parseInt(parding)
                }
                parding = $(elem).css("padding-bottom");
                if (parding && parding != "") {
                    bottom = parseInt(parding)
                }
                return top + bottom;
            }
            /*margingサイズを取得する*/
            function getMargin(elem) {
                var top = 0;
                var bottom = 0;
                var margin = $(elem).css("margin-left");
                if (margin && margin != "") {
                    top = parseInt(margin)
                }
                margin = $(elem).css("margin-bottom");
                if (margin && margin != "") {
                    bottom = parseInt(margin)
                }
                return top + bottom;
            }
        },
        /**高さを自動適用を実行する*/
        fill: function () {
            $(window).trigger("resize");
            return $(this);
        },
        /**印刷*/
        print: function () {
            var ifrm = $("<iframe/>", {
                "class": "printDialog",
            //    "src": document.URL
            }).appendTo("body");
            /*コピーを取る*/
            var content = $(this).clone();
            /*scrollをしないようにする*/
            $(content).find("div").css("overflow-x", "visible");
            $(content).find("div").css("overflow-y", "visible");
            /*hrを非表示*/
            $(content).find("hr").css("display", "none");
            var win = ifrm[0].contentWindow;
            var doc = ifrm[0].contentDocument;
            var index = document.location.href.lastIndexOf('/');
            var cssPath = document.location.href.substr(0, index) + "/css/layout.css";
            doc.head.innerHTML = "<link rel='stylesheet' type='text/css' href='" + cssPath + "' />";
            doc.body.innerHTML = $(content).html();
            window.setTimeout(function () {
                if (doc.queryCommandSupported('print')) {
                    doc.execCommand("print", true, null);
                } else {
                    win.print();
                }
                $(".printDialog").remove();
                if (Denshow.Browser.chrome) {
                    Denshow.submit();
                }
            },100);
        },

        /**
         *モーダルダイアログを表示する
         *@param {String} link ページURL
         *@param {Number} width 幅
         *@param {Number} height 高さ
         *@param {Object|Object=} options
         *@param {Function|Function=} callback(event,sender,returnValue)
         *@return {Dialog} jQuery UI Dialog object
         */
        modalDialog: function (link, width, height, options, callback) {
            var url = link;
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
                title: '',
                resizable: false,
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
                $("#mydialog").remove();
            }
            dlg = $('<div/>', {
                'class': 'mydlgClass', id: 'mydialog'
            }).html($('<iframe/>', {
                'src': url,
                'style': 'border: none; width: 100%;height:99%; height: calc(100% - 5px); margin: 0px;'
            })).dialog(dlgOption);
            //dialogを公開する
            window.currentDialog = dlg.get(0);

            //dialog表示する
            dlg.dialog("open");
            return dlg;
        },
        /*ドロップダウンチェックリストを表示する
         *@width{Number} テキストの幅
         *@placeholder{String} 未選択時の表示
         */
        dropCheckList: function (width, placeholder) {
            function setCheckText(txtBox, checklist) {
                var checked = $(":checked", checklist);
                var selected = "";
                checked.each(function () {
                    if (selected != "") {
                        selected += ",";
                    }
                    selected += $(this).next("label").text();
                });
                $(txtBox).val(selected);
            }
            $(this).wrap("<div class='checklist_dropPanel' style='display:none;'></div>");
            var dropPanel = $(this).parent(".checklist_dropPanel");
            var displayText = $("<input class='checklist_displayText' type='text' readonly placeholder='" + placeholder + "' />").insertBefore(dropPanel);
            if (width && width > 0) { displayText.width(width) };
            setCheckText(displayText, this);
            var checkList = $(this);

            $(":checkbox", this).click(function () {
                setCheckText(displayText, checkList);
            });
            $("td", this).hover(function () {
                $(this).css("background-color", "lightgray");
            }, function () {
                $(this).css("background-color", "");
            });
            $(":checkbox", this).hover(function () {
                $(this).css("background-color", "gray");
            });


            displayText.click(function () {
                dropPanel.css("left", $(this).position().left);
                // dropPanel.width($(this).width());
                dropPanel.show();
            });
            $(document).mousedown(function (event) {
                var target = event.target;
                if ($(".checklist_displayText,.checklist_dropPanel,.checklist_dropPanel *").has(target).size() == 0) {
                    dropPanel.hide();
                }
            });

        },

        /*ドロップダウンチェックリストをクリアする*/
        clearCheckList: function () {
            $(":checked", this).prop("checked", false);
            $(this).parent(".checklist_dropPanel").prev(".checklist_displayText").val("");
        },
    });
}(jQuery));

var isDebug = false;
/*Denshow JavaScript Library v1.0.0*/
var Denshow = {
    /*初期Window幅*/
    defaultWidth: 1024,
    /*初期Window高さ*/
    defaultHeight: 720,
    //システムページのURL変数定義
    Urls: {
        /*ログイン画面*/
        F0_01: "./F0-01.aspx",
        /*パスワード変更画面*/
        F0_02: "./F0-02.aspx",
        /*一覧画面*/
        F0_03: "./F0-03.aspx",
        /*認識結果確認画面*/
        F0_04: "./F0-04.aspx",
        /*帳票画像表示*/
        F0_05: "./F0-05.aspx",
        /*コメント入力*/
        F0_06: "./F0-06.aspx",
        /*帳票確定画面*/
        F0_08: "./F0-08.aspx",
        /*エラー画面*/
        F0_09: "./F0-09.aspx",
        /*待ち画像*/
        WaitImgSrc: "./image/waiting.gif",
        ConfirmIcon: "./image/confirm.png",
        ErrorIcon: "./image/error.png",
        InfoIcon: "./image/info.png",
        openIcon: "./icon/open.png",
        closeIcon: "./icon/close.png"
    },
    //処理中フラグ
    submiting: false,
    unloadCheckOff: false,
    //Browser 情報取得する
    Browser: new BrowserInfo(),
    //画面処理化処理
    init: function () {
        //操作制御
        if (isDebug != true) {
            //右クリック禁止
            $(document).on("contextmenu", function (ev) {
                ev.returnValue = false;
                return false;
            });
            //キーイベントを無効化
            $(window).keydown(function (ev) {
                return Denshow.Events.document_onkeydown(ev);
            });
        }
        //F1キーを無効化
        $(window).on("help", function (ev) { return false; });

        //Form
        $("form").each(function () {
            this.onsubmit = function (event) {
                return Denshow.Events.form_submit(event);
            };
        });
    },
    // Javascriptでフォームsubmit時、この関数を呼び出します。
    // document.forms[0].submit()を直接使用しないでください。
    submit: function () {
        var form = $("form").get(0);
        if (!form.onsubmit || (form.onsubmit() != false)) {
            form.submit();
        }
    },
    useCloseAlert: function (isUse, message) {
        if (isUse) {
            //OpenWindowを閉じる前、親画面のロックを解除する
            $(window).on("beforeunload", function (event) {
                var ev = event || window.event;
                if (Denshow.submiting || Denshow.unloadCheckOff) { return; }
                return message;
            });
        } else {
            $(window).off("beforeunload");
        }
    }
}

/** Denshow JavaScript Library 共通イベント処理 */
Denshow.Events = {
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
        if (ev.altKey) {
            ev.keyCode = 0;
            ev.preventDefault();
            ev.stopPropagation();
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
                var allowFilter = "textarea,input:not([readonly])";
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
                return ev.returnValue;
            case 27:
                // ESCキー
                ev.keyCode = 0;
                ev.returnValue = false;
                return false;
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
                    ev.keyCode = 0;
                    ev.cancelBubble = false;
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
                    if (Denshow.Browser.ie11) {
                        alert("この操作は禁止です");
                    }
                    ev.preventDefault();
                    ev.stopPropagation();
                    ev.returnValue = false;
                    ev.keyCode = 0;
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
            case 65:
                // Ctrl + A （全選択)
            case 90:
                // Ctrl + Z (取消)
                if (ev.ctrlKey) {
                    return;
                }
                break;
            default:
                if (ev.ctrlKey) {
                    ev.keyCode = 0;
                    ev.cancelBubble = false;
                    ev.preventDefault();
                    ev.stopPropagation();
                    ev.returnValue = false;
                    return false;
                }
                break;
        }
    },

    //form_submit
    form_submit: function (e) {
        var ev = e || window.event;
        if (Denshow.submiting == true) {
            ev.returnValue = false;
            return false;
        } else {
            Denshow.submiting = true;
            //複数イベントバインドする場合、最後のハンドローラの戻り値を取得
            var ret = $(Denshow).triggerHandler('Action_Onsubmit');
            if (ret == false) {
                //submit canceled
                ev.returnValue = false;
                Denshow.submiting = false;
                return false;
            }
            Denshow.fn.showWaiting();
            return true;
        }
    },
};

/** Denshow JavaScript Library 内部使用関数定義 */
Denshow.fn = {
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
        $(".waiting").append("<img src='" + Denshow.Urls.WaitImgSrc + "' border='0'  />");
        $(".waiting").css("display", "none");
    },

    // 画面マスクと読み取り中動画を非表示する
    hideWaiting: function () {
        $(".maskdiv").hide();
        $(".waiting").hide();
        $(".maskdiv").off();
        if (Denshow.Browser.isMs) {
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
        if (Denshow.Browser.isMs) {
            Denshow.fn.createWaitingPanel();
        }
        Denshow.fn.resetPosition();
        $(".maskdiv").css("display", "block");
        $(".waiting").css("display", "block");
        $(window).resize(Denshow.fn.resetPosition)
                 .scroll(Denshow.fn.resetPosition);
    },
    //画面マスクを表示します
    showLocker: function () {
        if (Denshow.Browser.isMs) {
            Denshow.fn.createWaitingPanel();
        }
        Denshow.fn.resetPosition();
        $(".maskdiv").css("display", "block");
        $(".maskdiv").click(function () {
            Denshow.fn.popupChildWindow(window);
        });
        $(window).resize(Denshow.fn.resetPosition)
                 .scroll(Denshow.fn.resetPosition);
    },
    isWindow: function (win) {
        try {
            return win && win.document;
        } catch (e) {
            return false;
        }
    }
}

/*modalDialogダイアログを閉じる
*@param {Object} data 戻り値を設定する
*/
function closeDialog(returnValue) {
    var dlg = window.currentDialog;
    if (dlg) {
        //戻り値ある場合、設定する
        if (returnValue) {
            $(dlg).data("returnData", returnValue);
        }
        $(dlg).dialog("close");
        window.currentDialog = null;
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

/**ページ初期化*/
$(document).ready(function () {
    try {
        Denshow.init();
        if (!Denshow.Browser.isMs) {
            Denshow.fn.createWaitingPanel();
        }
    } catch (e) {
        alert(e.message);
    } finally {
        Denshow.fn.hideWaiting();
    }
});

/*アラートダイアログを表示する*/
function showInfoDialog(message, callbackId) {
    if ($("#infoDialog").size() == 0) {
        $(" <div id='infoDialog'><table><tr><td><image src='" + Denshow.Urls.InfoIcon + "' /></td><td><span ID='infoDialogLabel'></span></td></tr></table></div>").appendTo("body");
    }
    callbackId = callbackId || '';
    $("#infoDialog").dialog({
        //dialogClass: "no-titlebar",
        title: '情報', //タイトル
        autoOpen: false,  // 自動的に開かないように設定
        width: 400,       // 横幅のサイズを設定
        modal: true,      // モーダルダイアログにする
        buttons: [        // ボタン名 : 処理 を設定
          {
              text: 'OK',
              click: function () {
                  $(this).dialog("close");
                  if (callbackId != '') {
                      $("#" + callbackId).click();
                  }
              }
          }
        ]
    });
    if (message) {
        $("#infoDialogLabel").text(message);
        $("#infoDialog").dialog("open");
    };
}

/*確認ダイアログを表示する*/
function showConfirmDialog(message, okCallbackId, cancelCallbackId) {
    if ($("#confirmDialog").size() == 0) {
        $(" <div id='confirmDialog'><table><tr><td><image src='" + Denshow.Urls.ConfirmIcon + "' /></td><td><span ID='confirmDialogLabel'></span></td></tr></table></div>").appendTo("body");
    }
    okCallbackId = okCallbackId || '';
    cancelCallbackId = cancelCallbackId || '';
    $("#confirmDialog").dialog({
        //dialogClass: "no-titlebar",
        title: '確認', //タイトル
        autoOpen: false,  // 自動的に開かないように設定
        width: 400,       // 横幅のサイズを設定
        modal: true,      // モーダルダイアログにする
        buttons: [        // ボタン名 : 処理 を設定
          {
              text: 'OK',
              click: function () {
                  $(this).dialog("close");
                  if (okCallbackId != '') {
                      $("#" + okCallbackId).click();
                  }
              }
          },
          {
              text: 'キャンセル',
              click: function () {
                  $(this).dialog("close");
                  if (cancelCallbackId != '') {
                      $("#" + cancelCallbackId).click();
                  }
              }
          }
        ]
    });
    if (message) {
        $("#confirmDialogLabel").text(message);
        $("#confirmDialog").dialog("open");
    };
}

// 一時保存確認ダイアログ
function showSaveConfirmDialog(message, tempSaveCallbackId, disposCallbackId) {
    if ($("#saveConfirmDialog").size() == 0) {
        $(" <div id='saveConfirmDialog'><table><tr><td><image src='" + Denshow.Urls.ConfirmIcon + "' /></td><td><span ID='saveconfirmDialogLabel'></span></td></tr></table></div>").appendTo("body");
    }
    $("#saveConfirmDialog").dialog({
        //dialogClass: "no-titlebar",
        title: '確認', //タイトル
        autoOpen: false,  // 自動的に開かないように設定
        width: 400,       // 横幅のサイズを設定
        modal: true,      // モーダルダイアログにする
        buttons: [        // ボタン名 : 処理 を設定
          {
              text: '一時保存',
              click: function () {
                  $(this).dialog("close");
                  $("#" + tempSaveCallbackId).click();
              }
          },
          {
              text: '破棄',
              click: function () {
                  $(this).dialog("close");
                  $("#" + disposCallbackId).click();
              }
          },
          {
              text: 'キャンセル',
              click: function () {
                  $(this).dialog("close");
              }
          }
        ]
    });
    if (message) {
        $("#saveconfirmDialogLabel").text(message);
        $("#saveConfirmDialog").dialog("open");
    };
};

// エラーダイアログ
function showErrorDialog(message, callbackId) {
    if ($("#errordialog").size() == 0) {
        $(" <div id='errordialog'><table><tr><td><image src='" + Denshow.Urls.ErrorIcon + "' /></td><td><span ID='errordialogLabel'></span></td></tr></table></div>").appendTo("body");
    }
    callbackId = callbackId || '';
    $("#errordialog").dialog({
        //dialogClass: "no-titlebar",
        title: 'エラー',
        autoOpen: false,  // 自動的に開かないように設定
        width: 400,       // 横幅のサイズを設定
        modal: true,      // モーダルダイアログにする
        buttons: [        // ボタン名 : 処理 を設定
          {
              text: 'OK',
              click: function () {
                  $(this).dialog("close");
              }
          }
        ],
        close: function () {
            if (callbackId != '') {
                $("#" + callbackId).click();
            }
        },
    });
    if (message) {
        $("#errordialogLabel").text(message);
        $("#errordialog").dialog("open");
    };
}

/* ウィンドウ開く(画面起動時用)*/
function winopen(url) {
    var left, top, width, height;
    left = (screen.availWidth - Denshow.defaultWidth) / 2.0;
    top = (screen.availHeight - Denshow.defaultHeight) / 2.0;
    width = Denshow.defaultWidth;
    height = Denshow.defaultHeight;
    if (Denshow.Browser.chrome) {
        width += 5;
    }
    var features = "toolbar=no, menubar=no, status=no,location=no, directories=no,resizable=1, scrollbars=1,";
    features += "top=" + top + "px,left=" + left + "px,width=" + width + "px,height=" + height + "px";
    win = window.open("", "denshow", features);
    win.location = url;
    window.setTimeout(function () {
        var parentWin = window.open("", "_parent");
        parentWin.opener = window;
        parentWin.close();
    }, 1000);
}
/*サブウィンドウ開く*/
function winopen2(url) {
    var left, top, width, height;
    left = (screen.availWidth - Denshow.defaultWidth) / 2.0;
    top = (screen.availHeight - Denshow.defaultHeight) / 2.0;
    width = Denshow.defaultWidth;
    height = Denshow.defaultHeight;
    if (Denshow.Browser.chrome) {
        width += 5;
    }
    var features = "toolbar=no, menubar=no, status=no,location=no, directories=no,resizable=1, scrollbars=1,";
    features += "top=" + top + "px,left=" + left + "px,width=" + width + "px,height=" + height + "px";
    win = window.open(url, "host2", features, true);
}
