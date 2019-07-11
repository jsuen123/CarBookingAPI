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

        public void AddBooking(Guid carId, Booking booking)
        {
            booking.CarId = carId;
            booking.Id = Guid.NewGuid();
            booking.StartDateTime = DateTime.Now;
            booking.EndDateTime = booking.StartDateTime.AddDays(1);
            _context.Bookings.Add(booking);
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            var currentBookings = _context.Bookings.Where(b => b.EndDateTime > DateTime.Now);
            return _context.Cars.Where(c => !currentBookings.Select(b => b.CarId).Contains(c.Id));
        }

        public bool CarAvailable(Guid carId)
        {
            var currentBookings = _context.Bookings.Where(b => b.EndDateTime > DateTime.Now);
            var cars = _context.Cars.Where(c => !currentBookings.Select(b => b.CarId).Contains(c.Id));
            return cars.Any(c => c.Id == carId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool CarExists(Guid carId)
        {
            return _context.Cars.Any(c => c.Id == carId);
        }

        public bool BookingExist(Guid bookingId)
        {
            return _context.Bookings.Any(b => b.Id == bookingId);
        }

        public Booking GetBooking(Guid bookingId)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
        }
    }
}
