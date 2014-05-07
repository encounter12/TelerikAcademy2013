function initElement() {
    var p = document.getElementById("foo");
    /*p.onclick = showAlert;*/
};

function showAlert() {
    alert("onclick Event detected!")
}

function getConfirmation() {
    var x;
    var r = confirm("Press a button!");
    if (r === true) {
        x = "You pressed OK!";
    }
    else {
        x = "You pressed Cancel!";
    }
    document.getElementById("result").innerHTML = x;
}

function redirect() {
    document.location = "http://www.yahoo.com/";
}

function writeMessage() {
    document.write("This is a test message");
}
