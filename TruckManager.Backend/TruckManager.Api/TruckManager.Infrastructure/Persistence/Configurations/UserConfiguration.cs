using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckManager.Domain.CompanyAggregate.ValueObjects;
using TruckManager.Domain.UserAggregate;
using TruckManager.Domain.UserAggregate.ValueObjects;

namespace TruckManager.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);

            static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("Users");
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

                builder.Property(t => t.FirstName).HasMaxLength(50);
                builder.Property(t => t.LastName).HasMaxLength(50);
                builder.Property(t => t.Email).HasMaxLength(50);


                builder.Property(t => t.CompanyId)
                    .HasConversion(
                    id => id.Value,
                    value => CompanyId.Create(value));
            }
        }
    }
}
