<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="floorDping.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.floorDping" %>

<!DOCTYPE html>
<html>
<head>
    <title>专家点评•房友印象</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/back.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/review.css" media="all">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/common.js"></script>
    <script type="text/javascript" src="js/review.js"></script>
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
<body onselectstart="return true;" ondragstart="return false;" style="background: #363634;">
    <div class="wrapper">
        <!-- start -->
        <ul class="nav_top" id="navTop" style="display: -webkit-box;">
            <li><a href="javascript:void(0);" onclick="REVIEW.switchPanel(0);return false;" class="current">房友印象</a></li>
            <li><a href="javascript:void(0);" onclick="REVIEW.switchPanel(1);return false;">专家点评</a></li>
        </ul>
        <!-- end -->
        <!--房友印象区-->
        <div id="impress" class="impress">
            <h3>选择或添加您的楼盘印象</h3>
            <div class="box1">
                <ul>
                    <li class="my_in">
                        <a href="javascript:void(0);" id="userReview" onclick="REVIEW.addReview(0,&#39;&#39;,&#39;my_in&#39;);" class="00" style="-webkit-box-flex: 4;">
                            <em>添加<br>
                                我的印象</em>
                        </a>
                    </li>
                    <asp:Repeater ID="rptYin" runat="server">
                        <ItemTemplate>
                            <li class="piece<%#Container.ItemIndex + 1 > 7 ? 7 : Container.ItemIndex + 1%>" id="id_3" style="background-color: #fb641c;">
                                <a href="javascript:void(0);" onclick="REVIEW.addReview(3,&#39;wwww&#39;,&#39;id_3&#39;);">
                                    <span><%#Eval("content") %></span>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <!--专家点评区-->
        <div id="professional" style="display: none;">
            <asp:Repeater ID="rptReview" runat="server">
                <ItemTemplate>
                    <div class="review_box">
                        <div class="review_man">
                            <img src="<%#Eval("zjPhoto") %>" width="70" height="70" style="width: 70px!important; height: 70px!important;" alt="">
                            <h3><%#Eval("zjname") %><em><br>
                                <%#Eval("zjPosition") %></em></h3>
                            <p><%#Eval("zjJieshao") %></p>
                        </div>
                        <div class="review_word">
                            <h2><%#Eval("title") %></h2>
                            <p><%#Eval("dpContent") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--显示我的印象-->
        <div class="pop_tips" id="popTips" style="display: none; top: 30%;">
            <div class="pop_show">
                <h4>我的楼盘印象是</h4>
                <div class="pop_info">
                    <input type="hidden" id="fid" value="<%=fid %>">
                    <input type="hidden" id="wid" value="<%=wid %>">
                    <input type="hidden" id="openid" value="<%=openid %>">
                    <input type="hidden" id="reviewId" value="0">
                    <input id="inputImpress" maxlength="4" type="text" class="input_impress" placeholder="输入四个字的楼盘印象">
                </div>
                <div class="pop_btns">
                    <a href="javascript:void(0);" onclick="REVIEW.closePop();">取消</a>
                    <a href="javascript:void(0);" onclick="REVIEW.sendReview();" class="out">确定</a>
                </div>
            </div>
        </div>
       <!--新输入-->
        <div class="pop_tips" id="noticeDiv" style="display: none; top: 30%;">
            <div class="oval"></div>
            <div class="pop_show">
                <h4 id="tipsTitle">温馨提示</h4>
                <div class="pop_info" id="tipsMsg">
                    <p>请输入四个字的中文描述</p>
                </div>
                <div class="pop_btns">
                    <a href="javascript:;" id="noticeBtn">确定</a>
                </div>
            </div>
        </div>

        <div id="popFail" style="display: none;" jqmoldstyle="block">
            <div class="bk"></div>
            <div class="cont">
            </div>
        </div>
        <div class="pop_mask" id="popMask" style="display: none;"></div>
        <script>
            var PID = 4;
            var TOKEN = "agpkhy1417835915";
            var WECHA_ID = 'okiB6uA0hnixn13MUDRzxQNR9zaY';
        </script>
        <a href="javascript:history.go(-1);" class="back360" style="">&nbsp;</a>
        <div mark="stat_code" style="width: 0px; height: 0px; display: none;">
        </div>
</body>
</html>
