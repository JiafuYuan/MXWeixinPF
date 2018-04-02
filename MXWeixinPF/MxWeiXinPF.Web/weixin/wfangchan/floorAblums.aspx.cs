using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class floorAblums : WeiXinPage
    {
        protected int fid;
        protected int wid;
        BLL.wx_fc_album aBll = new BLL.wx_fc_album();
        protected DataTable data = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = MXRequest.GetQueryInt("fid");
            wid = MXRequest.GetQueryInt("wid");
            if (!IsPostBack)
            {
                showInfo();
            }
        }

        void showInfo()
        {
             
        }

    }
}