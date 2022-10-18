$('table').on('click', '.driver-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    driverUpdateUser(element);
});

// Limpar os campos quando a modal for fechada
document.getElementById('vehicleUpdateModal').addEventListener('hide.bs.modal', () => vehicleClearFields());

let driverUpdateUser = (buttonUpdate) => {
    let id = buttonUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/driver/user/getById?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('userUpdateModal'), {});
                
                document.getElementById('updateUserModalId').value = data.id;
                document.getElementById('campo-name-update').value = data.name;
                document.getElementById('campo-email-update').value = data.email;
                document.getElementById('campo-cpf-update').value = data.cpf;
                document.getElementById('campo-phone-update').value = data.phone;
            

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let userDriverUpdate = () => {
    let id = document.getElementById("updateUserModalId").value;
    let name = document.getElementById("campo-name-update").value;
    let email = document.getElementById("campo-email-update").value;
    let cpf = document.getElementById("campo-cpf-update").value;
    let phone = document.getElementById("campo-phone-update").value;

    let dados = new FormData();
    dados.append("id", id);
    dados.append("name", name);
    dados.append("email", email);
    dados.append("cpf", cpf);
    dados.append("phone", phone);

    console.log(dados);

    return dados;
}

let saveUpdateUserDriver = () => {
    let formData = userDriverUpdate();

    userUpdate(formData);
}

let userUpdate = (formData) => {
    let statusResponse = 0;
    fetch('/Driver/user/Update', {
        method: 'POST',
        body: formData
    })
        //.then((response) => {
        //    statusResponse = response.status;

        //    return response.json();
        //})
        .then((data) => {
            //if (statusResponse === 200) {
            debugger;

            //let modal = bootstrap.Modal.getInstance(document.getElementById('vehicleUpdateModal'), {});
            //modal.hide();

            $("#userUpdateModal .btn-close-update").click();

            //$('#table-vehicle-driver').DataTable().ajax.reload();

            toastr.success('Veículo alterado com sucesso');

            //vehicleClearFields();

            return;
            //}

            showNotificationErrorsOfValidation(data);
        })
    .catch((error) => {
        console.error(error);

        toastr.error('Não foi possível alterar o veículo');
    });
};

document.getElementById("button-update-driver-user")
    .addEventListener("click", saveUpdateUserDriver);