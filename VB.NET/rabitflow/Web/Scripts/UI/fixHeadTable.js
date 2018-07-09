///<reference path="../common.js" />
$.fn.extend({
    /**ヘッダ固定のテーブルを作成する
     *@param parent テーブルのコンテナー
     */
    fixTable: function (parent) {
        if ($(this).size() == 0 || parent == null || $(parent).size() == 0) {
            return;
        }
        $(this).formatTable();
        var ths = $("thead td", this);
        //すべでセルの幅を退避する
        var colgroup = "<colgroup>";
        for (var i = 0; i < ths.size() ; i++) {
            colgroup += "<col />";
        }
        colgroup += "</colgroup>";
        $(colgroup).insertBefore($("thead", this));
        var cols = $("col", this);
        for (var i = 0; i < ths.size() ; i++) {
            var width = $(cols[i]).width() > 0 ? $(cols[i]).width() : $(ths[i]).outerWidth();
            $(cols[i]).attr("width", width);
            $(cols[i]).css("min-width", width);
        }
        ths.css("width", "");
        var header = $(this).clone().addClass("fixheader");
        var headerId = header.attr("id") + "_header";
        header.attr("id", headerId);
        $("tbody", header).remove();
        header.insertBefore(this);
        $("thead", this).remove();
        header.wrap("<div style='overflow:hidden;'></div>");
        $(this).wrap("<div style='overflow:auto;'></div>");
        var headerDiv = $(header).parent("div");
        $(this).parent("div").on("scroll", function (ev) {
            headerDiv.scrollLeft($(this).scrollLeft());
        });
        $(parent).css("overflow", "hidden");
        $(this).resetFixTable(parent);
        var table = this;
        $(window).on("resize", function () {
            $(table).resetFixTable(parent);
        });
        return this;
    },
    /**ヘッダ固定のテーブルの高さを自動調整する*/
    resetFixTable: function (parent) {
        if ($(this).size()==0 || parent == null || $(parent).size() == 0) {
            return;
        }
        var bodyDiv = $(this).parent("div");
        var headerDiv = $(bodyDiv).prev();
        var bodyCols = $("col", this);
        var titleCols = $("col", headerDiv);
        var trs = $("tbody>tr", this).filter(":not(:hidden)");
        trs = $.grep(trs, function (tr) { return $(tr).find("td").size() == titleCols.size() });
        var tds = $(trs).size() > 0 ? $(trs[0]).find("td") : null;
        if (tds) {
            for (var i = 0; i < bodyCols.size() ; i++) {
                var width = $(tds[i]).outerWidth();
                $(bodyCols[i]).attr("width",width);
                $(titleCols[i]).attr("width", width);
            }
        }
        $("table:eq(0)", headerDiv).width($(this).width());
        var divWidth = $(parent).width() > $(this).width() + 20 ? $(this).width() + 18 : $(parent).width() - 1;
        var divheight = $(parent).height() - headerDiv.height() - 8;
        bodyDiv.width(divWidth);
        bodyDiv.height(divheight);
        
        if (bodyDiv.hasVScroll()) {
            headerDiv.width(divWidth - 18);
        } else {
            headerDiv.width(divWidth);
        }
    },
    /**横スクロールバー存在するか*/
    hasHScroll: function () {
        var elem = $(this).get(0);
        if (!elem) { return false; }
        var offsetHeight = elem.offsetHeight === 0 ? $(this).height() : elem.offsetHeight;
        return offsetHeight > elem.clientHeight;
    },
    /**横スクロールバー存在するか*/
    hasVScroll: function () {
        var elem = $(this).get(0);
        if (!elem) { return false; }
        var offsetWidth = elem.offsetWidth === 0 ? $(this).width() : elem.offsetWidth;
        return offsetWidth > elem.clientWidth;
    },
    formatTable: function () {
        var table = this;
        if ($(table).find("thead").size() > 0) {
            return;
        }
        var thead = $("tr:eq(0)", table);
        var tbody = $("tr:gt(0)", table);
        if ($("tbody", table).size() == 0) {
            $("<tbody />").appendTo(this);
            $("tbody", table).append(tbody);
        }
        $("<thead />").insertBefore($("tbody", table));
        $("thead", table).append(thead);
        return this;
    }
});