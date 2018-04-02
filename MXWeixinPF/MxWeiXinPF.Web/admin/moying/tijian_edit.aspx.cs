using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.admin.moying
{
    public partial class tijian_edit : Web.UI.ManagePage
    {
        private string _action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected int uid;
        BLL.wx_my_tijian bll = new BLL.wx_my_tijian();
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("moyingtijian", MXEnums.ActionEnum.View.ToString()); //检查权限
            id = MXRequest.GetQueryInt("id");
            uid = MXRequest.GetQueryInt("uid");
            _action = MXRequest.GetQueryString("action");
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
                {
                    showInfo(id);
                }
            }
        }

        void showInfo(int _id)
        {
            Model.wx_my_tijian model = bll.GetModel(_id);
            this.txtDetail.Text = model.tijiandetails;
            this.txtFu.Text = model.tijianfu.ToString();
            this.txtGao.Text = model.tijiangao.ToString();
            this.txtTou.Text = model.tijiantou.ToString();
            this.txtXiong.Text = model.tijianxiong.ToString();
            this.txtZhong.Text = model.tijianzhong.ToString();
            this.txtDate.Text = model.tijiandate.ToString();
        }

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            Model.wx_my_tijian model = bll.GetModel(_id);
            DateTime tjDate = MyCommFun.Obj2DateTime(this.txtDate.Text);
            model.tijiandate = tjDate;
            model.tijianmonth = MyCommFun.Str2Int(tjDate.ToString("MM"));
            model.tijiandetails = this.txtDetail.Text;
            model.tijianfu = MyCommFun.Str2Decimal(this.txtFu.Text);
            model.tijiangao = MyCommFun.Str2Decimal(this.txtGao.Text);
            model.tijianzhong = MyCommFun.Str2Decimal(this.txtZhong.Text);
            model.tijianxiong = MyCommFun.Str2Decimal(this.txtXiong.Text);
            model.tijiantou = MyCommFun.Str2Decimal(this.txtTou.Text); 

            if (bll.Update(model))
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region 修改操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.wx_my_tijian model = new Model.wx_my_tijian();
            Model.manager mModel = GetAdminInfo();
            Model.wx_userweixin uModel = GetWeiXinCode();
            model.adminname = mModel.user_name;
            model.wid = uModel.id;
            DateTime tjDate = MyCommFun.Obj2DateTime(this.txtDate.Text);
            model.tijianluru = DateTime.Now;
            model.tijiandate = tjDate;
            model.tijianmonth = MyCommFun.Str2Int(tjDate.ToString("MM"));
            model.tijiandetails = this.txtDetail.Text;
            model.tijianfu = MyCommFun.Str2Decimal(this.txtFu.Text);
            model.tijiangao = MyCommFun.Str2Decimal(this.txtGao.Text);
            model.tijianzhong = MyCommFun.Str2Decimal(this.txtZhong.Text);
            model.tijianxiong = MyCommFun.Str2Decimal(this.txtXiong.Text);
            model.tijiantou = MyCommFun.Str2Decimal(this.txtTou.Text);
            model.userid = uid;
            if (bll.Add(model) > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("moyingtijian", MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "tijianinfo_list.aspx?uid=" + uid, "Success");
            }
            else //添加
            {
                ChkAdminLevel("moyingtijian", MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "tijianinfo_list.aspx?uid=" + uid, "Success");
            }
        }
    }
}