namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Абстрактный класс исключения NotFound.
/// </summary>
public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}