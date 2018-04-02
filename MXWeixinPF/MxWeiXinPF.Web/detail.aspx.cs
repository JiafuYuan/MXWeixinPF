using MxWeiXinPF.Common;
using MxWeiXinPF.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web
{
    public partial class detail : TBasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            if (errInitTemplates != "")
            {
                Response.Write(errInitTemplates);
                return;
            }
            //1获得模版基本信息
            BLL.wx_templates tBll = new BLL.wx_templates();
            templateDetailName = tBll.GetDetailTemplatesFileNameByWid(wid);
            if (templateDetailName == null || templateDetailName.Trim() == "")
            {
                templateDetailName = "type1";
            }

            tPath = MyCommFun.GetRootPath() + "/templates/detail/" + templateDetailName + "/news_show.html";
            TemplateMgr template = new TemplateMgr(tPath, wid);
            template.tType = TemplateType.News;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(templateDetailName, wid);


        }
    }
}