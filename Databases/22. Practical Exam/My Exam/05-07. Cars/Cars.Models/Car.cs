namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        public int Id { get; set; }

        // MaxLength is extended to 20 in the task description
        // because in the JSON data there are models with more than 10 symbols !!!
        [MaxLength(20)]
        [Required]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        // This is NOT DB field. It's used only for the JSON importer
        // to be able to reuse this class when parsing the json data
        [NotMapped]
        public string ManufacturerName { get; set; }

        [Required]
        public int DealerId { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }
    }
}
