
// Limpar os campos quando a modal for fechada
//document.getElementById('detailsPaymentModal').addEventListener('hide.bs.modal', () => petLimparCampos());

let petEditarPreencherModal = (userUpdate) => {
    let id = userUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/Administrator/Users/update?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })



        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('userUpdate'), {});
                modal.show
                //        //document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
                //        //document.getElementById('User_Name').value = data.user.name;
                document.getElementById('IdentificationNumber').value = data.identificationNumber;

                modal.show();
            }
        })
        .catch((error) => console.log(error));
};

$('table').on('click', 'button.userUpdate', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    petEditarPreencherModal(element);
});

//document.getElementById('saveUser')
//    .addEventListener('click', () => petHandleCadastrarButton());

//let petHandleCadastrarButton = () => {
//    let id = document.getElementById('cadastroUserModalId').value;
//    let formData = userCadastroEditarGerarFormData();

//    if (id === '') {
//        userCadastrarUser(formData);
//        return;
//    }

//    formData.append('id', id);

//    userEditarUser(formData);
//}

//let guardLimparCampos = () => {
//    document.getElementById('cadastroGuardModalId').value = '';
//    document.getElementById('IdentificationNumber').value = '';
//}

//let guardCadastroEditarGerarFormData = () => {
//    let identificationNumber = document.getElementById('IdentificationNumber').value

//    let formData = new FormData();
//    formData.append('identificationNumber', identificationNumber);

//    return formData;
//}

//let guardEditarGuard = (formData) => {
//    let statusResponse = 0;

//    fetch('/administrator/guard/update', {
//        method: 'POST',
//        body: formData
//    })
//        .then((response) => {
//            statusResponse = response.status;

//            return response.json();
//        })
//        .then((data) => {
//            if (statusResponse === 200) {
//                bootstrap.Modal.getInstance(document.getElementById('guardUpdate')).hide();

//                guardLimparCampos();

//                $('#guard-Id').DataTable().ajax.reload();

//                toastr.success('Guarda alterado com sucesso');

//                return;
//            }

//            showNotificationErrorsOfValidation(data);
//        })
//        .catch((error) => {
//            console.error(error);

//            toastr.error('Não foi possível alterar o Guarda');
//        });
//};

//let guardCadastrarGuard = (formData) => {
//    let statusResponse = 0;

//    fetch('/administrator/guard/register', {
//        method: 'POST',
//        body: formData
//    })
//        .then((response) => {
//            statusResponse = response.status;

//            return response.json();
//        })
//        .then((data) => {
//            if (statusResponse === 200) {
//                bootstrap.Modal.getInstance(document.getElementById('guardUpdate')).hide();

//                guardLimparCampos();

//                $('#guard-Id').DataTable().ajax.reload();

//                toastr.success('Guarda cadastrado com sucesso');

//                return;
//            }

//            showNotificationErrorsOfValidation(data);
//        })
        //.catch((error) => {
        //    console.error(error);

        //    toastr.error('Não foi possivel cadastrar o Guarda');
        //});
}