(function() {
    
    require.config({
        paths: {
            "jquery": "libs/jquery",
            "underscore": "libs/underscore",
            "utils": "utils",
            "game": "game",
            "guess": "guess",
            "player": "player",
            "players": "players",
            "storage-extensions": "storage-extensions"
        }
    });

    require(["jquery", "underscore", "utils", "game", "guess", "player", "players", "storage-extensions"], 
        function($, _, Utils, Game, Guess, Player, Players, StorageObjectExtensions) {

        var players = new Players(),
            TOP_PLAYERS_NUMBER = 2;
        createNewGame();

        $("#submit").click(function() {

            var isInputValid = Utils.validateInput("#int", "#inputContainer", "#submit", 4);

            if (isInputValid) {
                $("#inputContainer" + " span").remove();
                var input = parseInt($("#int").val());
                
                var guess = new Guess(input, game.randomInteger);

                game.addGuess(guess);
                addGuessToDom("#printboard", guess);
                

                if (isGameComplete(guess, game.randomInteger)) {

                    var player = new Player();
                    player.nickname = window.prompt("Game completed! Enter your nickname: ", "e.g. IronMan");
                    player.add(game);
                    players.update(player);

                    var isNewGameConfirmed = startNewGamePrompt();
                    if (isNewGameConfirmed) {
                        clearPrintboard();
                        createNewGame();
                    }
                    else {
                        
                        $("body").empty();
                        $("body").append($("<div>").html(players.toString()));

                        updateLocalStorage(players);
                        var playersFromLocalStorage = localStorage.getObject(players.constructor.name.toLowerCase());
                        var topPlayers = getTopPlayers(playersFromLocalStorage, TOP_PLAYERS_NUMBER);

                        $("body").append($("<div>").html(topPlayers));

                    }
                }
            } 
            else {
                $("#inputContainer" + " span").remove();
                Utils.displayInputError("#inputContainer");
                $("#int").focus(function() {
                    $("#inputContainer" + " span").remove();
                });
            }
        });

        function addGuessToDom(container, guess) {
            $(container).append($("<div>").html(guess.toString()));
        }
        function startNewGamePrompt() {
            var isNewGameConfirmed = window.confirm("Would you like to start a new game?");
            return isNewGameConfirmed;
        }

        function clearPrintboard() {
            $("#printboard").empty();
            $("#int").val("");
        }

        function createNewGame() {
            game = new Game(1000, 9999);
        }

        function isGameComplete(currentGuess, randomNumber) {
            if (currentGuess.rams === randomNumber.toString().length) {
                return true;
            }
            return false;
        }

        function getTopPlayers(players, topPlayersNumber) {
            var topPlayersString = "Top " + topPlayersNumber + " players: ";
            var sortedPlayersList = _.sortBy(players.playersList, "rating").reverse();
            var topPlayersList = sortedPlayersList.slice(0, topPlayersNumber);

            _.each(topPlayersList, function(player, index) {
                topPlayersString += "<br />" + (index + 1) + ". Nickname: " + player.nickname + ", Rating: " + player.rating;
            });

            return topPlayersString;
        }

        function updateLocalStorage(obj) {
            var objString = obj.constructor.name.toLowerCase();
            if (localStorage.getItem(objString) === null) {
                localStorage.setObject(objString, obj);
            }
            else {
                localStorage.clear();
                localStorage.setObject(objString, obj);
            }
        }

    });
}());