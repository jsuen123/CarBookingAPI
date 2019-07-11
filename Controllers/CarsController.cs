using System;
using System.Collections.Generic;
using AutoMapper;
using CarBookingAPI.Entities;
using CarBookingAPI.Models;
using CarBookingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBookingAPI.Controllers
{
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of cars
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/cars")]
        public IActionResult GetCars()
        {
            var carsFromRepo = _carRepository.GetAvailableCars();

            if (carsFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<Car>, IEnumerable<CarDto>>(carsFromRepo));
        }


        [HttpPost("/api/cars/{carId}")]
        public IActionResult CreateBooking(Guid carId, [FromBody] BookingForCreationDto booking)
        {
            if (booking == null)
                return BadRequest();

            if (!_carRepository.CarExists(carId))
                return NotFound();

            var isCarAvailable = _carRepository.CarAvailable(new Guid("626c2527-1828-47f6-92c7-17f3c5d51d82"));

            if (!isCarAvailable)
                return BadRequest($"The car is not available.");

            var bookingEntity = _mapper.Map<Booking>(booking);
            _carRepository.AddBooking(carId, bookingEntity);

            if (!_carRepository.Save())
                throw new Exception($"Creating a booking for car {carId} failed on save.");
            
            var bookingToReturn = _mapper.Map<BookingDto>(bookingEntity);

            return CreatedAtRoute("GetBooking",
                new { bookingId = bookingToReturn.Id },
                bookingToReturn);
        }

        [HttpGet("/booking/{bookingId}", Name = "GetBooking")]
        public IActionResult GetBooking(Guid bookingId)
        {
            if (!_carRepository.BookingExist(bookingId))
            {
                return NotFound();
            }

            var bookingFromRepo = _carRepository.GetBooking(bookingId);

            if (bookingFromRepo == null)
            {
                return NotFound();
            }

            var booking = Mapper.Map<BookingDto>(bookingFromRepo);
            return Ok(booking);
        }
    }
}
