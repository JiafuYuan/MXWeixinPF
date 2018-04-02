<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.zjd.WebForm1" %>

<!DOCTYPE html>
 <html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <meta charset="utf-8">
        <link rel="stylesheet" type="text/css" href="http://img.ishangtong.com/zjd/reset.css" media="all">
<link rel="stylesheet" type="text/css" href="http://img.ishangtong.com/zjd/main.css?20140123" media="all">
<link rel="stylesheet" type="text/css" href="http://img.ishangtong.com/zjd/dialog.css" media="all">
<script src="http://img.ishangtong.com/zjd/zepto.js" type="text/javascript"></script>
<script src="http://img.ishangtong.com/zjd/dialog_min.js" type="text/javascript"></script>
<script src="http://img.ishangtong.com/zjd/player_min.js" type="text/javascript"></script>
<script src="http://img.ishangtong.com/zjd/main.js" type="text/javascript"></script>
<title>砸金蛋</title>
        
<meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
     
        <!-- Mobile Devices Support @begin -->
            
            <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
            <meta content="no-cache" http-equiv="pragma">
            <meta content="0" http-equiv="expires">
            <meta content="telephone=no, address=no" name="format-detection">
            <meta content="width=device-width, initial-scale=1.0" name="viewport">
            <meta name="apple-mobile-web-app-capable" content="yes"> <!-- apple devices fullscreen -->
            <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
        <!-- Mobile Devices Support @end -->
  <style>
    </style>
    </head>
    <body onselectstart="return true;" ondragstart="return false;">
    
              <script>
                  document.addEventListener("DOMContentLoaded", function () {
                      playbox.init("playbox");
                      //
                      var shape = document.getElementById("shape");
                      var hitObj = {
                          handleEvent: function (evt) {
                              if ("SPAN" == evt.target.tagName) {
                                  var audio = new Audio();
                                  audio.src = "http://img.ishangtong.com/zjd/smashegg.mp3";
                                  audio.play();
                                  setTimeout(function () {
                                      evt.target.classList.toggle("on");
                                      //var rand = Math.round(Math.random()*10);
                                      var submitData = {
                                          token: "o7MB9jtqWGlltLePYaJim_Sg2hV0",
                                          ac: "zjduser",
                                          formhash: "f5fac067",
                                          tid: "1",
                                      };
                                      $.ajax({
                                          url: 'index.php?ac=zjduser&tid=1&token=o7MB9jtqWGlltLePYaJim_Sg2hV0',
                                          type: "POST",
                                          dataType: "json",
                                          async: true,
                                          data: submitData,
                                          success: function (res) {
                                              if (1 == res.success) {
                                                  evt.target.classList.toggle("luck");
                                              }
                                              setTimeout(function () {
                                                  if (1 == res.success) {
                                                      var urls = ["http://img.ishangtong.com/zjd/smashegg/coin.png"];
                                                      getCoin(urls);
                                                      jg(res.data);
                                                  } else {
                                                      lqsb(res.msg);
                                                  }
                                              }, 2000);
                                          }
                                      });

                                  }, 100);
                                  $("#hit").addClass("on").css({ left: evt.pageX + "px", top: evt.pageY + "px" });
                              }
                              //shape.classList.toggle("pause");
                              shape.removeEventListener("click", hitObj, false);
                              //setTimeout(function(){$("#hit").removeClass("on");}, 1500);
                          }
                      }

                      shape.addEventListener("click", hitObj, false);

                  }, false);
</script>
<div class="body pb_10">
<div style="position:absolute;left:10px;top:10px;z-index:350;">
<a href="javascript:;" id="playbox" class="btn_music" onclick="playbox.init(this).play();" ontouchstart="event.stopPropagation();"></a><audio id="audio" loop="" src="http://img.ishangtong.com/zjd/default.mp3" style="pointer-events:none;display:none;width:0!important;height:0!important;"></audio>
</div>
<section  class="stage">
<img src="http://img.ishangtong.com/zjd/stage.jpg">
         <div  id="shape" class="cube on">
        <div class="plane one"><span><figure>&nbsp;</figure></span></div>
        <div class="plane two"><span><figure>&nbsp;</figure></span></div>
        <div class="plane three"><span><figure>&nbsp;</figure></span></div>
      </div>
      <div id="hit" class="hit"><img src="http://img.ishangtong.com/zjd/1.png"></div>
           </section>
<section>
<div class="instro_wall">
<article>
<h6>参与次数</h6>
<div>
                
                <p>
                <p   >本次活动每天可以砸23次,总共可以砸 720 次 你已经砸了4次 </p>
                </p>
