using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class floorInfo : WeiXinPage
    {
        protected Model.wx_fc_floor floor;
        protected int fid;
        BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = MXRequest.GetQueryInt("fid");
            if (!IsPostBack)
            {
                showInfo();
            }
        }

        void showInfo()
        {
            floor = fBll.GetModel(fid);
        }
    }
}