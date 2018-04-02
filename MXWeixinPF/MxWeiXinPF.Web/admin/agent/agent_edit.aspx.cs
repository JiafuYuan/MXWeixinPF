using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;

namespace MxWeiXinPF.Web.admin.agent
{
    public partial class agent_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        BLL.manager mBll = new BLL.manager();
        BLL.wx_agent_info aBll = new BLL.wx_agent_info();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                id = MyCommFun.RequestInt("id");
                if (id<=0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!mBll.Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }

            }


            if (!Page.IsPostBack)
            {

                BindDdlProvince(ddlProvince);
                BindDdlCity(ddlCity);

                ChkAdminLevel("agent_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
               
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
 

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            litpwdtip.Text = "不填则不修改密码";
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            //ddlRoleId.SelectedValue = model.role_id.ToString();
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtUserName.Text = model.user_name;
            txtUserName.ReadOnly = true;
            txtUserName.Attributes.Remove("ajaxurl");

            txtRealName.Text = model.real_name;
            txtTelephone.Text = model.telephone;
            txtEmail.Text = model.email;
            ddlProvince.SelectedValue = model.province;
            ddlCity.SelectedValue = model.city;
            txtArea.Text = model.county;
            txtqq.Text = model.qq;
            txtEmail.Text = model.email;
            txtSortid.Text = MyCommFun.ObjToStr(model.sort_id);  // model.sort_id;
            txtRemark.Text = model.remark;

            //代理商信息
            Model.wx_agent_info agentinfo = aBll.GetAgentModel(_id);

            txtagentPrice.Text = agentinfo.agentPrice.Value.ToString();
            txtsqJine.Text = agentinfo.sqJine.Value.ToString();
            txtcompanyName.Text = agentinfo.companyInfo;
            ddlagentType.SelectedValue = agentinfo.agentType.Value.ToString();
            ddlagentLevel.SelectedValue = agentinfo.agentLevel;
            
            txtagentArea.Text = agentinfo.agentArea;
            txtindustry.Text=agentinfo.industry ;

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();
            string agentArea = txtagentArea.Text.Trim();


            Model.manager model = new Model.manager();

            model.role_id = 3; //代理商的角色id
            model.role_type =2;//系统用户，有区别与admin
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            //检测用户名是否重复
            if (mBll.Exists(txtUserName.Text.Trim()))
            {
                return false;
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
          
            model.agentId = GetAdminInfo().id;
            model.agentLevel = 1;//说明为代理商
            model.qq = txtqq.Text;
            model.email = txtEmail.Text;
            model.reg_ip = MXRequest.GetIP();
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id = MyCommFun.Obj2Int(txtSortid.Text);
            model.remark = txtRemark.Text;
           

            //代理商的基本信息
            Model.wx_agent_info agentinfo = new Model.wx_agent_info();
            int managerId = mBll.Add(model);
            if (managerId > 0)
            {
                agentinfo.managerId = managerId;
                agentinfo.agentPrice = MyCommFun.Str2Int(txtagentPrice.Text.Trim());
                agentinfo.sqJine = MyCommFun.Str2Int(txtsqJine.Text.Trim());
                agentinfo.czTotMoney = 0;
                agentinfo.remainMony = 0;
                agentinfo.companyInfo = txtcompanyName.Text;
                agentinfo.agentType = MyCommFun.Str2Int(ddlagentType.SelectedItem.Value);
                agentinfo.agentLevel =  ddlagentLevel.SelectedItem.Value;
                agentinfo.agentArea = agentArea;
                agentinfo.industry = txtindustry.Text.Trim();
                agentinfo.userNum = 0;
                agentinfo.wcodeNum = 0;
                agentinfo.createDate = DateTime.Now;
                agentinfo.expiryDate = DateTime.Parse("2100-12-1");
               int agentid= aBll.Add(agentinfo);
               if (agentid > 0)
               {
                   AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加代理商基本信息:" + model.user_name); //记录日志
                   return true;
               }
               else
               {
                   mBll.Delete(managerId);
               }
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();
            string agentArea = txtagentArea.Text.Trim();

            bool result = false;
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);

          //  model.role_id = int.Parse(ddlRoleId.SelectedValue);
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            //判断密码是否更改
            if (txtPassword.Text.Trim() != "")
            {
                //获取用户已生成的salt作为密钥加密
                model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            }
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();
          //  model.wxNum = int.Parse(txtMaxNum.Text);

            model.qq = txtqq.Text;
            model.email = txtEmail.Text;

            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id = MyCommFun.Str2Int(txtSortid.Text);
            model.remark = txtRemark.Text;

            if (bll.Update(model))
            {
                Model.wx_agent_info agentinfo = aBll.GetAgentModel(_id);
               
                agentinfo.agentPrice = MyCommFun.Str2Int(txtagentPrice.Text.Trim());
                agentinfo.sqJine = MyCommFun.Str2Int(txtsqJine.Text.Trim());
               
                agentinfo.companyInfo = txtcompanyName.Text;
                agentinfo.agentType = MyCommFun.Str2Int(ddlagentType.SelectedItem.Value);
                agentinfo.agentLevel =  ddlagentLevel.SelectedItem.Value;
                agentinfo.agentArea = agentArea;
                agentinfo.industry = txtindustry.Text.Trim();
                  
               bool agentid= aBll.Update(agentinfo);
               if (agentid)
               {
                   AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改代理商基本信息:" + model.user_name); //记录日志
                   result = true;
               }
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

             
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("agent_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改代理商基本信息成功！", "agent_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("manager_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加代理商基本信息成功！", "agent_list.aspx", "Success");
            }
        }


        #region 地区绑定
        /// <summary>
        /// 绑定省份
        /// </summary>
        /// <param name="ddl"></param>
        public void BindDdlProvince(DropDownList ddl)
        {
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=1");
            if (disList != null)
            {
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataSource = disList;
                ddl.DataBind();
            }

        }

        /// <summary>
        /// 绑定省份
        /// </summary>
        /// <param name="ddl"></param>
        public void BindDdlCity(DropDownList ddl)
        {
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=2");
            if (disList != null)
            {
                ddl.DataTextField = "name";
                ddl.DataValueField = "id";
                ddl.DataSource = disList;
                ddl.DataBind();
            }

        }

        /// <summary>
        /// 省级选择完以后，联动带出城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provId = ddlProvince.SelectedItem.Value;
            BLL.pre_common_district disBll = new BLL.pre_common_district();
            IList<Model.pre_common_district> disList = disBll.GetModelList("level=2 and upid=" + provId);
            if (disList != null)
            {
                ddlCity.DataTextField = "name";
                ddlCity.DataValueField = "id";
                ddlCity.DataSource = disList;
                ddlCity.DataBind();
            }
            MessageBox.ResponseScript(this, "$(\"#txtUserName\").focus();");

        }

        #endregion 
    }
}