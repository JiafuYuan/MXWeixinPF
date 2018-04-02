<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chongzhi.aspx.cs" Inherits="MxWeiXinPF.Web.admin.agent.chongzhi" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>代理商充值</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />


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
        <div class="location">
            <a href="agent_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <i class="arrow"></i>
            <a href="agent_list.aspx"><span>代理商管理</span></a>
            <i class="arrow"></i>
            <span>代理商充值</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->


        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">代理商充值</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>登录名</dt>
                <dd>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>姓名</dt>
                <dd>
                     <asp:Label ID="lblRealName" runat="server" Text=""></asp:Label>
                  
                </dd>
            </dl>

            <dl>
                <dt>申请费用</dt>
                <dd>
                    <asp:Label ID="lbltxtsqJine" runat="server" Text=""></asp:Label>

                </dd>
            </dl>
            <dl>
                <dt>余额</dt>
                <dd>
                    <asp:Label ID="lblYue" runat="server" Text=""></asp:Label>

                </dd>
            </dl>

            <dl>
                <dt>享受的价格</dt>
                <dd>
                    <asp:Label ID="lblagentPrice" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>代理商等级</dt>
                <dd>
                    <asp:Label ID="lblagentLevel" runat="server" Text=""></asp:Label>

                </dd>
            </dl>
            <dl>
                <dt>充值金额</dt>
                <dd>
                    <asp:TextBox ID="txtMoney" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
                    <span class="Validform_checktip">*数字</span>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
