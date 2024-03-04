using TreeWebAPI;
using TreeWebAPI.Infrastructure;

namespace StoreProject.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly TreeDbContext _dbContext;
    public ITreeNodeRepository TreeNodes { get; }
    public IErrorRecordRepository ErrorRecords { get; }

    public UnitOfWork(TreeDbContext dbContext, ITreeNodeRepository treeNodeRepository, 
        IErrorRecordRepository errorRecordRepository)
    {
        _dbContext = dbContext;
        TreeNodes = treeNodeRepository;
        ErrorRecords = errorRecordRepository;
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }

}