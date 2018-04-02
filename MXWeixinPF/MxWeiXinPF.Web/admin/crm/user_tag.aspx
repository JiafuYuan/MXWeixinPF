<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_tag.aspx.cs" Inherits="MxWeiXinPF.Web.admin.crm.user_tag" %>

<%@ Import Namespace="MxWeiXinPF.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑用户</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
     <script type="text/javascript" src="/weixin/commpage/js/aSelect.js"></script>
    <script type="text/javascript" src="/weixin/commpage/js/aLocation.js"></script>

    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });


          
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="user_list.aspx" class="home"><i></i><span>微信用户表页</span></a>
            <i class="arrow"></i>
            <span>编辑用户标签</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本资料</a></li>
                    </ul>
                </div>
            </div>
        </div>



        <div class="tab-content">
            <dl>
                <dt>昵称</dt>
                <dd>
                    <asp:Label ID="lblnickname" Text="-" runat="server"></asp:Label>
                </dd>
            </dl>

            <dl>
                <dt>头像</dt>
                <dd>
                    <asp:Image ID="imgPhoto" runat="server" Style="width: 200px;" />
                </dd>
            </dl>
            <dl>
                <dt>分组</dt>
                <dd>
                    <asp:Label ID="lblGroupName" Text="" runat="server"></asp:Label></dd>
            </dl>
            <dl>
                <dt>性别</dt>
                <dd>
                    <asp:Label ID="lblSex" Text="-" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>地区</dt>
                <dd>
                    <asp:Label ID="lblArea" Text="-" runat="server"></asp:Label>
                </dd>
            </dl>



            <dl>
                <dt>关注时间</dt>
                <dd>
                    <asp:Label ID="lblsubscribe_time" Text="-" runat="server"></asp:Label></dd>
            </dl>

            <!-- 用户填写的内容 -->
             

            <dl>
                <dt>标签设置</dt>
                <dd>
                    <asp:HiddenField ID="hidtagId" runat="server" Value="0" />
                    <asp:HiddenField ID="hidWid" runat="server" Value="0" />
                    <asp:HiddenField ID="hidOpenid" runat="server" Value="" />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                    <asp:TextBox ID="txtTag" runat="server" CssClass="input" TextMode="MultiLine" datatype="*2-255" sucmsg=" "></asp:TextBox>
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
          <script>
              $(function () {
                  var sel = aSelect({ data: aLocation });
                  sel.bind('#Js-selectProvince', '<%=prov%>');

         
               })
    </script>
    </form>
</body>
</html>
