using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();
                if (admin_info.agentLevel > 0)
                {
                    //说明为代理商
                    mygzh.Style.Add("display", "none");
                  //  Response.Redirect("index.aspx");
                }
                else
                {
                    indexUrl.HRef = "wxIndex.aspx";
                  //  Response.Redirect("wxIndex.aspx");
                }
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[MXKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "MxWeiXinPF", -14400);
            Utils.WriteCookie("AdminPwd", "MxWeiXinPF", -14400);

            Session["uweixinId"] = null;
            Utils.WriteCookie("uweixinId", "MxWeiXinPF", -14400);

            Response.Redirect("login.aspx");
        }

    }
}