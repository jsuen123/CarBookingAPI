using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBookingAPI.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        public Guid CarId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
