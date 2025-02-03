using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Application.Abstraction.Repositories;
using Application.Models.CurrentStates;
using Application.Models.TransactionModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "CA1849", Justification = "Methods")]
[SuppressMessage("", "CA2100", Justification = "Methods")]
[SuppressMessage("", "SA1118", Justification = "Methods")]
public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Transaction?> FindUserByCardName(long cardId)
    {
        string sql = """
                     select card_id, transaction_name, transaction_date
                     from transactions
                     where card_id = :cardId";
                     """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardId: ", NpgsqlTypes.NpgsqlDbType.Text, cardId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync(CancellationToken.None);

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new Transaction(
            CardId: reader.GetInt64(0),
            TransactionName: reader.GetString(1),
            TransactionDate: reader.GetString(2));
    }

    public async Task<long> GetCardBalance(CurrentState currentState)
    {
        string sql = """
                     select card_bill
                     from cards
                     where card_name = @card_name;
                     """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("card_name", currentState.Card?.CardName);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
        {
            throw new ArgumentException(nameof(reader));
        }

        return reader.GetInt64(0);
    }

    public async Task UpdateBalance(long amount, CurrentState currentState)
    {
        if (currentState.User is null) throw new ArgumentNullException(nameof(currentState));

        string sql = """
                     update cards
                     set card_bill = @card_bill
                     where owner_card_id = @owner_card_id";
                     """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("owner_card_id: ", currentState.User.Id);
        command.Parameters.AddWithValue("card_bill: ", amount);

        await command.PrepareAsync();

        await command.ExecuteNonQueryAsync();

        await AddTransactionToHistory(
            currentState,
            "Balance of account with " + currentState.Card?.CardName.ToString(NumberFormatInfo.CurrentInfo) +
            " is updated",
            connection);
    }

    public async Task<IEnumerable<Transaction>> GetAllTransaction(long cardId)
    {
        string sql =
            """
            select card_id, transaction_name, transaction_date
            from transactions
            where card_id = @cardID";
            """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardId: ", cardId);

        await using NpgsqlDataReader reader = command.ExecuteReader();

        IList<Transaction> cards = new List<Transaction>();
        while (await reader.ReadAsync())
        {
            cards.Add(new Transaction(
                CardId: reader.GetInt64(0),
                TransactionName: reader.GetString(1),
                TransactionDate: reader.GetString(2)));
        }

        return cards;
    }

    private static async Task AddTransactionToHistory(
        CurrentState currentState,
        string transactionName,
        NpgsqlConnection connection)
    {
        string sql =
            """
            insert into transactions(card_id, transaction_date, transaction_name)
            values (@card_id, @transaction_date, @transaction_name)";
            """;

        await using var command = new NpgsqlCommand(sql, connection);

        if (currentState.Card != null)
        {
            command.Parameters.AddWithValue("card_id", currentState.Card.Id);
        }

        command.Parameters.AddWithValue("transaction_date: ", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        command.Parameters.AddWithValue("transaction_name: ", transactionName);

        await command.PrepareAsync();
        await command.ExecuteNonQueryAsync();
    }
}