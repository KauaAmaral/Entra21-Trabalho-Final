using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    internal class GuardMapping : IEntityTypeConfiguration<Guard>
    {
        public void Configure(EntityTypeBuilder<Guard> builder)
        {
            builder.ToTable("guards");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasColumnType("BIT")
                .IsRequired()
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

            builder.Property(x => x.IdentificationNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnName("identification_number");
            
            builder.Property(x => x.UserId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("user_id");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Guards)
                .HasForeignKey(x => x.UserId);

            builder.HasData(
               new Guard
               {
                   Id = 1,
                   IdentificationNumber = "0123456789", 
                   Status = true,
                   UserId = 1
               });
        }
    }
}
