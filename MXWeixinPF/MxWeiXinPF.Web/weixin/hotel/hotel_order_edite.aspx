<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_order_edite.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.hotel.hotel_order_edite" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>在线预订未处理</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/hotels.css" rel="stylesheet" type="text/css">
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js" type="text/javascript"></script>

    <link href="../../scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/bootstrap/datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />

    <link href="css/mystyle.css" rel="stylesheet" type="text/css">

    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
      <script type="text/javascript" src="../../scripts/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"></script>

</head>

<body id="hotelsno" class="mode_webapp">
    <div class="qiandaobanner"><a href="index.aspx">
        <img src="<%=image %>" /></a> </div>
    <div class="cardexplain">
        <ul class="round">
            <li class="title mb"><span class="none"><%=createtime %>订单详情<%=zhuangtai %></span></li>
            <li class="nob">
                <div class="beizhu">此订单可重新修改后再提交！</div>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>预订人</th>
                        <td>
                            <input name="truename" type="text" class="px" id="truename" runat="server" value="123" placeholder="请输入您的真实姓名"></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>联系电话</th>
                        <td>
                            <input name="tel" class="px" id="tel" value="12345678999" runat="server" type="text" placeholder="请输入您的电话"></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>入住时间</th>
                        <td>
                            <input name="dateline" class="px datetimepicker" runat="server" id="dateline" value="" type="text" placeholder="入住时间">
                        </td>
                    </tr>
                </table>
            </li>

            <input type="hidden" name="formhash" id="formhash" value="77ee642e" />
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>类型</th>
                        <td><%=roomtype %></td>
                    </tr>
                </table>
            </li>

            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>预订数量</th>
                        <td>
                            <select name="nums" class="dropdown-select" id="nums" runat="server" onchange="dothis(this.value)">
                                <option value="1">1间</option>
                                <option value="2">2间</option>
                                <option value="3">3间</option>
                                <option value="4">4间</option>
                                <option value="5">5间</option>
                                <option value="6">6间</option>
                                <option value="7">7间</option>
                                <option value="8">8间</option>
                                <option value="9">9间</option>
                                <option value="10">10间</option>
                                <option value="11">11间</option>
                                <option value="12">12间</option>
                                <option value="13">13间</option>
                                <option value="14">14间</option>
                                <option value="15">15间</option>
                                <option value="16">16间</option>
                                <option value="17">17间</option>
                                <option value="18">18间</option>
                                <option value="19">19间</option>
                                <option value="20">20间</option>
                            </select></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>原价</th>
                        <td class="userinfo" id="price1">￥<%=yuanjia %></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>现价</th>
                        <td class="userinfo price" id="price2">￥<%=price %></td>
                    </tr>
                </table>
            </li>
            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th>为你节省</th>
                        <td class="userinfo price2" id="price3">￥<%=jiesheng %></td>
                    </tr>
                </table>
            </li>


            <li class="nob">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                    <tr>
                        <th valign="top" class="thtop">备注</th>
                        <td>
                            <textarea name="info" class="pxtextarea" style="height: 99px; overflow-y: visible" id="info" runat="server" placeholder="请输入备注信息">4534</textarea></td>
                    </tr>
                </table>
            </li>
        </ul>

        <div class="footReturn">
            <ul>
                <li class="footerbtn"><a id="showcard2" class="del right3">删除订单</a></li>
                <li class="footerbtn"><a id="showcard" class="submit left3">提交订单</a></li>
            </ul>
            <div class="clr"></div>
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">操作成功<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>
        </div>



        <input type="hidden" runat="server" id="roomidnum" value="" />
        <input type="hidden" runat="server" id="hotelidnum" value="" />
        <input type="hidden" runat="server" id="openidnum" value="" />
        <input type="hidden" runat="server" id="dingdanidnum" value="" />

        <input type="hidden" runat="server" id="yuanjianum" value="" />
        <input type="hidden" runat="server" id="xianjianum" value="" />
        <input type="hidden" runat="server" id="jsnum" value="" />
        <script type="text/javascript">
            function dothis(nums) {

                var str1 = document.getElementById('yuanjianum').value * nums;
                var str2 = document.getElementById('xianjianum').value * nums;
                var str3 = document.getElementById('jsnum').value * nums;
                $("#price1").text("￥" + str1);
                $("#price2").text("￥" + str2);
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





                    var truename = document.getElementById('truename').value;
                    var tel = document.getElementById('tel').value;
                    var dateline = document.getElementById('dateline').value;
                    //var leaveTime = document.getElementById('leaveTime').value;

                    //var roomType = document.getElementById('roomtypenum').value;
                    var openid = document.getElementById('openidnum').value;
                    var roomid = document.getElementById('roomidnum').value;
                    var hotelid = document.getElementById('hotelidnum').value;

                    var nums = document.getElementById('nums').value;
                    var xianjianum = document.getElementById('xianjianum').value;
                    var yuanjianum = document.getElementById('yuanjianum').value;
                    var dingdanidnum = document.getElementById('dingdanidnum').value;
                    var info = document.getElementById('info').value;


                    var submitData = {
                        truename: truename,
                        tel: tel,
                        dateline: dateline,
                        openid: openid,
                        roomid: roomid,
                        hotelid: hotelid,
                        nums: nums,
                        xianjianum: xianjianum,
                        yuanjianum: yuanjianum,
                        info: info,
                        dingdanidnum: dingdanidnum,
                        myact: "dingdanedite"
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




        $("#showcard2").click(function () {


            var dingdanidnum = document.getElementById('dingdanidnum').value;



            var submitData = {

                dingdanidnum: dingdanidnum,
                myact: "dingdandelete"
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



</body>
</html>
