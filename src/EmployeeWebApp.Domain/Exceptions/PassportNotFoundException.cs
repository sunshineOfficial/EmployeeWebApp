namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения PassportNotFound.
/// </summary>
public class PassportNotFoundException : NotFoundException
{
    public PassportNotFoundException(int id) : base($"Паспорта с id {id} не существует.")
    {
    }
}