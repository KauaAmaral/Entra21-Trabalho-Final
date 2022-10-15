$('#table-vehicle-driver').DataTable({
    responsive: true,
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/driver/vehicle/getAll',
        dataSrc: ''
    },
    processing: true,
    columns: [
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
        { data: 'model' },
        {
            data: null,
            width: '20%',
            render: function (data, type, vehicle) {
                return `<button class="btn btn-primary vehicle-update" data-id="${vehicle.id}">Editar</button>
                <button class="btn btn-danger vehicle-delete" data-id="${vehicle.id}">Apagar</button>`;
            }
        }
    ],
});