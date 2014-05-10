function isNumberEven(input) {
    if (input % 2 === 0) {
        return true;
    }
    return false;
}

function isInt(n) {
    return (typeof n === 'number' && n % 1 === 0);
}

document.getElementById("process").onclick = function () {
    var input = +document.getElementById("num").value; //the unary plus (+) converts its operand into a number
    if (!isNaN(input)) {
        if (isInt(input)) {
            jsConsole.writeLine("The number \"" + input + "\" is " + (isNumberEven(input) ? "even." : "odd."));
        } else {
            jsConsole.writeLine("The number \"" + input + "\" is floating point number. Please enter integer.");
        }

    } else {
        jsConsole.writeLine("The entered value is not a number. Please enter number.");
    }
}