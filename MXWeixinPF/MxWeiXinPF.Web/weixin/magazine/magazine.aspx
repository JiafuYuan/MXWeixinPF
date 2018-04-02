<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="magazine.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.magazine" %>

<!DOCTYPE html>
<html class="no-js admin responsive-320    ui-viewport-640     showcase-feature" lang="zh-CN">
<script type="text/javascript">
    window.l_createElement = document.createElement;
    window.l_Function = window.Function;
    window.l_open = window.open;
    window.l_adoptNode = document.adoptNode;
    window.l_defineProperty = Object.defineProperty;
</script>
<head runat="server">
    <meta charset="utf-8">
    <meta name="HandheldFriendly" content="True">
    <meta name="MobileOptimized" content="320">
    <meta name="format-detection" content="telephone=no">
    <meta http-equiv="cleartype" content="on">
    <!-- dns prefetch -->
    <title></title>
    <!-- _global -->
    <script>

        document.createElement = window.l_createElement;
        window.Function = window.l_Function;
        window.open = window.l_open;
        document.adoptNode = window.l_adoptNode;
        Object.defineProperty = window.l_defineProperty;

        var _global = { "is_mobile": false };

        //base_head_script.js
        function viewportMeta() {
            var e = parseInt(window.screen.width), t = e / 640, i = navigator.userAgent;
            if (/Android (\d+\.\d+)/.test(i))
            {
                var a = parseFloat(RegExp.$1); document.write(a > 2.3 ? '<meta name="viewport" content="width=640, minimum-scale = ' + t + ", maximum-scale = " + t + ', target-densitydpi=device-dpi">' : '<meta name="viewport" content="width=640, target-densitydpi=device-dpi">')
            }
            else document.write('<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi">')
        }
        function _cdnFallback(e) {
            var t = e.nodeName.toLowerCase(), i = document.createElement(t), a = { script: "src", link: "href" }, n = a[t], o = e[n];
            o = o.replace("kdt-static.qiniudn.com", "kdt-static.b0.upaiyun.com"), "link" == t && (i.rel = "stylesheet"), i[n] = o, document.body.appendChild(i)
        }
        !function (e) {
            var t = document.documentElement;
            e.match(/micromessenger\/5/gi) ? t.className = t.className + " mobile wx_mobile wx_mobile_5" : e.match(/micromessenger/gi) ? t.className = t.className + " mobile wx_mobile" : window._global.is_mobile && (t.className = t.className + " mobile")
        }(navigator.userAgent || navigator.vendor || window.opera);
    </script>


    <!-- meta viewport -->
    <script>viewportMeta && viewportMeta(); </script>

    <!-- CSS -->
    <link rel="stylesheet" href="css/base_8bebc248be.css" onerror="_cdnFallback(this)">
    <link rel="stylesheet" href="css/showcase_admin_015e1d3671.css" onerror="_cdnFallback(this)">
    <style>
        body {
            background-color: #f9f9f9;
        }
    </style>
</head>

<body class=" full-screen">
    <!-- container -->
    <div class="container ">
        <div class="content ">
            <div class="content-body">
                <div class="ui-loading" id="js-loading">
                    <div class="loading-animate"></div>
                </div>
                <!-- 临时解决MX3下固件引起的bug -->
                <!--擦拭图片-->
                <!--data-bg:擦拭后，data-url:擦拭前-->
                <div id="js-mask" class="ui-mask" data-url="<%=cleanImg%>" data-bg="<%=fristImg %>"></div>

                <div class="tpl-scroll js-tpl-scroll-container">
                    <!--data-loop:是否循环滚动-->
                    <div class="swiper-container js-tpl-scroll" data-loop="<%=ckRepeat %>">
                        <div class="swiper-wrapper">
                            <!--封面图片-->
                            <div class="swiper-slide" data-hash="slide_first">
                                <i id="wxcover" data-wxcover="<%=fristImg %>" style="background-image: url(<%=fristImg%>);"></i>
                                <div class="ui-up-arrow js-up-arrow">
                                    <img src="img/gesture_mini.png" alt="滑动提示" width="230" height="280">
                                </div>
                            </div>
                            <!--/封面图片-->

                            <!--过场图片-->
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <div class="swiper-slide" data-hash="slide_<%#Container.ItemIndex+2 %>">
                                        <i style="background-image: url(<%#Eval("url")%>);"></i>
                                        <div class="anm-wrap"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <!--/过场图片-->

                            <!--封底图片,有链接时改成a标签-->
                            <div class="swiper-slide" data-hash="slide_last">
                                <%if (linkurl != "")
                                  { %>
                                <a class="js-lazy-scroll" target="_blank" href="<%=linkurl %>" data-src="<%=lastImg %>"></a>
                                <%}
                                  else
                                  { %>
                                <i class="js-lazy-scroll" data-src="<%=lastImg %>"></i>
                                <%} %>
                            </div>
                            <!--/封底图片-->
                        </div>
                    </div>
                    <div class="hide" id="wxdesc"></div>
                    <!--音乐区-->
                    <%if (ckMusic == "1")
                      {  %>
                    <div class="ui-right-btns js-beta-coffee js-audio" data-src="<%=groundMusic %>">
                        <i class="ui-music-btn js-music-btn"></i>
                    </div>
                    <% } %>
                    <div class="ui-left-btns">
                        <a href="javascript:void(0)"><i class="ui-homepage-btn"></i></a>
                    </div>
                </div>

            </div>
        </div>
        <!-- fuck taobao -->
        <div id="js-fuck-taobao" class="fullscreen-guide fuck-taobao hide">
            <span class="js-close-taobao guide-close">&times;</span>
            <span class="guide-arrow"></span>
            <div class="guide-inner">
                <div class="step step-1"></div>
                <div class="js-step-2 step"></div>
            </div>
        </div>
    </div>

    <!-- JS -->
    <script src="js/jquery-2.0.3.min.js" onerror="_cdnFallback(this)"></script>
    <script src="js/base_a2880871e1.js" onerror="_cdnFallback(this)"></script>
    <script src="js/main_d7a097e190.js" onerror="_cdnFallback(this)"></script>
    <script src="js/scroll_7523dfb4df.js" onerror="_cdnFallback(this)"></script>
    <script src="js/base_b67b711127.js" onerror="_cdnFallback(this)"></script>
    <!--<script src="http://kdt-static.qiniucdn.com/v2/build/wap/showcase/index_1e5a2636a9.js" onerror="_cdnFallback(this)"></script> -->

</body>
</html>
