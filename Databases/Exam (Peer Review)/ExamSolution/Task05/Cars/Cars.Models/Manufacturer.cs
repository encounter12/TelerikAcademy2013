using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

    }
}
