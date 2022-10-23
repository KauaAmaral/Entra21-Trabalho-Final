using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.TokenExpiredDate)
                .IsRequired()
                .HasColumnType("DATETIME2");

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
                .HasMaxLength(64);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("DATETIME2");

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.Hierarchy)
                .HasColumnType("TINYINT")
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(x => x.IsEmailConfirmed)
                .HasColumnType("BIT")
                .HasDefaultValue(false);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Token = new Guid("924e32c0-6523-4efc-ac8f-04ff1ef63220"),
                    TokenExpiredDate = new DateTime(2005 - 08 - 08),
                    Name = "Admin",
                    Email = "admin@admin.com",
                    Password = "1234".GetHash(),
                    Cpf = "111.111.111-11",
                    Phone = "1111111111",
                    CreatedAt = new DateTime(2005 - 08 - 08),
                    Hierarchy = Enums.UserHierarchy.Administrador,
                    Status = true,
                    IsEmailConfirmed = true
                });
        }
    }
}