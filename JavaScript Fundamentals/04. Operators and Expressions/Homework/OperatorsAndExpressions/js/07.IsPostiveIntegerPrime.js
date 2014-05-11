/*global jsConsole, isInputValid*/

//Primality Test - Trial division: http://en.wikipedia.org/wiki/Trial_division, http://en.wikipedia.org/wiki/Primality_test 
function isPrime(input) {
    if (input <= 1) {
        return false;
    }

    var maxDivisor = Math.floor(Math.sqrt(input));

    for (var i = 2; i <= maxDivisor; i++) {
        if (input % i === 0) {
            return false;
        }
    }
    return true;
}

document.getElementById("process").onclick = function () {

    var input = Number(document.getElementById("num").value);

    //validation function taking 2 parameters: expectedType and inputElementId and returning true or false (defined in: userValidation.js)
    if (isInputValid("int", "num") === true) {
        jsConsole.writeLine(input + " is " + (isPrime(input) ? "prime." : "not prime."));
    } else {
        jsConsole.writeLine("You have entered incorrect data type. Please re-enter");
    }
};