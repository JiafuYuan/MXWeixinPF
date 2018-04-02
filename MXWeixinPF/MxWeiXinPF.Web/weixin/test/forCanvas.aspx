<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forCanvas.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.test.forCanvas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body> 
     <canvas id="canvas" style="border:1px solid #aaa; margin:5px auto; display:block;">
         当前浏览器不支持canvas,换其他浏览器试一下吧
     </canvas>
    <script type="text/javascript">
        window.onload = function () {
            var canvas = document.getElementById("canvas");

            canvas.width =900;
            canvas.height = 600;

            var context = canvas.getContext("2d");
            context.beginPath();
            context.moveTo(100, 200);
            context.lineTo(200, 300); 
            context.lineTo(100, 400);
            context.lineWidth = 7;
            context.strokeStyle = "yellow";
            context.stroke();

            context.beginPath();
            context.moveTo(300, 200);
            context.lineTo(400, 300);
            context.lineTo(300, 400);
            context.lineWidth = 7;
            context.strokeStyle = "red";
            context.stroke();

            context.beginPath();
            context.moveTo(500, 200);
            context.lineTo(600, 300);
            context.lineTo(500, 400);
            context.lineWidth = 7;
            context.strokeStyle = "green";
            context.stroke();

            
            
        }
    </script>
    
</body>
</html>
