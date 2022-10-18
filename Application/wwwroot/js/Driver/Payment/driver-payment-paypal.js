$('table').on('click', '.vehicle-pay', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;

    let id = element.getAttribute("data-id");
    realizarPagamento(id)
});

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(realizarPagamento);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function realizarPagamento(id, position) {
    $.ajax({
        url: '/driver/paypal',
        type: "POST",
        data: { id: id, longitude: position.coords.longitude, latidude: position.coords.latitude },
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data.status) {

                let jsonresult = JSON.parse(data.response);

                console.log(jsonresult);

                let links = jsonresult.links;

                let resultado = links.find(item => item.rel === "approve")

                window.location.href = resultado.href
            }
            else {
                alert("Volte mais tarde, o serviço de pagamento não está funcionado!")
            }
        }
    });
}