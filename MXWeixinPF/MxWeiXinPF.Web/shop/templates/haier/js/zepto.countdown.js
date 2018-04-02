/*
 * @author: chenxiaoyong@ehaier.com
 * @date: 2014-08-18
 * @site: http://m.ehaier.com
 * @project: Countdown Plugin 
 */

! function (window, $, undefined) {
  
	var pluginName = 'countdown',
		pluginHTML = '<div class="day">' +
						'<span class="h-flag"></span>' +
					 '</div>' +
					 '<div class="hour">' +
						'<span class="h-flag"></span>' +
						'<span class="l-flag"></span>' +
					 '</div>' +
					 '<i>:</i>' +
					 '<div class="minute">' +
						'<span class="h-flag"></span>' +
						'<span class="l-flag"></span>' +
					 '</div>' +
					 '<i>:</i>' +
					 '<div class="second">' +
						'<span class="h-flag"></span>' +
						'<span class="l-flag"></span>' +
					 '</div>',
		Plugin = function (selector, callback) {
			this.bootCountdown(selector, callback);	
		};
		
		Plugin.prototype = {
			constructor: Plugin,
			bootCountdown: function (selector, callback) {

				var parent = $(selector).append(pluginHTML),
					deadline= parent.attr('data-endtime'),
					countdownD = parent.find('.day'),
					countdownDH = countdownD.find('.h-flag'),
					countdownH = parent.find('.hour'),
					countdownHH = countdownH.find('.h-flag'),
					countdownHL = countdownH.find('.l-flag'),
					countdownM = parent.find('.minute'),
					countdownMH = countdownM.find('.h-flag'),
					countdownML = countdownM.find('.l-flag'),
					countdownS = parent.find('.second'),
					countdownSH = countdownS.find('.h-flag'),
					countdownSL = countdownS.find('.l-flag'),
					nowTime = Date.now(),
					endTime = new Date( deadline ? deadline : null).getTime(),
					secs = Math.max((endTime - nowTime) / 1000, 0);
				
				(function() {
					var day = parseInt(secs / (3600*24)),
						hour = parseInt(secs % (3600*24) / 3600),
						minute = parseInt(secs % 3600 / 60),
						second = parseInt(secs % 60);
				    
					if (day) {
						countdownDH.html(day+'天');	
					} else {
						countdownDH.hide();	
					}

					if ((hour+'').length > 1) {
						countdownHH.html((hour+'')[0])
						countdownHL.html((hour+'')[1])
					} else {
						countdownHH.html('0')
						countdownHL.html((hour+'')[0])
					}

					if ((minute+'').length > 1) {
						countdownMH.html((minute+'')[0])
						countdownML.html((minute+'')[1])
					} else {
						countdownMH.html('0')
						countdownML.html((minute+'')[0])
					}
					if ((second+'').length > 1) {
						countdownSH.html((second+'')[0])
						countdownSL.html((second+'')[1])
					} else {
						countdownSH.html('0')
						countdownSL.html((second+'')[0])
					}

					if (--secs < 0) {
						callback && callback(selector);
						return false;
					}
					setTimeout(arguments.callee, 1000);
				})();
					
			}
		};

	$.fn[pluginName] = function (callback) {
		return this.each(function () {
			var $this = $(this),
			    data = $this.data(pluginName);
			if (!data) {
				$this.data(pluginName, new Plugin(this, callback));
			}
		});
	};

}(this, $);
