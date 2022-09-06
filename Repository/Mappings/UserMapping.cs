using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
                
            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            
            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME2");

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("BIT");

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@admin.com",
                    Password = "1234",
                    Cpf = "11111111111",
                    Phone = "1111111111",
                    CreatedAt = new DateTime(2005-08-08),
                    Status = true
                });
        }
    }
}
