$('#table-vehicle-driver').DataTable({
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
        { data: 'model' },
        { data: 'type' },
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