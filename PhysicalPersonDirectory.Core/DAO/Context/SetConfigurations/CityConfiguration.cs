using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class CityConfiguration:IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    { 
//-----------------------------------Table Config----------------------------------------------------------------------------------
        builder.HasKey(c => c.Id);
//-----------------------------------Properties Config----------------------------------------------------------------------------------        
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        #region City Seed
        builder.HasData(
            new City("თბილისი") { Id = 1 },
            new City("ქუთაისი") { Id = 2 },
            new City("ბათუმი") { Id = 3 },
            new City("რუსთავი") { Id = 4 },
            new City("გორი") { Id = 5 },
            new City("ზუგდიდი") { Id = 6 },
            new City("ფოთი") { Id = 7 },
            new City("თელავი") { Id = 8 },
            new City("ოზურგეთი") { Id = 9 },
            new City("ამბროლაური") { Id = 10 },
            new City("ახალციხე") { Id = 11 },
            new City("ახალქალაქი") { Id = 12 },
            new City("მარნეული") { Id = 13 },
            new City("გარდაბანი") { Id = 14 },
            new City("ბოლნისი") { Id = 15 },
            new City("დუშეთი") { Id = 16 },
            new City("საგარეჯო") { Id = 17 },
            new City("ლაგოდეხი") { Id = 18 },
            new City("ბორჯომი") { Id = 19 },
            new City("ცხინვალი") { Id = 20 },
            new City("ცაგერი") { Id = 21 },
            new City("ლენტეხი") { Id = 22 },
            new City("მესტია") { Id = 23 },
            new City("წალენჯიხა") { Id = 24 },
            new City("ჩხოროწყუ") { Id = 25 },
            new City("ხობი") { Id = 26 },
            new City("სენაკი") { Id = 27 },
            new City("მარტვილი") { Id = 28 },
            new City("ვანი") { Id = 29 },
            new City("ტყიბული") { Id = 30 },
            new City("ბაღდათი") { Id = 31 },
            new City("ხარაგაული") { Id = 32 },
            new City("საჩხერე") { Id = 33 },
            new City("ხონი") { Id = 34 },
            new City("ნინოწმინდა") { Id = 35 }
        );
        #endregion
    }
}