using MxWeiXinPF.Templates;
using System;
using System.Collections.Generic;
using MxWeiXinPF.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using MxWeiXinPF.BLL;
using System.Data;
using System.Web.Services; //引入命名空间

namespace MxWeiXinPF.Web.shop
{
    public partial class get : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ApiKey = "4d88048525100566";//请把XXXXXX修改成您在快递100网站申请的APIKey
            string expno = Request["data"];
            string typeCom = Request["com"];
            string nu = Request["nu"];
            string openid = MyCommFun.RequestOpenid();
            int wid = MyCommFun.RequestInt("wid");
            int id = MyCommFun.RequestInt("rid");
            DataSet ds = null;
            express exBll = new express();
            ds = exBll.GetList(wid, openid, id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                typeCom = ds.Tables[0].Rows[0]["express_code"].ToString();
                nu = ds.Tables[0].Rows[0]["express_no"].ToString();
            }

            string apiurl = "http://api.kuaidi100.com/api?id=" + ApiKey + "&com=" + typeCom + "&nu=" + nu + "&show=2&muti=1&order=asc";
            //Response.Write (apiurl);
            WebRequest request = WebRequest.Create(@apiurl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.UTF8;
            StreamReader reader = new StreamReader(stream, encode);
            string detail = reader.ReadToEnd();

            Response.Write(detail + "<br/>");
        }
    }
}