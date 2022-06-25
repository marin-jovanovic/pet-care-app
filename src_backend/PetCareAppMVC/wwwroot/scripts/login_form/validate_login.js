window.onload = (event) => {

    delete_init();
  
  };
  
  function delete_init() {
  
    document.getElementById("delete__username").onclick = () => {
      var input = document.getElementById("input__username");
      input.value = '';
      input.focus();
    }
    
    document.getElementById("delete__password").onclick = () => {
      var input = document.getElementById("input__password");
      input.value = '';
      input.focus();
    }

    
  }
  