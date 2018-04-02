<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hotel_room_info.aspx.cs" Inherits="MxWeiXinPF.Web.admin.hotel.hotel_room_info" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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

            var editor = KindEditor.create('.editor', {
                width: '98%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });

            var editorMini = KindEditor.create('.editor-mini', {
                width: '98%',
                height: '250px',
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
        <div class="location">
            <a href="hotel_list.aspx" class="home"><i></i><span>微酒店</span></a>
            <i class="arrow"></i>
            <span><a href="hotel_room.aspx?hotelid=<%=hotelid %>" >房间类型</a></span>
            <i class="arrow"></i>
            <span>商家设置</span>
        </div>
        <div class="line10"></div>


         <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">房间类型设置</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">商家图片</a></li>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </ul>
                </div>
            </div>
        </div>

         <div class="tab-content">
             <dl>
                <dt>房间类型：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="roomType" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
                <dl>
                <dt>简要说明：</dt>
                <dd>
                    <textarea name="indroduce" rows="2" cols="20" id="indroduce"  sucmsg=" " nullmsg=" " class="input" runat="server"></textarea>
                    <span class="Validform_checktip">*字尽量少，如“大床，双床，适合2人”</span>
                </dd>
            </dl>
              <dl>
                <dt>原价：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="roomPrice" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
                <dl>
                <dt>优惠价：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="salePrice" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

               <dl>
                <dt>排序号：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="sortid" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n"></asp:TextBox>
                    <span class="Validform_checktip">*值越大越靠前,调整酒店聚合页的排序</span>
                </dd>
            </dl>

             <dl>
                <dt>配套设施：</dt>
                <dd>  
                     <textarea id="facilities" class="editor" style="visibility: hidden;" runat="server"></textarea>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

             </div>

        <div class="tab-content"  style="display:none">

               <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title1" CssClass="input normal" datatype="*1-100" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid1" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n" Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic1" runat="server" CssClass="input normal upload-path" datatype="*1-100" Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz1" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

                 <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title2" CssClass="input normal"  sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid2" CssClass="input normal" sucmsg=" " nullmsg=" " datatype="n" Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic2" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz2" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

               <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title3" CssClass="input normal" sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid3" CssClass="input normal" sucmsg=" " nullmsg=" "  Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic3" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz3" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

                <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title4" CssClass="input normal"  sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid4" CssClass="input normal" sucmsg=" " nullmsg=" "  Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic4" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz4" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

              <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title5" CssClass="input normal"  sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid5" CssClass="input normal" sucmsg=" " nullmsg=" "  Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic5" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz5" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

                 <dl>
                <dt>文字描述：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="title6" CssClass="input normal"  sucmsg=" " nullmsg=" " Style="width: 100px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    排序：         
                   <asp:TextBox runat="server" ID="sortpicid6" CssClass="input normal" sucmsg=" " nullmsg=" "  Style="width: 50px;"></asp:TextBox>
                    <span class="Validform_checktip">*</span>
                    图片地址：                  
                   <asp:TextBox ID="roomPic6" runat="server" CssClass="input normal upload-path"  Style="width: 100px;" sucmsg=" " nullmsg=" " />
                    <div class="upload-box upload-img"></div>
                    图片跳转地址：                  
                   <asp:TextBox ID="roomPictz6" runat="server" CssClass="input" Style="width: 100px;"  sucmsg=" " nullmsg=" " />
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>

            </div>

                <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="save_room" runat="server" CssClass="btn" Text="保存" OnClick="save_room_Click"   />
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
