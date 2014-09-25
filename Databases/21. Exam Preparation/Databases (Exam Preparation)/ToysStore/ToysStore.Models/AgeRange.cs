namespace ToysStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AgeRange
    {
        public AgeRange()
        {
            this.Toys = new HashSet<Toy>();
        }

        public int Id { get; set; }

        public int? MinimumAge { get; set; }

        public int? MaximumAge { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
