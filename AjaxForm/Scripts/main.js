console.log("loaded main.js");

let loadForms = () => {
    $.ajax({
        url: "/api/form",
        dataType: "json",
        success: (listOfForms) => {
            listOfForms.map((m) => {
                var _li = $("<li>").html(m.Form);
                $("#formData").append(_li);
            });
        }
    });
}

$(document).ready(() => {
    console.log("ready...");
    loadForms();
});