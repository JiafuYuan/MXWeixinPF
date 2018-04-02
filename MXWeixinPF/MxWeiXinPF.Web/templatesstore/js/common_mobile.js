$(document).ready(function(){
	//分辨率适应
	$(window).resize(function(){
		$(".submitBox .btn").width($(window).width()*0.42-15);
		var wheight = $(window).height()-113+"px";
		$("#wrap").css("min-height",wheight);
	}).resize();
	
	//按钮点击
	$('.meun span,.btn,a').on('touchstart',function(){
		$(this).addClass('hover');
	}).on('touchend',function(){
		$(this).removeClass('hover');
	});	
	
	//侧栏菜单
	$(".option").height($(window).height()-47);
	$(".option table").width($(window).width()-60);
	$(".option tr td a").css("padding",(($(window).height()-47)/4-79)/2+"px 0");
	var flagC = true;
	$(".iconMeun").click(function(e) {
		if(flagC){
			$(".option").animate({marginLeft:0},"slow");
			flagC = false;
		}
		else{
			$(".option").animate({marginLeft:"100%"},"slow");
			flagC = true;
		}
		$(".iconMeun").toggleClass("hover");
	});
	$(".option .close").click(function(e) {
		$(".option").animate({marginLeft:"100%"},"slow");
		flagC = true;
		$(".iconMeun").toggleClass("hover");
	});
	
	//查看更多loading
	$('.btnMore').click(function(){
		$('#loading').fadeIn();
	});
	
	//在线咨询
	$('.btnConsult').click(function(){
		$('#Information').fadeIn();
	});
	$('.close').click(function(){
		$('.pop').fadeOut();
	});
	
	//video全屏播放
	$('.video').click(function(){
		$('video')[0].play();
		$('video')[0].webkitEnterFullscreen();
	});
	document.onwebkitfullscreenchange=function(){
		if(!document.webkitFullscreenElement){
			$('video')[0].pause();
		}
    };
	
	//banner滑动 Swipe
	$("#banner").width($(window).width());
	$("#banner img").width($(window).width()-14);
	$("#banner").height(($(window).width()-14)/57*33+10);
	window.mySwipe = new Swipe($('#banner')[0],{
		auto:3000,
		callback:function(index, element){
			$('.bannerNum span').removeClass('now').eq(index%$('.bannerNum span').size()).addClass('now');
		}
	});
	$('.bannerNum span:eq(0)').addClass('now');
	
	//首页菜单滑动 Swipe
	window.mySwipe = new Swipe($('#swipe')[0],{
		continuous:false,
		callback:function(index, element){
			$('.swipeNum li').removeClass('now').eq(index).addClass('now');
		}
	});
	$('#swipe section').each(function(){
		$('.swipeNum').append('<li></li>');
	});
	$('.swipeNum li:eq(0)').addClass('now');
	
});