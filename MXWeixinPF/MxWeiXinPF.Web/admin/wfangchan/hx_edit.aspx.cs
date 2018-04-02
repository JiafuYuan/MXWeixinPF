using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using System.Data;

namespace MxWeiXinPF.Web.admin.wfangchan
{
    public partial class hx_edit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型 
        private int id = 0;
        protected int fid;
        BLL.wx_fc_houseType bll = new BLL.wx_fc_houseType();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            fid = MXRequest.GetQueryInt("fid");
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
            //全景图
            BLL.wx_fc_panorama pBll = new BLL.wx_fc_panorama();
            DataTable pdt = pBll.GetList(" wid=" + weixin.id).Tables[0];
            this.ddlPanorama.Items.Clear();
            this.ddlPanorama.Items.Add(new ListItem("请选择全景相册...", ""));
            foreach (DataRow dr in pdt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["jdname"].ToString().Trim();
                this.ddlPanorama.Items.Add(new ListItem(Title, Id));
            }
            //子楼盘
            BLL.wx_fc_sonfloor sBll = new BLL.wx_fc_sonfloor();
            DataTable sdt = sBll.GetList(" wid=" + weixin.id + " and fid=" + fid).Tables[0];
            this.ddlSonfloor.Items.Clear();
            this.ddlSonfloor.Items.Add(new ListItem("请选择子楼盘...", ""));
            foreach (DataRow dr in sdt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["name"].ToString().Trim();
                this.ddlSonfloor.Items.Add(new ListItem(Title, Id));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            Model.wx_fc_houseType model = bll.GetModel(_id);

            string[] ft = model.houseType.Split('房');
            if (ft.Length >= 2)
            {
                string f = ft[0];
                string t = ft[1].Substring(0, 1);
                this.ddlFang.SelectedValue = f;
                this.ddlDing.SelectedValue = t;
            }
            this.txtJieshao.Text = model.Jieshao;
            this.txtJzmj.Text = model.jzmj.ToString();
            this.txtName.Text = model.Name;
            this.txtSort_id.Text = model.sort_id.ToString();
            this.txtStorey.Text = model.storey;
            this.slideA.ImageUrl = model.htimgA;
            this.slideAUrl.Text = model.htimgA;
            this.slideB.ImageUrl = model.htImgB;
            this.slideBUrl.Text = model.htImgB;
            this.slideC.ImageUrl = model.htimgC;
            this.slideCUrl.Text = model.htimgC;
            this.slideD.ImageUrl = model.htimgD;
            this.slideDUrl.Text = model.htimgD;
            this.ddlSonfloor.SelectedValue = model.sid.ToString();
            this.ddlPanorama.SelectedValue = model.pid.ToString();

        }
        #endregion


        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_houseType model = new Model.wx_fc_houseType();
            bool result = false;
            model.createDate = DateTime.Now;
            string ht = this.ddlFang.SelectedItem.Value + "房" + this.ddlDing.SelectedItem.Value + "厅";
            model.houseType = ht;
            model.htimgA = this.slideAUrl.Text;
            model.htImgB = this.slideBUrl.Text;
            model.htimgC = this.slideCUrl.Text;
            model.htimgD = this.slideDUrl.Text;
            model.Jieshao = this.txtJieshao.Text;
            model.jzmj = MyCommFun.Str2Decimal(this.txtJzmj.Text);
            model.Name = this.txtName.Text;
            model.sid = MyCommFun.Str2Int(this.ddlSonfloor.Text);
            model.pid = MyCommFun.Str2Int(this.ddlPanorama.Text);
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.storey = this.txtStorey.Text;
            model.wid = weixin.id;
            model.fid = fid;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加户型信息:" + model.Name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_fc_houseType model = bll.GetModel(_id);
            bool result = false;
            string ht = this.ddlFang.SelectedItem.Value + "房" + this.ddlDing.SelectedItem.Value + "厅";
            model.houseType = ht;
            model.htimgA = this.slideAUrl.Text;
            model.htImgB = this.slideBUrl.Text;
            model.htimgC = this.slideCUrl.Text;
            model.htimgD = this.slideDUrl.Text;
            model.Jieshao = this.txtJieshao.Text;
            model.jzmj = MyCommFun.Str2Decimal(this.txtJzmj.Text);
            model.Name = this.txtName.Text;
            model.sid = MyCommFun.Str2Int(this.ddlSonfloor.Text);
            model.pid = MyCommFun.Str2Int(this.ddlPanorama.Text);
            model.sort_id = MyCommFun.Str2Int(this.txtSort_id.Text);
            model.storey = this.txtStorey.Text;

            if (bll.Update(model))
            {
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改户型内容id:" + model.Id); //记录日志
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
                JscriptMsg("修改信息成功！", "hxMgr.aspx?id=" + fid, "Success");
            }
            else //添加
            {
                ChkAdminLevel("floormgr", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "hxMgr.aspx?id=" + fid, "Success");
            }
        }
    }
}