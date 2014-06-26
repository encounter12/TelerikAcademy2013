window.onload = function () {


    document.getElementById("font-colour-input").onchange = function () {
        var textarea = document.getElementsByTagName("textarea")[0];
        textarea.style.color = document.getElementById("font-colour-input").value;
    }
    document.getElementById("background-colour-input").onchange = function () {
        var textarea = document.getElementsByTagName("textarea")[0];
        textarea.style.backgroundColor = document.getElementById("font-colour-input").value;
    }
}