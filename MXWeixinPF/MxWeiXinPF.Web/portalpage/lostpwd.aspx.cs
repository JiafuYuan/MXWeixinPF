using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.portalpage
{
    public partial class lostpwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            string logName = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();
            if (logName.Length == 0 || email.Length == 0 || logName.Contains("'") || email.Contains("'"))
            {
                MessageBox.Show(this, "登录名或者邮箱是非法的！");
                return;
            }

            //检测用户名是否重复
            if (!bll.Exists(logName,email))
            {
                MessageBox.Show(this, "登录名或者邮箱输入错误！");
                return;
            }
            model.user_name = logName;
            model.email = email;
           
            lblError.Text = "";

             
        }
    }
}