<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yyddDetail.aspx.cs" Inherits="MxWeiXinPF.Web.admin.wfangchan.yyddDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">

        <!--导航栏-->
        <div class="location">
            <a href="floorMgr.aspx" class="home"><i></i><span>楼盘列表</span></a>
            <i class="arrow"></i>
            <a href="yyddMgr.aspx?id=<%=fid %>" ><i></i><span>订单列表</span></a>
            <i class="arrow"></i>
            <span>订单详情</span>
        </div>
        <div class="line10"></div>

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>预约项目：</dt>
                <dd>
                    <asp:Label ID="lblObj" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>预约人：</dt>
                <dd>
                    <asp:Label ID="lblPerson" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>电话：</dt>
                <dd>
                    <asp:Label ID="lblTelephone" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>备注：</dt>
                <dd>
                    <asp:Label ID="lblRemark" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>下单时间：</dt>
                <dd>
                    <asp:Label ID="lblxddate" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>预约时间：</dt>
                <dd>
                    <asp:Label ID="lblyydate" runat="server" Text="Label"></asp:Label>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl> 
            <dl>
                <dt>*订单状态：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem>未处理</asp:ListItem>
                            <asp:ListItem>确认</asp:ListItem>
                            <asp:ListItem>拒绝</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>*客服备注：</dt>
                <dd>
                    <asp:TextBox ID="txtkfremark" runat="server" TextMode="MultiLine" Rows="7" Columns="70"></asp:TextBox>
                    <span class="Validform_checktip">可以留空</span>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="javascript:history.back(-1);"/>
                <a href="javascript:void(0);"><span class="btn yellow">取消</span></a>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
