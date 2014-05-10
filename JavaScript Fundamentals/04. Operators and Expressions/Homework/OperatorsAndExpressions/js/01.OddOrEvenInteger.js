function isNumberEven(input) {
    if (input % 2 === 0) {
        return true;
    }
    return false;
}

document.getElementById("process").onclick = function () {
    
    var input = Number(document.getElementById("num").value);

    //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
    if (isInputValid("int", "num") === true) {
        jsConsole.writeLine("The number \"" + input + "\" is " + (isNumberEven(input) ? "even." : "odd."));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
    }  
}