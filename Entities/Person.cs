using System;
using System.ComponentModel.DataAnnotations;

namespace CarBookingAPI.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DriversLicenseNo { get; set; }
        [Required]
        public string IssuedState { get; set; }
    }
}
