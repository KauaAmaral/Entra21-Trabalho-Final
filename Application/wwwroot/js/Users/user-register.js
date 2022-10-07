let registerGuard = () => {
    let email = document.getElementById("campo-email").value;
    let name = document.getElementById("campo-nome").value;
    let cpf = document.getElementById("campo-cpf").value;
    let hierachy = document.getElementById("campo-hierarchy").value;
    let password = document.getElementById("campo-password").value;
    //let confirmPassword = document.getElementById("campo-confirm-password").value;

    let dados = new FormData();
    dados.append("email", email);
    dados.append("name", name);
    dados.append("cpf", cpf);
    dados.append("hierachy", hierachy);
    dados.append("password", password);
    console.log(dados);

    fetch('/Administrator/Users/register', {
        method: 'POST',
        body: dados
    })
        //.then((data) => {
        //    console.log(data);

        //    toastr.success("Guarda cadastrado com sucesso");

        //    $('#tabela-consultas').DataTable().ajax.reload();

        //    bootstrap.Modal.getInstance(
        //        document.getElementById('exampleModal')).hide();

        //})
        //.catch((error) => {
        //    toastr.error("Não foi possível cadastrar o guarda");

        //    console.log(error);
        //});
}

document.getElementById("buttom-register-guard")
    .addEventListener("click", registerGuard);