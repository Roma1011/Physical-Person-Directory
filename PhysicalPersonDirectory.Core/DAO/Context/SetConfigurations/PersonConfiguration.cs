using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class PersonConfiguration:IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasKey(p => p.Id)
            .IsClustered();

        builder.HasIndex(p => p.Pid)
            .IsUnique();
        
        builder.Property(p=>p.Name)
            .IsUnicode()
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p=>p.Surname)
            .IsUnicode()
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p=>p.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.DateOfPBirth)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(p => p.TypeOfPhone)
            .HasConversion(phone => phone != null ? phone.ToString() : null,
                phone => phone != null ? (TypeOfPhone)Enum.Parse(typeof(TypeOfPhone), phone) : default)
            .IsRequired(false);
        
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(p => p.ImagePath)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.HasOne(p => p.City)
            .WithOne(p=>p.Person)
            .HasForeignKey<Person>(p=>p.CityId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}