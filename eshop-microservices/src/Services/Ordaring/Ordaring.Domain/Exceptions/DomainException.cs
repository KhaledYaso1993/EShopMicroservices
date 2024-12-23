namespace Ordaring.Domain.Exceptions;

public class DomainException: Exception
{
    public DomainException(string Message)
        : base($"Domain Exception\"{Message}\"Throw From Domain Layer."  )
    {
            
    }
}
