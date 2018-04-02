using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.magazine
{
    public partial class magazine_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        BLL.wx_mz_magazine bll = new BLL.wx_mz_magazine();
        protected void Page_Load(object sender, EventArgs e)
        {
            action = MXRequest.GetQueryString("action");
            id = MXRequest.GetQueryInt("id");
            if (!IsPostBack)
            {
                if (action == MXEnums.ActionEnum.Edit.ToString() && id > 0)//修改
                {
                    showInfo(id);
                }
            }
        }

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.wx_mz_magazine model = new Model.wx_mz_magazine();
            model.isbackmusic = this.needMusic.SelectedItem.Value;
            model.isrepeat = this.needRepeat.SelectedItem.Value;
            model.mname = this.txtName.Text;
            model.mremark = this.txtRemark.InnerText;
            model.sort_id = MyCommFun.Str2Int(this.txtSortId.Text);
            model.footurl = this.txtUrl.Text;
            model.footimg = this.txtFootimg.Text;
            model.createdate = DateTime.Now;
            model.coverimg = this.txtCoverImg.Text;
            model.cleanimg = this.txtCleanimg.Text;
            model.backmusic = this.txtGroundmusic.Text;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "微网站添加海报内容:" + model.mname); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            Model.wx_mz_magazine model = bll.GetModel(_id);
            model.isbackmusic = this.needMusic.SelectedItem.Value;
            model.isrepeat = this.needRepeat.SelectedItem.Value;
            model.mname = this.txtName.Text;
            model.mremark = this.txtRemark.InnerText;
            model.sort_id = MyCommFun.Str2Int(this.txtSortId.Text);
            model.footurl = this.txtUrl.Text;
            model.footimg = this.txtFootimg.Text;
            model.coverimg = this.txtCoverImg.Text;
            model.cleanimg = this.txtCleanimg.Text;
            model.backmusic = this.txtGroundmusic.Text;

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "微网站修改海报内容:" + model.mname); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 赋值操作
        public void showInfo(int _id)
        {
            Model.wx_mz_magazine model = bll.GetModel(_id);
            this.txtCleanimg.Text = model.cleanimg;
            this.txtCoverImg.Text = model.coverimg;
            this.txtFootimg.Text = model.footimg;
            this.txtGroundmusic.Text = model.backmusic;
            this.txtName.Text = model.mname;
            this.txtRemark.InnerText = model.mremark;
            this.txtSortId.Text = model.sort_id.ToString();
            this.txtUrl.Text = model.footurl;
            this.needMusic.SelectedValue = model.isbackmusic == "1" ? "1" : "2";
            this.needRepeat.SelectedValue = model.isrepeat == "1" ? "1" : "2";

        }
        #endregion

        //保存操作
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("magazine", MXEnums.ActionEnum.Edit.ToString());//检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "magazien_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("magazine", MXEnums.ActionEnum.Add.ToString());//检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "magazien_list.aspx", "Success");
            }
        }
    }
}