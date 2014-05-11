/*jslint browser: true*/
/*global jsConsole, isInputValid*/

(function () {
    'use strict';

    function solveQuadraticEquation(a, b, c) {
        var roots = [],
            discriminant;

        discriminant = b * b - 4 * a * c;

        if (discriminant > 0) {
            //two roots
            roots[0] = (-b + Math.sqrt(discriminant)) / (2 * a);
            roots[1] = (-b - Math.sqrt(discriminant)) / (2 * a);
        } else if (discriminant === 0) {
            //one double root
            roots[0] = -b / (2 * a);
            roots[1] = -b / (2 * a);
        }

        return roots;
    }

    document.getElementById("process").onclick = function () {

        if (isInputValid("int", "a") && isInputValid("int", "b") && isInputValid("int", "c")) {
            var coefficientA = Number(document.getElementById("a").value),
                coefficientB = Number(document.getElementById("b").value),
                coefficientC = Number(document.getElementById("c").value),
                equationString,
                roots;

            roots = solveQuadraticEquation(coefficientA, coefficientB, coefficientC);
            equationString = 'Equation ' + coefficientA + 'x<sup>2</sup> + ' + coefficientB + 'x + ' + coefficientC + ' = 0';

            if (roots.length > 0) {
                jsConsole.writeLine(equationString + ' has roots ' + roots[0] + ' and ' + roots[1]);
            } else {
                jsConsole.writeLine(equationString + ' has no real roots');
            }

        } else {
            jsConsole.writeLine("You have entered incorrect data type. Please, re-enter.");
        }
    };

}());