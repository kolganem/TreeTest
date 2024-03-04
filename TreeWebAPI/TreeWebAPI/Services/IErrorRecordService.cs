using TreeWebAPI.Models;

namespace TreeWebAPI.Services;

public interface IErrorRecordService
{
    Task<bool> Add(ErrorRecord errorRecord);
    
    Task<bool> Add(string type, string data);

    Task<ErrorRecord> GetSingle(Guid id);

    Task<ICollection<ErrorRecord>> GetRange(DateTime from, DateTime to, int? skip, int? take);
}