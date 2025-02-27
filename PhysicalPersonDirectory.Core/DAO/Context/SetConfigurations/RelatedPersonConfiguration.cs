using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class RelatedPersonConfiguration:IEntityTypeConfiguration<RelatedPerson>
{
    public void Configure(EntityTypeBuilder<RelatedPerson> builder)
    {
//-----------------------------------Table Config----------------------------------------------------------------------------------
        builder.HasKey(rl => rl.Id);
        
//-----------------------------------Relationship Config----------------------------------------------------------------------------------
        builder
            .HasOne(pr => pr.Person)
            .WithMany(p => p.RelatedPersons)
            .HasForeignKey("PersonId")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(pr => pr.Related)
            .WithMany() 
            .HasForeignKey("RelatedPersonId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}