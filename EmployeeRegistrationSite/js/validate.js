function Validate() {
    var empNum = document.getElementById('employeeNumber');
    var pass = document.getElementById('password');

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
    else{
        $("#password").css("border", "1px solid #dbdbdb");
        $("#passwordLabel").css("background-color", "rgba(255, 255, 255, 0)");
    }
}