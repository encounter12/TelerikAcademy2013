using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class City
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }
    }
}
