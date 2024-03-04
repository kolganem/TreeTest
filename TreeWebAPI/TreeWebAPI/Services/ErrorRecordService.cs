using System.Collections;
using StoreProject.Infrastructure;
using TreeWebAPI.Models;

namespace TreeWebAPI.Services;

public class ErrorRecordService : IErrorRecordService
{
    private readonly IUnitOfWork _unitOfWork;

    public ErrorRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Add(ErrorRecord errorRecord)
    {
        await _unitOfWork.ErrorRecords.Add(errorRecord);

        return await _unitOfWork.SaveAsync() > 0;
    }

    public async Task<bool> Add(string type, string data)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(data))
        {
            ErrorRecord errorRecord = new() { Id = new Guid(), TypeInfo = type, Time = DateTime.UtcNow, Data = data };
            await _unitOfWork.ErrorRecords.Add(errorRecord);
            result = await _unitOfWork.SaveAsync() > 0;
        }

        return result;
    }

    public async Task<ErrorRecord> GetSingle(Guid id)
    {
        return await _unitOfWork.ErrorRecords.GetById(id);
    }

    public async Task<ICollection<ErrorRecord>> GetRange(DateTime from, DateTime to, int? skip, int? take)
    {
        return await _unitOfWork.ErrorRecords.GetAllByRangeAsync(from, to, skip, take);
    }
}