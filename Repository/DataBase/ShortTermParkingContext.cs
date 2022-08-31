using Microsoft.EntityFrameworkCore;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Mappings;

namespace Entra21.CSharp.Area21.RepositoryDataBase
{
    public class ShortTermParkingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ShortTermParkingContext(DbContextOptions<ShortTermParkingContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new NotificationMapping());
        }
    }
}