
// Limpar os campos quando a modal for fechada
//document.getElementById('detailsPaymentModal').addEventListener('hide.bs.modal', () => petLimparCampos());

let petEditarPreencherModal = (guardUpdate) => {
    let id = guardUpdate.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/Administrator/Guard/update?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })



        .then((data) => {
            if (statusResponse === 200) {
                let modal = new bootstrap.Modal(document.getElementById('guardUpdate'), {});
                modal.show
                //        //document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
                //        //document.getElementById('User_Name').value = data.user.name;
                document.getElementById('IdentificationNumber').value = data.identificationNumber;

                modal.show();
            }
        })
        .catch((error) => console.log(error));
};

$('table').on('click', 'button.guardUpdate', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    petEditarPreencherModal(element);
});