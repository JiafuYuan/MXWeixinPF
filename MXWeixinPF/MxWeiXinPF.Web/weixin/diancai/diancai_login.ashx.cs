using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxWeiXinPF.Web.weixin.diancai
{
    /// <summary>
    /// diancai_login 的摘要说明
    /// </summary>
    public class diancai_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            string username = MyCommFun.QueryString("username");
            string parssword = MyCommFun.QueryString("parssword");
            string id = MyCommFun.QueryString("id");
            string openid = MyCommFun.QueryString("openid");
            string state = MyCommFun.QueryString("state");
            string goodsData = QueryString("goodsData");
            int shopid = MyCommFun.RequestInt("shopid");
           

            BLL.wx_diancai_dianyuan dianyuanbll = new BLL.wx_diancai_dianyuan();
            Model.wx_diancai_dianyuan dianyuan = new Model.wx_diancai_dianyuan();


            BLL.wx_diancai_caipin_category categorybll = new BLL.wx_diancai_caipin_category();

            BLL.wx_diancai_member menberbll = new BLL.wx_diancai_member();
            Model.wx_diancai_member member = new Model.wx_diancai_member();

            BLL.wx_diancai_dingdan_manage manage = new BLL.wx_diancai_dingdan_manage();
            Model.wx_diancai_dingdan_manage managemodel = new Model.wx_diancai_dingdan_manage();
            BLL.wx_diancai_dingdan_caiping caipinbll = new BLL.wx_diancai_dingdan_caiping();
            Model.wx_diancai_dingdan_caiping caipin = new Model.wx_diancai_dingdan_caiping();

            if (_action == "login")
            {
                if (dianyuanbll.Exists(username, parssword))
                {
                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "登录成功！");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
                else
                {
                    jsonDict.Add("ret", "fail");
                    jsonDict.Add("content", "密码错误！");

                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }
            }

            else  if (_action == "setstatus")
            {
                //id

                if (manage.Updatestatus(id, state))
                {
                    managemodel = manage.GetModel(MyCommFun.Str2Int(id));
                    BLL.wx_diancai_member menbll = new BLL.wx_diancai_member();
                    if (state == "1")
                    {

                        menbll.Update(managemodel.openid);
                    }
                    if (state == "2")
                    {

                        menbll.Updatefail(managemodel.openid);
                    }

                    jsonDict.Add("ret", "ok");
                    jsonDict.Add("content", "提交成功！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                }

            }

            else if (_action =="addmember")
            {
                #region 用户基本信息管理
                member = menberbll.GetModel( shopid, openid);
                bool isAdd = false;
                if (member == null)
                {
                    isAdd = true;
                }
                else
                {
                    if (member.status.Value == 0)
                    { 
                        //处于黑名单里
                        jsonDict.Add("ret", "fail");
                        jsonDict.Add("content", "您处于黑名单里！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                }

            
                    member.shopid = shopid;
                    member.openid = openid;
                    member.weixinName = MyCommFun.QueryString("weixinName");
                    member.Name = MyCommFun.QueryString("username");
                    member.memberName = MyCommFun.QueryString("username");
                    member.menberTel = MyCommFun.QueryString("customerTel");
                    member.memberAddress = MyCommFun.QueryString("address");
                    member.successDingdan = 0;
                    member.failDingdan = 0;
                    member.cancelDingdan = 0;
                    member.zongjifen = 0;
                    member.zongcje = 0;
                    member.status = 0;
                    member.createDate = DateTime.Now;
               
                if (isAdd)
                {
                    menberbll.Add(member);
                }
                else
                {
                    menberbll.Update (member);
                }

               jsonDict.Add("ret", "ok");
               jsonDict.Add("content", "提交成功！");
               context.Response.Write(MyCommFun.getJsonStr(jsonDict));


                #endregion

            }
            else  if (_action == "addcaidan")
            {
                string deskNumber=MyCommFun.QueryString("deskNumber");//桌号
                //用户点菜完，提交订单
                #region 判断参数是否合法，判断用户是否处于黑名单里
                if (goodsData == "" || openid=="")
                {
                    jsonDict.Add("ret", "err");
                    jsonDict.Add("content", "订单提交失败,参数为空值！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                member = menberbll.GetModel(shopid, openid);
                bool isAdd = false;
                if (member == null)
                {
                    isAdd = true;
                    member = new Model.wx_diancai_member();
                }
                else
                {
                    if (member.status.Value == 0)
                    {
                        //处于黑名单里
                        jsonDict.Add("ret", "fail");
                        jsonDict.Add("content", "您处于黑名单里,不能下单！");
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                }

                #endregion

                //获得商家信息
                BLL.wx_diancai_shopinfo shopbll = new BLL.wx_diancai_shopinfo();
                Model.wx_diancai_shopinfo shopinfoEntity = new Model.wx_diancai_shopinfo();
                shopinfoEntity = shopbll.GetModel(shopid);

                #region 计算商品总价格
                decimal payAmount = 0;
                string[] sArray = goodsData.Split(';');

                for (int i = 0; i < sArray.Length - 1; i++)
                {
                    string[] sAr = sArray[i].Split(',');
                    payAmount += Convert.ToInt32(sAr[1]) * Convert.ToDecimal(sAr[2]);//总价

                }

                #endregion

              
                member.shopid = shopid;
                member.openid = openid;
               
                member.Name = MyCommFun.QueryString("name");
                member.memberName = MyCommFun.QueryString("name");
                member.menberTel = MyCommFun.QueryString("phone");
                member.memberAddress = MyCommFun.QueryString("address");
                member.successDingdan = 0;
                member.failDingdan = 0;
                member.cancelDingdan = 0;
                member.zongjifen = 0;
                member.zongcje = 0;
                member.status = 0;
                member.createDate = DateTime.Now;
            
                if (isAdd)
                {
                    menberbll.Add(member);
                }
                else
                {
                    menberbll.Update (member);
                }

                #region //订单信息
                managemodel.shopinfoid = shopid;
                managemodel.openid = openid;
                managemodel.orderNumber = Utils.Number(13);//订单号
                managemodel.deskNumber = deskNumber;//桌号deskNumber
                managemodel.customerName = MyCommFun.QueryString("name");
                managemodel.customerTel = MyCommFun.QueryString("phone");
                managemodel.address = MyCommFun.QueryString("address");
                managemodel.oderRemark = MyCommFun.QueryString("oderRemark");
                managemodel.payStatus = 0;
                managemodel.oderRemark = "";
                managemodel.oderTime = DateTime.Now;
                managemodel.createDate = DateTime.Now;
                int idf = manage.Add(managemodel);

                #endregion

                #region   //form表单提交
                BLL.wx_diancai_form_control cBll = new BLL.wx_diancai_form_control();
                IList<Model.wx_diancai_form_control> controlList = cBll.GetModelList("shopinfoId="+shopid);
                if (controlList != null)
                {
                    BLL.wx_diancai_form_result retBll = new BLL.wx_diancai_form_result();
                    Model.wx_diancai_form_result result = new Model.wx_diancai_form_result();
                    result.shopinfoId = shopid;
                    result.openid = openid;
                    result.createDate = DateTime.Now;
              
                    Model.wx_diancai_form_control control = new Model.wx_diancai_form_control();
                    for (int i = 0; i < controlList.Count; i++)
                    {
                        control = controlList[i];
                        string reqControlIdValue = MyCommFun.QueryString("control_" + control.seq);
                        result.cId = control.seq;
                        result.cName = control.cName;
                        result.userResult = reqControlIdValue;
                        retBll.Add(result);
                    }
                }
                #endregion

                //菜品
              
                for (int i = 0; i < sArray.Length - 1; i++)
                {

                    string[] sAr = sArray[i].Split(',');
                    caipin.dingId = idf;
                    caipin.caiId = Convert.ToInt32(sAr[0]);//菜品ID
                    caipin.num = Convert.ToInt32(sAr[1]);//菜品件数
                    caipin.price = Convert.ToDecimal(sAr[2]);//菜品单价
                    caipin.totpric = Convert.ToInt32(sAr[1]) * Convert.ToDecimal(sAr[2]);//总价
                  //  payAmount += Convert.ToInt32(sAr[1]) * Convert.ToDecimal(sAr[2]);//客户购买总价
                    caipinbll.Add(caipin);
                }
                //订单满多少免配送费
                if (payAmount < shopinfoEntity.freeSendcost)
                {
                    payAmount += Convert.ToDecimal(shopinfoEntity.sendCost);
                }
              
               bool isOk=  manage.Update(idf, payAmount);
               if (isOk)
               {
                   jsonDict.Add("ret", "ok");
                   jsonDict.Add("content", "订单提交成功！请到订单查看！");
                   context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               }
               else
               {
                   jsonDict.Add("ret", "err");
                   jsonDict.Add("content", "订单提交失败！");
                   context.Response.Write(MyCommFun.getJsonStr(jsonDict));
               }
                context.Response.End();

            }
        }



        public static string QueryString(string param)
        {
            if (HttpContext.Current.Request[param] == null || HttpContext.Current.Request[param].ToString().Trim() == "")
            {
                return "";
            }
            string ret = HttpContext.Current.Request[param].ToString().Trim();
            return ret;
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