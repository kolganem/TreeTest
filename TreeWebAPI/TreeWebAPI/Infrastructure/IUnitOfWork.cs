using TreeWebAPI.Infrastructure;

namespace StoreProject.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    ITreeNodeRepository TreeNodes { get; }
    
    IErrorRecordRepository ErrorRecords { get; }

    Task<int> SaveAsync();
}