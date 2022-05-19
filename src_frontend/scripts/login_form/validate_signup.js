window.onload = (event) => {

  autocomplete(document.getElementById("input__card__year"), get_years());  

  autocomplete(document.getElementById("input__card__month"), get_months());  

  delete_init();

  change_listeners_init();

};

function change_listeners_init() {
  console.log("change");

  [
    "input__username__err", 
    "input__OIB__err", 
    "input__firstname__err",  
    "input__lastname__err",
    "input__email__err",
    "input__cardnumber__err",
    "input__card__month__err",
    "input__card__year__err",
    "input__password__err",
    "input__password_repeat__err"
  ].forEach(element => {
    // console.log(element)  
    show_element(element, false);

  });

  show_element("input__card__type", false);
 
  init_username_listeners();
  init_oib_listeners();
  init_firstname_listeners();
  init_lastname_listeners();
  init_email_listeners();
  init_card_number_listeners();
  init_card_month_listeners();
  init_card_year_listeners();
  init_password_listeners();
  init_password_repeat_listeners();
  
}

function init_generic_listeners(id_selector, id_selector_err, additional_control) {

  let element = document.getElementById(id_selector)

  let is_entered = false;

  runner();
  
  element.onkeyup = function() {
    is_entered= true;
    
    runner();
  }
  
  element.onfocus = function() {
    is_entered= true;
  }

  element.onblur = function() {
    runner();
  }

  function runner() {
    console.log("runner", id_selector)

    if (is_entered) {
      console.log(id_selector, "entered")

      if (document.getElementById(id_selector).value === '') {
        document.getElementById(id_selector).style= "border: 2px solid red;"
        document.getElementById(id_selector_err).innerText= id_selector + " OIB ne može biti prazan. "

        show_element(id_selector_err, true);
        return
      }  
    } else {
      if (document.getElementById(id_selector).value === '') {
        
        set_red(id_selector);
        return
      }
    }

    if (additional_control(document.getElementById(id_selector).value)) {
      console.log("addition control passed for", id_selector)
 
      show_element(id_selector_err, false);
      set_green(id_selector);
 
    } else {
      console.log("add control failed for", id_selector)
      set_red(id_selector);

    }

  }
  
}

function set_red(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid #609;"
}

function set_green(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid green;"

}

function set_blue(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid red;"
}

function init_username_listeners() {

  let id_selector = "input__username"
  let id_selector_err = "input__username__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control username", value)
    return true;
  }) 


  // let is_entered = false;

  // let id = "input__username"
  // let element = document.getElementById(id)
  // runner();
  
  // element.onkeyup = function() {
  //   is_entered= true;
    
  //   runner();
  // }
  
  // element.onfocus = function() {
  //   is_entered= true;
  // }

  // element.onblur = function() {
  //   runner();
  // }

  // function runner() {
  //   console.log("username validation")
  //   let id_selector = "input__username"
  //   let id_selector_err = "input__username__err"

  //   if (is_entered) {
  //     if (document.getElementById(id_selector).value === '') {
  //       document.getElementById(id_selector).style= "border: 2px solid red;"
  //       show_element(id_selector_err, true);
  //       return
  //     }  
  //   } else {
  //     if (document.getElementById(id_selector).value === '') {
  //       document.getElementById(id_selector).style= "border: 2px solid #609;"
  //       return
  //     }
  //   }

  //   document.getElementById(id_selector).style= "border: 2px solid yellow;"

  // }

}

