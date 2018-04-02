<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_Result.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.qiangpiao.order_Result" %>

<% if (ErrLevel < 100)
   {
       Response.Write(ErrorInfo);
   }
   else
   {  %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="description" content="">
    <meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1, user-scalable=no">
    <meta name="viewport" content="initial-scale=1.0,user-scalable=no,maximum-scale=1" media="(device-height: 568px)">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name='apple-touch-fullscreen' content='yes'>
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <meta name="format-detection" content="address=no">
    <link href="css/index.css" rel="stylesheet" />
    <link href="css/mystyle.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
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

        h1 .text-icon {
            font-size: 140%;
            color: #FA7251;
            margin-right: .2rem;
            vertical-align: initial;
        }

        .text-icon {
            font-family: base_icon;
            display: inline-block;
            vertical-align: middle;
            font-style: normal;
        }

        h1 {
            text-align: center;
            margin: .28rem .2rem;
        }
    </style>
</head>

<body id="deal-detail">
    <header class="navbar">
        <div class="nav-wrap-left">
            <a class="react back" href="javascript:history.back()"><i class="text-icon icon-back"></i></a>
        </div>
        <h1 class="nav-header">抢票结果</h1>
    </header>
    <div id="tips"></div>

    <asp:Literal ID="litJoined" runat="server"></asp:Literal>

    <asp:Literal ID="litShow" runat="server"></asp:Literal>

    <asp:Literal ID="litFull" runat="server"></asp:Literal>

    <a href="#" class="btn buy-btn btn-block btn-larger " onclick="nowBuy_Click"
        data-stid="##a" gaevent="imt/deal/buyBtn">查看更多活动</a>
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
</body>
</html>
<%} %>