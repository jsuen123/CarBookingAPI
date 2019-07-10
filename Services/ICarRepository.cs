using System.Collections.Generic;
using CarBookingAPI.Entities;

namespace CarBookingAPI.Services
{
    public interface ICarRepository
    {
        void AddBooking(Booking booking);
        IEnumerable<Car> GetAvailableCars();
        bool Save();
    }
}
