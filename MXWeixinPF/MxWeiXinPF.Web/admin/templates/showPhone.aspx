<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showPhone.aspx.cs" Inherits="MxWeiXinPF.Web.admin.templates.showPhone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #back {
            width: 380px;
            height: 580px;
            background-image: url(images/phoneBack.png);
            background-repeat: no-repeat;
        }

        #onShow {
            width: 320px;
            height: 410px;
            margin-top: 97px;
             margin-left:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="back">
            <div class="header">

            </div>
            <iframe frameborder="0" id="onShow" src="/index.aspx?wid=<%=wid %>"></iframe>
            <div class="bottom">

            </div>
        </div>
    </form>
</body>
</html>
