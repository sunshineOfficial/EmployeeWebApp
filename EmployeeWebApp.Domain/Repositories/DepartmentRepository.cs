using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EmployeeWebApp.Domain.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Department"/>.
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    private readonly string _dbConnection;

    public DepartmentRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }
    
    /// <inheritdoc/>
    public async Task<int> AddDepartmentAsync(Department department)
    {
        using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Departments"" (""Name"", ""Phone"")
                    VALUES (@Name, @Phone)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, department);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Department> GetDepartmentAsync(int id)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Departments""
                    WHERE ""Id"" = @Id;";

        var department = await connection.QuerySingleAsync<Department>(sql, new { Id = id });

        return department;
    }
}