using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxWeiXinPF.Common;
using System.Text;
using MxWeiXinPF.Web.admin.sms;

namespace MxWeiXinPF.Web.weixin.yuyue
{
    /// <summary>
    /// yuyueApi 的摘要说明
    /// </summary>
    public class yuyueApi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //暂只考虑添加留言信息
            context.Response.ContentType = "text/json";
            try
            {

                string openid = MyCommFun.QueryString("openid");//openid
                if (openid == "" || openid == "loseopenid")
                {
                    openid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
                int formid = MyCommFun.RequestInt("formid");
                int wid = MyCommFun.RequestInt("wid");
                
                BLL.wx_yy_base ybBll = new BLL.wx_yy_base();
                Model.wx_yy_base baseinfo=ybBll.GetModel(formid);


                BLL.wx_yy_control cBll = new BLL.wx_yy_control();
                BLL.wx_yy_result rBll = new BLL.wx_yy_result();
                Model.wx_yy_result ret = new Model.wx_yy_result();
                IList<Model.wx_yy_control> clist = cBll.GetModelList("formId=" + formid);

                DateTime now = DateTime.Now;
                //是否需要上传图片 begin
                if (baseinfo.needPIC)
                {
                    ret = new Model.wx_yy_result();
                    ret.formId = formid;
                    ret.openid = openid;
                    ret.cId = -100;
                    ret.userResult = MyCommFun.QueryString("img_show");
                    ret.cName = "图片";
                    ret.createDate = now;
                    rBll.Add(ret);
                }
                //end


               // rBll.DeleteByOpenid(openid, formid);
                StringBuilder smsContent = new StringBuilder("活动名称：" + baseinfo.title+ ",客户表单内容：");
                for (int i = 0; i < clist.Count; i++)
                {
                    ret = new Model.wx_yy_result();
                    ret.formId = formid;
                    ret.openid = openid;
                    ret.cId = clist[i].id;
                    ret.userResult = MyCommFun.QueryString("control_" + clist[i].id);
                    ret.cName = clist[i].cName;
                    ret.createDate = now;
                    rBll.Add(ret);
                    smsContent.Append(ret.cName + ":" + ret.userResult+" ");
                }
                if (baseinfo.needSMS)
                {
                    smsMgr smgr = new smsMgr(wid);
                    smgr.SendSMS(baseinfo.phone, smsContent.ToString(),"在线预约",baseinfo.title,baseinfo.id);
                }
                context.Response.Write("{\"success\":\"true\",\"content\":\"提交成功！\"}");

            }
            catch (Exception ex)
            {
                context.Response.Write("{\"success\":\"false\",\"content\":\"系统出现问题，请重新提交！\"}");
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