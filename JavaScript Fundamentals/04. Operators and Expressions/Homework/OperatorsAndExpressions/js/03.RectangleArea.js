/*global jsConsole*/

function RectangleArea(width, height) {
    return width * height;
}

document.getElementById("process").onclick = function () {

    var width = Number(document.getElementById("width").value);
    var height = Number(document.getElementById("height").value);

    if (isInputValid("number", "width") && isInputValid("number", "height") ) {
        jsConsole.writeLine("Rectangle width: " + width);
        jsConsole.writeLine("Rectangle height: " + height);
        jsConsole.writeLine("Rectangle area: S = " + width + " x " + height + " = " + RectangleArea(width, height));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
    }
}