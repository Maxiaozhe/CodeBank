<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryPoem.aspx.cs" Inherits="PoemWebService.QueryPoem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        table{
            border-collapse:collapse;
            border-style:solid;
            border-color:gray;
            border-width:1px; 
        }
        .input{
            width:100%;
        }
        .commandButton{
            width:auto;
            height:24px;
        }
        .viewHeader td{
            height:23px;
            background-color:steelblue;
            color:black;
            text-align:center;
            font-weight:bold;
            border-style:solid;
            border-color:gray;
            border-width:1px; 
        }
        .viewdata td{
            border-collapse:collapse;
            border-style:solid;
            border-color:gray;
            border-width:1px; 
            background-color:lemonchiffon;
        }
        .keyword{
            background-color:pink;
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        function search() {
            var key = $("#txtSearchKey").get(0).value;
            PoemWebService.PoemApi.QueryPoem(key, onSuccess, onError);
            return false;

        }
        function onSuccess(datas) {
            var result = datas;
            var sb = new Sys.StringBuilder();
            var key = $("#txtSearchKey").get(0).value;
            sb.append("<table>");
            sb.append("<tr class='viewHeader'><td>No</td><td>作者</td><td>朝代</td><td>标题</td></tr>");
            for(var i=0;i<datas.length;i++){
                var item = datas[i];
                var body = item.Body;
                body = body.replace(/\n/g, '<br />');
                var regex = new RegExp(key, "g");
                body = body.replace(regex, "<span class='keyword'>$0</span>")
                sb.append("<tr class='viewdata'>");
                sb.append("<td>" + item.ID + "</td>");
                sb.append("<td>" + item.Author + "</td>");
                sb.append("<td>" + item.Dynasty + "</td>");
                sb.append("<td>" + item.Title + "</td>");
                sb.append("</tr>");
                sb.append("<tr>");
                sb.append("<td class='poemBody' colspan='4'>");
                sb.append(body);
                sb.append("</td>");
                sb.append("</tr>");
            }
            sb.append("</table>");
            $("#dataview").html(sb.toString());
            //$("#dataview").append(sb.toString());
        }
        function onError(data) {
            var result = data;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference path="PoemApi.svc" />
        </Services>
    </asp:ScriptManager>
    <div style="text-wrap:avoid;">
        <asp:TextBox ID="txtSearchKey" runat="server" CssClass="input"  AutoCompleteType="Search"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="检索" CssClass="commandButton" OnClientClick="return search();" />
    </div>
        <div id="dataview"></div>
    </form>
</body>
</html>
