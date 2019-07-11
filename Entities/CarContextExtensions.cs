using System;
using System.Collections.Generic;

namespace CarBookingAPI.Entities
{
    public static class CarContextExtensions
    {
        public static void EnsureSeedDataForContext(this CarDbContext context)
        {
            context.Cars.RemoveRange(context.Cars);
            context.Persons.RemoveRange(context.Persons);
            context.Bookings.RemoveRange(context.Bookings);
            context.SaveChanges();

            //Init Seed data
            var cars = new List<Car>()
            {
                new Car()
                {
                    Id = new Guid("8413a612-f743-4d9e-9032-88b6a140930e"),
                    Make = "Honda",
                    Model = "Civic",
                    Registration = "A12B34",
                    Year = 2019
                },

                new Car()
                {
                    Id = new Guid("4a483049-70cf-4ea0-ae09-70f1de11a48c"),
                    Make = "Honda",
                    Model = "Civic",
                    Registration = "ZZZ123",
                    Year = 2018
                },

                new Car()
                {
                    Id = new Guid("626c2527-1828-47f6-92c7-17f3c5d51d82"),
                    Make = "Subaru",
                    Model = "Impreza",
                    Registration = "ABC123",
                    Year = 2019
                },

                new Car()
                {
                    Id = new Guid("518c0119-4526-4ec5-9d94-87787ed4761d"),
                    Make = "Toyota",
                    Model = "Camry",
                    Registration = "ABD456",
                    Year = 2019
                }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();

            var person = new List<Person>()
            {
                new Person()
                {
                    Id = new Guid("e2daad18-32e9-4a6c-ab9b-332213932e86"),
                    FirstName = "Michael",
                    LastName = "Jordan",
                    DriversLicenseNo = "111111111",
                    IssuedState = "VIC"
                },

                new Person()
                {
                    Id = new Guid("d184b350-7379-4a35-9479-157bd0356219"),
                    FirstName = "Kevin",
                    LastName = "Durant",
                    DriversLicenseNo = "222222222",
                    IssuedState = "VIC"
                },

                new Person()
                {
                    Id = new Guid("2fae2515-a301-4c71-a93f-24134882c5f5"),
                    FirstName = "Stephen",
                    LastName = "Curry",
                    DriversLicenseNo = "333333333",
                    IssuedState = "NSW"
                },
            };

            context.Persons.AddRange(person);
            context.SaveChanges();

            var booking = new List<Booking>()
            {
                //Active booking
                new Booking()
                {
                    Id = new Guid("7b4eabcf-f72d-40fe-892d-e127f94f182f"),
                    CarId = new Guid("4a483049-70cf-4ea0-ae09-70f1de11a48c"),
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now.AddDays(1),
                    PersonId = new Guid("2fae2515-a301-4c71-a93f-24134882c5f5")
                },

                //Expired booking
                new Booking()
                {
                    Id = new Guid("506c781f-ef7f-4c87-b2ea-814349575c3e"),
                    CarId = new Guid("8413a612-f743-4d9e-9032-88b6a140930e"),
                    StartDateTime = new DateTime(2019, 07, 01, 13, 00, 00),
                    EndDateTime = new DateTime(2019, 07, 02, 13, 00, 00),
                    PersonId = new Guid("d184b350-7379-4a35-9479-157bd0356219")
                }
            } ;

            context.Bookings.AddRange(booking);
            context.SaveChanges();
        }

    }
}
