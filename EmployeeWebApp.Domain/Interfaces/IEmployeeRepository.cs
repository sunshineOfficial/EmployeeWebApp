using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Models;

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
    Task<int> AddEmployee(EmployeeModel employee);
    
    /// <summary>
    /// Удаляет сотрудника по id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    Task DeleteEmployee(int id);
    
    /// <summary>
    /// Получает всех сотрудников для указанной компании.
    /// </summary>
    /// <param name="companyId">Id компании.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанной компании.</returns>
    Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByCompanyId(int companyId);
    
    /// <summary>
    /// Получает всех сотрудников для указанного отдела.
    /// </summary>
    /// <param name="departmentId">Id отдела.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанного отдела.</returns>
    Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByDepartmentId(int departmentId);

    /// <summary>
    /// Изменяет сотрудника по его id.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    /// <param name="updatedEmployee">Измененный сотрудник.</param>
    Task UpdateEmployee(int id, EmployeeModel updatedEmployee);
}