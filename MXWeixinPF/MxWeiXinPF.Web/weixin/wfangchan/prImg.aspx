﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prImg.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.prImg" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/qjtJs.js"></script>
    <title>房地产项目-仿七扇门</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <meta name="Keywords" content="房地产项目-仿七扇门" />
    <meta name="Description" content="就看见" />
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta content="no-cache" http-equiv="pragma">
    <meta content="0" http-equiv="expires">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <style>
        body, div, h1, h2, h3, span, p {
            font-family: Verdana,Arial,Helvetica,sans-serif;
            color: #000000;
        }
        /* fullscreen */
        html {
            height: 100%;
        }

        body {
            height: 100%;
            margin: 0px;
            overflow: hidden; /* disable scrollbars */
        }

        body {
            font-size: 10pt;
            background: #ffffff;
        }

        table, tr, td {
            font-size: 10pt;
            border-color: #777777;
            background: #dddddd;
            color: #000000;
            border-style: solid;
            border-width: 2px;
            padding: 5px;
            border-collapse: collapse;
        }

        h1 {
            font-size: 18pt;
        }

        h2 {
            font-size: 14pt;
        }

        .warning {
            font-weight: bold;
        }
        /* fix for scroll bars on webkit & Mac OS X Lion */
        ::-webkit-scrollbar {
            background-color: rgba(0,0,0,0.5);
            width: 0.75em;
        }

        ::-webkit-scrollbar-thumb {
            background-color: rgba(255,255,255,0.5);
        }

        a {
            text-decoration: none;
        }

        .view_change {
            position: fixed;
            z-index: 1000;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 42px;
            background-color: #262626;
            border: 1px solid #000000;
            box-shadow: 0 1px 0 rgba(255,255,255,0.2) inset;
            text-align: center;
        }

            .view_change a {
                line-height: 23px;
                display: block;
                font-size: 16px;
                color: #fefefe;
                line-height: 42px;
                text-shadow: 1px 2px 0 rgba(0,0,0,0.8);
            }

                .view_change a::before {
                    content: "";
                    display: inline-block;
                    width: 23px;
                    height: 23px;
                    line-height: 23px;
                    margin-right: 5px;
                    margin-top: -5px;
                    vertical-align: middle;
                    background: url(data:image/gif;base64,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);
                    background-size: auto 23px;
                    background-repeat: no-repeat;
                }

        .back360 {
            display: inline-block;
            width: 40px;
            height: 40px;
            position: fixed;
            bottom: 10px;
            left: 10px;
            z-index: 1000;
            background: red;
            border-radius: 60px;
            background: url('img/back.png') no-repeat center center;
            background-size: 100% 100%;
        }
    </style>
</head>
<body onselectstart="return true;" ondragstart="return false;">
    <div id="container" style="width: 100%; height: 100%;">
        This content requires HTML5/CSS3, WebGL, or Adobe Flash Player Version 9 or higher.
    </div>
    <script type="text/javascript">
        if (ggHasHtml5Css3D() || ggHasWebGL()) {
            pano = new pano2vrPlayer("container");
            skin = new pano2vrSkin(pano);
            pano.readConfigUrl('xmlstr.aspx?id=<%=id%>&wid=<%=wid%>&fid=<%=fid%>&openid=<%=openid%>');
        } else {
            alert("not support 360view");
        }
    </script>
    <noscript>
        <p><b>Please enable Javascript!</b></p>
    </noscript>
    <div class='view_change'>
        <a href='prImgView.aspx?id=<%=id %>&fid=<%=fid %>&wid=<%=wid %>&openid=<%=openid %>'><%=title %></a>
    </div>
    <a href="floorHtype.aspx?fid=<%=fid %>&wid=<%=wid %>&openid=<%=openid %>" class="back360" style="">&nbsp;</a>
    <div mark="stat_code" style="width: 0px; height: 0px; display: none;">
    </div>
</body>
</html>
