// TODO: Guad - Wellinton Ajustar Validações 
//let alturaMask = IMask(document.getElementById('cadastroGuardaModalCpf'), {
//    mask: Number,  // enable number mask
//    scale: 2,  // digits after point, 0 for integers
//    signed: false,  // disallow negative
//    thousandsSeparator: '',  // any single char
//    padFractionalZeros: true,  // if true, then pads zeros at end to the length of scale
//    normalizeZeros: true,  // appends or removes zeros at ends
//    radix: ',',  // fractional delimiter
//    mapToRadix: ['.'],  // symbols to process as radix
//    // additional number interval options (e.g.)
//    min: 0,
//    max: 1.60
//});

//let alturaMask = IMask(document.getElementById('cadastroGuardaModalNumeroIdentificacao'), {
//    mask: Number,  // enable number mask
//    scale: 2,  // digits after point, 0 for integers
//    signed: false,  // disallow negative
//    thousandsSeparator: '',  // any single char
//    padFractionalZeros: true,  // if true, then pads zeros at end to the length of scale
//    normalizeZeros: true,  // appends or removes zeros at ends
//    radix: ',',  // fractional delimiter
//    mapToRadix: ['.'],  // symbols to process as radix
//    // additional number interval options (e.g.)
//    min: 0,
//    max: 1.60
//});

document.getElementById('registerGuardModalSave')
    .addEventListener('click', () => guardHandleRegisterButton());


let guardHandleRegisterButton = () => {
    let id = document.getElementById('registerGuardModalId').value;
    let formData = guardRegisterUpdateGenerateFormData();

    if (id === '') {
        guardRegisterGuard(formData);
        return;
    }

    formData.append('id', id);

    guardUpdateGuard(formData);
}

let guardClearFields = () => {
    document.getElementById('cadastroGuardaModalId').value = '';
    document.getElementById('cadastroGuardaModalNome').value = '';
    document.getElementById('cadastroGuardaModalCpf').value = '';
    document.getElementById('cadastroGuardaModalNumeroIdentificacao').value = '';
}

let guardRegisterUpdateGenerateFormData = () => {
    let nome = document.getElementById('cadastroGuardaModalNome').value;
    let cpf = document.getElementById('cadastroGuardaModalCpf').value;
    let numeroIdentificacao = document.getElementById('cadastroGuardaModalNumeroIdentificacao').value;

    cpf = cpf.replace('.', '').replace('-', '').trim();
    numeroIdentificacao = cpf.replace('.', '').replace('-', '').trim();

    let formData = new FormData();
    formData.append('nome', nome);
    formData.append('cpf', cpf);
    formData.append('numeroIdentificacao', numeroIdentificacao);

    return formData;
};

let guardRegisterGuard = (formData) => {
    let statusResponse = 0;

    fetch('/guarda/cadastrar', {
        method: 'POST',
        body: formData
    })
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            if (statusResponse === 200) {
                bootstrap.Modal.getInstance(document.getElementById('registerGuardModal')).hide();

                guardClearFields();

                $('#guard-table').DataTable().ajax.reload();

                toastr.success('Guarda cadastrado com sucesso');

                return;
            }

            showNotificationErrorsOfValidation(data);
        })
        .catch((error) => {
            console.error(error);

            toastr.error('Não foi possível cadastrar o Guarda');
        });
}