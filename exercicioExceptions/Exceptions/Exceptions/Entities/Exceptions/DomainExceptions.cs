namespace Exceptions.Entities.Exceptions;

public class DomainExceptions(string? message) : ApplicationException(message)
{
}