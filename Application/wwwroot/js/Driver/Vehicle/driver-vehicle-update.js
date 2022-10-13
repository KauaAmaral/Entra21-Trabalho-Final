$('table').on('click', '.vehicle-update', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    driverUpdateVehicle(element);
});

// Limpar os campos quando a modal for fechada
document.getElementById('vehicleUpdateModal').addEventListener('hide.bs.modal', () => vehicleClearFields());

let driverUpdateVehicle = (buttonUpdate) => {
    let id = buttonUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/driver/vehicle/getById?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('vehicleUpdateModal'), {});

                //document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
                document.getElementById('campo-licensePlate').value = data.licensePlate;
                document.getElementById('campo-model').value = data.model;
                document.getElementById('campo-type').value = data.type;

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let vehicleUpdate = (formData) => {

    let statusResponse = 0;

    fetch('/driver/vehicle/update', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('vehicleUpdateModal')).hide();

                userClearFields();

                $('#vehicles-id').DataTable().ajax.reload();

                toastr.success('Vehicle alterado com sucesso');

                return;
            }

            //showNotificationErrorsOfValidation(data);
        })
    //.catch((error) => {
    //    console.error(error);

    //    toastr.error('Não foi possível alterar o usuario');
    //});
};

document.getElementById("button-update-vehicle")
    .addEventListener("click", userUpdate);