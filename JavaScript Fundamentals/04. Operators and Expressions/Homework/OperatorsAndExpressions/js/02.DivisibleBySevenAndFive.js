/*global jsConsole, isInputValid*/

function isDivisibleBy7And5(input) {
    if (input % 35 === 0) {
        return true;
    }
    return false;
}

document.getElementById("process").onclick = function () {
    var input = Number(document.getElementById("num").value);

    //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
    if (isInputValid("int", "num") === true) {
        jsConsole.writeLine("The number \"" + input + "\" is divisible by 7 and 5: " + isDivisibleBy7And5(input));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
    }
};