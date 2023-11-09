using System.Reflection;
using DbUp;
using EmployeeWebApp.Domain.Interfaces;
using EmployeeWebApp.Infrastructure.Configuration;
using EmployeeWebApp.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeWebApp.Infrastructure.Extensions;

/// <summary>
/// Класс с методами расширения для добавления функциональности базы данных.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    /// Выполняет миграцию базы данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    /// <returns><see cref="IConfiguration"/>.</returns>
    public static IServiceCollection MigrateDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        upgrader.PerformUpgrade();

        return services;
    }

    /// <summary>
    /// Добавляет в контейнер зависимостей реализации для интерфейсов репозиториев.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        return services.Configure<ConnectionStringsSettings>(configuration.GetSection("ConnectionStrings"))
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<ICompanyRepository, CompanyRepository>()
            .AddScoped<IPassportRepository, PassportRepository>()
            .AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}