</div>
</article>
<article>
<h6>活动说明</h6>
<div>
 	
               <p>   <p>
	亲，请点击进入砸金蛋砸奖活动页面，祝您好运哦！
</p>
<p>
	仅作测试，不要当真！
</p>  </p>
</div>
</article>
<article class="a3">
<h6>活动奖项</h6>
<div>
<ul>
<ol>

                                                        <li>
<p>
一等奖 <label class="color_golden">:12</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400211437446.jpg"></figure>
<label> iMac</label>
</li>
                            
                                                         <li>
<p>
二等奖 <label class="color_golden">:40</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400211437453.jpg"></figure>
<label> ipad</label>
</li>
                            
		
                                                         <li>
<p>
三等奖 <label class="color_golden">:230</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400211437460.jpg"></figure>
<label> iphone</label>
</li>
                            
		
                                                         <li>
<p>
四等奖 <label class="color_golden">:140</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400741171719.jpg"></figure>
<label> ipadmin</label>
</li>
                            
		
                                                         <li>
<p>
五等奖 <label class="color_golden">:50</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400741171665.jpg"></figure>
<label> 记事本</label>
</li>
                            
		
                                                         <li>
<p>
六等奖 <label class="color_golden">:60</label>
</p>
<figure><img src="http://weixinapi.qiniudn.com/1400211437453.jpg"></figure>
<label> 笔记本</label>
</li>
                            
		
                             		
                             		
                             		
                                                          												
</ol>
</ul>
</div>
</article>
<article>
<h6>我的中奖纪录</h6>
<div>
<table>
                    
                      </table>

</div>
</article>
 <article>
<h6>最新中奖手机号</h6>
<div>
<table  >
 
                            
                                                    <tr>
                         <td  >2014-07-26 14:54:59</td>
                         <td  >155****9656</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-25 23:55:24</td>
                         <td  >****</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-25 12:55:49</td>
                         <td  >152****6870</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-25 11:39:58</td>
                         <td  >185****2387</td>

<td>砸中三等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-25 11:36:57</td>
                         <td  >185****2387</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-24 19:11:47</td>
                         <td  >****</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-24 18:22:07</td>
                         <td  >138****8000</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-24 16:39:03</td>
                         <td  >183****9122</td>

<td>砸中四等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-24 16:37:55</td>
                         <td  >183****9122</td>

<td>砸中三等奖</td>
                            
</tr>
                          
                                                    <tr>
                         <td  >2014-07-24 16:09:47</td>
                         <td  >138****8000</td>

<td>砸中四等奖</td>
                            
</tr>
                                                 
 </table>
