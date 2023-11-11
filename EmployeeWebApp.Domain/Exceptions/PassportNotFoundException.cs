namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения PassportNotFoundException.
/// </summary>
public class PassportNotFoundException : NotFoundException
{
    public PassportNotFoundException(int id) : base($"Паспорта с id {id} не существует.")
    {
    }
}