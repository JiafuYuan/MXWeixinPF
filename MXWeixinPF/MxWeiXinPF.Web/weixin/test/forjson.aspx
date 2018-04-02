<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forjson.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.test.forjson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">


    <title></title>
    <script src="../../scripts/jquery/jquery-2.1.0.min.js"></script>
    <script type="text/javascript">
        $(function () {

            //Html5新特性localStorage
            //var userData = {
            //    user: "xiaoer",
            //    age: 15,
            //    happy: "basketball"
            //};
            //localStorage.setItem("name", JSON.stringify(userData));
            //alert(localStorage.getItem("name"));

            //判断是否在线
            //alert(window.navigator.onLine);

            //获得地理位置
            //window.navigator.geolocation.getCurrentPosition(function (pos) {
            //    alert("当前位置的纬度：" + pos.coords.latitude);
            //    alert("当前位置的经度：" + pos.coords.longitude);
            //    alert("时间戳：" + pos.timestamp);
            //});


            //离线缓存技术
            //applicationCache.CHECKING();

        })
        

 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input name="teleName" id="Text1" value="" placeholde="请输入内容" type="text" required />
        <input name="teleName" id="txttelephone" value="" placeholde="请输入内容" type="search" />
        <input type="submit" value="提交" />
    </form>
</body>
</html>
