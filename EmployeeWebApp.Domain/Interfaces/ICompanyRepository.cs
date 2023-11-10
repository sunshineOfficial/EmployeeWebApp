using EmployeeWebApp.Domain.Entities;

namespace EmployeeWebApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория для взаимодействия с сущностью <see cref="Company"/>.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Добавляет новую компанию.
    /// </summary>
    /// <param name="company">Новая компания.</param>
    /// <returns>Id добавленной компании.</returns>
    Task<int> AddCompanyAsync(Company company);

    /// <summary>
    /// Получает компанию.
    /// </summary>
    /// <param name="id">Id компании.</param>
    /// <returns>Компания с указанным id.</returns>
    Task<Company> GetCompanyAsync(int id);
    
    /// <summary>
    /// Изменяет компанию по id.
    /// </summary>
    /// <param name="id">Id компании.</param>
    /// <param name="updatedCompany">Измененная компания.</param>
    Task UpdateCompanyAsync(int id, Company updatedCompany);
    
    /// <summary>
    /// Удаляет компанию по id.
    /// </summary>
    /// <param name="id">Id компании.</param>
    Task DeleteCompanyAsync(int id);
}