let registerVehicle = () => {
    let licensePlate = document.getElementById("campo-license-plate").value;
    let model = document.getElementById("campo-model").value;
    let type = document.getElementById("campo-type").value;

    let dados = new FormData();
    dados.append("licensePlate", licensePlate);
    dados.append("model", model);
    dados.append("type", type);

    console.log(dados);

    fetch('/driver/vehicle/register', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            
            console.log(data);

            toastr.success("Veículo cadastrado com sucesso");

            $('#table-vehicle-driver').DataTable().ajax.reload();

            clearFieldsvehicle();

            $("#modalRegisterVehicle .btn-close").click();
        })
        .catch((error) => {
            console.log(error);

            toastr.error("Não foi possivel cadastrar o veículo");
        });
}

document.getElementById("button-register-vehicle")
    .addEventListener("click", registerVehicle);

let clearFieldsvehicle = () => {
    document.getElementById("campo-license-plate").value = '';
    document.getElementById("campo-model").value = '';
    $('#campo-type').val('').trigger('change');
}