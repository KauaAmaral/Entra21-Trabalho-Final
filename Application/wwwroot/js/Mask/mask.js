﻿debugger;
$(".vehiclePlate").mask("SSS0A99");
$(".vehiclePlate").on("input", function () {
    $(this).val($(this).val().toUpperCase());
});
 
$("#phone").mask("(00) 00009-0000");
$(".phone").mask("(00) 00009-0000");
$("#cpf").mask("999.999.999-99");
$(".cpf").mask("999.999.999-99");
$("#data").mask("99/99/9999");
$("#cnpj").mask("99.999.999/9999-99");
$("#cep").mask("99.999-999");