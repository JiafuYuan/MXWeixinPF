using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class myYuyue : WeiXinPage
    {
        protected int wid;
        protected int fid;//对应一个系统设置
        protected string openid;
        protected string photo;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MXRequest.GetQueryInt("wid");
            fid = MXRequest.GetQueryInt("fid");
            openid = MyCommFun.RequestOpenid();
            if (!IsPostBack)
            {
                showInfo();
            }
        }
        void showInfo()
        {
            BLL.wx_fc_yyInfo yBll = new BLL.wx_fc_yyInfo();
            BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
            BLL.wx_fc_yySysset ysBll = new BLL.wx_fc_yySysset();
            int yid = MyCommFun.Obj2Int(fBll.GetModel(fid).yid);
            photo = ysBll.GetModel(yid).headImg;
            this.rptDinfo.DataSource = yBll.GetList(string.Format(" openid='{0}' and wid={1} and fid={2}", openid, wid, fid));
            this.rptDinfo.DataBind();
        }

        protected void rptDinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Literal ltr = e.Item.FindControl("ltrShow") as Literal;
                string status = drv["orderStatus"].ToString();
                int yid = MyCommFun.Obj2Int(drv["id"]);
                string kfremark = drv["kfRemark"].ToString();
                if (status == "待回复")//显示客服备注
                {
                    ltr.Text = " <a id=\"\" style=\"color: #fff;\" class=\"submit\" href=\"yySeefloor.aspx?fid=" + fid + "&wid=" + wid + "&openid=" + openid + "&yid=" + yid + "\">修改订单 </a>";
                }
                else                  //显示修改按钮
                {
                    ltr.Text = "<p>" + kfremark + "</p>";
                }


            }
        }
    }
}