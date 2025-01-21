using Microsoft.EntityFrameworkCore;
using RepairAndConstructionApp.Models;

namespace RepairAndConstructionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 2); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
