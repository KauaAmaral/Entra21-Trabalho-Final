$(document).ready(function () {
    let value = $("#campo-hierarchy").val();
    if (value == "Guarda") {
        $("#campo-identification").prop("disabled", false);
    }
});

$("#campo-hierarchy").on("change", function () {
    let value = $("#campo-hierarchy").val();
    if (value == 1) {
        $("#campo-identification").prop("disabled", false);
    }
    else {
        $("#campo-identification").prop("disabled", true);
        $("#campo-identification").val("");
    }
});