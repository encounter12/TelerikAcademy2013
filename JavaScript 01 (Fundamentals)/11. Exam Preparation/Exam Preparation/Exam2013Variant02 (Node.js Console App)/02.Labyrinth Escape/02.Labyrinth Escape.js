function Solve(input) {
    var dimensions = parseNumbers(input[0]);
    var startPosition = parseNumbers(input[1]);

    var rows = dimensions[0];
    var cols = dimensions[1];

    var currentRow = startPosition[0];
    var currentCol = startPosition[1];

    var field = initField();
    var directions = parseDirections();

    var sumOfNumbers = 0;
    var visitedCells = 0;

    while (true) {
        if (currentRow < 0 || currentCol < 0 || currentRow >= rows || currentCol >= cols) {
            return "out " + sumOfNumbers;
        }
        
        if (field[currentRow][currentCol] === 'X') {
            return "lost " + visitedCells;
        }

        sumOfNumbers += field[currentRow][currentCol];
        field[currentRow][currentCol] = 'X';

        switch (directions[currentRow][currentCol]) {
            case 'l':
                currentCol -= 1;
                break;
            case 'r':
                currentCol += 1;
                break;
            case 'u':
                currentRow -= 1;
                break;
            case 'd':
                currentRow += 1;
                break;
            default:
                "No direction"
        }

        visitedCells++;
    }

    function parseNumbers(input) {
        return input.split(' ').map(Number);
    }

    function parseDirections() {
        var directions = [];
        var index = 0;
        for (var i = 2; i < rows + 2; i++) {
            directions[index] = input[i].split('');
            index++;
        }
        return directions;
    }

    function initField() {
        var field = [];
        var counter = 1;
        for (var i = 0; i < rows; i++) {
            field[i] = [];
            for (var j = 0; j < cols; j++) {
                field[i][j] = counter++;
            }
        }
        return field;
    }
}


//var input = [
//    "3 4",
//    "1 3",
//    "lrrd",
//    "dlll",
//    "rddd"]
//console.log(Solve(input));
//Answer: out 45


//var fs = require("fs");
//fs.readFile('Tests/test.000.002.in.txt', function (error, fileContent) {
//    var input = fileContent.toString().split('\n');
//    // use the input array
//    console.log(Solve(input));
//});
//Answer: lost 21