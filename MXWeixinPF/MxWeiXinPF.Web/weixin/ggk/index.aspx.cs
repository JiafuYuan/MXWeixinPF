using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;

namespace MxWeiXinPF.Web.weixin.ggk
{
    public partial class index : WeiXinPage
    {
        
      public  Model.wx_ggkActionInfo ggkAction = new Model.wx_ggkActionInfo();
        BLL.wx_ggkActionInfo actbll = new BLL.wx_ggkActionInfo();
        BLL.wx_ggkAwardItem itemBll = new BLL.wx_ggkAwardItem();
        BLL.wx_ggkAwardUser ubll = new BLL.wx_ggkAwardUser();
        BLL.wx_ggkUsersTemp utbll = new BLL.wx_ggkUsersTemp();
        string NoAward = "谢谢参与";
      protected  string errorInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlyWeiXinLook();
            if (!IsPostBack)
            {
                int aid = MyCommFun.RequestInt("aid", 0);
                int wid = MyCommFun.RequestInt("wid", 0);
                string openid = MyCommFun.RequestOpenid();
                if (aid == 0 || wid == 0 || openid.Trim() == "" | openid.Trim() == "loseopenid")
                {
                    errorInfo="访问的参数有问题!";
                    ggkAction = null;
                    return;
                }

                bindData(aid, openid);
              
            }
        }
        /// <summary>
        /// 绑定页面上的基本信息
        /// </summary>
        private void bindData(int id, string openid)
        {
            #region 活动详情
            ggkAction = actbll.GetModel(id);
            if (ggkAction == null)
            {
                errorInfo = "该活动不存在!";
                return;
            }
            if (ggkAction.endDate <= DateTime.Now)
            { //说明活动已经结束
                errorInfo = "活动已结束!";
                ggkAction = null;
                return;
            }
            else if (ggkAction.beginDate > DateTime.Now)
            {
                //活动未开始
                errorInfo = "活动尚未开始!<br/>活动时间为：" + ggkAction.beginDate.ToString() + "到" + ggkAction.endDate.ToString();
                ggkAction = null;
                return;
            }
            this.Title = ggkAction.actName;
            List<Model.wx_ggkAwardItem> itemlist = itemBll.GetModelList("actId="+id);
            StringBuilder sb = new StringBuilder("");
            Model.wx_ggkAwardItem item = new Model.wx_ggkAwardItem();
            int ttJpNum = 0;//实际奖品数量
            for (int i = 0; i < itemlist.Count; i++)
            {
                item = itemlist[i];
                sb.Append("<p>" +item.jxName + "：" + item.jpName + "  数量：" + item.jpNum + "</p>");
                ttJpNum += item.jpRealNum.Value;
            }

            if (ggkAction.djPwd.Trim().Length > 0)
            {
                litPwd.Text = "  <p>  <input name=\"\" class=\"px\" id=\"parssword\" type=\"password\" value=\"\" placeholder=\"商家输入兑奖密码\"></p>";
            }

            litJiangXing.Text = sb.ToString();

            litRemark.Text = ggkAction.brief;
            litContentInfo.Text = ggkAction.contractInfo;
            litTTTimes.Text = ggkAction.personMaxTimes == null ? "0" : ggkAction.personMaxTimes.Value.ToString();

            #endregion

            lock (this)
            {
                ProcZJ(ttJpNum, id, openid, itemlist);
            }
        }

