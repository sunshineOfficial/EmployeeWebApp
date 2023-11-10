using EmployeeWebApp.Domain.Entities;

namespace EmployeeWebApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория для взаимодействия с сущностью <see cref="Employee"/>.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Добавляет нового сотрудника.
    /// </summary>
    /// <param name="employee">Новый сотрудник.</param>
    /// <returns>Id добавленного сотрудника.</returns>
    Task<int> AddEmployeeAsync(Employee employee);
    
    /// <summary>
    /// Удаляет сотрудника по id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    Task DeleteEmployeeAsync(int id);
    
    /// <summary>
    /// Получает всех сотрудников для указанной компании.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанной компании.</returns>
    Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId);
    
    /// <summary>
    /// Получает всех сотрудников для указанного отдела.
    /// </summary>
    /// <param name="departmentId">Id отдела.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанного отдела.</returns>
    Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);

    /// <summary>
    /// Изменяет сотрудника по его id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <param name="updatedEmployee">Измененный сотрудник.</param>
    Task UpdateEmployeeAsync(int id, Employee updatedEmployee);
}