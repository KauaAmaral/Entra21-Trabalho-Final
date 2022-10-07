// consulta-datatable.js

$('#table-users').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/Administrator/Users/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        { data: 'email' },
        { data: 'name' },
        { data: 'cpf' },
        { data: 'password' },
        {
            data: null,
            render: function (data, type, user) {
                let cor = '';
                let hierachy = '';
                if (user.hierachy === 0) {
                    hierachy = "Administrador";
                }
                else if (user.hierachy === 1) {
                    hierachy = "Guarda";
                }
                else if (user.hierachy === 2) {
                    hierachy = "Motorista";
                }
                return `<span class="badge bg-${cor}">${status}</span>`;
            }
        },
        //{
        //    data: null,
        //    width: '20%',
        //    render: function (data, type, user) {
        //        if (consulta.status == 0) {
        //            return `<button class="btn btn-primary consulta-iniciar" data-id="${consulta.id}">Iniciar</button>
        //            <button class="btn btn-danger consulta-cancelar" data-id="${consulta.id}">Cancelar</button>`;
        //        }

        //        if (consulta.status == 1) {
        //            return `<button class="btn btn-success consulta-finalizar" data-id="${consulta.id}">Finalizar</button>`;
        //        }

        //        if (consulta.status == 2) {
        //            return `<button class="btn btn-light consulta-detalhar" data-id="${consulta.id}">Exibir detalhes</button>`;
        //        }

        //        return "";
        //    }
        //}
    ],
});