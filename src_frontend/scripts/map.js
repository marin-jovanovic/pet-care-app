window.onload = () => {
  (async () => {
    await map_drivers();
  })();

}

async function map_drivers() {

  // test
  // var map_inst = SingletonFactory.getInstance();
  // map_inst.add_complex_marker(15.9326851, 45.791663);

  // show my area on map
  await set_position();

  // var map_inst = SingletonFactory.getInstance();
  // let user_position = get_user_position();

  // map_inst.add_complex_marker(15.9326851, 45.791663);

  // show all markers that are in db
  show_markers();

  // test for user click
  var map_inst = SingletonFactory.getInstance();
  map_inst.single_click();

}

function get_markers() {
  return {
    // "0": {
    //   lon: "15.97357328039510", 
    //   lat: "45.79500836301534"
    // },
    // "1": {
    //   lon: "15.976148201050032", 
    //   lat: "45.805779155784435"
    // },
    "2": {
      lon: "15.97357328039518", 
      lat: "45.79500836301531"
    },
    "3": {
      lon: "15.951257301391397", 
      lat: "45.79644458901876"
    },
    "4": {
      lon: "15.938554359496676", 
      lat: "45.80996723511464"
    },
    "5": {
      lon: "15.994859291137193", 
      lat: "45.820376239569896"
    },
  }

}

