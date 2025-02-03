using System.Diagnostics.CodeAnalysis;
using Application.Abstraction.Repositories;
using Application.Models.UserModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "CA1849", Justification = "Methods")]
public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username, string password)
    {
        const string sql = """
                           select user_id, user_name, user_role, user_password
                           from users
                           where user_name = :username AND user_password = :password;
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("username: ", username);
        command.Parameters.AddWithValue("customer: ", UserRole.Customer);
        command.Parameters.AddWithValue("password: ", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync(CancellationToken.None);

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            UserRole: reader.GetFieldValue<UserRole>(2),
            Password: reader.GetString(3));
    }

    public async Task<User?> AddNewUser(string username, string password)
    {
        string sql =
            """
            insert into users(user_name, user_role, user_password)
            values (@username, @customer, @password)";
            """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("username: ", username);
        command.Parameters.AddWithValue("customer: ", UserRole.Customer);

        await using NpgsqlDataReader reader = command.ExecuteReader();

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            UserRole: reader.GetFieldValue<UserRole>(2),
            Password: reader.GetString(3));
    }

    public async Task<bool> DeleteUser(string username, string password)
    {
        string sql = """
                     delete from users
                     where user_name = @username";
                     """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("username: ", username);

        await using NpgsqlDataReader reader = command.ExecuteReader();

        if (await reader.ReadAsync() is false)
        {
            return false;
        }

        return true;
    }
}