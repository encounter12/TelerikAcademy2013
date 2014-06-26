function getRGB(hexColor) {
    var r = function () {
        return parseInt(hexColor.substring(1, 3), 16);
    }
    var g = function () {
        return parseInt(hexColor.substring(3, 5), 16);
    }
    var b = function () {
        return parseInt(hexColor.substring(5, 7), 16);
    }

    return "rgb(" + r() + ", " + g() + ", " + b() + ")";
}


var a = getRGB("#00FF00");

console.log(a);