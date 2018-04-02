using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Text;
namespace MxWeiXinPF.Web.admin.magazine
{
    public partial class mz_img_list : Web.UI.ManagePage
    {
        protected int mzid;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mzid = MXRequest.GetQueryInt("mzid");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("magazine", MXEnums.ActionEnum.View.ToString()); //检查权限 
                RptBind("id>0 and mid=" + mzid, "sort_id asc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            this.page = MXRequest.GetQueryInt("page", 1);

            //图表或列表显示
            BLL.wx_mz_img bll = new BLL.wx_mz_img();
            this.rptList2.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList2.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("mz_img_list.aspx", "page={0}&mzid={1}",
                 "__id__", mzid.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("mz_img_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("magazine", MXEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.wx_mz_img bll = new BLL.wx_mz_img();
            Repeater rptList = new Repeater();
            rptList = this.rptList2;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "保存杂志图片排序"); //记录日志
            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt("mz_img_list.aspx", "keywords={0}&mzid={1}",
                this.keywords, mzid.ToString()), "Success");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("magazine", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            BLL.wx_mz_img bll = new BLL.wx_mz_img();
            Repeater rptList = this.rptList2;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除 条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("mz_img_list.aspx", "keywords={0}&mzid={1}",
                 this.keywords, mzid.ToString()), "Success");
        }

        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("mz_img_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("mz_img_list.aspx", "keywords={0}&mzid={1}",
                 this.keywords, mzid.ToString()));
        }

    }
}