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
        await using var connection = new NpgsqlConnection(_dbConnection);
        
        var sql = @"INSERT INTO ""Passports"" (""Type"", ""Number"")
                    VALUES (@Type, @Number)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, passport);
        await connection.CloseAsync();

        return id;
    }

    /// <inheritdoc/>
    public async Task<Passport> GetPassportAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Passports""
                    WHERE ""Id"" = @Id;";

        var passport = await connection.QuerySingleOrDefaultAsync<Passport>(sql, new { Id = id });
        await connection.CloseAsync();

        return passport;
    }
    
    /// <inheritdoc/>
    public async Task UpdatePassportAsync(int id, Passport updatedPassport)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Passports""
                    SET
                        ""Type"" = CASE WHEN @Type IS NULL THEN ""Type"" ELSE @Type END,
                        ""Number"" = CASE WHEN @Number IS NULL THEN ""Number"" ELSE @Number END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, updatedPassport.Type, updatedPassport.Number });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task DeletePassportAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Passports"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> PassportExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Passports"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}