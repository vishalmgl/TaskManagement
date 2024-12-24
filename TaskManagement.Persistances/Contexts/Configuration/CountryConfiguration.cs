using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.Property(c => c.Code).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(c => c.Title).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");

            builder.HasKey(a => a.Code);
        }
    }
}
