using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.zjd
{
    public partial class end : WeiXinPage
    {
        public int aid = 0;
        public int wid = 0;
        public string image = "";
        public string backmusic = "";
        public string openid = "";
        public Model.wx_zjdActionInfo zjdAction;
        BLL.wx_zjdActionInfo actBll = new BLL.wx_zjdActionInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            aid = MyCommFun.RequestInt("aid");
            wid = MyCommFun.RequestInt("wid");
            openid = MyCommFun.QueryString("openid");

            if (!IsPostBack)
            {
                BLL.wx_zjdActionInfo infobll = new BLL.wx_zjdActionInfo();
                Model.wx_zjdActionInfo info = new Model.wx_zjdActionInfo();
                info = infobll.GetModel(aid);
                if (info != null)
                {
                    image = info.beginPic;
                   
                }
            }
        }

       
         
    }
}