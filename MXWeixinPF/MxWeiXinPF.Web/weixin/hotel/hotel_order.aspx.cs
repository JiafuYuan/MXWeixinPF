using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.hotel
{
    public partial class hotel_order : WeiXinPage
    {
        public int hotelid = 0;
        public int roomid = 0;
        public string openid = "";
        public string image = "";
        BLL.wx_hotel_dingdan dingdanbll = new BLL.wx_hotel_dingdan();
        public string order="";
        public int numdingdan = 0;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            openid = MyCommFun.QueryString("openid");
            roomid = MyCommFun.RequestInt("roomid");
            if (!Page.IsPostBack)
            {

                BLL.wx_hotels_info infobll = new BLL.wx_hotels_info();
                Model.wx_hotels_info info = new Model.wx_hotels_info();
                info = infobll.GetModel(hotelid);
                if (info!=null)
                {               
                image = info.topPic;
                }

                BLL.wx_hotel_dingdan dingdanbll = new BLL.wx_hotel_dingdan();
                DataSet dr = dingdanbll.GetList(openid, hotelid);
                if (dr.Tables[0].Rows.Count > 0)
                {
                    numdingdan = dr.Tables[0].Rows.Count;
                }
                else
                {
                    numdingdan = 0;
                }


                List(openid, hotelid);
            }
        }

        public void List(string openid,int hotelid)
        {

            DataSet dr = dingdanbll.GetList(openid,hotelid);
            if(dr.Tables[0].Rows.Count >0)
            {
                order += "  <ul class=\"round\"> ";
                for(int i=0;i<dr.Tables[0].Rows.Count;i++)
                {
                   
                    if (dr.Tables[0].Rows[i]["orderStatus"].ToString() == "0")
                    {
                        order += "<li class=\"title\"><a href=\"hotel_order_edite.aspx?dingdanid=" + dr.Tables[0].Rows[i]["id"].ToString() + "&hotelid=" + hotelid + "&roomid=" + roomid + "&openid=" + openid + "\"><span>" + dr.Tables[0].Rows[i]["createDate"].ToString() + "订单详情";//05月29日 9时39分
                    }
                    else
                    {
                        order += "<li class=\"title\"><a href=\"hotel_order_xianshi.aspx?dingdanid=" + dr.Tables[0].Rows[i]["id"].ToString() + "&hotelid=" + hotelid + "&roomid=" + roomid + "&openid=" + openid + "\"><span>" + dr.Tables[0].Rows[i]["createDate"].ToString() + "订单详情";//05月29日 9时39分
                    }

                 
                    if(dr.Tables[0].Rows[i]["orderStatus"].ToString()=="1")
                    {
                        order += "<em class=\"ok\">成功</em></span>";  
                    
                    }
                    else if (dr.Tables[0].Rows[i]["orderStatus"].ToString() == "0")
                    {
                        order += "<em class=\"no\">未处理</em></span>";  
                    }
                    else if (dr.Tables[0].Rows[i]["orderStatus"].ToString() == "2")
                    {
                        order += "<em class=\"error\">失败</em></span>";
                    }

                    order += "</a></li><li><div class=\"text\"><p>预约商家：" + dr.Tables[0].Rows[i]["hotelName"].ToString() + "</p>";
                    order += "<p>类型：" + dr.Tables[0].Rows[i]["roomType"].ToString() + "</p><p>预订数量：" + dr.Tables[0].Rows[i]["orderNum"].ToString() + "间</p>";
                    order += "<p>预定日期：" + dr.Tables[0].Rows[i]["orderTime"].ToString() + "</p></div></li>";
                }

                order += " </ul> ";
            }
        }
    }
}