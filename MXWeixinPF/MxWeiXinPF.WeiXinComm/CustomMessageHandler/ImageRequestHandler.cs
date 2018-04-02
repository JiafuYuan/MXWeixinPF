using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Configuration;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using System.Xml;
using System.Xml.Linq;
using MxWeiXinPF.DAL;
using MxWeiXinPF.Common;
using Senparc.Weixin.MP;
using Senparc.Weixin;
 

namespace MxWeiXinPF.WeiXinComm.CustomMessageHandler
{
    public partial class CustomMessageHandler
    {
        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            int apiid = wxcomm.getApiid();

            wxResponseBaseMgr.Add(apiid, requestMessage.FromUserName, requestMessage.MsgType.ToString(), requestMessage.PicUrl, "none", "", requestMessage.ToUserName);


            #region ==== 微拍 ===
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            BLL.wx_paizhao_setting setBll = new BLL.wx_paizhao_setting();
            bool isOpen = setBll.isOpened(apiid);
            if (isOpen)
            {
                if (CurrentMessageContext.RequestMessages.Count > 1)
                {

                    string keywordStr = "";
                    for (int i = CurrentMessageContext.RequestMessages.Count - 2; i >= 0; i--)
                    {
                        var historyMessage = CurrentMessageContext.RequestMessages[i];
                        if (historyMessage.MsgType == RequestMsgType.Text)
                        {
                            keywordStr += (historyMessage as RequestMessageText).Content + ",";
                        }
                    }
                    threeInterface.weipaiInterface wxcf = new threeInterface.weipaiInterface();
                    if (wxcf.isWeipaiKeyWord(keywordStr, apiid))
                    {
                        //奥尔图的照片来拉
                        string content = wxcf.weipaiChuanTuPian(requestMessage.FromUserName, requestMessage.PicUrl, apiid);
                        responseMessage.Content = content;
                        return responseMessage;
                    }
                }
            }

            #endregion

            #region 微信上墙
            WeiXCommFun wxFun = new WeiXCommFun();
            //查询微信上墙的活动，只取一条
            BLL.wx_sq_act actBll = new BLL.wx_sq_act();
            Model.wx_sq_act act = actBll.GetModel(apiid, DateTime.Now);
            if (act != null)
            {
                //查询是否在黑名单里
                BLL.wx_sq_heimd hBll = new BLL.wx_sq_heimd();
                bool isExist = hBll.Exists(requestMessage.FromUserName, act.id);
                if (isExist)
                {
                    //存在黑名单里
                    return wxFun.GetResponseMessageTxtByContent(requestMessage, "您在黑名单里，无法上传图片", apiid);
                }
                else
                {
                    //说明有微信上墙活动
                    //1 将图片的地址保存到数据库
                    BLL.wx_sq_piclist pBll = new BLL.wx_sq_piclist();
                    Model.wx_sq_piclist pic = new Model.wx_sq_piclist();
                    pic.openid = requestMessage.FromUserName;
                    pic.aid = act.id;
                    pic.picUrl = requestMessage.PicUrl;
                    pic.hasShenghe = false;
                    pic.createDate = DateTime.Now;
                    int ret = pBll.Add(pic);
                    //2返回提示语句

                    if (ret > 0)
                    {
                        string content = "";
                        if (act.shenghe)
                        {
                            if (act.shengheTip == null || act.shengheTip.Trim().Length <= 0)
                            {
                                content = "已经成功上传等待审核！<br/><a href=\"" + MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid=" + apiid + "&aid=" + act.id + "\">查看相册</a>照片id为" + ret;

                            }
                            else
                            {
                                content = act.shengheTip;
                            }

                           
                        }
                        else
                        {
                            if (act.noshengheTip == null || act.noshengheTip.Trim().Length <= 0)
                            {
                                 content = "已经成功上传点击查看<br/><a href=\"" + MyCommFun.getWebSite() + "/weixin/shangqiang/index.aspx?wid=" + apiid + "&aid=" + act.id + "\">查看相册</a>照片id为" + ret;
                          
                            }
                            else
                            {
                                content = act.noshengheTip;
                            }
                        }
                        return wxFun.GetResponseMessageTxtByContent(requestMessage, content, apiid);
                    }
                    else
                    {
                        return wxFun.GetResponseMessageTxtByContent(requestMessage, "图片上传失败，请重新上传", apiid);
                    }
                }

            }
            else
            {
                return wxFun.GetResponseMessageTxtByContent(requestMessage, "您刚刚上传了一个图片", apiid);
            }

            #endregion

            //var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            //responseMessage.Articles.Add(new Article()
            //{
            //    Title = "您刚才发送了图片信息",
            //    Description = "您发送的图片将会显示在边上",
            //    PicUrl = requestMessage.PicUrl,
            //    Url = requestMessage.PicUrl
            //});
            //responseMessage.Articles.Add(new Article()
            //{
            //    Title = "第二条",
            //    Description = "第二条带连接的内容",
            //    PicUrl = requestMessage.PicUrl,
            //    Url = "http://m.uweixin.cn"
            //});
            //return responseMessage;
        }



    }
}
