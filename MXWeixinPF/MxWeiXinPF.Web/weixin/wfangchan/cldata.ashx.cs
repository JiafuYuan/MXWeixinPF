using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MxWeiXinPF.Common;
using System.Text;
using System.Data;

namespace MxWeiXinPF.Web.weixin.wfangchan
{
    /// <summary>
    /// cldata 的摘要说明
    /// </summary>
    public class cldata : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string action = MXRequest.GetQueryString("myact");
            int wid = MyCommFun.RequestInt("wid");
            string openid = MyCommFun.RequestOpenid();

            #region 添加印象
            if (action == "fyyx")
            {
                BLL.wx_fc_fyImpression fBll = new BLL.wx_fc_fyImpression();
                Dictionary<string, string> jsondict = new Dictionary<string, string>();
                string imp_user = MyCommFun.QueryString("imp_user");
                int fid = MyCommFun.RequestInt("fid");
                int record = fBll.GetRecordCount(" content='" + imp_user + "'");
                int allrw = fBll.GetRecordCount(" id>0 ");
                int rep = fBll.GetRecordCount(" openid='" + openid + "'");
                if (rep > 0)
                {
                    jsondict.Add("errno", "2");
                    jsondict.Add("res", "你已经添加过印象了");
                    context.Response.Write(MyCommFun.getJsonStr(jsondict));
                    return;
                }

                if (record > 0)//有过此类印象
                {
                    double re = (Convert.ToDouble(record) / allrw) * 100;
                    jsondict.Add("res", re.ToString() + "%");
                }
                else           //独特印象
                {
                    jsondict.Add("res", "1");
                }
                Model.wx_fc_fyImpression fModel = new Model.wx_fc_fyImpression();
                fModel.content = imp_user;
                fModel.createDate = DateTime.Now;
                fModel.fid = fid;
                fModel.openid = openid;
                fModel.sort_id = 1;
                fModel.wid = wid;
                fModel.quantity = 1;
                fBll.Add(fModel);
                jsondict.Add("errno", "1");
                context.Response.Write(MyCommFun.getJsonStr(jsondict));
                return;
            }
            #endregion

            #region 添加预约订单信息
            if (action == "addyydd")
            {
                Dictionary<string, string> jsondict = new Dictionary<string, string>();
                BLL.wx_fc_yyInfo yBll = new BLL.wx_fc_yyInfo();
                BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
                string linkman = MyCommFun.QueryString("truename");
                string dateline = MyCommFun.QueryString("dateline");
                string timepart = MyCommFun.QueryString("timepart");
                int housetype = MyCommFun.RequestInt("housetype");
                string info = MyCommFun.QueryString("info");
                string tel = MyCommFun.QueryString("tel");
                int fid = MyCommFun.RequestInt("fid");
                int addOrEdit = MyCommFun.RequestInt("addOrEdit");
                int yid = MyCommFun.Obj2Int(fBll.GetModel(fid).yid);
                Model.wx_fc_yyInfo yyinfo = new Model.wx_fc_yyInfo()
                {
                    createdate = DateTime.Now,
                    hid = housetype,
                    telephone = tel,
                    remark = info,
                    name = linkman,
                    yydate = MyCommFun.Obj2DateTime(dateline),
                    yydatepart = timepart,
                    wid = wid,
                    fid = fid,
                    yid = yid,
                    openid = openid,
                    orderStatus = "待回复",
                    sort_id = 99
                };
                if (addOrEdit > 0)
                { //修改
                    yyinfo.Id = addOrEdit;
                    yBll.Update(yyinfo);
                }
                else                  //添加
                {
                    yBll.Add(yyinfo);
                }
                jsondict.Add("errno", "0");
                jsondict.Add("content", "");
                context.Response.Write(MyCommFun.getJsonStr(jsondict));
                return;
            }
            #endregion

