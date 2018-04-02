using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    public partial class xmlstr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.ContentType = "text/xml";
                int id = MyCommFun.RequestInt("id");
                if (id <= 0)
                { return; }
                BLL.wx_fc_panorama pbll = new BLL.wx_fc_panorama();
                Model.wx_fc_panorama pano = pbll.GetModel(id);
                StringBuilder sb = new StringBuilder("");


                sb.Append("<panorama id=\"\">");
                sb.Append("<view fovmode=\"0\" pannorth=\"0\"><start pan=\"0\" fov=\"70\" tilt=\"0\"/><min pan=\"0\" fov=\"5\" tilt=\"-90\"/>");
                sb.Append("<max pan=\"360\" fov=\"120\" tilt=\"90\"/></view>");
                sb.Append("<input tilesize=\"685\" tilescale=\"1.014598540145985\" tile0url=\"" + getPicUrl(pano.pri_front) + "\" tile1url=\"" + getPicUrl(pano.pic_right) + "\" tile2url=\"" + getPicUrl(pano.pic_behind) + "\" tile3url=\"" + getPicUrl(pano.pic_left) + "\" tile4url=\"" + getPicUrl(pano.pic_top) + "\" tile5url=\"" + getPicUrl(pano.pic_bottom) + "\" />");
                sb.Append("<userdata title=\"mxweixin_pano\" datetime=\"2011:11:03 09:41:07\" description=\"description\" copyright=\"copyright\" tags=\"tags\" author=\"author\" source=\"source\" comment=\"comment\" info=\"info\" longitude=\"0\" latitude=\"\"/>");
                sb.Append("<autorotate speed=\"0.200\" nodedelay=\"0.00\" startloaded=\"1\" returntohorizon=\"0.000\" delay=\"5.00\"/>");
                sb.Append("<control sensitivity=\"8\" simulatemass=\"1\" lockedmouse=\"0\" lockedkeyboard=\"0\" lockedwheel=\"0\" invertwheel=\"0\" speedwheel=\"1\" dblclickfullscreen=\"0\" invertcontrol=\"1\" />");
                sb.Append("<sounds></sounds>");
                sb.Append("</panorama>");


                //string one = pano.pri_front;
                //string two = pano.pic_right;
                //string thr = pano.pic_behind;
                //string fou = pano.pic_left;
                //string fiv = pano.pic_top;
                //string six = pano.pic_bottom; 
                //sb.Append("<panorama id=\"\" hideabout=\"1\"><view fovmode=\"0\" pannorth=\"0\">");
                //sb.Append("<start pan=\"5.5\" fov=\"80\" tilt=\"1.5\"/><min pan=\"0\" fov=\"80\" tilt=\"-90\"/>");
                //sb.Append("<max pan=\"360\" fov=\"80\" tilt=\"90\"/></view>");
                //sb.Append("<userdata title=\"\" datetime=\"2013:05:23 21:01:02\" description=\"\" copyright=\"\" tags=\"\" author=\"\" source=\"\" comment=\"\" info=\"\" longitude=\"\" latitude=\"\"/>");
                //sb.Append("<hotspots width=\"180\" height=\"20\" wordwrap=\"1\">");
                //sb.Append("<label width=\"180\" backgroundalpha=\"1\" enabled=\"1\" height=\"20\" backgroundcolor=\"0xffffff\" bordercolor=\"0x000000\" border=\"1\" textcolor=\"0x000000\" background=\"1\" borderalpha=\"1\" borderradius=\"1\" wordwrap=\"1\" textalpha=\"1\"/>");
                //sb.Append("<polystyle mode=\"0\" backgroundalpha=\"0.2509803921568627\" backgroundcolor=\"0x0000ff\" bordercolor=\"0x0000ff\" borderalpha=\"1\"/></hotspots><media/>");
                //sb.Append("<input tilesize=\"700\" tilescale=\"1.014285714285714\" tile0url=\"" + one + "\" tile1url=\"" + two + "\" tile2url=\"" + thr + "\" tile3url=\"" + fou + "\" tile4url=\"" + fiv + "\" tile5url=\"" + six + "\"/>");
                //sb.Append("<autorotate speed=\"0.200\" nodedelay=\"0.00\" startloaded=\"1\" returntohorizon=\"0.000\" delay=\"5.00\"/>");
                //sb.Append("<control simulatemass=\"1\" lockedmouse=\"0\" lockedkeyboard=\"0\" dblclickfullscreen=\"0\" invertwheel=\"0\" lockedwheel=\"0\" invertcontrol=\"1\" speedwheel=\"1\" sensitivity=\"8\"/>");
                //sb.Append("</panorama>");
                Response.Write(sb.ToString());
            }
        }

        /// <summary>
        /// 获得图片的url
        /// </summary>
        /// <param name="orginUrl"></param>
        /// <returns></returns>
        public string getPicUrl(string orginUrl)
        {
            if (orginUrl == null)
            {
                return "";
            }
            string ret = orginUrl;
            if (ret.IndexOf("http") < 0)
            {
                return MyCommFun.getWebSite() + orginUrl;
            }
            else
            {
                return ret;
            }

        }
    }
}