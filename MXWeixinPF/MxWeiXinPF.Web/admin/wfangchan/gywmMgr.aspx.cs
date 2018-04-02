using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MxWeiXinPF.Common;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class gywmMgr : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型 
        private int id = 0;
        protected int fid;
        protected int record;
        BLL.wx_fc_aboutWe bll = new BLL.wx_fc_aboutWe();
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = MXRequest.GetQueryInt("id");
            record = bll.GetRecordCount(" fid=" + fid);
            if (record > 0)
                id = bll.GetModelList(" fid=" + fid)[0].Id;
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.View.ToString()); //检查权限  
                if (record > 0)//修改,否则添加
                {
                    ShowInfo(this.id);
                }
            }
        }


        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.wx_fc_aboutWe model = bll.GetModel(_id);
            this.txtAddress.Text = model.address;
            this.txtDetail.InnerText = model.newsDetail;
            this.txtLatXPoint.Text = model.lngX.ToString();
            this.txtLngYPoint.Text = model.latY.ToString();
            this.txtLogo.Text = model.logoAddress;
            this.imgLogo.ImageUrl = model.logoAddress;
            this.txtMobilephone.Text = model.mobilephone;
            this.txtName.Text = model.name;
            this.txtSort_id.Text = model.sort_id.ToString();
            this.txtTelephone.Text = model.telephone.ToString();


        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_aboutWe model = new Model.wx_fc_aboutWe();
            bool result = false;
            model.address = this.txtAddress.Text;
            model.createDate = DateTime.Now;
            model.latY = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.logoAddress = this.txtLogo.Text;
            model.mobilephone = this.txtMobilephone.Text;
            model.name = this.txtName.Text;
            model.newsDetail = this.txtDetail.InnerText;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.telephone = this.txtTelephone.Text;
            model.fid = fid;
            model.wid = weixin.id;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加关于我们:" + model.name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_aboutWe model = bll.GetModel(_id);
            bool result = false;
            model.address = this.txtAddress.Text;
            model.latY = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.logoAddress = this.txtLogo.Text;
            model.mobilephone = this.txtMobilephone.Text;
            model.name = this.txtName.Text;
            model.newsDetail = this.txtDetail.InnerText;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.telephone = this.txtTelephone.Text;

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改产品库内容id:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (record > 0) //修改
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "gywmMgr.aspx?id=" + fid, "Success");
            }
            else //添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "gywmMgr.aspx?id=" + fid, "Success");
            }
        }
    }
}