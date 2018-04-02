using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;
namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class yy_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型 
        private int id = 0;
        BLL.wx_fc_yySysset bll = new BLL.wx_fc_yySysset();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!bll.Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.View.ToString()); //检查权限

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }

        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.wx_fc_yySysset bll = new BLL.wx_fc_yySysset();
            Model.wx_fc_yySysset model = bll.GetModel(_id);
            this.txtAddress.Text = model.address;
            this.txtddHeadimg.Text = model.headImg;
            this.txtDetail.Text = model.detail;
            this.txtLatXPoint.Text = model.lngX.ToString();
            this.txtLngYPoint.Text = model.latY.ToString();
            this.txtTelephone.Text = model.telephone;
            this.txtSort_id.Text = model.sort_id.ToString();
            this.imgddHeadimg.ImageUrl = model.headImg;
        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_yySysset model = new Model.wx_fc_yySysset();
            bool result = false;
            model.headImg = this.txtddHeadimg.Text;
            model.latY = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.telephone = this.txtTelephone.Text;
            model.wid = weixin.id;
            model.address=this.txtAddress.Text;
            model.createdate = DateTime.Now;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.detail = this.txtDetail.Text;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加预约系统设置:" + model.address); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_yySysset model = bll.GetModel(_id);
            bool result = false;
            model.address = this.txtAddress.Text;
            model.headImg = this.txtddHeadimg.Text;
            model.latY = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.telephone = this.txtTelephone.Text;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.detail = this.txtDetail.Text;
            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改预约系统设置,id:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "yyMgr.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "yyMgr.aspx", "Success");
            }
        }
    }
}