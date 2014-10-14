namespace WebServicesExam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.State = GameState.WaitingForOpponent;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public GameState State { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        public virtual ApplicationUser RedPlayer { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "char")]
        public string RedPlayerNumber { get; set; }
        
        public string BluePlayerId { get; set; }
        
        public virtual ApplicationUser BluePlayer { get; set; }
        
        [StringLength(4)]
        [Column(TypeName = "char")]
        public string BluePlayerNumber { get; set; }
        
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
