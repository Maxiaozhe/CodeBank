///<reference path="../common.js" />
$.fn.extend({
    fileView: function (mode) {
        var elem = $(this).get(0);
        return new FileView(elem,mode);
    }
});

function FileView(elem,mode) {
    this.view = elem;
    this.mode = mode;
    this.selectedDiv = null;
    this.dblClicked = false;
    this.init();
}
FileView.prototype = {
    init: function () {
        var view = this, elem = this.view;
        $("input[type=image]", elem).dblclick(function(ev){
            return view.ondblclick(ev); 
        });
        $("input[type=image]", elem).click(function(ev){
            return view.onclick(ev); 
        });
        var selimg = $("input[type=image]", elem).filter("[id*=SelImg]");
        if(selimg.size()>0){
            var tbl = $(selimg[0]).parents("table:eq(0)");
            view.selectedDiv = $("div",tbl)[0]; 
        }
        $("label", elem).dblclick(function(ev){
            return view.ondblclick(ev);
        });
        //scroll
        if (view.mode == 'visible') {
            $(elem).height("100%");
        } else {
            $(elem).hide();
            var parent = $(elem).parent();
            $(elem).height(parent.height());
            $(elem).show();
            var x, y;
            x = $("#" + elem.id + "_Scroll_X").val();
            y = $("#" + elem.id + "_Scroll_Y").val();
            $(elem).scrollLeft(x);
            $(elem).scrollTop(y);
            $(elem).scroll(function (ev) {
                var x, y;
                x = $(elem).scrollLeft();
                y = $(elem).scrollTop();
                $("#" + elem.id + "_Scroll_X").val(x);
                $("#" + elem.id + "_Scroll_Y").val(y);
            });
        }
    },
    ondblclick:function(e){
        var ev = e || window.event, btn, elem = ev.target;
        if(elem.tagName.toLowerCase()=='input'){
            btn=elem;
        }else if(elem.tagName.toLowerCase()=='label'){
            btn = $("#" + elem.htmlFor)[0];
        }
        if (btn) {
            this.dblClicked = true;
            $(btn).click();
        }
    },
    onclick: function (e) {
        if (this.dblClicked) {
            this.dblClicked = false;
            return;
        }
        var ev=e||window.event, vw = this.view, btn, elem = ev.target,div;
        var tbl = $(elem).parents("table:eq(0)");
        if($("div",tbl).size()>0){
            div = $("div", tbl)[0];
        }
        if(div && div!==this.selectedDiv){
            var index= $("input:hidden",div).val();
            $("#" + vw.id +"_SelectedIndex").val(index);
            this.setNormal(this.selectedDiv);
            this.setSelected(div);
            this.selectedDiv=div;
        }
        ev.preventDefault();
        return false;
    },
    setSelected:function(div){
        if(div){
            $(div).switchClass("normal", "selected");
        }
    },
    setNormal: function (div) {
        if (div) {
            $(div).switchClass("selected", "normal");
        }
    }

}