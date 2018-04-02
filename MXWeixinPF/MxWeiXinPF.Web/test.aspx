<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="MxWeiXinPF.Web.test" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>最爱自己的那两个人</title>
    <meta charset="utf-8">
    <meta content="" name="description">
    <meta content="" name="keywords">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="telephone=no, address=no" name="format-detection">
    <link href="http://stc.weimob.com/css/magazine/main.css?v=5" rel="stylesheet" />
    <script type="text/javascript">
        (function () {
            var phoneWidth = parseInt(window.screen.width),
                phoneScale = phoneWidth / 640,
                ua = navigator.userAgent;

            if (/Android (\d+\.\d+)/.test(ua)) {
                var version = parseFloat(RegExp.$1);
                // andriod 2.3
                if (version > 2.3) {
                    document.write('<meta name="viewport" content="width=640, minimum-scale = ' + phoneScale + ', maximum-scale = ' + phoneScale + ', target-densitydpi=device-dpi">');
                    // andriod 2.3以上
                } else {
                    document.write('<meta name="viewport" content="width=640, target-densitydpi=device-dpi">');
                }
                // 其他系统
            } else {
                document.write('<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi">');
            }
        })();
        var config = {
            coverUrl: 'http://317995.m.weimob.com/img/static/cc/e8/35/image/20140929/20140929092340_46173.jpg',
            swipeCur: 0,
            swipeDir: 'horizontal', // 'vertical' // horizontal
        }
    </script>
    <script src="http://stc.weimob.com/src/zepto_min.js?v=2014-05-21"></script>
    <script src="http://stc.weimob.com/src/magazine/lottery.js?v=5"></script>
    <script src="http://stc.weimob.com/src/magazine/swipe.js?v=5"></script>
    <script src="http://stc.weimob.com/src/magazine/player.js?v=5"></script>
    <script src="http://stc.weimob.com/src/magazine/stackBlur.js?v=5"></script>
    <script src="http://stc.weimob.com/src/magazine/app.js?v=5"></script>

