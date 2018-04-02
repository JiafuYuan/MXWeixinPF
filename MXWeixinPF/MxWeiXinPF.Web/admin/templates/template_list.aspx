<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template_list.aspx.cs" Inherits="MxWeiXinPF.Web.admin.templates.template_list" %>


<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>模版列表</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {

            $("#btnSave").click(function () {
                var list = $('input:radio[name="gTemplate"]:checked').attr("tip");
                if (list == null) {

                    $.dialog.alert("请选中一个模版!");
                    return false;
                }
                else {
                    $("#txtSelectTemplateId").val(list);
                }
                //二级
                var erjiList = $('input:radio[name="gErjiTemplate"]:checked').attr("tip");
                if (erjiList == null) {
                    $("#txtSelectErJiTemplateId").val("14");
                }
                else {
                    $("#txtSelectErJiTemplateId").val(erjiList);
                }

                //列表
                var liebiaoList = $('input:radio[name="gLiebiaoTemplate"]:checked').attr("tip");
                if (erjiList == null) {
                    $("#txtSelectLieBiaoTemplateId").val("11");
                }
                else {
                    $("#txtSelectLieBiaoTemplateId").val(liebiaoList);
                }

                //详情
                var detailList = $('input:radio[name="gDetailTemplate"]:checked').attr("tip");
                if (erjiList == null) {
                    $("#txtSelectDetailTemplateId").val("12");
                }
                else {
                    $("#txtSelectDetailTemplateId").val(detailList);
                }

                var colorId = $('input:radio[name="gColor"]:checked').attr("tip");
                if (colorId == null) {
                    $("#txtSelectColorId").val("4");
                }
                else {
                    $("#txtSelectColorId").val(colorId);
                }

            });

            //创建图文的窗口 
            $("#aLookIndex").click(function () {
                console.log("begin");
                var contenturl = "url:templates/showPhone.aspx";
                var m = $.dialog({
                    id: 'dialogGuiZe',
                    fixed: true,
                    lock: true,
                    max: false,
                    min: false,
                    title: "查看模版效果",
                    content: contenturl,
                    height: 600,
                    width: 400,
                    close: function () {
                        
                    }
                });
                console.log("end");
            })


        });


    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a class="home"><i></i><span>模版列表</span></a>
            <asp:HiddenField ID="hidWTId" runat="server" Value="0" />
            <asp:TextBox ID="txtSelectTemplateId" runat="server" Text="0" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="txtSelectErJiTemplateId" runat="server" Text="0" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="txtSelectLieBiaoTemplateId" runat="server" Text="0" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="txtSelectDetailTemplateId" runat="server" Text="0" Style="display: none;"></asp:TextBox>
            <asp:TextBox ID="txtSelectColorId" runat="server" Text="0" Style="display: none;"></asp:TextBox>
        </div>
        <!--/导航栏-->

        <!--tab-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">首页模版</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">二级分类页面模版</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">列表页面模版</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">详情页面模版</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">颜色选择</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <!--/tab-->
        <div class="tab-content">
            <!--图片列表-->
            <asp:Repeater ID="rptList2" runat="server">
                <HeaderTemplate>
                    <div class="templatelist" style="width: 1000px; margin: 0 auto;">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="templatelidiv">
                            <label for='<%#"rad"+Eval("id")%>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("aboutPic")%>' />

                                <div class="templateName" style="height: 20px; padding-top: 5px;">
                                    <%# "<input id=\"rad"+Eval("id")+"\" type=\"radio\" name=\"gTemplate\" tip=\""+Eval("id")+"\" /> "%>
                                    <%#Eval("tName")%>
                                </div>
                            </label>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList2.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无模版</div>" : ""%>
              </ul>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <!--/图片列表-->
        </div>
        <div class="tab-content" style="display: none;">
            <!--二级页面图片列表-->
            <asp:Repeater ID="rptErJiList" runat="server">
                <HeaderTemplate>
                    <div class="templatelist" style="width: 1000px; margin: 0 auto;">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="templatelidiv">
                            <label for='<%#"rad_erji"+Eval("id")%>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("aboutPic")%>' />

                                <div class="templateName" style="height: 20px; padding-top: 5px;">
                                    <%# "<input id=\"rad_erji"+Eval("id")+"\" type=\"radio\" name=\"gErjiTemplate\" tip=\""+Eval("id")+"\" /> "%>
                                    <%#Eval("tName")%>
                                </div>
                            </label>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptErJiList.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无模版</div>" : ""%>
              </ul>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <!--/二级页面图片列表-->
        </div>
        <div class="tab-content" style="display: none;">
            <!--列表页面图片列表-->
            <asp:Repeater ID="rptLieBiaoList" runat="server">
                <HeaderTemplate>
                    <div class="templatelist" style="width: 1000px; margin: 0 auto;">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="templatelidiv">
                            <label for='<%#"rad_liebiao"+Eval("id")%>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("aboutPic")%>' />

                                <div class="templateName" style="height: 20px; padding-top: 5px;">
                                    <%# "<input id=\"rad_liebiao"+Eval("id")+"\" type=\"radio\" name=\"gLiebiaoTemplate\" tip=\""+Eval("id")+"\" /> "%>
                                    <%#Eval("tName")%>
                                </div>
                            </label>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptLieBiaoList.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无模版</div>" : ""%>
              </ul>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <!--/列表页面图片列表-->
        </div>
        <div class="tab-content" style="display: none;">
            <!--详情页面图片列表-->
            <asp:Repeater ID="rptDetailList" runat="server">
                <HeaderTemplate>
                    <div class="templatelist" style="width: 1000px; margin: 0 auto;">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="templatelidiv">
                            <label for='<%#"rad_detail"+Eval("id")%>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("aboutPic")%>' />

                                <div class="templateName" style="height: 20px; padding-top: 5px;">
                                    <%# "<input id=\"rad_detail"+Eval("id")+"\" type=\"radio\" name=\"gDetailTemplate\" tip=\""+Eval("id")+"\" /> "%>
                                    <%#Eval("tName")%>
                                </div>
                            </label>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptDetailList.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无模版</div>" : ""%>
              </ul>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <!--/详情页面图片列表-->
        </div>

        <div class="tab-content" style="display: none;">

            <asp:Repeater ID="rptColor" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <thead>
                            <tr>
                                <th width="5%">选择</th>
                                <th>内容</th>

                            </tr>
                        </thead>
                        <tbody class="ltbody">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="td_c">
                        <td>
                            <%# "<input id=\"radcolor"+Eval("id")+"\" type=\"radio\" name=\"gColor\" tip=\""+Eval("id")+"\" /> "%>
                        </td>
                        <td>
                            <label for='<%#"radcolor"+Eval("id")%>'>
                                <%# Eval("mName") %>
                            </label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>



        </div>
        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSave" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSave_Click" />
                <asp:HyperLink ID="aLookIndex" runat="server" CssClass="btn yellow fontwhite">查看效果</asp:HyperLink>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
