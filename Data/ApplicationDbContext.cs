using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairAndConstructionService.Models;

namespace RepairAndConstructionService.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for all models
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensures Identity configurations are applied

            // Identity role seeding (Optional: Adds admin and user roles)
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole { Id = "3", Name = "Worker", NormalizedName = "WORKER" }
            );

            // Review relationships
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Worker)
                .WithMany(w => w.Reviews)
                .HasForeignKey(r => r.WorkerId);

            // Booking relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Worker)
                .WithMany(w => w.Bookings)
                .HasForeignKey(b => b.WorkerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.JobOffer)
                .WithMany()
                .HasForeignKey(b => b.JobOfferId);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Job Offers
            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer { Id = 1, Title = "Electrical Repair", Description = "Fix wiring and installations", Price = 150M },
                new JobOffer { Id = 2, Title = "Plumbing Repair", Description = "Fix plumbing issues", Price = 200M }
            );

            // Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Alice Johnson", Email = "alice@mail.com", PhoneNumber = "1234567890" },
                new Customer { Id = 2, Name = "Bob Williams", Email = "bob@mail.com", PhoneNumber = "0987654321" }
            );

            // Workers
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id = 1, Name = "Dimitur Djerov", Specialization = "Electrician", Rating = 4.5 },
                new Worker { Id = 2, Name = "Jane Smith", Specialization = "Plumber", Rating = 4.8 }
            );

            // Services
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Title = "Roof Repair", Description = "Fix leaks and damage on your roof.", Price = 500M },
                new Service { Id = 2, Title = "Plumbing", Description = "Install new plumbing and fix water system issues.", Price = 150M },
                new Service { Id = 3, Title = "Painting", Description = "Interior and exterior painting services.", Price = 300M },
                new Service { Id = 4, Title = "Electrician", Description = "Electrical installations and repair.", Price = 200M }
            );
        }
    }
}


