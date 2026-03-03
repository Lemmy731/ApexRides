using ApexRide.Models;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }   

        public DbSet<Admin> Admins { get; set; }    
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Inquiry> Inquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inquiry>()
                .HasOne(i => i.Car)
                .WithMany(c => c.Inquiries)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
