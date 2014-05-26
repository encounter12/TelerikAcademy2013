/*global jsConsole, isInputValid*/

function isPointWithinCircle(pointX, pointY, circleRadius) {
    var distanceToCenter = Math.sqrt(Math.pow(pointX, 2) + Math.pow(pointY, 2));
    if (distanceToCenter <= circleRadius) {
        return true;
    }
    return false;
}

document.getElementById("process").onclick = function () {

    var pointX = Number(document.getElementById("xCoord").value);
    var pointY = Number(document.getElementById("yCoord").value);

    var circleRadius = 5;
    if (isInputValid("number", "xCoord") && isInputValid("number", "yCoord")) {
        jsConsole.writeLine("Point(" + pointX + ", " + pointY + ") is within a circle K(0, " + circleRadius + "): "
            + isPointWithinCircle(pointX, pointY, circleRadius));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
    }
};