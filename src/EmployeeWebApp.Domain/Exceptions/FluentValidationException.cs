namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения валидации.
/// </summary>
public class FluentValidationException : BadRequestException
{
    public FluentValidationException(string message) : base(message)
    {
    }
}