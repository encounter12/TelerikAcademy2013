using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    class Model
    {
        public int Id { get; set; }
        
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
