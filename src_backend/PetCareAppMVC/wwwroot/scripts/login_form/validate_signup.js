window.onload = (event) => {

  autocomplete(document.getElementById("input__card__year"), get_years());  

  autocomplete(document.getElementById("input__card__month"), get_months());  

    autocomplete(document.getElementById("input__role"), get_roles());  


  delete_init();

  change_listeners_init();

};

function change_listeners_init() {

  [
    "input__username__err", 
    "input__OIB__err", 
    "input__firstname__err",  
    "input__lastname__err",
    "input__email__err",
    "input__cardnumber__err",
    "input__cardtype__err",
    "input__card__month__err",
    "input__card__year__err",
    "input__password__err",
      "input__password_repeat__err",
    "input__role__err"
  ].forEach(element => {
    show_element(element, false);

  });

  init_username_listeners();
  init_oib_listeners();
  init_firstname_listeners();
  init_lastname_listeners();
  init_email_listeners();
  init_card_number_listeners();
  init_card_type_listeners();
  init_card_month_listeners();
  init_card_year_listeners();
  init_password_listeners();
  init_password_repeat_listeners();
    init_role_listeners();
}

function empty_msg_mapper() {
  return {
    "input__username" : "Korisničko ime ne može biti prazno.",
    "input__OIB" : "OIB ne može biti prazan.",
    "input__firstname" : "Ime ne može biti prazno.",
    "input__lastname" : "Prezime ne može biti prazno.",
    "input__email" : "Adresa e-pošte ne može biti prazna.",
    "input__cardnumber" : "Broj kartice ne može biti prazan.",
    // "input__cardtype": "",
    "input__card__month" : "Mjesec istjecanja kreditne kartice ne može biti prazan.",
    "input__card__year" : "Godina istjecanja kreditne kartice ne može biti prazna.",
    "input__password" : "Lozinka ne može biti prazna",
      "input__password_repeat": "Ponovno upisana lozinka ne može biti prazna.",
      "input__role": "Uloga ne može biti prazna"
  }
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

    if (is_entered) {

      if (document.getElementById(id_selector).value === '') {
        set_red(id_selector);

        let val = empty_msg_mapper()[id_selector];
        if (val === undefined) {
          set_blue(id_selector);
        } else {
          document.getElementById(id_selector_err).innerText = val;
        }

        show_element(id_selector_err, true);
        return;
      }  
    } else {
      if (document.getElementById(id_selector).value === '') {
        set_blue(id_selector);
        return;
      }
    }
   
    if (additional_control(document.getElementById(id_selector).value)) {
 
      show_element(id_selector_err, false);
      set_green(id_selector);
 
    } else {
      set_red(id_selector);

    }

  }
  
}



function init_role_listeners() {

    let id_selector = "input__role"
    let id_selector_err = "input__role__err"

    init_generic_listeners(id_selector, id_selector_err, (value) => {

        if (!is_role_valid(value)) {
            show_element(id_selector_err, true);

            document.getElementById(id_selector_err).innerText =
                "Uloga nije valjanog formata, ona je administrator ili korisnik."
            return false;
        } else {
            show_element(id_selector_err, false);
            return true;
        }

    })


}

function init_username_listeners() {

  let id_selector = "input__username"
  let id_selector_err = "input__username__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    return true;
  }) 


}

function init_oib_listeners() {

  let id_selector = "input__OIB"
  let id_selector_err = "input__OIB__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    var reg = /^\d+$/;

    let val = document.getElementById(id_selector).value; 

    if (val.length === 11 && val.match(reg)) {
      show_element(id_selector_err, false);
      return true
    } else {
      show_element(id_selector_err, true);
      document.getElementById(id_selector_err).innerText = 
      "OIB nije valjanog formata, mora sadržavati 11 brojeva.";
      return false;
    }

  }) 



}

function init_firstname_listeners() {
  let id_selector = "input__firstname"
  let id_selector_err = "input__firstname__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    return true;
  }) 

  


}

function init_lastname_listeners() {

  let id_selector = "input__lastname"
  let id_selector_err = "input__lastname__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {
    return true;
  }) 


  

}

function init_email_listeners() {

  let id_selector = "input__email"
  let id_selector_err = "input__email__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {
   
    if (! isEmailValid(value)) {
      show_element(id_selector_err, true);
      document.getElementById(id_selector_err).innerText = 
      "Adresa e-pošte nije valjanog formata."

      return false;
    } 

    return true;
  }) 

}

