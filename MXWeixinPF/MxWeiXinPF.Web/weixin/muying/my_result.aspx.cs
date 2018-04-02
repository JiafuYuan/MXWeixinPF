using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.muying
{
    public partial class my_result : WeiXinPage
    {
        protected int id;
        protected int wid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = MXRequest.GetQueryInt("id");
                wid = MXRequest.GetQueryInt("wid");
                BLL.wx_my_tijian tjBll = new BLL.wx_my_tijian();
                this.rptList.DataSource = tjBll.GetList(" userid=" + id + " and wid=" + wid + " order by tijiandate desc");
                this.rptList.DataBind();
            }

        }
    }
}