using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.agent
{
    public partial class myaccount : Web.UI.ManagePage
    {
        Model.manager adminEntity = new Model.manager();
        Model.wx_agent_info agent = new Model.wx_agent_info();
        BLL.wx_agent_info aBll = new BLL.wx_agent_info();
        protected void Page_Load(object sender, EventArgs e)
        {
            adminEntity = GetAdminInfo(); //取得管理员信息
            agent = aBll.GetAgentModel(adminEntity.id);
            if (agent != null)
            {
                txtuser_name.Text = adminEntity.user_name;
                txtreal_name.Text = adminEntity.real_name;
                txtremainMony.Text = agent.remainMony.ToString();
                txtremainMony.Font.Size = FontUnit.Large;
                if (agent.remainMony < agent.agentPrice)
                {
                    txtremainMony.ForeColor = System.Drawing.Color.Red;
                   
                }

                txtczTotMoney.Text = agent.czTotMoney.Value.ToString();
                txtsqJine.Text = agent.sqJine.Value.ToString();
                lblxfTotMoney.Text = (agent.czTotMoney.Value - agent.remainMony.Value).ToString();

                txtuserNum.Text = agent.userNum.Value.ToString();
                txtwcodeNum.Text = agent.wcodeNum.Value.ToString();

                lblagentPrice.Text = agent.agentPrice.Value.ToString();

            }
        }
    }
}