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
        { data: 'licensePlate' },
        {
            data: null,
            render: function (data, tipo, payment) {
                let cor = '';
                let type = '';

                if (payment.type === 0) {
                    type = "Carro";
                    cor = "success";
                }
                else if (payment.type === 1) {
                    type = "Moto";
                    cor = "info";
                }

                return `<span class="badge bg-${cor}">${type}</span>`;
            }
        },
        { data: 'model' },
        {
            data: null,
            width: '20%',
            render: function (data, type, payment) {
                return `<button class="btn btn-outline-primary payment-details" data-id="${payment.id}">Detalhes</button>`;
            }
        }
    ],
});