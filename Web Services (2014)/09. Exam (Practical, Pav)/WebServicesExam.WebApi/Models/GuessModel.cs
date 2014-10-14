namespace WebServicesExam.WebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using WebServicesExam.Models;

    public class GuessModel
    {
        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return guess => new GuessModel
                {
                    Id = guess.Id,
                    UserId = guess.User.Id,
                    Username = guess.User.UserName,
                    GameId = guess.Game.Id,
                    Number = guess.Number,
                    DateMade = guess.DateCreated,
                    CowsCount = guess.CowsCount,
                    BullsCount = guess.BullsCount,
                };
            }
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        public int BullsCount { get; set; }
    }
}