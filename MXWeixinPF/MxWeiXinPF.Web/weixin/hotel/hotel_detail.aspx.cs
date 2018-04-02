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
    public partial class hotel_detail : WeiXinPage
    {
        public int hotelid = 0;
        public string openid = "";
        BLL.wx_hotels_info hotelbll = new BLL.wx_hotels_info();
        Model.wx_hotels_info hotel = new Model.wx_hotels_info();
        BLL.wx_hotel_pic picbll = new BLL.wx_hotel_pic();
        
        public string address = "";
        public string tel = "";
        public string jieshao = "";
        public string tupian = "";
        public string tabid = "";
        public string xplace = "";
        public string yplace = "";
        public int numdingdan = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            openid = MyCommFun.QueryString("openid");
            if (!Page.IsPostBack)
            {
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

                List(hotelid);
            }

        }
        public void List(int hotelid)
        {
            hotel = hotelbll.GetModel(hotelid);
            if (hotel!=null)
            {
                address = hotel.hotelAddress;
                xplace = hotel.xplace.ToString();
                yplace = hotel.yplace.ToString();
                tel = hotel.hotelPhone;
                jieshao = hotel.hotelIntroduct;

                DataSet dr = picbll.GetList(hotelid);
                if (dr.Tables[0].Rows.Count>0)
                {
                    int j = 0;
                    for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
                    {
                        tupian += "<li><p>" + dr.Tables[0].Rows[i]["title"].ToString() + "</p>  ";
                        if (dr.Tables[0].Rows[i]["picTiaozhuan"].ToString() != "")
                        {
                            tupian += " <a href=\"" + dr.Tables[0].Rows[i]["picTiaozhuan"].ToString() + "\">";
                        }
                        else
                        {
                            tupian += " <a href=\"#\">";
                        }
                       tupian+="  <img src=\"" + dr.Tables[0].Rows[i]["picUrl"].ToString() + "\"></a></li>";

                        j += 1;
                        tabid += "<li   >" + j.ToString() + "</li>";

                    }
                } 
            }


        }
    }
}