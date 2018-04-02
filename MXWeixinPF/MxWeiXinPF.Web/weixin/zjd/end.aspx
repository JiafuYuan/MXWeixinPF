<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="end.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.zjd.end" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/main.css?20140123" media="all">
    <link rel="stylesheet" type="text/css" href="css/dialog.css" media="all">
    <script src="js/zepto.js" type="text/javascript"></script>
    <script src="js/dialog_min.js" type="text/javascript"></script>
    <script src="js/player_min.js" type="text/javascript"></script>
    <script src="js/main.js" type="text/javascript"></script>
    <title>砸金蛋</title>

    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">

    <!-- Mobile Devices Support @begin -->

    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta content="no-cache" http-equiv="pragma">
    <meta content="0" http-equiv="expires">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <!-- apple devices fullscreen -->
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <!-- Mobile Devices Support @end -->

</head>
<body onselectstart="return true;" ondragstart="return false;">
    <form runat="server" id="form1">
        <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />
        <script>
            document.addEventListener("DOMContentLoaded", function () {
                playbox.init("playbox");
                //
                var shape = document.getElementById("shape");
                var hitObj = {
                    handleEvent: function (evt) {
                        if ("SPAN" == evt.target.tagName) {
                            var audio = new Audio();
                            audio.src = "<%=backmusic%>";
                            audio.play();
                            setTimeout(function () {
                                evt.target.classList.toggle("on");
                                //var rand = Math.round(Math.random()*10);
                                var submitData = {
                                    token: "o99epjjmjWhMPNzoQbo9r6DAEYds",
                                    ac: "zjduser",
                                    formhash: "574b8ba6",
                                    tid: "513",
                                };
                                $.ajax({
                                    url: 'index.aspx??wid=<%=wid%>&aid=<%=aid%>',
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
                                            var urls = ["image/coin.png"];
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
            <div style="position: absolute; left: 10px; top: 10px; z-index: 350;">
<a id="playbox" class="btn_music" ontouchstart="event.stopPropagation();" onclick="playbox.init(this).play();" href="javascript:;"></a>

<audio id="audio" style="pointer-events:none;display:none;width:0!important;height:0!important;" src="null" loop=""></audio>
            </div>
            <section class="stage">
                <img src="image/activity-zjd-end.jpg">
                <div class="red">
                           
                     活动已结束！
                </div>

            </section>
             
           
        </div>
        
       
    </form>
</body>
</html>
