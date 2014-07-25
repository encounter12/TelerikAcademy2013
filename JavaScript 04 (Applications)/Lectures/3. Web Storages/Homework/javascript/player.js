define(["underscore"], function (_) {
    var Player;
    
    Player = (function() {

        function Player() {
            
            this.nickname = null;
            this.games = [];
            this.rating = 0;
        }

        function updateRating(self) {
            var RATING_COEFFICIENT = 50,
                guessesTotalNumber = 0;

            _.each(self.games, function(game) {
                guessesTotalNumber += game.guesses.length;
            });

            if (self.games.length === 0) {
                self.rating = 0;
            }
            else {
                var curentRatingRaw = RATING_COEFFICIENT / (guessesTotalNumber / self.games.length);
                self.rating = Math.round(curentRatingRaw * 100) / 100;
            }
        }


        Player.prototype.add = function(game) {

            this.games.push(game);
            var self = this;
            updateRating(self);
        };

        Player.prototype.toString = function() {
            var playerString = "Nickname: " + this.nickname 
                                + ", Played games: " + this.games.length  
                                + ", Rating: " + this.rating;
            return playerString;
        };

        return Player;
    })();

    return Player;
});