using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    internal class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LicensePlate)
                .HasColumnName("license_plate")
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(8);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Type)
                .HasColumnName("vehicle_type")
                .IsRequired()
                .HasColumnType("TINYINT");

            builder.Property(x => x.UserId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(x => x.Status)
              .IsRequired()
              .HasColumnType("BIT");
           
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("update_at")
                .HasColumnType("DATETIME2");


            builder.HasOne(x => x.User)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.UserId);

            builder.HasData(
               new Vehicle
               {
                   Id = 1,
                   LicensePlate = "fhf-1234",
                   Model = "123121234",
                   Type = 0,
                   UserId = 1,
                   Status = true,
                   CreatedAt = DateTime.Now
               }) ;

//INSERT INTO vehicles(license_plate, Model, vehicle_type, user_id, Status, created_at) VALUES('324123h', '12hj1', 0, 1, 'true', '1334-12-12')

//SELECT* From vehicles

        }
    }
}
