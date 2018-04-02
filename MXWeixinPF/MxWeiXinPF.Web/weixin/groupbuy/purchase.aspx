<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchase.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.groupbuy.purchase" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>仅售45元，价值56元浪沙牛排套餐1份！</title>
    <link rel="stylesheet" type="text/css" href="css/Groupbuying(for_gb).css" media="all">
    <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <script src="../../scripts/jquery/alert.js"></script>
</head>

<body class="sanckbg">
    <div class="menu_header">
        <div class="menu_topbar"><span class="head-title">提交订单</span> <span class="head_btn_left"><a href="javascript:history.go(-1);">返回</a></span> <a class="head_btn_right" href="index.aspx"><i class="menu_header_home"></i></a></div>
    </div>
    <form runat="server">
        <input type="hidden" name="formhash" id="formhash" value="d19d9492" />
        <input type="hidden" name="oldBc" id="oldBc" value="<%=customerNum %>" />
        <div id="order_add" class="car2" style="">
            <h2 class="title">订单信息</h2>
            <ul class="biao3">
                <li>
                    <p class="pl">商品名称：</p>
                    <p class="pr"><%=huodname %></p>
                </li>
                <li>
                    <p class="pl">商品单价：</p>
                    <p class="pr F_red">￥<%=tuangj %></p>
                </li>
                <li>
                    <p class="pl">数量</p>
                    <p class="pr">
                        <input id="customerNum" name="nums" onchange="ckit(this)" type="number" htip="输入产品数量" errtip="输入产品数量" class="px" tag="input" maxlength="11" value="<%=customerNum %>">
                    </p>
                </li>
            </ul>
        </div>
        <div class="tishi">本团购每人限购 <span class="F_red"><%=limitCount %></span> 件,你已经团购 <span class="F_red"><%=yg %></span> 件</div>

        <h2 class="fhdtl_h m15">详细信息</h2>
        <div class="fhdtl_c">
            <ul class="biao2">
                <li id="sndiv" runat="server" visible="false">
                    <strong>SN码:</strong>
                    <input id="sn" name="info" runat="server" htip="sn码" errtip="输入sn码" class="px" value="" />
                </li>
                <li>
                    <p class="pl">姓名</p>
                    <p class="pr">
                        <input id="customerName" runat="server" name="name" type="text" htip="请输入正确的姓名，2~8个汉字" errtip="请输入正确的姓名，2~8个汉字" class="px" tag="input" value="">
                    </p>
                </li>
                <li>
                    <p class="pl">手机</p>
                    <p class="pr">
                        <input id="tel" runat="server" name="tel" htip="请输入正确的手机号码" errtip="请输入正确的手机号码" class="px" tag="input" maxlength="11" value="">
                    </p>
                </li>

                <li>
                    <p class="pl">地址</p>
                    <p class="pr">
                        <input id="address" name="address" runat="server" htip="输入你的地址" errtip="输入你的地址" class="px" tag="input" value="">
                    </p>
                </li>
                <li>
                    <p class="pl">备注</p>
                    <p class="pr">
                        <input id="Remark" runat="server" name="info" htip="备注" errtip="输入备注信息" class="px" tag="input" value="">
                    </p>
                </li>
                <li id="pwddiv" runat="server" visible="false"><strong>消费密码:</strong><input id="shopsPwd" name="shopsPwd" runat="server" htip="消费密码" errtip="输入消费密码" class="px" tag="input" value="" /></li>
            </ul>
        </div>
        <script>
            function ckit(obj) {
                if (obj.value > 200 && 200 != 0) {
                    alert('超过了允许的值');
                    obj.value = 200;
                }

            }
        </script>
        <div class="footReturn">
            <ul>
                <li class="footerbtn"><a id="showcard2" class="return right3" href="index.php?ac=Groupbuying-index&amp;id=650&amp;tid=2443&amp;c=oyV8_t_hHNmbH6Kc3yJPtYhIjGU4">返回</a></li>
                <li class="footerbtn">
                    <input type="button" value="提交" id="BtnOrder" class="submit" style="width: 100%">
                </li>
                <div class="clr"></div>
            </ul>
        </div>
        <asp:HiddenField ID="limit" Value="" runat="server" />
        <asp:HiddenField ID="limitCount1" Value="" runat="server" />
        <asp:HiddenField ID="totalCount1" Value="" runat="server" />
        <asp:HiddenField ID="count1" Value="" runat="server" />
    </form>
    <section id="tipMessage" class="Fh_qdown_apv box-shadow" style="display: none; z-index: 10000;">
        <p class="F_red F_font">请输入正确的姓名，2~8个汉字</p>
        <span class="F_grey2">--微团购--</span>
    </section>

</body>
</html>
<script>

    $(document).ready(function () {
        $("#showcard2").click(function () {
            var wid = $.query.get("wid");
            var aid = $.query.get("aid");
            window.location.href = "index.aspx?wid=" + wid + "&aid=" + aid;
        })
        $("#BtnOrder").click(function () {
            //if ($("#limit").val() == "0" )
            //{
            //    alert("超过抢购数量！");
            //    return;
            //}

            var wid = $.query.get("wid");
            var openid = $.query.get("openid");
            var aid = $.query.get("aid");

            var customerName = $("#customerName").val();
            var tel = $("#tel").val();
            var customerNum = $("#customerNum").val();
            var address = $("#address").val();
            var shopsPwd = $("#shopsPwd").val();
            //var sn = $("#sn").val();
            var Remark = $("#Remark").val();
            var oldNum = $("#oldBc").val();

            var submitData = {
                wid: wid,
                openid: openid,
                baseid: aid,
                customerName: customerName,
                tel: tel,
                customerNum: customerNum,
                oldNum: oldNum,
                address: address,
                shopsPwd: shopsPwd,
                Remark: Remark,
                myact: "commit"
            };
            $.post('groupbuying.ashx', submitData,
         function (data) {
             if (data.ret == "ok") {
                 alert(data.content);
                 window.location.href = "index.aspx?wid=" + wid + "&aid=" + aid + "&openid=" + openid + "";
             } else {
                 alert(data.content);
             }
         },"json")

        });
    });
</script>

<script>
    function ckit(obj) {
        var limitCount = $("#limitCount1").val();
        var totalCount = $("#totalCount1").val();
        var count = $("#count1").val();
        if (obj.value > limitCount && totalCount != "" && count != "") {

            if (limitCount > count) {
                alert('商品还剩' + 0 + '件！');
                obj.value = count;
            }
            else {
                alert('超过了允许的值！');
                obj.value = limitCount;
            }
        }

        if (obj.value <= 0) {
            alert('商品数不能为0！');
            obj.value = 1;
        }
    }

</script>
