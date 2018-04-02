using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class user_tag : Web.UI.ManagePage
    {

        private int id = 0;
        public  string prov = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            this.id = MXRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_list", MXEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(this.id);

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_crm_users uBll = new BLL.wx_crm_users();
            Model.wx_crm_users user = uBll.GetModel(_id);

            BLL.wx_crm_group gBll = new BLL.wx_crm_group();
            Model.wx_crm_group group = gBll.GetModel(user.groupId.Value);

            BLL.wx_crm_users_tag tBll = new BLL.wx_crm_users_tag();
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_crm_users_tag tagEntity = tBll.GetModelByWidAndOpenid(weixin.id, user.openid);

           

            lblnickname.Text = user.nickname;
            imgPhoto.ImageUrl = user.headimgurl;

            lblSex.Text = GetUserSex(int.Parse(user.sex));

            lblArea.Text = user.country + " " + user.province + " " + user.city;
            lblsubscribe_time.Text = MyCommFun.GetTime(user.subscribe_time).ToString();

            prov = user.province;
         

            if (group != null)
            {
                lblGroupName.Text = group.name;
            }

            if (tagEntity != null)
            {
                hidtagId.Value = tagEntity.id.ToString();
                txtTag.Text = tagEntity.tag;
            }

            hidWid.Value = user.wid.ToString();
            hidOpenid.Value = user.openid;

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

        #region 修改操作=================================
        private bool DoEdit()
        {

            BLL.wx_crm_users_tag tagBll = new BLL.wx_crm_users_tag();

            int tagId = int.Parse(hidtagId.Value);
            Model.wx_crm_users_tag tagEntity = new Model.wx_crm_users_tag();

            if (tagId > 0)
            { //修改
                tagEntity = tagBll.GetModel(tagId);
                tagEntity.tag = txtTag.Text.Trim();
                return tagBll.Update(tagEntity);
            }
            else
            {   //新增
                tagEntity.wid = int.Parse(hidWid.Value);
                tagEntity.openid = hidOpenid.Value;
                tagEntity.tag = txtTag.Text.Trim();
                tagEntity.createDate = DateTime.Now;
                int ret = tagBll.Add(tagEntity);
                if (ret > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }




        }


         

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ChkAdminLevel("user_list", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit())
            {
                JscriptMsg("设置用户标签中发生错误！", "", "Error");
                return;
            }
            
            JscriptMsg("设置用户成功！", "user_list.aspx", "Success");

        }



        #endregion
    }
}