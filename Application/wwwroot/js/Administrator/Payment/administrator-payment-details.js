let petEditarPreencherModal = (detailsPayments) => {
    let id = detailsPayments.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/administrator/Payments/details?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })

        .then((data) => {
            if (statusResponse === 200) {
                document.getElementById('User_Name').value = data.user.name;
                let modal = new bootstrap.Modal(document.getElementById('detailsPayments'), {});
                modal.show();
                document.getElementById('User_Cpf').value = data.user.cpf;
                document.getElementById('User_Email').value = data.user.email;
                document.getElementById('User_Phone').value = data.user.phone;
                document.getElementById('Vehicle_Model').value = data.vehicle.model;
                document.getElementById('Vehicle_LicensePlate').value = data.vehicle.licensePlate;
                document.getElementById('TransactionId').value = data.transactionId;
                document.getElementById('Value').value = data.value;
                document.getElementById('PayerId').value = data.payerId;
            }
        })
        .catch((error) => console.log(error));
}

$('table').on('click', '.payment-details', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    petEditarPreencherModal(element);
});