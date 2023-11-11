namespace EmployeeWebApp.Domain.Exceptions;

/// <summary>
/// Класс исключения EmployeeCannotBeCreatedException.
/// </summary>
public class EmployeeCannotBeCreatedException : BadRequestException
{
    public EmployeeCannotBeCreatedException(int companyId, int passportId, int departmentId) : base(
        $"Невозможно создать сотрудника с companyId {companyId}, passportId {passportId} и departmentId {departmentId}")
    {
    }
}