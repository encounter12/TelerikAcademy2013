namespace ToysStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AgeRanx
    {
        public AgeRanx()
        {
            Toys = new HashSet<Toy>();
        }

        public int Id { get; set; }

        public short MinAge { get; set; }

        public short? MaxAge { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
