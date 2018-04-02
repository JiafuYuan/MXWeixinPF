using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetRemoteImage("https://mp.weixin.qq.com/cgi-bin/getimgdata?token=1818104102&msgid=200318139&mode=large&source=&fileId=0&ow=1681793591");
               
            }
        }

        /// <summary>
        /// 替换下载远程图片及入库操作
        /// </summary>
        /// <param name="strInput">内容</param>
        /// <returns>返回string类型;替换后的内容</returns>
        public static string ReplaceRemoteUrl(string strInput)
        {
            string tempFilePath = "";
            string outStr;
            outStr = strInput;

            //获取远程图片url集合
            string _pattern = @"(http|https|ftp|rtsp|mms):(\/\/|\\\\){1}((([\w-])+[.]){1,}(net|com|cn|org|cc|tv|[0-9]{1,3}))([^\?\s]*\/)(([^\?\s])+[.]{1}(gif|jpg|png|bmp))";
            MatchCollection found = null;
            RegexOptions TheOptions;
            TheOptions = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            Regex r = new Regex(_pattern, TheOptions);
            found = r.Matches(strInput);
            foreach (Match m in found)
            {
                tempFilePath = "";
                if (m.Value.Length > 0)
                {
                    tempFilePath = GetRemoteImage(m.Value);
                    //如果下载成功
                    if (tempFilePath.Length > 0)
                    {
                        outStr = outStr.Replace(m.Value, tempFilePath);
                    }
                }
            }

            return outStr;
        }
        /// <summary>
        /// 下载远程图片
        /// </summary>
        /// <param name="strUrl">将要下载的图片地址</param>
        /// <returns>返回string类型;图片的本地地址</returns>
        private static string GetRemoteImage(string strUrl)
        {
            try
            {
                //硬盘路径
                string PathStr = "D:\\publish\\";
                //url路径
                string dPathStr = "";

                string fileExt = System.IO.Path.GetExtension(strUrl);
                Random ro = new Random((int)DateTime.Now.Ticks);
                Random ro2 = new Random(Guid.NewGuid().GetHashCode());
                string filePath = @"Upload\Image\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MMdd") + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ro.Next(1000) + fileExt;
                string tempFolder = System.IO.Path.GetDirectoryName(PathStr + filePath);
                if (!System.IO.Directory.Exists(tempFolder))
                {
                    System.IO.Directory.CreateDirectory(tempFolder);
                }
                WebClient wc = new WebClient();
                wc.DownloadFile(strUrl, PathStr + filePath);
                wc.Dispose();

                filePath = dPathStr + filePath;
                return filePath;
            }
            catch (Exception err)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='JavaScript' type='text/JavaScript'>alert('获取远程图片出错!原因如下:\\n" + err.Message + "');</script>\n");
                //HttpContext.Current.Response.Write(Functions.ShowErr("获取远程图片出错!原因如下:\\n" + ,1));
                //HttpContext.Current.Response.End();
                return "";
            }
        }

    }
}