using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class PersonConfiguration:IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
//-----------------------------------Table Config----------------------------------------------------------------------------------
        builder
            .HasKey(p => p.Id)
            .IsClustered();

        builder.HasIndex(p => p.Pid)
            .IsUnique();
//-----------------------------------Properties Config----------------------------------------------------------------------------------        
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
            .HasConversion(birth=>birth.Value,
                birth=> new DateOfBirth(birth))
            .HasColumnType("date")
            .IsRequired();

        builder.Property(p => p.TypeOfPhone)
            .HasConversion(phone => phone != null ? phone.ToString() : null,
                phone => phone != null ? (TypeOfPhone)Enum.Parse(typeof(TypeOfPhone), phone) : default)
            .IsRequired(false);
        
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(p => p.ImageSource)
            .IsRequired(false);

        builder.Property(p => p.Gender)
            .HasConversion(gender => gender.ToString(),
                gender => (Gender)Enum.Parse(typeof(Gender), gender))
            .HasMaxLength(10)
            .IsRequired();
//-----------------------------------Relationship Config----------------------------------------------------------------------------------
        builder.HasOne(p => p.City)
            .WithOne(p=>p.Person)
            .HasForeignKey<Person>(p=>p.CityId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
        #region Person Seed
        builder.HasData(
            new Person("01001000001", "გიორგი", "აბაშიძე", TypeOfPhone.Mobile, "599123456", Gender.Male, new DateOfBirth(new DateOnly(1985, 11, 25)), 1) { Id = 1 },
            new Person("01001000002", "მარიამ", "ბერიძე", TypeOfPhone.Mobile, "577654321", Gender.Female, new DateOfBirth(new DateOnly(1995, 5, 3)), 2) { Id = 2 },
            new Person("01001000003", "ნიკოლოზ", "გიგაური", TypeOfPhone.HousePhone, "2123456", Gender.Male, new DateOfBirth(new DateOnly(2005, 8, 11)), 3) { Id = 3 },
            new Person("01001000004", "ანა", "დავითაშვილი", TypeOfPhone.OfficePhone, "322456789", Gender.Female, new DateOfBirth(new DateOnly(1999, 3, 14)), 4) { Id = 4 },
            new Person("01001000005", "დათო", "ელიზბარაშვილი", TypeOfPhone.Mobile, "555987654", Gender.Male, new DateOfBirth(new DateOnly(1985, 8, 25)), 5) { Id = 5 },
            new Person("01001000006", "თეკლა", "ვანიშვილი", TypeOfPhone.HousePhone, "2323232", Gender.Female, new DateOfBirth(new DateOnly(1998, 2, 24)), 6) { Id = 6 },
            new Person("01001000007", "ლუკა", "ზარანდია", TypeOfPhone.OfficePhone, "344556677", Gender.Male, new DateOfBirth(new DateOnly(1985, 8, 25)), 7) { Id = 7 },
            new Person("01001000008", "ელენე", "თორდია", TypeOfPhone.Mobile, "591112233", Gender.Female, new DateOfBirth(new DateOnly(1985, 8, 25)), 8) { Id = 8 },
            new Person("01001000009", "გიორგი", "კახიძე", TypeOfPhone.HousePhone, "2667788", Gender.Male, new DateOfBirth(new DateOnly(1985, 8, 25)), 9) { Id = 9 },
            new Person("01001000010", "ნინო", "ლომიძე", TypeOfPhone.OfficePhone, "355667788", Gender.Female, new DateOfBirth(new DateOnly(1985, 8, 25)), 10) { Id = 10 }
        );
        #endregion
    }
}