using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class floorHtype : System.Web.UI.Page
    {
        protected string openid;
        protected int fid;
        protected int wid;
        protected int jlNum;
        protected Model.wx_fc_floor fModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = MXRequest.GetQueryInt("fid");
            wid = MXRequest.GetQueryInt("wid");
            openid = MyCommFun.RequestOpenid();
            if (!IsPostBack)
            {
                BLL.wx_fc_houseType htBll = new BLL.wx_fc_houseType();
                BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
                fModel = fBll.GetModel(fid);
                this.rptHt.DataSource = htBll.GetList(string.Format(" wid={0} and fid={1} ", wid, fid));
                jlNum = htBll.GetList(string.Format(" wid={0} and fid={1} ", wid, fid)).Tables[0].Rows.Count;
                this.rptHt.DataBind();
            }
        }
    }
}