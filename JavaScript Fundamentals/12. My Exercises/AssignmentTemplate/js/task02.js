window.onload = function fillArrayAndPrint() {
    jsConsole.writeLine("Specify the array length?");

    var length = 0;
    var clickNumber = 0;
    var arr = new Array;

    document.getElementById('process').onclick = function() {
        
        clickNumber++;

        if (clickNumber === 1) {
            length = parseInt(document.getElementById("num").value);
            arr = new Array(length);
            jsConsole.writeLine(length);
            jsConsole.writeLine("Enter array elements:");
            jsConsole.clearTextFields();
        }
        else if (clickNumber > 1 && clickNumber <= length + 1) {
            var input = document.getElementById("num").value;
            arr[clickNumber - 2] = input;
            jsConsole.writeLine(input);
            jsConsole.clearTextFields();

            if (clickNumber === length + 1) {
                jsConsole.writeLine("Array elements: " + arr.join(", "));
                jsConsole.writeLine("The array reversed: " + arr.reverse().join(", "));
            }
        }
        else if (clickNumber > length + 1) {
            clickNumber = 0;
            jsConsole.clearAll();
            fillArrayAndPrint();
        }
    };

    function clearAndRun() {
        jsConsole.clearAll();
        fillArrayAndPrint();
    }
}
