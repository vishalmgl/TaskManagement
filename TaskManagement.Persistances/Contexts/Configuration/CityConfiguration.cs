using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.Property(c => c.Code).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(c => c.Title).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");

            builder.HasKey(a => a.Code);
        }
    }
}
