using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship between School and Transport
            modelBuilder.Entity<Transport>()
                .HasOne(t => t.School)
                .WithMany(s => s.Transports)
                .HasForeignKey(t => t.SchoolId);
            // Seed data for initial schools and admin
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "APS", Location = "Sawat", Fees = 1000 },
                new School { Id = 2, Name = "IQRA", Location = "Kohat", Fees = 1500 },
                new School { Id = 3, Name = "BIRD SKY", Location = "Mardan", Fees = 1200 },
                new School { Id = 4, Name = "CITY LEARN", Location = "Swabi", Fees = 1100 },
                new School { Id = 5, Name = "WALKSCHOOL", Location = "Lahore", Fees = 1300 }
            );

            // Seed data for transport buses
            modelBuilder.Entity<Transport>().HasData(
                new Transport { Id = 1, BusNumber = "Bus101", SchoolId = 1 },
                new Transport { Id = 2, BusNumber = "Bus102", SchoolId = 2 },
                new Transport { Id = 3, BusNumber = "Bus103", SchoolId = 3 },
                new Transport { Id = 4, BusNumber = "Bus104", SchoolId = 4 },
                new Transport { Id = 5, BusNumber = "Bus105", SchoolId = 5 }
            );

            // Seed a hardcoded admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Username = "admin", Password = "1234" }
            );
        }
    }

}