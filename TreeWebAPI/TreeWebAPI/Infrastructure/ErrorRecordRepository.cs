namespace TreeWebAPI.Infrastructure;

public class ErrorRecordRepository : IErrorRecordRepository
{
    public ErrorRecordRepository(TreeDbContext context) : base(context)
    {
    }
}