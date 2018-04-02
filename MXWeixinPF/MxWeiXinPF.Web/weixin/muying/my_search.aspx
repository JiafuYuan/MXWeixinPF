<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_search.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.muying.my_search" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>体检信息
    </title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <link href="css/fans.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../scripts/bootstrap/datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery/jquery.query.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jquery/alert.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../scripts/bootstrap/datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"></script>
    <script type="text/javascript" src="js/main.js"></script>

    <style type="text/css">
        .InputType {
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            background-color: #FFFFFF;
            border: 1px solid #E8E8E8;
            margin: 5px 0 4px;
            padding: 5px 10px;
            line-height: 28px;
            padding-left: 50px;
            color: #666666;
        }
    </style>
</head>
<body id="news">
    <form name="form1" method="post"   id="form1">
         <div class="qiandaobanner">
            <a href="javascript:history.go(-1);">

                <asp:Image ID="zjpic" runat="server" ImageUrl="img/11.jpg" EnableViewState="false" />
            </a>
        </div>
        <div class="cardexplain">
            <ul class="round">
                
                
                <%--<li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>手机</th>
                            <td>
                                <input name="control_239" class="px" id="control_239" value="" type="text" placeholder="请输入手机">
                            </td>
                        </tr>
                    </table>
                </li>--%>

                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>姓名</th>
                            <td>
                                <input name="control_240" class="px" id="name" value="" type="text" placeholder="请输入姓名">
                            </td>
                        </tr>
                    </table>
                </li>

                <%--                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>预约时间</th>
                            <td>
                                <input name="control_241" class="px datetimepicker" id="control_241" value="" type="text" placeholder="请输入预约时间">
                            </td>
                        </tr>
                    </table>
                </li>

                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>qq</th>
                            <td>
                                <input name="control_242" class="px" id="control_242" value="" type="text" placeholder="请输入你的QQ">
                            </td>
                        </tr>
                    </table>
                </li>

                <li class="nob">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="kuang">
                        <tr>
                            <th>图片 </th>
                            <td>
                                <input id="picUpload" name="picUpload" type="file" accept="image/jpeg, image/jpg, image/png" onchange="my.changeImg(this, event, {base_url:'http://img.uweixin.cn/'});" /><br />
                                <img src='\images\noneimg.jpg' id="img_show" style="max-width: 100px; max-height: 80px;">
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </li>--%>
            </ul>
            <div class="footReturn">
                <a id="showcard" class="submit" href="javascript:void(0)">查 询</a>
                <div class="window" id="windowcenter">
                    <div id="title" class="wtitle">
                        保存成功<span class="close" id="alertclose"></span>
                    </div>
                    <div class="content">
                        <div id="txt">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#showcard").click(function () {
                    var name = $("#name").val();
                    if (name == '') {
                        alert('姓名不能为空');
                        return;
                    }
                    var submitData = {
                        name: name,
                        wid: <%=wid%>
                    };
                    $.post('muyingAPI.ashx?myact=search', submitData, function (data) {
                        if (data.sys == '0') {
                            window.location.href = 'my_result.aspx?id=' + data.content;
                        }
                        else {
                            alert(data.content);
                        }
                    }, "json");
                    //oLay.style.display = "block";
                });
            });
        </script>
    </form>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('.datetimepicker').datetimepicker({
        //        minView: "month", //选择日期后，不会再跳转去选择时分秒 
        //        format: "yyyy-mm-dd", //选择日期后，文本框显示的日期格式 
        //        language: 'zh-CN', //汉化 
        //        autoclose: true //选择日期后自动关闭 
        //    });
        //});
    </script>
</body>

</html>
