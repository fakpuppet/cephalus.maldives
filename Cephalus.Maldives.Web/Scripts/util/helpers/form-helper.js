FormHelper = function () {
    return {
        ShowLoader: function ($submit) {
            if ($submit.data("showing-loader") !== !0) {
                var i = $submit[0].getBoundingClientRect().width
                    , r = parseInt($submit.css("padding-left"))
                    , u = parseInt($submit.css("padding-right"))
                    , f = parseInt($submit.css("border-left-width"))
                    , e = parseInt($submit.css("border-right-width"))
                    , t = $submit.closest("div");
                $submit.width(i - r - u - e - f);
                $submit.is("input") ? $submit.attr("data-value", $submit.val()) : $submit.attr("data-value", $submit.html());
                $submit.css("text-indent", "-9999px");
                t.addClass("loader-in-btn").addClass("loader-hover");
                t.find("i").length == 0 && t.append("<i><\/i>");
                t.find("i").css("top", parseInt(t.css("padding-top")) + ($submit.outerHeight() - 22) / 2);
                $submit.data("showing-loader", !0)
            }
        },
        HideLoader: function (n) {
            var t = n.data("showing-loader");
            t === !0 && (n.is("input") ? n.val(n.data("value")) : n.html(n.data("value")),
                n.removeAttr("style"),
                n.closest("div.loader-in-btn").removeClass("loader-in-btn").find("i:last:empty").remove(),
                n.data("showing-loader", !1))
        },
    };
}();