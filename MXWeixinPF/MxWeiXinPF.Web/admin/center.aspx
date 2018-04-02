<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="MxWeiXinPF.Web.admin.center" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理首页</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/layout.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a class="home"><i></i><span>管理中心</span></a>
           
        </div>
        <!--/导航栏-->

        <!--内容-->
        <div class="line10"></div>
        <div class="nlist-1">
            <ul>
                <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
                <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
                <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
            </ul>
        </div>
        <div class="line10"></div>
 
        <div class="nlist-2">
            <h3><i></i>站点信息</h3>
            <ul>
                <li>站点名称：<%=siteConfig.webname %></li>
                <li>公司名称：<%=siteConfig.webcompany %></li>
                <li>系统版本：V<%=Utils.GetVersion()%></li>
                <li>升级通知：<%--<asp:Literal ID="LitUpgrade" runat="server" />--%></li>
            </ul>
            <h3><i class="msg"></i>官方消息</h3>
            <ul>
                <%--<asp:Literal ID="LitNotice" runat="server" />--%>
            </ul>
        </div>
        <div class="line20"></div>

    

       

        <!--/内容-->
    </form>
</body>
</html>
