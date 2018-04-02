<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lostpwd.aspx.cs" Inherits="MxWeiXinPF.Web.portalpage.lostpwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>找回密码</title>
    <script type="text/javascript" src="/scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="/admin/js/layout.js"></script>
    <link href="/admin/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server" autocomplete="off">

         <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">请认真填写信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">

            <dl>
                <dt>登录帐号</dt>
                <dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" "   AutoCompleteType="Disabled"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
             
            <dl>
                <dt>邮箱</dt>
                <dd>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="e" nullmsg="请再输入邮箱地址" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
             
            <dl>
                <dd>
                     
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" OnClick="btnSubmit_Click" />
                    <asp:Label ID="lblError" runat="server" Text="" style="color:red;"></asp:Label>
                </dd>
            </dl>

        </div>

    </form>
</body>
</html>
