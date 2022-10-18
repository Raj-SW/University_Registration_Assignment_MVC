
function login() {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    //get values from input
    var adminName = $("#AdminName").val();
    var password = $("#Password").val();

    //alert(adminName + ' ' + password);

    //create object to map Login Model
    logObj = { AdminName: adminName, Password: password };

    //ajax POST
    $.ajax({
        type: "POST",
        url: "/Login/Authenticate",
        data: logObj,
        dataType: "json",
        success: function (response) {
            if (response.result) {

                toastr.success("Login Successfull!! Request is on review");
                window.location = response.url;
            }
            else {
                toastr.error('Wrong Credentials');
                return false;
            }
        },
        failure: function (response) {
            toastr.error('Unable to make request!!');
        },
        error: function (response) {
            toastr.error('Something happen, Please contact Administrator!!');

        }
    });

}