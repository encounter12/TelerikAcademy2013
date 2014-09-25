namespace ToysStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Toys = new HashSet<Toy>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
