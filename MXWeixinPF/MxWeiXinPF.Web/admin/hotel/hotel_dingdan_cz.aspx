<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_dingdan_cz.aspx.cs" Inherits="MxWeiXinPF.Web.admin.hotel.hotel_dingdan_cz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单处理</title>
        <script type="text/javascript" src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
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
    <script type="text/javascript">
        function parentToIndex(id) {
            parent.location.href = "/admin/Index.aspx?id=" + id;

        }

        $(function () {


        });

    </script>
    <style>
       a.shenghe {
        color:red;
        
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">

            <div class="location">
            <a href="hotel_list.aspx" class="home"><i></i><span>微酒店</span></a>
            <a href="hotel_dingdan_manage.aspx?hotelid=<%=hotelid %>" class="home">
            <i class="arrow"></i>
            <span>在线预定管理</span>
            </a>
            <i class="arrow"></i>
           <span>订单处理</span>
   
        </div>
        <div class="line10"></div>


         <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">订单处理</a></li>                     
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>



  
        <!--/导航栏-->

         <div class="tab-content">

               <dl>
                <dt><%=ordername%>:</dt>
                <dd>                 
                    <%=openid %>
                </dd>
            </dl>
               <dl>
                <dt>电话:</dt>
                <dd>                 
                    <%=dingdan.tel %>
                </dd>
            </dl>
               <dl>
                <dt>入住/离店时间:</dt>
                <dd>                 
                    <%=dingdan.arriveTime.Value.ToShortDateString() %>~<%=dingdan.leaveTime.Value.ToShortDateString() %>
                </dd>
            </dl>
               <dl>
                <dt>房间类型:</dt>
                <dd>                 
                    <%=dingdan.roomType %>
                </dd>
            </dl>
               <dl>
                <dt>预定数量:</dt>
                <dd>                 
                    <%=dingdan.orderNum %>
                </dd>
            </dl>
               <dl>
                <dt>价格:</dt>
                <dd>                 
                    <%=dingdan.price %>
                </dd>
            </dl>


             <dl>
                <dt>备注:</dt>
                <dd>                 
                    <%=beizhu %>
                </dd>
            </dl>

            <dl>
                <dt>状态调整为：</dt>
                <dd>
                    <asp:DropDownList ID="StatusType" runat="server">
                        <asp:ListItem Text="不处理" Value="0"></asp:ListItem>
                        <asp:ListItem Text="确认" Value="1"></asp:ListItem>
                        <asp:ListItem Text="拒绝" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    
                </dd>
            </dl>
         </div>
      
           <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_groupbase" runat="server" CssClass="btn" Text="保存" OnClick="save_groupbase_Click"  />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
