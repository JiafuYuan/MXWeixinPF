<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_order_xianshi.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.hotel.hotel_order_xianshi" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>在线预订成功</title>
<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
<link href="css/hotels.css" rel="stylesheet" type="text/css">
<script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
</head>

<body id="hotelsok" class="mode_webapp">
<div class="qiandaobanner">  <a href="index.php?ac=hotelslist&amp;c=o99epjjmjWhMPNzoQbo9r6DAEYds&amp;tid=1563" > <img  src="http://img.ishangtong.com/images/RTqs2yHIc9.jpg"  /></a> </div>
<div class="cardexplain">


<ul class="round">
<li class="title"><span class="none"><%=createtime %> 订单详情<%=zhuangtai %></span></li>
<li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>联系人</th>
<td class="userinfo"><%=truename %></td>
</tr>
</table>
</li>
<li class="dandanb"><a href="tel:12345678977"><span>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>联系电话</th>
<td class="userinfo"><%=tel %></td>
</tr>
</table></span></a>
</li>
<li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>入住时间</th>
<td class="userinfo"><%=rztime %></td>
</tr>
</table>
</li>
<li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>离店时间</th>
<td class="userinfo"><%=ldtime %></td>
</tr>
</table>
</li>
<li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>房间类型</th>
<td class="userinfo"><%=roomtype %></td>
</tr>
</table>
</li>
<li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>预订数量</th>
<td class="userinfo"><%=num %>间</td>
</tr>
</table>
</li>
<li class="nob">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>原价</th>
<td class="userinfo">￥<%=yuanjia %></td>
</tr>
</table>
</li>
<li class="nob">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>现价</th>
<td class="userinfo price">￥<%=price %></td>
</tr>
</table>
</li>
<li class="nob">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th>为你节省</th>
<td class="userinfo price2" id="price3">￥<%=jiesheng %></td>
</tr>
</table>
</li>
                                                                    

                                             <li class="dandanb">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
<tr>
<th valign="top" class="thtop">备注</th>
<td class="userinfo pm"><%=beizhu %></td>
</tr>
</table>
</li>
</ul>
 <input type="hidden" name="formhash" id="formhash" value="77ee642e" />
<%--<ul class="round">
<li class="title"><span class="none">商家留言</span></li>
<li>
<span class="green none"><p class="time">时间：06月17日 16:43</p></span>
</li>
</ul>--%>
<div class="footReturn">
<a id="showcard"  class="del" >删除此订单</a>
<div class="window" id="windowcenter">
<div id="title" class="wtitle">删除成功<span class="close" id="alertclose"></span></div>
<div class="content">
<div id="txt"></div>
</div>
</div>
</div>
<input type="hidden" runat="server" id="dingdanidnum" value="" />
<script type="text/javascript">
    var oLay = document.getElementById("overlay");
    $(document).ready(function () {


        $("#showcard").click(function () {


            var dingdanidnum = document.getElementById('dingdanidnum').value;

            var submitData = {

                dingdanidnum: dingdanidnum,
                myact: "dingdandelete"
            };
            $.post('hotel_info.ashx', submitData,
             function (data) {
                 if (data.ret == "ok") {
                     alert(data.content);

                     window.location.href = "hotel_order.aspx?openid=<%=openid%>&hotelid=<%=hotelid%>&roomid=<%=roomid%>";

                 } else { alert(data.content); }
             },
                "json");

            oLay.style.display = "block";
        });
    });

    $("#windowclosebutton").click(function () {
        $("#windowcenter").slideUp(500);
        oLay.style.display = "none";

    });
    $("#alertclose").click(function () {
        $("#windowcenter").slideUp(500);
        oLay.style.display = "none";

    });

    function alert(title) {

        $("#windowcenter").slideToggle("slow");
        $("#txt").html(title);
        //$("#windowcenter").hide("slow"); 
        setTimeout('$("#windowcenter").slideUp(500)', 4000);
    }

</script> 
</div>
<script src="index/js/plugback.js" type="text/javascript" type="text/javascript"></script>

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
            <a  href="hotel_detail.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
            <img src="images/xxyX63YryG.png">
            <p>关于</p>
            </a>
        </li>
        <li>
            <a class="active" href="hotel_order.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
            <span class="num" ><%=numdingdan %></span>  <img src="images/s22KaR0Wtc.png">
            <p>订单</p>
            </a>
        </li>
    </ul>
</div>


</body>
</html>
