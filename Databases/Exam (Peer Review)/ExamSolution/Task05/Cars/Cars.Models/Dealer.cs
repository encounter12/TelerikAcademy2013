using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Dealer
    {
        private ICollection<City> cities;

        public Dealer()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        //public int CityId { get; set; }

        //public virtual City City { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

    }
}
