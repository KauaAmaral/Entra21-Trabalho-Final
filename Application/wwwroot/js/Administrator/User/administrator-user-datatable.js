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
        { data: 'hierarchy' },
        {
            data: null,
            width: '20%',
            render: function (data, type, user) {
                return `<button class="btn btn-light user-update" data-id="${user.id}">Editar</button>`;
            }

        }
    ],
});