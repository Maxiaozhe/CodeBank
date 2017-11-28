<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>無題のページ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 417px">
    
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
        </asp:RadioButtonList>
        <asp:Image ID="imgFlag" runat="server" />
        <br />
        <asp:Label ID="Label1" runat="server" Height="16px" Text="Label" Width="306px"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="85px" TextMode="MultiLine" Width="558px" Font-Names="NSimSun"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="444px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Font-Names="Arial" Text="Button" />
        <asp:Button ID="Button2" runat="server" Height="25px" Text="Button" Width="114px" />
        <br />
    
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="559px">
            <Columns>
                <asp:BoundField HeaderText="Name" />
                <asp:BoundField HeaderText="Tel" />
                <asp:BoundField HeaderText="Address" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
