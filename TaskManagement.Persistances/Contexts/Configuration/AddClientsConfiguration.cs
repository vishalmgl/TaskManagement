using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class AddClientsConfiguration : IEntityTypeConfiguration<AddClients>
    {
        public void Configure(EntityTypeBuilder<AddClients> builder)
        {
            builder.ToTable("AddClients");

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.ClientName).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");
            builder.Property(c => c.GSTNumber).HasMaxLength(15).HasColumnType("VARCHAR(15)");
            builder.Property(c => c.ClientStatusCode).IsRequired().HasMaxLength(5).HasColumnType("VARCHAR(5)");
            builder.Property(c => c.CountryCode).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(c => c.StateCode).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(c => c.CityCode).IsRequired().HasMaxLength(3).HasColumnType("VARCHAR(3)");
            builder.Property(c => c.Address).HasMaxLength(255).HasColumnType("VARCHAR(255)");

            builder.HasKey(a => a.Id);

            builder.HasOne(c => c.ClientStatus)
                .WithMany(cs => cs.AddClients)
                .HasForeignKey(c => c.ClientStatusCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Country)
                .WithMany(co => co.AddClients)
                .HasForeignKey(c => c.CountryCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.State)
                .WithMany(s => s.AddClients)
                .HasForeignKey(c => c.StateCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.City)
                .WithMany(ci => ci.AddClients)
                .HasForeignKey(c => c.CityCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
