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
    public partial class hotel_room_info : Web.UI.ManagePage
    {
        TextBox title;
        TextBox sortpicid;
        TextBox roomPic;
        TextBox roomPictz;
        protected string editetype = "";
        protected static int roomid = 0;
        protected int hotelid = 0;
        BLL.wx_hotel_room roomBll = new BLL.wx_hotel_room();
        Model.wx_hotel_room room = new Model.wx_hotel_room();

        BLL.wx_hotel_roompic picBll = new BLL.wx_hotel_roompic();
        Model.wx_hotel_roompic pic = new Model.wx_hotel_roompic();
        wx_hotel_roompic iBll = new wx_hotel_roompic();

        protected void Page_Load(object sender, EventArgs e)
        {
            hotelid = MyCommFun.RequestInt("hotelid");
            roomid = MyCommFun.RequestInt("roomid");
            editetype = MyCommFun.QueryString("type");
            if (!IsPostBack)
            {
                if (editetype == "edite")
                {
                    list(roomid);
                }
            }
        }

        public void list(int roomid)
        {
            room = roomBll.GetModel(roomid);
            if (room != null)
            {
                //this.hotelName.Text = hotel.hotelName;
                //this.hotelAddress.Text = hotel.hotelAddress;
                //this.hotelPhone.Text = hotel.hotelPhone;
                //this.mobilPhone.Text = hotel.mobilPhone;
                //this.noticeEmail.Text = hotel.noticeEmail;
                this.roomType.Text = room.roomType;
                this.indroduce.InnerText = room.indroduce;
                this.roomPrice.Text = room.roomPrice.ToString();
                this.salePrice.Text = room.salePrice.ToString();
                this.sortid.Text = room.sortid.ToString();
                this.facilities.Value = room.facilities;           
            }

            IList<Model.wx_hotel_roompic> itemlist = iBll.GetModelList("roomid=" + roomid + " order by id asc");
            if (itemlist != null && itemlist.Count > 0)
            {
                int count = itemlist.Count;


                Model.wx_hotel_roompic itemEntity = new Model.wx_hotel_roompic();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist[(i - 1)];
                    title = this.FindControl("title" + i) as TextBox;
                    sortpicid = this.FindControl("sortpicid" + i) as TextBox;
                    roomPic = this.FindControl("roomPic" + i) as TextBox;
                    roomPictz = this.FindControl("roomPictz" + i) as TextBox;

                    title.Text = itemEntity.title;
                    sortpicid.Text = itemEntity.sortpicid.ToString();
                    roomPic.Text = itemEntity.roomPic.ToString();
                    roomPictz.Text = itemEntity.roomPictz.ToString();

                }

            }
        }

        protected void save_room_Click(object sender, EventArgs e)
        {
            editetype = MyCommFun.QueryString("type");
            if (editetype == "add")
            {
                room.hotelid = hotelid;
                room.roomType = this.roomType.Text;
                room.indroduce = this.indroduce.InnerText;
                room.roomPrice = Convert.ToDecimal( this.roomPrice.Text);
                room.salePrice = Convert.ToDecimal( this.salePrice.Text);
                room.facilities = this.facilities.Value;
                room.sortid = Convert.ToInt32( this.sortid.Text);
                room.createDate = DateTime.Now;
            

                int id = roomBll.Add(room);


                for (int i = 1; i <= 6; i++)
                {
                    title = this.FindControl("title" + i) as TextBox;
                    sortpicid = this.FindControl("sortpicid" + i) as TextBox;
                    roomPic = this.FindControl("roomPic" + i) as TextBox;
                    roomPictz = this.FindControl("roomPictz" + i) as TextBox;

                    if (title.Text.Trim() != "" && sortpicid.Text.Trim() != "")
                    {

                        pic.roomid = id;
                        pic.title = title.Text.ToString();
                        pic.sortpicid = MyCommFun.Str2Int(sortpicid.Text.ToString());
                        pic.roomPic = roomPic.Text.ToString();
                        pic.roomPictz = roomPictz.Text.ToString();
                        pic.createDate = DateTime.Now;
                        pic.hotelid = hotelid;
                        picBll.Add(pic);

                    }
                }
                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加房间类型，主键为" + id); //记录日志
                JscriptMsg("添加成功！", "hotel_room.aspx?hotelid="+hotelid+"", "Success");
            }

            else if (editetype == "edite")
            {
                if (roomid == 0)
                {

                    return;
                    //操作失败！
                }

                room = roomBll.GetModel(roomid);

                room.hotelid = hotelid;
                room.roomType = this.roomType.Text;
                room.indroduce = this.indroduce.InnerText;
                room.roomPrice = Convert.ToDecimal(this.roomPrice.Text);
                room.salePrice = Convert.ToDecimal(this.salePrice.Text);
                room.facilities = this.facilities.Value;
                room.sortid = Convert.ToInt32(this.sortid.Text);             

                roomBll.Update(room);

                picBll.Deletepic(roomid);

                for (int i = 1; i <= 6; i++)
                {
                    title = this.FindControl("title" + i) as TextBox;
                    sortpicid = this.FindControl("sortpicid" + i) as TextBox;
                    roomPic = this.FindControl("roomPic" + i) as TextBox;
                    roomPictz = this.FindControl("roomPictz" + i) as TextBox;

                    if (title.Text.Trim() != "" && sortpicid.Text.Trim() != "")
                    {
                        pic.hotelid = hotelid;
                        pic.roomid = roomid;
                        pic.title = title.Text.ToString();
                        pic.sortpicid = MyCommFun.Str2Int(sortpicid.Text.ToString());
                        pic.roomPic = roomPic.Text.ToString();
                        pic.roomPictz = roomPictz.Text.ToString();
                        pic.createDate = DateTime.Now;
                        picBll.Add(pic);

                    }
                }
                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改房间类型设置，主键为" + hotelid); //记录日志
                JscriptMsg("修改成功！", "hotel_room.aspx?hotelid=" + hotelid + "", "Success");

            }
        }
    }
}