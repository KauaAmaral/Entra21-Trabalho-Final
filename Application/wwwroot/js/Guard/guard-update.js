$('table').on('click', 'button.guard-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    guardUpdateFillModal(element);
});

document.getElementById('registerGuardModal').addEventListener('hide.bs.modal', () => guardClearFields());

let guardUpdateFillModal = (buttonUpdate) => {
    let id = buttonUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/guarda/obterPorId?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('registerGuardModal'), {});

                document.getElementById('cadastroGuardaModalLabel').innerText = `Editar Guarda: ${data.nome}`
                document.getElementById('cadastroGuardaModalId').value = data.id;
                document.getElementById('cadastroGuardaModalNome').value = data.nome;
                document.getElementById('cadastroGuardaModalCpf').value = String(data.altura).trim();
                document.getElementById('cadastroGuardaModalNumeroIdentificacao').value = String(data.altura).trim();

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let guardUpdateGuard = (formData) => {

    let statusResponse = 0;

    fetch('/guarda/editar', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('registerGuardModal')).hide();

                guardClearFields();

                $('#pet-table').DataTable().ajax.reload();

                toastr.success('Guarda alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o Guarda');
        });
};