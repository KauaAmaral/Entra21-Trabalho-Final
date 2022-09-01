using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    public class NotificationMapping : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notification");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .HasColumnName("status");

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("create_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("update_at");

            builder.Property(x => x.GuardId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("guard_id");

            builder.HasOne(x => x.Guard)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.GuardId);

            builder.Property(x => x.VehicleId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("vehicle_id");

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.VehicleId);

            builder.Property(x => x.RegisteredVehicle)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .HasColumnName("register_vehicle");

            builder.Property(x => x.Address)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("address");
        }
    }
}
