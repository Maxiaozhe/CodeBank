function window_open(URL, WindowName, Option) {

    var dd;
    var org_target;
    var new_target;
    var org_action;
    var org_name;
    var org_viewstate;
    var hWnd;

    dd = new Date();

    if (WindowName != null && WindowName != "") {
        new_target = WindowName;
    } else {
        new_target = dd.getTime();
    }

    hWnd = window.open("../SysPage/wait1.html", new_target, Option);
    var URLs;
    URLs = URL.split("?", 2);
    hWnd.document.write('<form name=\"form1\" action=\"' + URLs[0] + '\" method=\"post\"><input type=\"hidden\" name=\"PostQuery\" value=\"\"></form>');
    hWnd.form1.PostQuery.value = URLs[1];
    hWnd.form1.submit();
    hWnd.focus();
}


function window_showModalDialog(URL, Argument, Option) {
    var Arg = new Array;
    Arg[0] = URL;
    Arg[1] = Argument;
    return window.showModalDialog('../SysPage/wait2.html', Arg, Option);
}


function GetDialogArguments(index) {
    if (window.dialogArguments.length > index) {
        return window.dialogArguments[index];
    }
    else {
        return window.dialogArguments;
    }
}