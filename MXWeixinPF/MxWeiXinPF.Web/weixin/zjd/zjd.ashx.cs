using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxWeiXinPF.Web.weixin.zjd
{
    /// <summary>
    /// zjd 的摘要说明
    /// </summary>
    public class zjd : IHttpHandler
    {
        BLL.wx_zjdActionInfo actbll = new BLL.wx_zjdActionInfo();
        BLL.wx_zjdAwardUser ubll = new BLL.wx_zjdAwardUser();
        BLL.wx_zjdUsersTemp utbll = new BLL.wx_zjdUsersTemp();

        public void ProcessRequest(HttpContext context)
        {
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();
            context.Response.ContentType = "text/json";
            string _action = MyCommFun.QueryString("myact");
            int aid = MyCommFun.RequestInt("aid");
            int wid = MyCommFun.RequestInt("wid");
            string openid = MyCommFun.QueryString("openid");


            if (_action == "choujiang")
            {
                BLL.wx_zjdAwardItem itemBll = new BLL.wx_zjdAwardItem();
                Model.wx_zjdActionInfo zjdAction = new Model.wx_zjdActionInfo();
                #region 判断

                if (aid == 0 || wid == 0 || openid.Trim() == "")
                {
                    jsonDict.Add("error", "sys");
                    jsonDict.Add("content", "参数错误！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;

                }
                zjdAction = actbll.GetModel(aid);
                if (zjdAction == null)
                {
                    jsonDict.Add("error", "sys");
                    jsonDict.Add("content", "参数错误！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }

                if (zjdAction.endDate <= DateTime.Now)
                { //说明活动已经结束
                    //非活动期间
                    jsonDict.Add("error", "end");
                    jsonDict.Add("content", "活动已结束");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                else if (zjdAction.beginDate > DateTime.Now)
                {
                    //活动未开始
                    //非活动期间
                    jsonDict.Add("error", "nostart");
                    jsonDict.Add("content", "活动未开始");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                int dayMaxTimes = zjdAction.dayMaxTimes == null ? 0 : zjdAction.dayMaxTimes.Value;
                int perMaxTimes = zjdAction.personMaxTimes == null ? 0 : zjdAction.personMaxTimes.Value;
                //判断每人最大抽奖次数，是否超过了
                if (personCJTimes(openid, aid) >= zjdAction.personMaxTimes)
                {
                    jsonDict.Add("error", "notimes");
                    jsonDict.Add("content", "您已抽过奖了，欢迎下次再来！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                if (isTodayOverSum(aid, openid, dayMaxTimes))
                {
                    jsonDict.Add("error", "notimes");
                    jsonDict.Add("content", "每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会,您已经用完了！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                Model.wx_zjdAwardUser award = ubll.getZJinfoByOpenid(aid, openid);
                if (award != null)
                {
                    //您中奖了
                    jsonDict.Add("error", "notimes");
                    jsonDict.Add("content", "您已抽过奖了，欢迎下次再来！");
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }


                #endregion
                #region 计算中奖信息

                /// 处理是否中奖
                /// hidStatus 状态为-1：不能抽奖，直接跳转到end.aspx页面；
                /// 0：抽奖次数超过设置的最高次数；
                /// 1：还可以继续抽奖；
                /// 2：中奖了；

                List<Model.wx_zjdAwardItem> itemlist = itemBll.GetModelList("actId=" + aid);//该活动的所有奖项信息
                int ttJpNum = 0;
                for (int i = 0; i < itemlist.Count; i++)
                {
                    ttJpNum += itemlist[i].jpRealNum.Value;
                }


                IList<Model.wx_zjdAwardUser> auserlist = ubll.getHasZJList(aid);//已经中奖的人列表
                int ZhongJiangNum = 0;
                if (auserlist != null)
                {
                    ZhongJiangNum = auserlist.Count; //已经中奖的人数
                }

                int syZjNum = ttJpNum - ZhongJiangNum; //剩余的奖品数量
                if (syZjNum <= 0)
                {  //说明已经没有奖品了
                    jsonDict.Add("error", "-1");
                    jsonDict.Add("content", zjdAction.cfcjhf);
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;
                }
                zjdAction.personNum = MyCommFun.Obj2Int(zjdAction.personNum, 1);
                zjdAction.personMaxTimes = MyCommFun.Obj2Int(zjdAction.personMaxTimes, 1);
                int fenmo = zjdAction.personNum.Value * zjdAction.personMaxTimes.Value;

                Random rd = new Random((int)DateTime.Now.Ticks);
                int radNum = rd.Next(0, fenmo);//从0到fenmo里随机出一个值
                if (radNum < syZjNum)
                {
                    //中奖了，再从剩余奖品里抽取一个奖品
                    Model.wx_zjdAwardItem dajiang = getZJItem(itemlist, auserlist);
                    if (dajiang != null)
                    {
                        //这是中的中奖了
                        string snumber = Get_snumber(aid);
                        int uId = ubll.Add(aid, "", "", openid, dajiang.jxName, dajiang.jpName, snumber, dajiang.sort_id.Value);

                        jsonDict.Add("error", "succ");
                        jsonDict.Add("content", "恭喜你中奖了!");
                        jsonDict.Add("sortid", dajiang.sort_id.Value.ToString());
                        jsonDict.Add("c_type", dajiang.jxName);
                        jsonDict.Add("c_name", dajiang.jpName);
                        jsonDict.Add("uid", uId.ToString());
                        jsonDict.Add("c_pic", dajiang.jiangpinpic.ToString());
                        jsonDict.Add("code", snumber);
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }
                    else
                    {
                        //奖品已经全部中完了
                        jsonDict.Add("error", "-1");
                        jsonDict.Add("content", zjdAction.cfcjhf);
                        context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                        return;
                    }

                }
                else
                {
                    //这个条件说明：未中奖
                    //抛出未中奖的数据 

                    jsonDict.Add("error", "-1");
                    jsonDict.Add("content", zjdAction.cfcjhf);
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
                    return;

                }




                #endregion

            }

            else if (_action == "update")//领取
            {
                try
                {
                    #region 提交手机
                    /// 提交手机号码

                    string username = MyCommFun.QueryString("username");
                    string tel = MyCommFun.QueryString("tel");
                    string snumber = MyCommFun.QueryString("snumber");
                    int id = MyCommFun.RequestInt("id");

                    if (aid == 0 || id == 0 || snumber == "" || tel == "" || username == "")
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                        return;
                    }

                    BLL.wx_zjdAwardUser ubll = new BLL.wx_zjdAwardUser();
                    Model.wx_zjdAwardUser model = ubll.GetModel(id);
                    if (model == null)
                    {
                        context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                        return;
                    }

                

                    model.uName = username;
                    model.uTel = tel;
                    ubll.Update(model);

                    context.Response.Write("{\"msg\":\"提交成功！\",\"success\":\"1\"}");
                    return;
                    #endregion

                }
                catch
                {
                    context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");

                    return;
                }

            }


            else if (_action == "updatestatus")//申请兑换
            {


                try
                {
                    #region 提交手机
                    /// 提交手机号码

                    string pwd = MyCommFun.QueryString("pwd");
                    int id = MyCommFun.RequestInt("id");



                    BLL.wx_zjdActionInfo infobll = new BLL.wx_zjdActionInfo();
                    Model.wx_zjdActionInfo infomodel = new Model.wx_zjdActionInfo();
                    infomodel = infobll.GetModel(aid);
                    if (infomodel==null)
                    {
                        return;
                    }
                    else if (infomodel.djPwd == "")
                    {
                        if (aid == 0 || id == 0 )
                        {
                            context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                            return;
                        }

                        BLL.wx_zjdAwardUser ubll = new BLL.wx_zjdAwardUser();
                        Model.wx_zjdAwardUser model = ubll.GetModel(id);
                        if (model == null)
                        {
                            context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                            return;
                        }

                      
                            model.hasLingQu = true;
                        
                        
                        ubll.Update(model);

                        context.Response.Write("{\"msg\":\"提交成功！\",\"success\":\"1\"}");
                        return;

                       
                    }
                    else
                    {
                        if (aid == 0 || id == 0 || pwd == "")
                        {
                            context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");
                            return;
                        }

                        if ((pwd.Length > 0) && (!actbll.ExistsPwd(aid, pwd)))
                        {
                            context.Response.Write("{\"msg\":\"商家兑换密码错误！！\",\"success\":\"0\"}");
                            return;
                        }

                        BLL.wx_zjdAwardUser ubll = new BLL.wx_zjdAwardUser();
                        Model.wx_zjdAwardUser model = ubll.GetModel(id);
                        if (model == null)
                        {
                            context.Response.Write("{\"msg\":\"提交出现异常2！！\",\"success\":\"0\"}");
                            return;
                        }

                        if (pwd.Length > 0)
                        {
                            model.hasLingQu = true;
                        }
                        else
                        {
                            model.hasLingQu = false;
                        }
                        ubll.Update(model);

                        context.Response.Write("{\"msg\":\"提交成功！\",\"success\":\"1\"}");
                        return;
                    }




                    
                    #endregion

                }
                catch
                {
                    context.Response.Write("{\"msg\":\"提交出现异常！！\",\"success\":\"0\"}");

                    return;
                }

            }

        }


        /// <summary>
        /// 判断该用户的抽奖次数
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        private int personCJTimes(string openid, int aid)
        {
            int times = 0;
            times = utbll.GetRecordCount(" actId=" + aid + " and openid='" + openid + "'");
            return times;
        }


        private bool isTodayOverSum(int aid, string openid, int todayTTTimes)
        {
            if (todayTTTimes <= 0)
            {
                return true;
            }

            Model.wx_zjdUsersTemp model = new Model.wx_zjdUsersTemp();
            model.openid = openid;
            DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime mingtianBegin = todaybegin.AddDays(1);
            if (!utbll.isExistsOpenid(" actId=" + aid + "  and  openid='" + openid + "' and  createDate>='" + todaybegin + "' and createDate<'" + mingtianBegin + "'"))
            { //第一次，插入
                model.times = 1;
                model.createDate = DateTime.Now;
                model.openid = openid;
                model.actId = aid;
                utbll.Add(model);
                return false;
            }

            model = utbll.getModelByAidOpenid(aid, openid);
            if (model.times >= todayTTTimes)
            {
                return true;
            }
            else
            {
                model.times += 1;
                utbll.Update(model);
                return false;
            }

        }

        public string Get_snumber(int aid)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, 9);//从0到9里随机出一个值

            return "SNzjd" + aid + "_" + MyCommFun.ConvertDateTimeInt(DateTime.Now) + radNum;
        }

        private Model.wx_zjdAwardItem getZJItem(IList<Model.wx_zjdAwardItem> itemlist, IList<Model.wx_zjdAwardUser> haszjlist)
        {
            IList<Model.wx_zjdAwardItem> zjItemlist = new List<Model.wx_zjdAwardItem>();//剩余奖品列表

            Model.wx_zjdAwardItem tmpItem = new Model.wx_zjdAwardItem();
            Model.wx_zjdAwardItem stmpItem = new Model.wx_zjdAwardItem();
            IList<Model.wx_zjdAwardUser> thiszjRs;

            for (int i = 0; i < itemlist.Count; i++)
            {
                tmpItem = itemlist[i];
                thiszjRs = (from user in haszjlist where user.jpName == tmpItem.jpName && user.jxName == tmpItem.jxName select user).ToArray<Model.wx_zjdAwardUser>();
                int tmpSYNum = 0;
                if (thiszjRs != null)
                {
                    tmpSYNum = MyCommFun.Obj2Int(tmpItem.jpRealNum) - thiszjRs.Count;
                }
                if (tmpSYNum <= 0)
                {
                    continue;
                }
                for (int j = 0; j < tmpSYNum; j++)
                {
                    stmpItem = new Model.wx_zjdAwardItem();
                    stmpItem.jpName = tmpItem.jpName;
                    stmpItem.jxName = tmpItem.jxName;
                    stmpItem.sort_id = tmpItem.sort_id;
                    stmpItem.jiangpinpic = tmpItem.jiangpinpic;
                    zjItemlist.Add(stmpItem);
                }
            }

            Random rd = new Random((int)DateTime.Now.Ticks);
            int jpIndex = rd.Next(0, zjItemlist.Count);//从0到zjItemlist.Count里随机出一个值
            return zjItemlist[jpIndex];
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