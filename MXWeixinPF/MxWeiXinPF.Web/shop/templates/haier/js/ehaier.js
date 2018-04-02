 	//灵猫
	var dr='';
	var r=dr?dr:encodeURIComponent(document.referrer);
	var rn=Math.floor(Math.random()*2147483647);
	var u='';
	if(r!==''&&r!==0&&r!=='0'&&r!==null&&r!==false&&r!==undefined){u+='&referrer='+r}
	document.write('<img width="1" height="1" style="position:absolute;" src="http://mnt.ehaier.com/mnt.gif?v=0.3&rn='+rn+u+'" />');