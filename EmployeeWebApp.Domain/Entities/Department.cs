namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Отдел.
/// </summary>
public class Department
{
    /// <summary>
    /// Id отдела.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Название отдела.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Номер телефона отдела.
    /// </summary>
    public string Phone { get; private set; }

    /// <summary>
    /// Создает сущность <see cref="Department"/>.
    /// </summary>
    /// <param name="name">Название отдела.</param>
    /// <param name="phone">Номер телефона отдела.</param>
    public Department(string name, string phone)
    {
        SetName(name);
        SetPhone(phone);
    }

    protected Department()
    {
    }
    
    /// <summary>
    /// Устанавливает id отдела.
    /// </summary>
    /// <param name="id">Id отдела.</param>
    public void SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id отдела не может быть меньше 1", nameof(id));
        }

        Id = id;
    }
    
    /// <summary>
    /// Устанавливает название отдела.
    /// </summary>
    /// <param name="name">Название отдела.</param>
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название отдела не может быть пустым, равным null или состоять из пробелов.",
                nameof(name));
        }

        Name = name;
    }
    
    /// <summary>
    /// Устанавливает номер телефона отдела.
    /// </summary>
    /// <param name="phone">Номер телефона отдела.</param>
    public void SetPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Номер телефона отдела не может быть пустым, равным null или состоять из пробелов.",
                nameof(phone));
        }

        Phone = phone;
    }
}