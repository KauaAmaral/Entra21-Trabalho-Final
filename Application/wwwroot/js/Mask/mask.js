$("#vehiclePlate").mask("SSS0A99");

$("#vehiclePlate").on("input", function () {
    $(this).val($(this).val().toUpperCase());
});

$("#data").mask("99/99/9999");
$("#cpf").mask("999.999.999-99");
$("#cnpj").mask("99.999.999/9999-99");
$("#telephone").mask("(99)9999-9999?9");
$("#cep").mask("99.999-999");

