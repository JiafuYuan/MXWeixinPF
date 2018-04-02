<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_detail.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.hotel.hotel_detail" %>


<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>ddd</title>
<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
<link href="css/hotels.css" rel="stylesheet" type="text/css">
 
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

<body id="hotelsdetail" class="mode_webapp" >
<div class="banner">
<div id="wrapper">
<div id="scroller">
<ul id="thelist">               
<%=tupian %>
</ul>
</div>
</div>
<div id="nav">
<div id="prev" onClick="myScroll.scrollToPage('prev', 0,400,3);return false">&larr; prev</div>
<ul id="indicator">          
<%=tabid %>
</ul>
<div id="next" onClick="myScroll.scrollToPage('next', 0);return false">next &rarr;</div>
</div>
<div class="clr"></div>
</div>

<script>


    var count = document.getElementById("thelist").getElementsByTagName("img").length;


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
<div class="cardexplain">


<ul class="round">
<li class="addr"><a href="http://api.map.baidu.com/marker?location=<%=xplace %>,<%=yplace %>&amp;title=<%=address %>&amp;content=<%=address %>&amp;output=html"><span><%=address %></span></a></li>
<li class="tel"><a href="tel:<%=tel %>"><span><%=tel %> 电话预订</span></a></li>
</ul>        
        <div class="detailcontent"><h2>详情介绍</h2>
        <div class="content">
            <span style="color:#444444;font-family:'Microsoft YaHei', Helvitica, Verdana, Arial, san-serif;font-size:14px;font-weight:bold;line-height:21px;background-color:#FCFCFC;"><%=jieshao %></span></div>
    </div>
</div>
<script src="js/plugback.js" type="text/javascript" ></script>

<div class="footermenu">
    <ul>
    <li>
            <a href="javascript:history.go(-1);">
            <img src="images/9uKCykhUSh.png">
            <p>返回</p>
            </a>
        </li>
    <li>
            <a href="index.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
            <img src="images/3YQLfzfunJ.png">
            <p>首页</p>
            </a>
        </li>
        <li>
            <a class="active" href="hotel_detail.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
            <img src="images/xxyX63YryG.png">
            <p>关于</p>
            </a>
        </li>
        <li>
            <a href="hotel_order.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
            <span class="num" ><%=numdingdan %></span>  <img src="images/s22KaR0Wtc.png">
            <p>订单</p>
            </a>
        </li>
    </ul>
</div>
<script type="text/javascript">
    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });
</script>

</body>
</html>
