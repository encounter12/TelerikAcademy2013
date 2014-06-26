'use strict';

//using () the anonymous function gets self-invoked, prints the "inner text" on the console and the return value is being assigned to variable "result"
var result = function () {
    console.log("inner text");
    return 2;
}();

//the value of variable "result" is printed on the console
console.log(result);

//the value of variable "result" is printed on the console
console.log(result);