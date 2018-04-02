using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.picmgr
{
    public partial class picSelect : System.Web.UI.Page
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string img_req = string.Empty;
        protected string txt_req = string.Empty;
        protected int picType = 0;
        MxWeiXinPF.BLL.wx_PicStore bll = new MxWeiXinPF.BLL.wx_PicStore();
        protected void Page_Load(object sender, EventArgs e)
        {
            picType = MyCommFun.RequestInt("picType", 0);
            img_req = MyCommFun.QueryString("img");
            txt_req = MyCommFun.QueryString("txt");
            this.pageSize = GetPageSize(40); //每页数量
            if (!IsPostBack)
            {
                BindDdl(picType);
                BindPic(picType);
            }
            
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="picType"></param>
        private void BindDdl(int picType)
        {
            DataSet ds = bll.GetTemplatesList();
            ddlTemplates.DataTextField = "pictemplates";
            ddlTemplates.DataValueField = "picType";
            ddlTemplates.DataSource = ds;
            ddlTemplates.DataBind();
            ddlTemplates.Items.Insert(0, new ListItem("用户上传图片", "0"));

            ddlTemplates.SelectedValue = picType.ToString();

            if (picType !=  0 )
            {
                div_userupload.Style.Add("display", "none");
                div_piclist.Style.Add("display", "");
                rptList2.DataSource = null;
            }
            else
            {
                div_userupload.Style.Add("display", "");
                div_piclist.Style.Add("display", "none");
            }
        }

        /// <summary>
        /// 绑定图片列表
        /// </summary>
        /// <param name="picType"></param>
        private void BindPic(int picType)
        {
            if (picType == 0)
            {
                return;
            }
            this.page = MXRequest.GetQueryInt("page", 1);
            StringBuilder sb = new StringBuilder("");
            DataSet plist = bll.GetPageList(picType, this.pageSize, this.page, "", "picType asc, sort_id asc,id asc", out this.totalCount);
            this.rptList2.DataSource = plist;
            this.rptList2.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("picSelect.aspx", "img={0}&txt={1}&pictype={2}&page={3}",
                this.img_req.ToString(), this.txt_req.ToString(), this.picType.ToString(), "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);


            //if (plist == null || plist.Tables.Count<=0)
            //{

            //    return;
            //}
            //MxWeiXinPF.Model.wx_PicStore p = new MxWeiXinPF.Model.wx_PicStore();
            //for (int i = 0; i < plist.Count; i++)
            //{
            //    sb.Append("<li>");
            //    p = plist[i];

            //    //图片
            //    sb.Append("<label for=\"rad" + p.id + "\" class=\"picLabel\" > <table class=\"picTable\"><tr><td class=\"picTd\"><img src=\"" + p.picUri + "\"  disabled  /></td></tr><tr><td class=\"chkTd\"><input id=\"rad" + p.id + "\" class=\"radPic\" name=\"radPic\" value=\"" + p.picUri + "\" type=\"radio\" /><label >" + p.picName + "</label></td></tr></table></label>");

            //    sb.Append("</li>");
            //}




        }


        /// <summary>
        /// 选择完类别后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            Response.Redirect(Utils.CombUrlTxt("picSelect.aspx", "img={0}&txt={1}&pictype={2}",
                 this.img_req.ToString(), this.txt_req.ToString(), ddlTemplates.SelectedItem.Value.ToString()));
        }


        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("picSelect_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("picSelect_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("picSelect.aspx", "img={0}&txt={1}&pictype={2}",
                this.img_req.ToString(), this.txt_req.ToString(),this.picType.ToString()));
        }


    }
}