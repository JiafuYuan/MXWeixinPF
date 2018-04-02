using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.diancai
{
    public partial class diancai_dingdan : WeiXinPage
    {
       
        public static  int shopid = 0;
        public string openid = "";
        public string dingdan = "";
        public   string Dingdanlist="";
        public   string dingdanren="";

        BLL.wx_diancai_dingdan_manage manage = new BLL.wx_diancai_dingdan_manage();
        Model.wx_diancai_dingdan_manage managemodel = new Model.wx_diancai_dingdan_manage();

        BLL.wx_diancai_shopinfo shopbll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo sjopmodel = new Model.wx_diancai_shopinfo();
        public string hotelName = "";
        public string type = "";
        public string rename = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = MyCommFun.RequestInt("shopid");
            openid = MyCommFun.QueryString("openid");
            dingdan = MyCommFun.QueryString("dingdan");
            if (!Page.IsPostBack)
            {
               
                sjopmodel = shopbll.GetModel(shopid);
                hotelName = sjopmodel.hotelName;
                rename = sjopmodel.dcRename;
                type = MyCommFun.QueryString("type");
                if (type=="delete")
                {
                    if (manage.Delete(dingdan))
                    {
                        contact_info.Style.Add("display", "none");
                        showcard.Style.Add("display", "none");
                        showcard.HRef = "#";
                        return;
                    }
                    else
                    {
                        showcard.HRef = "diancai_dingdan.aspx?dingdan=" + dingdan + "&type=delete&shopid=" + shopid + "&openid=" + openid;
                    }
                }
               

             
                if (dingdan!="")
                {
                    List(dingdan);
                }
             
               
            }
        }

        public void List(string dingdan)
        {
            
            //订单
            Dingdanlist = "";
            dingdanren = "";

            DataSet dr = manage.Getcaopin(dingdan);
            if(dr.Tables[0].Rows.Count>0)
            {
                decimal amount = 0;

                  
   
                Dingdanlist+="<tr><th>菜品名称</th><th class=\"cc\">单价</th><th class=\"cc\">购买份数</th><th class=\"rr\">价格</th> </tr>";
                for (int i=0;i<dr.Tables[0].Rows.Count;i++)
                {
                Dingdanlist+=" <tr><td>"+dr.Tables[0].Rows[i]["cpName"]+"</td>";
                Dingdanlist+="<td class=\"cc\">"+dr.Tables[0].Rows[i]["price"]+"</td>";
                Dingdanlist+="<td class=\"cc\">"+dr.Tables[0].Rows[i]["num"]+"</td>";
                Dingdanlist+="<td class=\"rr\">￥"+dr.Tables[0].Rows[i]["totpric"]+"</td></tr>";
                amount += Convert.ToDecimal( dr.Tables[0].Rows[i]["totpric"]);
                }
                decimal zongji = amount;

                 //订单满多少免配送费
               
                decimal psf = 0;
                if (amount < sjopmodel.freeSendcost)
                {
                    zongji  += Convert.ToDecimal(sjopmodel.sendCost);
                   
                    psf = sjopmodel.sendCost.Value;
                }



                Dingdanlist += "<tr><td>商品总费</td><td class=\"cc\">￥" + amount + "</td>  <td class=\"cc\" >配送费</td><td class=\"rr\" >￥" + psf + "</td></tr>";
                Dingdanlist += "<tr><td>总计：</td><td ></td><td ></td><td class=\"rr\">￥" + zongji + "</td></tr>";

            }


            managemodel = manage.GetModeldingdan(dingdan);
            //订单信息
            if (managemodel != null)
            {
                dingdanren += "<tr><td width=\"70\">订单编号： " + managemodel.orderNumber + "</td></tr>";
                dingdanren += "<tr> <td>下单时间：" + managemodel.oderTime + "</td></tr>";
                dingdanren += "<tr><td>联系人：" + managemodel.customerName + "</td></tr>";
                dingdanren += "<tr><td>联系电话：" + managemodel.customerTel + "</td></tr>";
                dingdanren += "<tr><td>地址：" + managemodel.address + "</td></tr>";
                dingdanren += "<tr><td>备注 ：" + managemodel.oderRemark + "</td></tr>";
                if (managemodel.payStatus == 1)
                {
                    dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='ok'>成功</em></td></tr>";
                    showcard.Style.Add("display", "none");
                    showcard2.Style.Add("display", "");
                    showcard.HRef = "#";
                }
                else if (managemodel.payStatus == 2)
                {
                   
                    dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='error'>失败</em></td></tr>";
                    showcard.HRef = "diancai_dingdan.aspx?dingdan=" + dingdan + "&type=delete&shopid=" + shopid + "&openid=" + openid;
                }
                else
                {
                    dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='no'>未处理</em></td></tr>";
                    showcard.HRef = "diancai_dingdan.aspx?dingdan=" + dingdan + "&type=delete&shopid=" + shopid + "&openid=" + openid;
                }


            }
            else
            {
                dingdanren += "<tr><td width=\"70\">订单编号：</td></tr>";
                dingdanren += "<tr> <td>下单时间：</td></tr>";
                dingdanren += "<tr><td>联系人：</td></tr>";
                dingdanren += "<tr><td>联系电话：</td></tr>";
                dingdanren += "<tr><td>地址：</td></tr>";
                dingdanren += "<tr><td>备注 ：</td></tr>";
    
            
               dingdanren += "<tr><td>订单状态：<em  style='width:70px;' class='no'>未处理</em></td></tr>";
              
            }
       
            
            dingdanren += "<tr><td>商家留言：</td></tr> <tr> <td></td></tr>"; 
        }

    }
}