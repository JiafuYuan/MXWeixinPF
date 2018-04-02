<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhaoshang_xiangq.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.diancai.zhaoshang_xiangq" %>



<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
<meta name="apple-mobile-web-app-capable" content="yes">
<meta name="apple-mobile-web-app-status-bar-style" content="black">
<meta name="format-detection" content="telephone=no">
<title>订餐系统</title>
<link href="css/diancai.css" rel="stylesheet" type="text/css">
</head>
<body class="mode_webapp">

<div class="menu_header"> 
     <div class="menu_topbar">
      <strong class="head-title">招商详情</strong>
      <span class="head_btn_left"><a href="javascript:history.go(-1);"><span>返回</span></a><b></b></span>
      <a class="head_btn_right" href="caidan_shangjia.aspx?shopid=<%=shopid %>&openid=<%=openid %>">
      <span><i class="menu_header_home"></i></span><b></b>
      </a>
     </div>
</div>

<div class="cardexplain">

<div class="detailcontent"><h2>招商说明</h2>
    <div class="content">
<%=zhaoshang %>
   </div>
    </div>
    
        <ul class="round">
       	<li class="tel"><a href="tel:<%=tel %>"><span><%=tel %> 招商热线</span></a></li>
</ul>

</div>
 

<script type="text/javascript">
    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
    });
</script>
</body>
</html>

