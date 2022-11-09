$('div').on('click', '.notification-pay', (event) => {
    let id = element.getAttribute("data-id");
    payment(id)
});

function payment(id) {
    debugger;
    $.ajax({
        url: 'Paypal/Notification',
        type: "POST",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data.status) {

                var jsonresult = JSON.parse(data.response);

                console.log(jsonresult);

                var links = jsonresult.links;

                var resultado = links.find(item => item.rel === "approve")

                window.location.href = resultado.href
            }
            else {
                alert("Já esta pago ou Fora da data limite")
                window.location.href = "https://localhost:7121"
            }
        }
    });
}