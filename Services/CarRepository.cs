using System.Collections.Generic;
using CarBookingAPI.Entities;

namespace CarBookingAPI.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }
    }
}
