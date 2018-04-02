<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_order_onlin.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.hotel.hotel_order_onlin" %>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>在线预订</title>
<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
<link href="css/hotels.css" rel="stylesheet" type="text/css">
<script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>
</head>

<body id="hotelsmore" >
<div class="qiandaobanner"> <img src="images/RTqs2yHIc9.jpg" > </div>
<div class="cardexplain">

<!--连锁店-->
<ul class="round">
<%=infostring %>
</ul>
</div>
<script>
    function dourl(url) {
        location.href = url;
    }
</script>


</body>
</html>