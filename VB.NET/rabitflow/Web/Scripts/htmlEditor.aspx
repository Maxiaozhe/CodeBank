<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dialog.aspx.vb" Inherits="RJ.RabitFlow.dialog1" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <!-- <meta http-equiv="X-UA-Compatible"  content="IE=EmulateIE8" />-->
    <title></title>
    <link href="UI/jquery-ui.css" rel="stylesheet">
    <link href="../Style/StyleHandler.ashx" rel="stylesheet">
    <link href="../Style/rabit_style_1.css" rel="stylesheet">
    <script type="text/javascript" src="jquery-1.12.4.js"></script>
    <script type="text/javascript" src="UI/jquery-ui.js"></script>
    <script type="text/javascript" src="MessageTypes.js"></script>
    <script type="text/javascript" src="Resources.js"></script>
    <script type="text/javascript" src="Common.js"></script>
    <script type="text/javascript" src="UI/HtmlEditor.js"></script>
    <style type="text/css">
        #Select1 {
            width: 161px;
            height: 126px;
        }

        .caption {
            width: 120px;
            margin: 1px 2px 1px 2px;
            line-height: 24px;
            display: inline-block;
            background-color: lightblue;
        }
    </style>
    <script type="text/javascript">
        var commandUis = [
        { type: 'list', commandId: 'fontName', name:'フォント',list: ['Arial', 'Baskerville', 'Baskerville Old Face', ' Courier', 'Courier New', 'Georgia', 'Verdana', 'MS UI Gothic', 'メイリオ', 'ＭＳ 明朝'] },
        { type: 'list', commandId: 'fontSize', name: 'サイズ', list: ['1', '2', '3', '4', '5', '6', '7'] },
        { type: 'pushbutton', commandId: 'bold', src: '../images/usrFLW0115/Bold.gif', pushed: '../images/usrFLW0115/Bold2.gif', name: '太字' },
        { type: 'pushbutton', commandId: 'italic', src: '../images/usrFLW0115/Italic.gif', pushed: '../images/usrFLW0115/Italic2.gif', name: '斜体' },
        { type: 'pushbutton', commandId: 'underline', src: '../images/usrFLW0115/Undline.gif', pushed: '../images/usrFLW0115/Undline2.gif', name: '下線' },
        { type: 'pushbutton', commandId: 'justifyLeft', src: '../images/usrFLW0115/Left.gif', pushed: '../images/usrFLW0115/Left2.gif', name: '左揃え' },
        { type: 'pushbutton', commandId: 'justifyCenter', src: '../images/usrFLW0115/center.gif', pushed: '../images/usrFLW0115/center2.gif', name: '中央揃え' },
        { type: 'pushbutton', commandId: 'justifyRight', src: '../images/usrFLW0115/right.gif', pushed: '../images/usrFLW0115/right2.gif', name: '右揃え' },
        { type: 'button', commandId: 'foreColorUI', src: '../images/usrFLW0115/fontcolor.gif', pushed: '../images/usrFLW0115/fontcolor2.gif', name: 'フォントの色' },
        { type: 'button', commandId: 'backColorUI', src: '../images/usrFLW0115/BgColor.gif', pushed: '../images/usrFLW0115/BgColor2.gif', name: 'フォントの背景色' },
        { type: 'button', commandId: 'setBgcolor', src: '../images/usrFLW0115/fill.gif', pushed: '../images/usrFLW0115/fill2.gif', name: '背景色' },
        { type: 'button', commandId: 'shadow', src: '../images/usrFLW0115/shadow.gif', pushed: '../images/usrFLW0115/shadow2.gif', name: '影' },
        { type: 'button', commandId: 'createLink', src: '../images/usrFLW0115/link.gif', pushed: '../images/usrFLW0115/link2.gif', name: 'リンクの作成' },
        { type: 'button', commandId: 'unlink', src: '../images/usrFLW0115/Unlink.gif', pushed: '../images/usrFLW0115/Unlink2.gif', name: 'リンクの削除' },
        { type: 'button', commandId: 'insertHorizontalRule', src: '../images/usrFLW0115/hr.gif', pushed: '../images/usrFLW0115/hr2.gif', name: '水平線の挿入' },
        { type: 'button', commandId: 'uploadImage', src: '../images/InsFile1.gif', pushed: '../images/InsFile2.gif', name: 'イメージ挿入' },
        { type: 'button', commandId: 'removeFormat', src: '../images/usrFLW0115/clear.gif', pushed: '../images/usrFLW0115/clear2.gif', name: '書式のクリア' }
        ];

        var myeditor;

        $(function () {
            commandUis[0].list = fontNames;
            var editor = $("#htmlEditor").htmlEditor("<div>Input here!</div>", true, initCommandBar);
            myeditor = editor;
            editor.HtmlChanged(function (ev) {
                $("#htmlsource").val(editor.html());
            });
 
            for (var fld in editor.commands) {
                $("<option/>").text(fld).appendTo("#commands");
            }

            $("#execCmd").click(function (ev) {
                var sel = $("#commands").get(0);
                var opt = sel.options[sel.selectedIndex];
                var cmd = $(opt).text();
                var value = $("#value").val();
                editor.execCommand(cmd, false, value);
            });
            $("#setHtml").click(function (ev) {
                editor.html($("#htmlsource").val());
            });
            
            $("#setreadonly").click(function () {
                editor.setEditMode(!editor.editMode);
            })

            function initCommandBar(editor) {
                if (!commandUis) { return; }
                for (var i = 0; i < commandUis.length; i++) {
                    var cmdOpt = commandUis[i];
                    editor.addCommand(cmdOpt);
                }
            }

        })
    </script>
</head>
<body onbeforeprint="return false;">
    <form id="form1" method="post" runat="server">
        <div id="htmlEditor" spellcheck="true" style="width:100%; min-width: 500px; height: 100%; min-height: 300px; border: 1px solid gray;">
            <asp:HiddenField ID="hdnImageParam" runat="server" />
        </div>
        <div id="dialog">
            <select id="commands"></select>
            <input id="value" style="width: 200px;" type="text" />
            <input id="execCmd" type="button" value="ExecCommand" />
            <input id="setHtml" type="button" value="resetHtml" />
            <input id="setreadonly" type="button" value="readonly" /></div>
        <textarea id="htmlsource" style="width: 100%; height: 300px">

        </textarea>
        <span id="log"></span>
    </form>

</body>
</html>
