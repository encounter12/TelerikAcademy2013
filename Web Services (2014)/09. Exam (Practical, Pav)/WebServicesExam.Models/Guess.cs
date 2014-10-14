namespace WebServicesExam.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Guess
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "char")]
        public string Number { get; set; }

        [Required]
        public int BullsCount { get; set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
