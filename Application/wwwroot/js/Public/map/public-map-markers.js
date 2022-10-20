$(document).ready(function () {
    getLocations();
});

function myMap(locations, position) {
    //const uluru = { lat: -31.56391, lng: 147.154312 };

    var mapProp = {
        center: new google.maps.LatLng({ lat: -26.9179821, lng: -49.0672724 }),
        zoom: 15,
    };

    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    const markers = locations.map((position, i) => {
        const marker = new google.maps.Marker({
            position: locations[i],
            map: map,
        });
        return marker;
    });

}

let getLocations = () => {
    let statusResponse = 0;

    fetch(`/public/map/getLocations`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })
        .then((data) => {
            debugger;
            var locations = data;
            myMap(locations);
        })
        .catch((error) => console.log(error));
}