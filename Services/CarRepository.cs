using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Car> GetAvailableCars()
        {
            var currentBookings = _context.Bookings.Where(b => b.EndDateTime > DateTime.Now);
            return _context.Cars.Where(c => !currentBookings.Select(b => b.CarId).Contains(c.Id));
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
