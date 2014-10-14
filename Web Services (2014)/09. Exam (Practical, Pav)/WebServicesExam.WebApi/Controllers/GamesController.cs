namespace WebServicesExam.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using WebServicesExam.Data;
    using WebServicesExam.Models;
    using WebServicesExam.WebApi.Models;
    using WebServicesExam.WebApi.Infrastructure;

    public class GamesController : BaseApiController
    {
        protected Random RandomGenerator { get; set; }

        public GamesController(IApplicationData data, IUserIdProvider userIdProvider) :
            base(data, userIdProvider)
        {
            this.RandomGenerator = new Random();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(GameInputModel gameInput)
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var game = new Game();
            game.Name = gameInput.Name;
            game.RedPlayerId = currentUserId;
            game.RedPlayerNumber = gameInput.Number;
            game.DateCreated = DateTime.Now;

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            var gameModel = this.Data.Games
               .All()
               .Where(g => g.Id == game.Id)
               .Select(GameModel.FromGame)
               .FirstOrDefault();

            return Ok(gameModel);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Put(int id, GameInputModel gameInput)
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var game = this.Data.Games
                .All()
                .Where(g => g.Id == id && 
                    g.State == GameState.WaitingForOpponent &&
                    g.RedPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return BadRequest("Game does not exist or can not be played");
            }

            game.BluePlayerId = currentUserId;
            game.BluePlayerNumber = gameInput.Number;

            var turn = this.RandomGenerator.Next(0, 2);
            if (turn == 0)
            {
                game.State = GameState.RedInTurn;
            }
            else
            {
                game.State = GameState.BlueInTurn;
            }

            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            var result = new
            {
                result = "You joined game " + game.Name,
            };

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var game = this.Data.Games.All()
                .Where(g => g.Id == id && 
                    (g.State == GameState.BlueInTurn || g.State == GameState.RedInTurn) &&
                    (g.RedPlayerId == currentUserId || g.BluePlayerId == currentUserId))
                .FirstOrDefault();

            if (game == null)
            {
                return BadRequest("Game does not exist or does not belong to user");
            }

            var gameModel = new GameDetailsModel 
            {
                Id = game.Id,
                Name = game.Name,
                DateCreated = game.DateCreated,
                Red = game.RedPlayer.Email,
                Blue = game.BluePlayer.Email,
                GameState = game.State.ToString(),
            };

            string opponentUserId = string.Empty;

            if (currentUserId == game.RedPlayer.Id)
            {
                gameModel.YourNumber = game.RedPlayerNumber;
                gameModel.YourColor = "red";
                opponentUserId = game.BluePlayerId;
            }
            else
            {
                gameModel.YourNumber = game.BluePlayerNumber;
                gameModel.YourColor = "blue";
                opponentUserId = game.RedPlayerId;
            }

            var yourGuesses = this.Data.Guesses
                .All()
                .Where(g => g.GameId == id && g.User.Id == currentUserId)
                .Select(GuessModel.FromGuess)
                .ToList();

            gameModel.YourGuesses = yourGuesses;

            var opponentGuesses = this.Data.Guesses
                .All()
                .Where(g => g.GameId == id && g.User.Id == opponentUserId)
                .Select(GuessModel.FromGuess)
                .ToList();

            gameModel.OpponentGuesses = opponentGuesses;

            return Ok(gameModel);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var openGames = this.Data.Games.All()
                .Where(g => g.State == GameState.WaitingForOpponent)
                .OrderBy(g => g.State)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Select(GameModel.FromGame)
                .Take(10);

            return Ok(openGames);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Guess(int id, GameInputModel gameInput)
        {
            var currentUserId = this.UserIdProvider.GetUserId();

            var game = this.Data.Games
                .All()
                .Where(g => g.Id == id &&
                    (g.State == GameState.RedInTurn || g.State == GameState.BlueInTurn) &&
                    (g.RedPlayerId == currentUserId || g.BluePlayerId == currentUserId))
                .FirstOrDefault();

            if (game == null)
            {
                return BadRequest("Game does not exist or can not be played");
            }

            if (game.State == GameState.RedInTurn && game.BluePlayerId == currentUserId)
            {
                return BadRequest("It's not your turn");
            }

            if (game.State == GameState.BlueInTurn && game.RedPlayerId == currentUserId)
            {
                return BadRequest("It's not your turn");
            }

            //TODO: Calculate cows and bulls
            var guess = new Guess();
            guess.GameId = id;
            guess.Number = gameInput.Number;
            guess.User.Id = currentUserId;
            guess.BullsCount = 0;
            guess.CowsCount = 0;
            guess.DateCreated = DateTime.Now;

            this.Data.Guesses.Add(guess);
            this.Data.SaveChanges();

            var guessModel = this.Data.Guesses
               .All()
               .Where(g => g.Id == game.Id)
               .Select(GuessModel.FromGuess)
               .FirstOrDefault();

            return Ok(guessModel);
        }
    }
}