function init_oib_listeners() {

  let id_selector = "input__OIB"
  let id_selector_err = "input__OIB__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control oib", value)
    if (document.getElementById(id_selector).value.length === 11) {
      console.log("oib length ok")
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
      return false
    }

  }) 

  // let id = "input__username"
  // let id_selector = "input__OIB"
  // let id_selector_err = "input__OIB__err"
  // let element = document.getElementById(id)

  // let is_entered = false;

  // runner();
  
  // element.onkeyup = function() {
  //   is_entered= true;
    
  //   runner();
  // }
  
  // element.onfocus = function() {
  //   is_entered= true;
  // }

  // element.onblur = function() {
  //   runner();
  // }

  // function runner() {
  //   // console.log("oib validation")



  //   if (is_entered) {
  //     console.log("oib entered")

  //     if (document.getElementById(id_selector).value === '') {
  //       document.getElementById(id_selector).style= "border: 2px solid red;"
  //       document.getElementById(id_selector_err).innerText= " OIB ne može biti prazan. "

  //       show_element(id_selector_err, true);
  //       return
  //     }  
  //   } else {
  //     if (document.getElementById(id_selector).value === '') {
        
  //       document.getElementById(id_selector).style= "border: 2px solid #609;"
  //       return
  //     }
  //   }

  //   if (document.getElementById(id_selector).value.length === 11) {
  //     console.log("oib length ok")
  //     show_element(id_selector_err, false);
  //     document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //   } else {
  //     console.log("oib length error")
  //     show_element(id_selector_err, true);
  //     document.getElementById(id_selector_err).innerText= " OIB nije valjanog formata, mora sadržavati 11 brojeva. "
  //     document.getElementById(id_selector).style= "border: 2px solid red;"
  //   }


  // }
  

}

function init_firstname_listeners() {
  let id_selector = "input__firstname"
  let id_selector_err = "input__firstname__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control firstname", value)
    return true;
  }) 

  // let id = document.getElementById("input__firstname")

  // id.onkeyup = function() {
  //   validate_firstname();
  // }
  
  // id.onfocus = function() {
  //   validate_firstname();
  // }

//  init_generic_listeners(id_selector, id_selector_err, () => {})

//   function validate_firstname() {

//     document.getElementById(id_selector).addEventListener("change", (event) => {
//       let id_selector = "input__firstname"
//       let id_selector_err = "input__firstname__err"
//         let value = document.getElementById("input__firstname").value; 
//       if (value === '') {
//         console.log("firstname empty")
//         show_element(id_selector_err, false);
//         return;
//       } else {
//         console.log("firstname ok")
//         show_element(id_selector_err, false);
//         document.getElementById(id_selector).style= "border: 2px solid yellow;"
//       }
//     });
  
//   }
  
  


}

function init_lastname_listeners() {

  let id_selector = "input__lastname"
  let id_selector_err = "input__lastname__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control ", value)
    return true;
  }) 


  // let id = document.getElementById("input__lastname")

  // id.onkeyup = function() {
  //   validate_lastname();
  // }
  
  // id.onfocus = function() {
  //   validate_lastname();
  // }

  // function validate_lastname() {
  //   id_selector = "input__lastname"
  //   id_selector_err = "input__lastname__err"
  //   document.getElementById(id_selector).addEventListener("change", (event) => {
  //     let id_selector = "input__lastname"
  //     let id_selector_err = "input__lastname__err"
  //       let value = document.getElementById("input__lastname").value; 
  //     if (value === '') {
  //       console.log("lastname empty")
  //       show_element(id_selector_err, false);
  //       return;
  //     } else {
  //       console.log("lastname ok")
  //       show_element(id_selector_err, false);
  //       document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //     }
  //   });
  
  // }
  

}

function init_email_listeners() {

  let id_selector = "input__email"
  let id_selector_err = "input__email__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control", value)
   
    if (! isEmailValid(value)) {
      console.log("email validation err")
      show_element(id_selector_err, true);
      return false;
    } 

    return true;
  }) 

  // function validate_email() {
  //   id_selector = "input__email"
  //   id_selector_err = "input__email__err"
  //   document.getElementById(id_selector).addEventListener("change", (event) => {
  //     let id_selector = "input__email"
  //     let id_selector_err = "input__email__err"
  //       let value = document.getElementById("input__email").value; 
  //     if (value === '') {
  //       console.log("email empty")
  //       show_element(id_selector_err, false);
  //       return;
  //     } else if (! isEmailValid(value)) {
  //       console.log("email validation err")
  //       show_element(id_selector_err, true);
  //       return;
  //     } else {
  //       console.log("email ok")
  //       show_element(id_selector_err, false);
  //       document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //     }
  //   });
  
  // }

  // let id = document.getElementById("input__email")

  // id.onkeyup = function() {
  //   validate_email();
  // }
  
  // id.onfocus = function() {
  //   validate_email();
  // }

}

