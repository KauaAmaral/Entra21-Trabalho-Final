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

            builder.Property(x => x.)
        }
    }
}