function init_card_number_listeners() {

  let id_selector = "input__cardnumber"
  let id_selector_err = "input__cardnumber__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {
          
    let card = creditCardValidation(value);
  
    if (card === undefined) {


      show_element(id_selector_err, true);

      document.getElementById(id_selector_err).innerText = 
      "Broj kreditne kartice nije valjanog formata.";
      
      return false
  
    } else {
      show_element(id_selector_err, false);
    
      document.getElementById("input__cardtype").value = card;
      return true;
    }

  }) 


}

function init_card_type_listeners() {
  let id_selector = "input__cardtype"
  let id_selector_err = "input__cardtype__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {

    return true


  }) 
}

function init_card_month_listeners() {

  let id_selector = "input__card__month"
  let id_selector_err = "input__card__month__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {

    if (! is_month_valid(value)) {
      show_element(id_selector_err, true);

      document.getElementById(id_selector_err).innerText = 
      "Mjesec istjecanja kreditne kartice nije valjanog formata, mora sadržavati 2 broja odnosno nalaziti se u padajućem izborniku."
      return false;
    } else {
      show_element(id_selector_err, false);
      return true;
    }

  }) 


}

function init_card_year_listeners() {
  
  let id_selector = "input__card__year"
  let id_selector_err = "input__card__year__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {

    if (! is_year_valid(value)) {
      show_element(id_selector_err, true);
      document.getElementById(id_selector_err).innerText = 
      "Godina istjecanja kreditne kartice nije valjanog formata, mora sadržavati 4 broja."
      return false;
    } else {
      show_element(id_selector_err, false);
      return true;
    }
  });

 

}

function init_password_listeners() {

  // https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_password_val


  let id_selector = "input__password"
  let id_selector_err = "input__password__err"
  init_generic_listeners(id_selector, id_selector_err, (value) => {


    let input_password = value;

    let msg ="Lozinka nije dovoljno sigurna; ";
  
    let to_contain = [];
    let other_conditions = [];
  
    var lowerCaseLetters = /[a-z]/g;
    if(! (input_password.match(lowerCaseLetters))) {  
      
      to_contain.push("barem jedno malo slovo");
    }
    
    var upperCaseLetters = /[A-Z]/g;
    if(! (input_password.match(upperCaseLetters))) {  
      to_contain.push("barem jedno veliko slovo");
    }
  
    var numbers = /[0-9]/g;
    if(! (input_password.match(numbers))) {  
      to_contain.push("barem jedan broj");
    }
    
    if(! (input_password.length >= 8)) {
      other_conditions.push("mora biti duljine minimalno 8 znakova")
    }
  
    var alphaNum = /^[a-z0-9]+$/i;
    if(input_password.match(alphaNum)) {  
      to_contain.push("barem jedan nealfanumericki znak");
    }
      
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
  
      return true;
    }

  });

  

}

function init_password_repeat_listeners() {

  let id_selector = "input__password_repeat"
  let id_selector_err = "input__password_repeat__err"

  init_generic_listeners(id_selector, id_selector_err, (value) => {


    let p_1 = document.getElementById("input__password").value;
    let p_2 = document.getElementById("input__password_repeat").value;
    
    let id = "input__password_repeat__err";
  
    if (p_1 === p_2 && p_1 !== "") {
  
      show_element(id, false);
  
      return true;
    } else {
      show_element(id, true);
  
      return false;
    }


  }) 




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

function is_role_valid(value) {
    let roles = get_roles();
    const lowercased = roles.map(name => name.toLowerCase());

    return lowercased.includes(value.toLowerCase());
}

function is_year_valid(value) {
  let years = get_years();
 
  return years.includes(value);

}

function is_month_valid(value) {
  let months = get_months();
  const lowercased = months.map(name => name.toLowerCase());

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

function isEmailValid(email) {
  const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
};

function show_element(id, visible) {
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

  document.getElementById("delete__cardtype").onclick = () => {
    var input = document.getElementById("input__cardtype");
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
    var input = document.getElementById("input__password__repeat");
    input.value = '';
    input.focus();
  }
  
    document.getElementById("delete__role").onclick = () => {
        var input = document.getElementById("input__role");
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

        else if (e.keyCode == 9) {


          document.getElementById("empty_click").click()

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

function get_roles() {
    return "admin administrator korisnik user".split(" ")

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

function set_blue(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid #609;"
}

function set_green(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid green;"

}

function set_red(id_selector) {
  document.getElementById(id_selector).style= "border: 3px solid red;"
}