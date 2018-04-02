using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class yySeefloor : WeiXinPage
    {
        protected string openid;
        protected int wid;
        protected int fid;
        protected int dnum;
        protected int addOrEdit;//0.添加!0.修改
        protected Model.wx_fc_yySysset ysModel;
        protected Model.wx_fc_yyInfo yiModel;
        BLL.wx_fc_yyInfo yiBll = new BLL.wx_fc_yyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            yiModel = new Model.wx_fc_yyInfo();
            wid = MXRequest.GetQueryInt("wid");
            fid = MXRequest.GetQueryInt("fid");
            openid = MyCommFun.RequestOpenid();
            if (!IsPostBack)
            {
                int yid = MXRequest.GetQueryInt("yid");
                if (yid > 0)
                {
                    yiModel = yiBll.GetModel(yid);
                    addOrEdit = yiModel.Id;
                }
                showInfo();
            }
        }

        void showInfo()
        {
            BLL.wx_fc_yySysset ysBLL = new BLL.wx_fc_yySysset();
            BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
            BLL.wx_fc_houseType htBll = new BLL.wx_fc_houseType();
            //楼盘
            Model.wx_fc_floor fModel = fBll.GetModelList(string.Format(" wid={0} and id={1}", wid, fid))[0];
            //系统设置
            ysModel = ysBLL.GetModelList(" id=" + fModel.yid)[0];
            //我的订单数量
            dnum = yiBll.GetRecordCount(" openid='" + openid + "' and fid=" + fid + " and wid=" + wid);
            //户型
            this.rptHx.DataSource = htBll.GetModelList(" fid=" + fModel.Id + " and wid=" + wid);
            this.rptHx.DataBind();
        }

    }
}