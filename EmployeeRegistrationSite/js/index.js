//Problem: Hints are shown even when form is valid
//Solution: Hide and show them at appropriate times
var $password = $("#password");
var $confirmPassword = $("#confirm_password");
var $employeeNumber = $("#employeeNumber");

//Hide hints
$("form span").hide();

function isPasswordValid() {
  return $password.val().length > 8;
}

function arePasswordsMatching() {
  return $password.val() === $confirmPassword.val();
}

function canSubmit() {
  return isPasswordValid() && arePasswordsMatching();
}

function Validate() {

    if ($employeeNumber.value == null || $employeeNumber.value == "") {
        $employeeNumber.css("border", "1px solid red");
        $("#employeeNumberLabel").css("background-color", "white");
    }
    else if ($password.value == null || $password.value == "".value == null || $password.value == "") {
        $password.css("border", "1px solid red");
        $("#passwordLabel").css("background-color", "white");
    }
}

function passwordEvent(){
    //Find out if password is valid  
    if(isPasswordValid()) {
      //Hide hint if valid
      $password.next().hide();
    } else {
      //else show hint
      $password.next().show();
    }
}

function confirmPasswordEvent() {
  //Find out if password and confirmation match
  if(arePasswordsMatching()) {
    //Hide hint if match
    $confirmPassword.next().hide();
  } else {
    //else show hint 
    $confirmPassword.next().show();
  }
}

function enableSubmitEvent() {
  $("#submit").prop("disabled", !canSubmit());
}

//When event happens on password input
$password.focus(passwordEvent).keyup(passwordEvent).keyup(confirmPasswordEvent).keyup(enableSubmitEvent);

//When event happens on confirmation input
$confirmPassword.focus(confirmPasswordEvent).keyup(confirmPasswordEvent).keyup(enableSubmitEvent);

enableSubmitEvent();

function Validate() {
    var empNum = document.getElementById('employeeNumber');
    var pass = document.getElementById('password');
    var empName = document.getElementById('employeeName');

    if (empName.value == '') {
        $("#employeeName").css("border", "1px solid red");
        $("#employeeNameLabel").css("background-color", "white");
        return false;
    }
    else {
        $("#employeeName").css("border", "1px solid #dbdbdb");
        $("#employeeNameLabel").css("background-color", "rgba(255, 255, 255, 0)");
    }

    if (empNum.value == '') {
        $("#employeeNumber").css("border", "1px solid red");
        $("#employeeNumberLabel").css("background-color", "white");
        return false;
    }
    else {
        $("#employeeNumber").css("border", "1px solid #dbdbdb");
        $("#employeeNumberLabel").css("background-color", "rgba(255, 255, 255, 0)");
    }

    if (pass.value == '') {
        $("#password").css("border", "1px solid red");
        $("#passwordLabel").css("background-color", "white");
        return false;
    }
    else {
        $("#password").css("border", "1px solid #dbdbdb");
        $("#passwordLabel").css("background-color", "rgba(255, 255, 255, 0)");
    }
}