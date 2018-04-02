<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.zjd.index" %>

<!DOCTYPE html>
<% if (ErrLevel < 100)
   {
       Response.Write(ErrorInfo);
   }
   else if (ErrLevel == 101)
   {  //活动已结束，跳转到结束页面
%>
<script type="text/javascript">
    window.location.href = "end.aspx?wid=<%=wid%>&aid=<%=aid%>&openid=<%=openid%> ";
</script>
<%
   }
   else
   {  %>
<html>
<head id="head1" runat="server">
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
    <style>
    </style>

</head>
<body onselectstart="return true;" ondragstart="return false;">
    <script>
        document.addEventListener("DOMContentLoaded", function(){
            playbox.init("playbox");
          
            var shape = document.getElementById("shape");
            var hitObj = {
                handleEvent: function (evt) {

                    if ("SPAN" == evt.target.tagName) {
                        var audio = new Audio();
                        audio.src = "music/smashegg.mp3";
                        audio.play();
                        setTimeout(function () {
                            evt.target.classList.toggle("on");
                            var rand = Math.round(Math.random()*10);
                                              
                            var openidValue = document.getElementById("openidValue").value;
                            var widValue = document.getElementById("widValue").value;
                            var aidValue=document.getElementById("aidValue").value;
                            var submitData = { 
                                openid: openidValue,
                                wid: widValue,
                                aid: aidValue,
                                myact: "choujiang"
                            };
                            $.post('zjd.ashx', submitData,
                             function (data) {
                                 if (data.content == "恭喜你中奖了!") {
                                         
                                     // alert(data.content);

                                     document.getElementById("hidAwardId").value=  data.uid;
                                     jg(data);
                                     // window.location.href = "index.aspx?wid=<%=wid%>&aid=<%=aid%>&openid=<%=openid%>";

                                 }
                                 if(data.error=="end")
                                 {
                                     window.location.href = "end.aspx?wid=" +<%=wid%> +"&aid=" +<%=aid%> +"&openid=" +<%=openid%> +"";
                                         }
                                 if(data.error=="-1")
                                 {
                                     alert(data.content);
                                 }
                                 if(data.error=="notimes")
                                 {
                                     alert(data.content);
                                 }
                                 else { 
                                                                                
                                     //alert(data.content);
                                     //jg(data);
                                 }
                             },
                                       "json");


                        }, 100);
                                 $("#hit").addClass("on").css({ left: evt.pageX + "px", top: evt.pageY + "px" });
                             }
                    //shape.classList.toggle("pause");
                    shape.removeEventListener("click", hitObj, false);
                    // setTimeout(function(){$("#hit").removeClass("on");}, 1500);
                }
            }

            shape.addEventListener("click", hitObj, false);

        }, false);
    </script>

    <div class="body pb_10">
        <div style="position: absolute; left: 10px; top: 10px; z-index: 350;">
        <a href="javascript:;" id="playbox" class="btn_music" onclick="playbox.init(this).play();" ontouchstart="event.stopPropagation();"></a><audio id="audio" loop="" src="<%=backmusic %>" style="pointer-events:none;display:none;width:0!important;height:0!important;"></audio>
            <!-- 上面一行不能换行-->
        </div>

        <%=sectinstring %>

        <section>
            <div class="instro_wall">
                <article>
                    <h6>参与次数</h6>
                    <div>
                        <p>
                            <p>
                                每人最多允许抽奖总次数<asp:Literal ID="littotTimes" runat="server" EnableViewState="false"></asp:Literal>次,每人每天最多抽奖次数  
                                    <asp:Literal ID="litdaysTimes" runat="server" EnableViewState="false"></asp:Literal>
                                次 你已经砸了
                                    <asp:Literal ID="litHasUsedTimes" runat="server" EnableViewState="false"></asp:Literal>次
                            </p>
                        </p>
                    </div>
                </article>
                <article>
                    <h6>活动说明</h6>
                    <div>

                        <p><%=begininfo %>  </p>
                    </div>
                </article>
                <article class="a3">
                    <h6>活动奖项</h6>
                    <div>
                        <ul>
                            <ol>
                                <%=jiangpinlist %>
                            </ol>
                        </ul>
                    </div>
                </article>
                <article>
                    <h6>我的中奖纪录</h6>
                    <div>
                        <table>
                            <%=zjjl %>
                        </table>

                    </div>
                </article>
                <article>
                    <h6>最新中奖手机号</h6>
                    <div>
                        <table>
                            <%=zhongjtel %>
                        </table>
                    </div>
                </article>
            </div>
        </section>
        <footer style="text-align: center; color: #fff; margin-right: 20px"></footer>
    </div>
    <div class="boxcontent boxwhite">
        <div class="box">
            <div class="title-red"><span></span></div>

            <div class="Detail">

                <asp:Literal ID="litOtherTip" runat="server" EnableViewState="false"></asp:Literal>
                <asp:Literal ID="litJiangXing" runat="server" EnableViewState="false"></asp:Literal>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" value="0" id="pwdstatus" />
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
	    <%=pwdinput%></table>',
                    btns: [
                    {
                        id: "",
                        name: "确定",
                        onclick: "fn.call();",

                        fn: function (self) {
                            var pwd= $.trim($("#pwdstatus").val());
                            if(pwd=="0")
                            {
                                var obj = {
                                    id: $.trim($("#hidAwardId").val()),                      
                                    tid: 513,
                                    snumber:$.trim($("#d1_1").val()),
                                    aid: <%=aid%>,                        
                                    openid: "<%=openid%>"                          
                                }
                            }
                            else
                            {
                                var obj = {
                                    id: $.trim($("#hidAwardId").val()),                      
                                    pwd:$.trim($("#d1_2").val()), 
                                    tid: 513,
                                    snumber:$.trim($("#d1_1").val()),
                                    aid: <%=aid%>,                        
                                    openid: "<%=openid%>"                          
                                }
                            }
                                       
                            $.ajax({
                                url: "zjd.ashx?myact=updatestatus",
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
                        id: "",
                        name: "领取",
                        onclick: "fn.call();",
                        fn: function (self) {
                     
                            var obj = {                          
                                username: $.trim($("#d2_1").val()),
                                tel: $.trim($("#d2_2").val()),                          
                                snumber: arg.code,                          
                                id: $.trim($("#hidAwardId").val()),
                                aid: <%=aid%>,                        
                                openid: "<%=openid%>"
                            }
                           
                            $.ajax({

                                url: "zjd.ashx?myact=update",
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
            function jg(arg){
     
                var d3 = new iDialog();
                d3.open({
                    classList: "result",
                    title:"",
                    close:"",
                    content:'<div class="header"><h5 style="color:#2f8ae5;font-size:16px;">恭喜您中奖了！您的运气实在是太好了！</h6></div>\
<table><tr>\
<td style="width:75px;"><label>'+arg.c_type+'</label></td>\
<td><img src="'+arg.c_pic+'" /></td>\
<td style="width:75px;"><label>'+arg.c_name+'</label></td>\
</tr></table>',
                    btns:[
                    {id:"", name:"领取奖品", onclick:"fn.call();", fn: function(self){
                        self.die();
                        lq(arg);
                    }},
                    {id:"", name:"关闭", onclick:"fn.call();", fn: function(self){
                        location.href = location.href + "&r="+Math.random();
                        self.die();
                    },}
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
<td><img src="image/7.png" /></td>\
<td style="width:170px;"><label><%=contractInfo%></label></td>\
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
<td><img src="image/8.png" /></td>\
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


            //领取结果

            $(function(){
           
            <%=initAlert%>

                //var d4 = new iDialog();
                //d4.open({
                //    classList: "result get_result",
                //    title:"",
                //    close:"",
                //    content:'<div class="header"><h6>您已中奖</h6></div>\
                // <table><tr>\
                // <td style="width:75px;"><label>1</label></td>\
                // <td><img src="http://dddd.cn/ke4/attached/image/uid10441/33473/20140311120910_88445.jpg" /></td>\
                // <td style="width:75px;"><label>一等奖</label></td>\
                // </tr></table>',
                //    btns:[
                //    {id:"", name:"领取奖品", onclick:"fn.call();", fn: function(self){
                //        self.die();
                //        lq({code:"061905102525035555", snid:'1'});
                //    }},
                //    {id:"", name:"关闭", onclick:"fn.call();", fn: function(self){
                //        self.die();
                //    },}
                //    ]
                //});

            });

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

    </script>
    <div mark="stat_code" style="width: 0px; height: 0px; display: none;">
    </div>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="isStatus" value="" />

        <input type="hidden" runat="server" id="openidValue" value="" />
        <input type="hidden" runat="server" id="widValue" value="" />
        <input type="hidden" runat="server" id="aidValue" value="" />
        <input type="hidden" runat="server" id="daycountValue" value="" />
        <input type="hidden" runat="server" id="personcounValue" value="" />
        <input type="hidden" runat="server" id="totalValue" value="" />
        <input type="hidden" runat="server" id="Hidden1" value="" />
        <input type="hidden" runat="server" id="hastime" value="" />
        <input type="hidden" runat="server" id="daytime" value="" />
        <input type="hidden" id="shape" value="on" />

        <asp:HiddenField ID="hidStatus" runat="server" Value="" EnableViewState="false" />
        <asp:HiddenField ID="hidErrInfo" runat="server" EnableViewState="false" />
        <asp:HiddenField ID="hidAwardId" runat="server" EnableViewState="false" Value="0" />

    </form>
</body>
</html>
<% }%>