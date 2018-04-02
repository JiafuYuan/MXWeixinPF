using MxWeiXinPF.Common;
using MxWeiXinPF.Web.admin.sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.BLL;
using System.Data;
using System.Web.SessionState;
using MxWeiXinPF.Web.UI;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    /// <summary>
    /// uProcess 的摘要说明
    /// </summary>
    public class uProcess : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            int aid = MyCommFun.RequestInt("aid");
            int wid = MyCommFun.RequestWid();
            string openid = MyCommFun.RequestOpenid();
            string _action = MXRequest.GetQueryString("mycat");
            BLL.wx_qp_base actBll = new wx_qp_base();
            BLL.wx_qp_users userBll = new BLL.wx_qp_users();
            //验证码
            if (_action == "sendCardCheckCode")
            {
                Model.wx_qp_base actModel = actBll.GetModel(aid);
                string actName = actModel.bName;
                smsMgr smgr = null;
                string Number = string.Empty;
                string smsStatus = string.Empty;
                string telephone = MXRequest.GetQueryString("telephone");
                #region 验证码
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                IList<Model.wx_qp_users> userList = userBll.GetModelList(string.Format(" (openid='{0}'and bId={2}) or (uTel='{1}' and bId={2})", openid, telephone, aid));
                try
                {
                    if (Regexlib.IsValidMobile(telephone))
                    {
                        //判断是否超过活动最大人数
                        if (actModel.cyPersonNum >= actModel.maxPersonNum)
                        {
                            jsonDict.Add("errno", "sys");
                            jsonDict.Add("content", "活动人数已满！");
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }

                        if (userList.Count > 0)//已参加过本次活动,不发送验证码
                        {
                            jsonDict.Add("errno", "sys");
                            jsonDict.Add("content", "你已参加过本次活动！");
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }
                        smgr = new smsMgr(wid);
                        Number = Utils.Number(6, true);
                        smsStatus = smgr.SendSMS(telephone, Number + "(动态验证码)，您于" + DateTime.Now.ToString("yyyy年MM月dd日 hh点mm分") + "参与\"" + actName + "\"抢票活动，请在10分钟内输入该验证码！", Number, actName, aid);
                        if (smsStatus == "成功")
                        {
                            //获取验证码
                            jsonDict.Add("errno", "0");
                            jsonDict.Add("content", "获取验证码成功");
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;
                        }
                        else
                        {
                            jsonDict.Add("errno", "sys");
                            jsonDict.Add("content", "发送验证码失败！");
                            context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                            return;

                        }
                    }
                    else
                    {
                        jsonDict.Add("errno", "sys");
                        jsonDict.Add("content", "手机格式错误！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }

                }
                catch (Exception ex)
                {
                    jsonDict.Add("errno", "sys");
                    jsonDict.Add("content", "发送验证码失败！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;

                }

                #endregion
            }
            
            //index页面抢票时判断是否已参加过活动
            if (_action == "qp_ckJoined")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                //判断此人是否已参与过活动
                bool joined = userBll.GetModelList(string.Format(" bId={0} and openid='{1}'", aid, openid)).Count > 0;
                if (joined)//已参与，跳转结果显示页面
                {
                    string goUrl = string.Format("order_Result.aspx?wid={0}&aid={1}&openid={2}&join=false", wid, aid, openid);
                    jsonDict.Add("errno", "0");
                    jsonDict.Add("content", goUrl);
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                else//还未参与，跳转订单页面
                {
                    string goUrl = string.Format("order.aspx?wid={0}&aid={1}&openid={2}", wid, aid, openid);
                    jsonDict.Add("errno", "0");
                    jsonDict.Add("content", goUrl);
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
            }

            //抢票得到订单
            if (_action == "qp_ckOrder")
            {
                string identCode = MyCommFun.QueryString("identCode");
                string telephone = MyCommFun.QueryString("telephone");
                BLL.wx_sms_info smsBll = new BLL.wx_sms_info();
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                string goUrl = "";
                //判断用户是否已经参与过活动
                IList<Model.wx_qp_users> userList = userBll.GetModelList(string.Format(" (openid='{0}'and bId={2}) or (uTel='{1}' and bId={2}) ", openid, telephone, aid));
                //判断验证码
                bool ckIdentcode = smsBll.ExistsYzm(telephone, identCode);

                Model.wx_qp_base actModel = actBll.GetModel(aid);

                //判断是否超过活动最大人数
                if (actModel.cyPersonNum >= actModel.maxPersonNum)
                {
                    jsonDict.Add("errno", "sys");
                    jsonDict.Add("content", "活动人数已满！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (userList.Count > 0)
                {
                    jsonDict.Add("errno", "sys");
                    jsonDict.Add("content", "你已参加过活动,每人只能参加一次！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (!Regexlib.IsValidMobile(telephone))
                {
                    jsonDict.Add("errno", "sys");
                    jsonDict.Add("content", "手机格式错误！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (!ckIdentcode)
                {
                    jsonDict.Add("errno", "sys");
                    jsonDict.Add("content", "验证码错误！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                


                Model.wx_qp_users model = new Model.wx_qp_users();
                model.bId = aid;
                model.openid = openid;
                model.uTel = telephone;
                model.createDate = DateTime.Now;
                model.sn = "sn_" + Utils.Number(6, true);
                //添加参与活动用户并给递加活动人数
                int res = userBll.Add(model);
                actModel.cyPersonNum = actModel.cyPersonNum + 1;
                actModel.yingyuanlist = null;
                actBll.Update(actModel);

                //判断该活动是否发送SN码通知用户
                if (actModel.isSnSendsms && res > 0)//发送
                {
                    smsMgr smgr = new smsMgr(wid);
                    string smsStatus = smgr.SendSMS("您于" + DateTime.Now.ToString("yyyy年MM月dd日 hh点mm分") + "参与\"" + actModel.bName + "\"抢票活动！恭喜你,抢票成功！(SN码)" + telephone, model.sn, model.sn, actModel.bName, aid);
                }
                goUrl = string.Format("order_Result.aspx?wid={0}&aid={1}&openid={2}&join=true", wid, aid, openid);
                jsonDict.Add("errno", "0");
                jsonDict.Add("content", goUrl);
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}