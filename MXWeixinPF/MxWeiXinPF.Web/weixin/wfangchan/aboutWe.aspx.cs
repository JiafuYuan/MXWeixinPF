using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class aboutWe : WeiXinPage
    {
        protected int fid;
        protected int wid;
        protected string openid;
        protected Model.wx_fc_aboutWe aw;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MXRequest.GetQueryInt("wid");
            fid = MXRequest.GetQueryInt("fid");
            if (!IsPostBack)
            {
                BLL.wx_fc_aboutWe awBll = new BLL.wx_fc_aboutWe();
                aw = awBll.GetModelList(" fid=" + fid + " and wid=" + wid)[0];
            }
        }
    }
}