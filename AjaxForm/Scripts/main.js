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

//make sure document is fully loaded before running functions for ajax call to api
$(document).ready(() => {

    console.log("ready...");
    loadForms();
});