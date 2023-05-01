using Microsoft.EntityFrameworkCore;
using TruckManager.Domain.Common.Models;
using TruckManager.Domain.CompanyAggregate;
using TruckManager.Domain.TruckAggregate;
using TruckManager.Domain.UserAggregate;
using TruckManager.Infrastructure.Persistence.Interceptors;

namespace TruckManager.Infrastructure.Persistence
{
    public class TruckManagerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public TruckManagerDbContext(DbContextOptions options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) 
            : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(TruckManagerDbContext).Assembly);
            modelBuilder.Model.GetEntityTypes()
                              .SelectMany(e => e.GetProperties())
                              .Where(p => p.IsPrimaryKey())
                              .ToList()
                              .ForEach(p => p.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