</div>
</article>
</div>
</section>
<footer style="text-align:center; color:#fff;margin-right:20px"></footer>
</div>
<script>
    //申请兑换
    function sqdh(arg) {
        var d1 = new iDialog();
        d1.open({
            classList: "apply",
            title: "",
            close: "",
            content: '<div class="header"><h6 style="color:#fff;">申请兑换</h6></div>\
<table>\
<tr><td>中奖码：<input type="text" id="d1_1" placeholder="" maxlength="30" readonly="readonly" value="'+ arg.code + '" /></td></tr>\
	<tr><td><input type="text" id="d1_2" placeholder="请输入兑奖密码" maxlength="30" /></td></tr>\</table>',
            btns: [
            {
                id: "", name: "确定", onclick: "fn.call();", fn: function (self) {
                    var obj = {
                        code: $.trim($("#d1_1").val()),
                        parssword: $.trim($("#d1_2").val()), tid: 1,
                        formhash: "f5fac067",
                        action: "setps"
                    }
                    $.ajax({
                        url: "index.php?ac=zjduser",
                        type: "POST",
                        dataType: "json",
                        data: obj,
                        success: function (res) {
                            if (1 == res.success) {
                                alert('兑奖状态已经记录');
                                location.href = location.href + "&r=" + Math.random();
                                self.die();

                            } else {
                                alert('兑奖密码错误');
                            }
                        }
                    });
                }
            },
            {
                id: "", name: "关闭", onclick: "fn.call();", fn: function (self) {
                    self.die();
                },
            }
            ]
        });
    }

    //领取
    function lq(arg) {
        var d2 = new iDialog();
        d2.open({
            classList: "get",
            title: "",
            close: "",
            content: '<div class="header"><h6>中奖码：' + arg.code + '</h6></div>\
<table>\
<tr><td><input type="text" id="d2_1" placeholder="请输入联系人" maxlength="30" /></td></tr>\
<tr><td><input type="text" id="d2_2" placeholder="请输入手机号，以便领取奖品" maxlength="30" /></td></tr>\
</table>',
            btns: [
            {
                id: "", name: "领取", onclick: "fn.call();", fn: function (self) {
                    var obj = {
                        username: $.trim($("#d2_1").val()),
                        tel: $.trim($("#d2_2").val()),
                        tid: 1,
                        code: arg.code,
                        formhash: "f5fac067",
                        action: "setTel"
                    }
                    $.ajax({
                        url: "index.php?ac=zjduser",
                        type: "POST",
                        data: obj,
                        dataType: "json",
                        success: function (res) {
                            if (1 == res.success) {
                                self.die();
                                lqcg();
                            } else {
                                console.log();
                            }
                        }
                    });
                }
            },
            {
                id: "", name: "关闭", onclick: "fn.call();", fn: function (self) {
                    if ('no' != arg.loca) {
                        location.href = location.href + "&r=" + Math.random();
                    }
                    self.die();
                },
            }
            ]
        });
    }

    //结果
    function jg(arg) {
        var d3 = new iDialog();
        d3.open({
            classList: "result",
            title: "",
            close: "",
            content: '<div class="header"><h5 style="color:#2f8ae5;font-size:16px;">恭喜您中奖了！您的运气实在是太好了！</h6></div>\
<table><tr>\
<td style="width:75px;"><label>'+ arg.c_type + '</label></td>\
<td><img src="'+ arg.c_pic + '" /></td>\
<td style="width:75px;"><label>'+ arg.c_name + '</label></td>\
</tr></table>',
            btns: [
            {
                id: "", name: "领取奖品", onclick: "fn.call();", fn: function (self) {
                    self.die();
                    lq(arg);
                }
            },
            {
                id: "", name: "关闭", onclick: "fn.call();", fn: function (self) {
                    location.href = location.href + "&r=" + Math.random();
                    self.die();
                },
            }
            ]
        });
    }

    //领取结果


    //领取结果-成功
    function lqcg() {
        var d5 = new iDialog();
        d5.open({
            classList: "success",
            title: "",
            close: "",
            content: '<div class="header"><h6>成功领取</h6></div>\
<table><tr>\
<td><img src="http://img.ishangtong.com/zjd/smashegg/7.png" /></td>\
<td style="width:170px;"><label>兑奖请联系我们，电话189xxxxxxx1</label></td>\
</tr></table>',
            btns: [
            {
                id: "", name: "知道了", onclick: "fn.call();", fn: function (self) {
                    location.href = location.href + "&r=" + Math.random();
                    self.die();
                }
            },
            ]
        });
    }

    //砸蛋结果-失败
    function lqsb(msg) {
        var d6 = new iDialog();
        d6.open({
            classList: "failed",
            title: "",
            close: "",
            content: '<div class="header">' + msg + '</div>\
<table><tr>\
<td><img src="http://img.ishangtong.com/zjd/smashegg/8.png" /></td>\
</tr></table>',
            btns: [
            {
                id: "", name: "确定", onclick: "fn.call();", fn: function (self) {
                    location.href = location.href + "&r=" + Math.random();
                }
            },
            ]
        });
    }

    window.alert = function (str) {
        var d7 = new iDialog();
        d7.open({
            classList: "alert",
            title: "",
            close: "",
            content: str,
            btns: [
            {
                id: "", name: "确定", onclick: "fn.call();", fn: function (self) {
                    self.die();
                }
            },
            ]
        });
    }



    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {


        window.shareData = {
            "imgUrl": "http://www.wxapi.cn/index/images/activity/activity-zjd-start.jpg",
            "timeLineLink": "http://www.apiwx.com/?ac=zjd&tid=1&id=650&auth=1",
            "sendFriendLink": "http://www.apiwx.com/?ac=zjd&tid=1&id=650&auth=1",
            "weiboLink": "http://www.apiwx.com/?ac=zjd&tid=1&id=650&auth=1",
            "tTitle": "砸金蛋活动开始了（测试）",
            "tContent": "砸金蛋活动开始了（测试）",
            "fTitle": "砸金蛋活动开始了（测试）",
            "fContent": "砸金蛋活动开始了（测试）",
            "wContent": "砸金蛋活动开始了（测试）"
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
                _report('timeline', res.err_msg);
            });
        });

        // 分享到微博
        WeixinJSBridge.on('menu:share:weibo', function (argv) {
            WeixinJSBridge.invoke('shareWeibo', {
                "content": window.shareData.wContent,
                "url": window.shareData.weiboLink,
            }, function (res) {
                _report('weibo', res.err_msg);
            });
        });
    }, false)
</script>
        		<div mark="stat_code" style="width:0px; height:0px; display:none;">
</div>

 </body></html>