$(document).ready(function() {
  //Make Purchase:
  $('#purchase-button').click(function () {
    var itemNum = $('#item').val();
    var money = parseFloat($('#total-money').val()).toFixed(2);
    $.ajax({
      type: 'GET',
      url: 'http://localhost:8080/money/' + money + '/item/' + itemNum,
      success: function(data) {
        $('#change-messages').val(data.quarters + 'quarter(s)' + data.dimes + 'dime(s)' + data.nickels + 'nickel(s)' + data.pennies + 'pennies(s)');
        $('#total-money').val('$0.00');
        $('#purchase-messages').val('Thank you!!!');
        updatedItem();
        theTotal= 0;

      },
      error: function(xhr) {
        var no = JSON.parse(xhr.responseText);
        $('#purchase-messages').val(no.message);
      }
      });
    });


//Money Button:
  var theTotal = 0;
  $('.money').click(function(){
    theTotal = Number(theTotal) + Number($(this).val());
      $('#total-money').val(theTotal.toFixed(2));
    });
//Change Return Button:
  $('#change-return-button').click(function() {
    updatedItem();
    returnMoney();
    $('#total-money').val('$0.00');
    theTotal = 0;
    $('#purchase-messages').val('');
    $('#item').val('');

  });


  });

//Money Button:
function returnMoney() {
  var returnChange = $('#total-money').val()*100;
  var quarter = parseInt(returnChange/25);
  quarter%=25;
  var dime = parseInt(returnChange/10);
  dime%=10;
  var nickel = parseInt(returnChange/5);
  nickel%=5;
  $('#change-messages').val(quarter + 'quarter(s)' + dime + 'dime(s)' + nickel + 'nickel(s)');
}



function setItemNumber(itemNumber) {
  $('#item').val(itemNumber);
}

function updatedItem() {
//  $('#item-row').empty();
  $.ajax({
  type: 'GET',
  url: 'http://localhost:8080/items',
  success: function(item) {
    $('#quan1').append().text(item[0].quantity);
    $('#quan2').append().text(item[1].quantity);
    $('#quan3').append().text(item[2].quantity);
    $('#quan4').append().text(item[3].quantity);
    $('#quan5').append().text(item[4].quantity);
    $('#quan6').append().text(item[5].quantity);
    $('#quan7').append().text(item[6].quantity);
    $('#quan8').append().text(item[7].quantity);
    $('#quan9').append().text(item[8].quantity);

    $('#number1').append().text(item[0].id);
    $('#number2').append().text(item[1].id);
    $('#number3').append().text(item[2].id);
    $('#number4').append().text(item[3].id);
    $('#number5').append().text(item[4].id);
    $('#number6').append().text(item[5].id);
    $('#number7').append().text(item[6].id);
    $('#number8').append().text(item[7].id);
    $('#number9').append().text(item[8].id);

    $('#name1').append().text(item[0].name);
    $('#name2').append().text(item[1].name);
    $('#name3').append().text(item[2].name);
    $('#name4').append().text(item[3].name);
    $('#name5').append().text(item[4].name);
    $('#name6').append().text(item[5].name);
    $('#name7').append().text(item[6].name);
    $('#name8').append().text(item[7].name);
    $('#name9').append().text(item[8].name);

    $('#cost1').append().text(parseFloat(item[0].price).toFixed(2));
    $('#cost2').append().text(parseFloat(item[1].price).toFixed(2));
    $('#cost3').append().text(parseFloat(item[2].price).toFixed(2));
    $('#cost4').append().text(parseFloat(item[3].price).toFixed(2));
    $('#cost5').append().text(parseFloat(item[4].price).toFixed(2));
    $('#cost6').append().text(parseFloat(item[5].price).toFixed(2));
    $('#cost7').append().text(parseFloat(item[6].price).toFixed(2));
    $('#cost8').append().text(parseFloat(item[7].price).toFixed(2));
    $('#cost9').append().text(parseFloat(item[8].price).toFixed(2));
  },
  error: function(response) {
    alert('Site Down');
  }
});
}
