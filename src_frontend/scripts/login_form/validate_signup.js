window.onload = (event) => {

  autocomplete(document.getElementById("input__card__year"), get_years());  

  autocomplete(document.getElementById("input__card__month"), get_months());  

  delete_init();

};

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

