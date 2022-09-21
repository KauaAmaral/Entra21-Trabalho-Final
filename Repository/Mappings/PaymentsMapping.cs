using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    public class PaymentsMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PayerId)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnName("payer_id");       
            
            builder.Property(x => x.Token)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("token");  
            
            builder.Property(x => x.TransactionId)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("transaction_id");

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("create_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("update_at");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(x => x.VehicleId)
                .HasColumnType("INT")
                .HasColumnName("vehicle_id");

            builder.Property(x => x.UserId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("user_id");
          
            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.UserId);
        }
    }
}
