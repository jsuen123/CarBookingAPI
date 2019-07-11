using System;

namespace CarBookingAPI.Models
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
    }
}
