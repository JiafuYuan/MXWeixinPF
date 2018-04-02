
using MxWeiXinPF.BLL;
using MxWeiXinPF.Common;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace MxWeiXinPF.Web.api.payment.wxpay
{
    public partial class notify_url : System.Web.UI.Page
    {
        /* 
         req:<xml>
  <appid><![CDATA[wxd745017dc584cdc9]]></appid>
  <attach><![CDATA[5|160]]></attach>
  <bank_type><![CDATA[CCB_DEBIT]]></bank_type>
  <fee_type><![CDATA[CNY]]></fee_type>
  <is_subscribe><![CDATA[Y]]></is_subscribe>
  <mch_id><![CDATA[10011937]]></mch_id>
  <nonce_str><![CDATA[9C82C7143C102B71C593D98D96093FDE]]></nonce_str>
  <openid><![CDATA[o305WuBqoBjW2VYcF9KJjyxoTRXQ]]></openid>
  <out_trade_no><![CDATA[b14112403325816]]></out_trade_no>
  <result_code><![CDATA[SUCCESS]]></result_code>
  <return_code><![CDATA[SUCCESS]]></return_code>
  <sign><![CDATA[3C546ED181C1F56900C1112C871A399B]]></sign>
  <sub_mch_id><![CDATA[10011937]]></sub_mch_id>
  <time_end><![CDATA[20141124033307]]></time_end>
  <total_fee>10</total_fee>
  <trade_type><![CDATA[JSAPI]]></trade_type>
  <transaction_id><![CDATA[1003530289201411240006160848]]></transaction_id>
</xml>
         */
        BLL.wx_logs logBll = new BLL.wx_logs();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessNotify();
            }
            catch (Exception ex)
            {
                WriteContent("fail", "订单处理报异常catch_1");
                logBll.AddLog("【微支付】微信预定", "notify_url Page_Load", "业务结果处理错误:"+ex.Message, 0);
            }
        }

       /// <summary>
       /// 处理回调的页面
       /// </summary>
        private void ProcessNotify()
        {
            //int wid = MyCommFun.RequestWid();
            int wid = 0;

            logBll.AddLog("【微支付】微信预定", "notify_url ProcessNotify", "从微支付返回到notify_url.aspx页面", 1);

            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string req = System.Text.Encoding.Default.GetString(byts);
            req = Server.UrlDecode(req);
            logBll.AddLog("【微支付】微信预定", "notify_url ProcessNotify", "req:" + req, 1);

            //返回的状态码
            string return_code = ReadXmlValue(req, "xml/return_code");

            logBll.AddLog("【微支付】微信预定", "notify_url ProcessNotify", "返回的状态码return_code：" + return_code, 1);

            if (return_code.Trim().ToLower() == "fail")
            {
                string return_msg = ReadXmlValue(req, "xml/return_msg");
                logBll.AddLog("【微支付】微信预定", "notify_url ProcessNotify", "订单处理错误：" + return_msg, 0);
                WriteContent("fail", "订单处理错误:" + return_msg);
                return;
            }


            string attach = ReadXmlValue(req, "xml/attach");
            string[] attachArr = attach.Split('|');
            wid = MyCommFun.Str2Int(attachArr[0]);
            int otid = MyCommFun.Str2Int(attachArr[1]);

            BLL.wx_payment_wxpay payBll = new BLL.wx_payment_wxpay();
            Model.wx_payment_wxpay paymentInfo = payBll.GetModelByWid(wid);
            logBll.AddLog(wid, "【微支付】微信预定", "notify_url ProcessNotify", "取到wid=" + wid, 1);



            string appId = ReadXmlValue(req, "xml/appid"); //公众账号id
            string mchId = ReadXmlValue(req, "xml/mch_id");//商户号

            string result_code = ReadXmlValue(req, "xml/result_code"); //业务结果
            if (result_code.Trim().ToLower() == "fail")
            {
                //支付失败
                string err_code = ReadXmlValue(req, "xml/err_code");
                string err_code_des = ReadXmlValue(req, "xml/err_code_des");
                logBll.AddLog(wid,"【微支付】微信预定", "notify_url ProcessNotify", "业务结果处理错误err_code：" + err_code + "[err_code_des]:" + err_code_des, 0);
                WriteContent("fail", "业务结果处理错误err_code：" + err_code + "[err_code_des]:" + err_code_des);
                return;
            }
            //支付成功
            string openid = ReadXmlValue(req, "xml/openid");
            //金额,以分为单位
            string total_fee = ReadXmlValue(req, "xml/total_fee");

            string out_trade_no = ReadXmlValue(req, "xml/out_trade_no");

            string transaction_id = ReadXmlValue(req, "xml/transaction_id");

            logBll.AddLog(wid, "【微支付】微信预定", "notify_url ProcessNotify", "支付成功了:openid=" + openid + " out_trade_no=" + out_trade_no + " transaction_id=" + transaction_id + " total_fee（分）=" + total_fee + " result_code=" + result_code + " orderid=" + otid + " wid=" + wid, 1);
            //------------------------------
            //处理业务开始
            //处理数据库逻辑
            //注意交易单不要重复处理
            //注意判断返回金额
            //------------------------------
            wxOrderTmpMgr Totbll = wxOrderTmpMgr.instance();
            string ret = Totbll.ProcessPaySuccess_wx("notify_url", out_trade_no, transaction_id, result_code, MyCommFun.Str2Int(total_fee), otid, wid);
            ret = ret == "" ? "处理数据同步发送成功" : ret;

            logBll.AddLog(wid, "微信预定", "【微支付】notify_url ProcessNotify", ret, 1);

            //------------------------------
            //处理业务完毕
            //------------------------------
            //回复服务器处理成功
            WriteContent("success");
        }

        /// <summary>
        /// 读取XML字符串中的节点值
        /// </summary>
        /// <param name="strXml"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public string ReadXmlValue(string strXml, string node)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strXml);
                XmlNode xn = doc.SelectSingleNode(node);
                value = xn.InnerText;
            }
            catch { }
            return value;
        }


        /// <summary>
        /// 返回值
        /// </summary>
        /// <param name="return_code">fail/success</param>
        /// <param name="return_msg">错误信息,如果正确，则返回空字符串</param>
        private void WriteContent(string return_code, string return_msg = "")
        {
            string str = "";
            str += "<xml><result_code><![CDATA[" + return_code.Trim().ToUpper() + "]]></result_code>";
            if (return_code.Trim().ToUpper() == "FAIL")
            {
                str += "<result_msg><![CDATA[" + return_msg + "]]></result_msg></xml>";
            }
            else
            {
                str += "</xml>";
            }
            Response.Output.Write(str);
        }
    }
}