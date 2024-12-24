using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Persistance.Contexts.Configuration
{
    public class AddClientsConfiguration : IEntityTypeConfiguration<AddClients>
    {
      public void Configure(EntityTypeBuilder<AddClients> builder)
        {

        }
    }
}
