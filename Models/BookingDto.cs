using System;

namespace CarBookingAPI.Models
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
