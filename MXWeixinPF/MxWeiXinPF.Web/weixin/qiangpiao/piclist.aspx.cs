using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    public partial class piclist : System.Web.UI.Page
    {
        BLL.wx_qp_base baseBll = new BLL.wx_qp_base();
        BLL.wx_qp_img imgBLL = new BLL.wx_qp_img();
        protected int aid;
        protected int wid;
        protected string openid=string.Empty;
        protected string actName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MyCommFun.RequestWid();
            aid = MyCommFun.RequestInt("aid", 0);
            if (!IsPostBack)
            {
                this.rptImglist.DataSource = imgBLL.GetList("bId=" + this.aid + " and iType=2  order by id desc");
                this.rptImglist.DataBind();
                this.openid = MyCommFun.RequestOpenid();
                Model.wx_qp_base baseMod = baseBll.GetModel(this.aid);
                actName = baseMod.bName;
            }
        }
    }
}