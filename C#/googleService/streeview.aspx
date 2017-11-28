<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="streeview.aspx.cs" Inherits="GoogleService.streeview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <style>
        body,div{
            margin:0px;
            padding:0px;
        }
        #root{
            position:fixed;
            width:100%;
            height:100%;
        }
        #streeviewFrame
        {
            width:100%;
            height:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="root">
            <iframe id="streeviewFrame" style="width:100%;height:100%" frameborder="0" runat="server" allowfullscreen></iframe>
        </div>
    </form>
</body>
</html>
