console.log("loaded main.js");


let loadForms = () => {
    $.ajax({
        url: "/api/form",
        dataType: "json",
        success: (listOfForms) => {
            listOfForms.map((l) => {
                $("#formData")
                    .append($("<li>").html(listOfForms))
            });


        }
    });
};

$(document).ready(() => {

    console.log("ready...");
    loadForms();
});