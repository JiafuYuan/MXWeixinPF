<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yySeefloor.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.yySeefloor" %>
<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" type="text/css" href="css/online_booking.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/common2.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/datepicker_car.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/pig-ui.css" media="all">
    <link rel="stylesheet" type="text/css" href="css/common1.css" media="all">
    <script type="text/javascript" src="js/jQuery.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script type="text/javascript" src="js/bootstrap-datepicker.js"></script>
    <title></title>
    <style>
        img {
            width: 100%!important;
        }
    </style>
</head>
<body onselectstart="return true;" ondragstart="return false;" id="onlinebooking">
    <div class="qiandaobanner">
        <img src="<%=ysModel.headImg %>">
    </div>
    <div class="cardexplain">
        <!--普通用户登录时显示-->
        <ul class="round">
            <li>
                <a href="myYuyue.aspx?openid=<%=openid %>&wid=<%=wid %>&fid=<%=fid%>">
                    <span>我的预约订单<em class="ok"><%=dnum %></em></span>
                </a>
            </li>
        </ul>
        <!--后台可控制是否显示-->
        <ul class="round">
            <li>
                <h2>预约说明</h2>
                <div class="text"><%=ysModel.detail %></div>
            </li>
        </ul>

        <!--后台可控制是否显示-->
        <ul class="round">
            <li class="addr"><a href="javascript:void(0)"><span>地址：<%=ysModel.address %> </span></a></li>
            <li class="tel"><a href="tel:"><span>预约电话：<%=ysModel.telephone %> </span></a></li>
        </ul>

        <ul class="round roundyellow">
            <li class="userinfo"><a href="javascript:void(0)"><span>请完善个人资料再填表单</span></a></li>
        </ul>

        <!--粉丝填写过的信息的，直接就显示名字电话，粉丝没有填写过信息的话，这里就直接留空让粉丝填写-->
        <ul class="round">
            <form action="javascript:;" method="post">
                <li class="title mb"><span class="none">请认真填写表单</span></li>
                <li class="nob">
                    <input name="formhash" id="formhash" value="ertyuio34567hh" type="hidden">
                    <input name="__formtoken__" id="__formtoken__" type="hidden" value="">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th>联系人</th>
                                <td>
                                    <input name="truename" class="px" id="truename" value="<%=yiModel.name %>" placeholder="请输入您的真实姓名" type="text"></td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th>联系电话</th>
                                <td>
                                    <input name="tel" class="px" id="tel" value="<%=yiModel.telephone%>" placeholder="请输入您的电话" type="tel"></td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th>预约日期</th>
                                <td>
                                    <input type="text" class="px hasDatepicker" name="dateline" placeholder="" value="<%=yiModel.yydate!=null?MyCommFun.Obj2DateTime(yiModel.yydate).ToString("yyyy-MM-dd"):""%>" readonly="readonly" id="dateline">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th>预约时间</th>
                                <td>
                                    <select name="timepart" id="timepart" class="dropdown-select">
                                        <option value="0:00-1:00">0:00-1:00</option>
                                        <option value="1:00-2:00">1:00-2:00</option>
                                        <option value="2:00-3:00">2:00-3:00</option>
                                        <option value="3:00-4:00">3:00-4:00</option>
                                        <option value="4:00-5:00">4:00-5:00</option>
                                        <option value="5:00-6:00">5:00-6:00</option>
                                        <option value="6:00-7:00">6:00-7:00</option>
                                        <option value="7:00-8:00">7:00-8:00</option>
                                        <option value="8:00-9:00" selected="">8:00-9:00</option>
                                        <option value="9:00-10:00">9:00-10:00</option>
                                        <option value="10:00-11:00">10:00-11:00</option>
                                        <option value="11:00-12:00">11:00-12:00</option>
                                        <option value="12:00-13:00">12:00-13:00</option>
                                        <option value="13:00-14:00">13:00-14:00</option>
                                        <option value="14:00-15:00">14:00-15:00</option>
                                        <option value="15:00-16:00">15:00-16:00</option>
                                        <option value="16:00-17:00">16:00-17:00</option>
                                        <option value="17:00-18:00">17:00-18:00</option>
                                        <option value="18:00-19:00">18:00-19:00</option>
                                        <option value="19:00-20:00">19:00-20:00</option>
                                        <option value="20:00-21:00">20:00-21:00</option>
                                        <option value="21:00-22:00">21:00-22:00</option>
                                        <option value="22:00-23:00">22:00-23:00</option>
                                        <option value="23:00-24:00">23:00-24:00</option>
                                    </select>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th>选择看房户型</th>
                                <td>
                                    <select name="housetype" id="housetype" class="download dropdown-select">
                                        <asp:Repeater ID="rptHx" runat="server">
                                            <ItemTemplate>
                                                <option value="<%#Eval("id") %>"><%#Eval("name") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>
                <li class="nob">
                    <table class="kuang" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr>
                                <th class="thtop" valign="top">备注</th>
                                <td>
                                    <textarea name="info" class="pxtextarea" style="height: 99px; overflow-y: visible" id="info" placeholder="请输入备注信息"><%=yiModel.remark %></textarea>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li> 
            </form>
        </ul>
        <div class="footReturn">
            <input id="showcard" class="submit" value="提交消息" type="button">
            <div class="window" id="windowcenter">
                <div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="txt"></div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        $(document).ready(function () {
            //当修改订单时
            $("#timepart").val("<%=yiModel.yydatepart%>");
            $("#housetype").val("<%=yiModel.hid%>");

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);
            var ndate = $('#dateline').datepicker({
                format: "yyyy-mm-dd",
                onRender: function (date) {
                    return date.valueOf() < now.valueOf() ? 'disabled' : '';
                }
            }).on("changeDate", function (date) {
                ndate.datepicker('hide');
            });
            $("#showcard").click(function () {
                var ret_single = ret_download = tel_num = housetype = '';
                $(".single").each(function (i) {
                    var s_name = $(this).parent().siblings().text();
                    var s_value = $(this).val();
                    if ('' != s_value) ret_single += '$' + s_name + '#' + s_value;
                });
                $(".download").each(function (i) {
                    var s_name = $(this).parent().siblings().text();
                    var s_value = $(this).val();
                    if ('' != s_value) ret_download += s_value;
                });
                tel_num = $("#tel").val();
                if ('undefined' !== typeof (tel_num)) {
                    if (tel_num == '') {
                        alert('电话不能为空');
                        return;
                    }
                    if (tel_num.length < 11) {
                        alert('请输入正确的电话');
                        return;
                    }
                }
                if ($("#truename").val() == '') { alert('名字不能为空'); return; }
                var submitData = {
                    truename: $("#truename").val(),
                    dateline: $("#dateline").val(),
                    timepart: $("#timepart").val(),
                    housetype: $("#housetype").val(),
                    info: $("#info").val(),
                    tel: $("#tel").val(),
                    openid: '<%=openid%>',
                    wid:<%=wid%>,
                    addOrEdit:<%=addOrEdit%>,
                    fid:<%=fid%>
                };
                if ('fromUsername' == submitData.wecha_id) submitData.wecha_id = '';
                $.post("cldata.ashx?myact=addyydd", submitData, function (data) {
                    if (data.errno == '0') {
                        window.location.href = "myYuyue.aspx?openid=<%=openid %>&wid=<%=wid %>&fid=<%=fid %>";
                        return;
                    } else {
                        alert(data.content);
                    }
                })
            });
        });


        $("#windowclosebutton").click(function () {
            $("#windowcenter").slideUp(500);
        });
        $("#alertclose").click(function () {
            $("#windowcenter").slideUp(500);
        });
        function jumpurl(url) {
            window.location.href = "myYuyue.aspx?openid=<%=openid %>&wid=<%=wid %>&fid=<%=ysModel.Id %>";
        }
        function alert(title) {

            $("#windowcenter").slideToggle("slow");
            $("#txt").html(title);
            setTimeout('$("#windowcenter").slideUp(1000)', 4000);
        }
    </script>
    <p>
        <br />
    </p>
    <div mark="stat_code" style="width: 0px; height: 0px; display: none;">
    </div>
    <div id="ui-datepicker-div" class="ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all"></div>
</body>
</html>
