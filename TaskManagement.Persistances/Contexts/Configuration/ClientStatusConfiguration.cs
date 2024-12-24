using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class ClientStatusConfiguration : IEntityTypeConfiguration<ClientStatus>
    {
        public void Configure(EntityTypeBuilder<ClientStatus> builder)
        {
            builder.ToTable("ClientStatuses");

            builder.Property(cs => cs.Code).IsRequired().HasMaxLength(5).HasColumnType("VARCHAR(5)");
            builder.Property(cs => cs.Title).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");

            builder.HasKey(a => a.Code);
        }
    }
}
