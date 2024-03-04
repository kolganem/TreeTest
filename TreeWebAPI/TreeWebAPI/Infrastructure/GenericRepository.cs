using StoreProject.Infrastructure;

namespace TreeWebAPI.Infrastructure;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private TreeDbContext _dbContext;

    protected TreeDbContext DbContext => _dbContext;

    protected GenericRepository(TreeDbContext context)
    {
        _dbContext = context;
    }

    public async Task<T> GetById(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}