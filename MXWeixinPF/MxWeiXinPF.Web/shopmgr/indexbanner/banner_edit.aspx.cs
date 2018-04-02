using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;
using MxWeiXinPF.Model;
namespace MxWeiXinPF.Web.shopmgr.indexbanner
{
    public partial class banner_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

       BLL.wx_shop_indexbanner pBll = new BLL.wx_shop_indexbanner();
        
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
           


            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                id = MyCommFun.RequestInt("id");
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!pBll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(id);
                }

            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_shop_indexbanner photo = pBll.GetModel(id);
            hidid.Value = photo.id.ToString();
            txtpName.Text = photo.bannerName.ToString();
            txtLinkUrl.Text = photo.bannerLinkUrl;
            txtpContent.Value = photo.remark.ToString();
            txtseq.Text = photo.sort_id.Value.ToString();
           

            //封面图片
            if (photo.bannerPicUrl != null && photo.bannerPicUrl.Trim() != "/images/noneimg.jpg")
            {
                txtImgUrl.Text = photo.bannerPicUrl;
                imgfacePicPic.ImageUrl = photo.bannerPicUrl;
            }
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtpName.Text.Trim().Length == 0)
            {
                strErr += "图片名称不能为空！";
            }
            if (this.txtImgUrl.Text.Trim().Length == 0)
            {
                strErr += "图片不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值
            Model.wx_shop_indexbanner photo = new Model.wx_shop_indexbanner();

            if (id > 0)
            {
                photo = pBll.GetModel(id);
            }

            string facePicc = imgfacePicPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                facePicc = txtImgUrl.Text.Trim();
            }
            Model.wx_userweixin weixin = GetWeiXinCode();
            photo.wid = weixin.id;
            photo.bannerName = txtpName.Text.Trim();
            photo.remark = txtpContent.Value.Trim();
            photo.bannerLinkUrl = txtLinkUrl.Text.Trim();
            photo.bannerPicUrl = facePicc;
            photo.sort_id = MyCommFun.Str2Int(txtseq.Text.Trim());


            #endregion

            if (id <= 0)
            {  //新增
                 photo.createDate = DateTime.Now;
                //1新增主表
                id = pBll.Add(photo);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加相册--图片信息，主键为" + id); //记录日志
                JscriptMsg("添加相册--图片信息成功！", "banner_list.aspx", "Success");
            }
            else
            {   //修改

                pBll.Update(photo);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改相册--图片信息，主键为" + id); //记录日志
                JscriptMsg("修改相册--图片信息成功！", "banner_list.aspx", "Success");
            }

        }
    }
}