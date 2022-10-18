
function register() {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    // add click event for the Register button
    $("#btnRegister").click(function () {
        toastr.info('Page Under construction!!');
    });

    //  add click event for Sign In button
   //$("#registrationBtn").click(function () {


        var fname = $("#fname").val(); // read fname input
        var sname = $("#sname").val(); // read sname input
        var address = $("#address").val(); // read address input
        var phoneNumber = $("#phoneNumber").val(); // read phone numer input
        var DOB = $("#DOB").val(); // read DOB input
        var guardianName = $("#guardianName").val(); // read guadian name input
        var emailAddress = $("#emailAddress").val(); // read email address input
        var nid = $("#nid").val(); // read nid input

        var subj1 = document.getElementById("subject1").value;
        var subj2 = document.getElementById("subject2").value;
        var subj3 = document.getElementById("subject3").value;

    var grade1 = $('#grade1').val();
    var grade2 = $('#grade2').val();
    var grade3 = $('#grade3').val();

       
        // create object to map LoginModel
    var subjObj = { Subject_1: subj1, Grade_1: grade1, Subject_2: subj2, Grade_2: grade2, Subject_3: subj3, Grade_3: grade3 }
    var authObj = { FirstName: fname, Surname: sname, Address: address, PhoneNumber: phoneNumber, DOB: DOB, GuardianName: guardianName, Email: emailAddress, NID: nid, Subjects: subjObj };
      //  var TempObj = { Student: authObj, Subject: subjObj }
        $.ajax({
            type: "POST",
            url: "/Registration/AddStudent",
            data: authObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {

                    toastr.success("Registration Sucessful!! Request is on review");
                    form.reset();
                    //window.location = response.url;
                }
                else {
                    toastr.error('Make sure phone number, email and nid are unique');
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
