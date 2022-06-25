window.driver_tab_name_changer = function driver_tab_name_changer() {
    var title = document.title;


    // slobodno dodavati jos poruka u titles, nije potrebno modificirati
    // ostatak koda da bi to radilo

    var titles =  [
        "Vrati nam se!", 
        "Parking te ceka!",
        "Parkiraj Me"
    ];
    var driver = null;
   
    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * ( max - min ) ) + min;
    }


     document.addEventListener("visibilitychange", function(e) {

        if(document.hidden) {
            driver = setInterval(function() {
                var prev_title = document.title;
                var num = getRandomNumber(0, titles.length - 1);
                document.title = titles[num];
                
                if (prev_title === document.title) {
                    if (num === titles.length - 1) {
                        document.title = titles[0]
                    } else {
                        document.title = titles[num + 1];
                    }
                }

            }, 200);
       } else {
           document.title = title;
           clearInterval(driver);
       }   
       
     });
}


