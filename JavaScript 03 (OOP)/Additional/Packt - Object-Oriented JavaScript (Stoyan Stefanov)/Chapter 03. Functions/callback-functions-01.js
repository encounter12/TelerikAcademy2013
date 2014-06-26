'use strict';
function multiplyByTwo(a, b, c, callback) {
    var i, 
        numbers = [],
        len = arguments.length - 1;

    for (i = 0; i < len; i++) {
        numbers[i] = callback(arguments[i] * 2);
    }
    return numbers;
}

function addOne(a) {
    return a + 1;
}

var myarr = multiplyByTwo(1, 2, 3, addOne);

console.log(myarr);