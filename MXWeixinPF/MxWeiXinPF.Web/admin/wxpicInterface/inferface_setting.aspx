<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inferface_setting.aspx.cs" Inherits="MxWeiXinPF.Web.admin.wxpicInterface.inferface_setting" %>
 
<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>微拍接口管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        
        <asp:HiddenField ID="hidid" runat="server" Value="0" />

        <!--导航栏-->
        <div class="location">
            <a href="pic_list.aspx" class="home"><i></i><span>返回</span></a>
          
            <i class="arrow"></i>
            <span>微拍接口管理</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">微拍接口管理</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>状态</dt>
                <dd>
                  <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblIsStart" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem  Value="1" >启用</asp:ListItem>
                            <asp:ListItem  Value="0" Selected="True">未启用</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    
                </dd>
            </dl>
            <dl>
                <dt>进入打印的关键词</dt>
                <dd>
                    
                    <asp:TextBox runat="server" ID="txtenterKeyWords" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-100" Text="打印" ></asp:TextBox>
                    <span class="Validform_checktip">*不能与其他的关键词相同</span>

                </dd>
            </dl>
              <dl>
                <dt>回复提示</dt>
                <dd>
                    
                    <asp:TextBox runat="server" ID="txtprompt" CssClass="input normal" sucmsg=" " nullmsg="" datatype="*1-300" Text="您已进入照片打印模式，上传一张照片，打印你的lomo图。10分钟后自动退出打印模式。" TextMode="MultiLine" Rows="2" ></asp:TextBox>
                    <span class="Validform_checktip">*</span>

                </dd>
            </dl>

            
            <dl>
                <dt>初始化接口url</dt>
                <dd>
                    <textarea name="txtinitApiUrl" rows="2" cols="20" id="txtinitApiUrl" class="input" runat="server" datatype="*0-1000" sucmsg=" " nullmsg=" " >http://wphoto.betterwood.com:8080/Server/wechat/userinit.action</textarea>

                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
             <dl>
                <dt>传图片的接口url</dt>
                <dd>
                    <textarea name="txtpicApiUrl" rows="2" cols="20" id="txtpicApiUrl" class="input" runat="server" datatype="*1-1000" sucmsg=" " nullmsg=" ">http://wphoto.betterwood.com:8080/Server/wechat/useruplodpic.action</textarea>

                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
           
            

        </div>



        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="typelist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>

