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
    public partial class hotel_form : WeiXinPage
    {
        public int hotelid = 0;
        public string openid = "";
        public int roomid = 0;
        BLL.wx_hotel_room roombll = new BLL.wx_hotel_room();
        Model.wx_hotel_room room = new Model.wx_hotel_room();
        BLL.wx_hotels_info hotelbll = new BLL.wx_hotels_info();
        Model.wx_hotels_info hotel = new Model.wx_hotels_info();

        BLL.wx_hotel_roompic picbll = new BLL.wx_hotel_roompic();

        public int numdingdan = 0;
        public string roomtype = "";
        public string yuanjia = "";
        public string xianjia = "";
        public string peitao = "";
        public string tel = "";
        public string tupian = "";
        public string tabid = "";
 
     
        public decimal price3 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            openid = MyCommFun.QueryString("openid");
            roomid = MyCommFun.RequestInt("roomid");

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
                this.roomidnum.Value = roomid.ToString();
                this.hotelidnum.Value = hotelid.ToString();
                this.openidnum.Value = openid.ToString();
                list(roomid, hotelid);
            }

        }

        public void list(int roomid, int hotelid)
        {
            room = roombll.GetModel(roomid);
            hotel = hotelbll.GetModel(hotelid);
            if (hotel!=null)
            {
                tel = hotel.hotelPhone;
            }
            if (room!=null)
            {
                roomtype = room.roomType;
                this.roomtypenum.Value = roomtype;
                yuanjia = room.roomPrice.ToString();
                xianjia = room.salePrice.ToString();
                price3 = Convert.ToDecimal(yuanjia) - Convert.ToDecimal(xianjia);
                peitao = room.facilities;
                this.yuanjianum.Value = yuanjia;
                this.pricenum.Value = xianjia;
                this.price3num.Value = price3.ToString();

            }
            DataSet dr = picbll.GetList(roomid);
            if(dr.Tables[0].Rows.Count >0)
            {
                int j = 0;
                for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
                {
                    tupian += "  <li><p>" + dr.Tables[0].Rows[i]["title"].ToString() + "</p><a href=\"" + dr.Tables[0].Rows[i]["roomPictz"].ToString() + "\"><img src=\"" + dr.Tables[0].Rows[i]["roomPic"].ToString() + "\"></a></li>";
                    j += 1;
                    tabid += "<li >"+j.ToString()+"</li>";
                }
            }
            
        }
    }
}