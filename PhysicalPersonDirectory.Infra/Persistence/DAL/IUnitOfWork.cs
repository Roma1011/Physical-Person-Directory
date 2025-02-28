namespace PhysicalPersonDirectory.Infra.Persistence.DAL;

public interface IUnitOfWork
{
    public Task<bool> SaveChangesAsync();
}