$('table').on('click', '.user-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    administratorUserUpdateFillModal(element);
});

// Limpar os campos quando a modal for fechada
//document.getElementById('cadastroPetModal').addEventListener('hide.bs.modal', () => petLimparCampos());

let administratorUserUpdateFillModal = (buttonUpdate) => {
    let id = buttonUpdate.getAttribute('data-id');
    let statusResponse = 0;
    debugger;
    fetch(`/administrator/users/getById?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('userUpdateModal'), {});

                //document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
                //document.getElementById('cadastroPetModalId').value = data.id;
                //document.getElementById('cadastroPetModalNome').value = data.nome;
                //document.getElementById('cadastroPetModalIdade').value = data.idade;
                //document.getElementById('cadastroPetModalAltura').value = String(data.altura).replace('.', ',');
                //document.getElementById('cadastroPetModalPeso').value = String(data.peso).replace('.', ',');

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let petEditarPet = (formData) => {

    let statusResponse = 0;

    fetch('/administrator/users/update', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('table-user-adm')).hide();

                petLimparCampos();

                $('#table-user-adm').DataTable().ajax.reload();

                toastr.success('PET alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o PET');
        });
};