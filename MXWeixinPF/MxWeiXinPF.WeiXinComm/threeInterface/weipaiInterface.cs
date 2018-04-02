using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxWeiXinPF.WeiXinComm.threeInterface
{
    public class weipaiInterface
    {

        #region 微拍接口

        /// <summary>
        /// 关注时候处理
        /// </summary>
        public string weipaiSubscribe(string openid, int wid)
        {
            
            BLL.wx_userweixin uwbll = new BLL.wx_userweixin();
            string wxId = uwbll.GetwxId(wid);//原始Id
            if (wxId == null || wxId.Trim() == "")
            {
                return "wid参数错误";
            }

            MxWeiXinPF.BLL.wx_logs logBll = new MxWeiXinPF.BLL.wx_logs();
            try
            {
                MxWeiXinPF.BLL.wx_paizhao_setting setBll = new MxWeiXinPF.BLL.wx_paizhao_setting();
                MxWeiXinPF.Model.wx_paizhao_setting model = setBll.GetModelByWid(wid);
                if (model == null || model.isOpen == false)
                {
                    return "未开启";
                }
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string url = model.initApiUrl;// "http://wphoto.betterwood.com:8080/Server/wechat/userinit.action";
                string userid = openid;

                string sourceid = wxId;// "gh_e2d7eb82cb50"; 该用户的来源，即关注的哪一个微信公众账号)、（微信号）原始ID
                string timestamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
                string v = "2000";
                string signature = "";
                parameters.Add("userid", openid);
                parameters.Add("sourceid", sourceid);
                parameters.Add("v", "2000");
                parameters.Add("timestamp", timestamp);
                signature = GetBizSign(parameters);
                string postParam = "userid=" + userid + "&sourceid=" + sourceid + "&timestamp=" + timestamp + "&v=" + v + "&signature=" + signature;
                string ret = Utils.HttpPost(url, postParam);

                Dictionary<string, object> dict = MyCommFun.JsonToDictionary(ret);
                string returnCode = dict["returncode"].ToString();
                if (returnCode == "200")
                {
                    //成功
                    logBll.AddLog(wid, "微拍用户关注时候的接口", "weipaiSubscribe", "奥尔图微拍接口调用成功了", 1);

                }
                else
                {
                    logBll.AddLog(wid, "微拍用户关注时候的接口", "weipaiSubscribe", "奥尔图微拍接口调用失败：" + dict["returnmessage"].ToString(), 0);
                }
                return returnCode;
            }
            catch (Exception ex)
            {

                logBll.AddLog(wid, "微拍用户关注时候的接口", "weipaiSubscribe", "报错：" + ex.Message, 0);
                return ex.Message;
            }

        }


        /// <summary>
        /// 传图片
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="PicUrl"></param>
        /// <returns></returns>
        public string weipaiChuanTuPian(string openid, string PicUrl, int wid)
        {
            BLL.wx_userweixin uwbll = new BLL.wx_userweixin();
            string wxId = uwbll.GetwxId(wid);//原始Id

            string returnCode = "";
            MxWeiXinPF.BLL.wx_logs logBll = new MxWeiXinPF.BLL.wx_logs();
            try
            {
                MxWeiXinPF.BLL.wx_paizhao_setting setBll = new MxWeiXinPF.BLL.wx_paizhao_setting();
                MxWeiXinPF.Model.wx_paizhao_setting model = setBll.GetModelByWid(wid);
                if (model == null || model.isOpen == false)
                {
                    return "";
                }
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string url = model.picApiUrl;// 
                string userid = openid;
                string sourceid = wxId;// "gh_e2d7eb82cb50"; //该用户的来源，即关注的哪一个微信公众账号)、（微信号）原始ID
                string timestamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
                string v = "2000";
                string downurl = PicUrl;
                string signature = "";
                parameters.Add("userid", openid);
                parameters.Add("sourceid", sourceid);
                parameters.Add("downurl", downurl);
                parameters.Add("timestamp", timestamp);
                parameters.Add("v", "2000");

                signature = GetBizSign(parameters);
                string postParam = "userid=" + userid + "&downurl=" + downurl + "&sourceid=" + sourceid + "&timestamp=" + timestamp + "&v=" + v + "&signature=" + signature;
                string ret = Utils.HttpPost(url, postParam);

                Dictionary<string, object> dict = MyCommFun.JsonToDictionary(ret);
                returnCode = dict["returncode"].ToString();

                if (returnCode == "200")
                {
                    //成功
                    logBll.AddLog(wid, "微拍传图的接口", "weipaiChuanTuPian", "奥尔图微拍接口调用成功了", 1);
                    MxWeiXinPF.BLL.wx_paizhao_picinfo pBll = new MxWeiXinPF.BLL.wx_paizhao_picinfo();
                    MxWeiXinPF.Model.wx_paizhao_picinfo pic = new MxWeiXinPF.Model.wx_paizhao_picinfo();
                    pic.openid = openid;
                    pic.picUrl = PicUrl;
                    pic.createDate = DateTime.Now;
                    pBll.Add(pic);
                    return dict["mentioninfo"].ToString();
                }
                else
                {
                    logBll.AddLog(wid, "微拍传图的接口", "weipaiChuanTuPian", "奥尔图微拍接口调用失败：" + dict["returnmessage"].ToString(), 0);
                    return dict["returnmessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                logBll.AddLog(wid, "微拍传图的接口", "weipaiChuanTuPian", "报错：" + ex.Message, 0);
                return "打印接口报错：" + ex.Message;
            }
        }

        /// <summary>
        /// 加密/校验流程如下(signature)：比如
        ///1. 将userid、sourceid、v、timestamp四个参数进行字典序排序
        ///2. 将几个参数字符串拼接成一个字符串进行md5加密
        /// </summary>
        /// <param name="bizObj"></param>
        /// <returns></returns>
        public string GetBizSign(Dictionary<string, string> bizObj)
        {
            Dictionary<string, string> bizParameters = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in bizObj)
            {
                if (item.Key != "")
                {
                    bizParameters.Add(item.Key.ToLower(), item.Value);
                }
            }
            string bizString = FormatBizQueryParaMap(bizParameters, false);

            return Utils.MD5(bizString);

        }

        public string FormatBizQueryParaMap(Dictionary<string, string> paraMap, bool urlencode)
        {

            string buff = "";
            try
            {
                var result = from pair in paraMap orderby pair.Key select pair;
                foreach (KeyValuePair<string, string> pair in result)
                {
                    if (pair.Key != "")
                    {

                        string key = pair.Key;
                        string val = pair.Value;
                        if (urlencode)
                        {
                            val = System.Web.HttpUtility.UrlEncode(val);
                        }
                        buff += key.ToLower() + "=" + val + "&";

                    }
                }

                if (buff.Length == 0 == false)
                {
                    buff = buff.Substring(0, (buff.Length - 1) - (0));
                }
            }
            catch (Exception e)
            {

            }
            return buff;
        }

        /// <summary>
        /// 是否为微拍的关键词
        /// </summary>
        /// <param name="keywordsStr">关键词字符串，类似 abc,cda,dds,</param>
        /// <param name="wid">微帐号id</param>
        /// <returns></returns>
        public bool isWeipaiKeyWord(string keywordsStr, int wid)
        {

            MxWeiXinPF.BLL.wx_paizhao_setting setBll = new MxWeiXinPF.BLL.wx_paizhao_setting();
            MxWeiXinPF.Model.wx_paizhao_setting setting = setBll.GetModelByWid(wid);
            if (setting == null || setting.isOpen == false || keywordsStr.IndexOf(setting.enterKeyWords+",")<0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 处理微拍的程序
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public string weipai_promptStr(string keywords,int wid)
        {
            string ret = "";
            MxWeiXinPF.BLL.wx_paizhao_setting setBll = new MxWeiXinPF.BLL.wx_paizhao_setting();
            MxWeiXinPF.Model.wx_paizhao_setting setting = setBll.GetModelByWid(wid);
            if (setting == null || setting.isOpen == false || setting.enterKeyWords != keywords)
            {
                return "";
            }
            else
            {
                ret = setting.prompt.ToString();
            }
            return ret;
        }

        #endregion
    }
}
