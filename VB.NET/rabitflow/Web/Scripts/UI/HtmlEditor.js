///<reference path="../common.js" />
/** JQueryの関数を拡張 */
$.fn.extend({
    /**リッチテキストを作成する
    *@param {string} documentHtml 初期化HTML
    *@param {bool} mode 編集モード
    *@param {function} uiCreator ツールバーの構築関数
    */
    htmlEditor: function (documentHtml, mode, uiCreator) {
        var elem = $(this).get(0);
        var editor = new HtmlEditor(this, documentHtml, mode, uiCreator);
        return editor;
    }
});

function HtmlEditor(elem, documentHtml, mode, uiCreater) {
    this.orgElement = elem;
    this.iframe = null;
    this.documentHtml = documentHtml;
    this.editMode = mode;
    this.Dom = null;
    this.win = null;
    this.body = null;
    this.toolbar = null;
    this.event = null;
    this.commands = {};
    this.lastBookmark = null;
    this.commandUIs = {};
    this.hdnImageParam = "hdnImageParam";
    if (uiCreater && $.isFunction(uiCreater)) {
        this.initCommandUi(uiCreater);
    }
    this.init();
}

HtmlEditor.prototype = {
    /*既定初期化HTML*/
    INIT_HTML: '<!DOCTYPE html><html><head><link type="text/css" rel="stylesheet" href="../Style/StyleHandler.ashx" /></head><body class="richtext"></body></html>',
    /*キーイベント定義*/
    KeyEvent: {
        /*すべてFunctionキー*/
        Keys: { "F1": 112, "F2": 113, "F3": 114, "F4": 115, "F5": 116, "F6": 117, "F7": 118, "F8": 119, "F9": 120, "F10": 121, "F11": 122, "F12": 123, "ESC": 27, "TAB": 9 },
        /*すべてCtrl＋キー*/
        CtrlKeys: {
            "CtrlA": 65, "CtrlB": 66, "CtrlC": 67, "CtrlD": 68, "CtrlE": 69, "CtrlH": 72, "CtrlI": 73, "CtrlK": 75, "CtrlL": 76,
            "CtrlM": 77, "CtrlN": 78, "CtrlO": 79, "CtrlP": 80, "CtrlU": 85, "CtrlR": 82, "CtrlV": 86, "CtrlX": 88, "CtrlZ": 90
        },
        /*禁止するFunctionキー*/
        ForbidKeys: ["F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "ESC"],
        /*禁止するCtrl＋キー*/
        ForbidCtrlKeys: ["CtrlB", "CtrlD", "CtrlE", "CtrlH", "CtrlI", "CtrlK", "CtrlL", "CtrlM", "CtrlN", "CtrlO", "CtrlP", "CtrlU", "CtrlR"],
        /**キーを禁止しているかどうか*/
        isForbidKey: function (e) {
            var ev = e || window.event, key;
            for (var index in this.ForbidKeys) {
                key = this.CtrlKeys[index];
                if (ev.keyCode == this.ForbidKeys[key]) {
                    return true;
                }
            }
            if (ev.ctrlKey) {
                for (var index in this.ForbidCtrlKeys) {
                    key = this.ForbidCtrlKeys[index];
                    if (ev.keyCode == this.CtrlKeys[key]) {
                        return true;
                    }
                }
            }
            return false;
        },
        /**キーイベントを無視する*/
        skip: function (ev) {
            ev.keyCode = 0;
            ev.ctrlKey = false;
            ev.returnValue = false;
            ev.preventDefault();
            ev.stopPropagation();
            return false;
        }
    },
    /**エディタを初期化する*/
    init: function () {
        var editor = this;
        if (!this.body) {
            $.each(["backColor", "backColorUI", "bold", "copy", "createLink", "cut", "delete", "fontName", "fontSize", "foreColor", "foreColorUI", "formatBlock", "forwardDelete", "heading", "indent", "insertHorizontalRule", "insertImage", "uploadImage", "insertOrderedList", "insertHtml", "insertUnorderedList", "insertParagraph", "italic", "justifyCenter", "justifyFull", "justifyLeft", "justifyRight", "outdent", "paste", "redo", "removeFormat", "selectAll", "setBgcolor", "shadow", "strikeThrough", "subscript", "superscript", "underline", "undo", "unlink"], function (i, name) {
                editor.commands[name] = this.toString();
            });

            $(this.orgElement).addClass("editorHolder");
            if (this.editMode) {
                $(this.orgElement).append($("<div />", { 'class': 'htmleditor-toolbar'}));
                this.toolbar = $(".htmleditor-toolbar", $(this.orgElement)).get(0);
                //forbid user select
                if (this.toolbar && this.toolbar.onselectstart) {
                    $(this.toolbar).on("selectstart", function (ev) { return });
                }
            }
            $(this.orgElement).append(
                $("<iframe />", {
                    'class': 'htmleditor',
                    'style': 'border:1px; width: 100%; margin: 0px;'
                })
            );
            if ($(".htmleditor", $(this.orgElement)).size() == 0) {
                return;
            }
            //Dom init
            this.iframe = $(".htmleditor", $(this.orgElement)).get(0);
            this.win = this.iframe.contentWindow;
            this.Dom = this.iframe.contentDocument;
            this.Dom.write(this.INIT_HTML);
            this.Dom.close();
            this.body = $("body", this.Dom).get(0);
            $(this.body).html(this.documentHtml);
        }
        if (this.editMode) {
            this.Dom.designMode = "on";
            $(this.body).attr("contenteditable", true);
        } else {
            this.Dom.designMode = "off";
            $(this.body).attr("contenteditable", false);
        }
        //EventHandler
        //KeyBoard
        if (this.editMode) {
            $(this.Dom).keydown(function (ev) {
                return editor.htmlEditor_onkeydown(ev);
            });
            $(this.Dom).on("beforedeactivate", function (ev) {
                editor.onBeforedeactivate(ev);
            });
            if ($(this.Dom).hasOwnProperty('onselectionchange')) {
                $(this.Dom).on("selectionchange", function (ev) {
                    $(editor).trigger("_stateChanged");
                });
            } 
            $(this.Dom).on("mouseup click focus keyup blur", function (ev) {
                $(editor).trigger("_stateChanged");
            });
            //UI Create
            if ($(editor.toolbar).css('display') == 'none') {
                $(editor.toolbar).show();
            } else {
                if (editor.editMode) {
                    $(editor).trigger("initCommandUi");
                }
            }
            $(editor).on("_HtmlChanged", function (ev) {
                editor.htmlFormat();
                $(editor).trigger("HtmlChanged");
            });
            //State Changed event
            $(editor).on("_stateChanged", function (ev) {
                var status = editor.getStatues();
                $(editor).trigger("_HtmlChanged");
                for (var commandId in status) {
                    if (editor.commandUIs.hasOwnProperty(commandId)) {
                        $(editor.commandUIs[commandId]).trigger("setvalue", status[commandId]);
                    }
                }
                $(editor).trigger("stateChanged");
            });
        }
        //iframe size
        var ifmH = this.toolbar ? $(this.orgElement).height() - $(this.toolbar).height() : $(this.orgElement).height();
        $(this.iframe).height(ifmH-8);
        $(this.orgElement).resize(function (ev) {
            ifmH = editor.toolbar ? $(editor.orgElement).height() - $(editor.toolbar).height() : $(editor.orgElement).height();
            $(editor.iframe).height(ifmH - 8);
        });
    },
    _init_EditMode:function(){

    },
    initCommandUi: function (callback) {
        if ($.isFunction(callback)) {
            var editor = this;
            $(editor).on("initCommandUi", function (ev) {
                callback.call(editor, editor);
            });
        }
    },
    HtmlChanged: function (callback) {
        if ($.isFunction(callback)) {
            var editor = this;
            $(editor).on("HtmlChanged", function (ev) {
                callback.call(ev);
            });
        }
    },
    htmlFormat: function () {
        //ie bug fix
        this.tableFix();
        //remove empty elem 
        $("script", this.Dom).remove();
        $(":empty", this.Dom).filter("span,em,u,i,b,strong,font").remove();
        $("img", this.Dom).removeAttr("height").css("height","");
    },
    tableFix: function () {
        $("table>*,tbody>*", this.Dom).not("tbody,thead,tfoot,tr,th,td,colgroup,col").remove();
        $("tr > *:not(td)", this.Dom).remove();
        $("td ~ *:not(td)", this.Dom).remove();
        //table前後<br>追加
        if ($("table:last~*", this.Dom).filter("p,div,br").size() == 0) {
            $("table:last", this.Dom).after("<br />");
        }
        if ($("table:first", this.Dom).prevAll().filter("p,div,br").size() == 0) {
            $("table:first", this.Dom).before("<br />");
        }
    },
    /**エディタの状態を変更する*/
    stateChanged: function (callback) {
        if ($.isFunction(callback)) {
            var editor = this;
            $(editor).on("stateChanged", function (ev) {
                callback.call(ev);
            });
        }
    },
    /**HTMLを取得及び設定する
     * @param {string} source ソース（省略する場合取得）
     */
    html: function (source) {
        if (!source) {
            return $("body", this.Dom).html();
        } else {
            return $("body", this.Dom).html(source);
        }
    },
    /**HTMLをエンコードする*/
    encodeHtml: function () {
        var source = this.html();
        source = source.replace(/</g, "&lt;");
        source = source.replace(/>/g, "&gt;");
        return source;
    },
    _resetEditor:function(){
        var editor = this;
        var source = this.html();
        this.html(source);
        $(editor.Dom).off("beforedeactivate selectionchange mouseup click focus keyup");
        $(editor).off("_HtmlChanged _stateChanged");
        $(this.toolbar).hide();
        editor.init();
    },
    /**編集モードを変更する
     * @param {bool} mode ON/OFF
     */
    setEditMode: function (mode) {
        if (mode==null) {
            return this.editMode;
        }
        if (mode !== this.editMode) {
            if (mode) {
                this.Dom.designMode = "on";
                $(this.body).attr("contenteditable", true);
                this.editMode = true;
            } else {
                this.Dom.designMode = "off";
                $(this.body).attr("contenteditable", false);
                this.editMode = false;
            }
            this._resetEditor();
        }
        return this.editMode;
    },
    /**色を選択する*/
    selectColor: function (callback) {
        var editor = this;
        var button = editor.event.target;
        $(editor).modalDialog(
            //url,queryString
            Rabit.Pages.frmSelColorPage, "",
            //width,height
            220, 244,
            //options
            {
                dialogClass: 'colorpicker',
                position: { my: 'left top', at: "left bottom", of: button }
            },
            //dialogArgs
            null,
            //callback
            callback);
    },
    /**イメージをアップロードする*/
    uploadImage: function (callback) {
        var editor = this, url = Rabit.Pages.frmUploadImage, param = "";
        var hdn = $("input:hidden[id*=" + this.hdnImageParam + "]", editor.orgElement);
        if (hdn.size() > 0) {
            param = hdn.val();
        }

        $(editor).modalDialog(
            //url,queryString
            Rabit.Pages.frmUploadImage, param,
            //width,height
            600, 500,
            //options
            {
                dialogClass: 'imageUploader'
            },
            //dialogArgs
            null,
            //callback
            callback);
    },
    /**コマンドを実行する*/
    execCommand: function (commandId, ui, value) {
        try {
            var editor = this,dom = editor.Dom;
            var cmds = this.commands;
            editor.focus();
            switch (commandId) {
                case cmds.insertHtml:
                    editor.insertHtml(value);
                    break;
                case cmds.insertHorizontalRule:
                    editor.insertHtml('<hr class="htmleditor-hr" /><br />');
                    break;
                case cmds.shadow:
                    
                    var elem = editor.styleWithCss(null, { 'textShadow': '3px 3px 3px #404040' }, true);
                    $(elem).find("[style *= text-shadow]").css("textShadow", "");
                    var count = $(elem).find("span").size();
                    while (count > 0) {
                        count = 0;
                        $(elem).find("span").each(function () {
                            if (this.childElementCount == 0 && this.style.cssText == '') {
                                var txt = dom.createTextNode(this.innerText);
                                $(this).replaceWith(txt);
                                count++;
                            }
                        });
                    }
                    break;
                case cmds.foreColorUI:
                case cmds.backColorUI:
                    editor.setBookmark();
                    editor.selectColor(function (ev, sender, value) {
                        if (value == null) {
                            return false;
                        }
                        var cmdid = (commandId == cmds.foreColorUI) ? cmds.foreColor : cmds.backColor;
                        editor.execCommand(cmdid, false, value);
                    });
                    return;
                case cmds.setBgcolor:
                    editor.setBookmark();
                    editor.selectColor(function (ev, sender, value) {
                        if (value == null) {
                            return false;
                        }
                        //Set backColor
                        editor.focus();
                        var node = editor.getNode();
                        var frag = node.getFocusElement();
                        var elem = frag.elem;
                        if (elem && elem !== editor.body && elem !== editor.Dom.documentElement) {
                            elem.style.backgroundColor = value;
                            if (frag.isClone) {
                                node.apply(elem);
                            }
                            $(editor).trigger("_stateChanged");
                        }
                    });
                    return;
                case cmds.uploadImage:
                    editor.setBookmark();
                    editor.uploadImage(function (ev, sender, value) {
                        if (value == null) {
                            return false;
                        }
                        var html = "<img src='" + value + "' style='max-width:99%;max-width:calc(100% - 8px)'/>"
                        editor.insertHtml(html);
                        $(editor).trigger("_stateChanged");
                    });
                    return;
                case cmds.createLink:
                    var url = window.prompt("URL:", "http://");
                    if (url == '' || url.toLowerCase() == 'http://') {
                        return;
                    }
                    editor.Dom.execCommand(commandId, false, url);
                    $("a[target!=_blank]",editor.Dom).attr("target", "_blank");
                    break;
                default:
                    editor.Dom.execCommand(commandId, ui, value);
                    break;
            }
            $(editor).trigger("_stateChanged");
        } catch (err) {
            alert(err.message);
        }
    },
    queryCommandValue: function (commandId) {
        this.focus();
        var value = this.Dom.queryCommandValue(commandId);
        alert(value);
    },
    isIFrame: function (elem) {
        if (elem && elem.tagName && typeof elem.tagName === "string") {
            return elem.tagName.toLowerCase() == 'iframe';
        } else {
            return false;
        }
    },
    /**フォーカスを設定する*/
    focus: function () {
        this.setRng();
    },
    htmlEditor_onkeydown: function (e) {
        /* window.event属性はIEのみのため、
           event objectを使う場合下記のように使用してください。 */
        var ev = e || window.event;
        var keyEvent = this.KeyEvent;
        switch (ev.keyCode) {
            case keyEvent.CtrlKeys.CtrlB:
                // IE （お気に入りの整理ダイアログ出力）
                if (ev.ctrlKey) {
                    this.execCommand(this.commands.bold, false);
                    return keyEvent.skip(ev);
                }
                break;
            case keyEvent.CtrlKeys.CtrlI:
                // IE（お気に入りフレーム表示）
                if (ev.ctrlKey) {
                    this.execCommand(this.commands.italic, false);
                    return keyEvent.skip(ev);
                }
                break;
            case keyEvent.CtrlKeys.CtrlU:
                // IE（お気に入りフレーム表示）
                if (ev.ctrlKey) {
                    this.execCommand(this.commands.underline, false);
                    return keyEvent.skip(ev);
                }
                break;
            case keyEvent.Keys.TAB:
                if (ev.shiftKey) {
                    this.execCommand(this.commands.outdent, false);
                } else {
                    this.execCommand(this.commands.indent, false);
                }
                return keyEvent.skip(ev);
        }
        //禁止キーをSKIPする
        if (keyEvent.isForbidKey(ev)) {
            return keyEvent.skip(ev);
        }
        $(this).trigger("_HtmlChanged", ev);
    },
    htmlEditor_onkeyup: function (e) {
        var ev = e || window.event;
        var keyEvent = this.KeyEvent;
        if (keyEvent.isForbidKey(ev)) {
            return keyEvent.skip(ev);
        }
    },
    onBeforedeactivate: function (e) {
        var ev = e || window.event;
        var target = ev.target;
        this.setBookmark();
    },
    getStatues: function () {
        var rng = this.getRng();
        var bold = this.Dom.queryCommandState(this.commands.bold);
        var italic = this.Dom.queryCommandState(this.commands.italic);
        var underline = this.Dom.queryCommandState(this.commands.underline);
        var strikeThrough = this.Dom.queryCommandState(this.commands.strikeThrough);
        var justifyCenter = this.Dom.queryCommandState(this.commands.justifyCenter);
        var justifyLeft = this.Dom.queryCommandState(this.commands.justifyLeft);
        var justifyRight = this.Dom.queryCommandState(this.commands.justifyRight);
        var justifyFull = this.Dom.queryCommandState(this.commands.justifyFull);
        var subscript = this.Dom.queryCommandState(this.commands.subscript);
        var superscript = this.Dom.queryCommandState(this.commands.superscript);
        var fontName = this.Dom.queryCommandValue(this.commands.fontName);
        var fontSize = this.Dom.queryCommandValue(this.commands.fontSize);
        var foreColor = this.Dom.queryCommandValue(this.commands.foreColor);
        return {
            bold: bold,
            italic: italic,
            underline: underline,
            strikeThrough: strikeThrough,
            justifyCenter: justifyCenter,
            justifyLeft: justifyLeft,
            justifyRight: justifyRight,
            justifyFull: justifyFull,
            subscript: subscript,
            superscript: superscript,
            fontName: fontName,
            fontSize: fontSize
        };
    },
    getSelection: function () {
        return this.win.getSelection ? this.win.getSelection() : win.document.selection;
    },
    getBookmark: function (rng) {
        if (rng && rng.startContainer) {
            return {
                startContainer: rng.startContainer,
                startOffset: rng.startOffset,
                endContainer: rng.endContainer,
                endOffset: rng.endOffset
            }
        } else {
            return rng;
        }
    },
    setBookmark: function () {
        var rng = this.getRng();
        this.lastBookmark = this.getBookmark(rng);

    },
    setRng: function (rng) {
        var sel = this.getSelection();
        if (!rng) {
            rng = this.getRng();
        }
        if (sel && rng && sel.addRange) {
            sel.removeAllRanges();
            sel.addRange(rng);
        }
    },
    getRng: function () {
        var self = this, selection, rng, elm, doc, ieRng, evt;

        if (!self.win) {
            return null;
        }

        doc = self.win.document;
        selection = self.getSelection();
        try {
            if (selection) {
                if (selection.rangeCount > 0) {
                    rng = selection.getRangeAt(0);
                }
            }
        } catch (ex) {
            // IE throws unspecified error here if TinyMCE is placed in a frame/iframe
        }

        // Use last rng passed from FocusManager if it's available this enables
        // calls to editor.selection.getStart() to work when caret focus is lost on IE
        if (!rng && self.lastBookmark) {
            var bookmark = self.lastBookmark;

            // Convert bookmark to range IE 11 fix
            if (bookmark.startContainer) {
                rng = doc.createRange();
                rng.setStart(bookmark.startContainer, bookmark.startOffset);
                rng.setEnd(bookmark.endContainer, bookmark.endOffset);
            } else {
                rng = bookmark;
            }

        }
        if (!rng) {
            rng = selection.createRange ? selection.createRange() : doc.createRange();
        }

        // No range found then create an empty one
        // This can occur when the editor is placed in a hidden container element on Gecko
        // Or on IE when there was an exception
        if (!rng) {
            rng = doc.body.createTextRange();
        }

        // If range is at start of document then move it to start of body
        if (rng && rng.setStart && rng.startContainer.nodeType === 9 && rng.collapsed) {
            elm = self.body;
            rng.setStart(elm, 0);
            rng.setEnd(elm, 0);
        }

        return rng;
    },
    insertHtml: function (content) {
        var self = this, rng = self.getRng(), caretNode, doc = self.win.document, frag, temp;

        if (rng.insertNode) {
            // Make caret marker since insertNode places the caret in the beginning of text after insert
            content += '<span id="__caret">_</span>';

            // Delete and insert new node
            if (rng.startContainer == doc && rng.endContainer == doc) {
                // WebKit will fail if the body is empty since the range is then invalid and it can't insert contents
                doc.body.innerHTML = content;
            } else {
                rng.deleteContents();

                if (doc.body.childNodes.length === 0) {
                    doc.body.innerHTML = content;
                } else {
                    // createContextualFragment doesn't exists in IE 9 DOMRanges
                    if (rng.createContextualFragment) {
                        frag = rng.createContextualFragment(content);
                        rng.insertNode(frag);
                    } else {
                        // Fake createContextualFragment call in IE 9
                        frag = doc.createDocumentFragment();
                        temp = doc.createElement('div');

                        frag.appendChild(temp);
                        temp.outerHTML = content;

                        rng.insertNode(frag);
                    }
                }
            }
            // Move to caret marker
            caretNode = $("#__caret", self.Dom).get(0);

            // Make sure we wrap it compleatly, Opera fails with a simple select call
            rng = doc.createRange();
            rng.setStartBefore(caretNode);
            rng.setEndBefore(caretNode);
            self.setRng(rng);

            // Remove the caret position
            $("#__caret", self.Dom).remove();

            try {
                self.setRng(rng);
            } catch (ex) {
                // Might fail on Opera for some odd reason
            }
        } else {
            if (rng.item) {
                // Delete content and get caret text selection
                doc.execCommand('Delete', false, null);
                rng = self.getRng();
            }

            // Explorer removes spaces from the beginning of pasted contents
            if (/^\s+/.test(content)) {
                rng.pasteHTML('<span id="__mce_tmp">_</span>' + content);
                $("#__mce_tmp", self.Dom).remove();
            } else {
                rng.pasteHTML(content);
            }
        }

    },
    modify: function (elem, attrs, styles, switchCss) {
        if (!elem) { return; }
        var css = styles || {};
        var opts = attrs || {};
        for (attr in opts) {
            elem[attr] = opts[attr];
        }
        for (attr in css) {
            if (attr in elem.style) {
                if (switchCss && elem.style[attr] && elem.style[attr]!="") {
                    elem.style[attr] = "";
                } else {
                    elem.style[attr] = css[attr];
                }
            }
        }
        return elem;
    },
    styleWithCss: function (attrs, styles, switchCss) {
        var node = this.getNode(), css = styles | {}, elem, attr;
        switch (node.rangeType) {
            case 'element':
            case 'collapse':
                var frag = node.getFocusElement();
                elem = frag.elem;
                if (elem && /hr|img/gi.test(elem.tagName)==false) {
                    this.modify(elem, attrs, styles, switchCss);
                    if (frag.isClone) {
                        node.apply(elem);
                    }
                    return elem;
                }
                break;
            case 'text':
                elem = node.wrap("span", attrs, styles);
                node.apply(elem);
                break;
            case 'mix':
                elem = node.rng.commonAncestorContainer;
                //body 変更できない
                if (elem && elem === this.body || elem == this.Dom) {
                    return;
                }
                if (/table|tbody|th|tr|td/gi.test(elem.tagName)) {
                    this.modify(elem, attr, styles, switchCss);
                } else {
                    elem = node.wrap("span", attrs, styles);
                    node.apply(elem);
                }
                break;
        }
        return elem;
    },
    getNode: function () {
        var editor = this, sel, rng, frag;
        var isCloned = false;
        sel = editor.getSelection();
        rng = editor.getRng();
        frag = rng.cloneContents();
        var rangeType = '';
        if (rng.collapsed || frag.childNodes.length == 0) {
            rangeType = 'collapse';
        }
        if (frag.childNodes.length > 1) {
            rangeType = 'mix';
        }
        if (frag.childNodes.length == 1) {
            if (frag.childNodes[0].nodeType == 3) {
                rangeType = 'text';
            } else {
                rangeType = 'element';
            }
        }
        return {
            editor: editor,
            rng: rng,
            sel: sel,
            cloneFrag: frag,
            rangeType: rangeType,
            getFocusElement: function () {
                var frag = this.cloneFrag;
                if (frag.childNodes.length == 1) {
                    if (frag.childNodes[0].nodeType == 1) {
                        if (/td|tr|tbody|th|table/gi.test(frag.childNodes[0].tagName) == false) {
                            return { 'elem': frag.childNodes[0], 'isClone': true };
                        }
                    }
                }
                var cont = rng.commonAncestorContainer;
                while (cont && cont.nodeType !== 1) {
                    cont = cont.parentNode;
                }
                return { 'elem': cont, 'isClone': false };
            },
            wrap: function (tag, attrs, styles, switchCss) {
                var editor = this.editor, dom = editor.Dom, attr;
                var elem = dom.createElement(tag);
                elem.appendChild(this.cloneFrag);
                editor.modify(elem, attrs, styles, switchCss);
                return elem;
            },
            apply: function (elem) {
                rng.deleteContents();
                rng.insertNode(elem);
            }
        }
    },
    addCommand: function (opts) {
        var editor = this;
        function addCommandButton(opts) {
            if (!editor.toolbar) {
                return false;
            }
            var commandId = opts.commandId;
            var title = opts.name || "";
            var btn = $("<input/>",
                { "id": commandId, type: "image", "src": opts.src, "class": "htmleditor-ui-button", title: title })
                .attr("draggable",false)
                .appendTo($(editor.toolbar));
            editor.commandUIs[commandId] = btn;
            $(btn).click(function (e) {
                var ev = e || window.event;
                editor.event = ev;
                editor.execCommand(commandId, false);
                ev.preventDefault();
                editor.event = null;
                return false;
            });
            if (opts.type == 'pushbutton') {
                //pushbutton
                $(btn).on("mousedown mouseup", function (e) {
                    var pushed = $(this).attr("pushed");
                    if (pushed === "true") {
                        $(this).trigger("setvalue", false);
                    } else {
                        $(this).trigger("setvalue", true);
                    }
                });
            } else {
                //button
                $(btn).on("mousedown mouseout mouseup", function (e) {
                    var ev = e || window.event;
                    switch (ev.type.toLowerCase()) {
                        case "mousedown":
                            $(this).trigger("setvalue", true);
                            break;
                        case "mouseout": case "mouseup":
                            $(this).trigger("setvalue", false);
                            break;
                    }
                });
            }
            $(btn).on("setvalue", function (ev, value) {
                if (value) {
                    $(this).attr("src", opts.pushed);
                    $(this).attr("pushed", "true");
                } else {
                    $(this).attr("src", opts.src);
                    $(this).attr("pushed", "false");
                }
            });
        }
        function addCommandList(opts) {
            if (!editor.toolbar) {
                return false;
            }
            var commandId = opts.commandId;
            var title = opts.name || "";
            var list = [];
            if (opts.list && $.isArray(opts.list)) {
                list = opts.list;
            }
            else if (opts.list && typeof opts.list === 'string') {
                var str = new String();
                list = opts.list.split(",");
            }
            var sel = $("<select/>",
                { "id": commandId, "class": "htmleditor-ui-select", title: title })
                .appendTo($(editor.toolbar));
            $("<option/>").text(title).appendTo($(sel));
            for (var i = 0; i < list.length; i++) {
                $("<option/>").text(list[i]).appendTo($(sel));
            }
            editor.commandUIs[commandId] = sel;
            $(sel).change(function (ev) {
                var cmb = this;
                var opt = cmb.options[cmb.selectedIndex];
                if (cmb.selectedIndex == 0) {
                    return;
                }
                var val = $(opt).text();
                editor.execCommand(commandId, false, val);
            });
            $(sel).on("setvalue", function (ev, value) {
                var cmb = this;
                for (var i = 0; i < cmb.options.length; i++) {
                    var opt = cmb.options[i];
                    if ($(opt).text() == value) {
                        cmb.selectedIndex = i;
                        return;
                    }
                }
                cmb.selectedIndex = 0;
            });
        }

        if (!opts || !opts.commandId) {
            return false;
        }
        if (!opts.type) {
            opts.type = "button";
        }
        switch (opts.type) {
            case "list":
                addCommandList(opts);
                break;
            case "button":
            case "pushbutton":
                addCommandButton(opts);
                break;
            default:
                break;
        }
    },
    log: function (buff) {
        if (!buff || $("#log").size() == 0) { return; }
        if (typeof buff === 'string') {
            var txt = buff.replace(/\n/g, '<br />');
            $("#log").html(txt);
        } else {
            var txt = "";
            for (var fld in buff) {
                if ($.isFunction(buff[fld])) {
                    continue;
                }
                txt += fld.toString() + " : " + (buff[fld] ? buff[fld].toString() : '(null)') + "<br />";
            }

            for (var fld in buff) {
                if ($.isFunction(buff[fld])) {
                    txt += fld.toString()
                    this.log.arguments
                    txt += fld.toString() + " : " + (buff[fld] ? buff[fld].toString() : '(null)') + "<br />";
                }
            }
            $("#log").html(txt);
        }
    }

}
/**（未使用）既存のリッチテキストを互換するため保留する*/
function OpenLink(url) {
    var hWnd, top, left, width, height;
    width = 800;
    height = 600;
    top = (screen.availHeight - height) / 2;
    left = (screen.availWidth - width) / 2;
    top = top > 0 ? top : 0;
    left = left > 0 ? left : 0;
    var option = '';
    option += 'toolbar=no,';
    option += 'location=no,';
    option += 'directories=no,';
    option += 'status=no,';
    option += 'menubar=no,';
    option += 'scrollbars=yes,';
    option += 'resizable=yes,';
    option += 'width=' + width + ',';
    option += 'height=' + height + ',';
    option += 'top=' + top + ',';
    option += 'left=' + left + '';
    hWnd = window.open(url, 'popup', option);
    hWnd.focus();
}
/**HTMLをデコードする*/
function decodeHtml(text){
    var source = text;
    source = source.replace(/&lt;/g, "<");
    source = source.replace(/&gt;/g, ">");
    return source;
}