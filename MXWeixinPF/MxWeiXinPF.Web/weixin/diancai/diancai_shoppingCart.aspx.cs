using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.diancai
{
    public partial class diancai_shoppingCart : WeiXinPage
    {
        public int shopid = 0;
        public string shopping = "";
        public string categories = "";
        public string openid = "";
       

    

        public string hotelName = "";
        public static int idf = 0;
        public string name = "";
        public string phone = "";
        protected string kongjian = "";
        protected string javascriptStr = "";
        protected string zhselect = "";

        public string rename = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindFormControl();
            }
        }



        protected void BindFormControl()
        {
            BLL.wx_diancai_caipin_category categorybll = new BLL.wx_diancai_caipin_category();

            BLL.wx_diancai_dingdan_caiping caipinbll = new BLL.wx_diancai_dingdan_caiping();

            BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
            Model.wx_diancai_member member = new Model.wx_diancai_member();

            BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
            Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();

            BLL.wx_diancai_form_control controlbll = new BLL.wx_diancai_form_control();



            openid = MyCommFun.QueryString("openid");

            shopid = MyCommFun.RequestInt("shopid");

            zhuohao(shopid);

            if (openid == "" || shopid == 0)
            {
                return;
            }


            shopinfo = shopBll.GetModel(shopid);
            rename = shopinfo.dcRename;
            hotelName = shopinfo.hotelName;
            idf = MyCommFun.RequestInt("id");

            member = menberbll.GetModel(shopid, openid);
            if (member != null)
            {
                name = member.memberName;
                phone = member.menberTel;
                this.address.InnerText = member.memberAddress;
            }

            if (shopinfo.limiteOrder && (!isOpen( shopinfo)))
            {
                contact_info.Style.Add("display", "none");
                showcard.Style.Add("display", "none");
                // MessageBox.ResponseScript(this, "$(\"#showcard2\").show();");
                showcard2.Style.Add("display", "");
                // contact_info.InnerHtml = "";

            }

            //获取控件
            DataSet ZH = controlbll.GetListZH(shopid);

            if (ZH.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ZH.Tables[0].Rows.Count; i++)
                {

                    if (ZH.Tables[0].Rows[i]["cType"].ToString() == "0")
                    {
                        kongjian += "<tr><td width=\"80px\"><label for=\"txt" + i + "\" class=\"ui-input-text\"  >" + ZH.Tables[0].Rows[i]["cName"] + "：</label></td>";
                        kongjian += "<td><div class=\"ui-input-text\">";
                        kongjian += " <input type=\"text\" id=\"txt" + i + "\" name=\"txt" + i + "\"  value=\"\"   class=\"ui-input-text\" placeholder=\"" + ZH.Tables[0].Rows[i]["defaultValue"] + "\">";
                        kongjian += "</div></td></tr>";

                        javascriptStr += "control_" + ZH.Tables[0].Rows[i]["seq"] + ":$(\"#txt" + i + "\").val(),";

                    }
                    else if (ZH.Tables[0].Rows[i]["cType"].ToString() == "1")
                    {
                        kongjian += "<tr><td width=\"80px\"><label for=\"select" + i + "\"  class=\"ui-input-text\"  >" + ZH.Tables[0].Rows[i]["cName"] + "：</label></td>";
                        kongjian += "<td>";
                        kongjian += "<select name=\"select" + i + "\" class=\"selectstyle\" id=\"select" + i + "\"  >";
                        if (ZH.Tables[0].Rows[i]["defaultValue"].ToString() != "")
                        {
                            string strzh = ZH.Tables[0].Rows[i]["defaultValue"].ToString().Replace("，", ",");
                            string[] sArray = strzh.Split(',');
                            for (int j = 0; j < sArray.Length; j++)
                            {
                                kongjian += "<option   value=" + sArray[j] + ">" + sArray[j] + "</option>";
                            }
                        }
                        kongjian += "</select>";
                        kongjian += "</td></tr>";

                        javascriptStr += "control_" + ZH.Tables[0].Rows[i]["seq"] + ":$(\"#select" + i + "\").val(),";
                    }



                }
            }

            categories = "{";

            DataSet category1 = categorybll.GetList(shopid);
            if (category1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < category1.Tables[0].Rows.Count; i++)
                {
                    categories += "\"" + category1.Tables[0].Rows[i]["id"].ToString() + "\"" + ":" + "\"" + category1.Tables[0].Rows[i]["categoryName"].ToString() + "\"" + ",";
                }
            }
            categories = categories.Substring(0, categories.Length - 1);
            categories += "}";

        }


        public void zhuohao(int shopid)
        {
            BLL.wx_diancai_desknum deskBll = new BLL.wx_diancai_desknum();
            DataSet zh = deskBll.GetListdesk(shopid);
            if (zh.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < zh.Tables[0].Rows.Count; i++)
                {
                    zhselect += "<option value=\"" + zh.Tables[0].Rows[i]["deskName"].ToString() + "\">" + zh.Tables[0].Rows[i]["deskName"].ToString() + "</option>";
                }
            }

        }


        /// <summary>
        /// 是否在运营中
        /// </summary>
        /// <returns></returns>
        public bool isOpen(Model.wx_diancai_shopinfo shopinfo)
        {
            int stats = 0;

            if (DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeEnd), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) < 0 || DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeBegin), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) > 0)
            {


            }
            else
            {
                stats += 1;
            }

            if (shopinfo.hoteltimeEnd1 != null && shopinfo.hoteltimeBegin1 != null)
            {
                if (DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeEnd1), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) < 0 || DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeBegin1), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) > 0)
                {


                }
                else
                {
                    stats += 1;
                }
            }

            if (shopinfo.hoteltimeEnd2 != null && shopinfo.hoteltimeBegin2 != null)
            {
                if (DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeEnd2), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) < 0 || DateTime.Compare(Convert.ToDateTime(shopinfo.hoteltimeBegin2), Convert.ToDateTime("2100-1-1 " + DateTime.Now.ToShortTimeString())) > 0)
                {


                }
                else
                {
                    stats += 1;
                }
            }





            if (stats > 0)
            {
                return true;// status = "<em class=\"ok\">营业中</em>";
            }
            else
            {
                return false;// status = "<em class=\"no\">未营业</em>";
            }

        }


    }
}