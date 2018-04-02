<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.moying.user_edit" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>体检--用户编辑</title>
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
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;*.rar;*.zip;*.doc;*.xls;*.mp3;*.mp4" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;;*.mp3;*.mp4" });
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
            <a href="user_list.aspx" class="back"><i></i><span>返回用户列表</span></a>
            <i class="arrow"></i>
            <span>编辑用户</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑用户</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>用户名</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtusername" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*用户名限制在十个字以内!</span>
                </dd>
            </dl>

            <dl>
                <dt>得分</dt>
                <dd>

                    <asp:TextBox ID="txtuserscore" runat="server" CssClass="input small" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*得分</span>
                </dd>
            </dl> 
            <dl>
                <dt>等级</dt>
                <dd>
                    <asp:TextBox ID="txtusergrade" runat="server" CssClass="input small" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*等级</span>
                </dd>
            </dl>
            <dl>
                <dt>地址</dt>
                <dd>
                    <asp:TextBox ID="txtuseraddr" runat="server" CssClass="input normal" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txtusertel" runat="server" CssClass="input normal" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*如021-88888888</span>
                </dd>
            </dl>

            <dl>
                <dt>生日</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtuserborn" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>开始时间</i>
                    </div>
                </dd>
            </dl>



            <dl>
                <dt>电子邮箱</dt>
                <dd>
                    <asp:TextBox ID="txtuseremail" runat="server" CssClass="input normal" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>


            <dl>
                <dt>头像</dt>
                <dd>
                    <asp:Image ID="imguserpic" runat="server" ImageUrl="../../images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtuserpic" runat="server" CssClass="input normal upload-path" Text="" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip"></span>

                </dd>
            </dl>

            <dl>
                <dt>qq</dt>
                <dd>
                    <asp:TextBox ID="txtuserqq" runat="server" CssClass="input normal" sucmsg=" " Text="" nullmsg="请填写信息，并且不要多于50字 " />
                    <span class="Validform_checktip">* </span>
                </dd>
            </dl>

            <dl>
                <dt>密码</dt>
                <dd>
                    <asp:TextBox ID="txtuserpsd" runat="server" CssClass="input normal" sucmsg=" " Text="" nullmsg="请填写信息，并且不要多于50字 " />
                    <span class="Validform_checktip">* </span>
                </dd>
            </dl>


        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="xitielist.aspx"><span class="btn yellow">返回上一页</span></a>

            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
