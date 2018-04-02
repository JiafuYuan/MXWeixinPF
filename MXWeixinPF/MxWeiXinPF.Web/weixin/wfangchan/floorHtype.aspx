<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="floorHtype.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.floorHtype" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/style.css" media="all">
    <link href="css/cate36_0.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jQuery.js"></script>
    <script type="text/javascript" src="js/house.js"></script>
    <title>楼盘户型 房产11133333</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta content="no-cache" http-equiv="pragma">
    <meta content="0" http-equiv="expires">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
</head>

<body onselectstart="return true;" ondragstart="return false;">
    <div class="wrapper" id="container">
        <!-- start -->
        <div class="act_top" id="actTop">
            <div class="act_top_show">
                <img src="<%=fModel.htheadImg %>" id="bannerPic">
            </div>
        </div>
        <div id="roomDetails">
            <div class="box box_up box_up3" id="box0">
                <h3><%=fModel.newsTitle %></h3>
                <div class="box_type" style="height: auto;">
                    <asp:Repeater ID="rptHt" runat="server">
                        <ItemTemplate>
                            <ul class="house_type">
                                <li id="boxLi<%#Container.ItemIndex+1 %>" class="current">
                                    <a href="javascript:void(0);" onclick="List.toggleList(<%#Container.ItemIndex+1 %>,0);">
                                        <strong><%#Eval("Name") %></strong>
                                        <span><%#Eval("fName") %></span>
                                        <em><%#Eval("houseType") %>  <%#Eval("storey") %>层</em>
                                    </a>
                                    <div class="house_photo house_arrow" style="display: -webkit-box;">
                                        <a href="htImg.aspx?id=<%#Eval("id") %>&wid=<%=wid %>&fid=<%=fid %>" class="ico_type">户型图</a>
                                        <a href="prImg.aspx?pid=<%#Eval("id") %>&wid=<%=wid %>&fid=<%=fid %>&openid=<%=openid %>" class="ico_360">全景图</a>
                                    </div>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="padding: 5px 10px; margin: 0 auto; border-top: 1px solid #e2e1e0;"><%=jlNum %> 条记录          </div>
                </div>
            </div>
        </div>
        <p>&nbsp;</p>
        <!-- end -->
    </div>

    <div class="pop_tips" id="popTips" style="display: none;">
        <div class="oval"></div>
        <div class="pop_show">
            <h4 id="tipsTitle">温馨提示</h4>
            <div class="pop_info" id="tipsMsg">
                <p></p>
            </div>
            <div class="pop_btns">
                <a href="javascript:void(0);" id="tipsOK">确定</a>
                <a href="javascript:void(0);" style="display: none;" id="tipsCancel">取消</a>
            </div>
        </div>
    </div>

    <p>
        <br />
        <br />
        <br />
        <br />
    </p>
    <script type="text/javascript">
        window.shareData = {
            "moduleName": "Estate",
            "moduleID": "0",
            "imgUrl": "",
            "sendFriendLink": "http://42.96.196.48/index.php?g=Wap&m=Estate&a=index&token=agpkhy1417835915",
            "tTitle": "房产11133333",
            "tContent": " 换句话"
        };
    </script>
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
    <link rel="stylesheet" href="css/idangerous.swiper.css">
    <link href="css/cate36_0.css" rel="stylesheet" type="text/css" />
    <div class="device">
        <a class="arrow-left" href="#"></a>
        <a class="arrow-right" href="#"></a>

        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <div class="content-slide">
                        <a href="index.aspx?wid=<%=wid %>&fid=<%=fid %>">
                            <p class="ico">
                                <img src="img/plugmenu6.png" />
                            </p>
                            <p class="title">楼盘首页</p>
                        </a>
                        <a href="floorInfo.aspx?wid=<%=wid %>&fid=<%=fid %>">
                            <p class="ico">
                                <img src="img/plugmenu4.png" />
                            </p>
                            <p class="title">楼盘简介</p>
                        </a>
                        <a href="floorAblums.aspx?wid=<%=wid %>&fid=<%=fid %>">
                            <p class="ico">
                                <img src="img/plugmenu7.png" />
                            </p>
                            <p class="title">楼盘相册</p>
                        </a>
                        <a href="floorHtype.aspx?wid=<%=wid %>&fid=<%=fid %>">
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
                        <a href="aboutWe.aspx?wid=<%=wid %>&fid=<%=fid %>">
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
    </div>
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
</body>
</html>
