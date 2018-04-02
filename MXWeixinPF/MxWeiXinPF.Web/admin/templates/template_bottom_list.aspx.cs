using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;

namespace MxWeiXinPF.Web.admin.templates
{
    public partial class template_bottom_list : Web.UI.ManagePage
    {
        wx_templates tBll = new wx_templates();
        wx_wsite_modulebase mBll = new wx_wsite_modulebase();
        wx_templates_wcode twBll = new wx_templates_wcode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();
                RptBind(weixin.id);
            }
        }

        #region 数据绑定=================================
        /// <summary>
        /// 绑定模版,颜色
        /// </summary>
        /// <param name="wid"></param>
        private void RptBind(int wid)
        {

            // 底部菜单模版数据绑定
            this.rptList2.DataSource = tBll.GetModelList("typeId=5 order by seq asc");
            this.rptList2.DataBind();

            //绑定当前微帐号选择的底部菜单模版Id 
            IList<Model.wx_templates_wcode> twlist = twBll.GetModelList("wid=" + wid);
            if (twlist != null && twlist.Count() > 0)
            {
                string bmenuTid = twlist[0].bmenuTid.ToString();
                hidWTId.Value = twlist[0].id.ToString();
              
                MessageBox.ResponseScript(this, "$(\"#rad" + bmenuTid + "\").attr(\"checked\",\"checked\"); ");
            }

        }




        #endregion


        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {

            int bmenuTid = MyCommFun.Str2Int(txtSelectTemplateId.Text);
            if (bmenuTid != 0)
            {
                Model.wx_userweixin weixin = GetWeiXinCode();

                Model.wx_templates_wcode tw = new Model.wx_templates_wcode();
                bool isAdd = true;
                bool Succ = false;
                if (hidWTId.Value != "0")
                {
                    int wtId = MyCommFun.Str2Int(hidWTId.Value);
                    tw = twBll.GetModel(wtId);
                    if (tw != null)
                    {
                        isAdd = false;
                    }
                }
                tw.wid = weixin.id;
                tw.bmenuTid = bmenuTid;
            
                if (isAdd)
                {

                    tw.createDate = DateTime.Now;
                    int id = twBll.Add(tw);
                    if (id > 0)
                    { Succ = true; }
                    hidWTId.Value = id.ToString();
                }
                else
                {
                    Succ = twBll.Update(tw);
                }
                if (Succ)
                {
                    JscriptMsg("底部菜单风格设置成功！", "template_bottom_list.aspx", "Success");
                }
                else
                {
                    JscriptMsg("底部菜单风格设置失败！", "", "Error");
                }
            }


        }
 
       
    }
}