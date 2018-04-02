using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.muying
{
    public partial class my_search : WeiXinPage
    {
        protected int wid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wid = MXRequest.GetQueryInt("wid");
            }
        }
    }
}