namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Компания.
/// </summary>
public class Company
{
    /// <summary>
    /// Id компании.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Название компании.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Создает сущность <see cref="Company"/>.
    /// </summary>
    /// <param name="name"></param>
    public Company(string name)
    {
        SetName(name);
    }

    protected Company()
    {
    }

    /// <summary>
    /// Устанавливает id компании.
    /// </summary>
    /// <param name="id">Id компании.</param>
    public void SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id компании не может быть меньше 1", nameof(id));
        }

        Id = id;
    }
    
    /// <summary>
    /// Устанавливает название компании.
    /// </summary>
    /// <param name="name">Название компании.</param>
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название компании не может быть пустым, равным null или состоять из пробелов.",
                nameof(name));
        }

        Name = name;
    }
}