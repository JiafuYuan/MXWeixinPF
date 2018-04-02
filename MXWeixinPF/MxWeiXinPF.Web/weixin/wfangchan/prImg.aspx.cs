using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class prImg : WeiXinPage
    {
        protected string openid;
        protected int wid;
        protected int fid;
        protected int id;
        protected string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            wid = MyCommFun.RequestInt("wid");
            fid = MyCommFun.RequestInt("fid");
            id = MyCommFun.RequestInt("id");
            int pid = MyCommFun.RequestInt("pid");
            openid = MyCommFun.QueryString("openid");
            if (!IsPostBack)
            {
                BLL.wx_fc_panorama pBll = new BLL.wx_fc_panorama();
                Model.wx_fc_panorama pModel = null;
                if (pid != 0)//当页面从户型页面过来
                {
                    id = getPid(pid);
                    pModel = pBll.GetModel(MyCommFun.Obj2Int(id));
                }
                else//当页面从全景图页面过来
                {
                    pModel = pBll.GetModel(MyCommFun.Obj2Int(id));
                }

                title = pModel.jdname;
                this.Title = title;
            }
        }

        int getPid(int pid)
        {
            BLL.wx_fc_houseType htBll = new BLL.wx_fc_houseType();
            return MyCommFun.Obj2Int(htBll.GetModel(pid).pid);
        }

    }

    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current != null && HttpContext.Current.Response != null)
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*"); // take care

                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept,X-Requested-With");
                    HttpContext.Current.Response.End();
                }
            }
        }

    } 
}