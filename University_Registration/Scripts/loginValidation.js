function loginValidation() {
    var adminName = $("#AdminName").val();
    var password = $("#Password").val();
    var errorMessage = "";

    if (adminName == "" || adminName == null) {
        errorMessage = "Please enter Admin Name \n";
    }
    if (password == "" || password == null) {
        errorMessage = errorMessage+ "Please enter Password \n";
    }
    if (errorMessage != "") {
        alert(errorMessage);
        return false;
    } else
    return true;
}