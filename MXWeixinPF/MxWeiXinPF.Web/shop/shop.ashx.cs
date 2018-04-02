using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxWeiXinPF.Common;
using System.Text;
using System.Data;
namespace MxWeiXinPF.Web.shop
{
    /// <summary>
    /// shop 的摘要说明
    /// </summary>
    public class shop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.wx_shop_cart cartBll = new BLL.wx_shop_cart();
            string _action = MyCommFun.QueryString("myact");
            string openid = MyCommFun.RequestOpenid();  //得到微信用户的openid
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            if (_action == "LoadProduct")
            {
                #region 选择排序，改变商品列表
                string sortColumn = MyCommFun.RequestParam("sortColumn");
                int wid = MyCommFun.RequestInt("wid");
                int id = MyCommFun.RequestInt("cid");
                string name = MyCommFun.RequestParam("name");
                string flog = MyCommFun.RequestParam("flog");
                string gd = MyCommFun.RequestParam("gd");
                DataSet ds = null;
                BLL.wx_shop_product proBll = new BLL.wx_shop_product();
                StringBuilder jsonStr = new StringBuilder();
                if (id != 0)
                {

                    if (sortColumn == "priceDesc")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " order  by  marketPrice desc ");
                    }
                    if (sortColumn == "priceDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " and productName like " + "'%" + name + "%'" + "order  by  marketPrice desc ");
                    }
                    if (sortColumn == "priceAsc")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " order  by  marketPrice asc  ");

                    } if (sortColumn == "priceAsc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " and productName like " + "'%" + name + "%'" + "order  by  marketPrice asc ");

                    }
                    if (sortColumn == "newDesc")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " and latest=" + 1 + " order  by  latest desc  ");
                    }
                    if (sortColumn == "newDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id +" and latest="+1+" and productName like " + "'%" + name + "%'" + "order  by  latest desc ");
                    }
                    if (sortColumn == "saleDesc")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " and hotsale=" + 1 + " order  by  hotsale desc  ");

                    }
                    if (sortColumn == "saleDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, "categoryId=" + id + " and hotsale=" + 1 + " and productName like " + "'%" + name + "%'" + "order  by hotsale desc ");

                    }
                }
                else {

                    if (sortColumn == "priceDesc")
                    {
                        ds = proBll.GetList(wid, 20,  "1=1 order  by  marketPrice desc ");
                    }
                    if (sortColumn == "priceDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, " productName like " + "'%" + name + "%'" + "order  by  marketPrice desc ");
                    }
                    if (sortColumn == "priceAsc")
                    {
                        ds = proBll.GetList(wid, 20, " 1=1 order  by  marketPrice asc  ");

                    } if (sortColumn == "priceAsc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 27, " productName like " + "'%" + name + "%'" + "order  by  marketPrice asc ");

                    }
                    if (sortColumn == "newDesc")
                    {
                        ds = proBll.GetList(wid, 20, " latest="+1+" order  by  latest desc  ");
                    }
                    if (sortColumn == "newDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, " latest=" + 1 + "productName like " + "'%" + name + "%'" + "order  by  latest desc ");
                    }
                    if (sortColumn == "saleDesc")
                    {
                        ds = proBll.GetList(wid, 20, "hotsale=" + 1 + " order  by  hotsale desc  ");

                    }
                    if (sortColumn == "saleDesc" && flog == "true")
                    {
                        ds = proBll.GetList(wid, 20, "hotsale="+1+" and productName like " + "'%" + name + "%'" + "order  by hotsale desc ");

                    }
                }



                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (id != 0)
                    {
                        if (gd == "")
                        {
                            foreach (DataRow d in ds.Tables[0].Rows)
                            {

                                jsonStr.Append("<div class=\"lists_items\"> <p class=\"pic\"> <a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"> <img src=\"" + d["productpic"] + "\"></a> </p>");
                                jsonStr.Append("<p class=\"list_tex\"><a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><span><font>￥" + d["marketPrice"] + "</font></span><strong>" + d["productName"] + "</strong></br>" + d["sku"] + "</a> </p>");
                                jsonStr.Append("<p class=\"list_tex\"><a class=\"activemsg\" href=\"\"></a></p><p class=\"list_tex\" ><span class=\"txt_blue\">库存" + d["stock"] + "</span></p> </div>");

                            }
                            jsonStr.Append("<div class=\"details_more\" style=\"float:left; width:100%;\"><A href=\"javascript:void(0);\" id=\"gengduo\" onclick=\"gengduo()\"><span>查看更多</span><br />可能产生较多流量<br /> </A>");

                        }
                        else
                        {
                            foreach (DataRow d in ds.Tables[0].Rows)
                            {

                                jsonStr.Append("<div class=\"list_msg list_with_img\" style=\"margin-top:10px;font-size:12px;\"> <a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><img style=\"top:16px;\" src=\"" + d["productpic"] + "\">");
                                jsonStr.Append("<p class=\"list_tex\">" + d["productName"] + "<span class=\"txt_red\" style=\"font-size:12px;\">￥" + d["marketPrice"] + "</span></p><p class=\"list_tex\">" + d["sku"] + "</p><p class=\"list_tex\">158人评价，98%好评");
                                jsonStr.Append("<span class=\"txt_blue\" style=\"font-size:12px;\">库存" + d["stock"] + "</span></p></a></div>");
                              }

                      
                          
                                 }
                    }
                    else {
                       
                            if (gd == "")
                        {
                            foreach (DataRow d in ds.Tables[0].Rows)
                            {

                                jsonStr.Append("<div class=\"lists_items\"> <p class=\"pic\"> <a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"> <img src=\"" + d["productpic"] + "\"></a> </p>");
                                jsonStr.Append("<p class=\"list_tex\"><a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><span><font>￥" + d["marketPrice"] + "</font></span><strong>" + d["productName"] + "</strong></br>" + d["sku"] + "</a> </p>");
                                jsonStr.Append("<p class=\"list_tex\"><a class=\"activemsg\" href=\"\"></a></p><p class=\"list_tex\" ><span class=\"txt_blue\">库存" + d["stock"] + "</span></p> </div>");

                            }
                            jsonStr.Append("<div class=\"details_more\" style=\"float:left; width:100%;\"><A href=\"javascript:void(0);\" id=\"gengduo\" onclick=\"gengduo()\"><span>查看更多</span><br />可能产生较多流量<br /> </A>");

                        }
                        else
                        {
                            foreach (DataRow d in ds.Tables[0].Rows)
                            {

                                jsonStr.Append("<div class=\"list_msg list_with_img\" style=\"margin-top:10px;font-size:12px;\"> <a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><img style=\"top:16px;\" src=\"" + d["productpic"] + "\">");
                                jsonStr.Append("<p class=\"list_tex\">" + d["productName"] + "<span class=\"txt_red\" style=\"font-size:12px;\">￥" + d["marketPrice"] + "</span></p><p class=\"list_tex\">" + d["sku"] + "</p><p class=\"list_tex\">158人评价，98%好评");
                                jsonStr.Append("<span class=\"txt_blue\" style=\"font-size:12px;\">库存" + d["stock"] + "</span></p></a></div>");
                              }


                        }
                       
    
                    }
                
                }
                
                
                  
                context.Response.Write(jsonStr);
                #endregion
            }
            else if (_action == "sousuo")
            {
                #region 选择商品名称，改变商品列表
               
                string name = MyCommFun.RequestParam("name");
                int wid = MyCommFun.RequestInt("wid");
                DataSet ds = null;
                BLL.wx_shop_product proBll = new BLL.wx_shop_product();
                StringBuilder jsonStr = new StringBuilder();
                
                 ds = proBll.GetList(wid, 20, " productName like " + "'%" + name + "%'" + "");
               
               
                if (ds != null && ds.Tables[0] != null&&ds.Tables[0].Rows.Count>0)
                {
                   
                        foreach (DataRow d in ds.Tables[0].Rows)
                        {

                            jsonStr.Append("<div class=\"lists_items\"> <p class=\"pic\"> <a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"> <img src=\"" + d["productpic"] + "\"></a> </p>");
                            jsonStr.Append("<p class=\"list_tex\"><a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><span><font>￥" + d["marketPrice"] + "</font></span><strong>" + d["productName"] + "</strong></br>" + d["sku"] + "</a> </p>");
                            jsonStr.Append("<p class=\"list_tex\"><a class=\"activemsg\" href=\"\"></a></p><p class=\"list_tex\" ><span class=\"txt_blue\">库存" + d["stock"] + "</span>1534人评价，96%好评</p> </div>");

                        }
                        jsonStr.Append("<div class=\"details_more\" style=\"float:left; width:100%;\"><A href=\"javascript:void(0);\" id=\"gengduo\" onclick=\"gengduo()\"><span>查看更多</span><br />可能产生较多流量<br /> </A>");
                   
                   
                }

                context.Response.Write(jsonStr);
                #endregion
            }
            else  if (_action == "gengduo")
            {
                #region 查看更多

                int wid = MyCommFun.RequestInt("wid");
                int id = MyCommFun.RequestInt("cid");
                DataSet ds = null;
                BLL.wx_shop_product proBll = new BLL.wx_shop_product();
                StringBuilder jsonStr = new StringBuilder();
                if (id != 0)
                {
                    ds = proBll.GetList(wid, -1, "categoryId=" + id + " and p.hotsale="+1+ " order  by  p.hotsale desc  ");
                }
                else {
                    ds = proBll.GetList(wid, -1, "p.hotsale="+1+" order  by  p.hotsale desc  ");
                }


                if (ds != null && ds.Tables[0] != null)
                {
                    foreach (DataRow d in ds.Tables[0].Rows)
                    {

                        jsonStr.Append("<div class=\"list_msg list_with_img\" style=\"margin-top:10px;font-size:12px;\"><a href=\"/shop/detail.aspx?wid=" + wid + "&pid=" + d["id"] + "&openid=" + openid + "\"><img style=\"top:16px;\" src=\"" + d["productpic"] + "\">");
                        jsonStr.Append("<p class=\"list_tex\">" + d["productName"] + "<span class=\"txt_red\" style=\"font-size:12px;\">￥" + d["marketPrice"] + "</span></p><p class=\"list_tex\">" + d["sku"] + "</p><p class=\"list_tex\">158人评价，98%好评");
                        jsonStr.Append("<span class=\"txt_blue\" style=\"font-size:12px;\">库存" + d["stock"] + "</span></p></a></div>");



                    }

                }

                context.Response.Write(jsonStr);
                #endregion
            }
            else if (_action == "checkid")
            {
                #region 是否存在该商品
                jsonDict = new Dictionary<string, string>();
                int wid = MyCommFun.RequestInt("wid");
                int id = MyCommFun.RequestInt("id");
                BLL.wx_shop_product proBll = new BLL.wx_shop_product();
                DataSet ds=null;
                ds =proBll.GetList("wid="+wid+" and id="+id+"");
                BLL.wx_shop_sku skuBll = new BLL.wx_shop_sku();
                Model.wx_shop_sku skuModel=skuBll.GetModel(id);
                if (ds != null &&ds.Tables[0].Rows.Count>0)
                {
                    jsonDict.Add("data", ds.Tables[0].Rows[0]["stock"].ToString());
                }
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                #endregion

            } 
           
            
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}