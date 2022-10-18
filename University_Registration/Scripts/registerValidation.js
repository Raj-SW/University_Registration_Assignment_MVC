function validateRegistration() {

    var fname = $("#fname").val(); // read fname input
    var sname = $("#sname").val(); // read sname input
    var address = $("#address").val(); // read address input
    var phoneNumber = $("#phoneNumber").val(); // read phone number input
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

    var errorMessage = "";

    if (fname == "" || fname == null || sname == "" || sname == null || address == "" || address == null || phoneNumber == "" || phoneNumber == null
        || DOB == "" || DOB == null || guardianName == "" || guardianName == null || emailAddress == "" || errorMessage == null
        || nid == "" || nid == null || subj1 == "" || subj1 == null || subj2 == "" || subj2 == null || subj3 == "" || subj3 == null
        || grade1 == "" || grade1 == null || grade2 == "" || grade2 == null || grade3 == "" || grade3 == null  ) {

        errorMessage = "Please do not leave any empty fields\n";
        alert(errorMessage);
        return false;

    }
    if (subj1 === subj2 || subj1 === subj3 || subj3 === subj2) {
        errorMessage = "Same subjects entered twice";
        alert(errorMessage);

        return false;
    }
        return true;
}