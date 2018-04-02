<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="htImg.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.htImg" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="MxWeiXinPF.Common" %>

<script runat="server">
    override protected void OnInit(EventArgs e)
    {

        /* 
            This page was created by mxCMS Template Engine at 2014/4/29 1:42:17.
            本页面代码由mxCMS模板引擎生成于 2014/4/29 1:42:17. 
        */

        base.OnInit(e);
        StringBuilder templateBuilder = new StringBuilder(220000);
        //const int channel_id = 8;

        templateBuilder.Append("\r\n<!DOCTYPE html>\r\n<html>\r\n    <head>\r\n        <meta charset=\"utf-8\" />\r\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("css/style.css\" media=\"all\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("css/back.css\" media=\"all\" />\r\n<script src=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("js/share.js\" type=\"text/javascript\"></");
        templateBuilder.Append("script>\r\n<script src=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("js/common.js\" type=\"text/javascript\"></");
        templateBuilder.Append("script>\r\n<script src=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("js/picroll.js\" type=\"text/javascript\"></");
        templateBuilder.Append("script>\r\n<title>楼盘户型图</title>\r\n        <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\" />\r\n<meta content=\"width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no\" name=\"viewport\">\r\n        \r\n        <!-- Mobile Devices Support @begin -->\r\n            <meta content=\"application/xhtml+xml;charset=UTF-8\" http-equiv=\"Content-Type\">\r\n            <meta content=\"no-cache,must-revalidate\" http-equiv=\"Cache-Control\">\r\n            <meta content=\"no-cache\" http-equiv=\"pragma\">\r\n            <meta content=\"0\" http-equiv=\"expires\">\r\n            <meta content=\"telephone=no, address=no\" name=\"format-detection\">\r\n            <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n            <meta name=\"apple-mobile-web-app-capable\" content=\"yes\" /> <!-- apple devices fullscreen -->\r\n            <meta name=\"apple-mobile-web-app-status-bar-style\" content=\"black-translucent\" />\r\n        <!-- Mobile Devices Support @end -->\r\n       \r\n    </head>\r\n    <body onselectstart=\"return true;\" ondragstart=\"return false;\">\r\n        <style type=\"text/css\">\r\n            .btn_zoom_in, .btn_zoom_out, .btn_down {\r\n                bottom: 100px;\r\n            }\r\n\r\n            .btn_down {\r\n                left: 20px;\r\n            }\r\n\r\n            .btn_zoom_in, .btn_zoom_out {\r\n                right: 20px;\r\n            }\r\n\r\n            .zoomDiv {\r\n                width: 100%;\r\n                height: 100%;\r\n                display: none;\r\n                z-index: 299;\r\n                overflow: scroll;\r\n                text-align: center;\r\n                background: rgba(0,0,0,0.7) url() no-repeat center center;\r\n                background-size: 30px 30px;\r\n            }\r\n\r\n            .type_up .btn_more {\r\n                top: 45px;\r\n            }\r\n\r\n            .type_full .type_up .btn_more {\r\n                top: 22px;\r\n            }\r\n\r\n            .type_full .type_info .type_num {\r\n                display: none;\r\n            }\r\n        </style>\r\n\r\n<div id=\"zoomDiv\" class=\"zoomDiv\">\r\n<img id=\"zoomImg\" width=\"200%\" height=\"200%\" src=\"\" />\r\n</div>\r\n<div id=\"detailContainer\" class=\"type_show\"><!-- 全部开时加上样式type_full -->\r\n<div class=\"picwrap\" id=\"picTank\"></div>\r\n<div class=\"type_info\" id=\"picDetail\" onclick=\"Picroll.switchDetail();\"></div>\r\n<a href=\"javascript:void(0);\" class=\"btn_show_close\"><span>关闭</span></a>\r\n</div>\r\n<a href=\"javascript:void(0);\" class=\"btn_down\" style=\"display:none;\"><span>下载</span></a>\r\n<a href=\"javascript:void(0);\" class=\"btn_zoom_out\" style=\"display:none;\"><span>放大</span></a>\r\n<div class=\"pop_tips\" id=\"popTips\" style=\"display:none;\">\r\n<div class=\"oval\"></div>\r\n<div class=\"pop_show\">\r\n<h4 id=\"tipsTitle\">温馨提示</h4>\r\n<div class=\"pop_info\" id=\"tipsMsg\">\r\n<p></p>\r\n</div>\r\n<div class=\"pop_btns\">\r\n<a href=\"javascript:void(0);\" id=\"tipsOK\">确定</a>\r\n<a href=\"javascript:void(0);\" style=\"display:none;\" id=\"tipsCancel\">取消</a>\r\n</div>\r\n</div>\r\n</div>\r\n<div id=\"popFail\" style=\"\">\r\n<div class=\"bk\"></div>\r\n<div class=\"cont\">\r\n <input id=\"fid\" type=\"hidden\" value=\"");
        templateBuilder.Append(MyCommFun.QueryString("fid"));
        templateBuilder.Append("\"/>\r\n <input id=\"wid\" type=\"hidden\" value=\"");
        templateBuilder.Append(MyCommFun.QueryString("wid"));
        templateBuilder.Append("\"/>\r\n <input id=\"htid\" type=\"hidden\" value=\"");
        templateBuilder.Append(MyCommFun.QueryString("id")); 
        templateBuilder.Append("\"/> \r\n<img src=\"");
        //templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
        templateBuilder.Append("img/loading.gif\" alt=\"loading...\">\r\n正在加载...\r\n</div>\r\n</div>\r\n<div class=\"pop_mask\" id=\"popMask\" style=\"display:none;\"></div>\r\n<script type=\"text/template\" id=\"template\">\r\n<p class=\"type_num\" id=\"typeNum\">1/");
        templateBuilder.Append("<%=data.total%>");
        templateBuilder.Append("<%=data.name%>");
        templateBuilder.Append("</p>\r\n<a href=\"javascript:void(0);\" class=\"type_up\">\r\n<strong>");
        templateBuilder.Append("<%=data.name%>");
        templateBuilder.Append("</strong>\r\n<span>");
        templateBuilder.Append("<%=data.desc%>");
        templateBuilder.Append("</span>\r\n<em>");
        templateBuilder.Append("<%=data.rooms%>");
        templateBuilder.Append("<%=data.area%>");
        templateBuilder.Append("</em>\r\n<span class=\"btn_more\">详情</span>\r\n</a>\r\n<div class=\"type_detail\">\r\n<p>楼层：");
        templateBuilder.Append("<%=data.floor%>");
        templateBuilder.Append("</p>");
        templateBuilder.Append("<%\r\nif(data.dtitle.length>0){%>");
        templateBuilder.Append("<%for(var i=0,il=data.dtitle.length;i<il;i++){ %>");
        templateBuilder.Append("\r\n<p>");
        templateBuilder.Append("<%=data.dtitle[i]%>");
        templateBuilder.Append("</p>\r\n");
        templateBuilder.Append("<% } %>");
        templateBuilder.Append("<%\r\n    	}else /*if data.dtitle.length>0 else */ { %>");
        templateBuilder.Append("<%if(data.area){%>");
        templateBuilder.Append("<p>建筑面积：");
        templateBuilder.Append("<%=data.area%>");
        templateBuilder.Append("</p>");
        templateBuilder.Append("<%} /*end of if(data.area)*/ %>");
        templateBuilder.Append("<%if(data.inner){%>");
        templateBuilder.Append("<p>套内面积：");
        templateBuilder.Append("<%=data.inner%>");
        templateBuilder.Append("</p>");
        templateBuilder.Append("<%} /*end of if(data.inner)*/%>");
        templateBuilder.Append("<%} /*end of if data.dtitle.length>0 */ %>");
        templateBuilder.Append("\r\n<ul>\r\n");
        templateBuilder.Append("<%for(var i=0,il=data.dlist.length;i<il;i++){%>");
        templateBuilder.Append("\r\n<li>");
        templateBuilder.Append("<%=data.dlist[i]%>");
        templateBuilder.Append("</li>\r\n");
        templateBuilder.Append("<% } %>");
        templateBuilder.Append("\r\n</ul>\r\n</div>\r\n</");
        templateBuilder.Append("script>\r\n\r\n<script>\r\n    var PID = 141;\r\n    var houseid = 1");
        //templateBuilder.Append(Utils.ObjectToStr(model.id));
        templateBuilder.Append(";\r\n    var WECHATID = '';\r\n</");
        templateBuilder.Append("script>\r\n\r\n<a href=\"javascript:history.go(-1);\" class=\"back360\" style=\"\">&nbsp;</a>        	 \r\n\r\n</body>\r\n</html>");
        Response.Write(templateBuilder.ToString());
    }
</script>

