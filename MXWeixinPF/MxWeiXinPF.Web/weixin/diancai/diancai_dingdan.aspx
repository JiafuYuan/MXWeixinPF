<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="diancai_dingdan.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.diancai.diancai_dingdan" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title><%=hotelName %></title>
    <link href="css/diancai.css" rel="stylesheet" type="text/css">
    <style>
</style>
</head>
<body class="mode_webapp">
    <div class="menu_header">
        <div class="menu_topbar">
            <strong class="head-title"></strong>
            <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
            <a class="head_btn_right" href="caidan_shangjia.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                <span><i class="menu_header_home"></i></span><b></b>
            </a>
        </div>
    </div>

    <div class="cardexplain" id="contact_info" runat="server">

        <ul class="round">
            <li class="title"><span class="none smallspan">订单详情</span></li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">

                <%=Dingdanlist %>
            </table>

        </ul>

        <ul class="round">
            <li class="title"><span class="none smallspan">订单信息</span></li>

            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <%=dingdanren %>
            </table>

        </ul>
        <div class="twobtn">
           
            <a class="del 3" id="showcard" runat="server">删除</a>
            <a id="showcard2" class="submit" href="javascript:history.go(-1);" style="display: none;" runat="server">返回</a>
        </div>


        <div class="clr"></div>
    </div>



    <div class="footermenu">
        <ul>
            <li>
                <a href="caidan_guanyu.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/xxyX63YryG.png">
                    <p>关于</p>
                </a>
            </li>
            <li>
                <a href="index.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/Lngjm86JQq.png">
                    <p><%=rename %></p>
                </a>
            </li>
            <li>
                <a href="diancai_shoppingCart.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                    <span class="num" id="cartN2">0</span>
                    <img src="images/2yFKO6TwKI.png">
                    <p>购物车</p>
                </a>
            </li>
            <li>
                <a class="active" href="diancai_oder.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/s22KaR0Wtc.png">
                    <p>订单</p>
                </a>
            </li>
            <li>
                <a href="diancai_geren.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
                    <img src="images/J0uZbXQWvJ.png">
                    <p>我的</p>
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
