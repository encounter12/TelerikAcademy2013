/*global jsConsole*/

//gets the value (1 or 0) of bit at position in integer's binary representation
function getBit(number, position) {
    var mask = 1 << position;
    return ((number & mask) >> position);
}

document.getElementById("process").onclick = function () {

    var input = Number(document.getElementById("num").value);

    //validation function takes 2 parameters: expectedType and inputElementId and returns true or false (defined in: userValidation.js)
    if (isInputValid("int", "num") === true) {
        jsConsole.writeLine(input + " (binary representation): " + input.toString(2));
        jsConsole.writeLine("3rd bit (counting from zero) is: " + getBit(input, 3));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
    }
}