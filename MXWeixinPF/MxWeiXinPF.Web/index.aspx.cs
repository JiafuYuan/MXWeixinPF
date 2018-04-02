﻿using MxWeiXinPF.Common;
using MxWeiXinPF.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MxWeiXinPF.Web
{
    public partial class index : TBasePage
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
            templateIndexFileName = tBll.GetTemplatesFileNameByWid(wid);
            if (templateIndexFileName == null || templateIndexFileName.Trim() == "")
            {
                errInitTemplates = "不存在该帐号或者该帐号尚未设置模版！";
                Response.Write(errInitTemplates);
                Response.End();
                return;
            }

           
            tPath = MyCommFun.GetRootPath() + "/templates/index/" + templateIndexFileName + "/index.html";
            TemplateMgr template = new TemplateMgr(tPath, wid);
            template.tType = TemplateType.Index;
            template.openid = MyCommFun.RequestOpenid();
            template.OutPutHtml(templateIndexFileName, wid);
        }
        

    }
}