</head>
<body onselectstart="return true;" ondragstart="return false;">
    <div class="container">
        <div class="loading-img">
            <img src="http://stc.weimob.com/imgs/loading.gif?v=2014-05-21" /></div>

        <div class="swipe" id="swipe">
            <ul>

                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929092509_92742.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929092526_74760.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093128_88373.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093144_62572.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093202_61904.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093221_50612.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093358_86114.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093416_75425.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093433_89277.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093458_81697.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093514_38766.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093527_10580.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093543_91197.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093558_66164.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093613_25004.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140929/20140929093629_83545.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140930/20140930102441_98331.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140930/20140930102456_48162.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140930/20140930102515_36585.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/cc/e8/35/image/20140930/20140930102534_44450.jpg)"></div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/96/a9/e0/image/20141014/20141014125403_73340.jpg)"></div>
                </li>


                <li>
                    <!--带按钮的图片需加上class top/middle/bottom ，位置分别在上中下 -->
                    <div class="middle" style="background-image: url(http://scene.img.weimob.com/static/96/a9/e0/image/20141017/20141017092352_41676.gif)">
                        <a class="links" href="http://mp.weixin.qq.com/s?__biz=MzA4NTkxNzEwNg==&mid=204153673&idx=1&sn=d65400c2568b2c221cbbc75174a54df3#rd">
                            <img src="http://hs-album.oss.aliyuncs.com/static/96/a9/e0/image/20141014/20141014133507_32992.png" /></a>
                    </div>
                </li>


                <li>
                    <div style="background-image: url(http://scene.img.weimob.com/static/96/a9/e0/image/20141002/20141002215249_73266.jpg)"></div>
                </li>




            </ul>
        </div>
        <div id="musicWrap" class="music_wrap f-hide">
            <span class="text move hide">打开</span>
            <i id="audioBtn" data-src="http://scene.video.weimob.com/video/cc/e8/35/mp3/20140927/格式工厂爸爸~2.mp3" class="btn_music on"></i>
        </div>

        <div id="arrowV" class="arrow_v f-hide">
            <p></p>
        </div>

        <div id="arrowH" class="arrow_h f-hide">
            <span class="arrow_l"></span>
            <span class="arrow_r"></span>
        </div>

        <div class="lottery" id="lottery"></div>
        <div class="download_mask" id="downloadMask"><i></i></div>
    </div>
    <script>
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {

            window.shareData = {
                "imgUrl": "http://hs-album.oss.aliyuncs.com/static/cc/e8/35/image/20140927/20140927090434_64808.jpg",
                "timeLineLink": "http://317995.m.weimob.com/magazine/magazine?_tj_twtype=31&_tj_pid=317995&_tt=1&_tj_graphicid=5804471&_tj_title=%E6%97%B6%E9%97%B4%E9%83%BD%E5%8E%BB%E5%93%AA%E4%BA%86&_tj_keywords=%E7%88%B6%E6%AF%8D&id=5101&wechatid=fromUsername&pid=317995&wxref=mp.weixin.qq.com&noe=1&channel=share%5E",
                "sendFriendLink": "http://317995.m.weimob.com/magazine/magazine?_tj_twtype=31&_tj_pid=317995&_tt=1&_tj_graphicid=5804471&_tj_title=%E6%97%B6%E9%97%B4%E9%83%BD%E5%8E%BB%E5%93%AA%E4%BA%86&_tj_keywords=%E7%88%B6%E6%AF%8D&id=5101&wechatid=fromUsername&pid=317995&wxref=mp.weixin.qq.com&noe=1&channel=share%5E",
                "weiboLink": "http://317995.m.weimob.com/magazine/magazine?_tj_twtype=31&_tj_pid=317995&_tt=1&_tj_graphicid=5804471&_tj_title=%E6%97%B6%E9%97%B4%E9%83%BD%E5%8E%BB%E5%93%AA%E4%BA%86&_tj_keywords=%E7%88%B6%E6%AF%8D&id=5101&wechatid=fromUsername&pid=317995&wxref=mp.weixin.qq.com&noe=1&channel=share%5E",
                "tTitle": "原来我们不在家，父母是这样的……",
                "tContent": "送给最爱自己的那两个人",
                "fTitle": "原来我们不在家，父母是这样的……",
                "fContent": "送给最爱自己的那两个人",
                "wContent": "送给最爱自己的那两个人"
            };

            // 发送给好友
            WeixinJSBridge.on('menu:share:appmessage', function (argv) {
                WeixinJSBridge.invoke('sendAppMessage', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.sendFriendLink,
                    "desc": window.shareData.fContent,
                    "title": window.shareData.fTitle
                }, function (res) {
                    if ('send_app_msg:cancel' != res.err_msg) {
                        shareReport();
                    }
                    _report('send_msg', res.err_msg);
                })
            });

            // 分享到朋友圈
            WeixinJSBridge.on('menu:share:timeline', function (argv) {
                WeixinJSBridge.invoke('shareTimeline', {
                    "img_url": window.shareData.imgUrl,
                    "img_width": "640",
                    "img_height": "640",
                    "link": window.shareData.timeLineLink,
                    "desc": window.shareData.tContent,
                    "title": window.shareData.tTitle
                }, function (res) {
                    if ('share_timeline:cancel' != res.err_msg) {
                        shareReport();
                    }
                    _report('timeline', res.err_msg);
                });
            });

            // 分享到微博
            WeixinJSBridge.on('menu:share:weibo', function (argv) {
                WeixinJSBridge.invoke('shareWeibo', {
                    "content": window.shareData.wContent,
                    "url": window.shareData.weiboLink
                }, function (res) {
                    if ('share_weibo:cancel' != res.err_msg) {
                        shareReport();
                    }
                    _report('weibo', res.err_msg);
                });
            });
        }, false)
        function shareReport() {
            var pid = '317995';
            var id = '5101';
            var wechatid = 'oslvvt_C09Ysplk0IhGLFoAEQzjg';
            var url = '/magazine/magazine/ShareBack';
            $.post(url, { pid: pid, id: id, wechatid: wechatid }, function (data) {
                if (data.status == 0) {
                    // success
                    // alert(data.message);
                    finishDump(data.data);
                } else {
                    // failed
                    // alert(data.message);
                }
            }, 'json');
        }
        function FavoriteReport() {
            var pid = '317995';
            var id = '5101';
            var wechatid = 'oslvvt_C09Ysplk0IhGLFoAEQzjg';
            var url = '/magazine/magazine/ShareBack';
            $.post(url, { pid: pid, id: id, wechatid: wechatid }, function (data) {
                if (data.status == 0) {
                    // success
                    // alert(data.message);
                    finishDump(data.data);
                } else {
                    // failed
                    // alert(data.message);
                }
            }, 'json');
        }
        function finishDump(data) {
            if (data) {
                if (data.redirect) {
                    window.location = data.redirect;
                } else if (data.tel) {
                    var tel_obj = $('<a href="tel:' + data.tel + '"></a>');
                    $(tel_obj).trigger('click');
                }
            }
        }
        // shareReport();
        // FavoriteReport();
    </script>
    <script type="text/javascript" src="http://stc.weimob.com/src/st/share_channel.js?v=123456"></script>
    <script type="text/javascript" src="http://stc.weimob.com/src/st/base64.js?v=10101011"></script>
    <script type="text/javascript" src="http://stc.weimob.com/src/st/st.js?v=10101011"></script>
    <script type="text/javascript">
        //使用案例如###如若上线请到研发群找我@赵增煜###
        st.push("_triggerEvent", {
            "is_statistic_on": "on", //开关
            "statisticServerPath": "http://statistic.weimob.com/wm.js", //统计地址
            "memcServerPath": "http://statistic.weimob.com/memc?cmd=get", //缓存地址
            "stat_action": "loadPage",  //统计动作类型
            "stat_optValue": ""    //参数值
        });
    </script>
</body>
</html>
