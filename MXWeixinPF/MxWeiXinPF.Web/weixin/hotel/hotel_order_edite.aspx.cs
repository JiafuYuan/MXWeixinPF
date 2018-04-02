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
    public partial class hotel_order_edite : WeiXinPage
    {
        public int hotelid = 0;
        public string openid = "";
        public string image = "";
       
        public string order = "";
        public int numdingdan = 0;
        public string dingdanid = "";
        BLL.wx_hotel_dingdan dingdanbll = new BLL.wx_hotel_dingdan();
        Model.wx_hotel_dingdan dingdan = new Model.wx_hotel_dingdan();
        public string createtime = "";
        public string zhuangtai = "";
        public string roomtype = "";
        public decimal yuanjia = 0;
        public decimal price = 0;
        public decimal jiesheng = 0;
        public int roomid = 0;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            openid = MyCommFun.QueryString("openid");
            dingdanid = MyCommFun.QueryString("dingdanid");
            roomid = MyCommFun.RequestInt("roomid");

            if(!IsPostBack)
            {

                BLL.wx_hotels_info infobll = new BLL.wx_hotels_info();
                Model.wx_hotels_info info = new Model.wx_hotels_info();
                info = infobll.GetModel(hotelid);
                image = info.topPic;

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
                this.dingdanidnum.Value = dingdanid;
                this.roomidnum.Value = roomid.ToString();
                this.hotelidnum.Value = hotelid.ToString();
                this.openidnum.Value = openid.ToString();

                getdingdan(dingdanid);
            }

        }

        public void getdingdan(string dingdanid)
        {
            int id = Convert.ToInt32(dingdanid);
            dingdan = dingdanbll.GetModel(id);
            if(dingdan!=null)
            {
                createtime = dingdan.orderTime.ToString();
               
                    if(dingdan.orderStatus==0)
                    {
                        zhuangtai = "<em class=\"no\">未处理</em>";
                       
                    }
                    else if (dingdan.orderStatus == 1)
                    {
                        zhuangtai = "<em class=\"ok\">成功</em>";
                    }
                    else
                    {
                        zhuangtai = "<em class=\"fail\">失败</em>";
                    }

                    this.truename.Value = dingdan.oderName;
                    this.tel.Value = dingdan.tel;
                    this.dateline.Value = dingdan.arriveTime.ToString();
                    roomtype = dingdan.roomType;
                    this.nums.Value = dingdan.orderNum.ToString();
                    yuanjia = Convert.ToDecimal(dingdan.yuanjia);
                    price = Convert.ToDecimal(dingdan.price);
                    jiesheng = (yuanjia - price) * Convert.ToDecimal(dingdan.orderNum);
                    this.yuanjianum.Value = yuanjia.ToString();
                    this.xianjianum.Value = price.ToString();
                    this.jsnum.Value = jiesheng.ToString();
                    this.info.Value = dingdan.remark;


            }
        }
    }
}