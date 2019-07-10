using System;
using System.ComponentModel.DataAnnotations;

namespace CarBookingAPI.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(4)]
        [Required]
        public int Year  { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Registration { get; set; }
    }
}
