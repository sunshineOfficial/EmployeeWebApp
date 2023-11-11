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
    
    /// <summary>
    /// Изменяет отдел по id.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    /// <param name="updatedDepartment">Измененный отдел.</param>
    Task UpdateDepartmentAsync(int id, Department updatedDepartment);
    
    /// <summary>
    /// Удаляет отдел по id.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    Task DeleteDepartmentAsync(int id);
    
    /// <summary>
    /// Проверяет, существует ли отдел с указанным id.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    /// <returns><see langword="true"/>, если отдел существует, иначе - <see langword="false"/></returns>
    Task<bool> DepartmentExistsAsync(int id);
}