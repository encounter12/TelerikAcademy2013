namespace ToysStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Toy
    {
        public Toy()
        {
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int AgeRangeId { get; set; }

        public string Color { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
