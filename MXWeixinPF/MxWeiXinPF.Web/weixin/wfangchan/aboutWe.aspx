<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutWe.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.aboutWe" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/style.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/peak-3.css" media="all" />
    <link rel="stylesheet" type="text/css" href="css/back.css">
    <script type="text/javascript" src="js/jQuery.js"></script>
    <title>关于我们</title>
    <link rel="stylesheet" type="text/css" href="css/waphome.css" media="all">
    <script type="text/javascript" src="js/swipe.js"></script>
    <script type="text/javascript" src="js/zepto.js"></script>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <meta name="Keywords" content="" />
    <meta name="Description" content="" />
    <!-- Mobile Devices Support @begin -->
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta content="no-cache" http-equiv="pragma">
    <meta content="0" http-equiv="expires">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <!-- apple devices fullscreen -->
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <!-- Mobile Devices Support @end -->
</head>
<body onselectstart="return true;" ondragstart="return false;">
    <div class="body" style="padding-bottom: 60px;">
        <div class="top_bar footer_bar">
        </div>
        <section class="news_article">
            <header>
                <h3 style="font-size: 14px;"><%=aw.name %></h3>
                <p>
                    <img src="<%=aw.logoAddress %>" alt="" style="width: 100%!important;">
                </p>
            </header>
            <article>
                <p>
                    <a style="text" href="gywmMap.aspx?gid=<%=aw.Id %>">
                        <span color="#2c2c2c">地址：<%=aw.address %> </span>
                        <img src="http://api.map.baidu.com/staticimage?width=600&height=235&center=&markers=|<%=aw.latY %>,<%=aw.lngX%>,&zoom=10&markerStyles=s,A,0xff0000" height="235" style="max-height: 250px; max-width: 390px;" />
                    </a>
                    <p>
                        <strong>
                            <span style="color: #009900; font-size: 16px;">免费热线：<a href="tel:"><%=aw.telephone %></a></span>
                        </strong>
                        <br />
                        公司简介：<br />
                        <p style="width: 100%!important;">
                            <%=aw.newsDetail %>
                        </p>
                    </p>
            </article>
        </section>
        <a href="javascript:history.go(-1);" class="back360" style="">&nbsp;</a>
    </div>
</body>
</html>
