//默认地址切换
$(".address_t a").click(function(){
	$(".address_t a").removeClass();
	$(".address_t a").find('b').removeClass('mr2').addClass("mr");
	$(".address_t a").find('span').html('设为默认地址');
	
	if(!$(this).hasClass('address_cur')){
		$(this).addClass('address_cur');
		$(this).find('b').removeClass('mr').addClass("mr2");
		$(this).find('span').html('默认地址');
	}else{
		$(this).removeClass();
		$(this).find('b').removeClass('mr2').addClass("mr");
		$(this).find('span').html('设为默认地址');
	}
	
});
//收货人验证
$("#consignee").blur(function(){
	var consignee = $("#consignee").val();
	if(consignee == ''){
		hintShow("conMsg","收货人不能为空");
		return false;
	}else{
		hintHide("conMsg");
	}
})
//验证邮编
$("#zipCode").blur(function(){
	var consignee = $("#zipCode").val();
	if(consignee == ''){
		hintShow("zipCodeMsg","邮编不能为空");
		return false;
	}else{
		hintHide("zipCodeMsg");
	}
})
//手机号验证
$("#mobile").blur(function(){
	var mobileNum = $("#mobile").val();
	var pattern = new RegExp("^((13[0-9])|(14[57])|(15[^4,\\D])|(18[0-9]))\\d{8}$");
	if(mobileNum == ''){
		hintShow("mobileNumMsg","手机号码不能为空");
		return false;
	}else{
		hintHide("mobileNumMsg");
	}
	if(!pattern.test(mobileNum)){
		hintShow("mobileNumMsg","手机号码不正确!");
		return false;
	}
})
//配送地址
$("#delivery").blur(function(){
	var delivery = $("#delivery").val();
	if(delivery == ''){
		hintShow("deliveryMsg","详细地址不能为空!");
		return false;
	}else{
		hintHide("deliveryMsg");
	}
})
//表单验证
$(".address_addbutton").click(function(){
	if(!checkRegForm()){
		return false;
	}
$("#registForm").submit();
});
//提示显示
function hintShow(showId,showCon){
	$("#"+showId).parent().show();
	$("#"+showId).text(showCon);
}
//提示隐藏
function hintHide(hideId){
	$("#"+hideId).parent().hide();
	$("#"+hideId).text("");
}
//表单验证方法
function checkRegForm(){
	var consignee = $("#consignee").val();
	if(consignee == ''){
		hintShow("conMsg","收货人不能为空");
		return false;
	}else{
		hintHide("conMsg");
	}
	var mobileNum = $("#mobile").val();
	var pattern = new RegExp("^((13[0-9])|(14[57])|(15[^4,\\D])|(18[0-9]))\\d{8}$");
	if(mobileNum == ''){
		hintShow("mobileNumMsg","手机号码不能为空");
		return false;
	}else{
		hintHide("mobileNumMsg");
	}
	if(!pattern.test(mobileNum)){
		hintShow("mobileNumMsg","手机号码不正确!");
		return false;
	}
	if(delivery == ''){
		hintShow("deliveryMsg","详细地址不能为空!");
		return false;
	}else{
		hintHide("deliveryMsg");
	}
	return true;
}
//支付方式切换
$("#choose_title .address_b").on('click',function(){
	$("#choose_title .address_b").find("a").removeClass('choose_cur');
	$("#choose_title .address_b").find("b").removeClass("micon choose_icon");	
	$(this).find('a').toggleClass('choose_cur');
	$(this).find('b').addClass("micon choose_icon");
});
//配送方式切换
$("#ps_style div").on('click',function(){
	
	$("#ps_style div").removeClass("choose_blue");
	$("#ps_style div").find("b").removeClass("micon order_right");	
	$(this).toggleClass('choose_blue');
	$(this).find("b").addClass("micon order_right");
	if($(this).find('span').html() == '预约：'){
		$("#delivery").val('1');
	}else{
		$("#delivery").val('0');
	}
});
//发票介质切换
$("#order_fp p").on('click',function(){
	
	$("#order_fp p").removeClass("order_cur");
	$("#order_fp p").children("b").removeClass("micon order_check");	
	$(this).toggleClass('order_cur');
	$(this).find("b").addClass("micon order_check");
	if($(this).find('span').html() == '电子发票 （推荐）'){
		$("#billForm").val('1');
	}else{
		$("#billForm").val('0');
	}
});