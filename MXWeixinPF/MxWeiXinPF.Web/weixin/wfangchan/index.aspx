<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title></title>
    <base href="." />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <link rel="stylesheet" href="css/idangerous.swiper.css">
    <link href="css/iscroll.css" rel="stylesheet" type="text/css" />
    <link href="css/cate36_0.css" rel="stylesheet" type="text/css" />
    <script src="js/iscroll.js" type="text/javascript"></script>
    <script type="text/javascript">
        var myScroll;
        function loaded() {
            myScroll = new iScroll('wrapper', {
                snap: true,
                momentum: false,
                hScrollbar: false,
                onScrollEnd: function () {
                    document.querySelector('#indicator > li.active').className = '';
                    document.querySelector('#indicator > li:nth-child(' + (this.currPageX + 1) + ')').className = 'active';
                }
            });
        }
        document.addEventListener('DOMContentLoaded', loaded, false);
    </script>
</head>

<body id="cate17">
    <div id="insert1" style="z-index: 10000; position: fixed; top: 20px;"></div>
    <div class="banner">
        <div id="wrapper">
            <div id="scroller">
                <%--幻灯片区--%>
                <ul id="thelist">
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <li>
                                <img src="<%#Eval("Str") %>">
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div id="nav">
            <div id="prev" onclick="myScroll.scrollToPage('prev', 0,400,2);return false">&larr; prev</div>
            <ul id="indicator">

                <li class="active"></li>
                <%for (int i = 0; i < ls.Count-1; i++){%>
                  
                <li></li>
                <%}%>
            </ul>
            <div id="next" onclick="myScroll.scrollToPage('next', 0,400,2);return false">next &rarr;</div>
        </div>
        <div class="clr"></div>
    </div>
    <div class="device">
        <a class="arrow-left" href="#"></a>
        <a class="arrow-right" href="#"></a>
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <div class="content-slide">
                        <a href="index.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu6.png" />
                            </p>
                            <p class="title">楼盘首页</p>
                        </a>
                        <a href="floorInfo.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu4.png" />
                            </p>
                            <p class="title">楼盘简介</p>
                        </a>
                        <a href="floorAblums.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu7.png" />
                            </p>
                            <p class="title">楼盘相册</p>
                        </a>
                        <a href="floorHtype.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu17.png" />
                            </p>
                            <p class="title">户型全景</p>
                        </a>
                    </div>
                </div>
                <div class="swiper-slide">
                    <div class="content-slide">
                        <a href="floorDping.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu15.png" />
                            </p>
                            <p class="title">印象点评</p>
                        </a>
                        <a href="yySeefloor.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu8.png" />
                            </p>
                            <p class="title">预约看房</p>
                        </a>
                        <a href="aboutWe.aspx?wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>">
                            <p class="ico">
                                <img src="img/plugmenu19.png" />
                            </p>
                            <p class="title">关于我们</p>
                        </a>
                    </div>
                </div>
            </div>
            <div class="pagination"></div>
        </div>
        <script src="js/jquery-1.10.1.min.js" type="text/javascript"></script>
        <script src="js/idangerous.swiper-2.1.min.js" type="text/javascript"></script>
        <script>
            var mySwiper = new Swiper('.swiper-container', {
                pagination: '.pagination',
                loop: true,
                grabCursor: true,
                paginationClickable: true
            })
            $('.arrow-left').on('click', function (e) {
                e.preventDefault()
                mySwiper.swipePrev()
            })
            $('.arrow-right').on('click', function (e) {
                e.preventDefault()
                mySwiper.swipeNext()
            })
        </script>
        <script>
            var count = document.getElementById("thelist").getElementsByTagName("img").length;
            var count2 = document.getElementsByClassName("menuimg").length;
            for (i = 0; i < count; i++) {
                document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + document.body.clientWidth + "px";
            }
            document.getElementById("scroller").style.cssText = " width:" + document.body.clientWidth * count + "px";

            setInterval(function () {
                myScroll.scrollToPage('next', 0, 400, count);
            }, 3500);
            window.onresize = function () {
                for (i = 0; i < count; i++) {
                    document.getElementById("thelist").getElementsByTagName("img").item(i).style.cssText = " width:" + document.body.clientWidth + "px";
                }
                document.getElementById("scroller").style.cssText = " width:" + document.body.clientWidth * count + "px";
            }
        </script>
    </div>
    <div style="display: none"></div>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script>
        function displayit(n) {
            for (i = 0; i < 4; i++) {
                if (i == n) {
                    var id = 'menu_list' + n;
                    if (document.getElementById(id).style.display == 'none') {
                        document.getElementById(id).style.display = '';
                        document.getElementById("plug-wrap").style.display = '';
                    } else {
                        document.getElementById(id).style.display = 'none';
                        document.getElementById("plug-wrap").style.display = 'none';
                    }
                } else {
                    if ($('#menu_list' + i)) {
                        $('#menu_list' + i).css('display', 'none');
                    }
                }
            }
        }
        function closeall() {
            var count = document.getElementById("top_menu").getElementsByTagName("ul").length;
            for (i = 0; i < count; i++) {
                document.getElementById("top_menu").getElementsByTagName("ul").item(i).style.display = 'none';
            }
            document.getElementById("plug-wrap").style.display = 'none';
        }

        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });
    </script>
    <!-- share -->
    <script type="text/javascript">
        window.shareData = {
            "moduleName": "Index",
            "moduleID": "0",
            "imgUrl": "http://42.96.196.48/tpl/static/attachment/focus/default/../wedding/9.jpg",
            "timeLineLink": "http://42.96.196.48/index.php?g=Wap&m=Estate&a=index&token=agpkhy1417835915",
            "sendFriendLink": "http://42.96.196.48/index.php?g=Wap&m=Estate&a=index&token=agpkhy1417835915",
            "weiboLink": "http://42.96.196.48/index.php?g=Wap&m=Estate&a=index&token=agpkhy1417835915",
            "tTitle": "你好，首页",
            "tContent": "你好，首页"
        };
    </script>

    <%--无用js--%>
    <script>
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
                wecha_id: 'okiB6uA0hnixn13MUDRzxQNR9zaY',
                url: window.shareData.sendFriendLink,
                to: to
            };
            $.post('/index.php?g=Wap&m=Share&a=shareData&token=agpkhy1417835915&wecha_id=okiB6uA0hnixn13MUDRzxQNR9zaY', submitData, function (data) { }, 'json')
        }
    </script>
</body>
</html>
