/*jslint browser: true*/
/*global requestAnimationFrame*/

(function () {
    'use strict';

    var canvas = document.getElementById("the-canvas"),
        context = canvas.getContext("2d");

    function drawOval(centerX, centerY, width, height, lineWidth, strokeStyle, fillStyle) {

        context.save();

        var longerAxisLength = Math.max(width, height),
            scaleX = width / longerAxisLength,
            scaleY = height / longerAxisLength,
            startingAngle = 0,
            endingAngle = 360 * Math.PI / 180;

        context.scale(scaleX, scaleY);

        centerX = centerX / scaleX;
        centerY = centerY / scaleY;

        context.beginPath();
        context.arc(centerX, centerY, (longerAxisLength / 2), startingAngle, endingAngle);
        context.closePath();

        context.restore();

        context.lineWidth = lineWidth;
        context.strokeStyle = strokeStyle;
        context.fillStyle = fillStyle;

        context.stroke();
        context.fill();
    }

    function drawCylinder(ellipseCenterX, ellipseCenterY, ellipseWidth, ellipseHeight, cylinderHeight,
        lineWidth, strokeStyle, fillStyle) {

        drawOval(ellipseCenterX, ellipseCenterY + cylinderHeight,
            ellipseWidth, ellipseHeight, lineWidth, strokeStyle, fillStyle);

        context.beginPath();
        context.lineWidth = lineWidth / 2;
        var lineWidthCorrection = lineWidth / 4;

        context.moveTo(ellipseCenterX - (ellipseWidth / 2) - lineWidthCorrection, ellipseCenterY + cylinderHeight);
        context.lineTo(ellipseCenterX - (ellipseWidth / 2) - lineWidthCorrection, ellipseCenterY);
        context.lineTo(ellipseCenterX + (ellipseWidth / 2) + lineWidthCorrection, ellipseCenterY);
        context.lineTo(ellipseCenterX + (ellipseWidth / 2) + lineWidthCorrection, ellipseCenterY + cylinderHeight);

        context.fill();
        context.stroke();

        drawOval(ellipseCenterX, ellipseCenterY,
            ellipseWidth, ellipseHeight, lineWidth, strokeStyle, fillStyle);
    }

    //drawOval(260, 170, 140, 28, 4, '#252321', '#396693');
    //drawCylinder(267, 81, 80, 29, 76, 4, '#252321', '#396693');

    function drawHat(ellipseCenterX, ellipseCenterY, ellipseWidth, ellipseHeight, lineWidth, strokeStyle, fillStyle) {

        var height = (76 / 80) * ellipseWidth,
            hatBrimCenterX = ellipseCenterX - 7,
            harBrimCenterY = ellipseCenterY + height + 13,
            hatBrimWidth = (140 / 80) * ellipseWidth,
            hatBrimHeight = (28 / 29) * ellipseHeight;

        drawOval(hatBrimCenterX, harBrimCenterY, hatBrimWidth, hatBrimHeight, lineWidth, strokeStyle, fillStyle);
        drawCylinder(ellipseCenterX, ellipseCenterY, ellipseWidth, ellipseHeight, height, lineWidth, strokeStyle, fillStyle);
    }

    //drawHat(267, 81, 80, 29, 4, '#252321', '#396693');

    var ellipseWidth = 80,
        ellipseCenterX = -ellipseWidth;

    function moveHatRight() {

        context.clearRect(0, 0, canvas.width, canvas.height);

        if (ellipseCenterX - ellipseWidth >= canvas.width) {
            ellipseCenterX = -ellipseWidth;
        }

        drawHat(ellipseCenterX, 81, ellipseWidth, 29, 4, '#252321', '#396693');
        ellipseCenterX += 2;
        requestAnimationFrame(moveHatRight);
    }

    requestAnimationFrame(moveHatRight);

}());