using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.muying
{
    /// <summary>
    /// muyingAPI 的摘要说明
    /// </summary>
    public class muyingAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            int wid = MyCommFun.RequestInt("wid");
            if (_action == "search")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                BLL.wx_my_user bll = new BLL.wx_my_user();
                string name = MyCommFun.QueryString("name");
                int result = bll.GetRecordCount(" username='" + name + "' and wid=" + wid);
                if (result > 0)
                {
                    int id = bll.GetModelList(" username='" + name + "' and wid=" + wid)[0].id;
                    jsonDict.Add("sys", "0");
                    jsonDict.Add("content", id.ToString() + "&wid=" + wid);
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                jsonDict.Add("sys", "err");
                jsonDict.Add("content", "此用户不存在");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }

            if (_action == "")
            {
                Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                return;
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