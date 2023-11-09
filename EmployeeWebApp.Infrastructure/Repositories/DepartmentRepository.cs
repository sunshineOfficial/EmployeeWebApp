using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using EmployeeWebApp.Domain.Models;
using EmployeeWebApp.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeeWebApp.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Department"/>.
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    private readonly ConnectionStringsSettings _settings;

    public DepartmentRepository(IOptions<ConnectionStringsSettings> settings)
    {
        _settings = settings.Value;
    }
    
    /// <inheritdoc/>
    public async Task<int> AddDepartment(DepartmentModel department)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);
        
        var sql = @"INSERT INTO ""Departments"" (""Name"", ""Phone"")
                    VALUES (@Name, @Phone)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, department);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Department> GetDepartment(int id)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"SELECT * FROM ""Departments""
                    WHERE ""Id"" = @Id;";

        var department = await connection.QuerySingleAsync<Department>(sql, new { Id = id });

        return department;
    }
}