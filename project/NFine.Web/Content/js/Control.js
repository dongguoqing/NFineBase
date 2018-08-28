$.createControls = function () {
    var id = "";
    $("input").each(function () {
        id = $(this).attr("id");//获取当前input的id 
        if ($(this).attr("ctrl") != null && $(this).attr("autoCreated") != "false") {
            var _ctrlName = $(this).attr("ctrl").toLowerCase();//获取当前的input的ctrl属性 根据该属性判断是什么控件
            switch (_ctrlName) {
                case "select":
                    break;
            }
        }
    })
}



function CreateSelect(controlId, ajaxurl, width, controlClass, isnull, title, onComplete, change) {
    if (ajaxurl == null)
        ajaxurl = $("#" + controlId).attr("ajaxurl");//获取ajax请求的地址
    width = width == null ? $("#" + controlId).css("width").replace("px", "") : width;
    isnull = isnull == null ? $("#" + controlId).attr("isnull") : isnull;
    title = title == null ? $("#" + controlId).attr("title") : title;
    controlClass = controlClass == null ? $("#" + controlId).attr("controlClass") : controlClass;

    if (width == null)//如果宽度是空 默认给250
        width = 250;

    var titleStr = "";
    if (title != null && title != "")
        titleStr = "title=\"" + title + "\"";
    if (controlClass == null)//给定默认样式  当前项目的下拉框默认样式为form-control
        controlClass = "form-control";
    $("#" + controlId).after("<select name=\"" + controlId + "_select\" Id=\"" + controlId + "_select\" class=\"" + controlClass + "\"></select>");
    if (isnull != null)//是否添加不可为空的属性
        $("#" + controlId + "_select").addClass("required");

    //
}

// -webkit-box-shadow: 0px 3px 3px #e9e9e9 inset;  投影方式 x轴偏移量 y轴偏移量 阴影模糊半径 阴影扩展半径 阴影颜色  兼容浏览器的写法 box-shadow  -webkit-box-shadow

////
//生成模糊下拉框
//options: json参数数组
////
$.fn.CreateddrList = function (options) {
    var _this = $(this);//当前要生成模糊下拉框的input标签
    var defaults = {
        ajaxurl: "",//请求的接口的地址
        liClick: function (strText, strValue) { },//模糊下拉框选中事件 默认为空
        loadingShow: false,//是否点击input标签就显示数据下拉框
        jsonData:null//请求传递的参数
    };
    var options = $.extend(defaults, options);
    var width = _this.css("width"), height = _this.css("height"), inputVal = _this.val();
    _this.hide();
    var ddrListObj = $(" <div style=\"position:relative;height:20px;display:inline-block;\" id=\"" + _this.attr("id") + "_div\"><input type=\"text\" value=\"" + inputVal + "\" id=\"" + _this.attr("id") + "_txt\" style=\"height:20px;width:" + width + ";line-height:20px;background-color:#ffffff;border:1px solid #cccccc;border-top:1px solid #acadb2;-webkit-border-radius:2px;-moz-border-radius:2px;border-radius:2px;over-flow:hidden;font-size:12px;color:#555555\" oninput=\"searchList(this.value)\" value=\"属性名\" maxlength=\"20\" style=\"width: 161px;\" /><ul id=\"" + _this.attr("id") + "_ul\" style=\"display:none;border:1px solid #d5d5d5;width:" + width + ";position:absolute;top:1.8em;overflow:hidden;background-color:#fff;max-height:160px;overflow-y:auto;border-top:1px solid #d5d5d5;z-index:10001;\" id=\"dropselect\"></ul></div>");
    //_this.after(ddrListObj);


    $.ajax({
        url: options.ajaxurl,
        type: "POST",
        data: {
            jsonData:options.jsonData
        },
        success: function (result) {
            var data = JSON.parse(result);
            $(data).each(function () {
                ddrListObj.find("ul").append("<li title=\"" + this.value + "\" style=\"\cursor:pointer;height:30px;line-height:2em;overflow:hidden;padding:0px 10px;border-top:1px solid #d5d5d5\"  onclick=\"" + options.liClick(this.text, this.value) + "\">" + this.text + "</li>");
            });
            ddrListObj.find("li").mouseover(function () {
                $(this).css("background-color", "#e9e9e9");
            })
            ddrListObj.find("li").mouseout(function () {
                $(this).css("background-color", "white");
            })
            _this.after(ddrListObj);
        },
        error: function () {
            _this.after(ddrListObj);
        }
    });

    //给input标签注册键盘事件
    ddrListObj.find("input").bind("keyup", function () {
        var count = 0;
        var this_i = this;
        var strValue = $(this_i).val();
        if (strValue != "") {
            $($(_this).attr("id") + "_ul").find("li").each(function (i) {
                var this_j = this;
                var contentValue = $(this_j).text();
                if ((contentValue.toLowerCase().indexOf(strValue.toLowerCase()) < 0) && (contentValue.toUpperCase().indexOf(strValue.toUpperCase()) < 0)) {
                    $(this).css("display", "none");
                    count++;
                } else {
                    $(this).css("display", "block");
                }
                if (count == (i + 1)) {
                    ddrListObj.find("ul").hide();
                } else {
                    ddrListObj.find("ul").show();
                }
            });
        }
    })

    ddrListObj.find("input").click(function () {
        if (options.loadingShow)
            ddrListObj.find("ul").show();
    })

    ddrListObj.find("input").bind("blur", function () {
        if ($(this).val() == "")
            $(this).val(inputVal);
    })

    $(document).click(function () {
        ddrListObj.find("ul").hide();
    });

}