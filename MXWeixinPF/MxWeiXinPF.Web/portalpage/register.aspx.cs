using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.portalpage
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            model.role_id =2;//普通用户
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
             
            //检测用户名是否重复
            if (bll.Exists(txtUserName.Text.Trim()))
            {
                return ;
            }
            model.user_name = txtUserName.Text.Trim();
            //获得6位的salt加密字符串
            model.salt = Utils.GetCheckCode(6);
            //以随机生成的6位字符串做为密钥加密
            model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();
            model.add_time = DateTime.Now;
            model.wxNum = 0;
            model.agentId =1;
            if (model.user_name.Contains("admin"))
            {
                lblError.Text = "登录包含非法字符";
                return;
            }
            lblError.Text = "";
            if (bll.Add(model) > 0)
            {
                //成功
                lblError.Text = "";
                MessageBox.Show(this, "注册成功！请登录！");

             //   MessageBox.ShowAndRedirect(this,"注册成功！将跳转到登录页面。。。","/admin/login.aspx");
            }
            else
            { 
                //失败
                MessageBox.Show(this,"注册失败！请重新注册，或者联系管理员！");
            }
        }

    }
}