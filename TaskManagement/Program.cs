using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//data context is entity framework core
});//This configures the application's data context to use SQL Server as the database provider
var apps = builder.Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

void SeedData(IHost app)
{

    using (var scope = app.Services.CreateScope())//This SeedData method initializes the database with initial data by creating a scope
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
