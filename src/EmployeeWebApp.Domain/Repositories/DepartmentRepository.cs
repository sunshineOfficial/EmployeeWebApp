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
        await using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Departments"" (""Name"", ""Phone"")
                    VALUES (@Name, @Phone)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, department);
        await connection.CloseAsync();

        return id;
    }

    /// <inheritdoc/>
    public async Task<Department> GetDepartmentAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Departments""
                    WHERE ""Id"" = @Id;";

        var department = await connection.QuerySingleOrDefaultAsync<Department>(sql, new { Id = id });
        await connection.CloseAsync();

        return department;
    }
    
    /// <inheritdoc/>
    public async Task UpdateDepartmentAsync(int id, Department updatedDepartment)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Departments""
                    SET
                        ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END,
                        ""Phone"" = CASE WHEN @Phone IS NULL THEN ""Phone"" ELSE @Phone END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, updatedDepartment.Name, updatedDepartment.Phone });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteDepartmentAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Departments"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> DepartmentExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Departments"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}