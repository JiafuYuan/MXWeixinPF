<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.qiangpiao.order" %>

<% if (ErrLevel < 100)
   {
       Response.Write(ErrorInfo);
   }
   else if (ErrLevel == 101)
   {  //活动已结束，跳转到结束页面
%>
<script type="text/javascript">
    window.location.href = "end.aspx?wid=" +<%=wid%> +"&aid=" +<%=aid%> +"&openid=" +<%=openid%> +";";
</script>
<%
   }
   else
   {  %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>【上海豪鑫国际旅行社团购】</title>
    <meta name="description" content="">
    <meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1, user-scalable=no">
    <meta name="viewport" content="initial-scale=1.0,user-scalable=no,maximum-scale=1" media="(device-height: 568px)">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name='apple-touch-fullscreen' content='yes'>
    <meta name="format-detection" content="telephone=no">
    <meta name="format-detection" content="address=no">
    <meta charset="utf-8">
    <link href="css/index.css" rel="stylesheet" />
    <link href="css/mystyle.css" rel="stylesheet" />
    <link href="css/dialog.css" rel="stylesheet" />
    <link href="/templatesstore/css/cate4_2.css" rel="stylesheet" type="text/css" />
    <link href="/templatesstore/css/iscroll.css" rel="stylesheet" type="text/css" />
    <script src="/templatesstore/js/iscroll.js" type="text/javascript"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/main.js"></script>
    <script src="js/dialog_min.js"></script>
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
    <style>
        .album {
            height: 3.9rem;
            position: relative;
            overflow: hidden;
        }

            .album img {
                width: 100%;
                min-height: 100%;
                -webkit-transform: translateY(-50%);
                -ms-transform: translateY(-50%);
                top: 50%;
                position: relative;
            }

            .album .desc {
                position: absolute;
                bottom: 0;
                width: 100%;
                color: white;
                text-align: center;
                height: .56rem;
                line-height: .56rem;
                font-size: .24rem;
                background: rgba(0, 0, 0, .5);
            }

        ul.ul {
            list-style-type: initial;
            padding-left: .4rem;
        }

            ul.ul li {
                font-size: .3rem;
                margin: .1rem 0;
                line-height: 1.5;
            }

        /*///*/
        #deal-detail .buy-price {
            color: #999;
            position: relative;
        }

        .buy-price .price {
            vertical-align: text-top;
        }

        .buy-price strong {
            font-size: .66rem;
        }

        .buy-price space {
            width: .16rem;
        }

        .list .buy-price .buy-btn {
            position: absolute;
            margin: 0;
            right: .2rem;
            top: .21rem;
            width: 2.6rem;
            margin-top: 0;
        }

        .buy-desc h1 {
            font-size: .36rem;
            margin: 0;
            margin-bottom: .22rem;
            color: #000;
        }

        .buy-desc p {
            margin: 0;
            color: #666;
        }

        /*agreement*/
        .agreement li {
            display: inline-block;
            width: 50%;
            margin-bottom: .22rem;
            box-sizing: border-box;
            color: #666;
        }

            .agreement li:nth-child(2n) {
                padding-left: .14rem;
            }

            .agreement li:nth-child(1n) {
                padding-right: .14rem;
            }

        .agreement ul.agree li {
            height: .32rem;
            line-height: .32rem;
        }

            .agreement ul.agree li.active {
                color: #6bbd00;
            }

        .agreement ul.btn-line li {
            vertical-align: middle;
            margin-top: .06rem;
            margin-bottom: 0;
        }

        .agreement .text-icon {
            margin-right: .14rem;
            vertical-align: top;
            height: 100%;
        }

        .agreement .agree .text-icon {
            font-size: .4rem;
            margin-right: .2rem;
        }

        /* 通用星星样式 */
        .stars {
            font-style: normal;
            font-size: .36rem;
            line-height: .36rem;
        }

        .buy-comment {
            float: right;
        }

        .voice-info {
            font-size: .3rem;
            color: #eb8706;
        }

        #deal-details .detail-title {
            background-color: #F8F9FA;
            padding: .2rem;
            font-size: .3rem;
            color: #000;
            border-bottom: 1px solid #ccc;
        }

            #deal-details .detail-title p {
                text-align: center;
            }

        #deal-details .detail-group {
            font-size: .3rem;
            display: -webkit-box;
            display: -ms-flexbox;
        }

        .detail-group .left {
            -webkit-box-flex: 1;
            -ms-flex: 1;
            display: block;
            padding: .28rem 0;
            padding-right: .2rem;
        }

        .detail-group .right {
            display: -webkit-box;
            display: -ms-flexbox;
            -webkit-box-align: center;
            -ms-box-align: center;
            width: 1.3rem;
            padding: .28rem .2rem;
            border-left: 1px solid #ccc;
        }

        .detail-group .middle {
            display: -webkit-box;
            display: -ms-flexbox;
            -webkit-box-align: center;
            -ms-box-align: center;
            width: 1.9rem;
            padding: .28rem .2rem;
            border-left: 1px solid #ccc;
        }

        #deal-terms {
            font-size: .3rem;
        }

        .js-fav-btn .fav-text {
            vertical-align: top;
        }

            .js-fav-btn .fav-text:after {
                content: "收藏";
            }

        .js-fav-btn .icon-star {
            display: none;
        }

        .js-fav-btn .icon-star-empty {
            display: inline-block;
        }

        .js-fav-btn.faved .fav-text:after {
            content: "取消收藏";
        }

        .js-fav-btn.faved .icon-star {
            display: inline-block;
        }

        .js-fav-btn.faved .icon-star-empty {
            display: none;
        }

        .comment-headline {
            color: #999;
            line-height: .35rem;
        }

        /* 酒店和促銷工具 */
        .hotel-desc-current {
            color: #999;
            margin-left: .08rem;
        }

        dl.list .hotel-price-panel {
            background: #f0efed;
            border-left: none;
            border-right: none;
        }

        .hotel-prices {
            padding: 5px 0;
        }

            .hotel-prices > li {
                display: inline-block;
                width: 94px !important;
                padding: 3px 5px 3px 10px;
                text-align: left;
                font-size: 12px;
                color: #666;
            }

                .hotel-prices > li:after {
                    content: ' ';
                    display: table;
                    margin-top: -30%;
                    border-left: 1px solid #ccc;
                    padding-top: 25%;
                    float: right;
                    clear: both;
                }

                .hotel-prices > li.active {
                    color: #2dbeae;
                }

        .campaign .tag,
        .campaign-item .tag {
            position: static;
            margin-left: .04rem;
            background: #ff8c00;
            color: #fff;
            line-height: 1.5;
            display: inline-block;
            padding: 0 .06rem;
            text-align: center;
            font-size: .24rem;
            border-radius: .06rem;
        }

        .hotel-price {
            color: #ff8c00;
            font-size: .24rem;
            display: block;
        }

        .campaign {
            height: .48rem;
        }

            .campaign .tag {
                font-size: .28rem;
            }

        .campaign-tip {
            padding-top: .24rem;
            padding-bottom: .24rem;
            background-color: #fff;
            border-bottom: 1px solid #ddd8ce;
            color: #555;
        }

        .btn-kefu {
            position: absolute;
            right: .016rem;
            top: .1rem;
            color: #ff8c00;
            border-color: #ff8c00;
        }
    </style>
