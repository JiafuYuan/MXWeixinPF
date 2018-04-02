<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="floorInfo.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.floorInfo" %>

<!DOCTYPE html>
<html>
<head>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">
    <meta content="application/xhtml+xml;charset=UTF-8" http-equiv="Content-Type">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <meta content="no-cache" http-equiv="pragma">
    <meta content="0" http-equiv="expires">
    <meta content="telephone=no, address=no" name="format-detection">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <title>房产11133333</title>
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/back.css">
    <script type="text/javascript" src="js/index.js"></script>
</head>
<body onselectstart="return true;" ondragstart="return false;">

    <div class="wrapper" id="container">
        <!-- start -->
        <div class="act_top" id="actTop" style="">
            <%--楼盘头部图片--%>
            <div class="act_top_show">
                <img src="<%=floor.fheadImg %>" width="720" height="175" id="bannerPic">
            </div>
        </div>
        <!--  end -->
        <!-- 楼盘简介 start -->
        <div class="box box_up">
            <!-- 收起时加上样式box_up,展开时去掉 -->
            <h3>楼盘简介</h3>
            <div class="box_time">
                <%=floor.fSummary %>
            </div>
            <a href="javascript:void(0);" onclick="Index.switchIndex(this);return false;" class="btn_more"><span>更多</span></a>
        </div>
        <!-- 楼盘简介 end -->
        <!-- 地图 start -->
        <div class="box">
            <h3>地图</h3>
            <div class="box_map">
                <div>
                    <a href="gywmMap.aspx?fid=<%=floor.Id %>">
                        
                        <img src="http://api.map.baidu.com/staticimage?width=600&height=235&center=&markers=|<%=floor.lngX %>,<%=floor.latY %>&zoom=10&markerStyles=s,A,0xff0000" style="max-height: 200px; width: 100%" /></a>
                </div>
                <p><%=floor.Address %></p>
            </div>
        </div>
        <!-- 地图 end -->

        <!-- 视频 start -->
        <!-- 视频 end -->

        <!-- 项目简介 start -->
        <div class="box box_up" >
            <h3>项目简介</h3>
            <div class="box_info">
                <%=floor.pSummary %>
            </div>
            <a href="javascript:void(0);" onclick="Index.switchIndex(this);return false;" class="btn_more"><span>更多</span></a>
        </div>
        <!-- 项目简介 end -->
        <!-- 交通配套 start -->
        <div class="box box_up" style="display: ">
            <h3>交通配套</h3>
            <div class="box_info">
                <%=floor.jtpt %>
            </div>
            <a href="javascript:void(0);" onclick="Index.switchIndex(this);return false;" class="btn_more"><span>更多</span></a>
        </div>
        <!-- 交通配套 end -->
    </div>
    <p>&nbsp;</p>
    <div class="pop_tips" id="popTips" style="display: none; top: 30%;">
        <div class="oval"></div>
        <div class="pop_show">
            <h4 id="tipsTitle">温馨提示</h4>
            <div class="pop_info" id="tipsMsg">
                <p></p>
            </div>
            <div class="pop_btns">
                <a href="javascript:void(0);" id="tipsOK">确定</a>
                <a href="javascript:void(0);" style="display: none;" id="tipsCancel">取消</a>
            </div>
        </div>
    </div>
    <div class="pop_mask" id="popMask" style="display: none;"></div>
    <a href="javascript:history.go(-1);" class="back360" style="">&nbsp;</a>
    <div mark="stat_code" style="width: 0px; height: 0px; display: none;"></div>
    <script type="text/javascript">
        window.shareData = {
            "moduleName": "Estate",
            "moduleID": "0",
            "imgUrl": "",
            "sendFriendLink": "http://42.96.196.48/index.php?g=Wap&m=Estate&a=introduce&token=agpkhy1417835915",
            "tTitle": "房产11133333",
            "tContent": " 换句话"
        };
    </script>
</body>
</html>
