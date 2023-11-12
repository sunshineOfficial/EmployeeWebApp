namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения CompanyNotFound.
/// </summary>
public class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(int id) : base($"Компании с id {id} не существует.")
    {
    }
}