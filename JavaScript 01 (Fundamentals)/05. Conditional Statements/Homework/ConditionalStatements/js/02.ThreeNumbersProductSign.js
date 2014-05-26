/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';
    function returnProductSign(a, b, c) {

        if (a === 0 || b === 0 || c === 0) {
            return "no sign";
        }

        if (a > 0) {
            if (b > 0) {
                if (c > 0) {
                    return "+";
                }
                return "-";
            }
            if (c > 0) {
                return "-";
            }
            return "+";
        }

        if (b > 0) {
            if (c > 0) {
                return "-";
            }
            return "+";
        }

        if (c > 0) {
            return "+";
        }
        return "-";
    }

    document.getElementById("process").onclick = function () {

        //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
        if (isInputValid("number", "num01") && isInputValid("number", "num02") && isInputValid("number", "num03")) {

            var a = Number(document.getElementById("num01").value),
                b = Number(document.getElementById("num02").value),
                c = Number(document.getElementById("num03").value);

            jsConsole.writeLine("Product sign: " + returnProductSign(a, b, c));
        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
        }
    };
}());