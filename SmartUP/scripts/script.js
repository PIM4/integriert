// Colapse do Menu Lateral
$(".button-collapse").sideNav();

// Controles das mascaras
$('.date').mask('00/00/0000');
$('.time').mask('00:00:00');
$('.datetime').mask('00/00/0000 00:00:00');
$('.cep').mask('00000-000', { placeholder: "00000-000" });
$('.phone_with_ddd').mask('(00) 0000-0000');
$('.celphones_with_ddd').mask('(00) 00000-0000');
$('.cnpj').mask('00.000.000/0000-00', { reverse: true});
$('.cpf').mask('000.000.000-00', { reverse: true});
$('.rg').mask('00.000.000-0', { reverse: true});
$('.money').mask('#.##0,00', { reverse: true});
//Mascara especial para campo celular ou fixo
var SPMaskBehavior = function (val) {
    return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
},
spOptions = {
    onKeyPress: function (val, e, field, options) {
        field.mask(SPMaskBehavior.apply({}, arguments), options);
    }
};
$('.sp_celphones').mask(SPMaskBehavior, spOptions);


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

    $(".module_dash").on("click", function (event) {
        event.preventDefault();
        var icon = $(".portlet-toggle"); 
        icon.toggleClass("ui-icon-minusthick ui-icon-plusthick");
        icon.closest(".portlet").find(".portlet-content").toggle();
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

//$("#novo_form").click(function(e){
//	e.preventDefault();
//	$("#cadastroForm, #cadastroForm_bg").show();
//});

//$("#cadastroForm_bg").click(function(){
//	$("#cadastroForm_bg, #cadastroForm").hide()
//})

$(document).ready(function(){
    
        // Setup - add a text input to each footer cell
    $('.datatable tfoot tr th').each(function () {
            var title = $(this).text();
            
            $(this).html('<input type="text" placeholder="Procurar ' + title + '" />');
        });

        // DataTable
        var table = $('.datatable').DataTable({
            language: {
                "sEmptyTable": "Nenhum registro encontrado",
                "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "_MENU_ resultados por página",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "sZeroRecords": "Nenhum registro encontrado",
                "sSearch": "Pesquisar",
                "oPaginate": {
                    "sNext": "Próximo",
                    "sPrevious": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Último"
                },
                "oAria": {
                    "sSortAscending": ": Ordenar colunas de forma ascendente",
                    "sSortDescending": ": Ordenar colunas de forma descendente"
                }
            }
        });

        // Apply the search
        table.columns().every(function () {
            var that = this;
            $('input', this.footer()).on('keyup change', function () {
                if (that.search() !== this.value) {
                    that
                        .search(this.value)
                        .draw();
                }
            });
        });
    
})