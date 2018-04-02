<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prImgView.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.prImgView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>宝贝推荐</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta charset="utf-8">
    <link href="css/news.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/plugmenu.css">
</head>

<body id="listhome1">
    <div class="Listpage">
        <div id="todayList">
            <ul class="todayList">
                <asp:Repeater ID="rptView" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="prImg.aspx?id=<%#Eval("id") %>&fid=<%=fid %>&wid=<%=wid %>&openid=<%=openid %>">
                                <div class="img">
                                    <img src="<%#Eval("pri_front") %>">
                                </div>
                                <h2><%#Eval("jdname") %></h2>
                                <p class="onlyheight"><%#Eval("remark") %></p>
                                <div class="commentNum"></div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <script type="text/javascript">
        window.shareData = {
            "moduleName": "Panorama",
            "moduleID": "0",
            "imgUrl": "",
            "sendFriendLink": "http://42.96.196.48/index.php?g=Wap&m=Panorama&a=index&token=agpkhy1417835915",
            "tTitle": "全景",
            "tContent": ""
        };
    </script>
    <script type="text/javascript">
        window.shareData.sendFriendLink = window.shareData.sendFriendLink.replace('http://42.96.196.48', 'http://42.96.196.48');
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                shareHandle('friend');
                WeixinJSBridge.invoke('sendAppMessage', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.sendFriendLink,
                    "desc": window.shareData.tContent,
                    "title": window.shareData.tTitle
                }, function (res) {
                    _report('send_msg', res.err_msg);
                })
            });

            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                shareHandle('frineds');
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.sendFriendLink,
                    "desc": window.shareData.tContent,
                    "title": window.shareData.tTitle
                }, function (res) {
                    _report('timeline', res.err_msg);
                });
            });

            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                shareHandle('weibo');
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": window.shareData.tContent,
                    "url": window.shareData.sendFriendLink,
                }, function (res) {
                    _report('weibo', res.err_msg);
                });
            });
        }, false)

        function shareHandle(to) {
            var submitData = {
                module: window.shareData.moduleName,
                moduleid: window.shareData.moduleID,
                token: 'agpkhy1417835915',
                wecha_id: '',
                url: window.shareData.sendFriendLink,
                to: to
            };
            $.post('/index.php?g=Wap&m=Share&a=shareData&token=agpkhy1417835915', submitData, function (data) { }, 'json')
        }
    </script>
</body>
</html>
