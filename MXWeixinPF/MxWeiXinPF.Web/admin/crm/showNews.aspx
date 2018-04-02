<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showNews.aspx.cs" Inherits="MxWeiXinPF.Web.admin.crm.showNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        
    </script>
    <style type="text/css">
        p {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;">
            <p>
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Image ID="imgPic" runat="server" style="max-height:300px;max-width:550px;" /></p>
            <p style="text-align:center;margin:auto 0px; font-size:13px; color:#808080;">
                <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label></p>
        </div>
    </form>
</body>
</html>
