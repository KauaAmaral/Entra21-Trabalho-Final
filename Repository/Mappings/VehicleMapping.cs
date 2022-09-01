using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    internal class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LicensePlate)
                .HasColumnName("license_plate")
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(8);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("DATETAME2");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("update_at")
                .HasColumnType("DATETAME2");

            builder.Property(x => x.Type)
                .HasColumnName("vehicle_type")
                .IsRequired()
                .HasColumnType("TINYINT");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("INT");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.UserId);

            builder.HasData(
                new Vehicle
                {
                    Id = 1,
                    LicensePlate = "fhf-1234",
                    Type = 0,
                    UserId = 1
                });
        }
    }
}
