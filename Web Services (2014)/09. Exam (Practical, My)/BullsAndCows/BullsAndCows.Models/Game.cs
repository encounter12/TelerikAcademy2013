namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public int YourNumber { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }

        public Game()
        {
            this.Guesses = new HashSet<Guess>();
        }
    }
}
