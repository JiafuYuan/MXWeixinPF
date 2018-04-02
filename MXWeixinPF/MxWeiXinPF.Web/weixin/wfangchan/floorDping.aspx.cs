using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class floorDping : WeiXinPage
    {
        protected int wid;
        protected string openid;
        protected int fid;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MXRequest.GetQueryInt("wid");
            fid = MXRequest.GetQueryInt("fid");
            openid = MXRequest.GetQueryString("openid");

            if (!IsPostBack)
            {
                showInfo();
            }
        }

        void showInfo()
        {
            //专家点评
            BLL.wx_fc_zjComment zBll = new BLL.wx_fc_zjComment();
            this.rptReview.DataSource = zBll.GetList(string.Format(" wid={0} and fid={1}", wid, fid));
            this.rptReview.DataBind();

            //房友印象
            BLL.wx_fc_fyImpression fBll = new BLL.wx_fc_fyImpression();
            this.rptYin.DataSource = fBll.GetListGroupby(string.Format(" wid={0} and fid={1} ", wid, fid));
            this.rptYin.DataBind();
        }
    }
}