function show_markers() {

  let markers = get_markers();

  var map_inst = SingletonFactory.getInstance();

  for (const key in markers) {  
    map_inst.add_marker(
      markers[key].lon, 
      markers[key].lat
    )
  };

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
          this.zoom           = 13;

          this.fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
          this.toProjection   = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
          var position       = new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);

          this.map = new OpenLayers.Map("Map");
          var mapnik         = new OpenLayers.Layer.OSM();
          this.map.addLayer(mapnik);

          this.markers = new OpenLayers.Layer.Markers( "Markers" );
          this.map.addLayer(this.markers);

          this.map.setCenter(position, this.zoom);



      }

      add_user_marker(lon, lat) {


        let position = new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);

        let marker = new OpenLayers.Marker(position);
        marker["icon"]["url"] = "../resources/OpenLayers-2.13.1/img/marker-blue.png"
        this.markers.addMarker(marker);
      
        let title = "title "

        // marker.events.register("click", marker, function(e){
        //   console.log("clicked", marker)

        // });


        
        marker.events.register("click", marker, function(e){
          console.log("clicked", marker)

          let marker_id = marker["icon"]["imageDiv"]["id"] 
          console.log(marker["icon"]["imageDiv"]["id"])
          document.getElementById(marker_id + "_innerImage").src = "../resources/OpenLayers-2.13.1/img/marker-green.png"

          // document.getElementById(marker["icon"]["attributes"])

          // marker["icon"]["url"] = "../resources/OpenLayers-2.13.1/img/marker.png"

          // markers.removeMarker(marker)

          // popup = new OpenLayers.Popup.FramedCloud("chicken",
          //     marker.lonlat,
          //     new OpenLayers.Size(200, 200),
          //     title,
          //     null, false );


          // var poPrompt = new OpenLayers.Popup('name',
          //                           null,
          //                           poSize,
          //                           '',
          //                           false);

          // this.map.addPopup(popup);
        });


        // console.log("user marker", marker)

        // var markers = new OpenLayers.Layer.Markers("Markers");

        // let markers = map_inst.markers;
        // let map = map_inst.map;
        // let listd = {
        //   0 : {
        //     Longitude: "15.97357328039510",
        //     Latitude: "45.79500836301534",
        //     Title: "icon 0",
        //     IconPath: "../resources/index.png"

        //   },
        //   1 : {
        //     Longitude: "15.976148201050032",
        //     Latitude: "45.805779155784435",
        //     Title: "icon 1",
        //     IconPath: "../resources/index.png"

        //   }
        // }

        // for(var i = 0; i < listd.length; i++)
        // { 
        //     console.log(i)

        //     var lonLat = new OpenLayers.LonLat(listd[i].Longitude, listd[i].Latitude);

        //     var title = listd[i].Title;
        //     var iconPath = listd[i].IconPath;
        //     var size = new OpenLayers.Size(15, 22);
        //     var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);

        //     var icon = new OpenLayers.Icon(iconPath, size, offset);
        //     var marker = new OpenLayers.Marker(lonLat, icon.clone());

        //     markers.addMarker(marker);

        //     marker.events.register("click", marker, function(e){
        //       popup = new OpenLayers.Popup.FramedCloud("chicken",
        //           marker.lonlat,
        //           new OpenLayers.Size(200, 200),
        //           title,
        //           null, false );
        //         map.addPopup(popup);
        //     });

        //  } 
        //  map.addLayer(markers);

      }

      add_marker(lon, lat) {

          let position = new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);

          let marker = new OpenLayers.Marker(position);
          this.markers.addMarker(marker);
        
          // this.markers.removeMarker(marker)

          let title = "title "


          marker.events.register("click", marker, function(e){

            console.log("clicked", marker)
            
            try {
              let selected_marker = document.getElementById("selected_marker") 
              console.log("prev", selected_marker)
              selected_marker.id = selected_marker.tmp 
              selected_marker.src = "../resources/OpenLayers-2.13.1/img/marker.png"
              console.log("changing")
            }  catch(e) {

            }


            let marker_id = marker["icon"]["imageDiv"]["id"] 
            console.log(marker["icon"]["imageDiv"]["id"])
            document.getElementById(marker_id + "_innerImage").src = "../resources/OpenLayers-2.13.1/img/marker-green.png"
  
            document.getElementById(marker_id + "_innerImage").tmp = marker_id + "_innerImage"
            document.getElementById(marker_id + "_innerImage").id = "selected_marker"
            console.log(document.getElementById("selected_marker").id)
            console.log(document.getElementById("selected_marker").tmp)
            // popup = new OpenLayers.Popup.FramedCloud("chicken",
            //     marker.lonlat,
            //     new OpenLayers.Size(200, 200),
            //     title,
            //     null, false );
            //   map.addPopup(popup);
          });
          // this.markers.events.trigger("click", marker)

      }

      set_position(lon, lat) {

        console.log("set postion")
        
        var position = new OpenLayers.LonLat(lon, lat).transform( this.fromProjection, this.toProjection);
        this.map.setCenter(position, this.zoom);

      }

      single_click() {
        /**
         * activate click
         * return click lon lat
         * deactivate click
         */

        let is_first = true;

        let clicked_val = 

        //Set up a click handler
        OpenLayers.Control.Click = OpenLayers.Class(OpenLayers.Control, {                
          defaultHandlerOptions: {
              'single': true,
              'double': false,
              'pixelTolerance': 0,
              'stopSingle': false,
              'stopDouble': false
          },

          initialize: function(options) {
              this.handlerOptions = OpenLayers.Util.extend(
                  {}, this.defaultHandlerOptions
              );
              OpenLayers.Control.prototype.initialize.apply(
                  this, arguments
              ); 
              this.handler = new OpenLayers.Handler.Click(
                  this, {
                      'click': this.trigger
                  }, 
                  this.handlerOptions
              );
                
              // return this.handler;

                // console.log(options)

          }, 

          trigger: function(e) {
              //A click happened!
              var lonlat = this.map.getLonLatFromViewPortPx(e.xy)

              lonlat.transform(
                new OpenLayers.Projection("EPSG:900913"), 
                new OpenLayers.Projection("EPSG:4326")
              );

                if (is_first) {
                  console.log("first click");
                  is_first = false;

                  // alert("You clicked near " + lonlat.lat + " N, " +
                  //                           + lonlat.lon + " E");
                  console.log(lonlat.lon, lonlat.lat);

                } else {
                  console.log("not first click");

                }

                // callbacks.point();

                // return 5;
                // e.callbacks.point;
                // console.log(lonlat.lon, lonlat.lat);

          }

        });

        var click = new OpenLayers.Control.Click();
        this.map.addControl(click);
        click.activate();
        // console.log(click)


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

async function get_user_position(cb) {

  const JELACIC = { 
    lat: 45.813138, 
    lon: 15.977264
  };

  if (navigator.geolocation) {



    navigator.geolocation.getCurrentPosition(

        (position) => {

            userLocation = {
                lat: position.coords.latitude,
                lon: position.coords.longitude,
            };

            cb(userLocation.lon, userLocation.lat);
        },

        () => {
        
          cb(JELACIC.lon, JELACIC.lat);

        }
    );
  } else {
    cb(JELACIC.lon, JELACIC.lat);
  }
} 



async function set_position() {

  let map_inst = SingletonFactory.getInstance();

  // let user_position = get_user_position(test_cb);
  // let user_position = await get_user_position(cb_add_user_marker);

  await get_user_position((lon, lat) => {
  
    console.log("cb for add user marker");
  
    let map_inst = SingletonFactory.getInstance();
    map_inst.add_user_marker(lon, lat);
  
  })

  // let user_position = await get_user_position();

  // console.log("user position", user_position);

  // map_inst.set_position(user_position.lon, user_position.lat);
  
  // if (navigator.geolocation) {



  //     navigator.geolocation.getCurrentPosition(

  //         (position) => {

  //             userLocation = {
  //                 lat: position.coords.latitude,
  //                 lng: position.coords.longitude,
  //             };

  //             console.log("user location", userLocation)
        
          
  //         },

  //         () => {
  
  //         }

  //     );

  // } 
  
}

// function njihov_nativ() {
//   var lat            = 47.35387;
//   var lon            = 8.43609;
//   var zoom           = 18;

//   var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
//   var toProjection   = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection
//   var position       = new OpenLayers.LonLat(lon, lat).transform( fromProjection, toProjection);

//   map = new OpenLayers.Map("Map");
//   var mapnik         = new OpenLayers.Layer.OSM();
//   map.addLayer(mapnik);

//   var markers = new OpenLayers.Layer.Markers( "Markers" );
//   map.addLayer(markers);
//   markers.addMarker(new OpenLayers.Marker(position));

//   map.setCenter(position, zoom);

// }
