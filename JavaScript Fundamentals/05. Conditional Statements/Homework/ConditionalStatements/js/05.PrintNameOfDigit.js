/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';
    function printDigitName(digit) {
        var digitName;

        switch (digit) {
        case 0:
            digitName = "zero";
            break;
        case 1:
            digitName = "one";
            break;
        case 2:
            digitName = "two";
            break;
        case 3:
            digitName = "three";
            break;
        case 4:
            digitName = "four";
            break;
        case 5:
            digitName = "five";
            break;
        case 6:
            digitName = "six";
            break;
        case 7:
            digitName = "seven";
            break;
        case 8:
            digitName = "eight";
            break;
        case 9:
            digitName = "nine";
            break;
        default:
            digitName = null;
        }

        return digitName;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "num")) {
            var digit = Number(document.getElementById("num").value);
            jsConsole.writeLine(printDigitName(digit));

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };
}());