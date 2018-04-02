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
    public partial class action_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_qp_base baseBll = new wx_qp_base();
        wx_qp_img imgBll = new wx_qp_img();
        wx_requestRule rBll = new wx_requestRule();

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            int id = 0;
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {

                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out  id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!baseBll.Exists(id))
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
                else
                {
                    txtbeginDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtendDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }



        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();
            Model.wx_qp_base qpModel = baseBll.GetModel(id);

            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='电影院抢票' and modelFunctionId=" + id)[0];
            txtKW.Text = rule.reqKeywords;

            if (qpModel.beginPic != null && qpModel.beginPic.Trim() != "/weixin/qiangpiao/images/qp1.jpg")
            {
                txtImgUrl.Text = qpModel.beginPic;
                imgbeginPic.ImageUrl = qpModel.beginPic;
            }
            txtactName.Text = qpModel.bName;

            txtbeginDate.Text = qpModel.actBegin.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtendDate.Text = qpModel.actEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txthaibaoPic.Text = qpModel.haibaoPic;
            txtyyRemark.Value = qpModel.yyRemark;
            this.txtqpRemark.Value = qpModel.qpRemark;

            txtmaxPersonNum.Text = qpModel.maxPersonNum.Value.ToString();
            rblisSnSendsms.SelectedValue = qpModel.isSnSendsms.ToString();

            txtyyGouPiaoBeginDate.Text = qpModel.yyGouPiaoBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtyyGouPiaoEndDate.Text = qpModel.yyGouPiaoEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            txtSortId.Text = qpModel.sort_id.ToString();
            rptAlbumList.DataSource = qpModel.yingyuanlist;
            rptAlbumList.DataBind();


        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

            Model.wx_requestRuleContent rc = new Model.wx_requestRuleContent();
            int id = MyCommFun.Str2Int(hidid.Value);
            #region  //先判断
            string strErr = "";
            if (this.txtKW.Text.Trim().Length == 0)
            {
                strErr += "关键词不能为空！";
            }
            if (this.txtactName.Text.Trim().Length == 0)
            {
                strErr += "活动名称不能为空！";
            }
            if (this.txtbeginDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtbeginDate.Text))
            {
                strErr += "开始时间不能为空！";
            }
            if (this.txtendDate.Text.Trim().Length == 0 || !MyCommFun.isDateTime(txtendDate.Text))
            {
                strErr += "结束时间不能为空！";
            }


            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }
            DateTime begin = DateTime.Parse(txtbeginDate.Text.Trim());
            DateTime end = DateTime.Parse(txtendDate.Text.Trim());
            if (begin >= end)
            {
                JscriptMsg("开始时间必须小于结束时间", "back", "Error");
                return;
            }
            #endregion

            #region 赋值
            Model.wx_qp_base baseModel = new Model.wx_qp_base();
            Model.wx_requestRule rule = new Model.wx_requestRule();

            string beginPic = imgbeginPic.ImageUrl;
            if (txtImgUrl.Text.Trim() != "")
            {
                beginPic = txtImgUrl.Text.Trim();
            }

            if (id > 0)
            {
                baseModel = baseBll.GetModel(id);
            }

            baseModel.bName = txtactName.Text.Trim();

            baseModel.actBegin = begin;
            baseModel.actEnd = end;

            baseModel.yyRemark = txtyyRemark.Value.Trim();
            baseModel.qpRemark = txtqpRemark.Value.Trim();
            baseModel.maxPersonNum = MyCommFun.Str2Int(txtmaxPersonNum.Text.Trim());

            baseModel.isSnSendsms = rblisSnSendsms.SelectedItem.Value == "1" ? true : false;
            baseModel.yyGouPiaoBeginDate = MyCommFun.Obj2DateTime(txtyyGouPiaoBeginDate.Text.Trim());
            baseModel.yyGouPiaoEndDate = MyCommFun.Obj2DateTime(txtyyGouPiaoEndDate.Text.Trim());

            baseModel.beginPic = beginPic;
            baseModel.haibaoPic = txthaibaoPic.Text.Trim();
            baseModel.sort_id = MyCommFun.Str2Int(txtSortId.Text.Trim(), 0);
            #region 保存相册====================

            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            bool res = imgBll.DeleteByBid(id,2);
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.wx_qp_img> ls = new List<Model.wx_qp_img>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    int img_id = Utils.StrToInt(imgArr[0], 0);
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.wx_qp_img { id = img_id, imgPic = imgArr[1], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.wx_qp_img { id = img_id, imgPic = imgArr[1] });
                        }
                    }
                }
                baseModel.yingyuanlist = ls;
            }
            else
                baseModel.yingyuanlist = null;
            #endregion


            #endregion

            if (id <= 0)
            {  //新增
                baseModel.wid = weixin.id;
                baseModel.cyPersonNum = 0;
                baseModel.createDate = DateTime.Now;
                id = baseBll.Add(baseModel);

                //3 新增回复规则表
                AddRule(weixin.id, id);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加电影院抢票活动，主键为" + id); //记录日志
                JscriptMsg("添加电影院抢票成功！", "action_list.aspx", "Success");
            }
            else
            {   //修改
                //1修改主表
                baseBll.Update(baseModel);

                //3 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '电影院抢票' and modelFunctionId=" + id);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtKW.Text.Trim();
                    rBll.Update(rule);
                }
                else
                {
                    AddRule(weixin.id, id);
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改电影院抢票，主键为" + id); //记录日志
                JscriptMsg("修改电影院抢票活动成功！", "action_list.aspx", "Success");
            }

        }

        /// <summary>
        /// 添加回复规则
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="modelId"></param>
        private void AddRule(int wid, int modelId)
        {
            rBll.AddModeltxtPicRule(wid, "电影院抢票", modelId, txtKW.Text.Trim());
        }



    }
}