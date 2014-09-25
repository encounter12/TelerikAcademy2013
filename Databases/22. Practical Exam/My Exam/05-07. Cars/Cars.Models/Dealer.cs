namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }

        // This is NOT DB field. It's used only for the JSON importer
        // to be able to reuse this class when parsing the json data
        [NotMapped]
        public string City { get; set; }
    }
}
