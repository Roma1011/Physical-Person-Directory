using Microsoft.EntityFrameworkCore;
using PhysicalPersonDirectory.Core.Domain.Entities;
using PhysicalPersonDirectory.Core.Domain.Entities.PersonEntity;

namespace PhysicalPersonDirectory.Core.DAO.Context;

internal class PhysicalPersonDbContext:DbContext
{
    public PhysicalPersonDbContext(DbContextOptions<PhysicalPersonDbContext> options) : base(options) {}
    public PhysicalPersonDbContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    
    public DbSet<Person> Person { get; set; }
    public DbSet<RelatedPerson> RelatedPersons { get; set; }
    public DbSet<City> City { get; set; }
}