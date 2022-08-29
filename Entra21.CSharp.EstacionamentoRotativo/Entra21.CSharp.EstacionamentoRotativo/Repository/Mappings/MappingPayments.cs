using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Mappings
{
    public class MappingPayments : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
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
