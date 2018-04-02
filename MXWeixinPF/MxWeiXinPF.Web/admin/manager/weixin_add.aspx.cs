using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;
using System.Configuration;

namespace MxWeiXinPF.Web.admin.manager
{
    public partial class weixin_add : Web.UI.ManagePage
    {
        protected int uid = 0;
        BLL.wx_userweixin bll = new BLL.wx_userweixin();
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = MyCommFun.RequestInt("uid", 0);

            //添加，则需要判断可以添加的微信号数量
            if (uid == 0)
            {
                JscriptMsg("参数不正确！", "back", "Error");
                return;
            }
            if (IsChaoGuoWxNum())
            {
                JscriptMsg("该用户微账号的数量已满，无法添加！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("wcodemgr", MXEnums.ActionEnum.View.ToString()); //检查权限
                txtEndData.Text = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                BLL.manager mBll = new BLL.manager();
                Model.manager user = mBll.GetModel(uid);
                lblUserName.Text = user.user_name + " " + user.real_name;

            }
        }

        #region 增加操作=================================
        private bool DoAdd()
        {
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
            if (this.txtEndData.Text.Trim().Length == 0)
            {
                strErr += "到期时间不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");

                return false;
            }

            Model.manager manager = GetAdminInfo();
            int uId = manager.id;
            string wxName = this.txtwxName.Text;
            string wxId = this.txtwxId.Text;

            string weixinCode = this.txtweixinCode.Text;
            string wxPwd = "";
            string headerpic = this.txtImgUrl.Text;
            string apiurl = "";
            string wxToken = this.txtwxToken.Text;
            string wxProvince = "";
            string wxCity = "";
            string AppId = this.txtAppId.Text;
            string AppSecret = this.txtAppSecret.Text;
            DateTime createDate = DateTime.Now;
            DateTime endDate = MyCommFun.Obj2DateTime(txtEndData.Text);


            Model.wx_userweixin model = new Model.wx_userweixin();

            model.uId = this.uid;
            model.wxName = wxName;
            model.wxId = wxId;
            model.yixinId = "";
            model.weixinCode = weixinCode;
            model.wxPwd = wxPwd;
            model.headerpic = headerpic;
            model.apiurl = apiurl;
            model.wxToken = wxToken;
            model.wxProvince = wxProvince;
            model.wxCity = wxCity;
            model.AppId = AppId;
            model.AppSecret = AppSecret;
            model.Access_Token = "";
            model.openIdStr = "";
            model.createDate = createDate;
            model.endDate = endDate;
            model.wenziMaxNum = -1;//-1为无限制
            model.tuwenMaxNum = -1;
            model.yuyinMaxNum = -1;
            model.wenziDefineNum = 0;
            model.tuwenDefineNum = 0;
            model.yuyinDefineNum = 0;
            model.requestTTNum = 0;
            model.requestUsedNum = 0;
            model.smsTTNum = 0;
            model.smsUsedNum = 0;
            model.isDelete = false;
            model.wStatus = 1;
            model.remark = "";
            model.seq = 99;

            if (IsChaoGuoWxNum())
            {
                return false;
            }
            int wId = bll.Add(model);
            if (wId > 0)
            {
                Object obj = ConfigurationManager.AppSettings["industry_defaultAdd"];
                if (obj != null && obj.ToString() == "true")
                {
                    //为微账户添加行业默认模块
                    BLL.manager mBll = new BLL.manager();
                    BLL.wx_industry_defaultModule idBll = new wx_industry_defaultModule();
                    Model.manager user = mBll.GetModel(uid);
                    int roleid = user.role_id;
                    idBll.addMouduleByRoleid(roleid, wId);
                }

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加微信号，主键为:" + model.id + ",微信号为：" + model.weixinCode); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("wcodemgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }

            JscriptMsg("添加微信公众帐号信息成功！", "weixin_list.aspx?id=" + this.uid, "Success");

        }

        /// <summary>
        ///  判断已经有的微信个数，若超过，则不能添加
        /// </summary>
        /// <returns>超过为true,未超过为false</returns>
        private bool IsChaoGuoWxNum()
        {
            BLL.manager mBll = new BLL.manager();
            Model.manager manager = mBll.GetModel(this.uid);

            int hasNum = bll.GetUserWxNumCount(this.uid);
            if (hasNum >= manager.wxNum)
            {
                JscriptMsg("该用户只能添加" + manager.wxNum + "个微信公众帐号,若想添加多个，请联系管理员！", "weixin_list.aspx?id=" + uid, "Error");
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}