<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="talk.aspx.cs" Inherits="MxWeiXinPF.Web.admin.crm.talk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>关注时回复</title>
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
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });

            $("input[name='rblResponseType']").click(function () {

                if ($(this).val() == "0") {
                    //文本
                    $(".wenben").show();
                    $(".music").hide();
                    $(".picnews").hide();
                    $("#div_gongju").show();
                }
                else if ($(this).val() == "1") {
                    //图文
                    $(".picnews").show();
                    $(".music").hide();
                    $(".wenben").hide();
                    $("#div_gongju").show();

                }
                else if ($(this).val() == "2") {
                    //语音
                    $(".wenben").hide();
                    $(".music").show();
                    $(".picnews").hide();
                    $("#div_gongju").show();
                }

            });

            $("#btnSendout").click(function () {
                var rType = $("input[name='rblResponseType']:checked").val();

                if (rType == "0") {
                    var txtContent = $("#txtContent").val();

                    if ($.trim(txtContent) == "") {
                        $.dialog.alert("请填写内容");
                        return false;
                    }
                }
                if (rType == "2") {
                    var txtMusicTitle = $("#txtMusicTitle").val();
                    var txtMusicFile = $("#txtMusicFile").val();

                    if ($.trim(txtMusicTitle) == "") {
                        $.dialog.alert("请填写音乐标题");
                        return false;
                    }

                    if ($.trim(txtMusicFile) == "") {
                        $.dialog.alert("请填写音乐链接");
                        return false;
                    }
                }

                if (rType == "1") {
                    //验证表单
                    if ($("#txtTitle").val() == "") {
                        $.dialog.alert('请填写标题！');
                        return false;
                    }

                }
            });
        });
        //创建图文的窗口
        function showGuiZeDialog(id) { 
            var contenturl = "url:crm/showNews.aspx?id=" + id;
            var m = $.dialog({
                id: 'dialogGuiZe',
                fixed: true,
                lock: true,
                max: false,
                min: false,
                title: "查看图文信息",
                content: contenturl,
                height: 420,
                width: 650,

                close: function () {
                    this.reload();
                }
            });
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
        <asp:HiddenField ID="hidAction" runat="server" Value="0" />

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="Div1" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--导航栏-->
        <div class="location" style="display: none;">
            <a href="javascript:;" class="home"><i></i><span>
                <asp:Literal ID="litNowPosition" runat="server" Text="发送消息"></asp:Literal>
            </span></a>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--聊天记录列表-->
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <td width="8%"></td>
                        <td align="center"></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <img alt="" src="<%#Eval("flag").ToString()=="1"?Eval("headerpic"):Eval("headimgurl")%>" class="headimgurl" style="max-height: 60px; max-width: 60px;" />
                    </td>
                    <td style="vertical-align: top;">
                        <p><%#Eval("flag").ToString()=="1"?"系统":Eval("nickname") %> &nbsp; <%# Convert.ToDateTime(Eval("createDate")).ToString("yyyy-MM-dd hh:mm:ss") %></p>
                        <asp:Literal ID="litShow" runat="server"></asp:Literal>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
            </table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/聊天记录列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->

        <!--内容-->
        <asp:Label ID="lblact" runat="server" Text="" Style="display: none;"></asp:Label>
        <asp:Label ID="lblreqestType" runat="server" Text="" Style="display: none;"></asp:Label>
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">
                            <asp:Literal ID="litNowPosition2" runat="server" Text="发送消息"></asp:Literal></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--/内容-->

        <!--发送消息-->
        <div class="tab-content">
            <dl>
                <dt>类型</dt>
                <dd>
                    <div class="rule-multi-radio">
                        <asp:RadioButtonList ID="rblResponseType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">文本</asp:ListItem>
                            <asp:ListItem Value="1">图文</asp:ListItem>
                            <asp:ListItem Value="2">语音</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </dd>
            </dl>

            <dl class="wenben" style="display: none;">
                <dt>内容</dt>
                <dd>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="input" Style="height: 100px;" TextMode="MultiLine" datatype="*0-1000" sucmsg="*最多1000个字符 "></asp:TextBox>
                    <span class="Validform_checktip">*最多1000个字符</span>
                </dd>
            </dl>
            <dl id="div_music_title" style="display: none;" class="music">
                <dt>音乐标题</dt>
                <dd>
                    <asp:TextBox ID="txtMusicTitle" runat="server" CssClass="input normal" datatype="*0-255" sucmsg="最多30个字符 " />
                    <span class="Validform_checktip">*最多30个字符</span>
                </dd>
            </dl>

            <dl id="div_music_url" style="display: none;" class="music">
                <dt>音乐链接</dt>
                <dd>
                    <asp:TextBox ID="txtMusicFile" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">*支持mp3格式，可以填写网上的链接，也可以本地上传！</span>
                </dd>
            </dl>
            <dl id="div_music_remark" style="display: none;" class="music">
                <dt>音乐描述</dt>
                <dd>
                    <asp:TextBox ID="txtMusicRemark" runat="server" CssClass="input normal upload-path" />
                </dd>
            </dl>
            <dl class="picnews" style="display: none;">
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" class="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl class="picnews" style="display: none;">
                <dt>图片</dt>
                <dd>
                    <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                </dd>
            </dl>
            <dl class="picnews" style="display: none;">
                <dt>内容</dt>
                <dd>
                    <textarea name="txtNewsContent" rows="2" cols="20" id="txtNewsContent" class="input" runat="server"></textarea>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl class="picnews" style="display: none;">
                <dt>链接</dt>
                <dd>
                    <asp:TextBox ID="txtUrl" runat="server" class="input normal"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>
        <!--/发送消息-->

        <!--工具栏-->
        <div class="page-footer" runat="server" id="div_gongju">
            <div class="btn-list tab-content">
                <asp:Button ID="btnSendout" runat="server" Text="发送" CssClass="btn" OnClick="btnSendout_Click" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
