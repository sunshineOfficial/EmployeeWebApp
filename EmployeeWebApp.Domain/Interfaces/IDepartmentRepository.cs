using EmployeeWebApp.Domain.Entities;

namespace EmployeeWebApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория для взаимодействия с сущностью <see cref="Department"/>.
/// </summary>
public interface IDepartmentRepository
{
    /// <summary>
    /// Добавляет новый отдел.
    /// </summary>
    /// <param name="department">Новый отдел.</param>
    /// <returns>Id добавленного отдела.</returns>
    Task<int> AddDepartmentAsync(Department department);

    /// <summary>
    /// Получает отдел.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    /// <returns>Отдел с указанным id.</returns>
    Task<Department> GetDepartmentAsync(int id);
}