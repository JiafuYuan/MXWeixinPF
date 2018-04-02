using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.diancai
{
    public partial class diancai_geren : WeiXinPage
    {
      
        public int shopid = 0;
        public string openid = "";
       
       
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        public int id = 0;
        public string rename = "";
        protected string username = "";
        protected string usertel = "";
        protected string useraddr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
               
                shopid = MyCommFun.RequestInt("shopid");
                openid = MyCommFun.QueryString("openid");
                shopinfo = shopBll.GetModel(shopid);
                hotelName = shopinfo.hotelName;
                rename = shopinfo.dcRename;

                BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
                IList<Model.wx_diancai_member> memlist = menberbll.GetModelList("shopid=" + shopid + " and openid='" + openid + "'");
               
                if (memlist == null || memlist.Count <= 0 || memlist[0] == null)
                {
                    
                }
                else
                {
                    username = memlist[0].Name;
                    usertel = memlist[0].menberTel;
                    useraddr = memlist[0].memberAddress;
                }

            }
        }
    }
}