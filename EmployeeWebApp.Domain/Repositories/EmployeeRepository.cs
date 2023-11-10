using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EmployeeWebApp.Domain.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Employee"/>.
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _dbConnection;

    public EmployeeRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }

    /// <inheritdoc/>
    public async Task<int> AddEmployeeAsync(Employee employee)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"INSERT INTO ""Employees"" (""Name"", ""Surname"", ""Phone"", ""CompanyId"", ""PassportId"", ""DepartmentId"")
                    VALUES (@Name, @Surname, @Phone, @CompanyId, @PassportId, @DepartmentId)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, employee);

        return id;
    }

    /// <inheritdoc/>
    public async Task DeleteEmployeeAsync(int id)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Employees"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Employees""
                    WHERE ""CompanyId"" = @CompanyId;";

        var employees = await connection.QueryAsync<Employee>(sql, new { CompanyId = companyId });

        return employees;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Employees""
                    WHERE ""DepartmentId"" = @DepartmentId;";

        var employees = await connection.QueryAsync<Employee>(sql, new { DepartmentId = departmentId });

        return employees;
    }

    /// <inheritdoc/>
    public async Task UpdateEmployeeAsync(int id, Employee updatedEmployee)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Employees""
                    SET
                        ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END,
                        ""Surname"" = CASE WHEN @Surname IS NULL THEN ""Surname"" ELSE @Surname END,
                        ""Phone"" = CASE WHEN @Phone IS NULL THEN ""Phone"" ELSE @Phone END,
                        ""CompanyId"" = CASE WHEN @CompanyId IS NULL THEN ""CompanyId"" ELSE @CompanyId END,
                        ""PassportId"" = CASE WHEN @PassportId IS NULL THEN ""PassportId"" ELSE @PassportId END,
                        ""DepartmentId"" = CASE WHEN @DepartmentId IS NULL THEN ""DepartmentId"" ELSE @DepartmentId END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new
        {
            Id = id,
            updatedEmployee.Name,
            updatedEmployee.Surname,
            updatedEmployee.Phone,
            updatedEmployee.CompanyId,
            updatedEmployee.PassportId,
            updatedEmployee.DepartmentId
        });
    }
}