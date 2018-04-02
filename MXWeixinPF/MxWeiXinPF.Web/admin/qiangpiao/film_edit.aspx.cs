using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MxWeiXinPF.BLL;
using System.Data;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.qiangpiao
{
    public partial class film_edit : Web.UI.ManagePage
    {
        wx_qp_film bll = new wx_qp_film();
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected string category_id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = MXRequest.GetQueryInt("id");
            string _action = MXRequest.GetQueryString("action");
            this.category_id = MXRequest.GetQueryString("category_id");
            //判断用户权限
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.wx_qp_film().Exists(id))
                {
                    JscriptMsg("此电影不存在或已被删除！", "back", "Error");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                TreeBind();
                // ChkAdminLevel("productlist", MXEnums.ActionEnum.View.ToString()); //检查权限
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }

        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            //Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.wx_qp_base bll = new BLL.wx_qp_base();
            DataTable dt = bll.GetList("id>0").Tables[0];

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择活动...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["bName"].ToString().Trim();
                this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
            }

            ddlCategoryId.SelectedValue = category_id.ToString();
        }
        #endregion

        //新增
        private bool DoAdd()
        {
            bool result = false;
            Model.wx_qp_film model = new Model.wx_qp_film();
            string name = this.txtName.Text;
            string status = this.rblisSnSendsms.SelectedValue;
            DateTime beginDate = DateTime.Parse(this.txtbeginDate.Text.Trim());
            int sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            DateTime endDate = DateTime.Parse(this.txtendDate.Text.Trim());
            int bid = Utils.StrToInt(this.ddlCategoryId.SelectedItem.Value, 0);
            DateTime time = DateTime.Now;

            model.fName = name;
            model.fStatus = status;
            model.sort_id = sort_id;
            model.createDate = time;
            model.fBegin = beginDate;
            model.fEnd = endDate;
            model.bId = bid;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加电影信息:" + model.fName); //记录日志
                result = true;
            }
            return result;
        }

        //赋值操作
        private void ShowInfo(int _id)
        {
            Model.wx_qp_film model = bll.GetModel(_id);
            txtName.Text = model.fName;
            txtbeginDate.Text = model.fBegin.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = model.fEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtSort_id.Text = model.sort_id.ToString();
            ddlCategoryId.SelectedValue = model.bId.ToString();
            rblisSnSendsms.SelectedValue = model.fStatus;
        }

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                Model.wx_qp_film model = bll.GetModel(_id);
                model.sort_id = Utils.StrToInt(txtSort_id.Text.Trim(), 99);
                model.fBegin = DateTime.Parse(this.txtbeginDate.Text.Trim());
                model.fEnd = DateTime.Parse(this.txtendDate.Text.Trim());
                model.bId = Utils.StrToInt(ddlCategoryId.SelectedValue, 99);
                model.fStatus = rblisSnSendsms.SelectedValue;
                model.fName = txtName.Text.Trim();
                if (bll.Update(model))
                {
                    AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改电影信息：" + model.fName); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region  //先判断
            string strErr = "";
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "电影名称不能为空！";
            }
            if (this.txtbeginDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtbeginDate.Text))
            {
                strErr += "开始时间不能为空！";
            }
            if (this.txtendDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtendDate.Text))
            {
                strErr += "结束时间不能为空！";
            }
            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            DateTime begin = DateTime.Parse(txtbeginDate.Text.Trim());
            DateTime end = DateTime.Parse(txtendDate.Text.Trim());
            if (begin >= end)
            {
                JscriptMsg("开始时间必须小于结束时间", "back", "Error");
                return;
            }
            #endregion
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.Edit.ToString()); 检查权限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改类别成功！", "film_list.aspx?id=" + category_id, "Success");
            }
            else //添加
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_category", MXEnums.ActionEnum.Add.ToString());检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加类别成功！", "film_list.aspx?id=" + category_id, "Success");
            }
        }


    }
}