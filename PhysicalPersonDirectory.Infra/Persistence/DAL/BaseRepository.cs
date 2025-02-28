using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysicalPersonDirectory.Infra.Abstraction.Common;
using PhysicalPersonDirectory.Infra.Abstraction.Specification;

[assembly:InternalsVisibleTo("PhysicalPersonDirectory.Core")]
namespace PhysicalPersonDirectory.Infra.Persistence.DAL;
internal abstract class BaseRepository<T,TDbContext> 
    where T: Entity
    where TDbContext:DbContext
{
    protected readonly TDbContext DbContext;
    protected BaseRepository(TDbContext dbContext)
        => DbContext = dbContext;
    
    public async Task<T?> GetByIdAsync(int id)
        => await DbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id);
    
    public async Task<List<T>> GetAllAsync()
        => await DbContext.Set<T>().ToListAsync();
    
    public async Task<int> IsExistWithCountAsync(BaseSpecification<T> baseSpecification) 
        => await DbContext.Set<T>().CountAsync(baseSpecification.Predicate);
    
    public async Task<EntityEntry> AddAsync(T entity)
        => await DbContext.AddAsync(entity);
    
    public Task<EntityEntry> UpdateAsync(T type) 
        => Task.FromResult<EntityEntry>(DbContext.Set<T>().Update(type));
    
    public Task<EntityEntry> DeleteAsync(T type) 
        => Task.FromResult<EntityEntry>(DbContext.Set<T>().Remove(type));
}