$('table').on('click', '.driver-update', (event) => {
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

    fetch(`/driver/vehicle/GetViewModelById?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('vehicleUpdateModal'), {});
                
                document.getElementById('updateVehicleModalId').value = data.id;
                document.getElementById('campo-licensePlate-update').value = data.licensePlate;
                document.getElementById('campo-model-update').value = data.model;
                $('#campo-type-update')
                    .append(new Option(data.typeName, data.type, false, false))
                    .val(data.type)
                    .trigger('change');

                modal.show();
            }
        })
        .catch((error) => console.log(error));
}

let vehicleDriverUpdate = () => {
    let id = document.getElementById("updateVehicleModalId").value;
    let licensePlate = document.getElementById("campo-licensePlate-update").value;
    let model = document.getElementById("campo-model-update").value;
    let type = document.getElementById("campo-type-update").value;

    let dados = new FormData();
    dados.append("id", id);
    dados.append("licensePlate", licensePlate);
    dados.append("model", model);
    dados.append("type", type);

    console.log(dados);

    return dados;
}

let saveUpdateVehicleDriver = () => {
    let formData = vehicleDriverUpdate();

    vehicleUpdate(formData);
}

let vehicleUpdate = (formData) => {
    let statusResponse = 0;
    fetch('/driver/vehicle/update', {
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

            $("#vehicleUpdateModal .btn-close-update").click();

            $('#table-vehicle-driver').DataTable().ajax.reload();

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

document.getElementById("button-update-vehicle")
    .addEventListener("click", saveUpdateVehicleDriver);