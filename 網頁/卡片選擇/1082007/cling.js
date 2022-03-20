$(function(){
	$("#SMALL img").click(function(){
		var N = $(this).attr("id").substr(2);
		$("#BIG").attr( "src" , "images/small" + N + ".jpg" );	
		$("#BIG").fadeOut(0);
  		$("#BIG").fadeIn(300);
	});
});
