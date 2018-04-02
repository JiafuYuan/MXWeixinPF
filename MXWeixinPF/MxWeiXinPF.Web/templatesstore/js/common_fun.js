(function($){
	$.get = function(url,_data,callback,dataType){
		var data = {};
		if(!callback){
			callback = _data;
		}else{
			data = _data;
		}
		if(!dataType){
			dataType = 'html';
		}
		var url_tmp = url;
		for(var d in data){
			url_tmp = url_tmp + ':' + d + '=' + data[d];
		}
		$.ajax({
			url: url,
			data: data,
			type: "GET",
			dataType: dataType,
			success: function(data){
				if(data == 'NEED_LOGIN'){
					if(top.location == self.location){
						location.reload();
					}else{
						parent.location.reload();
					}
				}else{
					callback && callback(data);
				}
			}
		});
	};
	
	$.post = function(url,_data,callback){
		var data = {};
		if(!callback){
			callback = _data;
		}else{
			data = _data;
		}
		var url_tmp = url;
		for(var d in data){
			url_tmp = url_tmp + ':' + d + '=' + data[d];
		}
		$.ajax({
			url: url,
			data: data,
			type: "POST",
			dataType: "html",
			success: function(data){
				if(data == 'NEED_LOGIN'){
					if(top.location == self.location){
						location.reload();
					}else{
						parent.location.reload();
					}
				}else{
					callback && callback(data);
				}
			}
		});
	};
	$.fn.xLazyLoad = function (options) {
		var _this = $(this);
		var defaults = {
			style: "top",
			offset: 200,
			trigger_element: null,
			callback: null,
			"": ""
		};
		var settings = $.extend({}, defaults, options);
		var stime = null;

		function loadImg() {
			_this.each(function () {
				if ($(this).attr("_effect")) {
					var y = isIpad() ? window.pageYOffset + 50 : Math.max(document.documentElement.scrollTop, document.body.scrollTop);
					var x = isIpad() ? window.pageXOffset + 50 : Math.max(document.documentElement.scrollLeft, document.body.scrollLeft);
					if (settings.trigger_element) {
						y = $(settings.trigger_element).offset().top;
						x = $(settings.trigger_element).offset().left;
					}
					var test = false;
					if (settings.style == "top") {
						test = $(this).offset().top <= document.documentElement.clientHeight + y + settings.offset && $(this).offset().top >= y - settings.offset;
					} else {
						test = $(this).offset().left <= document.documentElement.clientWidth - x + settings.offset && $(this).offset().left >= x - settings.offset;
					}
					if (test) {
						$(this).removeAttr('_effect');
						var self = this;
						var img = $(self).find('img[_src]');
						if(img.size()){
							img.each(function(kk,v_img){
								var _src = $(v_img).attr("_src");
								$(v_img).removeAttr("_src");
								setTimeout(function () {
									$(v_img).load(function(){
										$(self).animate({
											opacity:1
										},500);
									}).attr("src", _src);
									settings.callback && settings.callback.call($(self));
								}, Math.random() * 1000);
							});
						}else{
							setTimeout(function () {
								$(self).animate({
									opacity:1
								},500);
								settings.callback && settings.callback.call($(self));
							}, Math.random() * 1000);
						}
					}
				}
			});
		}

		function isIpad() {
			return navigator.userAgent.match(/iPad/i) != null;
		}
		if (!settings.trigger_element) {
			$(window).bind("scroll.xLazyLoad", function () {
				if (stime) {
					clearTimeout(stime);
				}
				stime = setTimeout(function () {
					loadImg();
				}, 200);
			});
		}
		loadImg();
		return this;
	};
	
	$.fn.xScroll = function(callback){
		if($(this).size() == 0){
			return;
		};
		var _this = this;
		$('html,body').stop(false,false).animate({
			scrollTop: $(this).offset().top
		}, 1000,function(){
			callback && callback.call($(_this));
		});
	};
	
	$.fn.xShake = function(){
		return $(this).stop(true,true).effect('pulsate',{times:2},400).focus();
	};
	
	$.fn.xNumber = function(){
		var bindStr = "input.validNumber propertychange.validNumber keyup.validNumber";
		$(this).on(bindStr,function(e){
			$(this).val($(this).val().replace(/[^\d]/g,''));
        });
	};
	
	/**
	* formatMoney(s,type)  
	* 功能：金额按千位逗号分割  
	* 参数：s，需要格式化的金额数值.  
	* 参数：type,判断格式化后的金额是否需要小数位.  
	* 返回：返回格式化后的数值字符串.  
	*/  
	$.number_format = function(s) {
		if (/[^0-9\.]/.test(s)) return "0";
		if (s == null || s == "") return "0";
		s = s.toString().replace(/^(\d*)$/, "$1.");
		s = (s + "00").replace(/(\d*\.\d\d)\d*/, "$1");  
		s = s.replace(".", ",");
		var re = /(\d)(\d{3},)/;  
		while (re.test(s))
			s = s.replace(re, "$1,$2");
		s = s.replace(/,(\d\d)$/, ".$1");
		if (true) {// 不带小数位(默认是有小数位)
			var a = s.split(".");
			if (a[1] == "00"){  
				s = a[0];
			};
		};
		return s;  
	};
	
	$.fn.outerHTML = function(){return $("<p></p>").append(this.clone()).html();};
	
	$.h = function(str){  
		str = str.replace(/&/g, '&amp;');
		str = str.replace(/</g, '&lt;');
		str = str.replace(/>/g, '&gt;');
		str = str.replace(/"/g, '&quot;');
		str = str.replace(/'/g, '&#039;');
		return str;
	};
	
	$.createpage = function(url,opt){
		if(url.indexOf('?') == -1){
			url = url+'?';
		}else{
			url = url+'&';
		}
		var width = 710;
		var height = 440;
		var afterClose;
		if(opt.afterClose){
			afterClose = opt.afterClose;
			delete opt.afterClose;
		}
		if(opt.flag.indexOf('_crop') != -1){
			width = 635;
			height = 538;
		}else if(opt.flag == 'Kv'){
			var width = 720;
			var height = 501;			
		}
		$.fancybox.open(url+$.param(opt),{
			padding	: 15,
			autoSize :false,
			width: width,
			height:height,
			type:'iframe',
			iframe : {
				scrolling : 'no'
			},
			beforeClose:function(){
				if(window.uploading){
					alert('操作中,请勿关闭窗口!');
					return false;
				}else{
					return true;
				}
			},
			afterClose:function(){
				afterClose && afterClose.call(this,opt.flag);
			}
		});
	};
	
	$.formatSize = function(size){
		var fileSize = Math.round(size / 1024);
		var suffix   = 'KB';
		if (fileSize > 1000) {
			fileSize = Math.round(fileSize / 1000);
			suffix   = 'MB';
		}
		var fileSizeParts = fileSize.toString().split('.');
		fileSize = fileSizeParts[0];
		if (fileSizeParts.length > 1) {
			fileSize += '.' + fileSizeParts[1].substr(0,2);
		}
		fileSize += suffix;
		
		return fileSize;
	};
	
	$.lang = function () {
		return location.pathname.split("/")[1];
	};
	$.gurl = function(url){
		return '/'+$.lang()+url;
	};
	
	$.check_email = function (ipt_txt){
		var txt = ipt_txt;
		if(typeof(ipt_txt) == 'object'){
			ipt_txt.val($.trim(ipt_txt.val()));
			txt = ipt_txt.val();
		}
		if(!/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(txt)){
			if(typeof(ipt_txt) == 'object'){
				ipt_txt.focus();
			}
			return false;
		}
		return true;
	};
	$.check_password = function (ipt_txt){
		ipt_txt.val($.trim(ipt_txt.val()));
		if(ipt_txt.val().length < 6 || ipt_txt.val().length > 20){
			ipt_txt.focus();
			return false;
		}
		return true;
	};
	$.check_empty = function (ipt_txt){
		ipt_txt = $(ipt_txt);
		ipt_txt.val($.trim(ipt_txt.val()));
		if(ipt_txt.val() == ''){
			ipt_txt.focus();
			return false;
		}
		return true;
	};	
})(jQuery);

