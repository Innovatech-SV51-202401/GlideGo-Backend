using GlideGo_Backend.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using GlideGo_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
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

var app = builder.Build();

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