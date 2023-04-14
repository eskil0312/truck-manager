using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckManager.Domain.CompanyAggregate;
using TruckManager.Domain.CompanyAggregate.ValueObjects;

namespace TruckManager.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            ConfigureCompaniesTable(builder);
            ConfigureCompanyTruckIdsTable(builder);
            ConfigureCompanyUserIdsTable(builder);
        }

        private static void ConfigureCompanyUserIdsTable(EntityTypeBuilder<Company> builder)
        {
            builder.OwnsMany(c => c.UserIds, uib =>
            {
                uib.WithOwner().HasForeignKey("UserId");
                uib.ToTable("CompanyUserIds");
                uib.HasKey("Id");

                uib.Property(ti => ti.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("CompanyUserId");
            });
        }

        private static void ConfigureCompanyTruckIdsTable(EntityTypeBuilder<Company> builder)
        {
            builder.OwnsMany(c => c.TruckIds, tib =>
            {
                tib.WithOwner().HasForeignKey("TruckId");
                tib.ToTable("CompanyTruckIds");
                tib.HasKey("Id");

                tib.Property(ti => ti.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("CompanyTruckId");
            });


        }

        private static void ConfigureCompaniesTable(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => CompanyId.Create(value));

            builder.Property(t => t.CompanyName).HasMaxLength(50);
        }
    }
}
