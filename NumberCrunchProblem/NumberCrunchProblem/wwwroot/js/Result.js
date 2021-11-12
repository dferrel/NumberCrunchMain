function generateResults() {
    var data = {};
    data.maxSample = $("#maxResults").val();
    data.doctorScore = $("#doctorScore").val();
    data.patientScore = $("#patientScore").val();
    $.ajax({
        url: "https://localhost:44367/NumberCrunch",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        crossDomain: true,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        beforeSend: function (xhr) {
            xhr.withCredentials = true;
        },
        success: function (data) {
            console.log(data);
            $('#resultTable').DataTable({
                "data": data,
                "columns": [
                    { "data": "sampleNumber" },
                    { "data": "sampleScoreDesc" }
                ]
            });
        },
        error: function (xhr) {
            console.log(xhr);
            alert("Failed to get score from the server.");
        }
    });
}

function generateMessage() {
    $("#messageArea").text(sessionStorage.getItem("message"))
}

function updateTableClass() {
    //default - table-striped
        //bordered - table-bordered and table-striped
        //simple - table-bordered
    console.log("test");
    $("#resultTable").removeClass("table-bordered");
    $("#resultTable").removeClass("table-striped");
    if ($('#selectedView').find(":selected").val() == '1') {
        $("#selectedView").addClass("table-striped");
    }
    else if ($('#selectedView').find(":selected").val() == '2') {
        $("#resultTable").addClass("table-bordered");
        $("#resultTable").addClass("table-striped");
    }
    else {
        $("#resultTable").addClass("table-bordered");
    }
}

$(document).ready(function () {
    generateResults();
    generateMessage();
    //$('#resultTable').DataTable();
});