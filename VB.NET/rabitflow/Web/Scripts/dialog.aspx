<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dialog.aspx.vb" Inherits="RJ.RabitFlow.dialog1" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
   <!-- <meta http-equiv="X-UA-Compatible"  content="IE=EmulateIE8" />-->
    <title></title>
    <link href="UI/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="jquery-1.12.4.js"></script>
    <script type="text/javascript" src="UI/jquery-ui.js"></script>
    <script type="text/javascript" src="MessageTypes.js"></script>
    <script type="text/javascript" src="Resources.js"></script>
    <script type="text/javascript" src="Common.js"></script>
    <style type="text/css">
        #Select1 {
            width: 161px;
            height: 126px;
        }
        .caption{
            width:120px;
            margin:1px 2px 1px 2px;
            line-height:24px;
            display:inline-block;
            background-color:lightblue;
        }
       
    </style>
    <script type="text/javascript">
        Rabit.JsonMessage = { Message: 'こんにちは！\nRabitFlowです', Type: 'confirm' };
        Rabit.Action_Enter = function (ev) {
            $(".debug").text(ev.keyCode);
        };
        Rabit.Action_Confirm = function (result) {
            if (result == true) {
              
            } else {
                alert("「いいえ」を押しました!");
            }
        };

        Rabit.Action_Onload = function () {
            $("#submitButton").click(function () {
                Rabit.submit();
            });
        };

        Rabit.Action_Onsubmit = function () {
            if (QuestionMessages.Save.Show()) {
                return true;
            } else {
                return false;
            }
        };
        ForbitPattern = '(<)|(>)|(&#)';
        UseTextForbitChar = true;
        
    </script>
</head>
<body onbeforeprint="return false;" >
       <form id="form1" method="post" runat="server">
           <span class="debug"></span>
           <input id="btnCancel" value="キャンセル" type="submit" />
            <input id="btnClosef" value="閉じる" type="submit" />
           <br /><span class="caption">readonly text:</span><input type="text" readonly="readonly" placeholder="readonly" />
           <br /><span class="caption">input text:</span><input type="text" placeholder="text" onblur="clEncode(this);" />
           <br /><span class="caption">textarea:</span><textarea placeholder="textarea" onblur="clEncode(this);"></textarea>
           <br /><span class="caption">hidden:</span><input type="hidden" id="hdnChampionPosition" runat="server" />
           <br /><span class="caption">input search:</span><input type="search" id="search" placeholder="search" />
           <br /><span class="caption">password:</span><input type="password" id="password" placeholder="password" />
           <br /><span class="caption">datetime:</span><input type="datetime" id="datetime" onblur="ChangeDate(this);"  />
           <br /><span class="caption">datetime-local:</span><input type="datetime-local" id="datetime-local" onblur="ChangeDate(this);" />
           <br /><span class="caption">color:</span><input type="color" id="color"   />
           <br /><span class="caption">Url:</span><input type="url" id="url"  />
           <br /><span class="caption">email:</span><input type="email" id="email"  placeholder="email"/>
           <br /><span class="caption">image:</span><input type="image" id="image" src="../Images/bbs.jpg"  runat="server" />
           <br /><span class="caption">month:</span><input type="month" id="month"  />
           <br /><span class="caption">number(整数):</span><input id="number" onkeydown="return NumberOnly(event);" onblur="nmFormat(this);" onfocus="noFormat(this);" />
           <br /><span class="caption">number(数値):</span><input id="numeric" onkeydown="return NumericOnly(event);" onblur="nmFormatEx(this);" onfocus="noFormat(this);" />
           <br /><span class="caption">range:</span><input max="100" step="1" min="0" type="range" id="range" value="12" />
           <br /><span class="caption">telephone:</span><input type="tel" id="tel" placeholder="tel" />
           <br /><span class="caption">time:</span><input type="time" id="time" onblur="ChangeTime(this);"  />
           <br /><span class="caption">file:</span><input type="file" id="file"  />
           <p>
           <input type="radio" id="radio1"  /><label for="radio1">radio1</label>
           <input type="radio" id="radio2" /><label for="radio2">radio2</label>
           </p>
           <input type="checkbox" id="check1" /><label for="check1">チェックボックス</label>
           <br />
           <select style="width: 103px"><option>A</option><option>B</option><option>C</option><option>D</option><option>E</option></select>
           <select id="Select1" multiple="multiple" name="D1">
               <option>A</option>
               <option>B</option>
               <option>C</option>
               <option>D</option>
           </select>
           <input type="button" value="Submit" id="submitButton" />
       </form>
</body>
</html>