<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_form.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.hotel.hotel_form" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>在线预订</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/hotels.css?2013.11.19" rel="stylesheet" type="text/css">

    <link href="../../scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/bootstrap/datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />

    <link href="css/mystyle.css" rel="stylesheet" type="text/css">


    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script src="js/iscroll.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"></script>
     
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
</head>

<body id="hotelsorder" class="mode_webapp">
    <div class="banner">
        <div id="wrapper">
            <div id="scroller">
                <ul id="thelist">
                    <%=tupian %>
                </ul>
            </div>
        </div>
        <div id="nav">
            <div id="prev" onclick="myScroll.scrollToPage('prev', 0,400,2);return false">&larr; prev</div>
            <ul id="indicator">
                <%=tabid %>
            </ul>
            <div id="next" onclick="myScroll.scrollToPage('next', 0);return false">next &rarr;</div>
        </div>
        <div class="clr"></div>
    </div>


    <div class="cardexplain">


        <!--商家房价及类型-->
        <ul class="round">
            <li class="biaotou bradius pad">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>类型</td>
                        <td class="yuanjia">原价</td>
                        <td class="youhuijia">优惠价</td>
                    </tr>
                </table>
            </li>
            <li><span class="noneorder">
                <table class="jiagebiao" width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td><%=roomtype %></td>
                        <td class="yuanjia">￥<%=yuanjia %></td>
                        <td class="youhuijia">￥<%=xianjia %></td>
                    </tr>
                </table>
            </span>
            </li>

        </ul>

        <!--后台可控制是否显示-->


        <div class="detailcontent">
            <h2>相关说明</h2>
            <div class="content"><%=peitao %> </div>
        </div>

        <ul class="round">
            <li class="tel"><a href="tel:<%=tel %>"><span><%=tel %> 电话预订</span></a></li>
        </ul>



        <input type="hidden" name="formhash" id="formhash" value="7de8fa52" />
        <input type="hidden" name="issub" id="issub" value="0" />

        <ul class="round">
            <li class="title mb"><span class="none">请认真填写在线订单</span></li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>预订人</th>
                        <td>
                            <input name="oderName" type="text" class="px" id="oderName" value="" placeholder="请输入您的真实姓名"></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>联系电话</th>
                        <td>
                            <input name="tel" type="text" class="px" id="tel" value="" placeholder="请输入您的电话"></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>预定时间</th>
                        <td>
                            <input name="arriveTime" class="px datetimepicker" id="arriveTime" runat="server" value="" type="text" placeholder="预定时间">
                        </td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>离店时间</th>
                        <td>
                            <input name="leaveTime" class="px datetimepicker" id="leaveTime" runat="server" value="" type="text" placeholder="离店时间">
                        </td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>类型</th>
                        <td>
                            <input class="px" id="roomtype" value="<%=roomtype %>" type="text" readonly="true"></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>预订数量</th>
                        <td>
                            <select name="orderNum" class="dropdown-select" id="orderNum" onchange="dothis(this.value)">
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                                <option value="11">11</option>
                                <option value="12">12</option>
                                <option value="13">13</option>
                                <option value="14">14</option>
                                <option value="15">15</option>
                                <option value="16">16</option>
                                <option value="17">17</option>
                                <option value="18">18</option>
                                <option value="19">19</option>
                                <option value="20">20</option>
                            </select></td>
                    </tr>
                </table>
            </li>



            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>原价</th>
                        <td class="userinfo" id="yuanjia">￥<%=yuanjia %></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>现价</th>
                        <td class="userinfo price" id="price">￥<%=xianjia %></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>为你节省</th>
                        <td class="userinfo price2" id="price3">￥<%=price3 %></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th valign="top" class="thtop">备注</th>
                        <td>
                            <textarea name="remark" class="pxtextarea" style="height: 99px; overflow-y: visible" id="remark" placeholder="请输入备注信息"></textarea></td>
                    </tr>
                </table>
            </li>
        </ul>

        <div class="footReturn">
            <a id="showcard" class="submit">提交订单</a>
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">提交成功<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>

        </div>
        <input type="hidden" runat="server" id="roomtypenum" value="" />
        <input type="hidden" runat="server" id="roomidnum" value="" />
        <input type="hidden" runat="server" id="hotelidnum" value="" />
        <input type="hidden" runat="server" id="openidnum" value="" />

        <input type="hidden" runat="server" id="yuanjianum" value="" />
        <input type="hidden" runat="server" id="pricenum" value="" />
        <input type="hidden" runat="server" id="price3num" value="" />

        <script type="text/javascript">

            function dothis(nums) {

                var str1 = document.getElementById('yuanjianum').value * nums;
                var str2 = document.getElementById('pricenum').value * nums;
                var str3 = document.getElementById('price3num').value * nums;
                $("#yuanjia").text("￥" + str1);
                $("#price").text("￥" + str2);
                $("#price3").text("￥" + str3);
            }

            var oLay = document.getElementById("overlay");
            $(document).ready(function () {



                $('.datetimepicker').datetimepicker({
                    minView: "month", //选择日期后，不会再跳转去选择时分秒 
                    format: "yyyy-mm-dd", //选择日期后，文本框显示的日期格式 
                    language: 'zh-CN', //汉化 
                    autoclose: true //选择日期后自动关闭 
                });





                $("#showcard").click(function () {

                    if ($("#issub").val() == "1") {
                        alert('请勿重复提交！谢谢！');
                        return false;
                    }
                

                    if ($("#arriveTime").val() >= $("#leaveTime").val())
                    {
                        alert("离店时间不能小于入住时间！")
                        return false;
                       
                    }


                    if ($("#tel").val() == '') { alert('电话不能为空'); return; }
                    if ($("#oderName").val() == '') { alert('名字不能为空'); return; }
                    if ($("#arriveTime").val() == '') { alert('请选择时间'); return; }



                    var oderName = document.getElementById('oderName').value;
                    var tel = document.getElementById('tel').value;
                    var arriveTime = document.getElementById('arriveTime').value;
                    var leaveTime = document.getElementById('leaveTime').value;

                    var roomType = document.getElementById('roomtypenum').value;
                    var openid = document.getElementById('openidnum').value;
                    var roomid = document.getElementById('roomidnum').value;
                    var hotelid = document.getElementById('hotelidnum').value;

                    var orderNum = document.getElementById('orderNum').value;
                    var price = document.getElementById('pricenum').value;
                    var yuanjia = document.getElementById('yuanjianum').value;
                    var remark = document.getElementById('remark').value;


                    var submitData = {
                        oderName: oderName,
                        tel: tel,
                        arriveTime: arriveTime,
                        leaveTime: leaveTime,
                        orderNum: orderNum,
                        roomType: roomType,
                        openid: openid,
                        roomid: roomid,
                        hotelid: hotelid,
                        price: price,
                        yuanjia: yuanjia,
                        remark: remark,
                        myact: "dingdan"
                    };
                    $.post('hotel_info.ashx', submitData,
                     function (data) {
                         if (data.ret == "ok") {
                             alert(data.content);

                             window.location.href = "hotel_order.aspx?openid=<%=openid%>&hotelid=<%=hotelid%>&roomid=<%=roomid%>";

                 } else { alert(data.content); }
             },
                "json");

            oLay.style.display = "block";
        });
    });

     $("#windowclosebutton").click(function () {
         $("#windowcenter").slideUp(500);
         oLay.style.display = "none";

     });
     $("#alertclose").click(function () {
         $("#windowcenter").slideUp(500);
         oLay.style.display = "none";

     });

     function alert(title) {

         $("#windowcenter").slideToggle("slow");
         $("#txt").html(title);
         setTimeout('$("#windowcenter").slideUp(500)', 4000);
     }


     var count = $("#thelist img").size();
     $("#thelist img").css("width", document.body.clientWidth);
     $("#scroller").css("width", document.body.clientWidth * count);
     setInterval(function () {
         myScroll.scrollToPage('next', 0, 400, count);
     }, 3500);
     window.onresize = function () {

         $("#thelist img").css("width", document.body.clientWidth);
         $("#scroller").css("width", document.body.clientWidth * count);
     }

        </script>
    </div>
    <script src="index/js/plugback.js" type="text/javascript" type="text/javascript"></script>

    <div class="footermenu">
        <ul>
            <li>
                <a href="javascript:history.go(-1);">
                    <img src="images/9uKCykhUSh.png">
                    <p>返回</p>
                </a>
            </li>
            <li>
                <a href="index.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
                    <img src="images/3YQLfzfunJ.png">
                    <p>首页</p>
                </a>
            </li>
            <li>
                <a href="hotel_detail.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
                    <img src="images/xxyX63YryG.png">
                    <p>关于</p>
                </a>
            </li>
            <li>
                <a class="active" href="hotel_order.aspx?openid=<%=openid %>&hotelid=<%=hotelid%>">
                    <span class="num"><%=numdingdan %></span>
                    <img src="images/s22KaR0Wtc.png">
                    <p>订单</p>
                </a>
            </li>
        </ul>
    </div>
    <script type="text/javascript">
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            WeixinJSBridge.call('hideToolbar');
        });
    </script>

</body>
</html>

