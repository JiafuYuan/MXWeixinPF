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
    public partial class yyddDetail : Web.UI.ManagePage
    {
        protected int id;
        protected int fid;
        BLL.wx_fc_yyInfo yiBll = new BLL.wx_fc_yyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = MyCommFun.RequestInt("id");
            fid = MyCommFun.RequestInt("fid");
            if (!IsPostBack)
            {
                DataRow dr = yiBll.GetList("id=" + id).Tables[0].Rows[0];
                lblObj.Text = dr["hxname"].ToString();
                lblPerson.Text = dr["name"].ToString();
                lblRemark.Text = dr["remark"].ToString();
                lblTelephone.Text = dr["telephone"].ToString();
                lblxddate.Text = MyCommFun.Obj2DateTime(dr["createdate"]).ToString("yyyy年MM月dd日 hh:mm:ss点");
                lblyydate.Text = MyCommFun.Obj2DateTime(dr["yydate"]).ToString("yyyy-MM-dd") + " / " + dr["yydatepart"].ToString();
                this.ddlStatus.SelectedValue = dr["orderStatus"].ToString();
                this.txtkfremark.Text = dr["kfRemark"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_fc_yyInfo yiModel = yiBll.GetModel(id);
            yiModel.kfRemark = this.txtkfremark.Text;
            yiModel.orderStatus = this.ddlStatus.SelectedItem.Text;
            yiBll.Update(yiModel);
            JscriptMsg("修改信息成功！", "yyddMgr.aspx?id=" + fid, "Success");
        }
    }
}