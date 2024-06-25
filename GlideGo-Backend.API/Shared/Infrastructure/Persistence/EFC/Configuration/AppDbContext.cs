using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using GlideGo_Backend.API.Design.Domain.Model.Aggregates;
using GlideGo_Backend.API.Design.Domain.Model.Entities;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<PublicationVehicle> PublicationVehicles { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<ElectricPublication> ElectricPublications { get; set; }
        public DbSet<ManualPublication> ManualPublications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    // Configuración de Location
    builder.Entity<Location>(entity =>
    {
        entity.HasKey(l => l.Id);
        entity.Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        entity.Property(l => l.Longitude).IsRequired().HasMaxLength(10);
        entity.Property(l => l.Latitude).IsRequired().HasMaxLength(10);
        entity.Property(l => l.AddressPickUp).HasMaxLength(120);

        entity.HasMany(l => l.PublicationVehicles)
              .WithOne(v => v.Location)
              .HasForeignKey(v => v.LocationId)
              .HasPrincipalKey(l => l.Id);
    });

    // Configuración de PublicationVehicle
    builder.Entity<PublicationVehicle>(entity =>
    {
        entity.HasKey(v => v.Id);
        entity.Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        entity.Property(v => v.Title).IsRequired().HasMaxLength(20);
        entity.Property(v => v.Summary).HasMaxLength(240);
        entity.Property(v => v.Category).IsRequired();
        entity.Property(v => v.SubCategory).IsRequired();
        entity.Property(v => v.Status).IsRequired();

        entity.Property(v => v.CreatedDate)
              .HasColumnName("CreatedAt")
              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.Property(v => v.UpdatedDate)
              .HasColumnName("UpdatedAt")
              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.HasMany(v => v.Publications)
              .WithOne()
              .OnDelete(DeleteBehavior.Cascade);
    });

    // Configuración de Publication
    builder.Entity<Publication>(entity =>
    {
        entity.ToTable("publications"); // Nombre explícito de la tabla
        entity.HasKey(p => p.Id).HasName("p_k_publications");
        entity.HasKey(p => p.Id);
        entity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        entity.Property(p => p.IdOwner).IsRequired();
        entity.Property(p => p.Status).IsRequired();
        entity.Property(p => p.CreatedDate)
              .HasColumnName("CreatedAt")
              .HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.Property(p => p.UpdatedDate)
              .HasColumnName("UpdatedAt")
              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.HasDiscriminator<string>("publication_type")
              .HasValue<Publication>("publication_base")
              .HasValue<ElectricPublication>("publication_electric")
              .HasValue<ManualPublication>("publication_manual");

        entity.OwnsOne(p => p.PublicationIdentifier, ai =>
        {
            ai.WithOwner().HasForeignKey("Id");
            ai.Property(pi => pi.Identifier).HasColumnName("PublicationIdentifier");
        });

        entity.Property(p => p.ImageUri).HasConversion(
            v => v.ToString(),
            v => new Uri(v));
    });

    // Configuración de ElectricPublication
    builder.Entity<ElectricPublication>(entity =>
    {
        entity.Property(pi => pi.BatteryCapacity).IsRequired().HasDefaultValue(0);
    });

    // Configuración de ManualPublication
    builder.Entity<ManualPublication>(entity =>
    {
        entity.Property(pi => pi.HaveBrakes).IsRequired();
    });

    // Aplicar convención de nombres de tablas en snake_case y pluralización
    builder.UseSnakeCaseWithPluralizedTableNamingConvention();
}

}




















