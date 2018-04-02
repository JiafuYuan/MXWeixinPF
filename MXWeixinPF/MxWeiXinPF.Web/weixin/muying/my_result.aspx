<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_result.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.muying.my_result" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>体检信息</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/onlinebooking.css" rel="stylesheet" type="text/css">
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <style>
        .round li.manage {
            display: none;
        }
    </style>
</head>

<body id="onlinebooking-no" class="mode_webapp">
    <div class="cardexplain">
        <!--用户的所有体检信息-->
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <ul class="round">
                    <input type="hidden" name="formhash" id="formhash" value="322ec242" />
                    <li class="title mb"><span class="none"><%#MyCommFun.Obj2DateTime(Eval("tijiandate")).ToString("MM月dd日 hh:mm") %>体检详情</span></li>
                    
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>身高</th>
                                <td><%#Eval("tijiangao") %>&nbsp;cm</td>
                            </tr>
                        </table>
                    </li>
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>体重</th>
                                <td><%#Eval("tijianzhong") %>&nbsp;kg</td>
                            </tr>
                        </table>
                    </li>
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>头部</th>
                                <td><%#Eval("tijiantou") %></td>
                            </tr>
                        </table>
                    </li>
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>胸部</th>
                                <td><%#Eval("tijianxiong") %></td>
                            </tr>
                        </table>
                    </li>
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>腹部</th>
                                <td><%#Eval("tijianfu") %></td>
                            </tr>
                        </table>
                    </li>
                    <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>体检时间</th>
                                <td><%#MyCommFun.Obj2DateTime(Eval("tijiandate")).ToString("yyyy年MM月dd日") %></td>
                            </tr>
                        </table>
                    </li>
                     <li class="nob">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                            <tr>
                                <th>体检信息</th>
                                <td><%#Eval("tijiandetails")  %></td>
                            </tr>
                        </table>
                    </li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "暂无记录" : ""%>
            </FooterTemplate>
        </asp:Repeater>

        <div class="footReturn">
            <div class="clr"></div>
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">操作成功<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/plugback.js" type="text/javascript" type="text/javascript"></script>
    <script type="text/javascript">
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            window.shareData = {
                "imgUrl": "",
                "timeLineLink": "http://www.apiwx.com?ac=onlinebooking&tid=219634",
                "sendFriendLink": "http://www.apiwx.com?ac=onlinebooking&tid=219634",
                "weiboLink": "http://www.apiwx.com?ac=onlinebooking&tid=219634",
                "tTitle": "乐享微信加*盟*报名",
                "tContent": "乐享微信加*盟*报名",
                "fTitle": "乐享微信加*盟*报名",
                "fContent": "乐享微信加*盟*报名",
                "wContent": "乐享微信加*盟*报名"
            };


            // 发送给好友
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                WeixinJSBridge.invoke('sendAppMessage', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.sendFriendLink,
                    "desc": window.shareData.fContent,
                    "title": window.shareData.fTitle
                }, function (res) {
                    _report('send_msg', res.err_msg);
                })
            });

            // 分享到朋友圈
            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.timeLineLink,
                    "desc": window.shareData.tContent,
                    "title": window.shareData.tTitle
                }, function (res) {
                    _report('timeline', res.err_msg);
                });
            });

            // 分享到微博
            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": window.shareData.wContent,
                    "url": window.shareData.weiboLink,
                }, function (res) {
                    _report('weibo', res.err_msg);
                });
            });
        }, false)
    </script>
</body>
</html>
