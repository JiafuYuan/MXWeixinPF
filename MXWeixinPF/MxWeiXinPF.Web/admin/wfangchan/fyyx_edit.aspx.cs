using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class fyyx_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型 
        private int id = 0;
        protected int fid;
        BLL.wx_fc_fyImpression bll = new BLL.wx_fc_fyImpression();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            fid = MXRequest.GetQueryInt("fid");
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
            Model.wx_fc_fyImpression model = bll.GetModel(_id);
            this.txtTitle.Text = model.content;
            this.txtSort_id.Text = model.sort_id.ToString();
            this.txtNum.Text = model.quantity.ToString();

        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_fyImpression model = new Model.wx_fc_fyImpression();
            bool result = false;
            model.fid = fid; 
            model.createDate = DateTime.Now;
            model.wid = weixin.id;
            model.content = this.txtTitle.Text;
            model.quantity = MyCommFun.Str2Int(this.txtNum.Text);
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加房友印象记录:" + model.content); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_fyImpression model = bll.GetModel(_id);
            bool result = false;

            model.content = this.txtTitle.Text;
            model.quantity = MyCommFun.Str2Int(this.txtNum.Text);
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改房友印象id:" + model.Id); //记录日志
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
                JscriptMsg("修改信息成功！", "fyyxMgr.aspx?id=" + fid, "Success");
            }
            else //添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "fyyxMgr.aspx?id=" + fid, "Success");
            }
        }
    }
}