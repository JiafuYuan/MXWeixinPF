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
    public partial class caidan_shangjia : WeiXinPage
    {
     
        public int shopid = 0;
        public string openid = "";
        BLL.wx_diancai_shopinfo shopBll = new BLL.wx_diancai_shopinfo();
        Model.wx_diancai_shopinfo shopinfo = new Model.wx_diancai_shopinfo();
        BLL.wx_diancai_shop_setup picbll = new BLL.wx_diancai_shop_setup();
  
        public string shopname = "";
        protected decimal jiage = 0;
        protected string quyu = "";
        protected string tel = "";
        protected string status = "";
        protected string imageurl = "";
        protected string image = "";
        protected string active = "";
        public string shangjia = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            shopid = MyCommFun.RequestInt("shopid");
            if (!Page.IsPostBack)
            {
                 
                openid = MyCommFun.QueryString("openid");
         

                //获取所有商家
                DataSet dr=shopBll.GetList();

                if(dr.Tables[0].Rows.Count>0)
                {
                    for(int i=0;i<dr.Tables[0].Rows.Count;i++)
                    {
                        shangjia += "<li class=\"dandanb\"><a href=\"caidan_guanyu.aspx?shopid=" + dr.Tables[0].Rows[i]["id"].ToString() + "&openid=" + openid + "\"><span class=\"none shangjia\">";
                        shangjia +="<img src=\""+dr.Tables[0].Rows[i]["hotelLogo"].ToString()+"\" /><h2>"+dr.Tables[0].Rows[i]["hotelName"].ToString()+"</h2>";
                        shangjia += "<p>区域："+dr.Tables[0].Rows[i]["sendArea"].ToString()+"</p><p>起送价：￥"+dr.Tables[0].Rows[i]["sendPrice"].ToString()+"</p>";
                   

            

                    int stats = 0;

                    if (string.Compare(MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeEnd"]).ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare(MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeBegin"]).ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) > 0)
                    {
                       

                    }
                    else
                    {
                        stats += 1;
                    }

                    if (dr.Tables[0].Rows[i]["hoteltimeEnd1"].ToString() != null && dr.Tables[0].Rows[i]["hoteltimeBegin1"].ToString() != null)
                    {
                        if (string.Compare(MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeEnd1"]).ToString("HH:mm"), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare((MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeBegin1"]).ToString("HH:mm")), DateTime.Now.ToShortTimeString().ToString()) > 0)
                        {


                        }
                        else
                        {
                            stats += 1;
                        }
                    }

                    if (dr.Tables[0].Rows[i]["hoteltimeEnd2"].ToString() != null && dr.Tables[0].Rows[i]["hoteltimeBegin2"].ToString() != null)
                    {
                        if (string.Compare((MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeEnd2"]).ToString("HH:mm")), DateTime.Now.ToShortTimeString().ToString()) < 0 || string.Compare((MyCommFun.Obj2DateTime(dr.Tables[0].Rows[i]["hoteltimeBegin2"]).ToString("HH:mm")), DateTime.Now.ToShortTimeString().ToString()) > 0)
                        {


                        }
                        else
                        {
                            stats += 1;
                        }
                    }





                    if (stats > 0)
                    {
                        shangjia += "<em class=\"ok\">营业中</em><div class=\"clr\"></div></span></a></li>";
                    }
                    else
                    {
                        shangjia += "<em class=\"no\">未营业</em><div class=\"clr\"></div></span></a></li>";
                    }


                }

                }
           
           











                #region
                DataSet drs = picbll.GetList(shopid);
                if(drs.Tables[0].Rows.Count>0)
                {
                    int j = 0;
                    for (int i = 0; i < drs.Tables[0].Rows.Count;i++ )
                    {
                        image += "<li><p>" + drs.Tables[0].Rows[i]["advertisementName"] + "</p><a href=" + drs.Tables[0].Rows[i]["websetUrl"] + " > <img src=" + drs.Tables[0].Rows[i]["picUrl"] + "></a></li>";
                        j+=1;
                        if(i==1)
                        {
                            active+=" <li   class=\"active\"  >"+j+"</li>";
                        }
                        else
                        {
                            active+=" <li   >"+j+"</li>";
                        }
                        
                    }
                }
                #endregion


 

            }
        }
    }
}