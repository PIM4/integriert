// Colapse do Menu Lateral
$(".button-collapse").sideNav();

// Função da manipulação dos cards na DASH
$( function() {
	$( ".column" ).sortable({
		connectWith: ".column",
		handle: ".portlet-header",
		cancel: ".portlet-toggle",
		placeholder: "portlet-placeholder ui-corner-all"
	});

	$( ".portlet" )
	.addClass( "ui-widget ui-widget-content ui-helper-clearfix ui-corner-all" )
	.find( ".portlet-header" )
	.addClass( "ui-widget-header ui-corner-all" )
	.prepend( "<span class='ui-icon ui-icon-minusthick portlet-toggle'></span>");

	$( ".portlet-toggle" ).on( "click", function() {
		var icon = $( this );
		icon.toggleClass( "ui-icon-minusthick ui-icon-plusthick" );
		icon.closest( ".portlet" ).find( ".portlet-content" ).toggle();
	});
} );

$("#fecha_menu").click(function(){
	$(this).hide();
	$("#abre_menu").show();
	$("#slide-out").css({'transform':'translateX(-100%)','transition':'.4s'});
    $(".compensa").addClass("fechado");
    
})

$("#abre_menu").click(function(){
	$(this).hide();
	$("#fecha_menu").show();
	$("#slide-out").css({'transform':'translateX(0)','transition':'.4s'});
    $(".compensa").removeClass("fechado");
    
})

$('.datepicker').pickadate({
selectMonths: true, // Creates a dropdown to control month
selectYears: 15, // Creates a dropdown of 15 years to control year,
today: 'Today',
clear: 'Clear',
close: 'Ok',
closeOnSelect: false // Close upon selecting a date,
});

$("#novo_form").click(function(e){
	e.preventDefault();
	$("#cadastroForm, #cadastroForm_bg").show();
});

$("#cadastroForm_bg").click(function(){
	$("#cadastroForm_bg, #cadastroForm").hide()
})

$(document).ready(function(){
	// switch () {
	// 	case label_1:
	// 		// statements_1
	// 		break;
	// 	default:
	// 		// statements_def
	// 		break;
	// }


	
	// $(".coluna1")
	// $(".coluna2")
	// $(".coluna3")
	// $(".coluna4")







	// $(".conteudo1")
	// $(".conteudo2")
	// $(".conteudo3")
})