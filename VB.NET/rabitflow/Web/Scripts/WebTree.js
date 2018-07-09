///<reference path="../Scripts/jquery-1.12.4.js" /> 
function Expand(btn,Ctgid, ActionType) {

    var openImg;
    var closeImg;
    var panel = btn.parentElement;
    if (ActionType == 0) {
        // フォームの場合
        $("#SelectFrmCtgID").val(Ctgid);
        openImg = "../images/ketsu.gif";
        closeImg = "../images/ketsu.gif";
    } else {
        // ビューの場合
        $("#SelectViwCtgID").val(Ctgid);
        openImg = "../images/spacer.gif";
        closeImg = "../images/spacer.gif";
    }

    var expanded = false;
    $(panel).children("img").each(function () {
        if ($(this).attr("alt") == "+") {
            $(this).attr("alt", "-");
            $(this).attr("src", openImg);
            expanded = true;
        } else {
            $(this).attr("alt", "+");
            $(this).attr("src", closeImg);
            expanded = false;
        }
    });

    $(panel).children("div").each(function () {
        if (expanded) {
            $(this).css("display", "block");
        } else {
            $(this).css("display", "none");
        }
    });

    window.event.cancelBubble = true;
}

function SelectedForm(Ctgid, IDFRM) {
    $("#SelectFrmCtgID").val(Ctgid);
    $("#SelectFormID").val(IDFRM);
    $("#SelectViwCtgID").val("-1");
}

function SelectedView(Ctgid, IDVIW, IDFRM, SFRMCtgid) {
    $("#SelectFrmCtgID").val(Ctgid);
    $("#SelectViewID").val(IDVIW);
    $("#SelectFormID").val(IDFRM);
    $("#SelectFrmCtgID").val(SFRMCtgid);
}