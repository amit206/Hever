
var map;
function initMap() {

    var mapOptions = {
        mapTypeId: 'roadmap',
    };

    // Display a map on the page
    map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    map.setTilt(45);
    bounds = new google.maps.LatLngBounds();

    var marker, i;
    var geocoder = new google.maps.Geocoder();

    var address = $('.address')[0].innerText;
    var title = $('.title')[0].innerText;
    console.log(address);
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {
            var position = new google.maps.LatLng(results[0].geometry.location.lat(), results[0].geometry.location.lng());
            bounds.extend(position);
            marker = new google.maps.Marker({
                position: position,
                map: map,
                title: "hi"
            });

            var infoWindow = new google.maps.InfoWindow();
            infoWindow.setContent(title);
            infoWindow.open(map, marker);

            // Automatically center the map fitting all markers on the screen
            map.fitBounds(bounds);
        }
    });
}
