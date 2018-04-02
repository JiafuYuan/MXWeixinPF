using MxWeiXinPF.BLL;
using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.hotel
{
    public partial class hotel_info : Web.UI.ManagePage
    {
        TextBox title;
        TextBox sortid;
        TextBox picUrl;
        TextBox picTiaozhuan;
        protected string editetype = "";
        protected static int hotelid = 0;
        BLL.wx_hotels_info hotelBll = new BLL.wx_hotels_info();
        Model.wx_hotels_info hotel = new Model.wx_hotels_info();

        BLL.wx_hotel_pic picBll = new BLL.wx_hotel_pic();
        Model.wx_hotel_pic pic = new Model.wx_hotel_pic();
        wx_hotel_pic iBll = new wx_hotel_pic();
        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            editetype = MyCommFun.QueryString("type");
            if(!IsPostBack)
            {
                if (editetype == "edite")
                {
                    list(hotelid);
                }
            }
        }


        public void list(int hotelid)
        {
            hotel = hotelBll.GetModel(hotelid);
            if (hotel != null)
            {
                this.hotelName.Text = hotel.hotelName;
                this.hotelAddress.Text = hotel.hotelAddress;
                this.hotelPhone.Text = hotel.hotelPhone;
                this.mobilPhone.Text = hotel.mobilPhone;
                this.noticeEmail.Text = hotel.noticeEmail;
                //this.emailPws.Text = hotel.emailPws;
                this.coverPic.Text = hotel.coverPic;
                this.topPic.Text = hotel.topPic;
                this.orderLimit.Text = hotel.orderLimit.ToString();
                this.listMode.SelectedValue = hotel.listMode.ToString();
                this.messageNotice.SelectedValue = hotel.messageNotice.ToString();
                this.pwd.Text = hotel.pwd;
                this.hotelIntroduct.Value = hotel.hotelIntroduct;
                this.orderRemark.Value = hotel.orderRemark;
                this.txtLatXPoint.Text = hotel.xplace.ToString();
                this.txtLngYPoint.Text = hotel.yplace.ToString();
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript'> $(\"#baiduframe\").attr(\"src\", \"../lbs/MapSelectPoint.aspx?yjindu=" + hotel.yplace.Value.ToString() + "&xweidu=" + hotel.xplace.Value.ToString() + "\");</script>");

            }

            IList<Model.wx_hotel_pic> itemlist = iBll.GetModelList("hotelid=" + hotelid + " order by id asc");
            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;


                Model.wx_hotel_pic itemEntity = new Model.wx_hotel_pic();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];
                    title = this.FindControl("title" + i) as TextBox;
                    sortid = this.FindControl("sortid" + i) as TextBox;
                    picUrl = this.FindControl("picUrl" + i) as TextBox;
                    picTiaozhuan = this.FindControl("picTiaozhuan" + i) as TextBox;

                    title.Text = itemEntity.title;
                    sortid.Text = itemEntity.sortid.ToString();
                    picUrl.Text = itemEntity.picUrl.ToString();
                    picTiaozhuan.Text = itemEntity.picTiaozhuan.ToString();

                }

            }
        }

        protected void save_hotel_Click(object sender, EventArgs e)
        {
              editetype = MyCommFun.QueryString("type");
              Model.wx_userweixin weixin = GetWeiXinCode();
              int wid = weixin.id;

            if (editetype == "add")
            {
                hotel.wid = wid;
                hotel.hotelName = this.hotelName.Text;
                hotel.hotelAddress = this.hotelAddress.Text;
                hotel.hotelPhone = this.hotelPhone.Text;
                hotel.mobilPhone = this.mobilPhone.Text;
                hotel.noticeEmail = this.noticeEmail.Text;
                //hotel.emailPws = this.emailPws.Text;
                hotel.coverPic = this.coverPic.Text;
                hotel.topPic = this.topPic.Text;
                hotel.orderLimit = MyCommFun.Str2Int( this.orderLimit.Text);
                hotel.listMode = Convert.ToBoolean( this.listMode.SelectedValue);
                hotel.messageNotice =MyCommFun.Str2Int( this.messageNotice.Text);
                hotel.pwd = this.pwd.Text;
                hotel.hotelIntroduct = this.hotelIntroduct.Value;
                hotel.orderRemark = this.orderRemark.Value;           
                hotel.createDate = DateTime.Now;
                hotel.xplace = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
                hotel.yplace=MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
    

                int id = hotelBll.Add(hotel);


                for (int i = 1; i <= 6; i++)
                {
                    title = this.FindControl("title" + i) as TextBox;
                    sortid = this.FindControl("sortid" + i) as TextBox;
                    picUrl = this.FindControl("picUrl" + i) as TextBox;
                    picTiaozhuan = this.FindControl("picTiaozhuan" + i) as TextBox;

                    if (title.Text.Trim() != "" && sortid.Text.Trim() != "")
                    {

                        pic.hotelid = id;
                        pic.title = title.Text.ToString();
                        pic.sortid = MyCommFun.Str2Int(sortid.Text.ToString());
                        pic.picUrl = picUrl.Text.ToString();
                        pic.picTiaozhuan = picTiaozhuan.Text.ToString();
                        pic.createDate = DateTime.Now;
                        picBll.Add(pic);

                    }
                }
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加商家设置，主键为" + id); //记录日志
                JscriptMsg("添加成功！", "hotel_list.aspx", "Success");

            }

            else if (editetype == "edite")
            {
                if (hotelid == 0)
                {

                    return;
                    //操作失败！
                }

                hotel.id = hotelid;
                hotel.wid = wid;
                hotel.hotelName = this.hotelName.Text;
                hotel.hotelAddress = this.hotelAddress.Text;
                hotel.hotelPhone = this.hotelPhone.Text;
                hotel.mobilPhone = this.mobilPhone.Text;
                hotel.noticeEmail = this.noticeEmail.Text;
               // hotel.emailPws = this.emailPws.Text;
                hotel.coverPic = this.coverPic.Text;
                hotel.topPic = this.topPic.Text;
                hotel.orderLimit = MyCommFun.Str2Int(this.orderLimit.Text);
                hotel.listMode = Convert.ToBoolean(this.listMode.SelectedValue);
                hotel.messageNotice = MyCommFun.Str2Int(this.messageNotice.Text);
                hotel.pwd = this.pwd.Text;
                hotel.hotelIntroduct = this.hotelIntroduct.Value;
                hotel.orderRemark = this.orderRemark.Value;
               // hotel.createDate = DateTime.Now;
                hotel.xplace = MyCommFun.Str2Decimal(this.txtLatXPoint.Text);
                hotel.yplace = MyCommFun.Str2Decimal(this.txtLngYPoint.Text);
             

                hotelBll.Update(hotel);

                picBll.Deletepic(hotelid);

                for (int i = 1; i <= 6; i++)
                {
                    title = this.FindControl("title" + i) as TextBox;
                    sortid = this.FindControl("sortid" + i) as TextBox;
                    picUrl = this.FindControl("picUrl" + i) as TextBox;
                    picTiaozhuan = this.FindControl("picTiaozhuan" + i) as TextBox;

                    if (title.Text.Trim() != "" && sortid.Text.Trim() != "")
                    {

                        pic.hotelid = hotelid;
                        pic.title = title.Text.ToString();
                        pic.sortid = MyCommFun.Str2Int(sortid.Text.ToString());
                        pic.picUrl = picUrl.Text.ToString();
                        pic.picTiaozhuan = picTiaozhuan.Text.ToString();
                        pic.createDate = DateTime.Now;
                        picBll.Add(pic);

                    }
                }
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改商家设置，主键为" + hotelid); //记录日志
                JscriptMsg("修改成功！", "hotel_list.aspx", "Success");
            }
        }
    }
}