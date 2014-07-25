define(function () {
    var Game;
    
    Game = (function() {

        function Game(min, max) {
            this.guesses = [];
            this.randomInteger = getRandomInteger(min, max);
        }

        function getRandomInteger(min, max) {
            var randomInt = Math.floor(Math.random() * (max - min + 1)) + min;
            return randomInt;
        }
        
        Game.prototype = {
            "addGuess": function(guess) {
                this.guesses.push(guess);
            },
            "toString": function() {
                var gameStr = "Guesses:" ;
                for (var i = 0; i < this.guesses.length; i++) {
                    gameStr += "<br />" + this.guesses[i].toString();
                }
                return gameStr;
            }
        };

        return Game;
    })();

    return Game;
});