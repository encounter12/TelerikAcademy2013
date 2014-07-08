var movingShapes = (function () {
    'use strict';

    var self;
    var container = document.getElementById('container');
    container.style.position = 'relative';
    container.style.width = '1200px';
    container.style.height = '700px';
    container.style.backgroundColor = '#222222';
    container.style.fontFamily = "Calibri";

    var ellipse = {
        majorRadiusA: 250,
        minorRadiusB: 170,
        centerX: parseInt(container.style.width) / 2,
        centerY: parseInt(container.style.height) / 2
    }
    var rect = {
        width: 800,
        height: 600
    }
    rect.x = (parseInt(container.style.width) - rect.width) / 2;
    rect.y = (parseInt(container.style.height) - rect.height) / 2;


    var DIV_WIDTH = "50px",
        DIV_HEIGHT = "50px";

    var divsMovingInRectangle = [],
        divsMovingInEllipse = [];

    var shapesCount = 0;

    var Directions = {
        South: "South",
        East: "East",
        North: "North",
        West: "West"
    };

    if (Object.freeze) {
        Object.freeze(Directions);
    }

    function addShape(motionType) {
        if (motionType === "rect") {
            var div = createDivElement();
            positionDivRandomlyOnRectangle(div, rect);
            divsMovingInRectangle.push(div);
            appendDivToDom(div, container);
            shapesCount += 1;
        }
        else if (motionType === "ellipse") {
            var div = createDivElement();
            positionDivRandomlyOnEllipse(div, ellipse);
            divsMovingInEllipse.push(div);
            appendDivToDom(div, container);
            shapesCount += 1;
        }
        else {
            throw new Error("The motion type parameter is not supported.");
        }
        if (shapesCount === 1) {
            moveShapes(50, 0.005, 1);
        }
    }
    // Returns a random integer between min and max
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        var red = getRandomInt(0, 255),
            green = getRandomInt(0, 255),
            blue = getRandomInt(0, 255),
            randomColor = 'rgb(' + red + ',' + green + ',' + blue + ')';
            return randomColor;
    }

    function setRandomBackgroundColor(element) {
        var red = getRandomInt(0, 255),
            green = getRandomInt(0, 255),
            blue = getRandomInt(0, 255);

            element.style.backgroundColor = getRandomColor();
    }

    function setRandomFontSize(element, min, max) {
        element.style.fontSize = getRandomInt(min, max) + "px";
    }

    function setRandomBorderColor(element) {
        element.style.borderColor = getRandomColor();
    }

    function createDivElement() {
        var div = document.createElement("div");
        div.style.width = DIV_WIDTH;
        div.style.height = DIV_HEIGHT;
        div.style.border = "1px solid";
        div.style.position = "absolute";
        div.style.textAlign = "center";
        setRandomBackgroundColor(div);
        setRandomFontSize(div, 12, 30);
        setRandomBorderColor(div);
        div.innerHTML = "div";
        return div;
    }

    function positionDivRandomlyOnRectangle(element, rect) {
        var upperSide = getRandomInt(0, 1),
            elementHalfWidth = parseInt(element.style.width) / 2,
            elementHalfHeight = parseInt(element.style.height) / 2;
            element.setAttribute("direction", null);

        if (upperSide) {
            element.style.top = (rect.y - elementHalfHeight) + "px";
            element.direction = Directions.West;

        } else{
            element.style.top = (rect.y  - elementHalfHeight + rect.height) + "px";
            element.direction = Directions.East;
        }

        element.style.left = (rect.x - elementHalfWidth + getRandomInt(0, rect.width)) + "px";
    }

    function positionDivRandomlyOnEllipse(div, ellipse) {
        div.setAttribute('angle', 0);
        div.angle = getRandomInt(0, 12) * (2 * Math.PI) / getRandomInt(1, 24);
        var divCenterX = ellipse.centerX + ellipse.majorRadiusA * Math.cos(div.angle);
        var divCenterY = ellipse.centerY + ellipse.minorRadiusB * Math.sin(div.angle);
        div.style.left = divCenterX - (parseFloat(div.style.width) / 2) + "px";
        div.style.top = divCenterY - (parseFloat(div.style.height) / 2) + "px";
    }

    function appendDivToDom(element, container) {
        container.appendChild(element);
    }

    function moveShapes(generalSpeed, angleSpeed, movingInRectSpeed) {

        var count = 0;
        function animate() {

            if (count >= 50) {
                moveElementsInEllipse(divsMovingInEllipse, ellipse, angleSpeed);
                moveElementsInRect(divsMovingInRectangle, rect, movingInRectSpeed);
                count = 0;
            }
            count += generalSpeed;
            window.requestAnimationFrame(animate);
        }
        animate();
    }

    function moveElementsInEllipse(elements, ellipse, angleSpeed) {

        for (var i = 0, len = elements.length; i < len; i += 1) {

            var elementCenterX = ellipse.centerX + ellipse.majorRadiusA * Math.cos(elements[i].angle);
            var elementCenterY = ellipse.centerY + ellipse.minorRadiusB * Math.sin(elements[i].angle);
            elements[i].style.left = (elementCenterX - parseFloat(elements[i].style.width) / 2) + 'px';
            elements[i].style.top = (elementCenterY - parseFloat(elements[i].style.height) / 2) + 'px';
            elements[i].angle += angleSpeed;
        }
    }

    function moveElementsInRect(elements, rect, movingInRectSpeed) {

        changeDirection();
        updateCoordinates();

        function updateCoordinates() {
            for (var i = 0, len = elements.length; i < len; i += 1) {
                if (elements[i].direction === Directions.East) {
                    elements[i].style.left = (parseInt(elements[i].style.left) + movingInRectSpeed) + "px";
                }
                if (elements[i].direction === Directions.West) {
                    elements[i].style.left = (parseInt(elements[i].style.left) - movingInRectSpeed) + "px";
                }
                if (elements[i].direction === Directions.North) {
                    elements[i].style.top = (parseInt(elements[i].style.top) - movingInRectSpeed) + "px";
                }
                if (elements[i].direction === Directions.South) {
                    elements[i].style.top = (parseInt(elements[i].style.top) + movingInRectSpeed) + "px";
                }
            }
        }

        function changeDirection() {

            for (var i = 0, len = elements.length; i < len; i += 1) {

                var elementHalfWidth = parseInt(elements[i].style.width) / 2,
                    elementHalfHeight = parseInt(elements[i].style.height) / 2;

                if (parseInt(elements[i].style.left) >= (rect.x + rect.width - elementHalfWidth)
                    && elements[i].direction === Directions.East) {
                    elements[i].direction = Directions.North;
                }
                else if (parseInt(elements[i].style.top) <= (rect.y - - elementHalfHeight)
                    && elements[i].direction === Directions.North) {
                    elements[i].direction = Directions.West;
                }
                else if (parseInt(elements[i].style.left) <= (rect.x - elementHalfWidth)
                    && elements[i].direction === Directions.West) {
                    elements[i].direction = Directions.South;
                }
                else if (parseInt(elements[i].style.top) >= (rect.y + rect.height - elementHalfHeight)
                    && elements[i].direction === Directions.South) {
                    elements[i].direction = Directions.East;
                }
            }
        }
    }

    self = {add: addShape};
    return self;
}());

var divsMovingInRectangle = 10,
    divsMovingInEllipse = 10;

for (var i = 0; i < divsMovingInRectangle; i += 1) {
    movingShapes.add("rect");
}
for (var i = 0; i < divsMovingInEllipse; i += 1) {
    movingShapes.add("ellipse");
}