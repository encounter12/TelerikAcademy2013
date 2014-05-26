/*global jsConsole, isInputValid*/
/*jslint browser: true*/

(function () {
    'use strict';
    function sortDescending(numbers) {
        var temp;
        if (numbers[1] < numbers[2]) {
            temp = numbers[1];
            numbers[1] = numbers[2];
            numbers[2] = temp;
        }
        if (numbers[0] < numbers[1]) {
            temp = numbers[0];
            numbers[0] = numbers[1];
            numbers[1] = temp;
        }
        if (numbers[1] < numbers[2]) {
            temp = numbers[1];
            numbers[1] = numbers[2];
            numbers[2] = temp;
        }
        return numbers;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "number01") && isInputValid("int", "number02") && isInputValid("int", "number03")) {
            var numbers = new Array(3);
            numbers[0] = Number(document.getElementById("number01").value);
            numbers[1] = Number(document.getElementById("number02").value);
            numbers[2] = Number(document.getElementById("number03").value);

            sortDescending(numbers);
            jsConsole.writeLine("The values sorted in descending order are: " + numbers.join(", "));

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };
}());