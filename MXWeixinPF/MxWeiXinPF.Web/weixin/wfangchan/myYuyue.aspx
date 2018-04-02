<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myYuyue.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.myYuyue" %>


<!DOCTYPE html>
<html class=" clickberry-extension clickberry-extension-standalone">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/online_booking.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/pig-ui.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/common.css" media="all">
    <script type="text/javascript" src="js/jQuery.js"></script>
    <title>我的预约</title>
    <style>
        img {
            width: 100%!important;
        }
    </style>
    <meta content="clickberry-extension-here">
</head>
<body onselectstart="return true;" ondragstart="return false;" id="onlinebooking-list">

    <div class="qiandaobanner">
        <a href="javascript:;">
            <img src="<%=photo %>">
        </a>
    </div>
    <a href="javascript:;"></a>
    <div class="cardexplain">
        <a href="javascript:;"></a>
        <ul class="round">
            <asp:Repeater ID="rptDinfo" runat="server" OnItemDataBound="rptDinfo_ItemDataBound">
                <ItemTemplate>
                    <a href="javascript:;">
                        <li class="title">
                            <span><%#Convert.ToDateTime(Eval("yydate")).ToString("yyyy-MM-dd") %>订单详情 <em class="no"><%#Eval("orderStatus").ToString()=="待回复"?"等待客服回电":Eval("orderStatus") %></em></span>
                        </li>
                    </a>
                    <li><a href="javascript:;"></a>
                        <div class="text">
                            <a href="javascript:;">
                                <p>联系人：<%#Eval("name") %></p>
                                <p>联系电话：<%#Eval("telephone") %></p>
                                <p>选择看房户型 ：<%#Eval("hxName") %></p>
                                <p>预约时间 ：<%#Eval("yydatepart") %></p>
                                <p>更新或提交时间：<%#Convert.ToDateTime(Eval("createdate")).ToString("yyyy年MM月dd日") %></p>
                            </a>
                            <div class="footReturn">
                                <a href="javascript:;"></a>
                                <asp:Literal ID="ltrShow" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <!--页码-->
    </div>
    <div mark="stat_code" style="width: 0px; height: 0px; display: none;"></div>
</body>
</html>
