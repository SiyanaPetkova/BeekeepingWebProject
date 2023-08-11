let mapOptions = {
    center: [42.69589761051528, 25.307006835937504],
    zoom: 10
}

let map = new L.map('map', mapOptions);

let layer = new L.TileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png');
map.addLayer(layer);


let marker = null;
map.on('click', (event) => {

    if (marker !== null) {
        map.removeLayer(marker);
    }

    marker = L.marker([event.latlng.lat, event.latlng.lng]).addTo(map);

    document.getElementById('latitude').value = event.latlng.lat;
    document.getElementById('longitude').value = event.latlng.lng;
})