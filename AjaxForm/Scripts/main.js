﻿//make sure js is loaded in browser
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
let sendForm = (e) => {
    var modelObj = {};
    modelObj.FirstName = $('#firstName').val();
    modelObj.LastName = $('#lastName').val();
    modelObj.Phone = $('#phone').val();
    modelObj.Cell = $('#cell').val();
    modelObj.EMail = $('#eMail').val();
    modelObj.OptOut = $('#optOut').val();

    var postObj = JSON.stringify(modelObj);
    console.log("posting", modelObj)
    $.ajax({
        url: "/api/form",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(modelObj), 
        type: "POST",
        success: (data) => {
            addToList(data);
            console.log("success");
        },
        error: (data) => {
            console.log("oops", data)
            console.log(data)
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