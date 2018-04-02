using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.manager
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public partial class manager_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        BLL.wx_agent_info aBll = new BLL.wx_agent_info();
        private bool isAgent = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.manager().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
               
            }


            if (!Page.IsPostBack)
            {
                
                BindDdlProvince(ddlProvince);
                BindDdlCity(ddlCity);

                ChkAdminLevel("manager_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得管理员信息
                Model.wx_agent_info agent = aBll.GetAgentModel(model.id);
                //代理商信息
                if (agent != null)
                {
                    lblremainMony.Text = agent.remainMony.Value.ToString();
                    lblagentPrice.Text = agent.agentPrice.Value.ToString();
                    lblMoney.Text = agent.agentPrice.Value.ToString();
                    isAgent = true;
                }

                RoleBind(ddlRoleId, model.id);
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 角色类型=================================
        private void RoleBind(DropDownList ddl, int managerId)
        {
            BLL.manager_role bll = new BLL.manager_role();
         //   DataTable dt = bll.GetList("agentId=" + managerId).Tables[0];
            DataTable dt = new DataTable();
            if (isAgent)
            {
                dt = bll.GetList("id!=1 and id!=3 ").Tables[0];
            }
            else
            {
                dt = bll.GetList("agentId=" + managerId).Tables[0];
            }

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                
            ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
                 
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            litpwdtip.Text = "不填则不修改密码";
            BLL.manager bll = new BLL.manager();
         
            Model.manager model = bll.GetModel(_id);

            ddlRoleId.SelectedValue = model.role_id.ToString();
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
            ddlMaxNum.SelectedValue = model.wxNum.ToString();
            hidOldMaxNum.Value = model.wxNum.ToString();
            ddlProvince.SelectedValue = model.province;
            ddlCity.SelectedValue = model.city;
            txtArea.Text = model.county;
            txtqq.Text = model.qq;
            txtEmail.Text = model.email;
            txtSortid.Text = MyCommFun.ObjToStr(model.sort_id);  // model.sort_id;
            txtRemark.Text = model.remark;
           

          }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
         
            Model.manager adminEntity = GetAdminInfo(); //取得管理员信息
            Model.wx_agent_info agent = new Model.wx_agent_info();
            bool isAgent = false;
            if (adminEntity.agentLevel < 0)
            {
                return false;
            }
            if (adminEntity.agentLevel > 0)
            {
                agent = aBll.GetAgentModel(adminEntity.id);
                isAgent = true;
                if (agent.remainMony < agent.agentPrice)
                {
                    JscriptMsg("余额不足，请联系管理员充值！", "", "Error");
                    return false;
                }
            }
            else
            { 
                
            }
            //int oldMaxNum = MyCommFun.Str2Int(hidOldMaxNum.Value);
            int newMaxNum = MyCommFun.Str2Int(ddlMaxNum.SelectedItem.Value);
            
            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();

            Model.manager model = new Model.manager();
            BLL.manager bll = new BLL.manager();
            model.role_id = int.Parse(ddlRoleId.SelectedValue);
            model.role_type = new BLL.manager_role().GetModel(model.role_id).role_type;
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            //检测用户名是否重复
            if (bll.Exists(txtUserName.Text.Trim()))
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
            model.wxNum = newMaxNum;
            model.agentId = GetAdminInfo().id;
            model.qq = txtqq.Text;
            model.email = txtEmail.Text;
            model.reg_ip = MXRequest.GetIP();
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id=MyCommFun.Obj2Int(txtSortid.Text);
            model.agentLevel = -1;
            model.remark = txtRemark.Text;
            model.agentId = adminEntity.id;
            int addId = bll.Add(model);
         
            if (addId>0 && isAgent)
            {
                int xfjine = newMaxNum * agent.agentPrice.Value;//消费金额

                //是代理商 :缴费，扣除金额，增加消费记录
                agent.remainMony -= xfjine;
                agent.userNum += 1;
                agent.wcodeNum += newMaxNum;
                bool updateRet= aBll.Update(agent);

                if (updateRet)
                {
                    BLL.wx_manager_bill bBll = new BLL.wx_manager_bill();
                    Model.wx_manager_bill bill = new Model.wx_manager_bill();
                    bill.billMoney = xfjine;
                    bill.managerId = agent.managerId;
                    bill.operPersonId = agent.managerId;
                    bill.operDate = DateTime.Now;
                    bill.billUsed = "开通1个用户"+ model.user_name+"的" + newMaxNum + "个微帐号";
                    bill.moneyType = "扣减";
                   int addBillId= bBll.Add(bill);
                   
                }
                else
                {
                    bll.Delete(addId);
                    addId = 0;
                }
            }
             
            if (addId> 0)
            {

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加用户:" + model.user_name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            int oldMaxNum = MyCommFun.Str2Int(hidOldMaxNum.Value);
            int newMaxNum = MyCommFun.Str2Int(ddlMaxNum.SelectedItem.Value);
            int addNewNum = newMaxNum - oldMaxNum; //新增的帐号
         

            Model.manager adminEntity = GetAdminInfo(); //取得管理员信息
            Model.wx_agent_info agent = new Model.wx_agent_info();
            bool isAgent = false;
            if (adminEntity.agentLevel < 0)
            {
                return false;
            }
            if (adminEntity.agentLevel > 0)
            {
                agent = aBll.GetAgentModel(adminEntity.id);
                isAgent = true;
                if (agent.remainMony < agent.agentPrice * addNewNum)
                {
                    JscriptMsg("余额不足，请联系管理员充值！", "", "Error");
                    return false;
                }
            }
            

            //地区
            string prov = ddlProvince.SelectedItem.Value;
            string city = ddlCity.SelectedItem.Value;
            string dist = txtArea.Text.Trim();


            bool result = false;
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);

            model.role_id = int.Parse(ddlRoleId.SelectedValue);
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
            model.wxNum = int.Parse(ddlMaxNum.SelectedItem.Value);

            model.qq = txtqq.Text;
            model.email = txtEmail.Text;
          
            model.province = prov;
            model.city = city;
            model.county = dist;
            model.sort_id = MyCommFun.Str2Int(txtSortid.Text);
            model.remark = txtRemark.Text;
          
            bool updateRet = bll.Update(model);

            if (updateRet && isAgent && addNewNum > 0)
            {
                int xfjine = addNewNum * agent.agentPrice.Value;//消费金额

                agent.remainMony -= xfjine;
                agent.wcodeNum += newMaxNum;

                bool updateRet2 = aBll.Update(agent);
                if (updateRet2)
                {
                    BLL.wx_manager_bill bBll = new BLL.wx_manager_bill();
                    Model.wx_manager_bill bill = new Model.wx_manager_bill();
                    bill.billMoney = xfjine;
                    bill.managerId = agent.managerId;
                    bill.operPersonId = agent.managerId;
                    bill.operDate = DateTime.Now;
                    bill.billUsed = "原用户" + model.user_name + "新增了" + addNewNum + "个微帐号";
                    bill.moneyType = "扣减";
                    int addBillId = bBll.Add(bill);

                }
                else
                {
                    bll.Delete(_id);
                    updateRet=false;
                }
 
            }

            if (updateRet)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改用户:" + model.user_name); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int oldMaxNum =MyCommFun.Str2Int( hidOldMaxNum.Value);
            int newMaxNum = MyCommFun.Str2Int(ddlMaxNum.SelectedItem.Value);

            if (newMaxNum < oldMaxNum)
            {
                JscriptMsg("微信帐号数量不能小于原来的微信帐号数量！", "", "Error");
                return;
            }
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("manager_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改用户信息成功！", "manager_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("manager_list", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加用户信息成功！", "manager_list.aspx", "Success");
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