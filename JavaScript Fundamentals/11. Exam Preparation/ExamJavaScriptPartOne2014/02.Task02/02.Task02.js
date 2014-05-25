function Solve(input) {

    var dimensions = parseNumbers(input[0]);
    var rows = dimensions[0];
    var cols = dimensions[1];

    var directions = parseDirections(rows, cols);
    var field = parseField(rows, cols);

    var currentRow = rows - 1;
    var currentCol = cols - 1;

    var visitedCellsSum = 0;
    var jumps = 0;

    while (true) {

        //check if stepping over visited cell  or going otside of the field  - return condition
        if (currentRow < 0 || currentCol < 0 || currentRow >= rows || currentCol >= cols) {
            return "Go go Horsy! Collected " + visitedCellsSum + " weeds";
        }

        if (field[currentRow][currentCol] === 'X') {
            return "Sadly the horse is doomed in " + jumps + " jumps";
        }

        //recalculate visitedCellsSum and jumps

        visitedCellsSum += field[currentRow][currentCol];
        jumps += 1;


        //mark curent cell as visited - X 
        field[currentRow][currentCol] = 'X';

        //move(currentRow, currentCol, directions[currentRow][currentCol]);

        switch (directions[currentRow][currentCol]) {
            case 1:
                currentRow -= 2;
                currentCol += 1;
                break;
            case 2:
                currentRow -= 1;
                currentCol += 2;
                break;
            case 3:
                currentRow += 1;
                currentCol += 2;
                break;
            case 4:
                currentRow += 2;
                currentCol += 1;
                break;
            case 5:
                currentRow += 2;
                currentCol -= 1;
                break;
            case 6:
                currentRow += 1;
                currentCol -= 2;
                break;
            case 7:
                currentRow -= 1;
                currentCol -= 2;
                break;
            case 8:
                currentRow -= 2;
                currentCol -= 1;
                break;
            default:
                "Error"
        }
    }

    function parseNumbers(input) {
        return input.split(' ').map(Number);
    }

    function parseDirections(rows, cols) {
        var directions = []
        for (var i = 1; i < rows + 1; i++) {
            directions[i - 1] = input[i].split('').map(Number);
        }
        return directions;
    }

    function parseField(rows, cols) {
        var field = [];
        for (var i = 0; i < rows; i++) {
            var firstElement = Math.pow(2, i);
            field[i] = [];
            field[i][0] = firstElement;
            for (var j = 1; j < cols; j++) {
                firstElement -= 1;
                field[i][j] = firstElement;
            }
        }
        return field;
    }
}


var test01 = [
'3 5',
'54561',
'43328',
'52388',
];

var test02 = [
'3 5',
'54361',
'43326',
'52888',
];

console.log(Solve(test02));

