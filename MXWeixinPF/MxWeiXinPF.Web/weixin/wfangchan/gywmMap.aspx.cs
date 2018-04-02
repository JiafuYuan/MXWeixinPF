using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class gywmMap : WeiXinPage
    {
        protected int gid;
        protected int fid; 
        protected string address;
        protected string name;
        protected string logourl;
        protected string tel;
        protected decimal? y;
        protected decimal? x;
        protected void Page_Load(object sender, EventArgs e)
        {
            gid = MXRequest.GetQueryInt("gid");
            fid = MXRequest.GetQueryInt("fid");
            if (!IsPostBack)
            {
                BLL.wx_fc_aboutWe awBll = new BLL.wx_fc_aboutWe();
                BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
                if (gid > 0)
                {
                    Model.wx_fc_aboutWe awModel = awBll.GetModel(gid);
                    address = awModel.address;
                    name = awModel.name;
                    logourl = awModel.logoAddress;
                    tel = awModel.telephone;
                    x = awModel.latY;
                    y = awModel.lngX;
                }
                if (fid > 0)
                {
                    Model.wx_fc_floor fModel = fBll.GetModel(fid);
                    address = fModel.Address;
                    name = fModel.newsTitle;
                    logourl = fModel.newsCover;
                    y = fModel.latY;
                    x = fModel.lngX;
                }
                
            }
        }
    }
}