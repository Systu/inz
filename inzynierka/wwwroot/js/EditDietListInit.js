var CheckeCheckBox = document.querySelectorAll("input:checked");
for (var i = 0; i < CheckeCheckBox.length; i++) {
    $(`input[name='${CheckeCheckBox[i].name}']`).val("true");
};
