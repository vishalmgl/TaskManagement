using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement;
using System.Text.Json.Serialization;
using TaskManagement.Interfaces;
using TaskManagement.Model;
using TaskManagement.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();//Make sure that the Seed service is registered in the dependency injection container (IServiceCollection) during application startup.
builder.Services.AddControllers().AddJsonOptions(x =>
                                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<ITaskAssignmentRepository,TaskAssignmentRepository>();
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//This configures the application's data context to use SQL Server as the database provider
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//data context is entity framework core
});
var apps = builder.Build();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


void SeedData(IHost apps)
{

    using (var scope = apps.Services.CreateScope())//This SeedData method initializes the database with initial data by creating a scope
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (apps.Environment.IsDevelopment())
{
    apps.UseSwagger();
    apps.UseSwaggerUI();
}

apps.UseHttpsRedirection();

apps.UseAuthorization();

apps.MapControllers();
SeedData(apps);
apps.Run();
