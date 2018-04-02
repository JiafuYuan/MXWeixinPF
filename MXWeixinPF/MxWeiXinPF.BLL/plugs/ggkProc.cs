using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxWeiXinPF.BLL
{
   public   class ggkProc
    {
        BLL.wx_ggkAwardUser ubll = new BLL.wx_ggkAwardUser();
        BLL.wx_ggkUsersTemp utbll = new BLL.wx_ggkUsersTemp();


        public void Proc(int id,string openid)
        {
             
        
        }


        #region 方法

        /// <summary>
        /// 取中奖的项目
        /// </summary>
        /// <param name="itemlist">所有的奖品信息</param>
        /// <param name="haszjlist">已经中奖的列表</param>
        /// <returns></returns>
        public  Model.wx_ggkAwardItem getZJItem(IList<Model.wx_ggkAwardItem> itemlist, IList<Model.wx_ggkAwardUser> haszjlist)
        {
            IList<Model.wx_ggkAwardItem> zjItemlist = new List<Model.wx_ggkAwardItem>();//剩余奖品列表

            Model.wx_ggkAwardItem tmpItem = new Model.wx_ggkAwardItem();
            Model.wx_ggkAwardItem stmpItem = new Model.wx_ggkAwardItem();
            IList<Model.wx_ggkAwardUser> thiszjRs;

            for (int i = 0; i < itemlist.Count; i++)
            {
                tmpItem = itemlist[i];
                thiszjRs = (from user in haszjlist where user.jpName == tmpItem.jpName && user.jxName == tmpItem.jxName select user).ToArray<Model.wx_ggkAwardUser>();
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
                    stmpItem = new Model.wx_ggkAwardItem();
                    stmpItem.jpName = tmpItem.jpName;
                    stmpItem.jxName = tmpItem.jxName;
                    zjItemlist.Add(stmpItem);
                }
            }

            Random rd = new Random((int)DateTime.Now.Ticks);
            int jpIndex = rd.Next(0, zjItemlist.Count);//从0到zjItemlist.Count里随机出一个值
            return zjItemlist[jpIndex];
        }


        /// <summary>
        /// 该用户的抽奖次数
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public int personCJTimes(string openid, int aid)
        {
            int times = 0;
            DAL.wx_ggkUsersTemp gutDal=new DAL.wx_ggkUsersTemp();
            times = gutDal.GetChoujTimesByOpenid(aid, openid);
            
            return times;
        }


        /// <summary>
        /// 判断今天是否已经超出抽奖次数
        /// todayTTTimes:能抽奖的总次数
        /// </summary>
        /// <param name="aid">活动主键id</param>
        /// <param name="openid"></param>
        /// <param name="todayTTTimes">每天的抽奖总次数</param>
        /// <returns></returns>
        public bool isTodayOverSum(int aid, string openid, int todayTTTimes,out int RemainTime)
        {
            if (todayTTTimes <= 0)
            {
                RemainTime = 0;
                return true;
            }

            Model.wx_ggkUsersTemp model = new Model.wx_ggkUsersTemp();
            model.openid = openid;
            DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime mingtianBegin = todaybegin.AddDays(1);
            if (!utbll.ExistsOpenid(" actId=" + aid + "  and  openid='" + openid + "' and  createDate>='" + todaybegin + "' and createDate<'" + mingtianBegin + "'"))
            { //第一次，插入
                model.times = 1;
                model.createDate = DateTime.Now;
                model.openid = openid;
                model.actId = aid;
                utbll.Add(model);
                RemainTime = model.times.Value - 1; 

              //  litRemainTimes.Text = (model.times - 1).ToString();
                return false;

            }

            model = utbll.getModelByAidOpenid(aid, openid);
            RemainTime = model.times.Value;
           // litRemainTimes.Text = (model.times).ToString();

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

        /// <summary>
        /// 返回中奖序列号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_snumber(int aid)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            int radNum = rd.Next(0, 9);//从0到9里随机出一个值

            return "SNggk" + aid + "_" + MyCommFun.ConvertDateTimeInt(DateTime.Now) + radNum;
        }


        #endregion

    }
}
