using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.BLL;

namespace MxWeiXinPF.Web.admin.ucard
{
    public partial class card_design : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        protected int sid = 0;//店铺主键id

        BLL.wx_ucard_cardinfo cardBll = new wx_ucard_cardinfo();
        //返回用户对应的商店id
        int getStoreid()
        {
            int id = 0;
            BLL.wx_ucard_store storeBll = new BLL.wx_ucard_store();
            Model.wx_userweixin weixin = GetWeiXinCode();
            IList<Model.wx_ucard_store> usList = storeBll.GetModelList(" wid='" + weixin.id + "' order by createDate desc,id desc");
            if (usList != null && usList.Count > 0)
            {
                id = usList[0].id;
            }
            return id;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("ucard_km", MXEnums.ActionEnum.View.ToString()); //检查权限

            sid = getStoreid();
            if (sid == 0)
            {
                JscriptMsg("请先在商家设置里面添加一个店铺!!", "back", "Error");
                return;
            }

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        private void ShowInfo()
        {
            IList<Model.wx_ucard_cardinfo> cardlist = cardBll.GetModelList("sId=" + sid);
            if (cardlist == null || cardlist.Count <= 0)
            {
                return;
            }
            Model.wx_ucard_cardinfo card = cardlist[0];
            hidid.Value = card.id.ToString();

            txtcardName.Text = card.cardName;
            vipname.InnerText = card.cardName;
            vipname.Style.Add("color", card.cardNameColor.ToString());
            txtcardNameColor.Text = card.cardNameColor.ToString().Substring(1);
            txtImgICO.Text = card.logo;
            cardlogo.Src = card.logo;
            if (card.bgUrl == null || card.bgUrl.ToString().Trim() == "")
            {
                ddlbgTypeId.SelectedValue = card.bgTypeUrl;
                txtbgUrl.Text = "";
                cardbg.Src = card.bgTypeUrl;
            }
            else
            {
                txtbgUrl.Text = card.bgUrl;
                cardbg.Src = card.bgUrl;
            }
            txtcardNoColor.Text = card.cardNoColor.ToString().Substring(1);
            number.Style.Add("color", card.cardNoColor.ToString());
            txtnoticePic.Value = card.noticePic;
            txtprivilegesPic.Value = card.privilegesPic;
            txtqiandaoPic.Value = card.qiandaoPic;
            txtshopingPic.Value = card.shopingPic;
            txtperinfoPic.Value = card.perinfoPic;
            txtinstructionsPic.Value = card.instructionsPic;
            txtcontactusPic.Value = card.contactusPic;

            news.Src = card.noticePic;
            vippower.Src = card.privilegesPic;
            qiandao.Src = card.qiandaoPic;
            shopping.Src = card.shopingPic;
            user.Src = card.perinfoPic;
            info.Src = card.instructionsPic;
            addr.Src = card.contactusPic;
        }

        #endregion



        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = MyCommFun.Str2Int(hidid.Value);
            Model.wx_ucard_cardinfo card = new Model.wx_ucard_cardinfo();

            if (id > 0)
            {
                card = cardBll.GetModel(id);
            }
            card.cardName = txtcardName.Text.Trim();
            card.cardNameColor = "#" + txtcardNameColor.Text;
            card.logo = Request.Form["txtImgICO"].Trim();

            if (txtbgUrl.Text.Trim() == "")
            {
                card.bgTypeUrl = ddlbgTypeId.SelectedItem.Value;
                card.bgUrl = "";
            }
            else
            {
                card.bgTypeUrl = "";
                card.bgUrl = txtbgUrl.Text.Trim();
            }

            card.cardNoColor = "#" + txtcardNoColor.Text;
            card.noticePic = txtnoticePic.Value;
            card.privilegesPic = txtprivilegesPic.Value;
            card.qiandaoPic = txtqiandaoPic.Value;
            card.shopingPic = txtshopingPic.Value;
            card.perinfoPic = txtperinfoPic.Value;
            card.instructionsPic = txtinstructionsPic.Value;
            card.contactusPic = txtcontactusPic.Value;

            if (id > 0)
            {
                ChkAdminLevel("ucard_km", MXEnums.ActionEnum.Edit.ToString()); //检查权限

                //修改
                cardBll.Update(card);
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "设置卡版面信息，主键为" + id); //记录日志
                JscriptMsg("设置卡版面信息成功！", "card_design.aspx", "Success");
            }
            else
            {
                ChkAdminLevel("ucard_km", MXEnums.ActionEnum.Add.ToString()); //检查权限
                //新增
                card.sId = sid;
                card.createDate = DateTime.Now;
                cardBll.Add(card);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "设置卡版面信息，主键为" + id); //记录日志
                JscriptMsg("设置卡版面信息成功！", "card_design.aspx", "Success");


            }



        }




    }
}