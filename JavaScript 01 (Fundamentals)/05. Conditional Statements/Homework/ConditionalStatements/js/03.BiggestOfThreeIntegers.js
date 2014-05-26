/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';
    function biggestInteger(a, b, c) {
        if (a >= b) {
            if (b > c) {
                return a;
            }
            if (a >= c) {
                return a;
            }
            return c;
        }
        if (b >= c) {
            return b;
        }
        return c;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "number01") && isInputValid("int", "number02") && isInputValid("int", "number03")) {
            var a = Number(document.getElementById("number01").value),
                b = Number(document.getElementById("number02").value),
                c = Number(document.getElementById("number03").value);
            jsConsole.writeLine("Biggest number is: " + biggestInteger(a, b, c));
        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };
}());