using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Add any additional configuration here
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reservation>().ToTable("Reservations");
            builder.Entity<Reservation>().HasKey(r => r.Id);
            builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Reservation>().Property(r => r.VehicleId).IsRequired();

            // Add any additional entity configurations here
        }
    }
}