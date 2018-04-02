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
    public partial class hotel_form : Web.UI.ManagePage
    {
        protected static int hotelid = 0;
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型
        wx_hotel_form_control cBll = new wx_hotel_form_control();

        protected void Page_Load(object sender, EventArgs e)
        {
            
                hotelid = MyCommFun.RequestInt("hotelid");
                if (cBll.Exists(hotelid)) //修改
                {
                    ShowInfo(hotelid);
                }
        }

        #region 赋值操作=================================
        private void ShowInfo(int shopid)
        {

            //绑定控件的值
            //绑定奖项信息
            IList<Model.wx_hotel_form_control> itemlist = cBll.GetModelList("hotelid=" + hotelid + " order by seq asc");

            //自定义控件
            IList<Model.wx_hotel_form_control> itemlist_zdy = (from c in itemlist where c.isSys != true select c).ToArray<Model.wx_hotel_form_control>();
            if (itemlist_zdy != null && itemlist_zdy.Count > 0)
            {
                int count = itemlist_zdy.Count;
                DropDownList ddlType;
                TextBox txtName;
                TextBox txtValue;
                CheckBox chkBT;
                TextBox txtSeq;

                Model.wx_hotel_form_control itemEntity = new Model.wx_hotel_form_control();
                for (int i = 1; i <= count; i++)
                {
                    itemEntity = itemlist_zdy[(i - 1)];

                    ddlType = this.FindControl("ddl" + i + "Type") as DropDownList;
                    txtName = this.FindControl("txt" + i + "Name") as TextBox;
                    txtValue = this.FindControl("txt" + i + "Value") as TextBox;

                    ddlType.SelectedValue = itemEntity.cType;
                    txtName.Text = itemEntity.cName;
                    txtValue.Text = itemEntity.defaultValue;

                }

            }
        }





        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            cBll.Delete(hotelid);
            AddControl();
        }

        public void AddControl()
        {

            DropDownList ddlType;
            TextBox txtName;
            TextBox txtValue;
            CheckBox chkBT;
            TextBox txtSeq;
            Model.wx_hotel_form_control control = new Model.wx_hotel_form_control();
            //系统内置控件的设置
            int idf = 0;

            for (int i = 1; i <= 9; i++)
            {
                control = new Model.wx_hotel_form_control();
                ddlType = this.FindControl("ddl" + i + "Type") as DropDownList;
                txtName = this.FindControl("txt" + i + "Name") as TextBox;
                txtValue = this.FindControl("txt" + i + "Value") as TextBox;

                if (txtName.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    control.cType = ddlType.SelectedItem.Value;
                    control.cName = txtName.Text.Trim();
                    control.defaultValue = txtValue.Text.Trim();
                    control.isBiTian = false;
                    control.seq = i;
                    control.hotelId = hotelid;
                    control.createDate = DateTime.Now;
                    idf = cBll.Add(control);
                }
            }
            AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加表单，shopinfoId为：" + hotelid); //记录日志
            JscriptMsg("操作成功！", Utils.CombUrlTxt("hotel_list.aspx?hotelid='" + hotelid + "'&manage=managetype", "keywords={0}", ""), "Success");
        }
    }
}