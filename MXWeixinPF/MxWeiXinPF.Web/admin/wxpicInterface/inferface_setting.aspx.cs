using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;
namespace MxWeiXinPF.Web.admin.wxpicInterface
{
    public partial class inferface_setting : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        wx_paizhao_setting tBll = new wx_paizhao_setting();

        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!Page.IsPostBack)
            {
                  ShowInfo();
                 
            }
        }



        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();
            Model.wx_paizhao_setting model = tBll.GetModelByWid(weixin.id);

            if (model != null)
            {
                hidid.Value = model.id.ToString();

                rblIsStart.SelectedValue = model.isOpen ? "1" : "0";

                txtenterKeyWords.Text = model.enterKeyWords.ToString();
                txtprompt.Text = model.prompt.ToString();
                txtinitApiUrl.Value = model.initApiUrl.ToString();
                txtpicApiUrl.Value = model.picApiUrl.ToString();

            }


             

        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            #region  //先判断
            string strErr = "";
            if (this.txtenterKeyWords.Text.Trim().Length == 0)
            {
                strErr += "进入打印的关键词不能为空！";
            }
           
            if (this.txtprompt.Text.Trim().Length == 0)
            {
                strErr += "回复提示不能为空！";
            }
            if (this.txtinitApiUrl.Value.Trim().Length == 0)
            {
                strErr += "初始化接口url不能为空！";
            }
            if (this.txtpicApiUrl.Value.Trim().Length == 0)
            {
                strErr += "传图片的接口url不能为空！";
            }

            if (strErr != "")
            {
                JscriptMsg(strErr, "back", "Error");
                return;
            }

            #endregion

            #region 赋值

            Model.wx_userweixin weixin = GetWeiXinCode();
            int id = MyCommFun.Str2Int(hidid.Value);

            Model.wx_paizhao_setting model = new Model.wx_paizhao_setting();

            if (id > 0)
            {
                model = tBll.GetModel(id);
            }

            model.isOpen = rblIsStart.SelectedItem.Value == "1" ? true : false;
            model.enterKeyWords = txtenterKeyWords.Text.ToString();
            model.initApiUrl = txtinitApiUrl.Value.ToString();
            model.picApiUrl = txtpicApiUrl.Value.ToString();
            model.prompt = txtprompt.Text.ToString();

            //start 判断接口是否开启了
            if (model.isOpen)
            {
                MxWeiXinPF.WeiXinComm.threeInterface.weipaiInterface wpi = new MxWeiXinPF.WeiXinComm.threeInterface.weipaiInterface();
                string retCode = wpi.weipaiSubscribe("test", weixin.id);
                if (retCode != "200")
                {
                    //失败
                    JscriptMsg("您尚未开通，请先与美图运营商开通后再开启！", "back", "Error");
                    return;
                }
            }
            //end 判断接口是否开启了

            #endregion

            if (id <= 0)
            {  //新增
                model.wid = weixin.id;
              
                //1新增主表
                id = tBll.Add(model);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加微拍接口信息，主键为" + id); //记录日志
                JscriptMsg("添加微拍接口信息成功！", "inferface_setting.aspx", "Success");
            }
            else
            {   //修改

                tBll.Update(model);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改微拍接口信息，主键为" + id); //记录日志
                JscriptMsg("修改微拍接口信息成功！", "inferface_setting.aspx", "Success");
            }

        }

    }
}