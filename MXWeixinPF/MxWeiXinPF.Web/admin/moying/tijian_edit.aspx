<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tijian_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.moying.tijian_edit" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <!--导航栏-->
        <div class="location">
            <a href="user_list.aspx" class="home"><i></i><span>用户管理</span></a>
            <i class="arrow"></i>
            <a href="tijianinfo_list.aspx?uid=<%=uid %>"><span>体检管理</span></a>
            <i class="arrow"></i>
            <span>记录编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">记录编辑</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>身高</dt>
                <dd>
                    <asp:TextBox ID="txtGao" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">单位：cm</span>
                </dd>
            </dl>
            <dl>
                <dt>体重</dt>
                <dd>
                    <asp:TextBox ID="txtZhong" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">单位：kg</span>
                </dd>
            </dl>
            <dl>
                <dt>胸部指数</dt>
                <dd>
                    <asp:TextBox ID="txtXiong" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>头部指数</dt>
                <dd>
                    <asp:TextBox ID="txtTou" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>腹部指数</dt>
                <dd>
                    <asp:TextBox ID="txtFu" runat="server" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>体检时间</dt>
                <dd>
                    <div class="input-date">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="*1-50" errormsg="请选择正确的日期" sucmsg=" " nullmsg=" " />
                        <i>日期</i>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>体检详情</dt>
                <dd>
                    <asp:TextBox ID="txtDetail" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    <span class="Validform_checktip">255个字符以内</span>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="提交保存" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>

</html>
