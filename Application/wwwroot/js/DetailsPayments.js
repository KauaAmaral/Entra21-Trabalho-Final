$('table').on('click', 'button.detailsPayments', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    petEditarPreencherModal(element);
});
let modal = new bootstrap.Modal(document.getElementById('detailsPaymentModal'), {});
modal.show();

// Limpar os campos quando a modal for fechada
document.getElementById('detailsPaymentModal').addEventListener('hide.bs.modal', () => petLimparCampos());

let petEditarPreencherModal = (botaoEditar) => {
    let id = botaoEditar.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/administrator/Payments/details?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        //.then((data) => {
        //    if (statusResponse === 200) {

        //        document.getElementById('cadastroPetModalLabel').innerText = `Editar PET: ${data.nome}`
        //        document.getElementById('cadastroPetModalId').value = data.id;
        //        document.getElementById('cadastroPetModalNome').value = data.nome;
        //        document.getElementById('cadastroPetModalIdade').value = data.idade;
        //        document.getElementById('cadastroPetModalAltura').value = String(data.altura).replace('.', ',');
        //        document.getElementById('cadastroPetModalPeso').value = String(data.peso).replace('.', ',');

        //        if (data.genero === 0)
        //            document.getElementById('cadastroPetGeneroFeminino').checked = true;
        //        else
        //            document.getElementById('cadastroPetGeneroMasculino').checked = true;

        //        $('#cadastroPetModalResponsavel')
        //            .append(new Option(data.responsavel.nomeCompleto, data.responsavel.id, false, false))
        //            .val(data.responsavel.id)
        //            .trigger('change');
        //        $('#cadastroPetModalRaca')
        //            .append(new Option(data.raca.nome, data.raca.id, false, false))
        //            .val(data.raca.id)
        //            .trigger('change');

        //    }
        //})
        //.catch((error) => console.log(error));
};