function init_card_number_listeners() {

  let id_selector = "input__cardnumber"
  let id_selector_err = "input__cardnumber__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control cardnumber", value)

      
    let card = creditCardValidation(value);
  
    if (card === undefined) {
      console.log("input__cardnumber err")
      show_element(id_selector_err, true);
      return false;
  
    } else {
      console.log("card", card)
      show_element(id_selector_err, false);
      // document.getElementById(id_selector).style= "border: 2px solid yellow;"
      show_element("input__card__type", true);
      document.querySelector("#input__card__type > td:nth-child(1) > span:nth-child(1) > input:nth-child(1)").value= card 
      // document.getElementById("input__cardnumber__type").style= "border: 2px solid yellow;"
    
      return true;
    }

  }) 


  // let id = document.getElementById("input__cardnumber")

  // id.onkeyup = function() {
  //   validate_cardnumber();
  // }
  
  // id.onfocus = function() {
  //   validate_cardnumber();
  // }

  // function validate_cardnumber() {
  //   id_selector = "input__cardnumber"
  //   id_selector_err = "input__cardnumber__err"
  //   document.getElementById(id_selector).addEventListener("change", (event) => {
  //     let id_selector = "input__cardnumber"
  //     let id_selector_err = "input__cardnumber__err"
  //       let value = document.getElementById("input__cardnumber").value; 
  //     if (value === '') {
  //       console.log("input__cardnumber empty")
  //       show_element(id_selector_err, false);
  //       return;
  //     } 
      
  //     let card = creditCardValidation(value);
  
  //     if (card === undefined) {
  //       console.log("input__cardnumber err")
  //       show_element(id_selector_err, true);
  //       return;
    
  //     } else {
  //       console.log("card", card)
  //       show_element(id_selector_err, false);
  //       document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //       show_element("input__card__type", true);
  //       document.querySelector("#input__card__type > td:nth-child(1) > span:nth-child(1) > input:nth-child(1)").value= card 
  //       document.getElementById("input__cardnumber__type").style= "border: 2px solid yellow;"
  //     }
  //   });
  
  // }


}

function init_card_month_listeners() {

  let id_selector = "input__card__month"
  let id_selector_err = "input__card__month__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control cardnumber", value)

    if (! is_month_valid(value)) {
      console.log("input__card__month validation err")
      show_element(id_selector_err, true);
      return false;
    } else {
      console.log("month ok")
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
      return true;
    }

  }) 

  // let input_card_month = document.getElementById("input__card__month")

  // input_card_month.onkeyup = function() {
  //   validate_card_month();
  // }
  
  // input_card_month.onfocus = function() {
  //   validate_card_month();
  // }

  // function validate_card_month() {
  //   id_selector = "input__card__month"
  //   id_selector_err = "input__card__month__err"
  //   document.getElementById(id_selector).addEventListener("change", (event) => {
  //     let id_selector = "input__card__month"
  //     let id_selector_err = "input__card__month__err"
  //       let value = document.getElementById("input__card__month").value; 
  //     if (value === '') {
  //       console.log("input__card__month empty")
  //       show_element(id_selector_err, false);
  //       return;
  //     } else if (! is_month_valid(value)) {
  //       console.log("input__card__month validation err")
  //       show_element(id_selector_err, true);
  //       return;
  //     } else {
  //       console.log("month ok")
  //       show_element(id_selector_err, false);
  //       document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //     }
  //   });
  // }
  

}

