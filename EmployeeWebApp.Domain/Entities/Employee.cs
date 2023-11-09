namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Сотрудник.
/// </summary>
public class Employee
{
    /// <summary>
    /// Id сотрудника.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Фамилия сотрудника.
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// Номер телефона сотрудника.
    /// </summary>
    public string Phone { get; private set; }
    
    /// <summary>
    /// Компания сотрудника.
    /// </summary>
    public Company Company { get; private set; }

    /// <summary>
    /// Паспорт сотрудника.
    /// </summary>
    public Passport Passport { get; private set; }

    /// <summary>
    /// Отдел сотрудника.
    /// </summary>
    public Department Department { get; private set; }

    /// <summary>
    /// Создает сущность <see cref="Employee"/>.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="surname">Фамилия сотрудника.</param>
    /// <param name="phone">Номер телефона сотрудника.</param>
    /// <param name="company">Компания сотрудника.</param>
    /// <param name="passport">Паспорт сотрудника.</param>
    /// <param name="department">Отдел сотрудника.</param>
    public Employee(string name, string surname, string phone, Company company, Passport passport, Department department)
    {
        SetName(name);
        SetSurname(surname);
        SetPhone(phone);
        Company = company;
        Passport = passport;
        Department = department;
    }

    protected Employee()
    {
    }
    
    /// <summary>
    /// Устанавливает id сотрудника.
    /// </summary>
    /// <param name="id">Id сотрудника.</param>
    public void SetId(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Id сотрудника не может быть меньше 1", nameof(id));
        }

        Id = id;
    }
    
    /// <summary>
    /// Устанавливает имя сотрудника.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя сотрудника не может быть пустым, равным null или состоять из пробелов.",
                nameof(name));
        }

        Name = name;
    }
    
    /// <summary>
    /// Устанавливает фамилию сотрудника.
    /// </summary>
    /// <param name="surname">Фамилия сотрудника.</param>
    public void SetSurname(string surname)
    {
        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException("Фамилия сотрудника не может быть пустым, равным null или состоять из пробелов.",
                nameof(surname));
        }

        Surname = surname;
    }
    
    /// <summary>
    /// Устанавливает номер телефона сотрудника.
    /// </summary>
    /// <param name="phone">Номер телефона сотрудника.</param>
    public void SetPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Номер телефона сотрудника не может быть пустым, равным null или состоять из пробелов.",
                nameof(phone));
        }

        Phone = phone;
    }
}