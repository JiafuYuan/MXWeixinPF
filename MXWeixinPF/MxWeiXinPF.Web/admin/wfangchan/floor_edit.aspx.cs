using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MxWeiXinPF.Common;
using System.Web.UI.WebControls;
using System.Data;

namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class floor_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型 
        private int id = 0;
        BLL.wx_fc_floor bll = new BLL.wx_fc_floor();
        BLL.wx_requestRule rBll = new BLL.wx_requestRule();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            //检验参数正确性
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!bll.Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.View.ToString()); //检查权限 
                TreeBind(); //绑定类别
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }

        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            BLL.wx_fc_yySysset bll = new BLL.wx_fc_yySysset();
            BLL.wx_fc_panorama pBll = new BLL.wx_fc_panorama();
            DataTable pDt = pBll.GetList(" wid=" + weixin.id).Tables[0];
            this.ddlQjt.Items.Clear();
            this.ddlQjt.Items.Add(new ListItem("请选择全景图...", ""));
            foreach (DataRow dr in pDt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["jdname"].ToString().Trim();
                this.ddlQjt.Items.Add(new ListItem(Title, Id));
            }

            DataTable dt = bll.GetList(" wid=" + weixin.id).Tables[0];
            this.ddlYybm.Items.Clear();
            this.ddlYybm.Items.Add(new ListItem("请选择预约版面...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["address"].ToString().Trim();
                this.ddlYybm.Items.Add(new ListItem(Title, Id));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.wx_fc_floor model = bll.GetModel(_id);
            Model.wx_requestRule rModel = rBll.GetModelList("modelFunctionName='微房产' and modelFunctionId=" + _id)[0];
            this.txtAddress.Text = model.Address;
            this.txtfSummary.InnerText = model.fSummary;
            this.txtjtpt.InnerText = model.jtpt;
            this.txtLngYPoint.Text = model.latY.ToString();
            this.txtLatXPoint.Text = model.lngX.ToString();

            this.txtNewsTitle.Text = model.newsTitle;
            this.txtpSummary.InnerText = model.pSummary;
            this.txtSort_id.Text = model.sort_id.ToString();
            this.txtVideo.Text = model.videoUrl;
            this.txtKW.Text = rModel.reqKeywords;
            this.slideA.ImageUrl = model.slideA;
            this.slideAUrl.Text = model.slideA;
            this.slideC.ImageUrl = model.slideC;
            this.slideCUrl.Text = model.slideC;
            this.slideD.ImageUrl = model.slideD;
            this.slideDUrl.Text = model.slideD;
            this.slideE.ImageUrl = model.slideE;
            this.slideEUrl.Text = model.slideE;
            this.slideB.ImageUrl = model.sildeB;
            this.slideBUrl.Text = model.sildeB;
            this.txtNewsCover.Text = model.newsCover;
            this.imgNewsCover.ImageUrl = model.newsCover;
            this.txtHtheadImg.Text = model.htheadImg;
            this.imgHtheadImg.ImageUrl = model.htheadImg;
            this.txtFheadImg.Text = model.fheadImg;
            this.imgFheadImg.ImageUrl = model.fheadImg;
            this.ddlQjt.SelectedValue = model.qid.ToString();
            this.ddlYybm.SelectedValue = model.yid.ToString();

        }
        #endregion


        #region 添加回复规则
        private void AddRule(int wid, int modelId)
        {
            rBll.AddModeltxtPicRule(wid, "微房产", modelId, txtKW.Text.Trim());
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_floor model = new Model.wx_fc_floor();
            bool result = false;

            model.yid = MyCommFun.Str2Int(this.ddlYybm.SelectedItem.Value);
            model.videoUrl = this.txtVideo.Text;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.Address = this.txtAddress.Text;
            model.createdate = DateTime.Now;
            model.fheadImg = this.txtFheadImg.Text;
            model.fSummary = this.txtfSummary.InnerText;
            model.htheadImg = this.txtHtheadImg.Text;
            model.jtpt = this.txtjtpt.InnerText;
            model.latY = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.newsCover = this.txtNewsCover.Text;
            model.newsTitle = this.txtNewsTitle.Text;
            model.pSummary = this.txtpSummary.InnerText;
            model.slideA = this.slideAUrl.Text;
            model.sildeB = this.slideBUrl.Text;
            model.slideC = this.slideCUrl.Text;
            model.slideD = this.slideDUrl.Text;
            model.slideE = this.slideEUrl.Text;
            model.wid = weixin.id;
            model.qid = MyCommFun.Str2Int(this.ddlQjt.SelectedItem.Value);
            int res = bll.Add(model);
            if (res > 0)
            {
                AddRule(weixin.id, res);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加楼盘信息:" + model.newsTitle); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_floor model = bll.GetModel(_id);
            bool result = false;
            IList<Model.wx_requestRule> rList = rBll.GetModelList("modelFunctionName='微房产' and modelFunctionId=" + _id);
            if (rList != null && rList.Count > 0)
            {
                Model.wx_requestRule rModel = rList[0];
                rModel.reqKeywords = this.txtKW.Text;
                rBll.Update(rModel);
            }
            else
            {
                AddRule(weixin.id, _id);
            }
            model.yid = MyCommFun.Str2Int(this.ddlYybm.SelectedItem.Value);
            model.videoUrl = this.txtVideo.Text;
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.Address = this.txtAddress.Text;
            model.fheadImg = this.txtFheadImg.Text;
            model.fSummary = this.txtfSummary.InnerText;
            model.htheadImg = this.txtHtheadImg.Text;
            model.jtpt = this.txtjtpt.InnerText;
            model.latY = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
            model.lngX = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
            model.newsCover = this.txtNewsCover.Text;
            model.newsTitle = this.txtNewsTitle.Text;
            model.pSummary = this.txtpSummary.InnerText;
            model.slideA = this.slideAUrl.Text;
            model.sildeB = this.slideBUrl.Text;
            model.slideC = this.slideCUrl.Text;
            model.slideD = this.slideDUrl.Text;
            model.slideE = this.slideEUrl.Text;
            model.qid = MyCommFun.Str2Int(this.ddlQjt.SelectedItem.Value);
            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改产品库内容id:" + model.Id); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "floorMgr.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }

                JscriptMsg("添加信息成功！", "floorMgr.aspx", "Success");
            }
        }
    }
}