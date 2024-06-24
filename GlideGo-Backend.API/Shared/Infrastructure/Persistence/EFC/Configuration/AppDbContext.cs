using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using GlideGo_Backend.API.Profiles.Domain.Model.Aggregates;
using GlideGo_Backend.API.Profiles.Domain.Model.Entities;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Place here the configuration of the entities
        // Profiles Context
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Dni");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Contact,
            e =>
            {
                e.WithOwner().HasForeignKey("Dni");
                e.Property(a => a.Email).HasColumnName("EmailAddress");
                e.Property(a => a.Number).HasColumnName("PhoneNumber");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Age,
            a =>
            {
                a.WithOwner().HasForeignKey("Dni");
                a.Property(s => s.Age).HasColumnName("Age");
            });
        

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
    
}