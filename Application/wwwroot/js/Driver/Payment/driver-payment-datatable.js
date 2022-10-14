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
            render: function (data, type, vehicle) {
                return `<button class="btn btn-primary vehicle-pay" data-id="${vehicle.id}">Pagar</button>`;
            }
        }
    ],
});