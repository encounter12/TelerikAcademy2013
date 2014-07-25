define(function () {
    var Guess;
    
    Guess = (function() {
        function Guess(inputNumber, randomNumber) {
            this.inputNumber = inputNumber;
            this.rams = getRamsNumber(inputNumber, randomNumber);
            this.sheep = getSheepNumber(inputNumber, randomNumber);
        }

        function getRamsNumber(input, randomNumber) {
            var ramsCount = 0,
                inputNumberString = input.toString(),
                randomNumberString = randomNumber.toString();

            for (var i = 0; i < inputNumberString.length; i++) {
                if (inputNumberString[i] === randomNumberString[i]) {
                    ramsCount += 1;
                }       
            }
            return ramsCount;
        }

        function getSheepNumber(input, randomNumber) {
            var sheepCount = 0,
                inputNumberString = input.toString(),
                randomNumberString = randomNumber.toString();

            for (var i = 0; i < inputNumberString.length; i++) {
                for (var j = 0; j < randomNumberString.length; j++) {
                    if (i != j && inputNumberString[i] === randomNumberString[j]) {
                        sheepCount += 1;
                    } 
                }
            }

            return sheepCount;
        }

        Guess.prototype.toString = function() {
            return "User input: " + this.inputNumber
                    + ", Rams: " + this.rams
                    + ", Sheep: " + this.sheep;
        };

        return Guess;
    })();

    return Guess;
});