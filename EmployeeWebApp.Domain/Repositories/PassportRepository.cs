using Dapper;
using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EmployeeWebApp.Domain.Repositories;

/// <summary>
/// Репозиторий для взаимодействия с сущностью <see cref="Passport"/>.
/// </summary>
public class PassportRepository : IPassportRepository
{
    private readonly string _dbConnection;

    public PassportRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }
    
    /// <inheritdoc/>
    public async Task<int> AddPassportAsync(Passport passport)
    {
        using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Passports"" (""Type"", ""Number"")
                    VALUES (@Type, @Number)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, passport);

        return id;
    }

    /// <inheritdoc/>
    public async Task<Passport> GetPassportAsync(int id)
    {
        using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Passports""
                    WHERE ""Id"" = @Id;";

        var passport = await connection.QuerySingleAsync<Passport>(sql, new { Id = id });

        return passport;
    }
}