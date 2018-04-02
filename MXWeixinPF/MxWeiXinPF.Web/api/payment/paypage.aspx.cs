using MxWeiXinPF.API.Payment.wxpay;
using MxWeiXinPF.Common;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MxWeiXinPF.Web.api.payment
{
    public partial class paypage : System.Web.UI.Page
    {

        public String packageValue = "";
        protected int wid = 0;
        protected string openid = "";
        protected string otid_str = "";
        protected string rpage = "";
        /// <summary>
        /// 订单付款的有效持续时间（单位为分）
        /// </summary>
        protected int expireMinute = 0;
        BLL.wx_logs logBll = new BLL.wx_logs();

        protected void Page_Load(object sender, EventArgs e)
        {



            try
            {
                wid = MyCommFun.RequestInt("wid");
                //授权
                BLL.wx_userweixin bll = new BLL.wx_userweixin();
                Model.wx_userweixin wxModel = bll.GetModel(wid);


                string code = MyCommFun.QueryString("code");
                if (code == null || code.Trim() == "")
                {
                    //logBll.AddLog("【微支付】微信预定", "paypage.aspx Page_Load", "code==null code.trim==kong", 1);

                    // openid = MyCommFun.RequestOpenid();
                    string thisUrl = MyCommFun.getTotalUrl();

                    string newUrl = OAuth.GetAuthorizeUrl(wxModel.AppId, thisUrl, "fukuan", OAuthScope.snsapi_base);

                    Response.Redirect(newUrl);
                }
                else
                {

                    var result = OAuth.GetAccessToken(wxModel.AppId, wxModel.AppSecret, code);
                    openid = result.openid;

                }
                //授权结束
                // logBll.AddLog("【微支付】微信预定", "paypage.aspx Page_Load", " 授权结束openid= " + openid, 1);
                int otid = MyCommFun.RequestInt("orderid");
                otid_str = otid.ToString();
                expireMinute = MyCommFun.RequestInt("expireminute");
                if (expireMinute == 0)
                {
                    expireMinute = 30;
                }
                else if (expireMinute == -1)
                {  //如果为-1，则有限期间为1年
                    expireMinute = 60 * 12 * 365;
                }
                if (openid == "" || otid == 0 || wid == 0)
                {
                    return;
                }


                BLL.orders otBll = new BLL.orders();
                Model.orders orderEntity = otBll.GetModel(otid, wid);
                logBll.AddLog("【微支付】微信预定", "paypage.aspx Page_Load", "orderEntity.order_no: " + orderEntity.order_no + "|orderEntity.order_amount:" + orderEntity.order_amount, 1);
                litout_trade_no.Text = orderEntity.order_no;
                litMoney.Text = orderEntity.order_amount.ToString();
                litDate.Text = orderEntity.add_time.ToString();


                //WxPayData(orderEntity.order_amount, orderEntity.id.ToString(), orderEntity.order_no, code);//老的接口
                WxPayDataV3(orderEntity.order_amount, orderEntity.id.ToString(), orderEntity.order_no, code);
            }
            catch (Exception ex)
            {
                logBll.AddLog("【微支付】微信预定", "paypage.aspx Page_Load", "ex: " + ex.Message, 1);
                MessageBox.ShowAndRedirect(this, "支付有问题："+ex.Message,"/shop/index.aspx?wid="+wid);
            }
        }

        /// <summary>
        /// 最新接口调用
        /// 2014-11-24
        /// </summary>
        /// <param name="ttFee">支付金额（单位元）</param>
        /// <param name="busiBody">订单内容</param>
        /// <param name="out_trade_no">订单号</param>
        /// <param name="code"></param>
        protected void WxPayDataV3(decimal ttFee, string busiBody, string out_trade_no, string code)
        {

            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            BLL.wx_userweixin uwBll = new BLL.wx_userweixin();
            Model.wx_userweixin uwEntity = uwBll.GetModel(wid);

            // logBll.AddLog(wid,"【微支付】微信预定", "paypage.aspx WxPayDataV3", "211 wid:" + wid, 1);

            //先设置基本信息
            string MchId = paymentInfo.partnerId; // "1218574001";//  

            string partnerKey = paymentInfo.partnerKey;// 商户支付密钥Key。登录微信商户后台，进入栏目【账户设置】【密码安全】【API 安全】【API 密钥】

            string notify_url = "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx";

            logBll.AddLog(wid, "【微支付】微信预定", "paypage.aspx WxPayDataV3", "uwEntity.AppId: " + uwEntity.AppId + "| uwEntity.AppSecret;" + uwEntity.AppSecret + "|code:" + code, 1);


            string timeStamp = "";
            string nonceStr = "";
            string paySign = "";

            string sp_billno = out_trade_no;
            //当前时间 yyyyMMdd
            string date = DateTime.Now.ToString("yyyyMMdd");

            if (null == sp_billno)
            {
                //生成订单10位序列号，此处用时间和随机数生成，商户根据自己调整，保证唯一
                sp_billno = DateTime.Now.ToString("HHmmss") + TenPayUtil.BuildRandomStr(28);
            }


            //创建支付应答对象
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler packageReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            //初始化

            //packageReqHandler.SetKey(""/*TenPayV3Info.Key*/);

            timeStamp = TenPayUtil.GetTimestamp();
            nonceStr = TenPayUtil.GetNoncestr();

            //设置package订单参数
            packageReqHandler.SetParameter("appid", uwEntity.AppId);		  //公众账号ID
            packageReqHandler.SetParameter("mch_id", MchId);		  //商户号
            packageReqHandler.SetParameter("nonce_str", nonceStr);                    //随机字符串
            packageReqHandler.SetParameter("body", busiBody);  //商品描述
            packageReqHandler.SetParameter("attach", wid + "|" + busiBody);
            packageReqHandler.SetParameter("out_trade_no", sp_billno);		//商家订单号
            packageReqHandler.SetParameter("total_fee", ((int)(ttFee * 100)).ToString());			        //商品金额,以分为单位(money * 100).ToString()
            packageReqHandler.SetParameter("spbill_create_ip", Request.UserHostAddress);   //用户的公网ip，不是商户服务器IP
            packageReqHandler.SetParameter("notify_url", notify_url);		    //接收财付通通知的URL
            packageReqHandler.SetParameter("trade_type", TenPayV3Type.JSAPI.ToString());//交易类型
            packageReqHandler.SetParameter("openid", openid);	                    //用户的openId

            string sign = packageReqHandler.CreateMd5Sign("key", partnerKey);
            packageReqHandler.SetParameter("sign", sign);	                    //签名

            string data = packageReqHandler.ParseXML();

            var result = TenPayV3.Unifiedorder(data);
            var res = XDocument.Parse(result);
            string prepayId = res.Element("xml").Element("prepay_id").Value;



            //设置支付参数
            Senparc.Weixin.MP.TenPayLibV3.RequestHandler paySignReqHandler = new Senparc.Weixin.MP.TenPayLibV3.RequestHandler(null);
            paySignReqHandler.SetParameter("appId", uwEntity.AppId);
            paySignReqHandler.SetParameter("timeStamp", timeStamp);
            paySignReqHandler.SetParameter("nonceStr", nonceStr);
            paySignReqHandler.SetParameter("package", string.Format("prepay_id={0}", prepayId));
            paySignReqHandler.SetParameter("signType", "MD5");
            paySign = paySignReqHandler.CreateMd5Sign("key", partnerKey);

            packageValue = "";
            packageValue += " \"appId\": \"" + uwEntity.AppId + "\", ";
            packageValue += " \"timeStamp\": \"" + timeStamp + "\", ";
            packageValue += " \"nonceStr\": \"" + nonceStr + "\", ";
            packageValue += " \"package\": \"" + string.Format("prepay_id={0}", prepayId) + "\", ";
            packageValue += " \"signType\": \"MD5\", ";
            packageValue += " \"paySign\": \"" + paySign + "\"";


        }

        /// <summary>
        /// 微信支付：生成请求数据
        /// </summary>
        /// <param name="openid">微信用户id</openid>
        /// <param name="ttFee">商品总价格</param>
        /// <param name="busiBody"></param>
        /// <returns></returns>
        protected void WxPayData(decimal ttFee, string busiBody, string out_trade_no, string code)
        {
            WxPayHelper wxPayHelper = new WxPayHelper();
            BLL.wx_payment_wxpay wxPayBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = wxPayBll.GetModelByWid(wid);

            //先设置基本信息
            string partnerId = paymentInfo.partnerId;// "1218574001";//  
            string appId = paymentInfo.appId;// "wxa9b8e33e48ac5e0f";// 
            string partnerKey = paymentInfo.partnerKey;// "huyuxianghuyuxianghuyuxiang12345";//  
            //paysignkey(非appkey) 
            string appKey = paymentInfo.paySignKey; //"nwRmqgvSG08pe3vU5qzBLb7Bvih0WOABGzUPvqgFqE0iSkJlJ8wh7JlLYy2cXFgFA3v1bM8eTDm1y1UcyeW9IGq2py2qei7J5xDoVR9lfO3cS6fMjFbMQeeqBRit0bKp";// 

            wxPayHelper.SetAppId(appId);
            wxPayHelper.SetAppKey(appKey);
            wxPayHelper.SetPartnerKey(partnerKey);
            wxPayHelper.SetSignType("SHA1");
            //设置请求package信息
            wxPayHelper.SetParameter("bank_type", "WX");
            wxPayHelper.SetParameter("body", busiBody);
            wxPayHelper.SetParameter("attach", wid + "|" + busiBody);
            wxPayHelper.SetParameter("partner", partnerId);
            wxPayHelper.SetParameter("out_trade_no", out_trade_no);
            wxPayHelper.SetParameter("total_fee", ((int)(ttFee * 100)).ToString());
            wxPayHelper.SetParameter("fee_type", "1");
            // wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx?wid="+wid);

            wxPayHelper.SetParameter("notify_url", "http://" + HttpContext.Current.Request.Url.Authority + "/api/payment/wxpay/notify_url.aspx");//不能带参数
            wxPayHelper.SetParameter("spbill_create_ip", MXRequest.GetIP());
            wxPayHelper.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //---------有效期截至日期------

            wxPayHelper.SetParameter("time_expire", DateTime.Now.AddMinutes(expireMinute).ToString("yyyyMMddHHmmss"));

            wxPayHelper.SetParameter("input_charset", "UTF-8");
            packageValue = wxPayHelper.CreateBizPackage();


        }

    }
}