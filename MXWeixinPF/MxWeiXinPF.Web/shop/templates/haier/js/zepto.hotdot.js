/*
 * @author: chenxiaoyong@ehaier.com
 * @date: 2014-08-21
 * @site: http://m.ehaier.com
 * @project: Hotdot Plugin
 * PS: 热点菜单
 */

! function (window, $, undefined) {

	var TOGGLE_CLASS = 'menu-toggle',
		COVER_HTML= '<div class="bg-cover-layer"></div>',
		isCover = false,
		pluginName = 'hotdot',
		Plugin = function (selector) {
			$(selector).on('click', this.toggle);
		};
		Plugin.prototype = {
			constructor: Plugin,
			toggle: function (event) {
				var $this = $(this),
					$parent = $this.parents('#hotdot-nav'),
					pageHeight = $('body').height(),
					winHeight = $(window).height();
				if ( $parent.hasClass(TOGGLE_CLASS) ) { 
					isCover ? isCover.remove() : isCover = false;
					$parent.removeClass(TOGGLE_CLASS);
				} else {
					isCover = $(COVER_HTML).appendTo('body').height(
								pageHeight > winHeight ?　pageHeight : winHeight
							　);
					$parent.addClass(TOGGLE_CLASS);
				}
				return false;
			}
		};

	$.fn[pluginName] = function () {
		return this.each(function () {
			var $this = $(this),
			    data = $this.data(pluginName);
			if (!data) {
				$this.data(pluginName, new Plugin(this));
			}
		});
	};

	$(function () {
		$('.hotdot').hotdot();
		$(document).on('click', '.bg-cover-layer', function () {
			var $parent = $('#hotdot-nav');
			if ($parent.hasClass(TOGGLE_CLASS)) {
				$parent.removeClass(TOGGLE_CLASS);
				isCover ? isCover.remove() : isCover = false;
			}

		})
	});

}(this, $);
