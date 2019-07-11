using System;
using System.Collections.Generic;
using CarBookingAPI.Entities;

namespace CarBookingAPI.Services
{
    public interface ICarRepository
    {
        void AddBooking(Guid carId, Booking booking);
        IEnumerable<Car> GetAvailableCars();
        bool Save();
        bool CarExists(Guid carId);
        bool BookingExist(Guid bookingId);
        Booking GetBooking(Guid bookingId);
        bool CarAvailable(Guid carId);
    }
}
