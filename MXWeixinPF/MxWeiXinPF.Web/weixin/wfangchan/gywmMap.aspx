<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gywmMap.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.wfangchan.gywmMap" %>

<!DOCTYPE HTML>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <title>上海沐雪网络科技有限公司</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
    <meta name="format-detection" content="telephone=no" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
</head>

<body>
    <script type="text/javascript" src="js/api?v=2.0&ak=908bb5a05fa5f839dafeb1a957c7ed51"></script>
    <div class="main">
        <div class="p_map">
            <div id="container"></div>
            <script type="text/javascript">
                $(function () {
                    var wh = $(window).height();
                    var bh = $('body').height();
                    var mh = $('#container').css('height');
                    mh = mh.replace('px', '');
                    oh = bh - wh;
                    nmh = mh - oh;
                    $('#container').css('height', nmh + 'px'); 
                    var sContent = function (id, name, imgsrc, address, tel) {
                        return "<h2 style='margin:0 0 7px 0;padding:0 0'>" + name + "</h2>" +
                        "<img style='float:right;margin:0px 0px 0px 4px' id='imgDemo' src='" + imgsrc + "' width='120' height='80' />" +
                        "<p style='padding-right:10px'>地址：" + '<%=address%>' + "</p>" +
                        (tel ? "<p style=''>电话：" + '<%=tel%>' + "</p>" : "") +
                        "" +
                        "</div>";
                    }
                    var storeList = [{ "id": "", "name": "<%=name%>", "logourl": "<%=logourl%>", "address": "<%=address%>", "tel": "<%=tel%>", "longitude": "<%=x%>", "latitude": "<%=y%>" }];
                    // 编写自定义函数,创建标注
                    function addMarker(point, content) {
                        var marker = new BMap.Marker(point);  // 创建标注
                        map.addOverlay(marker);
                        var infoWindow = new BMap.InfoWindow(content);
                        map.openInfoWindow(infoWindow, point); //开启信息窗口
                        marker.addEventListener("click", function () {
                            this.openInfoWindow(infoWindow);
                            //图片加载完毕重绘infowindow
                            document.getElementById('imgDemo').onload = function () {
                                infoWindow.redraw();
                            }
                        });
                    }
                    var map = new BMap.Map("container");
                    var point = new BMap.Point(<%=x%>,<%=y%>);
                    map.centerAndZoom(point, 13);
                    var user_marker = new BMap.Marker(point);  // 创建标注
                    map.addOverlay(user_marker);

                    for (var i = 0, l = storeList.length; i < l; i++) {
                        var point = new BMap.Point(storeList[i].longitude, storeList[i].latitude);
                        var content = sContent(storeList[i].id, storeList[i].name, storeList[i].logourl, storeList[i].address, storeList[i].tel);
                        addMarker(point, content);
                    }
                });
            </script>
        </div>
    </div>
</body>
</html>
