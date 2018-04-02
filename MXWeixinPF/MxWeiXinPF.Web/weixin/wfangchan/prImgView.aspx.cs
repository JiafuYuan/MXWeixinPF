using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class prImgView : WeiXinPage
    {
        protected int wid;
        protected int fid;
        protected int id;
        protected string openid;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MyCommFun.RequestInt("wid");
            fid = MyCommFun.RequestInt("fid");
            id = MyCommFun.RequestInt("id");
            openid = MyCommFun.QueryString("openid");
            if (!IsPostBack)
            {
                BLL.wx_fc_panorama pBll = new BLL.wx_fc_panorama();
                this.rptView.DataSource = pBll.GetModelList(" fid=" + fid);
                this.rptView.DataBind();
            }
        }
    }
}