namespace BullsAndCows.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.WebApi.Models;

    public class GamesController : ApiController
    {
        private const string noBluePlayerAvailable = "No blue player yet";

        private readonly IBullsAndCowsData data;

        public GamesController()
            : this(new ApplicationData())
        {
        }

        public GamesController(IBullsAndCowsData data)
        {
            this.data = data;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameDataModel model)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();

            var newGame = new Game
            {
                Name = model.Name,
                Blue = noBluePlayerAvailable,
                YourNumber = model.Number,
                DateCreated = DateTime.Now,
                GameState = GameState.WaitingForOpponent
            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            model.Id = newGame.Id;
            model.Red = currentUserId;
            model.Blue = newGame.Blue;
            model.DateCreated = newGame.DateCreated;

            return Ok(model);
        }
    }
}
