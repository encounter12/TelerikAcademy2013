define(["player"], function (Player) {
    var Players;
    
    Players = (function() {
        function Players() {
            this.playersList = [];
        }

        Players.prototype.update = function(currentPlayer) {

            var len = this.playersList.length;
            var isPlayerFound = false;
            
            for (var i = 0; i < len; i++) {
                if (this.playersList[i].nickname === currentPlayer.nickname) {
                    isPlayerFound = true;
                    this.playersList[i].add(currentPlayer.games[0]);
                    break;
                } 
            }

            if (!isPlayerFound || this.playersList.length === 0) {
                this.playersList.push(currentPlayer);
            } 
        }

        Players.prototype.toString = function() {
            var playersListStr = "Players list: ";
            for (var i = 0; i < this.playersList.length; i++) {
                playersListStr += "<br />" + this.playersList[i].toString();
            }
            return playersListStr;
        };
        
        return Players;
    })();

    return Players;
});