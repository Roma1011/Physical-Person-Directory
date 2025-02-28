using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class RelatedPersonConfiguration:IEntityTypeConfiguration<RelatedPerson>
{
    public void Configure(EntityTypeBuilder<RelatedPerson> builder)
    {
//-----------------------------------Table Config----------------------------------------------------------------------------------
        builder.HasKey(rl => rl.Id);
//-----------------------------------Properties Config----------------------------------------------------------------------------------   

        builder.Property(rl => rl.RelationType)
            .HasConversion(rl=>rl.ToString(),
                rl=>(RelationType)Enum.Parse(typeof(RelationType),rl))
            .IsRequired()
            .HasMaxLength(50);
        
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