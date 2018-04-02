<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.vote.index" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>微投票</title>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <link href="css/vote(for_vt).css" rel="stylesheet" type="text/css">
    <script src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
    <script src="../../scripts/jquery/jquery.query.js"></script>
    <script src="../../scripts/jquery/alert.js"></script>
    <style>
</style>
</head>

<body id="vote-text">
    <script src="js/audio.min.js" type="text/javascript"></script>
    <script>
        audiojs.events.ready(function () {
            audiojs.createAll();
        });
    </script>
    <div class="vote">
        <form class="form" target="_top" runat="server" enctype="multipart/form-data">
            <div class="votecontent">
                <h2><%=baseinfo.title %></h2>
                <span class="date"><%=baseinfo.creatDate.Value.ToString("yyyy-MM-dd") %></span>
                <p class="content" id="content"><%=baseinfo.votecontent %></p>

                <script src="js/play.js" type="text/javascript"></script>
                <p class="modus">单选投票，<span class="number">共有<%=toupNum %>参与投票</span></p>
                <ul class="list" id="list">
                    <asp:Literal ID="litChooes" runat="server"></asp:Literal>
                    <asp:Literal ID="litMessageList" runat="server" EnableViewState="false"></asp:Literal>
                </ul> 
                <asp:Literal ID="litSubmitBtn" runat="server" EnableViewState="false"></asp:Literal>
                <input class="pxbtn" name="button" runat="server" type="button" id="btnSubmit" value="确认提交">
            </div>
        </form>
        <div class="copyright" style="text-align: center; color: #fff;">© 2001-2014 <a href="http://www.wxapi.cn/" style="color: #cccccc">乐享微信版权所有</a></div>
    </div> 
</body>
</html>
<script>
    $(document).ready(function () {
        $(".ckbx").click(function () {
            var i = 0;
            var aa = document.getElementsByName('id[]');
            var mnum = aa.length;
            j = 0;
            for (i = 0; i < mnum; i++) {
                if (aa[i].checked) {
                    j++;
                }
            }
            if (j > 2) {

                $(this).attr("checked", false);

            }
        });
    });
    $(document).ready(function () {

        var isradio = $('input:radio[class="ckbx"]:checked').val();

        $("#btnSubmit").click(function () {
            var wid = $.query.get("wid");
            var openid = $.query.get("openid");
            var aid = $.query.get("aid");
            var selectItemid = "";

            if (isradio == "true") {
                var list = $('input:radio[class="ckbx"]:checked').val();

                if (list == null) {
                    alert("请选中一个!");
                    return false;
                }
                else {
                    selectItemid = list;
                }
            }
            else {
                $('input[class="ckbx"]:checked').each(function () {
                    selectItemid += $(this).val() + ',';
                });
                if (selectItemid == "") {
                    alert("请选中一个!");
                    return;
                }
                if (selectItemid.length > 0) {
                    selectItemid = selectItemid.substring(0, selectItemid.length - 1);
                }
            }
            var submitData = {
                wid: wid,
                openid: openid,
                baseid: aid,
                itemid: selectItemid,
                isradio: isradio,
                myact: "commit"
            }; 
            $.post('vote.ashx', submitData,
         function (data) {
             if (data.ret == "ok") {
                 alert(data.content);
                 window.location.href = location.href;
             } else { alert(data.content); }
         },
         "json")
        });
    });
    </script>
