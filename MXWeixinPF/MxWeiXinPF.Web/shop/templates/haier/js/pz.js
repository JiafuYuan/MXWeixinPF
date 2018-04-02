	//品众
	var _pzt =_pzt||{}; 
	_pzt.siteid='f79b954c3d78f2cea5ec9b74429f658b'; 
	_pzt.events = [];
		
	(function(){
	var tk = document.createElement('script'); 
	tk.type = 'text/javascript'; 
	tk.async = true;
	tk.src=('https:'==document.location.protocol?'https://ssl-static.pzoom.com':'http://static.pzoom.com') +'/fx/1/1/t.js'; 
	var s = document.getElementsByTagName('script')[0];
	s.parentNode.insertBefore(tk, s);})();

	function _pzRegistMonitoring(){
		_pzt.events.push({type:'target',category:'category',action:'reg',opt_label:'reg_variable',value:1});
		PzoomTracker.trackPageView();
	}

	function _pzOrderMonitoring(orderSn, orderAmount){
		var _pzt =_pzt||{};
		_pzt.siteid='f79b954c3d78f2cea5ec9b74429f658b';
		
		_pzt.order={o_id:orderSn, o_total_price:orderAmount};
		(function(){
		var tk = document.createElement('script');
		tk.type='text/javascript';
		tk.async = true;
		tk.src = ('https:' == document.location.protocol?
		'https://ssl-static.pzoom.com':'http://static.pzoom.com')+'/fx/1/1/t.js';
		var s = document.getElementsByTagName('script')[0];s.parentNode.insertBefore(tk,s);})();
	}