using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    public partial class index : WeiXinPage
    {
        public string openid = "";
        protected string actName = string.Empty;
        public int wid;
        public int aid;
        public int ErrLevel = 100;
        public string ErrorInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestWid();
            aid = MyCommFun.RequestInt("aid", 0);
            BLL.wx_qp_base actBll = new BLL.wx_qp_base();
            if (aid == 0 || wid == 0 || openid.Trim() == "loseopenid" || !actBll.Exists(aid))
            {
                ErrLevel = 1;
                ErrorInfo = "访问参数错误！";
                return;
            }
            if (!IsPostBack)
            {
                RptBind();
            }

        }

        #region 数据绑定=================================
        private void RptBind()
        {
            BLL.wx_qp_img imgBll = new BLL.wx_qp_img();
            BLL.wx_qp_base baseBll = new BLL.wx_qp_base();
            BLL.wx_qp_film filmBll = new BLL.wx_qp_film();
            //得到抢票活动相关信息
            IList<Model.wx_qp_base> qblist = baseBll.GetModelList("wid=" + wid + " and id=" + aid);
            if (qblist == null || qblist.Count <= 0)
            {
                return;
            }

            Model.wx_qp_base qpBase = qblist[0];
            litFilmhb.Text = "<img src=\"" + qpBase.haibaoPic + "\">";
            actName = qpBase.bName;
            litJies.Text = "<span>" + qpBase.yyRemark + "</span>";

            //得到所有热映电影
            DataSet ds = filmBll.GetList("bid=" + aid + " order by sort_id asc,id desc");
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //得到所有影院图片
            DataSet imgDs = imgBll.GetList(4, "bId=" + aid + " and iType=2 ", "id desc");
            this.rptImg.DataSource = imgDs;
            this.rptImg.DataBind();


        }
        #endregion

        

    }
}