using MxWeiXinPF.WeiXinComm;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class group_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidAccessToken();
                BindAllGroup();
            }

        }

        /// <summary>
        /// 验证accesstoken
        /// </summary>
        /// <returns></returns>
        public bool ValidAccessToken()
        {
            string err = "";
            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm wcr = new WeiXinCRMComm();
            string accessToken = wcr.getAccessToken(weixin.id, out err);
            if (err != "")
            {
                lblInfo.Text = "该功能仅限于认证过的服务号，其他的都无法使用！AccessToken获取失败，请检查AppId和AppSecret填写是否正确！错误信息如下：" + err;
                lblInfo.ForeColor = System.Drawing.Color.Red;
                btnSyn.Enabled = false;
                btnSyn.Style.Add("display", "none");
                hidErr.Value = lblInfo.Text;
                MessageBox.ResponseScript(this, " $(\"#btn_anniu\").hide();");
                return false;
            }
            else
            {
                hidErr.Value = "";
                //获取上次更新的时间
                BLL.wx_crm_setting setBll = new BLL.wx_crm_setting();
                Model.wx_crm_setting setting = setBll.GetModelByWid(weixin.id);
                if (setting == null || setting.groupSynDate == null)
                {
                    lblInfo.Text = "请点击按钮更新分组信息";
                }
                else
                {
                    lblInfo.Text = "上次更新时间为："+setting.groupSynDate.Value;
                }
                return true;
            }
           
        }

          //同步
        protected void btnSyn_Click(object sender, EventArgs e)
        {
            string err = "";
            Model.wx_userweixin weixin = GetWeiXinCode();
            WeiXinCRMComm wcr = new WeiXinCRMComm();
            string accessToken = wcr.getAccessToken(weixin.id, out err);
            if (err != "")
            {
                return;
            }
            GroupsJson gJson = Groups.Get(accessToken);
            List<GroupsJson_Group> gjg = gJson.groups;

            #region   将数据插入到数据库里
            BLL.wx_crm_group gBll = new BLL.wx_crm_group();
            Model.wx_crm_group group = new Model.wx_crm_group();
            try
            {
                gBll.DeleteByWid(weixin.id);

                int ttCount = gjg.Count;
                int insertCount = 0;
                for (int i = 0; i < gjg.Count; i++)
                {
                    group.id = gjg[i].id;
                    group.name = gjg[i].name;
                    group.count = gjg[i].count;
                    group.wid = weixin.id;
                     bool succ=gBll.Add(group);
                     if (succ)
                     {
                         insertCount++;
                     }
                }
                if (ttCount == insertCount)
                {
                    //将此次同步的日期更新到设置表里
                    BLL.wx_crm_setting setBll = new BLL.wx_crm_setting();
                    setBll.UpdateGroupSysDate(weixin.id, ttCount, DateTime.Now);
                    JscriptMsg("分组同步成功！", "group_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("分组同步失败！", "", "Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                JscriptMsg("分组同步失败！"+ex.Message, "", "Error");
                return;
            }
            #endregion

        }

        protected void BindAllGroup()
        {
              Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.wx_crm_group gBll = new BLL.wx_crm_group();
            IList<Model.wx_crm_group> gList = gBll.GetModelList("wid="+weixin.id);
            rptList.DataSource = gList;
            rptList.DataBind();

        }
    }
}