<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paypage.aspx.cs" Inherits="MxWeiXinPF.Web.api.payment.paypage" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>微支付</title>
    <meta http-equiv="Content-type" content="text/html; charset=GBK">
    <meta content="application/xhtml+xml;charset=GBK" http-equiv="Content-Type">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery.query.js"></script>
    <script type="text/javascript">

        function auto_remove(img) {
            div = img.parentNode.parentNode; div.parentNode.removeChild(div);
            img.onerror = "";
            return true;
        }
        function changefont(fontsize) {
            if (fontsize < 1 || fontsize > 4) return;
            $('#content').removeClass().addClass('fontSize' + fontsize);
        }

        // 当微信内置浏览器完成内部初始化后会触发WeixinJSBridgeReady事件。
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //公众号支付
            jQuery('a#getBrandWCPayRequest').click(function (e) {
                WeixinJSBridge.invoke('getBrandWCPayRequest', {
                   <%=packageValue%>
                }, function (res) {

                   // newurl = "/api/payment/wxpay/payResult.aspx?wid=" + <%=wid%> + "&otid=" +<%=otid_str%> + "&openid=" + <%=openid%>+"";
                    
                if (res.err_msg == "get_brand_wcpay_request:ok") {
                   
                 //   window.location.href = "http://www.baidu.com";

                }else
                {
                   // alert("false");
                    return false;
                }
                // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
            });

        });

        WeixinJSBridge.log('yo~ ready.');

        }, false);

        if (jQuery) {
            jQuery(function () {

                var width = jQuery('body').width() * 0.87;
                jQuery('img').error(function () {
                    var self = jQuery(this);
                    var org = self.attr('data-original1');
                    self.attr("src", org);
                    self.error(function () {
                        auto_remove(this);
                    });
                });
                jQuery('img').each(function () {
                    var self = jQuery(this);
                    var w = self.css('width');
                    var h = self.css('height');
                    w = w.replace('px', '');
                    h = h.replace('px', '');
                    if (w <= width) {
                        return;
                    }
                    var new_w = width;
                    var new_h = Math.round(h * width / w);
                    self.css({ 'width': new_w + 'px', 'height': new_h + 'px' });
                    self.parents('div.pic').css({ 'width': new_w + 'px', 'height': new_h + 'px' });
                });
            });
        }



    </script>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
            -webkit-box-sizing: border-box;
        }

        .body {
            text-align: center;
            width: 100%;
            padding: 60px 20px;
        }

            .body .ordernum {
                font-size: 14px;
                line-height: 30px;
            }

            .body .money {
                font-size: 20px;
                font-weight: bold;
                line-height: 60px;
            }

            .body .time {
                font-size: 16px;
                font-weight: bold;
                line-height: 30px;
            }

            .body .btn {
                display: block;
                background: #25a52e;
                text-decoration: none;
                border-radius: 2px;
                color: #fff;
                height: 44px;
                line-height: 44px;
                font-size: 18px;
                margin-top: 20px;
            }
    </style>
</head>
<body>
    <section class="body">
        <div class="ordernum">订单号：<asp:Literal ID="litout_trade_no" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="money">共计金额￥<asp:Literal ID="litMoney" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="time">下单时间：<asp:Literal ID="litDate" runat="server" EnableViewState="false"></asp:Literal></div>
        <div class="paytype" style="display: none;">支付方式：微信支付</div>
        <a href="javascript:void(0);" class="btn" id="getBrandWCPayRequest">确认支付</a>
      
     </section>

</body>

</html>

