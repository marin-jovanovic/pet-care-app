window.onload = (event) => {

  autocomplete(document.getElementById("input__card__year"), get_years());  

  autocomplete(document.getElementById("input__card__month"), get_months());  

  delete_init();

  change_listeners_init();

  // validation_init();
  
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
    console.log(element)  
    show_element(element, false);

  });



  let id_selector = "input__username"
  let id_selector_err = "input__username__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let id_selector_err = "input__username__err"
    if (document.getElementById("input__username").value === '') {
      console.log("username empty")
      show_element(id_selector_err, false);
      return;
    } 

    // todo check if exist
    let exist = true 

    if (! exist) {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
   
    } else {
      console.log("username exist")
      show_element(id_selector_err, true);
    }
  });

  id_selector = "input__OIB"
  id_selector_err = "input__OIB__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__OIB").value; 
    
    if (value === '') {
      console.log("oib empty")
      show_element(id_selector_err, false);
      return;
    } 
    
    if (value.length === 11) {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    } else {
      console.log("oib length error")
      show_element(id_selector_err, true);
    }

  });

  id_selector = "input__firstname"
  id_selector_err = "input__firstname__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__firstname").value; 
    if (value === '') {
      console.log("firstname empty")
      show_element(id_selector_err, false);
      return;
    } else {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    }
  });

  id_selector = "input__lastname"
  id_selector_err = "input__lastname__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__lastname").value; 
    if (value === '') {
      console.log("lastname empty")
      show_element(id_selector_err, false);
      return;
    } else {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    }
  });


  id_selector = "input__email"
  id_selector_err = "input__email__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__email").value; 
    if (value === '') {
      console.log("email empty")
      show_element(id_selector_err, false);
      return;
    } else if (! isEmailValid(value)) {
      console.log("email validation err")
      show_element(id_selector_err, true);
      return;
    } else {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    }
  });

  show_element("input__card__type", false);

  id_selector = "input__cardnumber"
  id_selector_err = "input__cardnumber__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__cardnumber").value; 
    if (value === '') {
      console.log("input__cardnumber empty")
      show_element(id_selector_err, false);
      return;
    } 
    
    let card = creditCardValidation(value);

    if (card === undefined) {
      console.log("input__cardnumber err")
      show_element(id_selector_err, true);
      return;
  
    } else {
      console.log("card", card)
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
      show_element("input__card__type", true);
      document.querySelector("#input__card__type > td:nth-child(1) > span:nth-child(1) > input:nth-child(1)").value= card 
      document.getElementById("input__cardnumber__type").style= "border: 2px solid yellow;"
    }
  });

  id_selector = "input__card__month"
  id_selector_err = "input__card__month__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__card__month").value; 
    if (value === '') {
      console.log("input__card__month empty")
      show_element(id_selector_err, false);
      return;
    } else if (! is_month_valid(value)) {
      console.log("input__card__month validation err")
      show_element(id_selector_err, true);
      return;
    } else {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    }
  });

  id_selector = "input__card__year"
  id_selector_err = "input__card__year__err"
  document.getElementById(id_selector).addEventListener("change", (event) => {
    let value = document.getElementById("input__card__year").value; 
    if (value === '') {
      console.log("input__card__y empty")
      show_element(id_selector_err, false);
      return;
    } else if (! is_year_valid(value)) {
      console.log("input__card__year validation err")
      show_element(id_selector_err, true);
      return;
    } else {
      show_element(id_selector_err, false);
      document.getElementById(id_selector).style= "border: 2px solid yellow;"
    }
  });

// https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_password_val
}

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
  console.log("id", id, visible)
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

