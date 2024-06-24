using GlideGo_Backend.API.Profiles.Application.Internal.CommandServices;
using GlideGo_Backend.API.Profiles.Application.Internal.QueryServices;
using GlideGo_Backend.API.Profiles.Domain.Repositories;
using GlideGo_Backend.API.Profiles.Domain.Services;
using GlideGo_Backend.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using GlideGo_Backend.API.Profiles.Interfaces.ACL;
using GlideGo_Backend.API.Profiles.Interfaces.ACL.Services;
using GlideGo_Backend.API.Shared.Domain.Repositories;
using GlideGo_Backend.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add Configuration for Routing
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

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
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title   = "Glidego.API",
            Version = "v1",
            Description = "GLIDEGO API",
            TermsOfService = new Uri("https://glidego.com/tos"),
            Contact = new OpenApiContact{ Name = "Glidego", Email = "contact@glidego.com" },
            License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")},
        });
    }); 

// configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();