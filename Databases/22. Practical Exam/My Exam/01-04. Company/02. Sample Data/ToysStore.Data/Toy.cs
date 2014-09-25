namespace ToysStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Toy
    {
        public Toy()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        public int AgeRangeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual AgeRanx AgeRanx { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
