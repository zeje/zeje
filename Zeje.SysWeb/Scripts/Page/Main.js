/*#region 时间格式化*/
Date.prototype.format = function (format) {
    if (!format) {
        format = "yyyy-MM-dd hh:mm:ss";
    }
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours(), // hour
        "m+": this.getMinutes(), // minute
        "s+": this.getSeconds(), // second
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
        "S": this.getMilliseconds()
        // millisecond
    };
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};

function formatDateTime(str) {
    if (str == null) {
        return "";
    }
    //str = str.replace("CEST", "");
    //return (new Date(str)).format("yyyy-MM-dd hh:mm:ss");

    //参见ToJsonResult
    return str.replace('T', ' ');//2012-01-05 01:02:01
}

function formatDate(str) {
    if (str == null) {
        return "";
    }
    //str = str.replace("CEST", "");
    //return (new Date(str)).format("yyyy-MM-dd");

    //参见ToJsonResult
    return str.slice(0, 10);//2012-01-05
}

/*#endregion*/

/*#region easyui datagrid按钮拼接*/
//planButtons:预计按钮json，实际按钮json
//[{buttonKey:"",buttonText:"",buttonFunction:"",functionParams:[],IsShow:true}]
//['Add','Edit',]
function DataGridOptString(planButtons, buttonArrays) {
    var tempBtnA = "&nbsp;<a href='#' class='AButton' onclick=\"{0}({1})\">{2}</a>&nbsp;";
    var tempBtnB = "&nbsp;<a href='#' class='AButton AButtonDisable'>{2}</a>&nbsp;";
    var btn = '';
    $.each(planButtons, function (i, btnJson) {
        if (btnJson.IsShow) {
            var tmpbtn = '';
            if ($.inArray(btnJson.buttonKey, buttonArrays) != -1) {
                tmpbtn = tempBtnA;
                tmpbtn = tmpbtn.replace("{0}", btnJson.buttonFunction)
                if (btnJson.functionParams) {
                    var tmpParams = new Array();
                    for (var i = 0; i < btnJson.functionParams.length; i++) {
                        tmpParams.push("'" + btnJson.functionParams[i] + "'");
                    }
                    tmpbtn = tmpbtn.replace("{1}", tmpParams.join(","))
                }
                else {
                    tmpbtn = tmpbtn.replace("{1}", "")
                }
                tmpbtn = tmpbtn.replace("{2}", btnJson.buttonText);
                btn += tmpbtn;
            }
            else {
                btn += tempBtnB.replace("{2}", btnJson.buttonText);
            }
        }
    });
    return btn;
}
/*#endregion*/

//Datagrid显示文本
function GetAreaText(mystr) {
    if (mystr == null || mystr == "") {
        return ("&nbsp;");
    }
    else {
        mystr = mystr.replace(/\r\n/, "<br/>");
        mystr = mystr.replace(/\n/, "<br/>");
        mystr = mystr.replace(/\t/, "　　");
        return (mystr);
    }
}

//  
/*#region 采用jquery easyui loading css效果*/
function ajaxLoading() {
    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"></div>").html("努力工作中，请稍候......").appendTo("body")
        .css({
            display: "block",
            left: ($(document.body).outerWidth(true) - 190) / 2,
            top: ($(window).height() - 45) / 2
        });
}
function ajaxLoadEnd() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

/*$.ajax({  
    type: 'POST',  
    url: 'sendLettersAgain.action',  
    data: {id:obj.id},  
    beforeSend:ajaxLoading,\\发送请求前打开进度条  
    success: function(robj){  
        ajaxLoadEnd();\\任务执行成功，关闭进度条  
        }  
}）;*/
/*#endregion*/
