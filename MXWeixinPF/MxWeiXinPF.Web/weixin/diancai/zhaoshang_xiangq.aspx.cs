using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.diancai
{
    public partial class zhaoshang_xiangq : WeiXinPage
    {
        BLL.wx_diancai_shop_setup setupbll = new BLL.wx_diancai_shop_setup();
        Model.wx_diancai_shop_setup setup = new Model.wx_diancai_shop_setup();
        public int shopid = 0;
        public string openid = "";
        public string zhaoshang = "";
        public string tel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = MyCommFun.RequestInt("shopid");
            openid = MyCommFun.QueryString("openid");
            if(!IsPostBack)
            {
                setup = setupbll.GetModelset(shopid);
                zhaoshang = setup.unionManage;
                tel = setup.unionTel;

            }
        }


    }
}