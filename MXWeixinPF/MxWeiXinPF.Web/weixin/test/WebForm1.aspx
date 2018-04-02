<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.test.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
    <script src="js/jquery.transit.min.js"></script>
    <script src="js/idangerous.swiper-2.6.1.min.js"></script>
    <link href="css/common6.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            changpian();
            gameStart();
            alert(parseInt(Math.random() * 7));
        });

        //图标飞出
        function changpian() {
            var index = 0;
            changpianAuto = setInterval(function () {
                var li = $("#page-8 ul li").eq(index);
                var x, y;
                switch (li.index()) {
                    case 0:
                        x = -117;
                        y = -55;
                        break;
                    case 1:
                        x = -125;
                        y = 18;
                        break;
                    case 2:
                        x = -113;
                        y = 114;
                        break;
                    case 3:
                        x = 18;
                        y = -125;
                        break;
                    case 4:
                        x = 85;
                        y = -95;
                        break;
                    case 5:
                        x = 117;
                        y = -35;
                        break;
                    case 6:
                        x = 132;
                        y = 26;
                        break;
                    case 7:
                        x = 86;
                        y = 108;
                        break;
                }
                li.css({ x: 0, y: 0, rotate: 0, opacity: 0 }).transition({ x: x, y: y, opacity: 1 }, 1600)
                index++;
                if (index == 8) {
                    clearInterval(changpianAuto);
                }
            }, 800)
        }

        //游戏
        function gameStart() {
            $("#page-6 .eat-author").transition({
                x: 162, complete: function () {
                    $(this).next().find("li:eq(1)").transition({ width: 17 }, 200, "linear");
                    $(this).css({ rotate: 90 }).transition({
                        y: 18, complete: function () {
                            $(this).next().find("li:eq(1)").transition({ width: 179 }, 1600, "linear");
                            $(this).css({ rotate: 180 }).transition({
                                x: 0, complete: function () {
                                    $(this).next().find("li:eq(2)").transition({ width: 17 }, 200, "linear");
                                    $(this).css({ rotate: 90 }).transition({
                                        y: 36, complete: function () {
                                            $(this).next().find("li:eq(2)").transition({ width: 179 }, 1600, "linear");
                                            $(this).css({ rotate: 0 }).transition({
                                                x: 162, complete: function () {
                                                    $(this).next().find("li:eq(3)").transition({ width: 17 }, 200, "linear");
                                                    $(this).css({ rotate: 90 }).transition({
                                                        y: 54, complete: function () {
                                                            $(this).next().find("li:eq(3)").transition({ width: 179 }, 1600, "linear");
                                                            $(this).css({ rotate: 180 }).transition({
                                                                x: 0, complete: function () {
                                                                    $(this).next().find("li:eq(4)").transition({ width: 17 }, 200, "linear");
                                                                    $(this).css({ rotate: 90 }).transition({
                                                                        y: 72, complete: function () {
                                                                            $(this).next().find("li:eq(4)").transition({ width: 110 }, 1000, "linear");
                                                                            $(this).css({ rotate: 0 }).transition({
                                                                                x: 100, complete: function () {
                                                                                    $(this).hide().next().next().css("visibility", "visible");
                                                                                    var over = $(this).next().next();
                                                                                    setTimeout(function () {
                                                                                        over.hide();
                                                                                        setTimeout(function () {
                                                                                            over.show();
                                                                                        }, 100)
                                                                                    }, 100)
                                                                                }
                                                                            }, 1000, "linear")
                                                                        }
                                                                    }, 200, "linear");
                                                                }
                                                            }, 1600, "linear")
                                                        }
                                                    }, 200, "linear");
                                                }
                                            }, 1600, "linear")
                                        }
                                    }, 200, "linear");
                                }
                            }, 1600, "linear")
                        }
                    }, 200, "linear");
                }
            }, 1600, "linear")
            $("#page-6 .game li:first").transition({ width: 179 }, 1600, "linear");
        }

    </script>
    <style type="text/css">
        li {
            list-style: none;
        }
    </style>
</head>
<body>
    <div class="page" id="page-8">
        <div class="cp">
            <div class="cp-rotate full-img">
                <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-rotate.png" />
            </div>
            <ul>
                <li class="full-img cp-1">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-1.png" /></li>
                <li class="full-img cp-2">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-2.png" /></li>
                <li class="full-img cp-3">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-3.png" /></li>
                <li class="full-img cp-4">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-4.png" /></li>
                <li class="full-img cp-5">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-5.png" /></li>
                <li class="full-img cp-6">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-6.png" /></li>
                <li class="full-img cp-7">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-7.png" /></li>
                <li class="full-img cp-8">
                    <img src="http://dn-h6app.qbox.me/static/images/pingwest/cp-8.png" /></li>
            </ul>
        </div>
        <div class="full-img text">
            <img src="http://dn-h6app.qbox.me/static/images/pingwest/8-text-0.png" />
        </div>
    </div>

    <div class="page" id="page-6">
        <div class="full-img title">
            <img src="http://dn-h6app.qbox.me/static/images/pingwest/6-title.png" />
        </div>
        <div class="full-img text">
            <img src="http://dn-h6app.qbox.me/static/images/pingwest/6-text.png" />
        </div>
        <div class="game">
            <div class="eat-author full-img">
                <img src="http://dn-h6app.qbox.me/static/images/pingwest/eat-author.png" />
            </div>
            <ul>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
            </ul>
            <div class="over full-img auto-x auto-y">
                <img src="http://dn-h6app.qbox.me/static/images/pingwest/over.png" />
            </div>
        </div>
    </div>

</body>
</html>
