namespace WebServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Guess
    {
        [Key]
        public int Id { get; set;}

        public int UserId { get; set; }

        public virtual User User { get; set; }
        
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int Number { get; set; }
        
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }
        public int BullsCount { get; set; }
    }
}
