namespace TreeWebAPI.Infrastructure.Exceptions;

[Serializable]
public class SecureException : Exception
{
    public SecureException(string message) : base(message)
    {
        
    }
}