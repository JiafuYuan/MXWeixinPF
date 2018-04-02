<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tp_result.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.vote.tp_result" %>

<!DOCTYPE html> 
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>投票结果</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/vote(for_vt).css" rel="stylesheet" type="text/css">  
</head>

<body id="vote-text"> 
    <div class="vote">
        <form id="Form1" class="form" target="_top" runat="server" enctype="multipart/form-data">
            <div class="votecontent" style="height:400px; text-align:center;">
                <h2>恭喜你投票成功！！</h2> 
            </div>
        </form>
        <div class="copyright" style="text-align: center; color: #fff;">© 2001-2014 <a href="http://www.wxapi.cn/" style="color: #cccccc">乐享微信版权所有</a></div>
    </div> 
</body>
</html> 