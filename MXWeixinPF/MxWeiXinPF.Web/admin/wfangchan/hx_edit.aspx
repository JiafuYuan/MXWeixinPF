<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hx_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.wfangchan.hx_edit" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑大转盘活动</title>
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
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });


        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="floorMgr.aspx" class="home"><i></i><span>楼盘列表</span></a>
            <i class="arrow"></i>
            <a href="hxMgr.aspx?id=<%=fid %>" class="back"><i></i><span>户型管理</span></a>
            <i class="arrow"></i>
            <span>编辑户型</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本内容</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>户型名称：</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*尽量简单，不要超过20字</span>
                </dd>
            </dl>
            <dl>
                <dt>请选择子楼盘：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlSonfloor" runat="server"></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>选择全景相册：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlPanorama" runat="server"></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">* 如果没有请留空，或者到 360°全景添加</span>
                </dd>
            </dl> 
            <dl>
                <dt>楼层：</dt>
                <dd>
                    <asp:TextBox ID="txtStorey" runat="server"  CssClass="input small" datatype="n" sucmsg=" " Text="" />
                    <span class="Validform_checktip">* 如：1-10</span>
                </dd>
            </dl>
            <dl>
                <dt>建筑面积：</dt>
                <dd>
                    <asp:TextBox ID="txtJzmj" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">* 如：约120平方米</span>
                </dd>
            </dl>
            <dl>
                <dt>房屋户型：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlFang" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <span>房</span>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlDing" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <span>厅</span>
                </dd>
            </dl>
            <dl>
                <dt>显示顺序：</dt>
                <dd>
                    <asp:TextBox ID="txtSort_id" runat="server"  CssClass="input small" datatype="n" sucmsg=" " Text="99" />
                    <span class="Validform_checktip">* 数值越大越靠前</span>
                </dd>
            </dl>

            <dl>
                <dt>户型介绍：</dt>
                <dd>
                    <asp:TextBox ID="txtJieshao" runat="server" TextMode="MultiLine" Rows="7" Columns="70"></asp:TextBox>
                    <span class="Validform_checktip">可以留空</span>
                </dd>
            </dl>
            <dl>
                <dt>户型图片:</dt>
                <dd>
                    <asp:Image ID="slideA" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideAUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">建议尺寸：宽720像素，高400像素</span>
                </dd>
                <dd>
                    <asp:Image ID="slideB" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideBUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">建议尺寸：宽720像素，高400像素</span>
                </dd>
                <dd>
                    <asp:Image ID="slideC" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideCUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">建议尺寸：宽720像素，高400像素</span>
                </dd>
                <dd>
                    <asp:Image ID="slideD" runat="server" ImageUrl="/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideDUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">建议尺寸：宽720像素，高400像素</span>
                </dd> 
            </dl>

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="javascript:history.back(-1);"><span class="btn yellow">返回上一页</span></a>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
