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
    public partial class hotel_order_onlin : WeiXinPage
    {
        BLL.wx_hotels_info infobll = new BLL.wx_hotels_info();
        public string infostring = "";
        public string openid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.QueryString("openid");

            if(!IsPostBack)
            {
                getlist();
            }
        }

        public void getlist()
        {
            DataSet dr=new DataSet();
            dr = infobll.GetList();
            if(dr.Tables[0].Rows.Count >0)
            {
                for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
                {
                    infostring += " <li><a href=\"index.aspx?hotelid=" + dr.Tables[0].Rows[i]["id"].ToString() + "&openid=" + openid + "\"><span>" + dr.Tables[0].Rows[i]["hotelName"].ToString() + "</span></a></li>";
                }
            }
        }
    }
}