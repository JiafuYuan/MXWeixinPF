<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.crm.user_list" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
  
    </script>
    <style type="text/css">
        .headimgurl {
            width: 80px;
        }

        .span_guanzhu {
            font-weight: bold;
        }

        .span_paolu {
            color: red;
        }
    </style>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="#" class="home"><i></i><span>会员管理</span></a>

        </div>
        <!--/导航栏-->
        <div class="mytips">
            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="hidErr" runat="server" />
            <asp:Button ID="btnSyn" runat="server" Text="同步粉丝信息" CssClass="btn" OnClick="btnSyn_Click" />
        </div>

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">

                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlGroupId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupId_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Text="所有状态" Value=""></asp:ListItem>
                                <asp:ListItem Text="已取消关注" Value="2"></asp:ListItem>
                                <asp:ListItem Text="关注" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th align="center" width="4%">序号</th>
                        <th align="center">用户</th>
                        <th align="center" width="12%">分组</th>
                        <th align="center" width="50">性别</th>
                        <th width="18%">所在城市</th>
                        <th width="14%">关注时间</th>
                        <th width="10%">状态</th>
                        <th width="18%">标签</th>
                        <th width="12%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%# Container.ItemIndex + 1%> 
                    </td>
                    <td align="center">
                        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        <a href="user_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>" class="usertitle">
                            <img alt="" src="<%# Eval("headimgurl") %>" class="headimgurl" /><br />
                            <%#Eval("nickname")%>
                        </a>
                    </td>
                    <td>
                        <div class="user-box">
                            <%#Eval("gName")%>
                        </div>
                    </td>
                    <td align="center"><%# GetUserSex(Convert.ToInt32(Eval("sex"))) %> </td>
                    <td>
                        <div class="user-box">
                            <%#Eval("country")%> <%#Eval("province")%> <%#Eval("city")%>
                        </div>
                    </td>
                    <td align="center"><%#Eval("subscribe_time")%></td>
                    <td align="center"><%#Eval("uStatus").ToString()=="1"?"<span class='span_guanzhu'>关注</span>":"<span class='span_paolu'>已取消关注</span>"%></td>
                    <td align="center"><%#Eval("tag")%></td>
                    <td align="center">
                        <a href="user_tag.aspx?id=<%#Eval("id")%>">编辑标签</a>
                        <a href="talk.aspx?id=<%#Eval("id")%>">查看对话记录</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
