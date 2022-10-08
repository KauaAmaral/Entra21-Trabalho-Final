$('#table-user-adm').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/administrator/users/getAll',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'name' },
        { data: 'email' },
        {
            data: null,
            render: function (data, type, user) {
                let cor = '';
                let hierarchy = '';
                if (user.hierarchy === 0) {
                    hierarchy = "Administrador";
                    cor = "danger";
                } else if (user.hierarchy === 1) {
                    status = "Guarda";
                    cor = "primary";
                } else if (user.hierarchy === 2) {
                    status = "Motorista";
                    cor = "success";
                }

                return `<span class="badge bg-${cor}">${hierarchy}</span>`;
            }
        },
        {
            data: null,
            width: '20%',
            render: function (data, type, user) {
                return `<button class="btn btn-primary user-update" data-id="${user.id}">Editar</button>
                <button class="btn btn-danger user-update" data-id="${user.id}">Apagar</button>`;
            }

        }
    ],
});