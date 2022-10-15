$('#table-vehicle-adm').DataTable({
    responsive: true,
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/administrator/vehicle/getAll',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'name' },
        { data: 'licensePlate' },
        {
            data: null,
            render: function (data, tipo, vehicle) {
                let cor = '';
                let type = '';

                if (vehicle.type === 0) {
                    type = "Carro";
                    cor = "success";
                }
                else if (vehicle.type === 1) {
                    type = "Moto";
                    cor = "info";
                }

                return `<span class="badge bg-${cor}">${type}</span>`;
            }
        },
        { data: 'model' }
    ],
});