            #region 加载相册信息
            if (action == "xiangce")
            {
                BLL.wx_fc_album bll = new BLL.wx_fc_album();
                BLL.wx_albums_photo pBll = new BLL.wx_albums_photo();
                BLL.wx_albums_info aBll = new BLL.wx_albums_info();
                Model.wx_albums_info model = new Model.wx_albums_info();
                int fid = MyCommFun.RequestInt("fid");
                StringBuilder sb = new StringBuilder("");
                sb.Append("showPics([");
                //获得楼盘相册
                DataTable artlist = bll.GetList(" fid=" + fid).Tables[0];

                int a_rowsNum = 0;//每行显示的图片数量
                List<Model.wx_albums_photo> allist = new List<Model.wx_albums_photo>();//图片表
                if (artlist != null && artlist.Rows.Count > 0)
                {
                    DataRow dr;
                    for (int i = 0; i < artlist.Rows.Count; i++)//循环楼盘相册
                    {
                        dr = artlist.Rows[i];
                        model = aBll.GetModel(int.Parse(dr["aid"].ToString()));//根据楼盘相册得到该相册基本信息表

                        //if (model.albums == null || model.albums.Count <= 0)
                        //{
                        //    continue;
                        //}
                        allist = pBll.GetModelList(" aId=" + model.id);
                        sb.Append("{\"title\":\"" + model.aName + "\",");
                        a_rowsNum = (allist.Count) / 2;
                        //第一行
                        sb.Append(" \"ps1\":[");
                        sb.Append(" { \"type\":\"title\", \"title\":\"" + model.aName + "\", \"subTitle\":\"" + model.aContent + "\"}");
                        if (a_rowsNum > 0)
                        {
                            sb.Append(",");
                        }
                        for (int h = 0; h < a_rowsNum; h++)
                        {
                            if (h < (a_rowsNum - 1))
                            {
                                sb.Append(" {\"type\":\"img\",\"name\":\"" + allist[h].pContent + "\",\"img\":\"" + MyCommFun.getWebSite() + allist[h].photoPic + "\",\"size\":[480,450]},");
                            }
                            else
                            {
                                sb.Append(" {\"type\":\"img\",\"name\":\"" + allist[h].pContent + "\",\"img\":\"" + MyCommFun.getWebSite() + allist[h].photoPic + "\",\"size\":[480,450]}");
                            }
                        }
                        sb.Append("],");

                        //第二行
                        sb.Append(" \"ps2\":[");
                        int h_cishu = 0;
                        for (int h = a_rowsNum; h < allist.Count; h++)
                        {

                            if (h_cishu == 1)
                            {
                                sb.Append(" {\"type\":\"text\",\"content\":\"" + model.aContent + "\"},");
                            }

                            if (h < (allist.Count - 1))
                            {
                                sb.Append(" {\"type\":\"img\",\"name\":\"" + allist[h].pContent + "\",\"img\":\"" + MyCommFun.getWebSite() + allist[h].photoPic + "\",\"size\":[480,450]},");
                                h_cishu++;
                            }
                            else
                            {
                                sb.Append(" {\"type\":\"img\",\"name\":\"" + allist[h].pContent + "\",\"img\":\"" + MyCommFun.getWebSite() + allist[h].photoPic + "\",\"size\":[480,450]}");
                            }

                        }
                        if (h_cishu == 0)
                        {
                            if (allist.Count > 0)
                            {
                                sb.Append(",");
                            }
                            sb.Append("{\"type\":\"text\",\"content\":\"" + model.aContent + "\"}");
                        }

                        sb.Append("]");

                        if (i < (artlist.Rows.Count - 1))
                        {
                            sb.Append("},");
                        }
                        else
                        {
                            sb.Append("}");
                        }
                    }
                }

                sb.Append("]);");
                context.Response.Write(sb.ToString());
                return;
            }
            #endregion

            #region 加载户型图片
            if (action == "htImg")
            {
                BLL.wx_fc_houseType htBll = new BLL.wx_fc_houseType();
                BLL.wx_fc_floor fBll = new BLL.wx_fc_floor();
                int fid = MyCommFun.RequestInt("fid");
                int htid = MyCommFun.RequestInt("htid");

                if (htBll.GetRecordCount(string.Format(" fid={0} and wid={1} and id={2}", fid, wid, htid)) < 1)
                {
                    return;
                }

                Model.wx_fc_houseType htModel = htBll.GetModel(htid);
                Model.wx_fc_floor fModel = fBll.GetModel(fid);
                StringBuilder sb = new StringBuilder("showRooms({");//begin
                sb.Append("\"banner\":\"http://42.96.196.48/tpl/static/attachment/focus/default/../canyin/3.jpg\",");
                sb.Append("\"rooms\":[{");
                sb.Append("\"name\":\"" + htModel.Name + "\",");
                sb.Append("\"desc\":\"" + fModel.newsTitle + "\",");
                sb.Append("\"bimg\":\"" + MyCommFun.getWebSite() + htModel.htimgA + "\",");
                sb.Append("\"rooms\":\"" + htModel.houseType + "\",");
                sb.Append("\"area\":\" " + htModel.jzmj + "平方米\",");
                sb.Append("\"floor\":\"" + htModel.storey + "\",");
                sb.Append("\"width\":1600,");
                sb.Append("\"height\":1600,");
                sb.Append("\"pics\":[");
                //图片区,A
                List<string> ls = imgstr(htModel);
                for (int i = 0; i < ls.Count; i++)
                {
                    sb.Append("{\"img\":\"" + MyCommFun.getWebSite() + htModel.htimgA + "\",");
                    sb.Append("\"width\":760,");
                    sb.Append("\"height\":760,");
                    sb.Append("\"name\":\"" + htModel.Name + "\"}");
                    if (i != ls.Count)
                        sb.Append(","); 

                } 

                sb.Append("],");
                //图片end
                sb.Append("\"dtitle\":[\"建筑面积约" + htModel.jzmj + "平方米\"],");
                sb.Append("\"dlist\":[\"" + htModel.Jieshao + "\"]");
                sb.Append("}]})");//end
                context.Response.Write(sb.ToString());
                return;
            }
            #endregion

        }

        List<string> imgstr(Model.wx_fc_houseType ht)
        {
            List<string> ls = new List<string>();
            if (ht.htimgA != "")
                ls.Add(ht.htimgA);
            if (ht.htImgB != "")
                ls.Add(ht.htImgB);
            if (ht.htimgC != "")
                ls.Add(ht.htimgD);
            if (ht.htimgD != "")
                ls.Add(ht.htimgD); 

            return ls;
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