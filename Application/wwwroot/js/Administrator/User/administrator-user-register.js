document.getElementById('button-save-user')
    .addEventListener('click', () => UserHandleRegisterButton());


let UserHandleRegisterButton = () => {
    let id = document.getElementById('campo-id').value;
    let formData = UserGetFormData();

    if (id === '') {
        userRegister(formData);
        return;
    }

    formData.append('id', id);

    userUpdate(formData);
}

let userCleanFields = () => {
    document.getElementById('campo-email').value = '';
    document.getElementById('campo-name').value = '';
    document.getElementById('campo-cpf').value = '';
    document.getElementById('campo-phone').value = '';
    document.getElementById('campo-identification').value = '';
    document.getElementById('campo-password').value = '';
    document.getElementById('campo-confirm-password') = '';

    $('#campo-hierarchy').val('').trigger('change');
}

let UserGetFormData = () => {
    let email = document.getElementById('campo-email').value;
    let name = document.getElementById('campo-name').value;
    let cpf = document.getElementById('campo-cpf').value;
    let phone = document.getElementById('campo-phone').value;
    let hierarchyId = document.getElementById('campo-hierarchy').value;
    let identification = document.getElementById('campo-identification').value;
    let password = document.getElementById('campo-password').value;
    let confirmPassword = document.getElementById('campo-confirm-password').value;

    let formData = new FormData();
    formData.append('email', email);
    formData.append('name', name);
    formData.append('cpf', cpf);
    formData.append('phone', phone);
    formData.append('hierarchyId', hierarchyId);
    formData.append('identification', identification);
    formData.append('password', password);
    formData.append('confirmPassword', confirmPassword);

    return formData;
};

let userRegister = (formData) => {
    let statusResponse = 0;
    fetch('/administrator/users/register', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('userUpdateModal'), {});

                modal.hide();

                userClearFields();

                $('#table-user-adm').DataTable().ajax.reload();

                toastr.success('PET cadastrado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível cadastrar o PET');
        });
}
