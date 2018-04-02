//购买数量增加或减少
var DOEVENT = document.hasOwnProperty("ontouchstart") ? "tap" : "click";

(function ($) {
	$.extend($,{
		showMask:function(){			 
			if(!$("#load_mask")[0]){
				var h = $(document.body).height()+"px";
			 	$("<div id='load_mask' class='tc_zz' style='height:"+h+"' />").appendTo("body");
			}else{				 
				$("#load_mask").show();
			}
			return this;
		},
		hideMask:function(){
			$("#load_mask").hide()			 
			return this;
		},
		 
        tip : function(content,s) {
            if(content){
				$("#alert_tip")[0]||$("body").append("<div id='alert_tip'><div></div><div class='alert_content'>"+content+"</div></div>");
				var t=$(document).scrollTop(),h=$(window).height();
				$("#alert_tip").css("top",h*0.3+t+"px");
				$("#alert_tip").is(":hidden")&&(
					$("#alert_tip > div.alert_content").html(content),
					$("#alert_tip").show(),
					typeof(s)=="number"?s!=-1&&window.setTimeout(function(){$("#alert_tip").hide();},s*1000):window.setTimeout(function(){$("#alert_tip").hide();},3000))
			}
			return this;
        },
		after : function(s,callback) {
			s = s || 10;
			callback = $.type(callback)==="function" ? callback : function(){null};
			window.setTimeout(callback,s);
		},
		Dialog:function(config){
			var options = {
				title: "系统提示",  // 弹窗的标题
				content: null,    //内容:文本或html
				button: {},     //按钮对象 {按钮文字:点击事件,...}
				ismask: !0,   //是否遮罩
				isclose: !0,   //关闭按钮
				callback: null   //弹出后回调
			},html, $D, D =  $.extend(options, config);
			$("#Dialog")[0]&&$("#mask").remove();$("#Dialog").remove();
			D.ismask&&(html = "<div id='mask'></div>");
			html+="<div id='Dialog'><div><b>"+D.title+"</b><span><a href='javascript:'></a></span></div><div class='text'><div></div>";
			$(html).appendTo("body");$D=$("#Dialog");
			D.ismask&&$("#mask").css("height",$("body").height());
			var t=$(document).scrollTop(),h=$(window).height();
			D.content&&$D.find(".text").html(D.content);
			$D.css("top",h*0.2+t+"px");
			typeof(D.callback)=="function"&&D.callback($D);
			D.isclose&&$("#Dialog span a").text("关闭").on(events_click,function(){$D.close();});
			!$.isEmptyObject(D.button)&&$.each(D.button, function(t, f){$("<a href='javascript:;'>"+t+"</a>").appendTo("#Dialog").on(events_click,function(){f($D);});});
			$D.close = function(){$("#mask").remove();$D.remove();};
			return this;
		}		 
	});
 
})($);

//js stringbuffer类
function StringBuffer()
{
    this.__strings__ =[];
}
StringBuffer.prototype.append = function(str){
    this.__strings__.push(str);
};
StringBuffer.prototype.toString = function(){
    return this.__strings__.join("");
}

//输出并显示功能导航菜单
function showNav() {
    if ($("#divNav")[0]) {
        $("#divNav").remove();
    }

    var buffer = new StringBuffer();
    buffer.append("<div class=\"gncd\" id=\"divNav\">");
    buffer.append("<header class=\"header\"><span class=\"fh left\"><a href=\"#\">&nbsp;</a></span><span class=\"title\">功能导航</span></header>");
    buffer.append("<div class=\"gncd_bottom\">");
    buffer.append("    <a href=\"/\" class=\"proCateg\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc9.png\"></span>");
    buffer.append("        <p>首页</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/navigation/index.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc1.png\"></span>");
    buffer.append("        <p>商品分类</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/member/memberCenter.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc6.png\"></span>");
    buffer.append("        <p>我的海尔</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/order/orderList.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc4.png\"></span>");
    buffer.append("        <p>订单查询</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/collect/collectList.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc3.png\"></span>");
    buffer.append("        <p>我的收藏</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/history/historyList.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc7.png\"></span>");
    buffer.append("        <p>历史浏览</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/eltItemComment/eltItemCommentList.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc8.png\"></span>");
    buffer.append("        <p>我的评价</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"/mobile/consulting/consultingList.html\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/ioc5.png\"></span>");
    buffer.append("        <p>我的咨询</p>");
    buffer.append("    </a>");
    buffer.append("    <a href=\"#\" class=\"lxkf\">");
    buffer.append("        <span>");
    buffer.append("            <img src=\"images/v2/public/icon.png\"></span>");
    buffer.append("        <p>联系客服</p>");
    buffer.append("    </a>");
    buffer.append("</div>");
    buffer.append("</div>");

    //追加到body
    $(buffer.toString()).appendTo($(document.body));
    //动态设定高度
    $("#divNav").height(document.body.scrollHeight || document.documentElement.scrollHeight).show();

    $("#divNav .fh a").on(DOEVENT, function (e) {
        e.preventDefault();
        $("#divNav").hide();
    });

    //商品分类
    var categBuffer = new StringBuffer();
    categBuffer.append("<a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc1.png\"></span>");
    categBuffer.append("       <p>冰箱</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc2.png\"></span>");
    categBuffer.append("       <p>空调</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc3.png\"></span>");
    categBuffer.append("       <p>洗衣机</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc4.png\"></span>");
    categBuffer.append("       <p>彩电</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc5.png\"></span>");
    categBuffer.append("      <p>厨房卫浴</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc6.png\"></span>");
    categBuffer.append("       <p>手机数码</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc7.png\"></span>");
    categBuffer.append("       <p>生活家电</p>");
    categBuffer.append("   </a>");
    categBuffer.append("   <a href=\"#\">");
    categBuffer.append("       <span>");
    categBuffer.append("           <img src=\"images/v2/public/s_ioc8.png\"></span>");
    categBuffer.append("       <p>家庭医疗</p>");
    categBuffer.append("   </a>");

    $("#divNav .proCateg").on(DOEVENT, function () {
        $("#divNav .title").text("商品分类");
        $(this).parent().html(categBuffer.toString());
    });
}
//隐藏功能导航菜单
/*function hideNav()
{
    $("#divNav").hide();
}
//展示导航菜单
$(function(){
	$(".right_but").on(DOEVENT, function () {
		showNav();
	});  
});*/