        /// <summary>
        /// 处理中奖信息
        /// </summary>
        /// <param name="ttJpNum"></param>
        /// <param name="id"></param>
        /// <param name="openid"></param>
        /// <param name="itemlist"></param>
        private void ProcZJ(int ttJpNum, int id, string openid, List<Model.wx_ggkAwardItem> itemlist)
        {
            BLL.ggkProc gproc = new BLL.ggkProc();
            #region 判断
            Model.wx_ggkAwardUser awardUser = ubll.getZJinfoByOpenid(id, openid);
            litRemainTimes.Text = gproc.personCJTimes(openid, id).ToString();
            if (awardUser != null && awardUser.id > 0)
            {  //说明已经中奖了
               

                litPrize.Text = awardUser.jxName;

                hidAwardId.Value = awardUser.id.ToString();
                if (awardUser.uTel != null && awardUser.uTel.Trim() != "")
                { //说明已经提交成功了 
                    hidStatus.Value = "110";
                    hidErrInfo.Value = "您已中过奖了，欢迎下次再来！";
                    litJp.Text = awardUser.jxName + " " + awardUser.jpName;
                    litSNM.Text = awardUser.sn;
                    if (awardUser.hasLingQu)
                    {
                        litLQStatus.Text = "你已经兑奖成功，本SN码自定作废!";
                    }
                    else
                    {
                        litLQStatus.Text = ggkAction.contractInfo;
                    }
                }
                else
                {  //中奖了，但是未提交 
                    hidStatus.Value = "100";
                    hidErrInfo.Value = "您已中奖，请提交！";
                    litJiangPing.Text = awardUser.jpName;
                    litSnCode.Text = awardUser.sn;

                    litJp.Text = awardUser.jxName + " " + awardUser.jpName;
                    litSNM.Text = awardUser.sn;

                }
                return;
            }


            int dayMaxTimes = ggkAction.dayMaxTimes == null ? 0 : ggkAction.dayMaxTimes.Value;
            int perMaxTimes = ggkAction.personMaxTimes == null ? 0 : ggkAction.personMaxTimes.Value;
            //判断每人最大抽奖次数，是否超过了
            if (gproc.personCJTimes(openid, id) >= ggkAction.personMaxTimes)
            {
                hidStatus.Value = "0";
                hidErrInfo.Value = "您已抽过奖了，欢迎下次再来！";
                return;
            }
            int RemainTime = 0;
            if (gproc.isTodayOverSum(id, openid, dayMaxTimes, out  RemainTime))
            {
                hidStatus.Value = "0";
                hidErrInfo.Value = "每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会。";
                litRemainTimes.Text = RemainTime.ToString();
                return;
            }
            litRemainTimes.Text = RemainTime.ToString();
           

            #endregion

            #region 计算中奖信息

            /// 处理是否中奖
            /// hidStatus 状态为-1：不能抽奖，直接跳转到end.aspx页面；
            /// 0：抽奖次数超过设置的最高次数；
            /// 1：还可以继续抽奖；
            /// 2：中奖了；
            IList<Model.wx_ggkAwardUser> auserlist = ubll.getHasZJList(id);//已经中奖的人列表
            int ZhongJiangNum = 0;
            if (auserlist != null)
            {
                ZhongJiangNum = auserlist.Count; //已经中奖的人数
            }
            int syZjNum = ttJpNum - ZhongJiangNum; //剩余的奖品数量
            if (syZjNum <= 0)
            {  //说明已经没有奖品了
                hidStatus.Value = "1";
                hidErrInfo.Value = ggkAction.cfcjhf;
                litPrize.Text = NoAward;
                return;
            }
            ggkAction.personNum = MyCommFun.Obj2Int(ggkAction.personNum, 1);
            ggkAction.personMaxTimes = MyCommFun.Obj2Int(ggkAction.personMaxTimes, 1);
            int fenmo = ggkAction.personNum.Value * ggkAction.personMaxTimes.Value;

            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, fenmo);//从0到fenmo里随机出一个值
            if (radNum < syZjNum)
            {
                //中奖了，再从剩余奖品里抽取一个奖品
                Model.wx_ggkAwardItem dajiang = gproc.getZJItem(itemlist, auserlist);
                if (dajiang != null)
                {
                    //这是中的中奖了
                    string snumber = gproc.Get_snumber(id);
                    int uId = ubll.Add(id, "", "", openid, dajiang.jxName, dajiang.jpName, snumber);
                    hidStatus.Value = "2";
                    hidErrInfo.Value = "恭喜你中奖了！";
                    litPrize.Text = dajiang.jxName;
                    litJiangPing.Text = dajiang.jpName;
                    hidAwardId.Value = uId.ToString();
                    litSnCode.Text = snumber;

                    litJp.Text = dajiang.jxName + " " + dajiang.jpName;
                    litSNM.Text = snumber;
                    return;
                }
                else
                {
                    //奖品已经全部中完了
                    hidStatus.Value = "1";
                    hidErrInfo.Value = ggkAction.cfcjhf;
                    litPrize.Text = NoAward;
                    return;
                }

            }
            else
            {
                //这个条件说明：未中奖
                //抛出未中奖的数据 
                hidStatus.Value = "1";
                hidErrInfo.Value = ggkAction.cfcjhf;
                litPrize.Text = NoAward;
            }




            #endregion
        }

        


      
    }

}