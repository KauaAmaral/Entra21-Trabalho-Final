$('table').on('click', '.user-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    administratorUserUpdateFillModal(element);
});

let administratorUserUpdateFillModal = (buttonUpdate) => {
    let id = buttonUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/administrator/users/getById?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {

                let modal = new bootstrap.Modal(document.getElementById('userUpdateModal'), {});
                document.getElementById('campo-id').value = data.id;
                document.getElementById('campo-email').value = data.email;
                document.getElementById('campo-name').value = data.name;
                document.getElementById('campo-cpf').value = data.cpf;
                document.getElementById('campo-phone').value = data.phone;
                document.getElementById('campo-identification').value = data.identificationId;
                document.getElementById('campo-password').value = "";
                document.getElementById('campo-confirm-password').value = "";

                debugger;

                $('campo-hierarchy')
                    .val(data.hierarchy)
                    .trigger('change');

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let userUpdate = (formData) => {
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
                $("#userUpdateModal .close").click();

                userCleanFields();

                $('#table-user-adm').DataTable().ajax.reload();

                toastr.success('Usuário alterado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível alterar o usuario');
        });
};