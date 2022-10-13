$('table').on('click', '.user-delete', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    userQuestDelete(element);
});

let userQuestDelete = (botaoApagar) => {
    swal({
        title: 'AVISO',
        text: 'Deseja apagar este usuario?',
        icon: 'warning',
        buttons: ['Não', 'Sim'],
        dangerMode: true,
        closeModal: true
    }).then((confirmou) => {
        if (confirmou)
            userDelete(botaoApagar);
    });
}

let userDelete = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');
    debugger;
    fetch(`/administrator/users/delete?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Usuario apagado com sucesso');
                    $('#table-user-adm').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o usuario');
                    break;
                default:
                    toastr.error('Não foi possível apagar o usuario');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}