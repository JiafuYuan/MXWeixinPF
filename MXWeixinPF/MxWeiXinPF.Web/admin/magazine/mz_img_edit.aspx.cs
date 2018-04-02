using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.magazine
{
    public partial class mz_img_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected int mzid;
        BLL.wx_mz_img bll = new BLL.wx_mz_img();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = MXRequest.GetQueryInt("id");
            mzid = MXRequest.GetQueryInt("mzid");
            action = MXRequest.GetQueryString("action");
            if (!IsPostBack)
            {
                if (action == MXEnums.ActionEnum.Edit.ToString())
                {
                    showInfo(id);
                }
            }
        }

        #region 显示信息
        void showInfo(int _id)
        {
            Model.wx_mz_img model = bll.GetModel(_id);
            this.txtImgUrl.Text = model.url;
            this.txtSortId.Text = model.sort_id.ToString();
        }
        #endregion

        #region 修改
        bool DoEdit(int _id)
        {
            bool result = false;
            Model.wx_mz_img model = bll.GetModel(_id);
            model.sort_id = MyCommFun.Str2Int(this.txtSortId.Text);
            model.url = this.txtImgUrl.Text;
            model.mid = mzid;
            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改图片内容"); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 添加
        bool DoAdd()
        {
            bool result = false;
            Model.wx_mz_img model = new Model.wx_mz_img();
            model.mid = mzid;
            model.sort_id = MyCommFun.Str2Int(this.txtSortId.Text);
            model.url = this.txtImgUrl.Text;
            model.createdate = DateTime.Now;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加图片内容"); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("magazine", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("修改过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "mz_img_list.aspx?mzid=" + mzid, "Success");
            }
            else //添加
            {
                ChkAdminLevel("magazine", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "mz_img_list.aspx?mzid=" + mzid, "Success");
            }
        }
    }
}