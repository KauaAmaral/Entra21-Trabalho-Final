$('table').on('click', '.guard-apagar', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    guardQuestionDelete(element);
});

let guardQuestionDelete = (buttonDelete) => {
    swal({
        title: 'AVISO',
        text: 'Deseja apagar este registro?',
        icon: 'warning',
        buttons: ['Não', 'Sim'],
        dangerMode: true,
        closeModal: false
    }).then((confirmed) => {
        if (confirmed)
            guardDelete(buttonDelete);
    });
}

let guardDelete = (buttonDelete) => {
    let id = buttonDelete.getAttribute('data-id');

    toastr.clear();

    fetch(`/guard/delete?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Guarda apagado com sucesso');
                    $('#guard-table').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o guarda');
                    break;
                default:
                    toastr.error('Não foi possível apagar o guarda');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}