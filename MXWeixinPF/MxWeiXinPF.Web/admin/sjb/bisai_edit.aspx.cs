using MxWeiXinPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web.admin.sjb
{
    public partial class bisai_edit : Web.UI.ManagePage
    {
        BLL.wx_sjb_bisai bisaibll = new BLL.wx_sjb_bisai();
        Model.wx_sjb_bisai bisai = new Model.wx_sjb_bisai();
        public string type = "";
        public int richengid = 0;
        public int bisaiid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           richengid= MyCommFun.RequestInt("rcid");
           bisaiid = MyCommFun.RequestInt("id");
           type = MyCommFun.QueryString("type");
            if(!IsPostBack)
            {
                //获取球队
                qiudui1();
                qiudui2();
                if (type == "edite")
                {
                    bisai = bisaibll.GetModel(bisaiid);
                    if(bisai!=null)
                    {
                        this.bsPic.Text = bisai.bsPic;
                        this.bsRemark.InnerText = bisai.bsRemark;
                        this.qd1Id.SelectedValue = bisai.qd1Id.ToString();
                        this.qd2Id.SelectedValue = bisai.qd2Id.ToString();
                        this.beginDate.Text = bisai.beginDate.ToString();
                        this.endDate.Text = bisai.endDate.ToString();
                        this.jcBeginDate.Text = bisai.jcBeginDate.ToString();
                        this.jcEndDate.Text = bisai.jcEndDate.ToString();

                    }
                }
            }
        }

      

        public void qiudui1()
        {
            BLL.wx_sjb_qiudui cBll = new BLL.wx_sjb_qiudui();
            IList<Model.wx_sjb_qiudui> cateList = cBll.GetModelList(" " );
            qd1Id.DataValueField = "id";
            qd1Id.DataTextField = "qdName";
            qd1Id.DataSource = cateList;
            qd1Id.DataBind();
            qd1Id.Items.Insert(0, new ListItem("请选择", ""));
        }

        public void qiudui2()
        {
            BLL.wx_sjb_qiudui cBll = new BLL.wx_sjb_qiudui();
            IList<Model.wx_sjb_qiudui> cateList = cBll.GetModelList(" ");
            qd2Id.DataValueField = "id";
            qd2Id.DataTextField = "qdName";
            qd2Id.DataSource = cateList;
            qd2Id.DataBind();
            qd2Id.Items.Insert(0, new ListItem("请选择", ""));
        }

        protected void save_qiudui_Click(object sender, EventArgs e)
        {
            BLL.wx_sjb_richeng richengbll = new BLL.wx_sjb_richeng();
            Model.wx_sjb_richeng richengmodel = new Model.wx_sjb_richeng();

            richengmodel = richengbll.GetModel(richengid);
            DateTime  beginDate=MyCommFun.Obj2DateTime(this.beginDate.Text.ToString());
            DateTime endDate=MyCommFun.Obj2DateTime(this.endDate.Text.ToString());

            if (beginDate > endDate)
            {
                JscriptMsg("开始时间不能大于介绍时间！", "back", "Error");
                return;
            }

            if (richengmodel.beginDate <= beginDate && richengmodel.endDate >= endDate)
            {
               
            }
            else
            {
                JscriptMsg("时间范围必须在日程日内！", "back", "Error");
                return;
            }

            if (type == "edite")
            {
                bisai.id = bisaiid;
                bisai.rcId = richengid;
                bisai.bsPic = this.bsPic.Text;
                bisai.bsRemark = this.bsRemark.InnerText;
                bisai.qd1Id = Convert.ToInt32( this.qd1Id.SelectedValue);
                bisai.qd2Id = Convert.ToInt32(this.qd2Id.SelectedValue);
                if (this.beginDate.Text!="")
                {
                bisai.beginDate = Convert.ToDateTime( this.beginDate.Text);
                }
                if (this.endDate.Text!="")
                {
                bisai.endDate = Convert.ToDateTime( this.endDate.Text);
                }
                if (this.jcBeginDate.Text!="")
                {
                    bisai.jcBeginDate= Convert.ToDateTime( this.jcBeginDate.Text);
                }
                if (this.jcEndDate.Text!="")
                {
                bisai.jcEndDate =Convert.ToDateTime( this.jcEndDate.Text);
                }

                


                bisaibll.Update(bisai);

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改球队设置，主键为" + bisaiid); //记录日志
                JscriptMsg("修改成功！", "bisai_list.aspx?id=" + richengid, "Success");


            }

            if(type=="add")
            {

                bisai.rcId = richengid;
                bisai.bsPic = this.bsPic.Text;
                bisai.bsRemark = this.bsRemark.InnerText;
                bisai.qd1Id = Convert.ToInt32(this.qd1Id.SelectedValue);
                bisai.qd2Id = Convert.ToInt32(this.qd2Id.SelectedValue);

               

                if (this.beginDate.Text != "")
                {
                    bisai.beginDate = Convert.ToDateTime(this.beginDate.Text);
                }
                if (this.endDate.Text != "")
                {
                    bisai.endDate = Convert.ToDateTime(this.endDate.Text);
                }



                if (this.jcBeginDate.Text != "")
                {
                    bisai.jcBeginDate = Convert.ToDateTime(this.jcBeginDate.Text);
                }
                if (this.jcEndDate.Text != "")
                {
                    bisai.jcEndDate = Convert.ToDateTime(this.jcEndDate.Text);
                }
             

                int id = bisaibll.Add(bisai);

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "修改球队设置，主键为" + id); //记录日志
                JscriptMsg("增加成功！", "bisai_list.aspx?id=" + richengid , "Success");

            }

        }
    }
}