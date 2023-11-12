using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EmployeeWebApp.Domain.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Company"/>.
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    private readonly string _dbConnection;

    public CompanyRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }

    /// <inheritdoc/>
    public async Task<int> AddCompanyAsync(Company company)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Companies"" (""Name"")
                    VALUES (@Name)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, company);
        await connection.CloseAsync();

        return id;
    }

    /// <inheritdoc/>
    public async Task<Company> GetCompanyAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Companies""
                    WHERE ""Id"" = @Id;";

        var company = await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
        await connection.CloseAsync();

        return company;
    }

    /// <inheritdoc/>
    public async Task UpdateCompanyAsync(int id, Company updatedCompany)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Companies""
                    SET ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, updatedCompany.Name });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteCompanyAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Companies"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> CompanyExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Companies"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}