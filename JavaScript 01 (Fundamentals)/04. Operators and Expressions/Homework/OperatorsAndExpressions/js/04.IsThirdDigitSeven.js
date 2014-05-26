/*global jsConsole, isInputValid*/

function nthDigit(input, position) {
    return (Math.floor(input / Math.pow(10, position - 1))) % 10;
}

document.getElementById("process").onclick = function () {

    var input = Number(document.getElementById("num").value);

    //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
    if (isInputValid("int", "num") === true) {
        jsConsole.writeLine("Third digit (right to left) is 7: " + (nthDigit(input, 3) === 7));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
    }
};