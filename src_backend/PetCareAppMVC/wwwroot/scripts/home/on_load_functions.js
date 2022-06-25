
window.onload = function() {
   
    driver_tab_name_changer();

    $("#registerFormU").slideUp();
    $("#registerFormC").slideUp();

      // za pocetnu animaciju s logotipom
      const tl = gsap.timeline({ defaults: { ease: "power1.out" } });

  
      // ne prepoznaje
      tl.to(".text", { y: "0%", duration: 1, stagger: 0.25 });
      // tl.to(".text", { y: "0%", duration: 0, stagger: 0.25 });
      
      // ne prepoznaje
      tl.to(".slider", { y: "-100%", duration: 1.5, delay: 0.5 });
      // tl.to(".slider", { y: "-100%", duration: 0, delay: 0.5 });
  
      try {
        tl.to(".intro", { y: "-100%", duration: 1 }, "-=1");
        // tl.to(".intro", { y: "-100%", duration: 0 }, "-=1");

      } catch(error) {

      }

      tl.fromTo(".landing", { opacity: 0 }, { opacity: 1, duration: 1 }, "-=1");

}
