using Microsoft.EntityFrameworkCore;

namespace PhysicalPersonDirectory.Core.DAO.Context;

public class PhysicalPersonDbContext:DbContext
{
    public PhysicalPersonDbContext(DbContextOptions<PhysicalPersonDbContext> options) : base(options) {}
}