$(document).ready(function(){    
	//panel面板
	$('#panel').panel({
		contentWrap: $('#cont'),
		swipeClose:false
	});
	//打开面板
	$('#filterBtn').on(DOEVENT, function () {
		//$('#panel').show();
		$('#panel').panel('toggle', 'push', 'right');
	});
	//选项卡切换 
	$(".sxtc_title li").each(function (i) {
		$(this).on(DOEVENT,function () {
			$(".sxtc_title li").removeClass("cur");
			$(this).addClass("cur");
		   $(".sxtc_content .xx_tab").eq(i).show().siblings().hide();
		})
	});
	
	
	//条件筛选        
	$(".sxtc_list .categ").on(DOEVENT, 
		function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else
			{
				$(".sxtc_list").find(".lb_nr").hide();
				$(".sxtc_list .categ").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	//地区配送选项 
	$(".xzdq_bottom .area").on(DOEVENT,function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else {
				$(".xzdq_bottom").find(".lb_nr").hide();
				$(".xzdq_bottom .area").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	
	
});
function func_jiege_dizhi_tab(){
	//获得商品价格被选中的
	var pre_num = $("#pro_pre li").length;
	for(var i = 1 ; i<=pre_num ; i++){
		if($("#pro_pre li:nth-child("+i+") a").hasClass("xz")){
			var pro_pre = $("#pro_pre li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	
	//获得配送地址被选中的
	var dizhi_num = $("#dizhi_xz ul").length;
	for(var j = 1 ;j <= dizhi_num; j++){
		var dizhi_num2 = $("#dizhi_xz li:nth-child("+j+") li").length;
		for(var i = 1 ; i<=dizhi_num2 ; i++){
			if($("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+") a").hasClass("xz")){
				var dizhi_xz = $("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+")").children("a").attr("value");
			}
			
		}
	}
	//获得tab条件
	var tab_num = $("#tab_tiaoj li").length-1;
	for(var i = 1 ; i<=tab_num ; i++){
		if($("#tab_tiaoj li:nth-child("+i+") a").hasClass("on")){
			var pro_tab = $("#tab_tiaoj li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	var arrtest = new Array();
	arrtest[0] = pro_pre;
	arrtest[1] = dizhi_xz;
	arrtest[2] = pro_tab;
	return arrtest;
}
function funLeiX(id_array){
	
	var zong_xuan = new Array();
	for(var j = 0 ;j < id_array.length ; j++){
		var lei_num = $("#"+id_array[j]+" li").length;
		for(var i = 1 ; i<=lei_num ; i++){
			if($("#"+id_array[j]+" li:nth-child("+i+") a").hasClass("xz")){
				zong_xuan[j] = $("#"+id_array[j]+" li:nth-child("+i+")").children("a").attr("value");	
			}
			
		}
	}
	return zong_xuan;
}$(document).ready(function(){    
	//panel面板
	$('#panel').panel({
		contentWrap: $('#cont'),
		//swipeClose:false
	});
	//打开面板
	$('#filterBtn').on(DOEVENT, function () {
		//$('#panel').show();
		$('#panel').panel('toggle', 'push', 'right');
	});
	//选项卡切换 
	$(".sxtc_title li").each(function (i) {
		$(this).on(DOEVENT,function () {
			$(".sxtc_title li").removeClass("cur");
			$(this).addClass("cur");
		   $(".sxtc_content .xx_tab").eq(i).show().siblings().hide();
		})
	});
	
	
	//条件筛选        
	$(".sxtc_list .categ").on(DOEVENT, 
		function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else
			{
				$(".sxtc_list").find(".lb_nr").hide();
				$(".sxtc_list .categ").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	//地区配送选项 
	$(".xzdq_bottom .area").on(DOEVENT,function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else {
				$(".xzdq_bottom").find(".lb_nr").hide();
				$(".xzdq_bottom .area").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	
	
});
function func_jiege_dizhi_tab(){
	//获得商品价格被选中的
	var pre_num = $("#pro_pre li").length;
	for(var i = 1 ; i<=pre_num ; i++){
		if($("#pro_pre li:nth-child("+i+") a").hasClass("xz")){
			var pro_pre = $("#pro_pre li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	
	//获得配送地址被选中的
	var dizhi_num = $("#dizhi_xz ul").length;
	for(var j = 1 ;j <= dizhi_num; j++){
		var dizhi_num2 = $("#dizhi_xz li:nth-child("+j+") li").length;
		for(var i = 1 ; i<=dizhi_num2 ; i++){
			if($("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+") a").hasClass("xz")){
				var dizhi_xz = $("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+")").children("a").attr("value");
			}
			
		}
	}
	//获得tab条件
	var tab_num = $("#tab_tiaoj li").length-1;
	for(var i = 1 ; i<=tab_num ; i++){
		if($("#tab_tiaoj li:nth-child("+i+") a").hasClass("on")){
			var pro_tab = $("#tab_tiaoj li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	var arrtest = new Array();
	arrtest[0] = pro_pre;
	arrtest[1] = dizhi_xz;
	arrtest[2] = pro_tab;
	return arrtest;
}
function funLeiX(id_array){
	
	var zong_xuan = new Array();
	for(var j = 0 ;j < id_array.length ; j++){
		var lei_num = $("#"+id_array[j]+" li").length;
		for(var i = 1 ; i<=lei_num ; i++){
			if($("#"+id_array[j]+" li:nth-child("+i+") a").hasClass("xz")){
				zong_xuan[j] = $("#"+id_array[j]+" li:nth-child("+i+")").children("a").attr("value");	
			}
			
		}
	}
	return zong_xuan;
}$(document).ready(function(){    
	//panel面板
	$('#panel').panel({
		contentWrap: $('#cont'),
		//swipeClose:false
	});
	//打开面板
	$('#filterBtn').on(DOEVENT, function () {
		//$('#panel').show();
		$('#panel').panel('toggle', 'push', 'right');
	});
	//选项卡切换 
	$(".sxtc_title li").each(function (i) {
		$(this).on(DOEVENT,function () {
			$(".sxtc_title li").removeClass("cur");
			$(this).addClass("cur");
		   $(".sxtc_content .xx_tab").eq(i).show().siblings().hide();
		})
	});
	
	
	//条件筛选        
	$(".sxtc_list .categ").on(DOEVENT, 
		function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else
			{
				$(".sxtc_list").find(".lb_nr").hide();
				$(".sxtc_list .categ").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	//地区配送选项 
	$(document).on('click',".xzdq_bottom .area",function () {
			if ($(this).hasClass("bgtu"))//打开状态
			{
				$(this).parent().children(".lb_nr").hide();
				$(this).removeClass("bgtu");
			}
			else {
				$(".xzdq_bottom").find(".lb_nr").hide();
				$(".xzdq_bottom .area").removeClass("bgtu");
				$(this).parent().children(".lb_nr").show();
				$(this).addClass("bgtu");
			}
		});
	
	
});
function func_jiege_dizhi_tab(){
	//获得商品价格被选中的
	var pre_num = $("#pro_pre li").length;
	for(var i = 1 ; i<=pre_num ; i++){
		if($("#pro_pre li:nth-child("+i+") a").hasClass("xz")){
			var pro_pre = $("#pro_pre li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	
	//获得配送地址被选中的
	var dizhi_num = $("#dizhi_xz ul").length;
	for(var j = 1 ;j <= dizhi_num; j++){
		var dizhi_num2 = $("#dizhi_xz li:nth-child("+j+") li").length;
		for(var i = 1 ; i<=dizhi_num2 ; i++){
			if($("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+") a").hasClass("xz")){
				var dizhi_xz = $("#dizhi_xz li:nth-child("+j+") li:nth-child("+i+")").children("a").attr("value");
			}
			
		}
	}
	//获得tab条件
	var tab_num = $("#tab_tiaoj li").length-1;
	for(var i = 1 ; i<=tab_num ; i++){
		if($("#tab_tiaoj li:nth-child("+i+") a").hasClass("on")){
			var pro_tab = $("#tab_tiaoj li:nth-child("+i+")").children("a").attr("value");
		}
		
	}
	var arrtest = new Array();
	arrtest[0] = pro_pre;
	arrtest[1] = dizhi_xz;
	arrtest[2] = pro_tab;
	return arrtest;
}
function funLeiX(id_array){
	
	var zong_xuan = new Array();
	for(var j = 0 ;j < id_array.length ; j++){
		var lei_num = $("#"+id_array[j]+" li").length;
		for(var i = 1 ; i<=lei_num ; i++){
			if($("#"+id_array[j]+" li:nth-child("+i+") a").hasClass("xz")){
				zong_xuan[j] = $("#"+id_array[j]+" li:nth-child("+i+")").children("a").attr("value");	
			}
			
		}
	}
	return zong_xuan;
}