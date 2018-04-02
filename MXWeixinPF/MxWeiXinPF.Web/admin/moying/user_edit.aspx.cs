using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;

namespace MxWeiXinPF.Web.admin.moying
{
    public partial class user_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_my_user userBll = new wx_my_user();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!userBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }
                
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
          
          
            hidid.Value = id.ToString();
            Model.wx_my_user userEntity = userBll.GetModel(id);

         

            //图片
            txtuserpic.Text = userEntity.userpic;
            imguserpic.ImageUrl = userEntity.userpic;

            txtusername.Text = userEntity.username;


            txtuserscore.Text = userEntity.userscore == null ? "0" : userEntity.userscore.Value.ToString();


            txtuseraddr.Text = userEntity.useraddr;
            txtusertel.Text = userEntity.usertel;
            txtuserborn.Text = userEntity.userborn == null ? "" : userEntity.userborn.Value.ToShortDateString();

            txtuseremail.Text = userEntity.useremail.ToString();
            txtuserqq.Text = userEntity.userqq.ToString();
            txtuserpsd.Text = userEntity.userpsd;
            txtusergrade.Text = userEntity.usergrade.ToString();
          
           
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

           
          
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";


            if (this.txtusername.Text.Trim().Length == 0)
            {
                strErr += "用户名不能为空！";
            }
            
           
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            #endregion

            #region 赋值
           

            Model.wx_my_user userEntity = new Model.wx_my_user();
           
            if (id > 0)
            {
                userEntity = userBll.GetModel(id);
            }

            userEntity.username = txtusername.Text.Trim();
            userEntity.userscore =MyCommFun.Obj2Int( txtuserscore.Text);
            userEntity.usergrade =MyCommFun.Obj2Int(txtusergrade.Text);
            userEntity.useraddr = txtuseraddr.Text.ToString();
            userEntity.usertel = txtusertel.Text;
            userEntity.userborn = MyCommFun.Obj2DateTime(txtuserborn.Text);
            userEntity.useremail = txtuseremail.Text.Trim();
            userEntity.userpsd = txtuserpsd.Text.Trim();
            userEntity.userqq = txtuserqq.Text.Trim();
            userEntity.userpic = txtuserpic.Text.Trim();
            

            #endregion

            if (id <= 0)
            {  //新增
                userEntity.wid = weixin.id;
                
                //1新增主表
                id = userBll.Add(userEntity);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加体检-用户信息，主键为" + id); //记录日志
                JscriptMsg("添用户信息成功！", "user_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                userBll.Update(userEntity);



                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改用户信息，主键为" + id); //记录日志
                JscriptMsg("修改用户信息成功！", "user_list.aspx", "Success");
            }

        }
    }
}