</head>
<body id="deal-detail" onselectstart="return true;" ondragstart="return false;">
    <form id="form1">
        <header class="navbar">
            <div class="nav-wrap-left">
                <a class="react back" href="javascript:history.back()"><i class="text-icon icon-back"></i></a>
            </div>
            <h1 class="nav-header">确认订单</h1>
            <div class="nav-wrap-right">
                <a class="react nav-dropdown-btn" data-com="dropdown" data-target="nav-dropdown">
                    <span class="nav-btn">
                        <i class="text-icon"></i>
                    </span>
                </a>
            </div>

        </header>
        <dl id="deal-terms" class="list">
            <dd>
                <dl>
                    <dt gaevent="imt/deal/terms">抢票须知</dt>
                    <dd class="dd-padding">
                        <ul class="ul">
                            <asp:Literal ID="ltrUserxz" runat="server"></asp:Literal>
                        </ul>
                    </dd>
                </dl>
            </dd>
        </dl>
        <div id="deal" class="list">

            <div>
                <h4 class="quick-buy-title"></h4>
                <dl class="list">
                    <dd>
                        <dl>
                            <dd class="kv-line-r dd-padding" data-com="smsBtn" data-requrl="/account/mobilelogincode">
                                <input type="tel" name="txttelephone" class="input-weak kv-k"
                                    placeholder="请输入手机号" id="txttelephone" />
                                <input type="button" id="btnFSYZM" onclick="getReceiveMemberCardVCode(this, event, 'form1', 'txttelephone');" class="btn btn-weak kv-v" value="发送验证码">
                            </dd>
                            <dd class="dd-padding">
                                <input type="tel" id="txtsms_captcha" class="input-weak" name="quickBuyCode" nosave="true" pattern="[0-9]+" placeholder="请输入手机短信中的验证码" />
                            </dd>
                        </dl>
                    </dd>
                </dl>
            </div>
            <div class="clearboth"></div>
        </div>
        <div class="btn-wrapper">
            <button id="btnSubmit" type="button" gaevent="imt/buy/quickBuy/submit"
                class="btn btn-block btn-strong btn-larger  mj-submit">
                提交订单</button>
        </div>

                    <div class="banner" <%=mark=="no"?"style=\"display:none\"":"" %>>
                <div id="wrapper">
                    <div id="scroller">
                        <ul id="thelist">
                            <asp:Repeater ID="rptImglist" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <p><%#Eval("iName") %></p>
                                        <img src="<%#Eval("imgPic") %>"></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%#rptImglist.Items.Count == 0 ? "" : ""%>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div id="nav">
                    <div id="prev" onclick="myScroll.scrollToPage('prev', 0,400,10);return false">&larr; prev</div>
                    <ul id="indicator">
                        <asp:Repeater ID="rptNum" runat="server">
                            <ItemTemplate>
                                <li class="<%#Container.ItemIndex==0?"active":"" %>"><%#Container.ItemIndex+1 %></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%#rptNum.Items.Count == 0 ? "" : ""%>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                    <div id="next" onclick="myScroll.scrollToPage('next', 0);return false">next &rarr;</div>
                </div>
                <div class="clr"></div>
            </div>
            <script>
                var count = document.getElementById("thelist").getElementsByTagName("img").length;

                var count2 = document.getElementsByClassName("menuimg").length;
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
            <div class="clearboth"></div>

        <footer>
            <div class="footer-copyright">
                <div class="hr"></div>
                <span class="footer-copyright-text">©2014 连云港今日文化传媒</span>
            </div>
        </footer>
        <div class="top-btn" data-com="gotop"><a class="react"><i class="text-icon">⇧</i></a></div>
        <div id="meituan_check">
            <br>
            <br>
            <br>
        </div>

        <script type="text/javascript">

            var intervalId, buttonObj;
            //发送下一条短信需要间隔的秒数
            var seconds = 60;
            function getReceiveMemberCardVCode(clickObj, evt, formId, teleName) {
                var pid = 1071;
                var form = document.getElementById(formId);
                var req = {
                    telephone: $.trim(form[teleName].value),
                    pid: pid,
                }

                if (!req.telephone) {
                    alert("请输入手机号", 1000); return;
                }


                clickObj.setAttribute("disabled", "disabled");
                $.ajax({
                    url: "uProcess.ashx?mycat=sendCardCheckCode&wid=<%=wid%>&aid=<%=aid%>&openid=<%=openid%>&telephone=" + form[teleName].value,
                    type: "post",
                    data: req,
                    dataType: "JSON",
                    success: function (res) {
                        if (0 == res.errno) {
                            clickObj.value = '验证码发送成功';
                            buttonObj = clickObj;
                            intervalId = setInterval("ticker()", 1000);
                        } else {
                            alert(res.content, 1500);
                            $("#btnFSYZM").removeAttr("disabled");
                            return false;
                        }
                    }
                });
            }

            function ticker() {
                seconds--;
                if (seconds > 55) {
                    //提示消息显示5秒钟
                } else if (seconds > 0) {
                    buttonObj.value = seconds + "秒后可重新获取";
                } else {
                    clearInterval(intervalId);
                    buttonObj.removeAttribute("disabled");
                    buttonObj.value = "获取验证码";
                    seconds = 60;
                    buttonObj = null;
                }
            }

            $(function () {
                //判断验证码是否相符,如相符跳转页面
                $("#btnSubmit").click(function () {
                    var tele=$("#txttelephone").val();
                    var ident=$("#txtsms_captcha").val();
                    if (tele=='') {
                        alert("请输入手机号", 1000); return;
                    }
                    if (tele=='') {
                        ident("请输入验证码", 1000); return;
                    }

                    var submitData = {
                        aid: <%=aid%>,
                        wid: <%=wid%>,
                        openid:'<%=openid%>',
                        telephone:tele,
                        identCode:ident,
                    };
                    $.post("uProcess.ashx?mycat=qp_ckOrder",submitData,function(data){
                        if(data.errno == 0){
                            window.location.href=data.content;
                        }else{
                            alert(data.content,1000)
                        }
                    });

                });
            })
        </script>
        <asp:Literal ID="litJavaScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
<%} %>
