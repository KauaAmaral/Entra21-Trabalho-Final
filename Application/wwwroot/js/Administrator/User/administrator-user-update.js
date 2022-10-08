$('table').on('click', '.user-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    administratorUserUpdateFillModal(element);
});

// Limpar os campos quando a modal for fechada
document.getElementById('userUpdateModal').addEventListener('hide.bs.modal', () => userClearFields());

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
                document.getElementById('campo-email').value = data.email;
                document.getElementById('campo-name').value = data.name;
                document.getElementById('campo-cpf').value = data.cpf;
                document.getElementById('campo-phone').value = data.phone;
                //document.getElementById('campo-procedimento').value = data.procedimento;
                document.getElementById('campo-password').value = "";
                document.getElementById('campo-confirm-password').value = "";

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

                userClearFields();

                $('#table-user-adm').DataTable().ajax.reload();

                toastr.success('Usuario alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o usuario');
        });
};