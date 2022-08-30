using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Mappings
{
    public class PaymentsMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("pagamentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Auto)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("automovel_id");

            builder.Property(x => x.User)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("usuario_id");
        }
    }
}
