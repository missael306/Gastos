var Gastos = Gastos || {};
Gastos.Share = Gastos.Share || {};

Gastos.Share = (function() {
    "use strict";
    let ShareLoad = function() {                

        this.Initialize = function() {       
            this.RegionDatepicker();  
            this.RegionValidate();            
        };

        this.FormatCurrency = function(number){
            let options = {
                style: "currency", 
                currency: "USD",
                maximumFractionDigits:2,
                minimumFractionDigits:2
            }                
            return new Intl.NumberFormat("en-US",options).format(number);
        }

        this.ShowAlerts = function(){            
            if($("#errorMessage").html().trim() != ""){
                $(".alertNotify").each(function(index,item){
                    let color = ($(item).attr("data-type") == "success") ? "green" : "orange";
                    $.alert({
                        title: "OK!",
                        content: $(item).val(),
                        type : color
                    });
                });
                $("#errorMessage").html("")
            }
        }

        this.CleanNumber = function(value){
            value = value+"";
            return value.replace("$","").split(",").join("");
        }

        this.CleanForm = function(idForm){   
            //Remove mask and others characters in the fields of the form
            $(`#${idForm} .input-numeric`).each(function(index,item){
                $(item).val($(item).val().replace("$","").split(",").join(""));
            })      

            //Set the format date in YYYY-MM-DD
            $(`#${idForm} .input-date`).each(function (index, item) {
                $(item).val($(item).val().split("/").reverse().join("-"));
            })
        }

        this.Confirm = function($titulo,$mensaje,$columns){
            return $.confirm({
                title: $titulo,
                icon: "fa fa-question-circle",                
                content: $mensaje,
                type: "orange",
                typeAnimated: true,
                closeIcon: true,
                closeIconClass: "fa fa-close",
                columnClass: $columns               
            });
        }

        this.Failure = function($message){
            $.alert({
                icon: "fa fa-warning",
                title: "Oops...",
                content: "Algo salio mal!<br/>"+$message,                
            })
        }

        this.DataTableConfig = function(){
            return {
                "searching": true,
                "ordering": false,
                "info":     false,
                "dom": "t<'bottom'ip>",
                "language":{
                    "url":"/js/share/js/datatable_language.json"
                }
            }            
        }

        this.RegionDatepicker = function(){
            $.datepicker.regional["es"] = {
                closeText: "Cerrar",
                prevText: "< Ant",
                nextText: "Sig >",
                currentText: "Hoy",
                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                monthNamesShort: ["Ene","Feb","Mar","Abr", "May","Jun","Jul","Ago","Sep", "Oct","Nov","Dic"],
                dayNames: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
                dayNamesShort: ["Dom","Lun","Mar","Mié","Juv","Vie","Sáb"],
                dayNamesMin: ["Do","Lu","Ma","Mi","Ju","Vi","Sá"],
                weekHeader: "Sm",
                dateFormat: "dd/mm/yy",
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ""
                };
                $.datepicker.setDefaults($.datepicker.regional["es"]);
        }

        this.RegionValidate = function(){
            jQuery.extend(jQuery.validator.messages, {
                required: "Este campo es obligatorio.",
                remote: "Por favor, rellena este campo.",
                email: "Por favor, escribe una dirección de correo válida",
                url: "Por favor, escribe una URL válida.",
                date: "Por favor, escribe una fecha válida.",
                dateISO: "Por favor, escribe una fecha (ISO) válida.",
                number: "Por favor, escribe un número entero válido.",
                digits: "Por favor, escribe sólo dígitos.",
                creditcard: "Por favor, escribe un número de tarjeta válido.",
                equalTo: "Por favor, escribe el mismo valor de nuevo.",
                accept: "Por favor, escribe un valor con una extensión aceptada.",
                maxlength: jQuery.validator.format("Por favor, no escribas más de {0} caracteres."),
                minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
                rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
                range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}"),
                max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}"),
                min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}")
            });
        }
    };

    return new ShareLoad();
})();
(function($, window, document) {
    "use strict";
    $(function() {
        Gastos.Share.Initialize();
    });
})(window.jQuery, window, document);
