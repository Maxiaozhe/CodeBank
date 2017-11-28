<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTest.aspx.cs" Inherits="GoogleService.ServiceTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/js/jquery-1.12.4.js" />
            </Scripts>
            <Services>
                <asp:ServiceReference Path="PlaceService.svc" />
            </Services>
        </asp:ScriptManager>
        <script type="text/javascript">
            $(function () {
                $("#btnSearch").click(function (ev) {
                    var key = $("#autocomplete").val();
                    GoogleService.PlaceService.DoTextSearch(key, onSuccess, onFailed);

                    return false;
                });
                function onSuccess(data) {
                    $("#places").off("change");
                    if (data.status === 'OK') {
                        $("#places option").remove();
                        for(var i =0;i<data.results.length;i++){
                            var result = data.results[i];
                            var opt=$("<option/>", {
                                "value": result.place_id
                            }).text(result.formatted_address).appendTo("#places");
                            opt.data("place", result);
                        }
                        $("#places").change(function (ev) {
                            var sel = $("#places").get(0);
                            var opt = sel.options[sel.selectedIndex];
                            var place = $(opt).data("place");
                            if (place) {
                                setPlaceInfo(place);
                            }
                        });
                        $("#places option:eq(0)").attr("selected", "selected");
                        $("#places").css("display", "");
                        setPlaceInfo(data.results[0]);
                    } else {
                        alert("対象データがありません。");
                        $("#places").css("display", "none");
                        $("#content").css("display", "none");
                    }
                }
                function onFailed(err) {
                    alert(err);
                }
                function setPlaceInfo(result) {
                    $("#lblAddress").text(result.formatted_address);
                    $("#lblLocation").text(result.geometry.location.lat + "," + result.geometry.location.lng);
                    $("#lblPlaceId").text(result.place_id);
                    var url = "mapview.aspx?id=" + result.place_id;
                    $("#lnkMap").attr("href", url);
                    $("#lnkMap").text(url);
                    $("#icon").attr("src", result.icon).attr("title", result.formatted_address);
                    var location = result.geometry.location.lat + "," + result.geometry.location.lng;
                    url = "streeview.aspx?location=" + location;
                    $("#lnkStreeView").attr("href", url);
                    $("#lnkStreeView").text(url);
                    $("#map").attr("src", result.EmbedMapUrl);
                    $("#streeview").attr("src", result.EmbedStreeViewUrl);
                    $("#content").css("display", "");
                }
            });
        </script>
        <input id="autocomplete" runat="server" placeholder="住所を入力してください" type="text" value="東京都中央区晴海１−８−１" />
        <input id="btnSearch" runat="server" type="submit" value="検索" />
        <select id="places" style="display:none"></select>
      <div style="width: 1200px; height: 600px; display: none" id="content" runat="server">
          <table class="result">
              <tr>
                  <td class="label">住所:</td>
                  <td class="info">
                      <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
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
                      <img id="icon" style="width:24px;" />
                      <asp:HyperLink ID="lnkMap" runat="server" Target="_blank" ClientIDMode="Static">[lnkMap]</asp:HyperLink>
                  </td>
              </tr>
              <tr>
                  <td class="label">ストリートビュー:</td>
                  <td class="info">
                      <asp:HyperLink ID="lnkStreeView" runat="server" Target="_blank" ClientIDMode="Static">[lnkStreeView]</asp:HyperLink>
                  </td>
              </tr>
          </table>

          <div>埋め込み地図とストリートビュー</div>
          <iframe id="map" runat="server" frameborder="0" allowfullscreen></iframe>
          <iframe id="streeview" runat="server" frameborder="0" allowfullscreen></iframe>
      </div>
    </form>
</body>
</html>
