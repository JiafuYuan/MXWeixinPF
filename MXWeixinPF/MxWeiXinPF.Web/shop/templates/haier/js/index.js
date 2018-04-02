/*
 * @author: chenxiaoyong@ehaier.com
 * @date: 2014-08-08
 * @site: http://m.ehaier.com
 */

! function (window, $,undefined) {
	
	var Page = {
		hideBar : function () {			
				setTimeout(function(){ window.scrollTo(0, 1); }, 100);				
		},
		bootSwiper: function () {
			var slideSwiper = new Swiper('.slide .swiper-container',{
				pagination: '.slide .pagination',
				loop:true,
				grabCursor: true,
				paginationClickable: true,
				calculateHeight: true,

			  });
		var categorySwiper = new Swiper('.category .swiper-container',{
				pagination: '.category .pagination',
				loop:true,
				grabCursor: true,
				paginationClickable: true,
				calculateHeight: true

			  });
		
		},		
		bootCountdown: function () {
			$('.countdown').countdown(function () {
				// alert('Stop!');
			});
		},
		toggleMenu: function () {
			
			var	LOCK_CLASS = 'absolutely-hoop',
				isLock = false,
			    headElement = $('#header'),
				openBtn = $('.navbar'),
				closeBtn = $('.toolbar-nav .close');

			function toggle() {
				var NAME_CLASS = 'navbar-toggle', 
					flag = headElement.hasClass(NAME_CLASS);
				if (flag) {
					isLock ? $('.wrap').first().removeClass(LOCK_CLASS) : isLock = false;  
					headElement.removeClass(NAME_CLASS);
				} else {
					 isLock = true, $('.wrap').first().addClass(LOCK_CLASS);
					 headElement.addClass(NAME_CLASS);
				}
			}	
			openBtn.click(toggle);
			closeBtn.click(toggle);
		
		},
		init: function () {
			this.hideBar();
			this.bootSwiper();
			this.bootCountdown();
			this.toggleMenu();	
		}
	};
	
	$(function () {		
		Page.init();
	});
}(this, $)
