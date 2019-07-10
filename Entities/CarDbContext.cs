using Microsoft.EntityFrameworkCore;

namespace CarBookingAPI.Entities
{
    public class CarDbContext:DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options): base(options)
        {
            Database.Migrate();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
