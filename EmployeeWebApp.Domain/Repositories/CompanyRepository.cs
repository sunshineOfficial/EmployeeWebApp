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
        using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Companies"" (""Name"")
                    VALUES (@Name)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, company);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Company> GetCompanyAsync(int id)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Companies""
                    WHERE ""Id"" = @Id;";

        var company = await connection.QuerySingleAsync<Company>(sql, new { Id = id });

        return company;
    }

    /// <inheritdoc/>
    public async Task UpdateCompanyAsync(int id, Company updatedCompany)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Companies""
                    SET ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, updatedCompany.Name });
    }

    /// <inheritdoc/>
    public async Task DeleteCompanyAsync(int id)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Companies"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
    }
}