$(document).ready(function() {

  jQuery.validator.addMethod("validphone", function(value, element) {
    var phone = /^\s*[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}\s*$/im;
    return phone.test(value);
}, "invalid phone number");

  $("#addItemForm").validate({
    errorElement: "p",
    rules: {
      fname : {
        required: true,
      },
      lname: {
        required: true,
      },
      email: {
        required: true,
        email: true
      },
      phone: {
        required: true,
        validphone: true
      }
    }
  });
});

const uri = 'users';

function addItem() {
    $("#addItemForm").validate();
    if($("#addItemForm").valid()){
    const fname = document.getElementById('fname');
    const lname = document.getElementById('lname');
    const phone = document.getElementById('phone');
    const email = document.getElementById('email');
  
    const item = {
      fname: fname.value.trim(),
      lname: lname.value.trim(),
      phone: phone.value.trim(),
      email: email.value.trim()
    };
  
    fetch(uri, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(item)
    })
      .then(response => response.json())
      .then(() => {
        fname.value = '';
        lname.value = '';
        phone.value = '';
        email.value = '';
      })
      .catch(error => console.error('Unable to add user.', error));
    }
}


function getItems() {
    fetch(uri)
      .then(response => response.json())
      .then(data => _displayItems(data))
      .catch(error => console.error('Unable to get items.', error));
}

  function _displayItems(data) {
    const tBody = document.getElementById('usersTable');
    tBody.innerHTML = '';
    data.forEach(item => {
      let tr = tBody.insertRow();
      let td1 = tr.insertCell(0);
      let textNode = document.createTextNode(item.fname);
      td1.appendChild(textNode);
  
      let td2 = tr.insertCell(1);
      textNode = document.createTextNode(item.lname);
      td2.appendChild(textNode);
  
      let td3 = tr.insertCell(2);
      textNode = document.createTextNode(item.phone);
      td3.appendChild(textNode);

      let td4 = tr.insertCell(3);
      textNode = document.createTextNode(item.email);
      td4.appendChild(textNode);
    });
}