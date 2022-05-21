window.onload = () => {

  set_position();
}

var SingletonFactory = (function(){
  class SingletonClass {

      constructor() {
          const JELACIC = { 
              lat: 45.813138, 
              lng: 15.977264
          };

          var lat            = JELACIC.lat;
          var lon            = JELACIC.lng;
          var zoom           = 18;

          this.fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
          this.toProjection   = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
          var position       = new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);

          this.map = new OpenLayers.Map("Map");
          var mapnik         = new OpenLayers.Layer.OSM();
          this.map.addLayer(mapnik);

          this.markers = new OpenLayers.Layer.Markers( "Markers" );
          this.map.addLayer(this.markers);
          this.markers.addMarker(new OpenLayers.Marker(position));

          this.map.setCenter(position, zoom);


      }

      add_marker(lon, lat) {

          console.log("marker", lon, lat)

          // var position = 
          //     new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);


          let marker =   new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);

          this.markers.addMarker(new OpenLayers.Marker(marker));

      }


  }
  var instance;
  return {
      getInstance: function(){
          if (instance == null) {
              instance = new SingletonClass();
              // Hide the constructor so the returned object can't be new'd...
              instance.constructor = null;
          }
          return instance;
      }
};
})();

function set_position() {


  var map_inst = SingletonFactory.getInstance();

  map_inst.add_marker(1, 2);
  map_inst.add_marker(45.791663, 15.9326851);

  // const JELACIC = { 
  //     lat: 45.813138, 
  //     lng: 15.977264
  // };

  // let userLocation = JELACIC;

  // (async () => {

  // })();

  if (navigator.geolocation) {



      navigator.geolocation.getCurrentPosition(

          (position) => {

              userLocation = {
                  lat: position.coords.latitude,
                  lng: position.coords.longitude,
              };

              console.log("user location", userLocation)

              map_inst.add_marker(userLocation.lat, userLocation.lng)

              // new google.maps.Marker({
              //     position: userLocation,
              //     map: map,
              // });
          
              // map.setCenter(userLocation);
          
          },

          () => {
              // TODO
              console.log("nije dat pristup lokaciji")

              userLocation = JELACIC;

              new google.maps.Marker({
                  position: userLocation,
                  map: map,
              });

          }

      );

  } else {
      console.log("geol not dop")
  }

  // console.log("after location", userLocation)

  // var lat            = userLocation.lat;
  // var lon            = userLocation.lng;
  // var zoom           = 18;

  // var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
  // var toProjection   = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
  // var position       = new OpenLayers.LonLat(lon, lat).transform( fromProjection, toProjection);

  // map = new OpenLayers.Map("Map");
  // var mapnik         = new OpenLayers.Layer.OSM();
  // map.addLayer(mapnik);

  // // var markers = new OpenLayers.Layer.Markers( "Markers" );
  // // map.addLayer(markers);
  // // markers.addMarker(new OpenLayers.Marker(position));

  // map.setCenter(position, zoom);

}

function njihov_nativ() {
  var lat            = 47.35387;
  var lon            = 8.43609;
  var zoom           = 18;

  var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
  var toProjection   = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
  var position       = new OpenLayers.LonLat(lon, lat).transform( fromProjection, toProjection);

  map = new OpenLayers.Map("Map");
  var mapnik         = new OpenLayers.Layer.OSM();
  map.addLayer(mapnik);

  var markers = new OpenLayers.Layer.Markers( "Markers" );
  map.addLayer(markers);
  markers.addMarker(new OpenLayers.Marker(position));

  map.setCenter(position, zoom);

}
