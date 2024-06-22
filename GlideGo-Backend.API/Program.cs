using System.Configuration;
using GlideGo_Backend.API.Design.Application.Internal.CommandService;
using GlideGo_Backend.API.Design.Application.Internal.QueryServices;
using GlideGo_Backend.API.Design.Domain.Repositories;
using GlideGo_Backend.API.Design.Domain.Services;
using GlideGo_Backend.API.Design.Infrastructure.Persistence.EFC.Repositories;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Execution_Monitor.Infrastructure.Persistence.EFC.Repositories;
using GlideGo_Backend.API.Shared.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.Ocsp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString == null) return;
    if (builder.Environment.IsDevelopment()) 
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction()) 
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",new OpenApiInfo
        {
            Title = "GlideGo-Backend.API",
            Version = "v1",
            Description = "GlideGo Backend API",
            TermsOfService = new Uri("https://glide-go.com/"),
            Contact = new OpenApiContact{ Name = "Glide Go", Email = "contact@glidego.com"},
            License = new OpenApiLicense{ Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0")},
        });
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Register the VehicleUsage services and repositories
// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicleUsageRepository, VehicleUsageRepository>();
builder.Services.AddScoped<VehicleUsageCommandService>();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();

// IAM Bounded Context Injection Configuration


var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Middleware for Request Authorization

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();