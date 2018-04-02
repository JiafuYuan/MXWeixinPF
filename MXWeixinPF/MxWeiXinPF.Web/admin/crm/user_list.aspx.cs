using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.WeiXinComm;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class user_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string status = "";
        protected int group_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("fensimgr", MXEnums.ActionEnum.View.ToString()); //检查权限
            this.group_id = MXRequest.GetQueryInt("group_id");
            status = MXRequest.GetQueryString("status");
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ValidAccessToken();

                GroupBind(); //绑定类别

                Model.wx_userweixin weixin = GetWeiXinCode();
                RptBind("u.wid=" + weixin.id + " " + CombSqlTxt(this.status,this.group_id, this.keywords), "groupid desc,id desc");
            }
        }

        #region 绑定组别=================================
        private void GroupBind()
        {
            BLL.wx_crm_group gBll = new BLL.wx_crm_group();
            Model.wx_userweixin weixin = GetWeiXinCode();
            IList<Model.wx_crm_group> grouplist = gBll.GetModelList("wid=" + weixin.id);

            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("所有分组", "-1"));
            if (grouplist == null)
            {
                return;
            }
            foreach (Model.wx_crm_group g in grouplist)
            {
                string iName = g.name + "(" + g.count.Value.ToString() + ")";
                this.ddlGroupId.Items.Add(new ListItem(iName, g.id.ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = MXRequest.GetQueryInt("page", 1);
            if (this.group_id > 0)
            {
                this.ddlGroupId.SelectedValue = this.group_id.ToString();
            }
            if (this.status.Trim().Length > 0)
            {
                this.ddlstatus.SelectedValue = this.status.ToString();
            }
           
            this.txtKeywords.Text = this.keywords;


            BLL.wx_crm_users bll = new BLL.wx_crm_users();
            DataSet ds = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    dr["subscribe_time"] = MyCommFun.GetTime(dr["subscribe_time"].ToString()).ToString();
                }
            }
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_list.aspx", "status={0}&group_id={1}&keywords={2}&page={3}",
            this.status.ToString(),this.group_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string status,int _group_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            
            if (_group_id > 0)
            {
                strTemp.Append(" and u.groupId=" + _group_id);
            }
            if (status.Trim().Length > 0)
            {
                strTemp.Append(" and u.uStatus="+status); 
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (u.nickname like '%" + _keywords + "%' or u.city like '%" + _keywords + "%' or g.[name] like '%" + _keywords + "%' or t.tag like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 返回用户性别=============================


        /// <summary>
        /// 获得用户的性别
        /// </summary>
        /// <param name="sexNum"></param>
        /// <returns></returns>
        protected string GetUserSex(int sexNum)
        {
            string result = string.Empty;
            switch (sexNum)
            {
                case 0:
                    result = "未知";
                    break;
                case 1:
                    result = "男";
                    break;
                case 2:
                    result = "女";
                    break;

            }
            return result;
        }

        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "status={0}&group_id={1}&keywords={2}",
               status.ToString(), this.group_id.ToString(), txtKeywords.Text));
        }

        //筛选类别
        protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "status={0}&group_id={1}&keywords={2}",
                 status.ToString(), ddlGroupId.SelectedValue, this.keywords));
        }

        //筛选状态
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "status={0}&group_id={1}&keywords={2}",
               ddlstatus.SelectedValue, this.group_id.ToString(), this.keywords));
        }


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), this.keywords));
        }


        #region 粉丝同步的方法

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
                if (setting == null || setting.personSynDate == null)
                {
                    lblInfo.Text = "请点击按钮更新分组信息";
                }
                else
                {
                    lblInfo.Text = "上次更新时间为：" + setting.personSynDate.Value;
                }
                return true;
            }

        }

        /// <summary>
        ///同步按钮 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            BLL.wx_crm_users uBll = new BLL.wx_crm_users();


            //更新时间，作为一个标记
            DateTime updateTime = DateTime.Now;
            try
            {
               string ret= SysPersonFun(0, weixin.id, accessToken, "", updateTime);
                //查找此次为同步到的，则为已经跑路的
                IList<Model.wx_crm_users> userlist = uBll.GetModelList("updateDate<'" + updateTime.ToString() + "'");
                if (userlist != null && userlist.Count > 0)
                {
                    for (int i = 0; i < userlist.Count; i++)
                    {
                        userlist[i].uStatus = 2;
                        uBll.Update(userlist[i]);

                    }
                }

                JscriptMsg(ret, "user_list.aspx", "Success");

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

        }

        /// <summary>
        /// 同步处理，递归算法
        /// </summary>
        /// <param name="totCount"></param>
        /// <param name="wid"></param>
        /// <param name="accessToken"></param>
        /// <param name="nexOpenid"></param>
        /// <param name="updateTime"></param>
        public string  SysPersonFun(int totCount, int wid, string accessToken, string nexOpenid, DateTime updateTime)
        {
            string ret = "";

            OpenIdResultJson gJson = Senparc.Weixin.MP.AdvancedAPIs.User.Get(accessToken, nexOpenid);

            List<string> openidStr = gJson.data.openid;//此次拉取的openid字符串

            totCount += InsertUserInfo(wid, accessToken, openidStr, updateTime);


            if (gJson.next_openid != "" && gJson.count == 1000)
            {
                SysPersonFun(totCount, wid, accessToken, gJson.next_openid, updateTime);
            }
            else
            {
                int sjTtCount = gJson.total;
                if (sjTtCount == totCount)
                {
                    //将此次同步的日期更新到设置表里
                    BLL.wx_crm_setting setBll = new BLL.wx_crm_setting();
                    setBll.UpdatePersonSysDate(wid, totCount, updateTime);
                  ret=  "粉丝同步成功！";
                }
                else
                {
                   ret= "粉丝同步失败！";
                }

            }

            return ret;
        }

        /// <summary>
        /// 同步一个用户信息，如果库里存在，则修改，不存在，则新增
        /// </summary>
        /// <param name="userDetail"></param>
        private int InsertUserInfo(int wid, string accessToken, List<string> openidStr, DateTime updateTime)
        {
            int totCount = 0;
            //   将数据插入到数据库里
            BLL.wx_crm_users uBll = new BLL.wx_crm_users();
            Model.wx_crm_users uEntity = new Model.wx_crm_users();
            try
            {


                UserInfoJson userDetail = new UserInfoJson();
                for (int i = 0; i < openidStr.Count; i++)
                {

                    userDetail = Senparc.Weixin.MP.AdvancedAPIs.User.Info(accessToken, openidStr[i]);
                    uEntity = uBll.GetModel(wid, openidStr[i]);
                    bool isAdd = true;
                    if (uEntity == null)
                    {
                        isAdd = true;
                        uEntity = new Model.wx_crm_users();
                    }
                    else
                    {
                        isAdd = false;
                    }
                    uEntity.wid = wid;
                    uEntity.openid = openidStr[i];
                    uEntity.nickname = userDetail.nickname;
                    uEntity.sex = userDetail.sex.ToString();
                    uEntity.city = userDetail.city;
                    uEntity.country = userDetail.country;
                    uEntity.province = userDetail.province;
                    uEntity.language = userDetail.language;
                    uEntity.headimgurl = userDetail.headimgurl;
                    uEntity.subscribe_time = userDetail.subscribe_time.ToString();

                    uEntity.updateDate = updateTime;
                    uEntity.uStatus = 1;

                    //查询分组号
                    GetGroupIdResult gid = Groups.GetId(accessToken, openidStr[i]);
                    uEntity.groupId = gid.groupid;

                    if (isAdd)
                    {
                        //新增
                        uEntity.createDate = DateTime.Now;
                        int succ = uBll.Add(uEntity);
                        if (succ > 0)
                        {
                            totCount++;
                        }
                    }
                    else
                    {
                        //修改
                        bool succ = uBll.Update(uEntity);
                        if (succ)
                        {
                            totCount++;
                        }
                    }


                }
                return totCount;
            }
            catch (Exception ex)
            {
                throw new Exception("用户信息同步失败！" + ex.Message);

            }

        }


        #endregion



    }
}