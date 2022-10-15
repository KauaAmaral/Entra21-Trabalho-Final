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
                .IsRequired()
                .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("update_at")
                .HasColumnType("DATETIME2");

            //INNE JOIN 
            builder.Property(x => x.GuardId)
                .HasColumnType("INT")
                .HasColumnName("guard_id");

            builder.HasOne(x => x.Guard)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.GuardId);

            builder.Property(x => x.VehicleId)
                 .HasColumnType("INT")
                 .HasColumnName("vehicle_id");

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
            //Endereço e comentario
            builder.Property(x => x.Address)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("address");

            builder.Property(x => x.Comments)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .HasColumnName("comments");
            //Vehicle
            builder.Property(x => x.VehicleLicensePlate)
                .HasColumnType("VARCHAR")
                .HasMaxLength(8)
                .IsRequired()
                .HasColumnName("vehicle_license_plate");

            builder.Property(x => x.RegisteredVehicle)
                .HasColumnType("BIT")
                .HasColumnName("register_vehicle");

            builder.Property(x => x.Type)
                .HasColumnName("vehicle_type")
                .IsRequired()
                .HasColumnType("TINYINT");

            builder.Property(x => x.NotificationAmount)
                .HasColumnName("notification_amount")
                .IsRequired()
                .HasColumnType("TINYINT")
                .HasDefaultValue(1);
            //Pagamento
            builder.Property(x => x.Token)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .HasColumnName("token");

            builder.Property(x => x.PayerId)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15)
                .HasColumnName("payer_id");

            builder.Property(x => x.TransactionId)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .HasColumnName("transaction_id");

            builder.Property(x => x.Value)
                .HasColumnType("DECIMAL")
                .HasPrecision(5, 2)
                .HasColumnName("value");
        }
    }
}
