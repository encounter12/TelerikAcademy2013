/*jslint browser: true*/
/*global jsConsole, isInputValid*/

(function () {
    'use strict';

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "num01") && isInputValid("int", "num02") &&
                isInputValid("int", "num03") && isInputValid("int", "num04") && isInputValid("int", "num05")) {

            var numberOne = parseFloat(document.getElementById("num01").value),
                numberTwo = parseFloat(document.getElementById("num02").value),
                numberThree = parseFloat(document.getElementById("num03").value),
                numberFour = parseFloat(document.getElementById("num04").value),
                numberFive = parseFloat(document.getElementById("num05").value),
                numbersArray,
                sortedNumbersArray;

            numbersArray = [numberOne, numberTwo, numberThree, numberFour, numberFive];
            // Clone array
            sortedNumbersArray = numbersArray.slice(0);
            // Sort numbers (numerically and descending)
            sortedNumbersArray.sort(function (a, b) { return b - a; });

            jsConsole.writeLine('The greatest number of ' + numbersArray.join(', ') + ' is ' + sortedNumbersArray[0]);

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };

}());