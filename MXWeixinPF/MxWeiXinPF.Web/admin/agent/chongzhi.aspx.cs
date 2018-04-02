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
    public partial class chongzhi : Web.UI.ManagePage
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
                if (id <= 0)
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
         
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            //ddlRoleId.SelectedValue = model.role_id.ToString();

            lblUserName.Text = model.user_name;

            lblRealName.Text = model.real_name;
         
            //代理商信息
            Model.wx_agent_info agentinfo = aBll.GetAgentModel(_id);

            lblYue.Text = agentinfo.remainMony.Value.ToString();
            lbltxtsqJine.Text = agentinfo.sqJine.Value.ToString();
            lblagentPrice.Text = agentinfo.agentPrice.Value.ToString();
            lblagentLevel.Text = agentinfo.agentLevel;

        }
        #endregion

        #region 充值操作=================================
        private bool DoEdit(int _id)
        {
                Model.wx_agent_info agentinfo = aBll.GetAgentModel(_id);
                int money = MyCommFun.Str2Int(txtMoney.Text.Trim());
                agentinfo.remainMony += money;
                agentinfo.czTotMoney += money;
                bool agentid = aBll.Update(agentinfo);
                if (agentid)
                {
                    //新增充值记录
                    BLL.wx_manager_bill bBll = new BLL.wx_manager_bill();
                    Model.wx_manager_bill bill = new Model.wx_manager_bill();
                    bill.managerId = _id;
                    bill.operPersonId = GetAdminInfo().id;
                    bill.operDate = DateTime.Now;
                    bill.moneyType = "充值";
                    bill.billUsed = "代理商充值";
                    bill.billMoney = money;
                    bBll.Add(bill);

                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改代理充值成功:" + agentinfo.managerId); //记录日志
                    return true;
                }
                else
                {

                    return false;
                }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string f = MyCommFun.QueryString("f");

            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("agent_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                if (f == "bill")
                {
                    JscriptMsg("代理商充值成功！", "bill_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("代理商充值成功！", "agent_list.aspx", "Success");
                }
            }
            
        }
    }
}