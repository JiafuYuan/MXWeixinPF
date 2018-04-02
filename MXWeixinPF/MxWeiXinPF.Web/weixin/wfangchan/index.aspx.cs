using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class index : WeiXinPage
    {
        protected Model.wx_fc_floor floor;
        BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
        protected int fid;
        protected int wid;
        protected string openid;
        protected List<test> ls;
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = MXRequest.GetQueryInt("fid");
            wid = MXRequest.GetQueryInt("wid");
            openid = MXRequest.GetQueryString("openid");
            if (!IsPostBack)
            {
                showInfo();
            }
        }

        void showInfo()
        {
            floor = fBll.GetModelList(string.Format(" wid={0} and id={1}", wid, fid))[0];
            if (floor == null)
            {
                return;
            }
            this.Title = floor.newsTitle;
            ls = new List<test>();
            if (floor.slideA != "")
                ls.Add(new test() { Str = floor.slideA }); 
            if (floor.sildeB != "")
                ls.Add(new test() { Str =floor.sildeB});
            if (floor.slideD != "")
                ls.Add(new test() { Str =floor.slideD});
            if (floor.slideC != "")
                ls.Add(new test() { Str =floor.slideC});
            if (floor.slideE != "")
                ls.Add(new test() { Str =floor.slideE});
            this.rptList.DataSource = ls;
            this.rptList.DataBind();

        }
    }

    public class test
    {
       public string Str{ get;set;} 
       
    }

}