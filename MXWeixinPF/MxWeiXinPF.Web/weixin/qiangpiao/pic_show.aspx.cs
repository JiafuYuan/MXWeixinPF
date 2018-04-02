using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    public partial class pic_show : System.Web.UI.Page
    {
        BLL.wx_qp_base baseBll = new BLL.wx_qp_base();
        BLL.wx_qp_img imgBLL = new BLL.wx_qp_img();
        protected int category_id;
        public int actNum = 0;
        protected int wid;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.category_id = Utils.StrToInt(MXRequest.GetQueryString("aid"), 0);
            int id = MyCommFun.RequestInt("id");
            wid = MyCommFun.RequestWid();
            if (!IsPostBack)
            {
                IList<Model.wx_qp_img> imglist = imgBLL.GetModelList("bId=" + category_id + "and iType=2  order by id desc ");
                 
                for (int i = 0; i < imglist.Count; i++)
                {
                    if (imglist[i].id == id)
                    {
                        actNum = i;
                        break;
                    }
                }
                int test = actNum;
                this.rptImgshow.DataSource = imglist;
                this.rptImgshow.DataBind();
                Model.wx_qp_base baseMod = baseBll.GetModel(this.category_id);
                this.Page.Title = baseMod.bName;
            }
        }
    }
}