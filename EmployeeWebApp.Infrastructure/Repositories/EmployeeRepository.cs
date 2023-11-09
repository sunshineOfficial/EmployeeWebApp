using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using EmployeeWebApp.Domain.Models;
using EmployeeWebApp.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeeWebApp.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Employee"/>.
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly ConnectionStringsSettings _settings;

    public EmployeeRepository(IOptions<ConnectionStringsSettings> settings)
    {
        _settings = settings.Value;
    }

    /// <inheritdoc/>
    public async Task<int> AddEmployee(EmployeeModel employee)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"INSERT INTO ""Employees"" (""Name"", ""Surname"", ""Phone"", ""CompanyId"", ""PassportId"", ""DepartmentId"")
                    VALUES (@Name, @Surname, @Phone, @CompanyId, @PassportId, @DepartmentId)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, employee);

        return id;
    }

    /// <inheritdoc/>
    public async Task DeleteEmployee(int id)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"DELETE FROM ""Employees"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByCompanyId(int companyId)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"SELECT ""Id"", ""Name"", ""Surname"", ""Phone"", ""CompanyId"", ""PassportId"", ""DepartmentId"" FROM ""Employees""
                    WHERE ""CompanyId"" = @CompanyId;";

        var employees = await connection.QueryAsync<EmployeeResponseModel>(sql, new { CompanyId = companyId });

        return employees;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByDepartmentId(int departmentId)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"SELECT ""Id"", ""Name"", ""Surname"", ""Phone"", ""CompanyId"", ""PassportId"", ""DepartmentId"" FROM ""Employees""
                    WHERE ""DepartmentId"" = @DepartmentId;";

        var employees = await connection.QueryAsync<EmployeeResponseModel>(sql, new { DepartmentId = departmentId });

        return employees;
    }

    /// <inheritdoc/>
    public async Task UpdateEmployee(int id, EmployeeModel updatedEmployee)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"UPDATE ""Employees""
                    SET
                        ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END,
                        ""Surname"" = CASE WHEN @Surname IS NULL THEN ""Surname"" ELSE @Surname END,
                        ""Phone"" = CASE WHEN @Phone IS NULL THEN ""Phone"" ELSE @Phone END,
                        ""CompanyId"" = CASE WHEN @CompanyId IS NULL THEN ""CompanyId"" ELSE @CompanyId END,
                        ""PassportId"" = CASE WHEN @PassportId IS NULL THEN ""PassportId"" ELSE @PassportId END,
                        ""DepartmentId"" = CASE WHEN @DepartmentId IS NULL THEN ""DepartmentId"" ELSE @DepartmentId END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, updatedEmployee);
    }
}