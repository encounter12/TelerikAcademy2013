/*jslint browser: true*/
/*global jsConsole, isInputValid*/

(function () {
    'use strict';
    function twoDigitsNumberNameEn(number) {
        if (number > 99) {
            return;
        }

        var digitsNames,
            tensNames,
            numberName;

        //digits names
        digitsNames = {};
        digitsNames[0] = 'zero';
        digitsNames[1] = 'one';
        digitsNames[2] = 'two';
        digitsNames[3] = 'three';
        digitsNames[4] = 'four';
        digitsNames[5] = 'five';
        digitsNames[6] = 'six';
        digitsNames[7] = 'seven';
        digitsNames[8] = 'eight';
        digitsNames[9] = 'nine';

        //tens names
        tensNames = {};
        tensNames[10] = 'ten';
        tensNames[11] = 'eleven';
        tensNames[12] = 'twelve';
        tensNames[13] = 'thirteen';
        tensNames[14] = 'fourteen';
        tensNames[15] = 'fifteen';
        tensNames[16] = 'sixteen';
        tensNames[17] = 'seventeen';
        tensNames[18] = 'eighteen';
        tensNames[19] = 'nineteen';
        tensNames[20] = 'twenty';
        tensNames[30] = 'thirty';
        tensNames[40] = 'fourty';
        tensNames[50] = 'fifty';
        tensNames[60] = 'sixty';
        tensNames[70] = 'seventy';
        tensNames[80] = 'eighty';
        tensNames[90] = 'ninety';

        numberName = '';

        if (number >= 0 && number < 10) {
            numberName = digitsNames[number];
        } else if (number >= 10 && number < 20) {
            numberName = tensNames[number];
        } else {
            //20, 30, ... 90
            if ((number % 10) === 0) {
                numberName = tensNames[(number / 10) * 10];
            } else { //21, 22, 31, 32, ...
                numberName = tensNames[parseInt(number / 10, 10) * 10] + '-' + digitsNames[number % 10];
            }
        }

        return numberName;
    }

    /**
     * Method for getting the English name of the numbers from 0 to 999
     * Used the names generation rules from
     * http://simple.wikipedia.org/wiki/Names_of_numbers_in_English
     */
    function threeDigitsNumberNameEn(number) {
        if (number > 999) {
            return;
        }

        var hundred = 'hundred',
            and = 'and',
            numberName = '';

        if (number <= 99) {
            numberName = twoDigitsNumberNameEn(number);
        } else {
            numberName = twoDigitsNumberNameEn(parseInt(number / 100, 10)) + ' ' + hundred;

            //left over
            if ((number % 100) !== 0) {
                numberName += ' ' + and + ' ' + twoDigitsNumberNameEn(number % 100);
            }
        }

        return numberName;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "num")) {

            var number = parseInt(document.getElementById("num").value, 10);
            jsConsole.writeLine(number + " -&gt; '" + threeDigitsNumberNameEn(number) + "'");

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };

}());