using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistances.Contexts.Configuration;

namespace TaskManagement.Persistances.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets for each entity
        public DbSet<AddClients> AddClients { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }

        // Configuring relationships via OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations for entities
            modelBuilder.ApplyConfiguration(new AddClientsConfiguration());
            modelBuilder.ApplyConfiguration(new ClientStatusConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new ContactDetailsConfiguration());
        }
        public Task RefreshAsync()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
            return Task.FromResult(0);
        }
    }
}
