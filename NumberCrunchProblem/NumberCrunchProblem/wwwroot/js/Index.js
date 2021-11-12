function validateInput() {
    var result = true;
    var rejectMessage = "";
    if (isNaN(parseInt($("#txtMaxSample").val())) || $("#txtMaxSample").val().indexOf(".") > -1 || $("#txtMaxSample").val().indexOf("-") > -1) {
        
        rejectMessage += " Please enter a valid positive integer for Sample Max Count. \n"
        result = false;
    }
    if (isNaN(parseInt($("#txtPatientScore").val())) || $("#txtPatientScore").val().indexOf(".") > -1) {
        
        rejectMessage += " Please enter a valid integer for Patient Score. \n"
        result = false;
    }
    if (isNaN(parseInt($("#txtDoctorScore").val())) || $("#txtDoctorScore").val().indexOf(".") > -1) {
        
        rejectMessage += " Please enter a valid integer for Doctor Score. \n"
        result = false;
    }
    if (!result) {
        alert(rejectMessage);
    }
    return result
}

function moveToResults() {
    if (validateInput()) {
        location.href = "/Crunch/Results?MaxResults=" + $("#txtMaxSample").val() + "&DoctorScore=" + $("#txtDoctorScore").val() + "&PatientScore=" + $("#txtPatientScore").val();
    }
}

function openFile(event) {
    var input = event.target;

    var reader = new FileReader();
    reader.onload = function () {
        var text = reader.result;
        console.log(text);
        sessionStorage.setItem("message",text);
    };
    reader.readAsText(input.files[0]);
};

$(document).ready(function () {
    sessionStorage.removeItem("message");
});