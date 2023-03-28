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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TruckManagerDbContext).Assembly);
            //modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()).Where(p => p.IsPrimaryKey()).ToList().ForEach(p => p.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never);
            base.OnModelCreating(modelBuilder);
        }
    }
}
