using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.WeiXinComm;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class group_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        // 页面加载操作
        protected void Page_Load(object sender, EventArgs e)
        {
            //取到操作类型
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_group", MXEnums.ActionEnum.View.ToString()); //检查权限
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo();
                }
            }

        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            hidId.Value = this.id.ToString();

            txtTitle.Text = MyCommFun.QueryString("name");

             
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            string name = txtTitle.Text.Trim();

            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm wcr = new WeiXinCRMComm();
            string err = "";
            string accessToken = wcr.getAccessToken(weixin.id, out err);
            if (err.Trim() != "")
            {
                JscriptMsg(err, "", "Error");
                return false;
            }
            WxJsonResult wjr = Groups.Create(accessToken, name);
            if (wjr.errcode.ToString() == "请求成功")
            {
                result = true;
            }
            if (result)
            {
                BLL.wx_crm_group gBll = new BLL.wx_crm_group();
                Model.wx_crm_group group = new Model.wx_crm_group();
                group.wid = weixin.id;
                group.id = ((Senparc.Weixin.MP.AdvancedAPIs.CreateGroupResult)(wjr)).group.id;
                group.name = name;
                group.count = 0;
               gBll.Add(group);

            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit( )
        {
            bool result = false;
            int id = MyCommFun.Str2Int(hidId.Value);
            string name = txtTitle.Text.Trim();

            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm wcr = new WeiXinCRMComm();
            string err = "";
            string accessToken = wcr.getAccessToken(weixin.id, out err);
            if (err.Trim() != "")
            {
                JscriptMsg(err, "", "Error");
                return false;  
            }
          WxJsonResult wjr=Groups.Update(accessToken, id, name);
          if (wjr.errmsg == "ok")
          {
              result = true;
          }
          if (result)
          {
              BLL.wx_crm_group gBll = new BLL.wx_crm_group();
              Model.wx_crm_group group = gBll.GetModel(id);
              group.name = name;
              gBll.Update(group);

          }

            return result;
        }
        #endregion


        // 提交保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim().Length <= 0)
            {
                JscriptMsg("组别名称不能为空！", "", "Error");
                return; 
                }

            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("user_group", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改用户组成功！", "group_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("user_group", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加用户组成功！", "group_list.aspx", "Success");
            }
        }

        public string MyCommfun { get; set; }
    }
}