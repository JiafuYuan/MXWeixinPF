using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.Web.admin.sms;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    public partial class order : WeiXinPage
    {
        /// <summary>
        /// ErrLevel:100表示正确无误，1表示严重错误，2表示业务方面有问题;3直接跳转到结束页面
        /// </summary>
        protected string openid = "";
        protected int wid;
        protected int aid;
        public int ErrLevel = 100;
        public string ErrorInfo = "";
        public string mark = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.wx_qp_base actBll = new BLL.wx_qp_base();
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestWid();
            aid = MyCommFun.RequestInt("aid");
            if (aid == 0 || wid == 0 || openid.Trim() == "loseopenid" || !actBll.Exists(aid))
            {
                ErrLevel = 1;
                ErrorInfo = "访问参数错误！";
                return;
            }
            BindData();
        }

        private void BindData()
        {
            BLL.wx_qp_img imgBLl = new BLL.wx_qp_img();
            BLL.wx_qp_base actBll = new BLL.wx_qp_base();
            BLL.wx_qp_users usersBll = new BLL.wx_qp_users();
            Model.wx_qp_base baseModel = actBll.GetModelList(" id=" + aid)[0];
            IList<Model.wx_qp_users> userList = usersBll.GetModelList(string.Format(" openid='{0}' and bId={1}", openid, aid));
            //判断活动是否过期
            if (baseModel.actEnd < DateTime.Now || baseModel.actBegin > DateTime.Now)
            {
                ErrLevel = 1;
                ErrorInfo = "此活动时间不对,很遗憾！";
                return;
            }
            if (userList.Count > 0)
            {
                ErrLevel = 1;
                ErrorInfo = "你已参加过活动,每人只能参加一次！";
                return;
            }

            //轮播图片
            this.rptImglist.DataSource = imgBLl.GetList(" bId=" + aid + " and iType=3 ");
            if (imgBLl.GetList(" bId=" + aid + " and iType=3 ").Tables[0].Rows.Count <= 0)
            {
                mark = "no";
            }
            this.rptImglist.DataBind();
            this.rptNum.DataSource = imgBLl.GetList(" bId=" + aid + " and iType=3 ");
            this.rptNum.DataBind();

            this.Page.Title = baseModel.bName;
            this.ltrUserxz.Text = baseModel.qpRemark;

        }

    }
}