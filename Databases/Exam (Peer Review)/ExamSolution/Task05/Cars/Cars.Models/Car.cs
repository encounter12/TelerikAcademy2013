using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Car
    {
        private ICollection<Dealer> dealers;

        public Car()
        {
            this.dealers = new HashSet<Dealer>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        }
    }
}
