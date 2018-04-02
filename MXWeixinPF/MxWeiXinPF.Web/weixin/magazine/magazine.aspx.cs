using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
namespace MxWeiXinPF.Web.weixin
{
    public partial class magazine : WeiXinPage
    {
        protected int mid = 3;
        protected string fristImg;
        protected string lastImg;
        protected string cleanImg;
        protected string ckRepeat;
        protected string ckMusic;
        protected string groundMusic;
        protected string linkurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.wx_mz_img bll = new BLL.wx_mz_img();
                mid = MXRequest.GetQueryInt("mid");
                showInfo();
                this.rptList.DataSource = bll.GetModelList(" mid=" + mid);
                this.rptList.DataBind();
            }
        }

        void showInfo()
        {
            BLL.wx_mz_magazine mBll = new BLL.wx_mz_magazine();
            Model.wx_mz_magazine mModel = mBll.GetModel(mid);
            this.Title = mModel.mname;
            fristImg = mModel.coverimg;
            lastImg = mModel.footimg;
            cleanImg = mModel.cleanimg;
            linkurl = mModel.footurl;
            ckRepeat = mModel.isrepeat;
            if (ckRepeat == "1")
                ckRepeat = "true";
            else
                ckRepeat = "false";
            ckMusic = mModel.isbackmusic;
            if (ckMusic == "1")
            {
                groundMusic = mModel.backmusic;
            }
        }


    }
}