namespace WebServices.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using WebServices.Models;

    public class GameDataModel
    {
        
        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return game => new GameDataModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    Blue = game.Blue,
                    Red = game.Red,
                    Number = game.YourNumber,
                    GameState = game.GameState.ToString(),
                    DateCreated = game.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public int Number { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}