using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.qiangpiao
{
    public partial class order_Result : WeiXinPage
    {
        protected string openid = string.Empty;
        protected int wid;
        protected int aid;
        public int ErrLevel = 100;
        public string ErrorInfo = "";
        public string joined = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            openid = MyCommFun.RequestOpenid();
            wid = MyCommFun.RequestWid();
            aid = MyCommFun.RequestInt("aid");
            joined = MXRequest.GetQueryString("join");
            if (aid == 0 || wid == 0 || openid.Trim() == "loseopenid" || joined == "")
            {
                ErrLevel = 1;
                ErrorInfo = "访问参数错误！";
                return;
            }
            ckState();
        }


        private void ckState()
        {
            BLL.wx_qp_base actBll = new BLL.wx_qp_base();
            BLL.wx_qp_users userBll = new BLL.wx_qp_users();
            Model.wx_qp_base baseModel = actBll.GetModel(aid);
            IList<Model.wx_qp_users> userList = userBll.GetModelList(" openid='" + openid + "' and bId=" + aid);
            Model.wx_qp_users userModel = null;
            string gpTime = DateTime.Parse(baseModel.yyGouPiaoBeginDate.ToString()).ToString("MM月dd日-HH:mm") +
                    "~" + DateTime.Parse(baseModel.yyGouPiaoEndDate.ToString()).ToString("MM月dd日-HH:mm");
            if (userList != null && userList.Count > 0)
                userModel = userList[0];

            string Fulltext = "<h1><i class=\"text-icon\">✔</i>已有" + baseModel.maxPersonNum + "人抢到票啦！</h1>" +
                "<dl class=\"list\">" +
                "<dd class=\"dd-padding\">特价票已售完即止！</dd>" +
                "<dd class=\"dd-padding\">请抓紧时间购票把！</dd>" +
                "<dd class=\"dd-padding\">购票时间：" + gpTime + "</dd></dl><br />";
            //活动人数已满
            if (baseModel.cyPersonNum > baseModel.maxPersonNum)
            {
                this.litFull.Text = Fulltext;
                return;
            }

            //非法用户
            if (userModel == null)
            {
                if (baseModel.cyPersonNum == baseModel.maxPersonNum)//最后一个用户
                    this.litFull.Text = Fulltext;
                else
                    Response.Redirect(string.Format("index.aspx?wid={0}&aid={1}&openid={2}", wid, aid, openid));
                return;
            }

            //第一次参与活动
            if (joined == "true")
            {
                string snNum = userModel.sn;
                this.litShow.Text = "<h1><i class=\"text-icon\">✔</i>您是第" + baseModel.cyPersonNum + "位参加本次抢票！</h1>" +
                "<dl class=\"list\">" +
                "<dd class=\"dd-padding\">您的sn码：" + snNum + " </dd>" +
                "<dd class=\"dd-padding\">购票时间：" + gpTime + "</dd></dl><br />";
                return;
            }//已参与过本次活动,不可以再参加
            else if (joined == "false")
            {
                string snNum = userModel.sn;
                this.litJoined.Text = "<h1><i class=\"text-icon\">✔</i>您已成功参加本次抢票！</h1>" +
                "<dl class=\"list\">" +
                "<dd class=\"dd-padding\">您的sn码：" + snNum + " </dd>" +
                "<dd class=\"dd-padding\">购票时间：" + gpTime + "</dd></dl><br />";
                return;
            }

        }

    }
}