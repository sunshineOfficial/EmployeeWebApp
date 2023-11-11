namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения DepartmentNotFound.
/// </summary>
public class DepartmentNotFoundException : NotFoundException
{
    public DepartmentNotFoundException(int id) : base($"Отдела с id {id} не существует.")
    {
    }
}