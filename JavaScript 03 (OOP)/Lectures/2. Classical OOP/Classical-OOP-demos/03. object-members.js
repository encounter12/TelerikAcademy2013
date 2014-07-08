/*global console: false*/
function Rect(x, y, width, height) {
    "use strict";
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.calcArea = function () {
        return this.width * this.height;
    };

    this.calcPerimeter = function () {
        return 2 * this.width + 2 * this.height;
    };
}

var rects = [
    new Rect(50, 55, 15, 10),
    new Rect(50, 55, 25, 20),
    new Rect(50, 55, 15, 20),
    new Rect(50, 55, 10, 25)],
    i,
    len,
    rect;

for (i = 0, len = rects.length; i < len; i += 1) {
    rect = rects[i];
    console.log('The area of rect #' + (i + 1) + ' is ' + rect.calcArea());
}