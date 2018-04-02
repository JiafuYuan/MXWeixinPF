using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Text;

namespace MxWeiXinPF.Web.admin.tongji
{
    public partial class reqrespData : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        BLL.wx_response_BaseData rbll = new BLL.wx_response_BaseData();
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MXRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                RptBind(CombSqlTxt(keywords), "createDate desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            Model.wx_userweixin weixin = GetWeiXinCode();
            if (weixin.closeKW == null || weixin.closeKW == false)
            {
                btnDelete.Text = "关闭自动回复";
                lblstatus.Text = "开启";
            }
            else
            {
                btnDelete.Text = "开启自动回复";
                lblstatus.Text = "关闭";
            }

            _strWhere = "wId=" + weixin.id + " and  flag is null " + _strWhere;
            this.page = MXRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            this.rptList.DataSource = rbll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("reqrespData.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and (wx_openid like  '%" + _keywords + "%'  or requestContent like '%" + _keywords + "%' or  reponseContent like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("reqrespData_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("reqrespData.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("reqrespData_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("reqrespData.aspx", "keywords={0}", this.keywords));
        }


        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
            }
        }

        public string TypeStr(object type)
        {
            string ret = "";
            string typeStr=(MyCommFun.ObjToStr(type)).ToLower();
            switch (typeStr)
            { 
                case "text":
                    ret = "文本";
                    break;
                case "event":
                    ret = "事件";
                    break;
                case "txtpic":
                    ret = "图文";
                    break;
                case "subscribe":
                    ret = "关注事件";
                    break;
                case "unsubscribe":
                    ret = "取消关注事件";
                    break;
                 default:
                    ret = "";
                    break;
            }
            return ret;
        }

        //关闭
        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // ChkAdminLevel("channel_" + this.channel_name + "_list", MXEnums.ActionEnum.Delete.ToString()); //检查权限
            string btnText = btnDelete.Text;
            BLL.wx_userweixin uwBll = new BLL.wx_userweixin();
            Model.wx_userweixin weixin = GetWeiXinCode();
            if (btnText == "关闭自动回复")
            {
                //关闭
                uwBll.UpdateField(weixin.id, "closeKW=1");
                weixin.closeKW = true;
                AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), weixin.id+"关闭了自动回复"); //记录日志
                JscriptMsg("成功关闭了自动回复！", Utils.CombUrlTxt("reqrespData.aspx", "keywords={0}", txtKeywords.Text), "Success");
            }
            else
            { 
                //开启
                uwBll.UpdateField(weixin.id, "closeKW=0");
                weixin.closeKW = false;
                AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), weixin.id + "开启了自动回复"); //记录日志

                JscriptMsg("成功开启了自动回复！", Utils.CombUrlTxt("reqrespData.aspx", "keywords={0}", txtKeywords.Text), "Success");

            }

            Session["nowweixin"] = weixin;



          
        }

    }
}