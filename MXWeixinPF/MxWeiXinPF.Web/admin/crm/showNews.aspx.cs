using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class showNews : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.wx_crm_fodder cfBll = new BLL.wx_crm_fodder();
            int fid = MXRequest.GetQueryInt("id");
            if (!IsPostBack)
            {
                Model.wx_crm_fodder cfModel = cfBll.GetModel(fid);
                this.lblTitle.Text = cfModel.title;
                this.imgPic.ImageUrl = cfModel.picurl;
                this.lblContent.Text = cfModel.scContent;
            }
        } 

    }
}