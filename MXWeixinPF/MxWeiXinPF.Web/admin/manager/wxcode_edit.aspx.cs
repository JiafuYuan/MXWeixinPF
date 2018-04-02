using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;
namespace MxWeiXinPF.Web.admin.manager
{
    public partial class wxcode_edit : Web.UI.ManagePage
    {
        BLL.wx_userweixin bll = new BLL.wx_userweixin();
        BLL.wx_agent_info aBll = new BLL.wx_agent_info();
        Model.manager adminEntity = new Model.manager();
        Model.wx_agent_info agent = new Model.wx_agent_info();
        protected string returnPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
             adminEntity = GetAdminInfo(); //取得管理员信息
             agent = aBll.GetAgentModel(adminEntity.id);
            if (!Page.IsPostBack)
            {
                 int id = 0;

                if (!int.TryParse(Request.QueryString["id"] as string, out id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_userweixin().Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
                returnPage = "wxcodemgr.aspx";
                //如果是从微用户管理里来的，还得判断下
                if (MyCommFun.QueryString("fpage").Trim().Length > 0 && MyCommFun.RequestInt("uid") > 0)
                {
                    returnPage = "weixin_list.aspx?id=" + MyCommFun.RequestInt("uid");
                }
                ShowInfo(id);
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {

            Model.wx_userweixin model = bll.GetModel(id);
            lblId.Text = model.id.ToString();
            this.txtwxName.Text = model.wxName;
            this.txtwxId.Text = model.wxId;
            this.txtweixinCode.Text = model.weixinCode;
            this.txtImgUrl.Text = model.headerpic;
            this.txtapiurl.Text =MyCommFun.getWebSite()+"/api/weixin/api.aspx?apiid="+ model.id;
            this.txtwxToken.Text = model.wxToken;
            if(model.wStatus!=null && model.wStatus==0)
            {
                this.rblwStatus.SelectedValue = "0";
            }
            

            this.txtAppId.Text = model.AppId;
            this.txtAppSecret.Text = model.AppSecret;
           // txtEndTime.Text = model.endDate.Value.ToString("yyyy-MM-dd");
            lblEndDate.Text = model.endDate.Value.ToString("yyyy-MM-dd");
            lblAddDate.Text = model.createDate.Value.ToString("yyyy-MM-dd");
            lblEndDate.Font.Bold = true;
            if (model.endDate < DateTime.Now)
            {
                //过期
                lblEndDate.ForeColor = System.Drawing.Color.Red;
                lblEndDate.Text += "[已过期]";

            }
            else if (model.endDate <= DateTime.Now.AddDays(20))
            {
                //快到期
                TimeSpan ts = model.endDate.Value - DateTime.Now;
                int sub = ts.Days;  
                lblEndDate.ForeColor = System.Drawing.Color.Red;
                lblEndDate.Text += " [还有" + sub + "天到期]";
              
            }
            else
            { 
                
            }

            //代理商信息
            if (agent != null)
            {
                lblremainMony.Text = agent.remainMony.Value.ToString();
                lblagentPrice.Text = agent.agentPrice.Value.ToString();
            }

        }

        #endregion



        #region 修改操作=================================
        private bool DoEdit()
        {
            int _id =MyCommFun.Str2Int(lblId.Text);
            string strErr = "";
            if (this.txtwxName.Text.Trim().Length == 0)
            {
                strErr += "公众帐号名称不能为空！";
            }
            if (this.txtwxId.Text.Trim().Length == 0)
            {
                strErr += "公众号原始id不能为空！";
            }

            if (this.txtweixinCode.Text.Trim().Length == 0)
            {
                strErr += "微信号不能为空！";
            }
            if (this.txtwxToken.Text.Trim().Length == 0)
            {
                strErr += "TOKEN值不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return false;
            }

            string wxName = this.txtwxName.Text;
            string wxId = this.txtwxId.Text;
            string weixinCode = this.txtweixinCode.Text;
            string headerpic = this.txtImgUrl.Text;
            string apiurl = this.txtapiurl.Text;
            string wxToken = this.txtwxToken.Text;
            string AppId = this.txtAppId.Text;
            string AppSecret = this.txtAppSecret.Text;

            Model.wx_userweixin model = bll.GetModel(_id);

            model.wxName = wxName;
            model.wxId = wxId;
            model.weixinCode = weixinCode;
            model.headerpic = headerpic;
            model.apiurl = apiurl;
            model.wxToken = wxToken;
            model.AppId = AppId;
            model.AppSecret = AppSecret;
            model.wStatus =MyCommFun.Str2Int( rblwStatus.SelectedItem.Value);

            int addYear =MyCommFun.Str2Int( ddlMaxNum.SelectedItem.Value);
            if (addYear > 0)
            {
                if (model.endDate.Value >= DateTime.Now)
                {
                    //直接加
                    model.endDate = model.endDate.Value.AddYears(addYear);
                }
                else
                { 
                    //已过期的，直接在当天开始加年份
                    model.endDate = DateTime.Now.AddYears(addYear);
                 }

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
                    else
                    {
                        int xfjine = addYear * agent.agentPrice.Value;//消费金额

                        //是代理商 :缴费，扣除金额，增加消费记录
                        agent.remainMony -= xfjine;
                        bool updateRet = aBll.Update(agent);
                        if (updateRet)
                        {
                            BLL.wx_manager_bill bBll = new BLL.wx_manager_bill();
                            Model.wx_manager_bill bill = new Model.wx_manager_bill();
                            bill.billMoney = xfjine;
                            bill.managerId = agent.managerId;
                            bill.operPersonId = agent.managerId;
                            bill.operDate = DateTime.Now;
                            bill.billUsed = "微帐号" + model.wxName + "增加时间" + addYear + "年";
                            bill.moneyType = "扣减";
                            int addBillId = bBll.Add(bill);

                        }
                        else
                        {
                            JscriptMsg("数据执行错误，请重新操作！", "", "Error");
                            return false;
                        }
                    }
                }
               
            }

            bool ret = bll.Update(model);

            if (ret)
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "【管理】修改微信号，主键为:" + model.id + ",微信号为：" + model.weixinCode); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (!DoEdit())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            //如果是从微用户管理里来的，还得判断下
            if (MyCommFun.QueryString("fpage").Trim().Length > 0 && MyCommFun.RequestInt("uid") > 0)
            {
                returnPage = "weixin_list.aspx?id=" + MyCommFun.RequestInt("uid");
                JscriptMsg("修改微信公众帐号信息成功！", returnPage, "Success");
            }
            else
            {
                JscriptMsg("修改微信公众帐号信息成功！", "wxcodemgr.aspx", "Success");
            }
        }


    }
}