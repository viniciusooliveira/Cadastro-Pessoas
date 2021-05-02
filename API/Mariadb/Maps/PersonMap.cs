using Mariadb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mariadb.Maps
{
    public class PersonMap : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("Person");

            builder.HasIndex(x => x.Name);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(x => x.Document)
                .HasMaxLength(11)
                .IsRequired();
            
            builder.Property(x => x.BirthDate)
                .HasColumnType("Date")
                .IsRequired();
            
            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(13);
        }
    }
}