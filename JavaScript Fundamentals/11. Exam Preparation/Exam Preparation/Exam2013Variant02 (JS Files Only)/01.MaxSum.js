function Solve(input) {

    var input = input.map(Number);
    var n = input[0];
    var maxSum = - Number.MAX_VALUE;
    var currentSum;

    for (var i = 1; i <= n; i++) {
        currentSum = 0;

        for (var j = i; j <= n; j++) {
            currentSum += input[j];

            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }
    }

    return maxSum;
}

//var input = [8, 1, 6, -9, 4, 4, -2, 10, -1];
//console.log(Solve(input));
//Answer: 16


//var fs = require("fs");
//fs.readFile('Tests/test.000.002.in.txt', function (error, fileContent) {
//    var input = fileContent.toString().split('\n');
//    // use the input array
//    console.log(Solve(input));
//});
//Answer: 15