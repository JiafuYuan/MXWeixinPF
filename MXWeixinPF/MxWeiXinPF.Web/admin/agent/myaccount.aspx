<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myaccount.aspx.cs" Inherits="MxWeiXinPF.Web.admin.agent.myaccount" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>代理商账户信息</title>
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
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filesize: "10240", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.rar;*.zip;*.doc;*.xls;*.mp3;*.mp4" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.rar;*.zip;*.doc;*.xls;*.mp3;*.mp4" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="index.aspx" class="back"><i></i><span>代理商账户信息</span></a>
          
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">代理商账户信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
             <div class="mytips">
               充值请联系管理员！
         </div>

            <dl>
                <dt>帐号</dt>
                <dd>
                    <asp:Label ID="txtuser_name" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
             <dl>
                <dt>姓名</dt>
                <dd>
                     <asp:Label ID="txtreal_name" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
             <dl>
                <dt>充值总金额</dt>
                <dd>
                   <asp:Label ID="txtczTotMoney" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
             <dl>
                <dt>消费金额</dt>
                <dd>
                   <asp:Label ID="lblxfTotMoney" runat="server" Text=""></asp:Label>
                </dd>
            </dl>

            <dl>
                <dt>剩余金额</dt>
                <dd>
                     <asp:Label ID="txtremainMony" runat="server" Text="" Font-Bold="true"></asp:Label>
                </dd>
            </dl>
            
            <dl>
                <dt>申请费用</dt>
                <dd>
                      <asp:Label ID="txtsqJine" runat="server" Text=""></asp:Label>
                </dd>
            </dl>

              <dl>
                <dt>享受的价格</dt>
                <dd>
                      <asp:Label ID="lblagentPrice" runat="server" Text=""></asp:Label>
                </dd>
            </dl>

            <dl>
                <dt>已有用户数量</dt>
                <dd>
                      <asp:Label ID="txtuserNum" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>已有微帐号数量</dt>
                <dd>
                     <asp:Label ID="txtwcodeNum" runat="server" Text=""></asp:Label>
                </dd>
            </dl>

        
        </div>
        

         
        <!--/内容-->

       
    </form>
</body>
</html>