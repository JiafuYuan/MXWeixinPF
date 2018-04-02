using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;


namespace MxWeiXinPF.Web.admin.qiangpiao
{
    public partial class action_list : Web.UI.ManagePage
    {
       
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");
          
            this.pageSize = GetPageSize(10); //每页数量

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("qiaopiao", MXEnums.ActionEnum.View.ToString()); //检查权限

                RptBind("id>0" + CombSqlTxt(this.keywords), "sort_id asc,id desc");
            }
        }



        #region 数据绑定=================================
        private void RptBind(  string _strWhere, string _orderby)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            this.page = MXRequest.GetQueryInt("page", 1);

            this.txtKeywords.Text = this.keywords;
            //图表或列表显示
            BLL.wx_qp_base bll = new BLL.wx_qp_base();

            _strWhere = "wid=" + weixin.id +" and "+ _strWhere;
            DataSet ds = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                int cout = ds.Tables[0].Rows.Count;
                for (int i = 0; i < cout; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    dr["link_url"]="<a href=\"javascript:;\">" + MyCommFun.getWebSite() + "/weixin/qiangpiao/index.aspx?wid=" + MyCommFun.ObjToStr(dr["wid"]) + "&aid=" + dr["id"].ToString() + "</a>";
                }
                ds.AcceptChanges();
            }
            this.rptList1.DataSource = ds;
            this.rptList1.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("action_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and bName like '%" + _keywords + "%'");
            }
            
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("action_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("action_list.aspx", "keywords={0}",
                 txtKeywords.Text ));
        }


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("action_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("action_list.aspx", "keywords={0}",
                this.keywords ));
        }

       

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("qiaopiao", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0; //成功数量
            int errorCount = 0; //失败数量
            BLL.wx_qp_base bll = new BLL.wx_qp_base();
            Repeater rptList = new Repeater();
            rptList = this.rptList1;

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
            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "删除抢票活动基本表成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("action_list.aspx", "keywords={0}", this.keywords), "Success");
        }

    }
}