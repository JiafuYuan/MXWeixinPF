using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class qjt_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        BLL.wx_fc_panorama pBll = new BLL.wx_fc_panorama();
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("floormgr", MXEnums.ActionEnum.View.ToString()); //检查权限
            if (!Page.IsPostBack)
            {
                action = MXRequest.GetQueryString("action");
                if (!string.IsNullOrEmpty(action) && action == MXEnums.ActionEnum.Edit.ToString())
                {
                    this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                    this.id = MXRequest.GetQueryInt("id");
                    if (this.id == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    if (!pBll.Exists(this.id))
                    {
                        JscriptMsg("信息不存在或已被删除！", "back", "Error");
                        return;
                    }
                    ShowInfo(id);
                }
                
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_fc_panorama pano = pBll.GetModel(id);
            hidid.Value = pano.Id.ToString();
            txtpName.Text = pano.jdname.ToString();
            txtpContent.Value = pano.remark.ToString();
            this.txtpName.Text = pano.jdname;
            this.txtImgBefore.Text = pano.pri_front;
            imgBefore.ImageUrl = pano.pri_front;
            this.txtImgRight.Text = pano.pic_right;
            imgRight.ImageUrl = pano.pic_right;
            this.txtImgBehond.Text = pano.pic_behind;
            imgBehond.ImageUrl = pano.pic_behind;
            this.txtImgLeft.Text = pano.pic_left;
            imgLeft.ImageUrl = pano.pic_left;
            this.txtImgTop.Text = pano.pic_top;
            imgTop.ImageUrl = pano.pic_top;
            this.txtImgBottom.Text = pano.pic_bottom;
            imgBottom.ImageUrl = pano.pic_bottom;
            this.txtpContent.Value = pano.remark;

            // litwUrl.Text = MyCommFun.getWebSite() + "/weixin/pano360/pano.aspx?wid=" + pano.wid + "&id=" + id;

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);
            Model.wx_fc_panorama model = new Model.wx_fc_panorama();
            if (id != 0)
            {
                model = pBll.GetModel(id);
            }
            string jdName = this.txtpName.Text;
            string pic_front = this.txtImgBefore.Text;
            string pic_right = this.txtImgRight.Text;
            string pic_behind = this.txtImgBehond.Text;
            string pic_left = this.txtImgLeft.Text;
            string pic_top = this.txtImgTop.Text;
            string pic_bottom = this.txtImgBottom.Text;
            string pic_yulan = "";
            string remark = this.txtpContent.Value;
            int seq = 0;
            DateTime createDate = DateTime.Now;
            model.Id = id;
            model.fid = 1;
            model.wid = weixin.id;
            model.jdname = jdName;
            model.pri_front = pic_front;
            model.pic_right = pic_right;
            model.pic_behind = pic_behind;
            model.pic_left = pic_left;
            model.pic_top = pic_top;
            model.pic_bottom = pic_bottom;
            model.pic_yulan = pic_yulan;
            model.remark = remark;
            model.seq = seq;

            if (id != 0)//修改
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                pBll.Update(model);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改360全景图信息，主键为" + id); //记录日志
                JscriptMsg("修改360全景图信息成功！", "qjtMgr.aspx", "Success");
            }
            else//添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                model.createDate = createDate;
                pBll.Add(model);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加360全景图信息，主键为" + id); //记录日志
                JscriptMsg("添加360全景图信息成功！", "qjtMgr.aspx", "Success");
            }
        }
    }
}