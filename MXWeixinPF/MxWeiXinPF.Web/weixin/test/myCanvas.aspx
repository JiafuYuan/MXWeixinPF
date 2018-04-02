<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myCanvas.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.test.myCanvas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">


        window.onload = function () {
            var canvas = document.getElementById("canvas");
            canvas.width = 800;
            canvas.height = 700;
            var cxt = canvas.getContext("2d");
            //cxt.fillStyle = "black";
            //cxt.fillRect(0,0,canvas.width,canvas.height);
            //for (var i = 0; i < 100; i++) {
            //    var r = Math.random() * 10 + 10;
            //    var R = r * 2;
            //    var x = Math.random() * canvas.width;
            //    var y = Math.random() * canvas.height;
            //    var v = Math.random() * 360;
            //    drawStar(cxt, x, y, r, R, v);
            //}

            //cxt.drawImage(
        }


        function drawStar(cxt, x, y, r, R, v) {
            cxt.lineWidth = 4;
            cxt.strokeStyle = "#fd3";
            cxt.fillStyle = "#fd5";
            cxt.beginPath();
            for (var i = 0; i < 5; i++) {
                cxt.lineTo(Math.cos((18 + i * 72 - v) / 180 * Math.PI) * R + x,
                    -Math.sin((18 + i * 72 - v) / 180 * Math.PI) * R + y);
                cxt.lineTo(Math.cos((54 + i * 72 - v) / 180 * Math.PI) * r + x,
                    -Math.sin((54 + i * 72 - v) / 180 * Math.PI) * r + y);
            }
            cxt.closePath();
            cxt.fill();
            cxt.stroke();

        }
      

    </script>
</head>
<body>
    <canvas id="canvas" style="border: 1px solid black;" />
    <div>
    </div>
</body>
</html>
