/*exported divisibleBy3And7*/

function divisibleBy3And7(inputFieldId) {
    var x = document.getElementById(inputFieldId).value;
    var outputString;

    if (isNaN(x) || x === "") {
        outputString = "Not a number";
    } else {
        outputString = x % (3 * 7) === 0 ? "divisible by 3 and 7" : "not divisible by 3 and 7";
    }
    return outputString;
}