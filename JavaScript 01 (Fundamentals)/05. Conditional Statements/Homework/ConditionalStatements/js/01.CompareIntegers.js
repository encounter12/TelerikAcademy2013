/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';

    document.getElementById("process").onclick = function () {

        //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
        if (isInputValid("int", "int01") && isInputValid("int", "int02")) {

            var a = parseInt(document.getElementById("int01").value, 10),
                b = parseInt(document.getElementById("int02").value, 10),
                temp;

            if (a > b) {
                temp = a;
                a = b;
                b = temp;
            }
            jsConsole.writeLine("a = " + a + ", b = " + b);

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
        }
    };
}());