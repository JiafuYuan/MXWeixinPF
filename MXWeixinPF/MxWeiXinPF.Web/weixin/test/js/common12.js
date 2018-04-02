/*
 * 全站公共脚本,基于jquery-1.9.1脚本库
*/
$(function () {

    var page = 1;
    //初始加载分屏动画
    mySwiper = $("#mySwiper").swiper({
        mode: "vertical",
        loop: false,
        noSwiping: true,
        noSwipingNext: true,
        noSwipingPrev: true,
        onSlideChangeEnd: function () {
            if (page != mySwiper.activeIndex) {
                $(".up").hide();
                page = mySwiper.activeIndex;
                if (page == 1) {
                    remove();
                }
                var slide = $("#mySwiper .swiper-wrapper>.swiper-slide").eq(mySwiper.activeIndex);
                switch (mySwiper.activeIndex) {
                    case 0:
                        $(".up").show();
                        break;
                    case 1:
                        $(".up").show();
                        break;
                    case 2:
                        break;
                    case 4:
                        $(".up").show();
                        animate4(slide);
                        break;
                    case 5:
                        $(".up").show();
                        break;
                    case 6:
                        break;
                }
            }
        }
    })
    //设置html
    var html = new Array();
    for (i = 0; i < $("#mySwiper>.swiper-wrapper>.swiper-slide").length; i++) {
        html[i] = $("#mySwiper>.swiper-wrapper>.swiper-slide").eq(i).html();
    }
    //移除动画后的效果
    function remove() {
        $("#mySwiper>.swiper-wrapper>.swiper-slide:eq(" + mySwiper.previousIndex + ")").html(html[mySwiper.previousIndex]);
    }
    function isIos() {
        var userAgentInfo = navigator.userAgent;
        var Agents = new Array("iPhone", "iPad");
        var flag = false;
        for (var v = 0; v < Agents.length; v++) {
            if (userAgentInfo.indexOf(Agents[v]) > 0) { flag = true; break; }
        }
        return flag;
    }
    var fixedBug = isIos();
    var mp3;
    window.onload = function () {
        if (fixedBug == true) {
            mp3 = new Audio();
            mp3.src = $("#mp3").attr("src");
            mp3.loop = true;
            mp3.autoplay = true;
            $("#mp3").remove();
        }
        playmusic();
        $(".up").show();
    }
    function animate4(slide) {
        //舞台人物
        var manDiv = $("#page-10 .man");
        manDiv.css({ opacity: 1 });
        setTimeout(function () {
            manDiv.hide();
            setTimeout(function () {
                manDiv.show();
                setTimeout(function () {
                    manDiv.hide();
                    setTimeout(function () {
                        manDiv.show();
                        setTimeout(function () {
                            manDiv.hide();
                            setTimeout(function () {
                                manDiv.show();
                                setTimeout(function () {
                                    manDiv.hide();
                                    setTimeout(function () {
                                        manDiv.show();
                                    }, 100)
                                }, 100)
                            }, 100)
                        }, 100)
                    }, 100)
                }, 100)
            }, 100)
        }, 100)
    }
    //框架结构
    var height;
    var page = 1;//当前处于的页数
    var car;//小车偏移
    var plan;//飞机偏移
    var game;//游戏偏移
    var isGame = false;//是否正在进行游戏动画
    var gameHtml = $("#page-6 .game").html();
    var cloud;//云朵偏移
    var isCloud = false;//云朵是否正处于飘浮
    var cloudHtml = $("#cloud").html();
    var shadow;//建筑窗户偏移
    var isShadow = false;//建筑窗户是否正处于动画
    var cp;//唱片偏移
    var isCp = false;//唱片是否正处于动画
    var wifi;//wifi偏移
    var isWifi = false;//wifi是否正处于动画
    var scrollerOffset = $("#scroller").offset().top;
    function structure() {
        $("#scroller>div.page").each(function () {
            if (document.documentElement.clientHeight < 567) {
                if ($(this).attr("id") == "page-4") {
                    height = 544;
                }
                else if ($(this).attr("id") == "page-5") {
                    height = 634;
                }
                else if ($(this).attr("id") == "page-6") {
                    height = 444;
                }
                else {
                    height = 544;
                }
            }
            else {
                if ($(this).attr("id") == "page-4") {
                    height = 590;
                }
                else if ($(this).attr("id") == "page-5") {
                    height = 640;
                }
                else if ($(this).attr("id") == "page-6") {
                    height = 480;
                }
                else if ($(this).attr("id") == "page-7") {
                    height = 600;
                }
                else if ($(this).attr("id") == "page-8") {
                    height = 600;
                }
                else {
                    height = 590;
                }
            }
            $(this).height(height);
        })
        car = $("#page-5 .car").offset().top + $("#page-5 .car").height() - height - scrollerOffset;
        plan = $("#page-5 .plan").offset().top + $("#page-5 .plan").height() - height - scrollerOffset;
        game = $("#page-6 .game").offset().top + $("#page-6 .game").height() - height - scrollerOffset;
        cloud = $("#page-7 .cloud-2").offset().top + $("#page-7 .cloud-2").height() - height - scrollerOffset;
        shadow = $("#page-7 .shadow").offset().top + $("#page-7 .shadow").height() - height - scrollerOffset;
        cp = $("#page-8 .cp").offset().top + $("#page-8 .cp").height() - height - scrollerOffset;
        wifi = $("#page-9 .wifi").offset().top + $("#page-9 .wifi").height() - height - scrollerOffset;
        man = $("#page-10 .man").offset().top + $("#page-10 .man").height() - height - scrollerOffset;
    }
    structure();
    //滚动
    myScroll = new IScroll("#wrapper", { probeType: 3, scrollX: false, freeScroll: true, checkDOMChanges: true, bounce: false, scrollbars: true, scrollbars: 'custom' });
    document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
    myScroll.on("scroll", onscrolls);
    myScroll.on("scrollEnd", onscrolls);
    function onscrolls() {
        //重复函数
        var offset = -this.y;
        var slide = $("#wrapper").parent();
        if (offset == 0) {
            slide.removeClass("swiper-no-prev");
        }
        else {
            slide.addClass("swiper-no-prev");
        }
        if (this.y == this.maxScrollY) {
            slide.removeClass("swiper-no-next");
            $(".up").show();
        }
        else {
            slide.addClass("swiper-no-next");
            $(".up").hide();
        }
        //汽车
        if (offset >= car && (offset - car) / 2 <= 225) {
            $("#page-5 .car").transition({ y: (offset - car) / 2 }, 1);
        }
        //飞机
        if (offset >= plan && (offset - plan) / 2 <= 170) {
            $("#page-5 .plan").transition({ x: (offset - plan), y: "-" + (offset - plan) / 2 }, 1);
        }
        //游戏
        if (offset >= game && offset <= game + height) {
            if (isGame == false) {
                gameStart();
            }
            isGame = true;
        }
        else {
            if (isGame) {
                $("#page-6 .game").html(gameHtml);
                isGame = false;
            }
        }
        //云朵
        if (offset >= cloud && offset <= cloud + height) {
            if (isCloud == false) {
                $("#cloud>div").addClass("layer");
                var scene = $("body")[0];
                var parallax = new Parallax(scene);
            }
            isCloud = true;
        }
        else {
            if (isCloud) {
                $("#cloud").html(cloudHtml);
                isCloud = false;
            }
        }
        //建筑窗户
        if (offset >= shadow && offset <= shadow + height) {
            if (isShadow == false) {
                windows();
            }
            isShadow = true;
        }
        else {
            if (isShadow) {
                clearInterval(windowAuto);
                isShadow = false;
            }
        }
        //唱片
        if (offset >= cp && offset <= cp + height) {
            if (isCp == false) {
                $(".cp-rotate").addClass("cp-rotate-animate");
                changpian();
            }
            isCp = true;
        }
        else {
            if (isCp) {
                $(".cp-rotate").removeClass("cp-rotate-animate");
                clearInterval(changpianAuto);
                $("#page-8 ul li").removeAttr("style");
                isCp = false;
            }
        }
        //wifi
        if (offset >= wifi && offset <= wifi + height) {
            if (isWifi == false) {
                wifis();
            }
            isWifi = true;
        }
        else {
            if (isWifi) {
                clearInterval(wifiAuto);
                clearInterval(xinhaoAuto);
                clearInterval(sAuto);
                isWifi = false;
            }
        }
    }
    //具体函数
    //游戏
    function gameStart() {
        $("#page-6 .eat-author").transition({
            x: 162, complete: function () {
                $(this).next().find("li:eq(1)").transition({ width: 17 }, 200, "linear");
                $(this).css({ rotate: 90 }).transition({
                    y: 18, complete: function () {
                        $(this).next().find("li:eq(1)").transition({ width: 179 }, 1600, "linear");
                        $(this).css({ rotate: 180 }).transition({
                            x: 0, complete: function () {
                                $(this).next().find("li:eq(2)").transition({ width: 17 }, 200, "linear");
                                $(this).css({ rotate: 90 }).transition({
                                    y: 36, complete: function () {
                                        $(this).next().find("li:eq(2)").transition({ width: 179 }, 1600, "linear");
                                        $(this).css({ rotate: 0 }).transition({
                                            x: 162, complete: function () {
                                                $(this).next().find("li:eq(3)").transition({ width: 17 }, 200, "linear");
                                                $(this).css({ rotate: 90 }).transition({
                                                    y: 54, complete: function () {
                                                        $(this).next().find("li:eq(3)").transition({ width: 179 }, 1600, "linear");
                                                        $(this).css({ rotate: 180 }).transition({
                                                            x: 0, complete: function () {
                                                                $(this).next().find("li:eq(4)").transition({ width: 17 }, 200, "linear");
                                                                $(this).css({ rotate: 90 }).transition({
                                                                    y: 72, complete: function () {
                                                                        $(this).next().find("li:eq(4)").transition({ width: 110 }, 1000, "linear");
                                                                        $(this).css({ rotate: 0 }).transition({
                                                                            x: 100, complete: function () {
                                                                                $(this).hide().next().next().css("visibility", "visible");
                                                                                var over = $(this).next().next();
                                                                                setTimeout(function () {
                                                                                    over.hide();
                                                                                    setTimeout(function () {
                                                                                        over.show();
                                                                                    }, 100)
                                                                                }, 100)
                                                                            }
                                                                        }, 1000, "linear")
                                                                    }
                                                                }, 200, "linear");
                                                            }
                                                        }, 1600, "linear")
                                                    }
                                                }, 200, "linear");
                                            }
                                        }, 1600, "linear")
                                    }
                                }, 200, "linear");
                            }
                        }, 1600, "linear")
                    }
                }, 200, "linear");
            }
        }, 1600, "linear")
        $("#page-6 .game li:first").transition({ width: 179 }, 1600, "linear");
    }
    //窗户闪烁
    var windowsLength = $(".shadow li").length;
    function whichwindow() { return parseInt(Math.random() * windowsLength) }//哪个窗户
    function windows() {
        windowAuto = setInterval(function () {
            var li = $(".shadow li").eq(whichwindow());
            li.hide();
            setTimeout(function () {
                li.show();
            }, 500)
        }, 100)
    }
    //音乐图标飞出
    function changpian() {
        var index = 0;
        changpianAuto = setInterval(function () {
            var li = $("#page-8 ul li").eq(index);
            var x, y;
            switch (li.index()) {
                case 0:
                    x = -117;
                    y = -55;
                    break;
                case 1:
                    x = -125;
                    y = 18;
                    break;
                case 2:
                    x = -113;
                    y = 114;
                    break;
                case 3:
                    x = 18;
                    y = -125;
                    break;
                case 4:
                    x = 85;
                    y = -95;
                    break;
                case 5:
                    x = 117;
                    y = -35;
                    break;
                case 6:
                    x = 132;
                    y = 26;
                    break;
                case 7:
                    x = 86;
                    y = 108;
                    break;
            }
            li.css({ x: 0, y: 0, rotate: 0, opacity: 0 }).transition({ x: x, y: y, opacity: 1 }, 1600)
            index++;
            if (index == 8) {
                clearInterval(changpianAuto);
            }
        }, 800)
    }
    //wifi
    function wifis() {
        var wifiDiv = $("#page-9 .wifi");
        var wifiPosition = -38;
        wifiAuto = setInterval(function () {
            wifiDiv.css({ backgroundPosition: "left " + wifiPosition + "px" });
            wifiPosition += -38;
            if (wifiPosition == -114) {
                wifiPosition = 0;
            }
        }, 500)
        var xinhaoDiv = $("#page-9 .xinhao");
        var xinhaoPosition = -16;
        xinhaoAuto = setInterval(function () {
            xinhaoDiv.css({ backgroundPosition: "left " + xinhaoPosition + "px" });
            xinhaoPosition += -16;
            if (xinhaoPosition == -48) {
                xinhaoPosition = 0;
            }
        }, 500)
        var s = 1;
        sAuto = setInterval(function () {
            var sDiv = $("#page-9 .s-" + s + "");
            sDiv.hide();
            setTimeout(function () {
                sDiv.show();
                switch (s) {
                    case 1:
                        s = 2;
                        break;
                    case 2:
                        s = 1;
                        break;
                }
            }, 1000)
        }, 2000)
    }
    $(document).on("tap", ".huan-button", function () {
        setTimeout(function () {
            mySwiper.swipeNext();
        }, 100)
    })

    //音乐
    $(".music").on("tap", function () {
        if ($(this).hasClass("play")) {
            $(this).removeClass("play");
            $("#music>span").addClass("zshow").html("关闭");
            setTimeout(function () { $("#music>span").removeClass("zshow") }, 1000);
            if (fixedBug == true) {
                mp3.pause();
            }
            else {
                document.getElementById("mp3").pause();
            }
        }
        else {
            $(this).addClass("play");
            $("#music>span").addClass("zshow").html("开启");
            setTimeout(function () { $("#music>span").removeClass("zshow") }, 1000);
            if (fixedBug == true) {
                mp3.play();
            }
            else {
                document.getElementById("mp3").play();
            }
        }
    })
    function playmusic() {
        $(".music").addClass("play");
        if (fixedBug == true) {
            mp3.play();
        }
        else {
            document.getElementById("mp3").play();
        }
    }
    $(document).on("tap", ".go-form", function () {
        $("#mySwiper").transition({ opacity: 0, scale: 5 }, 800);
        $(".form").css({ "visibility": "visible", opacity: 0, scale: 5 }).transition({ scale: 1, opacity: 1 }, 800);
    })
    //结果页
    $(document).on("submit", "form", function () {
        if ($("#name").val() == "") {
            $("#name").focus();
            return false;
        }
        if ($("#tel").val() == "") {
            $("#tel").focus();
            return false;
        }
        if ($("#mail").val() == "") {
            $("#mail").focus();
            return false;
        }
        if ($("#company").val() == "") {
            $("#company").focus();
            return false;
        }
        if ($("#position").val() == "") {
            $("#position").focus();
            return false;
        }
        $.ajax({
            type: "post",
            url: $("#form_ajax_url").text(),
            dataType: "json",
            data: { name: $("#name").val(), mobile: $("#tel").val(), email: $("#mail").val(), company: $("#company").val(), job: $("#position").val() },
            async: false,
            success: function (data) {
                //$(".form").transition({scale:5,opacity:0},800);
                //$(".result").css({"visibility":"visible"}).css({scale:5,opacity:0}).transition({scale:1,opacity:1},800);
                $(".form").transition({
                    scale: 5, opacity: 0, complete: function () {
                        $(this).hide();
                    }
                }, 800);
                $(".result").css({ "visibility": "visible" }).css({ scale: 5, opacity: 0 }).transition({ scale: 1, opacity: 1 }, 800);
            }
        });
        return false
    })
    var share = false;
    $(document).on("tap click", ".gets", function (event) {
        if (share == false) {
            $(".share").css({ "visibility": "visible" }).show();
            event.stopPropagation();
            event.preventDefault();
            return false;
        }
    })
    $(document).on("touchstart", ".share", function (event) {
        event.stopPropagation();
        event.preventDefault();
        $(".share").hide();
    })

    //刮刮卡
    var hasTouch = 'ontouchstart' in window;
    var canvas;
    var ctx;
    var color = "#fff";
    var lines = [];
    var points = [];
    $(document).ready(function () {
        var offset = $("#canvas").offset();
        var canvas_left = offset.left;
        var canvas_top = offset.top;
        $("#canvas").addClass("canvasover");
        canvas = document.getElementById('canvas');
        var width = canvas.width;
        var height = canvas.height;
        ctx = canvas.getContext('2d');
        // 使用“gray”颜色对canvas画布进行“矩形”填充。  
        ctx.fillStyle = '#9f9f9f';
        roundRect(ctx, 0, 0, width, height, 5, true, false);
        function roundRect(ctx, x, y, width, height, radius, fill, stroke) {
            if (typeof stroke == "undefined") {
                stroke = true;
            }
            if (typeof radius === "undefined") {
                radius = 5;
            }
            ctx.beginPath();
            ctx.moveTo(x + radius, y);
            ctx.lineTo(x + width - radius, y);
            ctx.quadraticCurveTo(x + width, y, x + width, y + radius);
            ctx.lineTo(x + width, y + height - radius);
            ctx.quadraticCurveTo(x + width, y + height, x + width - radius, y + height);
            ctx.lineTo(x + radius, y + height);
            ctx.quadraticCurveTo(x, y + height, x, y + height - radius);
            ctx.lineTo(x, y + radius);
            ctx.quadraticCurveTo(x, y, x + radius, y);
            ctx.closePath();
            if (stroke) {
                ctx.stroke();
            }
            if (fill) {
                ctx.fill();
            }
        }
        ctx.fillStyle = '#fff';
        ctx.font = "15px Georgia";
        ctx.fillText("刮一发放松一下", 98, 68);
        ctx.fillText("还有意外惊喜噢", 98, 90);
        if (fixedBug == false) {
            canvas.style.display = 'none';
            canvas.offsetHeight;
            canvas.style.display = 'inherit';
        }
        ctx.stroke();
        ctx.closePath();
        //移动
        var START_EV = hasTouch ? 'touchstart' : 'mousedown';
        var MOVE_EV = hasTouch ? 'touchmove' : 'mousemove';
        var END_EV = hasTouch ? 'touchend' : 'mouseup';
        document.getElementById("canvas").addEventListener(START_EV, touchCheck, false);
        document.getElementById("canvas").addEventListener(MOVE_EV, touchCheck, false);
        document.getElementById("canvas").addEventListener(END_EV, touchCheck, false);
        var startTouch;
        var isDrag = false;
        var lastPoint;

        function touchCheck(evt) {
            evt.preventDefault();
            var touchX;
            var touchY;
            if (hasTouch) {
                if (evt.touches.length > 0) {
                    touchX = evt.touches[0].pageX - canvas_left;
                    touchY = evt.touches[0].pageY - canvas_top;
                }
                else {
                    if (lastPoint) {
                        touchX = lastPoint.x;
                        touchY = lastPoint.y;
                    }
                }
            }
            else {
                touchX = evt.pageX - canvas_left;
                touchY = evt.pageY - canvas_top;
            }

            switch (evt.type) {
                case START_EV:
                    evt.stopPropagation();
                    DrawLine();
                    points = [];
                    points.push({ x: touchX, y: touchY });
                    isDrag = true;
                    lastPoint = { x: touchX, y: touchY };

                    break;
                case MOVE_EV:
                    if (isDrag) {
                        points.push({ x: touchX, y: touchY });
                        lastPoint = { x: touchX, y: touchY };
                        DrawLine();
                    }
                    break;
                case END_EV:
                    isDrag = false;
                    if (points.length > 0) {
                        points.push({ x: touchX, y: touchY });
                        lines.push(points);
                        DrawLine();
                    }
                    var data = ctx.getImageData(0, 10, width, height).data;
                    for (var i = 0, j = 0; i < data.length; i += 4) {
                        if (data[i] && data[i + 1] && data[i + 2] && data[i + 3]) {
                            j++;
                        }
                    }
                    if (j <= width * height * 0.35) {
                        ctx.clearRect(0, 0, width, height);
                    }
                    break;
            }
        }
        function DrawSingleLine(ctx, line) {
            for (var j = 0; j < line.length; j++) {
                var point = line[j];
                if (j == 0)
                    ctx.moveTo(point.x, point.y);
                else
                    ctx.lineTo(point.x, point.y);
            }
        }
        function DrawLine() {
            ctx.globalCompositeOperation = "destination-out";
            ctx.beginPath();
            ctx.strokeStyle = color;
            ctx.lineWidth = 10;
            var tempLines = lines;
            if (tempLines.length == 0) {
                tempLines.push(points);
            }
            for (var i = 0; i < tempLines.length; i++) {
                var line = tempLines[i];
                DrawSingleLine(ctx, line);
            }
            if (isDrag && points.length > 0) {
                DrawSingleLine(ctx, points);
            }
            if (fixedBug == false) {
                canvas.style.display = 'none';
                canvas.offsetHeight;
                canvas.style.display = 'inherit';
            }
            ctx.stroke();
            ctx.closePath();
        }
    });
    $(document).one("touchstart", "body", function () {
        playmusic();
    })
})