using Microsoft.EntityFrameworkCore;
using TruckManager.Domain.TruckAggregate;

namespace TruckManager.Infrastructure.Persistence
{
    public class TruckManagerDbContext : DbContext
    {
        public TruckManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; } = null!;
    }
}
