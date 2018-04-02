using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;

namespace MxWeiXinPF.Web.admin.qiangpiao
{
    public partial class advmgr : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_qp_img pBll = new wx_qp_img();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;

            if (!Page.IsPostBack)
            {
                id = MyCommFun.RequestInt("id");

                ShowInfo(id);

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            IList<Model.wx_qp_img> plist = pBll.GetModelList(" bId=" + id+" and iType=3 ");
            rptAlbumList.DataSource = plist;
            rptAlbumList.DataBind();
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int bid = MyCommFun.Str2Int(hidid.Value);

            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            bool res=pBll.DeleteByBid(bid,3);
            if (albumArr != null && albumArr.Length > 0)
            {
                if (albumArr.Length > 50)
                {
                    JscriptMsg("不能上传超过50张相片！", "back", "Error");
                    return;
                }
                Model.wx_qp_img photo = new Model.wx_qp_img();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    photo = new Model.wx_qp_img();

                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        photo.createDate = DateTime.Now;
                        photo.bId = bid;
                        photo.iType = 3;
                        photo.imgPic = imgArr[1];
                        photo.remark = remarkArr[i] == null ? "" : remarkArr[i];
                        pBll.Add(photo);

                    }
                }

            }

            AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑广告相册，广告主键为" + bid); //记录日志
            JscriptMsg("编辑广告相册成功！", "advmgr.aspx?id=" + bid, "Success");

        }
    }
}