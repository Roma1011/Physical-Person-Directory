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
    private readonly TDbContext _dbContext;
    protected BaseRepository(TDbContext dbContext)
        => _dbContext = dbContext;
    
    public async Task<T?> GetByIdAsync(int id)
        => await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(x=>x.Id==id);
    
    public async Task<List<T>> GetAllAsync()
        => await _dbContext.Set<T>().ToListAsync();
    
    public async Task<bool> IsExistByAnyAsync(BaseSpecification<T> baseSpecification) 
        => await _dbContext.Set<T>().AnyAsync(baseSpecification.Predicate);
    
    public async Task<EntityEntry> AddAsync(T entity)
        => await _dbContext.AddAsync(entity);
    
    public Task<EntityEntry> UpdateAsync(T type) 
        => Task.FromResult<EntityEntry>(_dbContext.Set<T>().Update(type));
    
    public Task<EntityEntry> DeleteAsync(T type) 
        => Task.FromResult<EntityEntry>(_dbContext.Set<T>().Remove(type));
}