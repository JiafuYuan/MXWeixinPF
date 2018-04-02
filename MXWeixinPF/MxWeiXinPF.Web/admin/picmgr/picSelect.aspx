<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picSelect.aspx.cs" Inherits="MxWeiXinPF.Web.admin.picmgr.picSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>选择图片</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type='text/javascript' src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.query.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../skin/mystyle.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        //窗口API
        var api = frameElement.api, W = api.opener;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
                selectedIco();
                return false;
            }
        }, {
            name: '取消'
        });

        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });

        });

        function selectedIco() {
            var opener = $($(api.data).parent().parent());
            var selectPicValue = "";

            if ($("#div_userupload").is(":hidden")) {

                if ($('input:radio[name="radPic"]:checked').val() == undefined) {
                    //说明没有选中任意一个选项
                }
                else {
                    var val = $('input:radio[name="radPic"]:checked').val();
                    selectPicValue = val;
                }
            }
            else {
                selectPicValue = $("#txtImgUrl").val();
            }

            if ($.query.get("txt").length == 0) {

                //  $("#txtImgICO", W.document).val(selectPicValue);
            }
            else {
                $("#" + $.query.get("txt"), W.document).val(selectPicValue);
            }

            if ($.query.get("img").length > 0) {

                if (selectPicValue.indexOf("/") >= 0) {
                    $("#" + $.query.get("img"), W.document).attr("src", selectPicValue);
                } else {
                    $("#" + $.query.get("img"), W.document).hide();
                    $("#" + $.query.get("img") + "_Container", W.document).append("<span class=\"" + selectPicValue + "\"></span>");

                }
            }

            api.close();

        }
    </script>

    <script type="text/javascript">
        $(function () {
            imgLayout();
            $(window).resize(function () {
                imgLayout();
            });
            //图片延迟加载
            $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
        });
        //排列图文列表
        function imgLayout() {
            var imgWidth = $(".imglist").width();
            var lineCount = Math.floor(imgWidth / 222);
            var lineNum = imgWidth % 222 / (lineCount - 1);
            $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
            $(".imglist ul li").css("margin-right", parseFloat(lineNum));
        }
        //等比例缩放图片大小
        function AutoResizeImage(e, s) {
            var img = new Image();
            img.src = $(this).attr("src")
            var w = img.width;
            var h = img.height;
            var wRatio = w / h;
            if ((220 / wRatio) >= 165) {
                $(this).width(220); $(this).height(220 / wRatio);
            } else {
                $(this).width(165 * wRatio); $(this).height(165);
            }
        }
    </script>
    <style type="text/css">
        #div_piclist {
        margin-left:10px;
        
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="tab-content">
            <dl>
                <dt>选择：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlTemplates" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTemplates_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                </dd>
            </dl>
            <div id="div_piclist" runat="server" style="display: none;">
                <table>
                    <tr>
                        <td>
                            <ul class="picUl">

                                <!--图片列表-->
                                <asp:Repeater ID="rptList2" runat="server">
                                   
                                    <ItemTemplate>
                                        <li>
                                            <label for="rad<%#Eval("id")%>" class="picLabel">
                                                <table class="picTable">
                                                    <tr>
                                                        <td class="picTd">
                                                            <img src="<%#Eval("picUri")%>" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="chkTd" style="line-height:20px; ">
                                                            <input id="rad<%#Eval("id")%>" class="radPic" name="radPic" value="<%#Eval("picUri")%>" type="radio" />
                                                            <label><%#Eval("picName")%></label>
                                                        </td> 
                                                    </tr> 
                                                </table> 
                                            </label> 
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%#rptList2.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无记录</div>" : ""%>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <!--/图片列表-->
                                <%-- <asp:Literal ID="litPicStr" runat="server" EnableViewState="false"></asp:Literal>--%>
                            </ul>

                        </td>

                    </tr>

                </table>
                <!--内容底部-->
                <div class="line20"></div>
                <div class="pagelist">
                    <div class="l-btns">
                        <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
                    </div>
                    <div id="PageContent" runat="server" class="default"></div>
                </div>
                <!--/内容底部-->

            </div>
            <div class="div-content" id="div_userupload" runat="server">

                <dl>
                    <dt>上传：</dt>
                    <dd>


                        <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                        <div class="upload-box upload-img"></div>
                        <span class="Validform_checktip">
                            <br />
                            推荐宽300高300像素正方形图片，个别模版需要宽720高400像素图片</span>


                    </dd>
                </dl>


            </div>
        </div>
    </form>
</body>
</html>
