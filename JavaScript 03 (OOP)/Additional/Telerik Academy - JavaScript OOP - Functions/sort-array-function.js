'use strict';
//Deep copies object
    function clone(obj) {

        var copy,
            i,
            attr;

        // Handle the 3 simple types, and null or undefined
        if (obj === null || typeof obj !== "object") {
            return obj;
        }

        // Handle Date
        if (obj instanceof Date) {
            copy = new Date();
            copy.setTime(obj.getTime());
            return copy;
        }

        // Handle Array
        if (obj instanceof Array) {
            copy = [];
            for (i = 0; i < obj.length; i += 1) {
                copy[i] = clone(obj[i]);
            }
            return copy;
        }

        // Handle Object
        if (obj instanceof Object) {
            copy = {};
            for (attr in obj) {

                if (obj.hasOwnProperty(attr)) {
                    copy[attr] = clone(obj[attr]);
                }
            }
            return copy;
        }

        throw new Error("Unable to copy obj! Its type isn't supported.");
    }

var numbers = [3, 2, 1, 3, 4, 5, 1, 2, 3, 4, 5, 7, 9];


console.log(numbers);

var clonedNumbers =  clone(numbers);

//sort array ascendingly
clonedNumbers.sort(function (x, y) {return x - y; });

console.log(clonedNumbers);

//sort array descendingly
clonedNumbers.sort(function (x, y) {return y - x; });

console.log(clonedNumbers);

console.log(numbers);