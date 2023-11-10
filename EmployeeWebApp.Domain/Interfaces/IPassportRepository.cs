using EmployeeWebApp.Domain.Entities;

namespace EmployeeWebApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория для взаимодействия с сущностью <see cref="Passport"/>.
/// </summary>
public interface IPassportRepository
{
    /// <summary>
    /// Добавляет новый паспорт.
    /// </summary>
    /// <param name="passport">Новый паспорт.</param>
    /// <returns>Id добавленного паспорта.</returns>
    Task<int> AddPassportAsync(Passport passport);

    /// <summary>
    /// Получает паспорт.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    /// <returns>Паспорт с указанным id.</returns>
    Task<Passport> GetPassportAsync(int id);
    
    /// <summary>
    /// Изменяет паспорт по id.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    /// <param name="updatedPassport">Измененный паспорт.</param>
    Task UpdatePassportAsync(int id, Passport updatedPassport);
    
    /// <summary>
    /// Удаляет паспорт по id.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    Task DeletePassportAsync(int id);
}