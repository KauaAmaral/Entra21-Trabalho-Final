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

            toastr.success("Consulta agendada com sucesso");

            $('#vehicles-id').DataTable().ajax.reload();

            bootstrap.Modal.getInstance(
                document.getElementById('modalRegisterVehicle')).hide();//exampleModal id da modal do bootstrap
        })
        .catch((error) => {
            toastr.error("Não foi possivel agendar a consulta");

            console.log(error);
        });
}

document.getElementById("button-register-vehicle")
    .addEventListener("click", registerVehicle);