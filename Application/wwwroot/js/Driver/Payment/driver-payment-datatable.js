$('#table-payment-driver').DataTable({
    responsive: true,
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/driver/payments/getAll',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'licensePlate' },
        { data: 'model' },
        {
            data: null,
            width: '20%',
            render: function (data, type, vehicle) {
                return `<button class="btn btn-primary vehicle-pay" data-id="${vehicle.id}">Pagar</button>`;
            }
        }
    ],
});