using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.TruckAggregate;
using TruckManager.Domain.TruckAggregate.Entities;
using TruckManager.Domain.TruckAggregate.ValueObjects;

namespace TruckManager.Infrastructure.Persistence.Configurations
{
    public class TruckConfigurations : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            ConfigureTucksTable(builder);
            ConfigureTruckTankingsTable(builder);
            ConfigureTruckIncidentsTable(builder);
        }

        private void ConfigureTruckIncidentsTable(EntityTypeBuilder<Truck> builder)
        {
            builder.OwnsMany(t => t.Incidents, sb =>
            {
                sb.ToTable("TruckIncidents");
                sb.WithOwner().HasForeignKey("TruckId");
                sb.HasKey(nameof(TruckIncident.Id), "TruckId");
                sb.Property(ti => ti.Id)
                    .HasColumnName("TruckIncidentId")
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => TruckInicdentId.Create(value));

                sb.Property(ti => ti.Description).HasMaxLength(250);
                sb.Property(ti => ti.Title).HasMaxLength(50);

            });

            builder.Metadata.FindNavigation(nameof(Truck.Incidents))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureTruckTankingsTable(EntityTypeBuilder<Truck> builder)
        {
            builder.OwnsMany(t => t.Tankings, sb => 
            {
                sb.ToTable("TruckTankings");
                sb.WithOwner().HasForeignKey("TruckId");
                sb.HasKey(nameof(TruckTanking.Id), "TruckId");
                sb.OwnsOne(tt => tt.Cost);
                sb.Property(tt => tt.Id)
                    .HasColumnName("TruckTankingId")
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => TruckTankingId.Create(value));
            });

        }

        private void ConfigureTucksTable(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");
            builder.HasKey(t => t.Id);

            builder.Property(t =>  t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => TruckId.Create(value));

            builder.Property(t => t.RegistrationNumber).HasMaxLength(50);

            builder.Property(t => t.CompanyId)
                .HasConversion(
                id => id.Value,
                value => CompanyId.Create(value));

        }
    }
}
