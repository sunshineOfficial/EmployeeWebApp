namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Паспорт.
/// </summary>
public class Passport
{
    /// <summary>
    /// Id паспорта.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Тип паспорта.
    /// </summary>
    public string Type { get; private set; }

    /// <summary>
    /// Номер паспорта.
    /// </summary>
    public string Number { get; private set; }

    /// <summary>
    /// Создает сущность <see cref="Passport"/>.
    /// </summary>
    /// <param name="type">Тип паспорта.</param>
    /// <param name="number">Номер паспорта.</param>
    public Passport(string type, string number)
    {
        SetType(type);
        SetNumber(number);
    }

    protected Passport()
    {
    }

    /// <summary>
    /// Устанавливает id паспорта.
    /// </summary>
    /// <param name="id">Id паспорта.</param>
    public void SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id паспорта не может быть меньше 1", nameof(id));
        }

        Id = id;
    }

    /// <summary>
    /// Устанавливает тип паспорта.
    /// </summary>
    /// <param name="type">Тип паспорта.</param>
    public void SetType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Тип паспорта не может быть пустым, равным null или состоять из пробелов.",
                nameof(type));
        }

        Type = type;
    }
    
    /// <summary>
    /// Устанавливает номер паспорта.
    /// </summary>
    /// <param name="number">Номер паспорта.</param>
    public void SetNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException("Номер паспорта не может быть пустым, равным null или состоять из пробелов.",
                nameof(number));
        }
        
        Number = number;
    }
}