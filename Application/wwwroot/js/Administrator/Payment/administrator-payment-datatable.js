$('#table-payment-adm').DataTable({
    responsive: true,
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/administrator/payments/getAll',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'model' },
        { data: 'licensePlate' },
        {
            data: null,
            width: '20%',
            render: function (data, type, payment) {
                return `<button class="btn btn-outline-primary payment-details" data-id="${payment.id}">Detalhes</button>`;
            }
        }
    ],
});