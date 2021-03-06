﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceApiTest.aspx.cs" Inherits="GoogleService.ServiceApiTest" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE11" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #autocomplete {
            width: 229px;
        }
        #map, #streeview {
            float: left;
            height: 600px;
            width: 550px;
            border:1px;
        }
         .label {
            font-size:11pt;
            white-space: nowrap;
            background-color: lightgrey;
        }
         .info{
             font-size:11pt;
             white-space: nowrap;
             width:100%;
         }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input id="autocomplete" runat="server" placeholder="住所を入力してください" type="text" value="東京都中央区晴海１−８−１" />
      <input id="btnSearch" runat="server" type="submit" value="検索" onserverclick="btnSearch_ServerClick" /></div>
      <div style="width:1200px; height:600px" id="content" runat="server">
           <table class="result">
            <tr>
                <td class="label">座標:</td>
                <td class="info">
                    <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="label">Place ID:</td>
                <td class="info">
                    <asp:Label ID="lblPlaceId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="label">マップ:</td>
                <td class="info">
                    <asp:HyperLink ID="lnkMap" runat="server" Target="_blank"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="label">ストリートビュー:</td>
                <td class="info">
                   <asp:HyperLink ID="lnkStreeView" runat="server" Target="_blank"></asp:HyperLink>
                </td>
            </tr>
        </table>
        <div>埋め込み地図とストリートビュー</div>
        <iframe id="map" runat="server"  frameborder="0" allowfullscreen ></iframe>
        <iframe id="streeview" runat="server" frameborder="0" allowfullscreen></iframe>
      </div>
    </form>
</body>
</html>
