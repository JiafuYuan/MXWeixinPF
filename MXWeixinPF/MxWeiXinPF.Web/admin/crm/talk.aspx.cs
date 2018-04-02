using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MxWeiXinPF.Common;
using MxWeiXinPF.WeiXinComm;
using System.Data;
using System.Text;

namespace MxWeiXinPF.Web.admin.crm
{
    public partial class talk : Web.UI.ManagePage
    {
        BLL.wx_response_BaseData rcBll = new BLL.wx_response_BaseData();
        BLL.wx_crm_users cuBll = new BLL.wx_crm_users();
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = MXRequest.GetQueryInt("id");
            if (!IsPostBack)
            {
                this.page = MXRequest.GetQueryInt("page", 1);        //获取分页
                this.keywords = MXRequest.GetQueryString("keywords");//获取查询关键字
                this.txtKeywords.Text = this.keywords;
                this.pageSize = GetPageSize(10);                    //分页每页数量
                MessageBox.ResponseScript(this, "$(\".wenben\").show();");
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            Model.wx_userweixin weixin = GetWeiXinCode();    //当前微信用户 
            Model.wx_crm_users cuModel = cuBll.GetModel(uid);//当前粉丝
            int wid = weixin.id;
            string openid = cuModel.openid;
            DataSet ds = rcBll.GetList(this.pageSize, this.page, " id>0 " + CombSqlTxt(this.keywords, wid, openid), "createDate desc,id asc", out totalCount);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("talk.aspx", "keywords={0}&page={1}&id={2}",
                this.keywords, "__id__", uid.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, int wid, string openid)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (wid > 0)
            {
                strTemp.Append(" and wid='" + wid + "' ");
            }

            if (!string.IsNullOrEmpty(openid))
            {
                strTemp.Append(" and wx_openid='" + openid + "' ");
            }

            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (requestContent like  '%" + _keywords + "%' or reponseContent like '%" + _keywords + "%' )");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("talk_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


        private const string URL_FORMAT = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";

        protected void btnSendout_Click(object sender, EventArgs e)
        {
            WeiXinCRMComm cpp = new WeiXinCRMComm();
            BLL.wx_crm_fodder cfBll = new BLL.wx_crm_fodder();
            Model.wx_userweixin weixin = GetWeiXinCode();    //当前微信用户  
            Model.wx_crm_users cuModel = cuBll.GetModel(uid);//当前粉丝
            string error = "";
            string accessToken = cpp.getAccessToken(weixin.id, out error);
            Model.wx_response_BaseData rc = new Model.wx_response_BaseData();
            try
            {
                rc.createDate = DateTime.Now;
                rc.wid = weixin.id;           
                rc.flag = 1;
                rc.rType = "客服回复";
                rc.wx_openid = cuModel.openid;//当前粉丝的openid

                if (rblResponseType.SelectedItem.Value == "0")
                {  //纯文本

                    //规则
                    if (this.txtContent.Text.Trim().Length == 0)
                    {
                        JscriptMsg("内容不能为空", "back", "Error");
                        return;
                    }
                    //添加内容   
                    rc.reponseContent = txtContent.Text.Trim();
                    rc.responseType = "text";
                    SendText(accessToken, cuModel.openid, txtContent.Text.Trim());
                }
                else if (rblResponseType.SelectedItem.Value == "1")
                {
                    #region 图文的信息回复
                    //图文 
                    //判断图片来自服务器或公网
                    string imgurl = this.txtImgUrl.Text;
                    if (imgurl.IndexOf("http") < 0)
                    {
                        imgurl = MyCommFun.getWebSite() + imgurl;
                    }
                    //发送图文
                    List<Article> artList = new List<Article>
                    {
                        new Article(){
                            Url=this.txtUrl.Text, 
                            PicUrl=imgurl,
                            Title=this.txtTitle.Text,
                            Description=this.txtNewsContent.Value
                        },
                    };
                    SendNews(accessToken, cuModel.openid, artList);
                    //添加内容
                    Model.wx_crm_fodder cfModel = new Model.wx_crm_fodder
                    {
                        scContent = this.txtNewsContent.Value,
                        title = this.txtTitle.Text,
                        picurl = imgurl,
                        url = this.txtUrl.Text,
                        createDate = DateTime.Now
                    };
                    int res = cfBll.Add(cfModel);

                    Dictionary<string, string> jsonDict = new Dictionary<string, string>();
                    jsonDict.Add("title", this.txtTitle.Text);
                    jsonDict.Add("scContent", this.txtNewsContent.Value);
                    jsonDict.Add("picurl", imgurl);
                    jsonDict.Add("url", this.txtUrl.Text);
                    jsonDict.Add("createDate", this.txtUrl.Text);

                    rc.reponseContent = this.txtTitle.Text+"";
                    rc.responseType = "news";

                    #endregion

                }
                else if (rblResponseType.SelectedItem.Value == "2")
                {  //语音

                    if (this.txtMusicTitle.Text.Trim().Length == 0)
                    {
                        JscriptMsg("音乐不能为空", "back", "Error");
                        return;
                    }
                    if (this.txtMusicFile.Text.Trim().Length == 0)
                    {
                        JscriptMsg("音乐链接不能为空", "back", "Error");
                        return;
                    }

                    //添加内容  
                    rc.responseType = "voice";
                    rc.remark = txtMusicRemark.Text;
                    SendVoice(accessToken, cuModel.openid, "Media_Id");
                }
                rcBll.Add(rc);

                //AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "编辑" + ruleName); //记录日志
                JscriptMsg("发送信息成功！", "talk.aspx?keywords=" + this.keywords + "&id=" + uid, "Success");
            }
            catch (Exception)
            {
                JscriptMsg("发送信息失败！", "talk.aspx?keywords=" + this.keywords + "&id=" + uid, "Error");
                return;
            }

        }

        #region 发送文本
        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static WxJsonResult SendText(string accessToken, string openId, string content)
        {
            var data = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            return CommonJsonSend.Send(accessToken, URL_FORMAT, data);
        }
        #endregion

        #region 发送语音

        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public static WxJsonResult SendVoice(string accessToken, string openId, string mediaId)
        {
            var data = new
            {
                touser = openId,
                msgtype = "voice",
                voice = new
                {
                    media_id = mediaId
                }
            };
            return CommonJsonSend.Send(accessToken, URL_FORMAT, data);
        }
        #endregion

        #region 发送图文
        /// <summary>
        /// 发送图文消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="title">音乐标题（非必须）</param> 
        /// <param name="url">图片url</param>
        /// <param name="picurl">图片链接地址</param>
        /// <returns></returns>
        public static WxJsonResult SendNews(string accessToken, string openId, List<Article> articles)
        {
            var data = new
            {
                touser = openId,
                msgtype = "news",
                news = new
                {
                    articles = articles.Select(z => new
                    {
                        title = z.Title,
                        description = z.Description,
                        url = z.Url,
                        picurl = z.PicUrl//图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80
                    }).ToList()
                }
            };
            return CommonJsonSend.Send(accessToken, URL_FORMAT, data);
        }
        #endregion

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sucCount = 0;
            int errorCount = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (rcBll.Delete(id))
                        sucCount += 1;
                    else
                        errorCount += 1;
                }
            }

