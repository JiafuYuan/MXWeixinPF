using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.hotel
{
    public partial class hotel_dingdan_cz : Web.UI.ManagePage
    {
        public int dingdanid = 0;
        BLL.wx_hotel_dingdan dingdanbll = new BLL.wx_hotel_dingdan();
        protected Model.wx_hotel_dingdan dingdan = new Model.wx_hotel_dingdan();
        public string ordername = "";
        public string openid = "";
        public string beizhu = "";
        public int hotelid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dingdanid = MyCommFun.RequestInt("id");
            hotelid = MyCommFun.RequestInt("hotelid");
            if (!IsPostBack)
            {

                dingdan = dingdanbll.GetModel(dingdanid);
                if (dingdan != null)
                {
                    ordername = dingdan.oderName;
                    openid = dingdan.openid;
                    beizhu = dingdan.remark;
                }
                else {
                    dingdan = new Model.wx_hotel_dingdan();
                }

            }
        }

        protected void save_groupbase_Click(object sender, EventArgs e)
        {
            dingdanid = MyCommFun.RequestInt("id");
            string status = StatusType.SelectedItem.Value;
            dingdanbll.Update(dingdanid, status);

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改状态，主键为" + dingdanid); //记录日志
            JscriptMsg("添加成功！", "hotel_dingdan_manage.aspx?hotelid=" + hotelid + "", "Success");
        }
    }
}