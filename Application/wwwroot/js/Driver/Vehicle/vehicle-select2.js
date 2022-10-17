$('#campo-type').select2({
    ajax: {
        url: '/driver/vehicle/getVehicleType',
        dataType: 'json',
        processResults: (data) => ({ results: data })
    }
});

$('#campo-type-update').select2({
    ajax: {
        url: '/driver/vehicle/getVehicleType',
        dataType: 'json',
        processResults: (data) => ({ results: data })
    }
});