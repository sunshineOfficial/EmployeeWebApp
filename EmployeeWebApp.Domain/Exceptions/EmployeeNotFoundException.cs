namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения EmployeeNotFound.
/// </summary>
public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int id) : base($"Сотрудника с id {id} не существует.")
    {
    }
}