using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using EmployeeWebApp.Domain.Models;
using EmployeeWebApp.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeeWebApp.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Passport"/>.
/// </summary>
public class PassportRepository : IPassportRepository
{
    private readonly ConnectionStringsSettings _settings;

    public PassportRepository(IOptions<ConnectionStringsSettings> settings)
    {
        _settings = settings.Value;
    }
    
    /// <inheritdoc/>
    public async Task<int> AddPassport(PassportModel passport)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);
        
        var sql = @"INSERT INTO ""Passports"" (""Type"", ""Number"")
                    VALUES (@Type, @Number)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, passport);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Passport> GetPassport(int id)
    {
        using var connection = new NpgsqlConnection(_settings.DatabaseConnection);

        var sql = @"SELECT * FROM ""Passports""
                    WHERE ""Id"" = @Id;";

        var passport = await connection.QuerySingleAsync<Passport>(sql, new { Id = id });

        return passport;
    }
}