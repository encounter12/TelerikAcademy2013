//function Solve(input) {

//    if (input[input.length - 1] === '' || input[input.length - 1] === undefined) {
//        input.pop();
//    }

//    var grid = fillGrid(input);

//    var currentRow = 0;
//    var currentCol = grid[0].length - 1;

//    var directions = [
//        [1, 0],
//        [0, -1],
//        [-1, 0],
//        [0, -1]
//    ];

//    var turnsCount = 0;
//    var trackLength = 0;
//    var directionsCount = 0;

//    while (true) {

//        //deadEndReached check
//        //trackCompleted check

//        currentRow = directions[directionsCount][0];

//        directionsCount++;
//        //increase counters 
//    }


//    function fillGrid(input) {
//        var grid = [];
//        for (var rows = 0; rows < input.length; rows++) {
//            grid[rows] = [];
//            for (var cols = input.length - 1; cols >= 0; cols--) {
//                grid[rows][cols] = getBitAtPosition(input[rows], input.length - 1 - cols);
//            }
//        }
//        return grid;
//    }

//    function getBitAtPosition(number, position) {
//        var mask = 1 << position;
//        return ((number & mask) >> position);
//    }
//}


//var input = [
//    2,
//    38,
//    20,
//    48,
//    111,
//    15,
//    3,
//    43
//];

//Solve(input);

////var fs = require("fs");
////fs.readFile('Tests/test.000.001.in.txt', function (error, fileContent) {
////    var input = fileContent.toString().split('\n');
////    // use the input array
////    console.log(Solve(input));
////});
