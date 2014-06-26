function createRectangle() {
    var rect = new Kinetic.Rect({
        x: 0,
        y: 0,
        width: 133,
        height: 45,
        stroke: 'green',
        strokeWidth: 1,
        cornerRadius: 4
    });
    return rect;
}

function createRightArrow() {
    var rightArrow = new Kinetic.Shape({
        drawFunc: function (context) {
            context.beginPath();
            context.moveTo(0, 0);
            context.quadraticCurveTo(16, 24, 47, 27);
            context.bezierCurveTo(80, 28, 90, 40, 95, 55);
            context.lineTo(88, 48);
            context.quadraticCurveTo(90, 51, 95, 45);
            context.lineTo(95, 55);
            context.strokeShape(this);
        },
        stroke: 'green',
        strokeWidth: 1
    });
    return rightArrow;
}

//transforms right arrow into a mirror left arrow
function createLeftArrow() {

    var rightArrow = createRightArrow();
    rightArrow.move({x: 95, y: 44});
    rightArrow.scale({
        x: -1,
        y: 1
    });
    var leftArrow = rightArrow;
    return leftArrow;
}

function createRectangleWithRightArrow(x, y) {
    var rectWithRightArrow = new Kinetic.Group({
        x: x,
        y: y,
        draggable: true
    });
    var rect = createRectangle();
    rect.move({x: 29, y: 0});

    var rightArrow = createRightArrow();
    rightArrow.move({x: 95, y: 44});
    rectWithRightArrow.add(rect);
    rectWithRightArrow.add(rightArrow);
    return rectWithRightArrow;
}

function createRectangleWithLeftArrow(x, y) {
    var rectWithLeftArrow = new Kinetic.Group({
        x: x,
        y: y,
        draggable: true
    });
    var rect = createRectangle();
    rect.move({ x: 29, y: 0 });
    var leftArrow = createLeftArrow();
    rectWithLeftArrow.add(rect);
    rectWithLeftArrow.add(leftArrow);
    
    return rectWithLeftArrow;
}

function createRectangleWithTwoArrows(x, y) {
    var rectWithTwoArrows = new Kinetic.Group({
        x: x,
        y: y,
        draggable: true
    });
    var rect = createRectangle();
    rect.move({ x: 29, y: 0 });
    var rightArrow = createRightArrow();
    rightArrow.move({ x: 95, y: 44 });
    var leftArrow = createLeftArrow();
    rectWithTwoArrows.add(rect);
    rectWithTwoArrows.add(rightArrow);
    rectWithTwoArrows.add(leftArrow);
    return rectWithTwoArrows;
}

function createAndPositionName(nameString, x, y) {
    var name = new Kinetic.Text({
        x: x,
        y: y,
        text: nameString,
        fontSize: 16,
        fontFamily: 'Calibri',
        fill: 'black',
        align: 'left'
    });
    return name;
}

var stage = new Kinetic.Stage({
    container: 'container',
    width: 900,
    height: 600
});

var layer = new Kinetic.Layer();

var groupLeftSideX;
var groupWidth = 190;
var groupHeight = 100;

//this is the name X position relative to the rectangle X position
var namePositionX = 45;
var namePositionY = 14;
var names = ['Petra Stamatova', 'Todor Stamatov'];

for (var i = 0; i < 2; i++) {

    groupLeftSideX = stage.getWidth() - (i + 1) * groupWidth;

    var rectWithTwoArrows = createRectangleWithTwoArrows(groupLeftSideX, namePositionY);
    var personsName = createAndPositionName(names[i], namePositionX, namePositionY);
    rectWithTwoArrows.add(personsName);
    layer.add(rectWithTwoArrows);
}

stage.add(layer);