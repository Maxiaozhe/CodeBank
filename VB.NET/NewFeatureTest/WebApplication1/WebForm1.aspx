<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>無題のページ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br /><asp:DropDownList ID="DropDownList1" runat="server"  DataTextField="text" DataValueField="Value" Width="135px" AutoPostBack="True">
            <asp:ListItem Text='0' Value='0'></asp:ListItem>
            <asp:ListItem Text='1' Value='1'></asp:ListItem>
            <asp:ListItem Text='2' Value='2'></asp:ListItem>
        </asp:DropDownList>
        <br />
    </div>
    </form>
</body>
</html>
