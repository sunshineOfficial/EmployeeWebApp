using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using EmployeeWebApp.Domain.Models;
using EmployeeWebApp.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeeWebApp.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Company"/>.
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    private readonly ConnectionStringsSettings _settings;

    public CompanyRepository(IOptions<ConnectionStringsSettings> settings)
    {
        _settings = settings.Value;
    }
    
    /// <inheritdoc/>
    public async Task<int> AddCompany(CompanyModel company)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);
        
        var sql = @"INSERT INTO ""Companies"" (""Name"")
                    VALUES (@Name)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, company);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Company> GetCompany(int id)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"SELECT * FROM ""Companies""
                    WHERE ""Id"" = @Id;";

        var company = await connection.QuerySingleAsync<Company>(sql, new { Id = id });

        return company;
    }
}