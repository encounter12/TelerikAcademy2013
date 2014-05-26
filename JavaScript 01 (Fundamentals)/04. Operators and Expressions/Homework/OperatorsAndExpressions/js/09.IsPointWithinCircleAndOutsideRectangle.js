/*global jsConsole, isInputValid*/

function isPointWithinCircle(pointX, pointY, circleCenterX, circleCenterY, circleRadius) {
    
    var circleXMin = circleCenterX - circleRadius,
        circleXMax = circleCenterX + circleRadius,
        circleYMin = circleCenterY - circleRadius,
        circleYMax = circleCenterY + circleRadius;

    if (pointX >= circleXMin && pointX <= circleXMax 
        && pointY >= circleYMin && pointY <= circleYMax) {
        return true;
    }
    return false;
}

function isPointOutsideRectangle(pointX, pointY, rectangleTop, rectangleLeft,
    rectangleWidth, rectangleHeight) {
    var rectangleXMin = rectangleLeft,
        rectangleXMax = rectangleLeft + rectangleWidth,
        rectangleYMin = rectangleTop - rectangleHeight,
        rectangleYMax = rectangleTop;

    if (pointX < rectangleXMin || pointX > rectangleXMax
        || pointY < rectangleYMin || pointY > rectangleYMax) {
        return true;
    }
    return false;
}

function isPointWithinCircleOutsideRectangle(pointX, pointY, circleCenterX, circleCenterY, circleRadius,
    rectangleTop, rectangleLeft, rectangleWidth, rectangleHeight) {

    var pointWithinCircle = isPointWithinCircle(pointX, pointY, circleCenterX, circleCenterY, circleRadius),
        pointOutsideRectangle = isPointOutsideRectangle(pointX, pointY, rectangleTop, rectangleLeft, rectangleWidth, rectangleHeight);

    if (pointWithinCircle && pointOutsideRectangle) {
        return true;
    }
    return false;
}

document.getElementById("process").onclick = function () {

    if (isInputValid("number", "pointX") && isInputValid("number", "pointY")) {
        var pointX = Number(document.getElementById("pointX").value),
            pointY = Number(document.getElementById("pointY").value);

        var pointWithinCircleOutsideRectangle = isPointWithinCircleOutsideRectangle(pointX, pointY, 1, 1, 3, 1, -1, 6, 2);
        jsConsole.writeLine("Point within the circle and outside rectangle: " + pointWithinCircleOutsideRectangle);
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
    }
};