using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;


namespace MxWeiXinPF.Web.admin.templates
{
    public partial class showPhone : Web.UI.ManagePage
    {
        protected int wid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                wid = weixin.id;
            }
        }
    }
}