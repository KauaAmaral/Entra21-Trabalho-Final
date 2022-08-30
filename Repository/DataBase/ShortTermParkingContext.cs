using Microsoft.EntityFrameworkCore;
using Entra21.CSharp.Area21.RepositoryEntities;
using Entra21.CSharp.Area21.RepositoryMappings;

namespace Entra21.CSharp.Area21.RepositoryDataBase
{
    public class ShortTermParkingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public ShortTermParkingContext(DbContextOptions<ShortTermParkingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
