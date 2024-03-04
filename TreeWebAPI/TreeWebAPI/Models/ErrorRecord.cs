namespace TreeWebAPI.Models;

public class ErrorRecord
{
    public Guid Id { get; set; }

    public DateTime Time { get; set; }

    public string TypeInfo { get; set; }

    public string Data { get; set; }
}