using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxWeiXinPF.Web.weixin.hotel
{
    /// <summary>
    /// hotel_info 的摘要说明
    /// </summary>
    public class hotel_info : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");

            BLL.wx_hotel_dingdan dingdanbll = new BLL.wx_hotel_dingdan();
            Model.wx_hotel_dingdan dingdan = new Model.wx_hotel_dingdan();
            string hotelid = MyCommFun.QueryString("hotelid");
            string roomid = MyCommFun.QueryString("roomid");
            string openid = MyCommFun.QueryString("openid");
            string oderName = MyCommFun.QueryString("oderName");
            string tel = MyCommFun.QueryString("tel");
         

            if (_action == "dingdan")
            {
                dingdan.hotelid = Convert.ToInt32( hotelid);
                dingdan.roomid = Convert.ToInt32( roomid);
                dingdan.openid = openid;
                dingdan.oderName = oderName;
                dingdan.tel = tel;
                dingdan.orderStatus = 0;


                if (Convert.ToDateTime(MyCommFun.QueryString("arriveTime")) < DateTime.Now.AddDays(-1))
                {
                    jsonDict.Add("ret", "faile");
                    jsonDict.Add("content", "入住时间不能小于今天时间！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                if (Convert.ToDateTime(MyCommFun.QueryString("arriveTime")) > Convert.ToDateTime(MyCommFun.QueryString("leaveTime")))
                {
                    jsonDict.Add("ret", "faile");
                    jsonDict.Add("content", "入住时间必须小于离店时间！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                if (MyCommFun.QueryString("arriveTime")!="")
                {
                dingdan.arriveTime = Convert.ToDateTime( MyCommFun.QueryString("arriveTime"));
                }
                if (MyCommFun.QueryString("leaveTime") != "")
                {
                    dingdan.leaveTime = Convert.ToDateTime(MyCommFun.QueryString("leaveTime"));
                }
                dingdan.roomType = MyCommFun.QueryString("roomType");
                dingdan.orderTime = DateTime.Now;
                dingdan.orderNum = MyCommFun.RequestInt("orderNum");
                dingdan.isDelete = 0;
                dingdan.price = MyCommFun.Str2Decimal( MyCommFun.QueryString("price"));
                dingdan.yuanjia =MyCommFun.Str2Decimal(MyCommFun.QueryString("yuanjia"));
                dingdan.remark = MyCommFun.QueryString("remark");
                dingdanbll.Add(dingdan);

               jsonDict.Add("ret", "ok");
               jsonDict.Add("content", "提交成功！");
               context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               return;

             }

            if (_action =="dingdanedite")
            {

                dingdan.id = MyCommFun.RequestInt("dingdanidnum");
                dingdan.oderName=MyCommFun.QueryString("truename");
                dingdan.tel = MyCommFun.QueryString("tel");

                if (Convert.ToDateTime(MyCommFun.QueryString("dateline")) < DateTime.Now.AddDays(-1))
                {
                    jsonDict.Add("ret", "faile");
                    jsonDict.Add("content", "入住时间不能小于今天时间！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                if (MyCommFun.QueryString("dateline")!="")
                {
                dingdan.arriveTime = Convert.ToDateTime(MyCommFun.QueryString("dateline"));
                }

               

                dingdan.orderNum = MyCommFun.RequestInt("nums");
                dingdan.price = Convert.ToDecimal( MyCommFun.QueryString("xianjianum"));
                dingdan.yuanjia = Convert.ToDecimal( MyCommFun.QueryString("yuanjianum"));
                dingdan.remark = MyCommFun.QueryString("info");
                dingdanbll.Updatehotel(dingdan);

                jsonDict.Add("ret", "ok");
                jsonDict.Add("content", "修改成功！");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                return;
            }

            if (_action == "dingdandelete")
            {
                int ddid = MyCommFun.RequestInt("dingdanidnum");
                dingdanbll.Update(ddid);
                jsonDict.Add("ret", "ok");
                jsonDict.Add("content", "删除成功！");
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
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