            AddAdminLog(MXEnums.ActionEnum.Delete.ToString(), "删除聊天记录成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("talk.aspx", "keywords={0}&id={1}", this.keywords, uid.ToString()), "Success", "parent.loadMenuTree");
        }

        //关键字查询
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("talk.aspx", "keywords={0}&id={1}", txtKeywords.Text, uid.ToString()));
        }

        //更改分页页大小
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("talk_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("talk.aspx", "keywords={0}&id={1}", this.keywords, uid.ToString()));
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                Literal litShow = e.Item.FindControl("litShow") as Literal;
                string flag = rowv["flag"].ToString();
                string reContent = rowv["reponseContent"].ToString();
                string ruContent = rowv["requestContent"].ToString();
                string reType = rowv["responseType"].ToString();
                string ruType = rowv["requestType"].ToString();
                string curType = "";
                string curContent = "";
                //判断消息发送方
                if (flag == "1")   //系统
                {
                    curContent = reContent;
                    curType = reType;
                }
                else if (flag == "2")//粉丝
                {
                    curContent = ruContent;
                    curType = ruType;
                }

                //判断消息类型
                if (curType == "text")
                {
                    litShow.Text = curContent;
                }
                else if (curType == "news")
                {
                    litShow.Text = "<a id=\"openNews\" title=\"编辑\" href=\"javascript:void(0)\" onclick=\"showGuiZeDialog(" + curContent + ");\">查看图文</a>";
                }


            }
        }


    }
}