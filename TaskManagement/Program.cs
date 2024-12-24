using Microsoft.EntityFrameworkCore;
using FluentValidation;
using TaskManagement.Persistances.Contexts;
using TaskManagement.Application.Features.CityFeatures;
using Microsoft.OpenApi.Models;
using TaskManagement.Application.Interfaces.Repositories;
using TaskManagement;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Persistances.Repositories.RepositoryClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register FluentValidation Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateCityCommandValidator>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); // Adjust if necessary

// Register repositories or services (example for CityRepository)
builder.Services.AddScoped<ICityRepository, CityRepository>();

// Add API Versioning (optional)
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// CORS setup (optional, if your front-end is hosted on a different domain)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(string.Format(@"{0}\TaskManagement.xml", System.AppDomain.CurrentDomain.BaseDirectory));
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Task Management API",
        Description = "API for managing tasks and cities.",
        Contact = new OpenApiContact
        {
            Name = "Your Team",
            Email = "support@example.com",
            Url = new Uri("https://yourwebsite.com")
        }
    });
});

var app = builder.Build();

// Apply database migrations on startup (optional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors();

// Enable Authentication and Authorization
app.UseAuthorization();

// Error handling middleware (optional, but recommended)
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