function init_card_year_listeners() {
  
  id_selector = "input__card__year"
  id_selector_err = "input__card__year__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control cardnumber", value)

    if (! is_year_valid(value)) {
      console.log("input__card__year validation err")
      show_element(id_selector_err, true);
      return false;
    } else {
      console.log("card year ok")
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
      return true;
    }
  });

  // }) 


  // let input_card_year = document.getElementById("input__card__year")

  // input_card_year.onkeyup = function() {
  //   validate_card_year();
  // }
  
  // input_card_year.onfocus = function() {
  //   validate_card_year();
  // }

  // function validate_card_year() {
  //   id_selector = "input__card__year"
  //   id_selector_err = "input__card__year__err"
  //   document.getElementById(id_selector).addEventListener("change", (event) => {
  //     let id_selector = "input__card__year"
  //     let id_selector_err = "input__card__year__err"
  //     let value = document.getElementById("input__card__year").value; 
      
  //     if (value === '') {
  //       console.log("input__card__y empty")
  //       show_element(id_selector_err, false);
  //       return;
  //     } else if (! is_year_valid(value)) {
  //       console.log("input__card__year validation err")
  //       show_element(id_selector_err, true);
  //       return;
  //     } else {
  //       console.log("card year ok")
  //       show_element(id_selector_err, false);
  //       document.getElementById(id_selector).style= "border: 2px solid yellow;"
  //     }
  //   });
  
  // }

}

function init_password_listeners() {

  // // https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_password_val
  // var input_password = document.getElementById("input__password");

  // // When the user clicks on the password field, show the message box
  // input_password.onfocus = function() {
  //   // document.getElementById("message").style.display = "block";
  //   let id ="input__password__err";
  //   // show_element(id, true);
  // }

  // // When the user clicks outside of the password field, hide the message box
  // input_password.onblur = function() {
  //   // document.getElementById("message").style.display = "none";

  //   let id = "input__password__err";
  //   // show_element(id, false);
  
  // }

  // When the user starts to type something inside the password field
  // input_password.onkeyup = function() {
  //   validate_password(input_password) ;   
  // }


  id_selector = "input__password"
  id_selector_err = "input__password__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control pass", value)


    let input_password = value;

    let msg ="Lozinka nije dovoljno sigurna; ";
  
    let to_contain = [];
    let other_conditions = [];
  
    var lowerCaseLetters = /[a-z]/g;
    if(! (input_password.value.match(lowerCaseLetters))) {  
      
      to_contain.push("barem jedno malo slovo");
    }
    
    var upperCaseLetters = /[A-Z]/g;
    if(! (input_password.value.match(upperCaseLetters))) {  
      to_contain.push("barem jedno veliko slovo");
    }
  
    var numbers = /[0-9]/g;
    if(! (input_password.value.match(numbers))) {  
      to_contain.push("barem jedan broj");
    }
    
    if(! (input_password.value.length >= 8)) {
      other_conditions.push("mora biti duljine minimalno 8 znakova")
    }
  
    var alphaNum = /^[a-z0-9]+$/i;
    if(input_password.value.match(alphaNum)) {  
      to_contain.push("barem jedan nealfanumericki znak");
    }
    
    console.log(to_contain)
    console.log(other_conditions)
  
    let msg_present = false;
  
    if (! (other_conditions.length === 0) && ! (to_contain.length === 0)) {
      msg_present = true
  
      other_conditions.forEach(element => {
        msg += element + " ";
      });
  
      msg += "te sadržavati "
      
      if (to_contain.length >= 2) {
        let last = to_contain.pop();
        let one_before_last = to_contain.pop();
  
        to_contain.forEach(element => {
          msg += element + ", "; 
        });
  
        msg += one_before_last + " i " + last
  
  
      } else {
        msg += to_contain[0];
      }
  
    } else if (!(other_conditions.length === 0)) {
      msg_present = true;
      other_conditions.forEach(element => {
        msg += element + " ";
      });
    
    }  else  if (! (to_contain.length === 0)) {
      msg_present = true;
      msg += "mora sadržavati "
      
      if (to_contain.length >= 2) {
        let last = to_contain.pop();
        let one_before_last = to_contain.pop();
  
        to_contain.forEach(element => {
          msg += element + ", "; 
        });
  
        msg += one_before_last + " i " + last;
  
  
      } else {
        msg += to_contain[0];
      }
    
  
    } 
    let id = "input__password__err";
  
    if (msg_present) {
      msg = msg.trimEnd() +  ".";
  
  
      document.getElementById(id).innerText = msg;
      show_element(id, true);

      return false;
  
    }    else {
      show_element(id, false);
      // document.getElementById("input__password").style= "border: 2px solid yellow;"
  
      return true;
    }

    // if (! is_year_valid(value)) {
    //   console.log("input__card__year validation err")
    //   show_element(id_selector_err, true);
    //   return false;
    // } else {
    //   console.log("card year ok")
    //   show_element(id_selector_err, false);
    //   document.getElementById(id_selector).style= "border: 2px solid yellow;"
    //   return true;
    // }
  });

  // function validate_password(input_password) {
 
  // }
  
  

}

