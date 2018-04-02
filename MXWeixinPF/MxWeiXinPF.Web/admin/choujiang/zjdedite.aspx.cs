using MxWeiXinPF.BLL;
using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.choujiang
{
    public partial class zjdedite : Web.UI.ManagePage
    {
        public string type = "";
        public int zjdid=0;
        public int wid = 0;
        BLL.wx_zjdActionInfo infobll = new BLL.wx_zjdActionInfo();
        Model.wx_zjdActionInfo info = new Model.wx_zjdActionInfo();
        wx_zjdAwardItem iBll = new wx_zjdAwardItem();
        wx_requestRule rBll = new wx_requestRule();
        Model.wx_requestRule rule = new Model.wx_requestRule();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            type = MyCommFun.QueryString("type");
            zjdid = MyCommFun.RequestInt("id");

            if(!IsPostBack)
            {
            
                if (type == "edite")
                {
                    if (zjdid>0)
                    {
                    ShowInfo(zjdid);
                    }
                }
            }

        }

        #region 赋值操作=================================
        private void ShowInfo(int id)
        {
            hidid.Value = id.ToString();

            IList<Model.wx_zjdAwardItem> aItemlist = iBll.GetModelList("actId=" + id);
            Model.wx_requestRule rule = rBll.GetModelList("modelFunctionName='砸金蛋' and modelFunctionId=" + id)[0];
            txtKW.Text = rule.reqKeywords;

            info = infobll.GetModel(zjdid);
            if (info==null)
            {
                return;
            }

            //基本设置
            if (info.beginPic != null && info.beginPic.Trim() != "/weixin/zjd/image/activity-zjd-start.jpg")
            {
                this.beginPic.Text = info.beginPic;
                imgbeginPic.ImageUrl = info.beginPic;
            }
            this.actName.Text = info.actName;
            this.duijiangInfo.Text = info.duijiangInfo;
            this.brief.InnerText = info.brief;
            this.beginDate.Text = info.beginDate.ToString();
            this.endDate.Text = info.endDate.ToString();
            if (info.actContent !=null)
            {
            this.actContent.InnerText = info.actContent.ToString();
            }
        
            this.cfcjhf.Text = info.cfcjhf;
            

            //活动结束
            if (info.endPic != null && info.endPic.Trim() != "/weixin/zjd/image/activity-zjd-end.jpg")
            {
                endPic.Text = info.endPic;
                imgEndPic.ImageUrl = info.endPic;
            }
            this.endNotice.Text = info.endNotice;
            this.endContent.Text = info.endContent;


            //中奖率设置
            this.zhongjianglv.Text = info.personNum.ToString();

            this.personMaxTimes.Text = info.personMaxTimes.ToString();
            this.dayMaxTimes.Text = info.dayMaxTimes.ToString();
            this.djPwd.Text = info.djPwd;
            this.backMusic.Text = info.backMusic;




            //绑定奖项信息
            IList<Model.wx_zjdAwardItem> itemlist = iBll.GetModelList("actId=" + id + " order by sort_id asc");

            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;
                TextBox txtJXName;
               TextBox txtJPName;
                TextBox txtNum;
                TextBox txtRealNum;
                TextBox txtXSName;
                
                Model.wx_zjdAwardItem itemEntity = new Model.wx_zjdAwardItem();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];
                    txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;//名称
                    txtXSName = this.FindControl("txt" + i + "XSName") as TextBox;//显示奖品数
                    txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;//实际奖品数
                    txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;//奖品重命名
                    txtNum = this.FindControl("txt" + i + "Num") as TextBox;//图片

                    txtJXName.Text = itemEntity.jxName;//奖品名称
                    txtXSName.Text = itemEntity.jpNum == null ? "0" : itemEntity.jpNum.Value.ToString();//显示奖品数量
                    txtRealNum.Text = itemEntity.jpRealNum == null ? "0" : itemEntity.jpRealNum.Value.ToString();//奖品数量
                    txtJPName.Text = itemEntity.jpName;//精品重命名
                    txtNum.Text = itemEntity.jiangpinpic;//奖品图片
                   
                  
                   
                    
                   
                   
                }

            }

            this.snShezhi.Text = info.snShezhi;
            this.snRename.Text = info.snRename;
            this.telRename.Text = info.telRename;
            this.jpDisplay.SelectedValue = info.jpDisplay.ToString();
            this.mrXingyun.SelectedValue = info.mrXingyun.ToString();
            this.zhongjiangSZ.SelectedValue = info.zhongjiangSZ.ToString();
            this.choujiangMode.SelectedValue = info.choujiangMode;


        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.wx_userweixin weixin = GetWeiXinCode();

           
            //基本设置

            string beginPicurl = imgbeginPic.ImageUrl;
            if (this.beginPic.Text.ToString() != "")
            {
                beginPicurl = this.beginPic.Text.ToString();
            }
            info.beginPic = beginPicurl;

            info.actName = this.actName.Text;
            info.duijiangInfo = this.duijiangInfo.Text;
            info.brief = this.brief.InnerText;
            DateTime beginDate = DateTime.Parse(this.beginDate.Text);
            DateTime endDate = DateTime.Parse(this.endDate.Text);
            if (beginDate >= endDate)
            {
                JscriptMsg("开始时间必须小于结束时间", "", "Error");
                return;
            }
            if (this.beginDate.Text!="")
            {
                info.beginDate = beginDate;
            }
            if (this.endDate.Text!="")
            {
                info.endDate = endDate;
            }
            info.actContent = this.actContent.InnerText;
            info.cfcjhf = this.cfcjhf.Text;

            //活动结束

            string endPicurl = imgEndPic.ImageUrl;
            if (this.endPic.Text != "")
            {
                endPicurl = this.endPic.Text;
            }
            info.endPic = endPicurl;

            info.endNotice = this.endNotice.Text;
            info.endContent = this.endContent.Text;
           


            //
            if (this.zhongjianglv.Text!="")
            {
                info.zhongjianglv = MyCommFun.Str2Decimal(this.zhongjianglv.Text);
            }

            info.personMaxTimes = MyCommFun.Str2Int(this.personMaxTimes.Text);
            info.dayMaxTimes = MyCommFun.Str2Int(this.dayMaxTimes.Text);
            if (info.dayMaxTimes >info.personMaxTimes)
            {
              
                JscriptMsg("每人每天砸的次数不能大于砸奖总次数！", "", "Error");
                return;
            }

            info.djPwd = this.djPwd.Text;
            if (this.backMusic.Text != "")
            {
                info.backMusic = this.backMusic.Text;
            }
            else
            {
                info.backMusic = "music/default.mp3";
            }
            info.personNum = MyCommFun.Str2Int(this.zhongjianglv.Text);

            //
            info.snShezhi = this.snShezhi.Text;
            info.snRename = this.snRename.Text;
            info.telRename = this.telRename.Text;
            info.jpDisplay = Convert.ToBoolean( this.jpDisplay.SelectedValue);
            info.mrXingyun = Convert.ToBoolean( this.mrXingyun.SelectedValue);
            info.zhongjiangSZ = Convert.ToInt32( this.zhongjiangSZ.SelectedValue);
            info.choujiangMode =  this.choujiangMode.SelectedValue;

            if (type == "edite")
            {
              
                info.id = zjdid;
                //1修改主表
                infobll.Update(info);
                //2删除，且新增奖项表
                EditAwardItem(zjdid);
                //3 修改回复规则表
                IList<Model.wx_requestRule> rlist = rBll.GetModelList("modelFunctionName = '砸金蛋' and modelFunctionId=" + zjdid);

                if (rlist != null && rlist.Count > 0)
                {
                    rule = rlist[0];
                    rule.reqKeywords = txtKW.Text.Trim();
                   
                    rBll.Update(rule);
                }
                else
                {
                    AddRule(weixin.id, zjdid);
                }

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改砸金蛋活动，主键为" + zjdid); //记录日志
                JscriptMsg("修改砸金蛋活动成功！", "zjdlist.aspx", "Success");

            }
            else if (type == "add")
            {
                info.wid = weixin.id;
                info.createDate = DateTime.Now;
                //1新增主表
               int id = infobll.Add(info);

                //2新增奖项表
                EditAwardItem(id);
                //3 新增回复规则表
                AddRule(weixin.id, id);
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加砸金蛋活动，主键为" + id); //记录日志
                JscriptMsg("添加砸金蛋活动成功！", "zjdlist.aspx", "Success"); 
            }

        }

        private void AddRule(int wid, int modelId)
        {
            rBll.AddModeltxtPicRule(wid, "砸金蛋", modelId, txtKW.Text.Trim());
        }


        private void EditAwardItem(int dzpId)
        {
            //1删除原来的，2新增
            iBll.DeleteByActId(dzpId);
            Model.wx_zjdAwardItem item = new Model.wx_zjdAwardItem();
            TextBox txtJXName;
            TextBox txtJPName;
            TextBox txtNum;
            TextBox txtRealNum;
            TextBox txtXSName;
            int sort_id = 0;

            int totJxNum = 0; //一共有多少奖项
            for (int i = 1; i <= 6; i++)
            {
                txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;
                txtXSName = this.FindControl("txt" + i + "XSName") as TextBox;
                txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;
                txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;
                txtNum = this.FindControl("txt" + i + "Num") as TextBox;
               

                if (txtJXName.Text.Trim() != ""  && txtNum.Text.Trim() != "" && txtRealNum.Text.Trim() != "" && MyCommFun.isNumber(txtNum.Text) && MyCommFun.isNumber(txtRealNum.Text))
                {
                    totJxNum++;
                }
            }

       
            for (int i = 1; i <= 6; i++)
            {
                txtJXName = this.FindControl("txt" + i + "JXName") as TextBox;//奖品名称
                txtXSName = this.FindControl("txt" + i + "XSName") as TextBox;//显示实际数量
                txtRealNum = this.FindControl("txt" + i + "RealNum") as TextBox;//实际数量
                txtJPName = this.FindControl("txt" + i + "JPName") as TextBox;//重命名
                txtNum = this.FindControl("txt" + i + "Num") as TextBox;//图片
              
                

                if (txtJXName.Text.Trim() != ""  && txtNum.Text.Trim() != "" && txtRealNum.Text.Trim() != ""  && MyCommFun.isNumber(txtRealNum.Text))
                {
                    sort_id++;
                    //那么添加奖品信息 
                    item.jxName = txtJXName.Text.Trim();//奖品
                    item.sort_id = sort_id;                  
                    item.jpNum = MyCommFun.Str2Int(txtXSName.Text.Trim());//奖品数量
                    item.jpRealNum = MyCommFun.Str2Int(txtRealNum.Text.Trim());//奖品数量
                    item.jpName = txtJPName.Text.Trim();//奖品重命名
                    item.jiangpinpic = txtNum.Text.Trim();//图片                                    
                    item.actId = dzpId;
                    item.createDate = DateTime.Now;
                    //item.jiaodu_min = avgDeg * sort_id;
                    iBll.Add(item);
                }

            }

        }
    }
}