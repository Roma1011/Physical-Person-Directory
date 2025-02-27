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
    }
}