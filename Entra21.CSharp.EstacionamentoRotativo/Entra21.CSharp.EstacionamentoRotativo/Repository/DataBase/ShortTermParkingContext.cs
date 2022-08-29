using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Mappings;

namespace Repository.DataBase
{
    public class ShortTermParkingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ShortTermParkingContext(DbContextOptions<ShortTermParkingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
