using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

            builder.Property(s => s.Code).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(s => s.Title).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");

            builder.HasKey(a => a.Code);
        }
    }
}
