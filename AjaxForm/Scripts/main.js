//make sure js is loaded in browser
console.log("loaded main.js");

//load forms from api controller with ajax and display data back to formData list in view
let loadForms = () => {
    $.ajax({
        url: "/api/form",
        dataType: "json",
        success: (listOfForms) => {
            listOfForms.map((data) => {
                console.log('a', data)
                $("#formData")
                    .append($("<li>").html(data.FirstName + " " + data.LastName + " " + data.Phone + " " + data.Cell + " " + data.EMail + " " + data.OptOut))
            });
        }
    });
};

//add new data to list of form data
let addToList = (data) => {
    $("#formData")
        .append($("<li>").html(data.FirstName + " " + data.LastName + " " + data.Phone + " " + data.Cell + " " + data.EMail + " " + data.OptOut));
}

//take data from form and send through api to ajax as new form data
let sendForm = () => {

    let newForm = {
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        email: $("#email").val(),
        phone: $("#phone").val(),
        cell: $("#cell").val(),
        optOut: $("#optOut").val()
    };

    $.ajax({
        url: "/api/form",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(newForm),
        type: "POST",
        success: (data) = {
            addToList(data);
        },
        error: (data) => {
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}

//make sure document is fully loaded before running functions for ajax call to api
$(document).ready(() => {

    console.log("ready...");
    loadForms();
});