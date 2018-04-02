using MxWeiXinPF.Common;
using MxWeiXinPF.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MxWeiXinPF.Web.weixin.yuyue
{
    /// <summary>
    /// uploadhead 的摘要说明
    /// </summary>
    public class uploadhead : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
         
           

            #region 上传头像
            Dictionary<string, string> jsonDict = new Dictionary<string, string>();

            string uploadFileRet = UpLoadFile(context);
            Dictionary<string, object> dict = MyCommFun.JsonToDictionary(uploadFileRet);
            if (dict["status"].ToString() == "0")
            {
                //上传失败
                jsonDict.Add("result", "0");
                jsonDict.Add("content", dict["msg"].ToString());
                context.Response.Write(MyCommFun.getJsonStr(jsonDict));

            }
            else
            {
                    //同步成功
                    jsonDict.Add("result", "1");
                    jsonDict.Add("content", "头像上传成功！");
                    jsonDict.Add("newPhotoUrl", dict["thumb"].ToString());
                    context.Response.Write(MyCommFun.getJsonStr(jsonDict));
            }

            #endregion
             
        }

        /// <summary>
        /// 上传图片的方法
        /// 返回缩略图的路劲
        /// </summary>
        /// <param name="context"></param>
        private string UpLoadFile(HttpContext context)
        {

            HttpPostedFile _upfile = context.Request.Files["header_img_id"];
            //  HttpFileCollection files = HttpContext.Current.Request.Files;
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = true; //默认生成缩略图
            _isthumbnail = true;
            if (_upfile == null)
            {
                return "";
            }
            UpLoad upFiles = new UpLoad();
            string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater);

            //返回成功信息
            return msg;
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