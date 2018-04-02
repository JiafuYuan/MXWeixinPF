<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.crm.group_list" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员组列表</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
       <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
  
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
           
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>会员组别</span>
        </div>
        <!--/导航栏-->

         <div class="mytips">
             <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label> 
             <asp:HiddenField ID="hidErr" runat="server" />
              <asp:Button ID="btnSyn" runat="server" Text="同步分组信息" CssClass="btn" OnClick="btnSyn_Click" />
         </div>

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list" id="btn_anniu">
                        <li><a class="add" href="group_edit.aspx?action=<%=MXEnums.ActionEnum.Add %>"><i></i>
                            <span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                      </ul>
                </div>
                 
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="8%">选择
                        </th>
                        <th align="center">组别名称
                        </th>
                       <th align="center">人数
                        </th>
                        <th width="10%">操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId"
                            Value='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td align="center">
                        <a href="group_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&name=<%#Eval("name")%>">
                            <%#Eval("name")%></a>
                    </td>
                      <td align="center">
                         
                            <%#Eval("count")%> 
                    </td>
                   
                    <td align="center">
                        <a href="group_edit.aspx?action=<%#MXEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&name=<%#Eval("name")%>">修改</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
            </table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->
    </form>
      
</body>
</html>
