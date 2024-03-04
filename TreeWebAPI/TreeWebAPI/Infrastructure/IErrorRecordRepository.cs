using Microsoft.EntityFrameworkCore;
using TreeWebAPI.Models;

namespace TreeWebAPI.Infrastructure;

public class IErrorRecordRepository : GenericRepository<ErrorRecord>
{
    protected IErrorRecordRepository(TreeDbContext context) : base(context) { }
    public async Task<ICollection<ErrorRecord>> GetAllByRangeAsync(DateTime from, DateTime to, int? skip, int? take)
    {
        return await DbContext.ErrorRecords
            .Where(e => e.Time >= from && e.Time <= to)
            .Skip(skip ?? 0)
            .Take(take ?? 0)
            .ToListAsync();
    }

    
}