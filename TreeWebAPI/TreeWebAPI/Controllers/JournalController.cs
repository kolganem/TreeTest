using Microsoft.AspNetCore.Mvc;
using TreeWebAPI.Infrastructure.Helper;
using TreeWebAPI.Models;
using TreeWebAPI.Services;

namespace TreeWebAPI.Controllers;

[Route("api/journal/")]
[ApiController]
public class JournalController : ControllerBase
{
    private readonly IErrorRecordService _errorRecordService;

    public JournalController(IErrorRecordService errorRecordService)
    {
        _errorRecordService = errorRecordService;
    }
    
    [HttpGet]
    [Route("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        ErrorRecord node = await _errorRecordService.GetSingle(id);
            
        return Ok(JsonHelper.ToJsonIgnoreLoopHandling(node));
    }
    
    [HttpGet]
    [Route("getRange")]
    public async Task<IActionResult> Get(DateTime from, DateTime to, int? skip, int? take)
    {
        ICollection<ErrorRecord> node = await _errorRecordService.GetRange(from, to, skip, take);
            
        return Ok(JsonHelper.ToJsonIgnoreLoopHandling(node));
    }
}