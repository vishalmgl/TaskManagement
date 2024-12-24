using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistances.Contexts.Configuration
{
    public class ContactDetailsConfiguration : IEntityTypeConfiguration<ContactDetails>
    {
        public void Configure(EntityTypeBuilder<ContactDetails> builder)
        {
            builder.ToTable("ContactDetails");

            builder.Property(cd => cd.Id).IsRequired();
            builder.Property(cd => cd.ContactPerson).HasMaxLength(120).HasColumnType("VARCHAR(120)");
            builder.Property(cd => cd.ContactNumber).HasMaxLength(15).HasColumnType("VARCHAR(15)");
            builder.Property(cd => cd.MailID).HasMaxLength(255).HasColumnType("VARCHAR(255)");

            builder.HasKey(a => a.Id);
        }
    }
}
