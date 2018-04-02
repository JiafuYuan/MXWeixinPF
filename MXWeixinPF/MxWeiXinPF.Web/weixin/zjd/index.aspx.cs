using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.weixin.zjd
{
    public partial class index : WeiXinPage
    {
        public int aid = 0;
        public int wid = 0;
        public string image = "";
        public string begininfo = "";
        public string begingg = "";
        public string backmusic = "";
        public string jiangpinlist = "";
        public string openid = "";
        public bool isZhJing = false;
        public string zjjl = "";
        public string zhongjtel = "";
        public string shuzu = "";
        public int ErrLevel = 100;
        public string ErrorInfo = "";
        public int picIndex = 0;
        public string lqresult = "";
        public string contractInfo = "";
        public string pwdinput = "";
        public string sectinstring = "";
        /// <summary>
        /// 初始化时候，如果是中奖未领取，则弹出领取窗口
        /// </summary>
        protected string initAlert = "";

        public Model.wx_zjdActionInfo zjdAction;
        BLL.wx_zjdAwardUser ubll = new BLL.wx_zjdAwardUser();
        BLL.wx_zjdUsersTemp utbll = new BLL.wx_zjdUsersTemp();
        BLL.wx_zjdActionInfo actBll = new BLL.wx_zjdActionInfo();
        BLL.wx_zjdAwardItem itemBll = new BLL.wx_zjdAwardItem();

        protected void Page_Load(object sender, EventArgs e)
        {
            aid = MyCommFun.RequestInt("aid");
            wid = MyCommFun.RequestInt("wid");
            openid = MyCommFun.QueryString("openid");
            if (!IsPostBack)
            {

                //砸金蛋记录

                openidValue.Value = openid;
                widValue.Value = wid.ToString();
                aidValue.Value = aid.ToString();

                if (aid == 0 || wid == 0 || openid.Trim() == "")
                {
                    ErrLevel = 1;
                    ErrorInfo = "访问参数错误！";
                    return;
                }



                BindData();

                Model.wx_zjdActionInfo info = new Model.wx_zjdActionInfo();
                info = actBll.GetModel(aid);
                if (info != null)
                {
                    image = info.beginPic;
                    begininfo = info.actContent;
                    backmusic = info.backMusic;

                    contractInfo = info.duijiangInfo;

                    if (info.djPwd.ToString() != "")
                    {
                        pwdinput = "  <tr ><td><input type=\"text\" id=\"d1_2\"   placeholder=\"请输入兑奖密码\" maxlength=\"30\" /></td></tr>\\";
                        this.pwdstatus.Value = "1";
                    }


                }
            }
        }





        private void BindData()
        {
            zjdAction = actBll.GetModel(aid);
            IList<Model.wx_zjdAwardItem> itemlist = itemBll.GetModelList("actId=" + aid);
            if (zjdAction == null || itemlist == null || itemlist.Count <= 0)
            {
                ErrLevel = 1;
                ErrorInfo = "未获得到数据";
                return;
            }
            this.Title = zjdAction.actName;

            if (zjdAction.endDate <= DateTime.Now)
            {   //说明活动已经结束
                ErrLevel = 101;
                ErrorInfo = "活动已结束";
                return;
            }

            StringBuilder sb = new StringBuilder("");
            Model.wx_zjdAwardItem item = new Model.wx_zjdAwardItem();
            int ttJpNum = 0;
            shuzu = "[";
            for (int i = 0; i < itemlist.Count; i++)
            {
                item = itemlist[i];
                sb.Append("<p>" + item.jxName + "：" + item.jpName + "  数量：" + item.jpNum + "</p>");
                ttJpNum += item.jpRealNum.Value;
                picIndex++;
                if (i < (itemlist.Count - 1))
                {
                    shuzu += item.jiaodu_min + ",";
                }
                else
                {
                    shuzu += item.jiaodu_min;
                }
            }
            shuzu += "]";


            littotTimes.Text = zjdAction.personMaxTimes == null ? "0" : zjdAction.personMaxTimes.Value.ToString();
            litdaysTimes.Text = zjdAction.dayMaxTimes == null ? "0" : zjdAction.dayMaxTimes.Value.ToString();

            if (zjdAction.beginDate > DateTime.Now)
            {
                hidStatus.Value = "-2";
                ErrorInfo = hidErrInfo.Value = "活动尚未开始";
            }


            getjiangpin(aid);
            zjjlist(openid);//中奖记录
            zjtel(aid);//最新中奖手机号



            int hasCjTimes = utbll.getCJCiShu(aid, openid);//返回该用户的抽奖次数
            this.litHasUsedTimes.Text = hasCjTimes.ToString();

            int dayMaxTimes = zjdAction.dayMaxTimes == null ? 0 : zjdAction.dayMaxTimes.Value;
            int perMaxTimes = zjdAction.personMaxTimes == null ? 0 : zjdAction.personMaxTimes.Value;
            //判断是否中奖了

            Model.wx_zjdAwardUser award = ubll.getZJinfoByOpenid(aid, openid);
            if (award != null && award.id > 0)
            {

                this.hastime.Value = "1";

                //您中奖了
                if (award.uTel != null && award.uTel.ToString().Trim() != "")
                {//已经中奖，并且提交了

                    hidAwardId.Value = award.id.ToString();
                    isZhJing = true;
                }
                else
                { //已经中奖，但是未提交
                    hidStatus.Value = "100";

                    hidAwardId.Value = award.id.ToString();

                }

                sectinstring += "<section  class=\"stage\">";
                sectinstring += " <img src=\"image/stage.jpg\">";
                sectinstring += "      <div    class=\"red\">";
                sectinstring += "    亲你已经中过奖了,不能再抽了!            </div>";

                sectinstring += "    </section>";



            }
            else
            {

                //判断每人最大抽奖次数，是否超过了
                if (hasCjTimes >= zjdAction.personMaxTimes)
                {

                    hidStatus.Value = "2";
                   // litOtherTip.Text = "<p class='red'>您已经抽了" + hasCjTimes + "次了。</p>";
                }
                if (isTodayOverSum(dayMaxTimes))
                {
                    this.daytime.Value = "1";
                    hidStatus.Value = "2";
                  //  litOtherTip.Text = "<p class='red'>每人每天只有" + dayMaxTimes.ToString() + "次抽奖机会，您已经使用完了。</p>";
                }
             
                    sectinstring += " <section class=\"stage\">";

                    sectinstring += " <img src=\"image/stage.jpg\">";
                    sectinstring += " <div id=\"shape\" class=\"cube on\">";
                    sectinstring += "  <div class=\"plane one\">";
                    sectinstring += "  <span>";
                    sectinstring += "   <figure>&nbsp;</figure>";
                    sectinstring += "    </span>";
                    sectinstring += " </div>";
                    sectinstring += " <div class=\"plane two\">";
                    sectinstring += "   <span>";
                    sectinstring += "   <figure>&nbsp;</figure>";
                    sectinstring += "   </span>";
                    sectinstring += "  </div>";
                    sectinstring += " <div class=\"plane three\">";
                    sectinstring += "   <span>";
                    sectinstring += "      <figure>&nbsp;</figure>";
                    sectinstring += "   </span>";
                    sectinstring += "  </div>";
                    sectinstring += "  </div>";
                    sectinstring += " <div id=\"hit\" class=\"hit\">";
                    sectinstring += "  <img src=\"image/1.png\"></div> </section>";


                

            }



        }


        #region 方法
        /// <summary>
        /// 最新中奖手机号
        /// </summary>
        public void zjtel(int aid)
        {
            BLL.wx_zjdAwardUser zjbll = new BLL.wx_zjdAwardUser();
            DataSet dzj = zjbll.GetList(aid);
            if (dzj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dzj.Tables[0].Rows.Count; i++)//
                {

                    zhongjtel += "<tr><td  >" + dzj.Tables[0].Rows[i]["createDate"] + "</td><td  >";
                    if (dzj.Tables[0].Rows[i]["uTel"].ToString() != "" && dzj.Tables[0].Rows[i]["uTel"].ToString().Length == 11)
                    {
                        zhongjtel += dzj.Tables[0].Rows[i]["uTel"].ToString().Substring(0, 4) + " ****" + dzj.Tables[0].Rows[i]["uTel"].ToString().Substring(8, 3);
                    }
                    else
                    {
                        zhongjtel += "   ****";
                    }

                    zhongjtel += "    </td><td>砸中" + dzj.Tables[0].Rows[i]["jxName"] + "</td></tr>";
                }
            }
        }


        /// <summary>
        /// 获奖记录
        /// </summary>
        /// <param name="openid"></param>
        public void zjjlist(string openid)
        {
            BLL.wx_zjdAwardUser userbll = new BLL.wx_zjdAwardUser();
            DataSet dt = userbll.GetListhj(aid,openid);
            StringBuilder sbAlert = new StringBuilder("");
            DataRow dr;
            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    dr = dt.Tables[0].Rows[i];


                    zjjl += "<tr><td>" + dt.Tables[0].Rows[i]["createDate"] + "</td><td  >";
                    if (dt.Tables[0].Rows[i]["uTel"].ToString() != "" && dt.Tables[0].Rows[i]["uTel"].ToString().Length == 11)
                    {
                        zjjl += dt.Tables[0].Rows[i]["uTel"].ToString().Substring(0, 4) + " ****" + dt.Tables[0].Rows[i]["uTel"].ToString().Substring(8, 3);
                    }
                    else
                    {
                        zjjl += "  ****";
                    }


                    zjjl += "</td><td>" + dr["jxName"] + "</td>";
                    if (dr["uTel"].ToString() != "" && dr["uName"].ToString() != "" && dr["hasLingQu"].ToString() == "False")
                    {

                        zjjl += "<td><input type=\"button\" value=\"申请兑换\" onclick=\"sqdh({code:'" + dr["sn"] + "', snid:'" + dr["id"] + "'});\" />";
                    }
                    else if (dr["uTel"].ToString() != "" && dr["uName"].ToString() != "" && dr["hasLingQu"].ToString() == "True")
                    {
                        zjjl += "<td><input type=\"button\" value=\"已兑换\"  />";
                    }
                    else if (dr["uTel"].ToString() == "" && dr["uName"].ToString() == "")
                    {

                        zjjl += "<td><input type=\"button\" value=\"领取奖品\" onclick=\"lq({code:'" + dr["sn"] + "', snid:'" + dr["id"] + "',loca:'no'});\" />";
                        sbAlert.Append(strAlert(i, dr["jpName"].ToString(), dr["jxName"].ToString(), dr["jiangpinpic"].ToString(), dr["sn"].ToString(), dr["id"].ToString()));
                    }
                    zjjl += "</td></tr>";
                }
            }

            initAlert = sbAlert.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">序列</param>
        /// <param name="jpName">奖品名称</param>
        /// <param name="jxName">奖项名称</param>
        /// <param name="jpPic">奖品图片</param>
        /// <param name="sncode">中奖sn码</param>
        /// <returns></returns>
        private string strAlert(int i, string jpName, string jxName, string jpPic, string sncode, string snId)
        {
            string ret = "";
            ret += " var d" + i + " = new iDialog();";
            ret += "  d" + i + ".open({";
            ret += "       classList: \"result get_result\",";
            ret += "         title:\"\",";
            ret += "          close:\"\",";
            ret += "         content:'<div class=\"header\"><h6>您已中奖</h6></div>\\";
            ret += "          <table><tr>\\";
            ret += "           <td style=\"width:75px;\"><label>" +  jxName+ "</label></td>\\";
            ret += "<td><img src=\"" + jpPic + "\" /></td>\\";
            ret += " <td style=\"width:75px;\"><label>" + jpName + "</label></td>\\";
            ret += " </tr></table>',";
            ret += " btns:[";
            ret += " {id:\"\", name:\"领取奖品\", onclick:\"fn.call();\", fn: function(self){";
            ret += "  self.die();";
            ret += "  lq({code:\"" + sncode + "\", snid:'" + snId + "'});";
            ret += "   }},";
            ret += " {id:\"\", name:\"关闭\", onclick:\"fn.call();\", fn: function(self){";
            ret += " self.die();";
            ret += "   },}";
            ret += " ]";
            ret += "  });";

            return ret;
        }

        /// <summary>
        /// 奖品列表
        /// </summary>
        /// <param name="aid"></param>
        public void getjiangpin(int aid)
        {
            BLL.wx_zjdAwardItem itembll = new BLL.wx_zjdAwardItem();
            DataSet dr = new DataSet();
            dr = itembll.GetList(aid);
            //jpDisplay
            zjdAction=actBll.GetModel(aid);
            if (zjdAction.jpDisplay.ToString() == "True")
            {

                if (dr.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
                    {
                        jiangpinlist += "<li>";
                        jiangpinlist += "<p>";
                        jiangpinlist += "" + dr.Tables[0].Rows[i]["jxName"] + "<label class=\"color_golden\">:" + dr.Tables[0].Rows[i]["jpNum"] + "</label>";
                        jiangpinlist += "</p>";
                        jiangpinlist += "<figure><img class=\"imageli\" src=\"" + dr.Tables[0].Rows[i]["jiangpinpic"] + "\"></figure> ";
                        if (dr.Tables[0].Rows[i]["jpName"].ToString() != "")
                        {
                            jiangpinlist += "  <label>" + dr.Tables[0].Rows[i]["jpName"] + "</label>";
                        }
                        else
                        {
                            jiangpinlist += "  <label>" + dr.Tables[0].Rows[i]["sort_id"] + "</label>";
                        }
                        jiangpinlist += "</li>";
                    }

                }
            }
            else
            {
                if (dr.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
                    {
                        jiangpinlist += "<li>";
                        jiangpinlist += "<p>";
                        jiangpinlist += "" + dr.Tables[0].Rows[i]["jxName"] + "";
                        jiangpinlist += "</p>";
                        jiangpinlist += "<figure><img class=\"imageli\" src=\"" + dr.Tables[0].Rows[i]["jiangpinpic"] + "\"></figure> ";
                        if (dr.Tables[0].Rows[i]["jpName"].ToString() != "")
                        {
                            jiangpinlist += "  <label>" + dr.Tables[0].Rows[i]["jpName"] + "</label>";
                        }
                        else
                        {
                            jiangpinlist += "  <label>" + dr.Tables[0].Rows[i]["sort_id"] + "</label>";
                        }
                        jiangpinlist += "</li>";
                    }

                }
            }

        }



        /// <summary>
        /// 判断今天是否已经超出抽奖次数
        /// todayTTTimes:能抽奖的总次数
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="todayTTTimes">每天的抽奖总次数</param>
        /// <returns></returns>
        private bool isTodayOverSum(int todayTTTimes)
        {
            if (todayTTTimes <= 0)
            {
                return true;
            }

            //DateTime todaybegin = DateTime.Parse(DateTime.Now.ToShortDateString());
            //DateTime mingtianBegin = todaybegin.AddDays(1);
            //if (!utbll.ExistsOpenid(" actId=" + aid + "  and  openid='" + openid + "' and  createDate>='" + todaybegin + "' and createDate<'" + mingtianBegin + "'"))
            //{
            //    return false;

            //}

            Model.wx_zjdUsersTemp model = utbll.getModelByAidOpenid(aid, openid);
            if (model != null)
            {
                if (model.times >= todayTTTimes)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        #endregion


    }
}