namespace WebServicesExam.WebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using WebServicesExam.Models;

    public class GameModel
    {
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return game => new GameModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    Blue = game.BluePlayer != null ? game.BluePlayer.Email : "No blue player yet",
                    Red = game.RedPlayer.Email,
                    GameState = game.State.ToString(),
                    DateCreated = game.DateCreated,
                };
            }
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Blue { get; set; }

        [Required]
        public string Red { get; set; }

        [Required]
        public string GameState { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}