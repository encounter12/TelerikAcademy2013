function Solve(input) {
    var input = input.map(Number);
    var pocketMoney = input[0];
    var maxSpentSum = - Number.MAX_VALUE;
    var currentSpentSum = 0;

    var cakePrices = [input[1], input[2], input[3]];

    var cake1MaxCount = parseInt(pocketMoney / input[1]);
    var cake2MaxCount = parseInt(pocketMoney / input[2]);
    var cake3MaxCount = parseInt(pocketMoney / input[3]);

    for (var i = 0; i <= cake1MaxCount; i++) {

        var cake1SpentMoney = i * input[1];

        for (var j = 0; j <= cake2MaxCount; j++) {

            var cake2SpentMoney = j * input[2];

            for (var k = 0; k <= cake3MaxCount; k++) {

                var cake3SpentMoney = k * input[3];

                currentSpentSum = cake1SpentMoney + cake2SpentMoney + cake3SpentMoney;

                if (currentSpentSum <= pocketMoney && currentSpentSum > maxSpentSum) {
                    maxSpentSum = currentSpentSum;
                }
            }
        }
    }
    return maxSpentSum;
}

var firstTest = [
    110,
    13,
    15,
    17
];

var secondTest = [
    20,
    11,
    200,
    300
];

var thirdTest = [
        110,
        19,
        29,
        39
];

console.log(Solve(firstTest));
console.log(Solve(secondTest));
console.log(Solve(thirdTest));