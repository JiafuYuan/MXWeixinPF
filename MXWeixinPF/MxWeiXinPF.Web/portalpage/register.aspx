<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="MxWeiXinPF.Web.portalpage.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户注册</title>
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
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="/tools/admin_ajax.ashx?action=manager_validate" AutoCompleteType="Disabled"></asp:TextBox>
                    <span class="Validform_checktip">*字母、下划线，不可修改</span>
                </dd>
            </dl>
            <dl>
                <dt>登录密码</dt>
                <dd>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*4-20" nullmsg="请设置密码" errormsg="密码范围在4-20位之间" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>确认密码</dt>
                <dd>
                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="请再输入一次密码" errormsg="两次输入的密码不一致" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>姓名</dt>
                <dd>
                    <asp:TextBox ID="txtRealName" runat="server" CssClass="input normal" datatype="*1-20" nullmsg=" "></asp:TextBox>
                     <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>手机</dt>
                <dd>
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="input normal" datatype="m" nullmsg="请再输入手机号码" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span>
              <i>（填写正确的手机号码！）</i>

                </dd>
            </dl>
            <dl>
                <dt>邮箱</dt>
                <dd>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="e" nullmsg="请再输入邮箱地址" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span>
              <i>（填写正确的邮箱地址，忘记密码时可以通过邮箱找回！）</i>

                </dd>
            </dl>
            <dl>
                <dd>
                     
                    <asp:Button ID="btnSubmit" runat="server" Text="注册" CssClass="btn" OnClick="btnSubmit_Click" />
                    <asp:Label ID="lblError" runat="server" Text="" style="color:red;"></asp:Label>
                </dd>
            </dl>

        </div>

    </form>
</body>
</html>