function init_password_repeat_listeners() {

  let id_selector = "input__password_repeat"
  let id_selector_err = "input__password_repeat__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {
    console.log("hello from additional control pass rep", value)


    let p_1 = document.getElementById("input__password").value;
    let p_2 = document.getElementById("input__password_repeat").value;
  
    console.log(p_1);
    console.log(p_2);
  
    let id = "input__password_repeat__err";
  
    if (p_1 === p_2 && p_1 !== "") {
  
      show_element(id, false);
      // document.getElementById("input__password_repeat").style= "border: 2px solid yellow;"
  
      return true;
    } else {
      show_element(id, true);
  
      return false;
    }

    // if (! is_month_valid(value)) {
    //   console.log("input__card__month validation err")
    //   show_element(id_selector_err, true);
    //   return false;
    // } else {
    //   console.log("month ok")
    //   show_element(id_selector_err, false);
    //   document.getElementById(id_selector).style= "border: 2px solid yellow;"
    //   return true;
    // }

  }) 


  // let input_repeat_password = document.getElementById("input__password_repeat")

  // input_repeat_password.onkeyup = function() {
  //   validate_password_repeat();
  // }
  
  // input_repeat_password.onfocus = function() {
  //   validate_password_repeat();
  // }


  function validate_password_repeat() {

   
  }

}










function validateCode(){
  var TCode = document.getElementById('TCode').value;
  if( /[^a-zA-Z0-9]/.test( TCode ) ) {
     alert('Input is not alphanumeric');
     return false;
  }
  return true;     
}


function isAlphaNumeric(str) {
  var code, i, len;

  for (i = 0, len = str.length; i < len; i++) {
    code = str.charCodeAt(i);
    if (!(code > 47 && code < 58) && // numeric (0-9)
        !(code > 64 && code < 91) && // upper alpha (A-Z)
        !(code > 96 && code < 123)) { // lower alpha (a-z)
      return false;
    }
  }
  return true;
};


function is_year_valid(value) {
  let years = get_years();
 
  return years.includes(value);

}

function is_month_valid(value) {
  let months = get_months();
  const lowercased = months.map(name => name.toLowerCase());
  console.log(lowercased);

  return lowercased.includes(value.toLowerCase());

}

function creditCardValidation(creditCradNum)
{
  cards = {
    "Mastercard": /^5[1-5][0-9]{14}$|^2(?:2(?:2[1-9]|[3-9][0-9])|[3-6][0-9][0-9]|7(?:[01][0-9]|20))[0-9]{12}$/,
    "American Express": /^3[47][0-9]{13}$/,
    "Visa": /^4[0-9]{12}(?:[0-9]{3})?$/,
    "Discover": /^65[4-9][0-9]{13}|64[4-9][0-9]{13}|6011[0-9]{12}|(622(?:12[6-9]|1[3-9][0-9]|[2-8][0-9][0-9]|9[01][0-9]|92[0-5])[0-9]{10})$/,
    "Maestro": /^(5018|5081|5044|5020|5038|603845|6304|6759|676[1-3]|6799|6220|504834|504817|504645)[0-9]{8,15}$/,
    "JCB": /^(?:2131|1800|35[0-9]{3})[0-9]{11}$/,
    "Diner’s Club": /^3(?:0[0-5]|[68][0-9])[0-9]{11}$/
  };
  
  let is_valid = false;

  for (const [key, value] of Object.entries(cards)) {

    if (value.test(creditCradNum)) {
        is_valid = true;
        return key
      } 

  }

  return undefined
  
}    

const isEmailValid = (email) => {
  const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
};

