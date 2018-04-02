<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="floor_edit.aspx.cs" Inherits="MxWeiXinPF.Web.admin.wfangchan.floor_edit"  ValidateRequest="false" %>

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

            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '75%',
                height: '100px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
            var editorMini = KindEditor.create('.editor-mini', {
                width: '75%',
                height: '100px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
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
            <span>编辑楼盘</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">图片</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>图文消息标题:</dt>
                <dd>
                    <asp:TextBox ID="txtNewsTitle" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*触发关键词后返回图文消息标题</span>
                </dd>
            </dl>
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:HiddenField ID="hidid" runat="server" Value="0" />
                    <asp:TextBox ID="txtKW" runat="server" CssClass="input normal" datatype="*1-20" sucmsg=" " Text="" />
                    <span class="Validform_checktip">*只能设置一个关键字</span>
                </dd>
            </dl>
            <dl>
                <dt>预约版面：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlYybm" runat="server"></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>全景图：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlQjt" runat="server"></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>楼盘地址:</dt>
                <dd>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input normal" datatype="*1-200" sucmsg=" " Text="请输入接待预约用户的地址" />
                    <span class="Validform_checktip">*如合肥市政务区南二环路3818号万达广场</span>
                </dd>
            </dl>
            <dl>
                <dt>楼盘视频：</dt>
                <dd>
                    <asp:TextBox ID="txtVideo" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" " Text="" /><br />
                    <span class="Validform_checktip">支持优酷视频地址如：http://v.youku.com/v_show/id_XNDA1ODEyNjE2.html
                    <br />
                        腾讯fash视频地址：如http://static.video.qq.com/TPout.swf?vid=v0119s27wd5&auto=0
                    <br />
                        也支持mp4和ogg 格式地址 http://www.w3school.com.cn/example/html5/mov_bbb.mp4 </span>
                </dd>
            </dl>
            <dl>
                <dt>地图选点</dt>
                <dd>
                    <iframe id="baiduframe" src="MapSelectPoint.aspx?yjindu=121.526149&xweidu=31.222663" height="300" width="700" style="border: 1px solid #e1e1e1;"></iframe>
                </dd>
            </dl>
            <dl>
                <dt>X,Y：</dt>
                <dd>纬度（x）:
                    <asp:TextBox ID="txtLatXPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    经度（y）:
                    <asp:TextBox ID="txtLngYPoint" runat="server" Width="200px" Text="" CssClass="input small " datatype="*1-20" sucmsg=" " nullmsg=""></asp:TextBox>
                    <span class="Validform_checktip">*</span> &nbsp;&nbsp;&nbsp;
                </dd>
            </dl>
            <dl>
                <dt>排序号:</dt>
                <dd>
                    <asp:TextBox ID="txtSort_id" runat="server" CssClass="input small" datatype="n" sucmsg=" " Text="99" />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>楼盘简介：</dt>
                <dd>
                    <textarea id="txtfSummary" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>
            <dl>
                <dt>项目简介：</dt>
                <dd>
                    <textarea id="txtpSummary" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>
            <dl>
                <dt>交通配套：</dt>
                <dd>
                    <textarea id="txtjtpt" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>首页幻灯片:</dt>
                <dd>
                    <asp:Image ID="slideA" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideAUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览[480*720]</span>
                </dd>
                <dd>
                    <asp:Image ID="slideB" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideBUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览[480*720]</span>
                </dd>
                <dd>
                    <asp:Image ID="slideC" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideCUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览[480*720]</span>
                </dd>
                <dd>
                    <asp:Image ID="slideD" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideDUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览[480*720]</span>
                </dd>
                <dd>
                    <asp:Image ID="slideE" runat="server" ImageUrl="~/images/noneimg.jpg" Style="max-height: 80px;" />
                    <asp:TextBox ID="slideEUrl" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览[480*720]</span>
                </dd>
            </dl>
            <dl>
                <dt>图文消息封面:</dt>
                <dd>
                    <asp:Image ID="imgNewsCover" ImageUrl="~/images/noneimg.jpg" runat="server" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtNewsCover" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览 建议尺寸：宽720像素，高400像素</span>
                </dd>
            </dl>
            <dl>
                <dt>楼盘头部图片：</dt>
                <dd>
                    <asp:Image ID="imgFheadImg" ImageUrl="~/images/noneimg.jpg" runat="server" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtFheadImg" runat="server" CssClass="input normal upload-path"  datatype="*"/>
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览 建议尺寸：宽720像素，高400像素</span>
                </dd>
            </dl>
            <dl>
                <dt>户型头部图片：</dt>
                <dd>
                    <asp:Image ID="imgHtheadImg" ImageUrl="~/images/noneimg.jpg" runat="server" Style="max-height: 80px;" />
                    <asp:TextBox ID="txtHtheadImg" runat="server" CssClass="input normal upload-path" />
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">预览 建议尺寸：宽720像素，高400像素</span>
                </dd>
            </dl>
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <a href="javascript: history.back(-1);"><span class="btn yellow">返回上一页</span></a>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
