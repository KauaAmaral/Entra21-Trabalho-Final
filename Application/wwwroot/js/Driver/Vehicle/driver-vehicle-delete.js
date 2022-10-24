$('table').on('click', '.vehicle-delete', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    vehicleQuestDelete(element);
});

let vehicleQuestDelete = (botaoApagar) => {
    swal({
        title: 'AVISO',
        text: 'Deseja apagar este veiculo?',
        icon: 'warning',
        buttons: ['Não', 'Sim'],
        dangerMode: true,
        closeModal: true
    }).then((confirmou) => {
        if (confirmou)
            vehicleDelete(botaoApagar);
    });
}

let vehicleDelete = (botaoApagar) => {
    let id = botaoApagar.getAttribute('data-id');

    fetch(`/driver/vehicle/delete?id=${id}`)
        .then((response) => {
            let statusResponse = response.status;

            switch (statusResponse) {
                case 200:
                    toastr.success('Veículo apagado com sucesso');
                    $('#table-vehicle-driver').DataTable().ajax.reload();
                    break;
                case 404:
                    toastr.error('Não foi possível encontrar o veículo');
                    break;
                default:
                    toastr.error('Não foi possível apagar esse veículo, pois já foi gerado uma notificação/pagamento com o mesmo!');
            }

            swal.stopLoading();
            swal.close();
        })
        .catch((error) => console.log(error));
}