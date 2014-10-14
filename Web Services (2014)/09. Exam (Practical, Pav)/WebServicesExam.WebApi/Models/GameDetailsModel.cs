namespace WebServicesExam.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    
    using WebServicesExam.Models;

    public class GameDetailsModel
    {
        public static Expression<Func<Game, GameDetailsModel>> FromGame
        {
            get
            {
                return game => new GameDetailsModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    DateCreated = game.DateCreated,
                    Red = game.RedPlayer.Email,
                    Blue = game.BluePlayer.Email,
                    GameState = game.State.ToString(),
                };
            }
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Red { get; set; }
        
        [Required]
        public string Blue { get; set; }
        
        public string YourNumber { get; set; }

        public ICollection<GuessModel> YourGuesses { get; set; }

        public ICollection<GuessModel> OpponentGuesses { get; set; }
        
        public string YourColor { get; set; }

        [Required]
        public string GameState { get; set; }
    }
}