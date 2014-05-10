/*global jsConsole*/

function trapezoidArea(a, b, h) {
    return (a + b) * h / 2;
}

document.getElementById("process").onclick = function () {

    if (isInputValid("number", "a") && isInputValid("number", "b") && isInputValid("number", "h")) {
        var a = Number(document.getElementById("a").value),
            b = Number(document.getElementById("b").value),
            h = Number(document.getElementById("h").value);

        jsConsole.writeLine("Trapezoid area: S = (" + a + " + " + b + ") * " + h + " / 2 = " + trapezoidArea(a, b, h));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
    }
}