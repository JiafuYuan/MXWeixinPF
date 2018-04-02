<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="floorAblums.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.floorAblums" %>



<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by mxCMS Template Engine at 2014/4/29 1:42:17.
		本页面代码由mxCMS模板引擎生成于 2014/4/29 1:42:17. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	const int channel_id = 10;

	templateBuilder.Append("<html>\r\n    <head>\r\n        <meta charset=\"utf-8\" />\r\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("css/photo.css\" media=\"all\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("css/back.css\" media=\"all\" />\r\n<script src=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("js/share.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("js/common.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("js/picshow.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n \r\n<title>楼盘相册</title>\r\n        <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\" />\r\n<meta content=\"width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no\" name=\"viewport\">\r\n \r\n        <!-- Mobile Devices Support @begin -->\r\n            <meta content=\"application/xhtml+xml;charset=UTF-8\" http-equiv=\"Content-Type\">\r\n            <meta content=\"no-cache,must-revalidate\" http-equiv=\"Cache-Control\">\r\n            <meta content=\"no-cache\" http-equiv=\"pragma\">\r\n            <meta content=\"0\" http-equiv=\"expires\">\r\n            <meta content=\"telephone=no, address=no\" name=\"format-detection\">\r\n            <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n            <meta name=\"apple-mobile-web-app-capable\" content=\"yes\" /> <!-- apple devices fullscreen -->\r\n            <meta name=\"apple-mobile-web-app-status-bar-style\" content=\"black-translucent\" />\r\n        <!-- Mobile Devices Support @end -->\r\n    \r\n    </head>\r\n    <body onselectstart=\"return true;\" ondragstart=\"return false;\">\r\n        <style type=\"text/css\">\r\n            #popFail .bk {\r\n                background-color: rgba(194,194,194,0.5);\r\n            }\r\n\r\n            .pop_photo {\r\n                height: 100%;\r\n            }\r\n\r\n                .pop_photo .photo li {\r\n                    float: left;\r\n                    height: 100%;\r\n                }\r\n\r\n            .photo_show img {\r\n                background: #202020 url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEwAAAAYCAMAAABnVuv4AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NUJCMjQ0QzVEMEI3MTFFMjkzMTg5MzNDOTA1MTA5QjAiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NUJCMjQ0QzZEMEI3MTFFMjkzMTg5MzNDOTA1MTA5QjAiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo1QkIyNDRDM0QwQjcxMUUyOTMxODkzM0M5MDUxMDlCMCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo1QkIyNDRDNEQwQjcxMUUyOTMxODkzM0M5MDUxMDlCMCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PgGdvqYAAAAzUExURT8/PyYmJkFBQTAwMCMjI0NDQzc3NygoKDs7OzIyMjk5OS0tLSsrKz09PTQ0NEVFRSAgIP6uubIAAAERSURBVHja7JTbjoMwDERN7oTY4///2rXTitUWtUUVD/vQkYJMsA+T4EB6oegL+w+wWl+kVK66jHQaxvwiZWCo2LgM9omzpQHNlrxxBq82kVrObLBoCZFXyn2x2ZVArbyBpYDWkZMKiTA21QAWmstUG7kXdA9C6ZnfwCLW+8VdQnT1eOwwc9WDKujJzvyBCapDmqYeAIMVr/+FzRStKOdgvs1g5VzGMBhDj7AxrZ+ARa8tOt89ndUjzK1b4XMYDdcCisP3O4QxmsEieNvCA8z8stiX0Vv3ieWpL2OHYcqKTeYuZiD4c7GAHmFJQu70FLZrMXuzScb9gKXb/UEJ5ZqDHpvM5rsGZn0Ttu+f9hL9CDAAnbBqw3t+r9QAAAAASUVORK5CYII=) no-repeat center center;\r\n            }\r\n\r\n            .pop_photo .photo li {\r\n                background: url(data:image/gif;base64,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) no-repeat center center;\r\n            }\r\n\r\n                .pop_photo .photo li.noLoading {\r\n                    opacity: 0;\r\n                    *filter: alpha(opacity=0);\r\n                }\r\n\r\n                .pop_photo .photo li img {\r\n                    border-radius: 5px;\r\n                }\r\n        </style>\r\n        <label id=\"fid\" title=\"");
	templateBuilder.Append(MxWeiXinPF.Common.MyCommFun.QueryString("fid"));
	templateBuilder.Append("\" style=\"display:none;\"></label>\r\n<div class=\"wrapper\">\r\n<!-- start -->\r\n<div class=\"photo_area\" id=\"scroller\" style=\"opacity:0;\"><!--  photo_wide -->\r\n<ul class=\"photo_show\" id=\"scrollList\" style=\"left:0;\"></ul><!-- 由于每个li的宽度不固定，需要用js来获取ul的宽度 -->\r\n<ul class=\"nav_photo\" id=\"scrollTips\"></ul>\r\n</div>\r\n<div class=\"pop_photo\" id=\"scroller1\" style=\"display:none;\">\r\n<ul class=\"photo\"  id=\"scrollPic\"></ul>\r\n<div class=\"info\"  id=\"picName\"></div>\r\n<a href=\"javascript:void(0);\" id=\"photoClick\" class=\"btn_show_close\" style=\"z-index:9999;\"><span>关闭</span></a>\r\n</div>\r\n<!-- end -->\r\n</div>\r\n<div id=\"popFail\" style=\"\">\r\n<div class=\"bk\"></div>\r\n<div class=\"cont\">\r\n<img src=\"");
	//templateBuilder.Append(Utils.ObjectToStr(config.templateskin));
	templateBuilder.Append("img/loading.gif\" alt=\"loading...\">\r\n正在加载...\r\n   </div>\r\n</div>\r\n<div class=\"pop_tips\" id=\"popTips\" style=\"display:none;\">\r\n<div class=\"oval\"></div>\r\n<div class=\"pop_show\">\r\n<h4 id=\"tipsTitle\">温馨提示</h4>\r\n<div class=\"pop_info\" id=\"tipsMsg\">\r\n<p></p>\r\n</div>\r\n<div class=\"pop_btns\">\r\n<a href=\"javascript:void(0);\" id=\"tipsOK\">确定</a>\r\n<a href=\"javascript:void(0);\" style=\"display:none;\" id=\"tipsCancel\">取消</a>\r\n</div>\r\n</div>\r\n</div>\r\n<div class=\"pop_mask\" id=\"popMask\" style=\"display:none;\"></div>\r\n<script type=\"text/template\" id=\"template1\"><!--缩略图-->\r\n");
	templateBuilder.Append("<% for(var i=0,il=data.length;i < il;i++){ var idx = i%9 + 1;%>");
	templateBuilder.Append("\r\n<li class=\"color_");
	templateBuilder.Append("<%=idx%>");
	templateBuilder.Append("\" id=\"picshow");
	templateBuilder.Append("<%=idx%>");
	templateBuilder.Append("\">\r\n");
	templateBuilder.Append("<%\r\nfor(var ps=1;ps<3;ps++){\r\nvar psdata = data[i]['ps'+ps];\r\n                %>");
	templateBuilder.Append("\r\n                <div class=\"ps_");
	templateBuilder.Append("<%=ps%>");
	templateBuilder.Append("\">\r\n");
	templateBuilder.Append("<% for(var j=0,jl=psdata.length;j<jl;j++){\r\nif(psdata[j].type == 'title'){\r\n%>");
	templateBuilder.Append("\r\n<div class=\"ps_1_0\" style=\"width:");
	templateBuilder.Append("<%=psdata[j].width%>");
	templateBuilder.Append("px;max-width:");
	templateBuilder.Append("<%=psdata[j].width%>");
	templateBuilder.Append("px;overflow:hidden;\"><h3>");
	templateBuilder.Append("<%=psdata[j].title%>");
	templateBuilder.Append("</h3><p>");
	templateBuilder.Append("<%=psdata[j].subTitle%>");
	templateBuilder.Append("</p></div>\r\n");
	templateBuilder.Append("<% }else if(psdata[j].type == 'img'){ %>");
	templateBuilder.Append("\r\n<div style=\"max-width:");
	templateBuilder.Append("<%=psdata[j].size[0]*(150/psdata[j].size[1])%>");
	templateBuilder.Append("px;\"><img id=\"thubImg");
	templateBuilder.Append("<%=psdata[j].idx%>");
	templateBuilder.Append("\"\r\n  onclick=\"PICSHOW.slidePics(this,");
	templateBuilder.Append("<%=psdata[j].idx%>");
	templateBuilder.Append(");\"\r\n  src=\"data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==\"\r\n  osrc=\"");
	templateBuilder.Append("<%=psdata[j].img%>");
	templateBuilder.Append("\" alt=\"");
	templateBuilder.Append("<%=psdata[j].name%>");
	templateBuilder.Append("\"\r\n  width=\"");
	templateBuilder.Append("<%=psdata[j].size[0]*(150/psdata[j].size[1])%>");
	templateBuilder.Append("\" height=\"150\"/></div>\r\n");
	templateBuilder.Append("<% }else if(psdata[j].type == 'text'){ %>");
	templateBuilder.Append("\r\n<div class=\"ps_2_0\" style=\"width:");
	templateBuilder.Append("<%=psdata[j].width%>");
	templateBuilder.Append("px;max-width:");
	templateBuilder.Append("<%=psdata[j].width%>");
	templateBuilder.Append("px;\"><!-- 根据文字的多少计算层的宽度 -->\r\n<p>");
	templateBuilder.Append("<%=psdata[j].content%>");
	templateBuilder.Append("</p>\r\n</div>\r\n");
	templateBuilder.Append("<% } /*end of psdata[j].type*/\r\n                    } /*end of psdata loop*/\r\n                    %>");
	templateBuilder.Append("\r\n</div>\r\n                ");
	templateBuilder.Append("<%\r\n                } /* end of ps for*/\r\n                %>");
	templateBuilder.Append("\r\n</li>\r\n");
	templateBuilder.Append("<%  } /* end of data.leng */\r\n        %>");
	templateBuilder.Append("\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/tempalte\" id=\"template2\"><!-- 数据-->\r\n");
	templateBuilder.Append("<% for(var i=0,il=data.length;i<il;i++){ var cidx = i+start, cls = (i == idx) ? ' class=\"current\"':''; %>");
	templateBuilder.Append("\r\n            <li><a href=\"javascript:void(0);\"");
	templateBuilder.Append("<%=cls%>");
	templateBuilder.Append(" onclick=\"sTo(");
	templateBuilder.Append("<%=cidx%>");
	templateBuilder.Append(");return false;\">");
	templateBuilder.Append("<%=data[i]%>");
	templateBuilder.Append("</a></li>\r\n        ");
	templateBuilder.Append("<% }%>");
	templateBuilder.Append("\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/template\" id=\"template3\"><!--大图浏览-->\r\n");
	templateBuilder.Append("<% for(var i=0,il=data.length;i<il;i++){ %>");
	templateBuilder.Append("<li style=\"width:");
	templateBuilder.Append("<%=R.w%>");
	templateBuilder.Append("px;\" class=\"noLoading\" id=\"bLi");
	templateBuilder.Append("<%=data[i].idx%>");
	templateBuilder.Append("\">\r\n<img id=\"bImg");
	templateBuilder.Append("<%=data[i].idx%>");
	templateBuilder.Append("\" load=\"false\" width=\"");
	templateBuilder.Append("<%=R.w%>");
	templateBuilder.Append("\" height=\"");
	templateBuilder.Append("<%=R.h%>");
	templateBuilder.Append("\" src=\"data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==\">\r\n</li>");
	templateBuilder.Append("<% } %>");
	templateBuilder.Append("\r\n</");
	templateBuilder.Append("script>\r\n\r\n<script>\r\n    var PID = 300;\r\n    var WECHATID = 'fromUsername';\r\n</");
	templateBuilder.Append("script>\r\n\r\n<a href=\"javascript:history.go(-1);\" class=\"back360\" style=\"\">&nbsp;</a> \r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>