<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pic_show.aspx.cs" Inherits="MxWeiXinPF.Web.weixin.qiangpiao.pic_show" %>

<!doctype html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="initial-scale=1">
    <title>Swiper Gallery App</title>

    <link rel="stylesheet" href="css/idangerous.swiper.css">
    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/gallery-app.css">
</head>
<body>
    <div class="swiper-container">
        <div class="pagination"></div>
        <div class="swiper-wrapper" style="width: 2424px;">
            <asp:Repeater ID="rptImgshow" runat="server">
                <ItemTemplate>
                    <div class="swiper-slide">
                        <div class="inner">
                            <img src="<%#Eval("imgPic") %>" alt="">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


    <script src="js/jquery.min.js"></script>
    <!-- Don't forget to get the latest Swiper and scrollbar version here-->
    <script src="js/idangerous.swiper-2.0.min.js"></script>

    
    <script type="text/javascript">
        $(function () {
            var gallery = $('.swiper-container').swiper({
                slidesPerView: 'auto',
                watchActiveIndex: true,
                centeredSlides: true,
                pagination: '.pagination',
                paginationClickable: true,
                resizeReInit: true,
                keyboardControl: true,
                grabCursor: true,
                initialSlide: 1,
                onImagesReady: function () {
                    changeSize()
                }



            })
            function changeSize() {
                //Unset Width
                $('.swiper-slide').css('width', '')
                //Get Size
                var imgWidth = $('.swiper-slide img').width();
                if (imgWidth + 40 > $(window).width()) imgWidth = $(window).width() - 40;
                //Set Width
                $('.swiper-slide').css('width', imgWidth + 40);
            }

            changeSize()

            //Smart resize
            $(window).resize(function () {
                changeSize()
                gallery.resizeFix(true)

            })

            gallery.swipeTo(<%=actNum%>, 750, 'true')
        })

    </script>

</body>
</html>