function show_element(id, visible) {
  // console.log("id", id, visible)
  var x = document.getElementById(id);

  if (visible) {
    if (x.style.display === "none") {
      x.style.display = "block";
    }
  
  } else {
    if (x.style.display !== "none") {
      x.style.display = "none";
    
    }
  }

  // if (x.style.display === "none") {
  //   x.style.display = "block";
  // } else {
  //   x.style.display = "none";
  // }
}


function delete_init() {

  document.getElementById("delete__username").onclick = () => {
    var input = document.getElementById("input__username");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__OIB").onclick = () => {
    var input = document.getElementById("input__OIB");
    input.value = '';
    input.focus();
    let id_selector_err = "input__OIB__err"
    show_element(id_selector_err, false);

  }
  
  document.getElementById("delete__firstname").onclick = () => {
    var input = document.getElementById("input__firstname");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__lastname").onclick = () => {
    var input = document.getElementById("input__lastname");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__email").onclick = () => {
    var input = document.getElementById("input__email");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__cardnumber").onclick = () => {
    var input = document.getElementById("input__cardnumber");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__card__month").onclick = () => {
    var input = document.getElementById("input__card__month");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__card__year").onclick = () => {
    var input = document.getElementById("input__card__year");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__password").onclick = () => {
    var input = document.getElementById("input__password");
    input.value = '';
    input.focus();
  }
  
  document.getElementById("delete__password_repeat").onclick = () => {
    var input = document.getElementById("input__password_repeat");
    input.value = '';
    input.focus();
  }
  
}

function autocomplete(inp, arr) {
    var currentFocus;
    inp.addEventListener("input", function(e) {
        var a, b, i, val = this.value;
        closeAllLists();
        if (!val) { return false;}
        currentFocus = -1;
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        this.parentNode.appendChild(a);
        for (i = 0; i < arr.length; i++) {
          if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
            b = document.createElement("DIV");
            b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
            b.innerHTML += arr[i].substr(val.length);
            b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
            b.addEventListener("click", function(e) {
                inp.value = this.getElementsByTagName("input")[0].value;
                closeAllLists();
            });
            a.appendChild(b);
          }
        }
    });
    
    inp.addEventListener("keydown", function(e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
          currentFocus++;
          addActive(x);
        } else if (e.keyCode == 38) {
          currentFocus--;
          addActive(x);
        } else if (e.keyCode == 13) {
          e.preventDefault();
          if (currentFocus > -1) {
            if (x) x[currentFocus].click();
          }
        }
    });
    function addActive(x) {
      if (!x) return false;
      removeActive(x);
      if (currentFocus >= x.length) currentFocus = 0;
      if (currentFocus < 0) currentFocus = (x.length - 1);
      x[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(x) {
      for (var i = 0; i < x.length; i++) {
        x[i].classList.remove("autocomplete-active");
      }
    }
    function closeAllLists(elmnt) {
      var x = document.getElementsByClassName("autocomplete-items");
      for (var i = 0; i < x.length; i++) {
        if (elmnt != x[i] && elmnt != inp) {
          x[i].parentNode.removeChild(x[i]);
        }
      }
    }
    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
  }
  
  function get_years()                
  {
    let current_year = Number(String(Date()).split(" ")[3])
    let max_exp_year = current_year + 7;

    let r = [];


      for (var i = current_year; i  <= max_exp_year; i++) {
        r.push(String(i));

     
      }   

    return r;
  }

  function get_months() {
    let months_hrv = "Siječanj Veljača Ožujak Travanj Svibanj Lipanj Srpanj Kolovoz Rujan Listopad Studeni Prosinac".split(" ")
    let months_descr = "January, February, March, April, May, June, July, August, September, October, November, December".split(", ")
    let months = "1 2 3 4 5 6 7 8 9 10 11 12 01 02 03 04 05 06 07 08 09".split(" ")
  
    return months_descr.concat(months).concat(months_hrv);
  }

      function val_cc () {          

      var expiry_month = document.getElementById("expiry_month").value;
      var expiry_year = document.getElementById("expiry_year").value;
      var today = new Date();
      var expiry_date = today.setFullYear(expiry_year, expiry_month);

      if (today.getTime() > expiry_date.getTime())

      {
          alert ("\u2022Expiry month and year cannot be blank/Expiry month and year is before today month and year.");

          return false;
      }
}

