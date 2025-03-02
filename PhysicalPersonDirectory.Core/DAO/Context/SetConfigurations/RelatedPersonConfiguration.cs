using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Context.SetConfigurations;

internal class RelatedPersonConfiguration:IEntityTypeConfiguration<RelatedPerson>
{
    public void Configure(EntityTypeBuilder<RelatedPerson> builder)
    {
//-----------------------------------Table Config-----------------------------------------------------------------------------------------
        builder.HasKey(rp => new { rp.PersonId, rp.RelatedPersonId });
//-----------------------------------Properties Config------------------------------------------------------------------------------------ 

        builder.Property(rl => rl.RelationType)
            .HasConversion(rl=>rl.ToString(),
                rl=>(RelationType)Enum.Parse(typeof(RelationType),rl))
            .IsRequired()
            .HasMaxLength(50);
        
//-----------------------------------Relationship Config----------------------------------------------------------------------------------
        builder
            .HasOne(pr => pr.Person)
            .WithMany(p => p.RelatedPersons)
            .HasForeignKey(pr => pr.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship where this Person is the target
        builder
            .HasOne(pr => pr.Related)
            .WithMany(p => p.RelatedToPersons)
            .HasForeignKey(pr => pr.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        #region Relations Seed
        builder.HasData(
            new RelatedPerson(1, 2, RelationType.Colleague) { Id = 1 },
            new RelatedPerson(3, 4, RelationType.Familiar) { Id = 2 },
            new RelatedPerson(5, 6, RelationType.Other) { Id = 3 },
            new RelatedPerson(7, 8, RelationType.Other) { Id = 4 },
            new RelatedPerson(9, 10, RelationType.Other) { Id = 5 }
        );
        #endregion


    }
}