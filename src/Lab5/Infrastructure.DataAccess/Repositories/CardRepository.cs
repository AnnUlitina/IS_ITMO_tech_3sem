using System.Diagnostics.CodeAnalysis;
using Application.Abstraction.Repositories;
using Application.Models.CardModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

[SuppressMessage("", "CA2100", Justification = "Methods")]
[SuppressMessage("", "CA2007", Justification = "Methods")]
public class CardRepository : ICardRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CardRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IEnumerable<Card>> GetAllCards(long userId)
    {
        const string sql =
            """
            select card_id, card_name, owner_card_id, card_password, card_bill
            from cards
            where owner_card_id = @userId
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("userId: ", userId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        IList<Card> cards = new List<Card>();
        while (await reader.ReadAsync())
        {
            cards.Add(new Card(
                Id: reader.GetInt64(0),
                CardName: reader.GetString(1),
                OwnerId: reader.GetInt32(2),
                Password: reader.GetString(3),
                Bill: reader.GetInt64(4)));
        }

        return cards;
    }

    public async Task<Card?> FindUserByCardName(string cardName, string password, long userId)
    {
        string sql = """
                     select card_id, card_name, owner_card_id, card_password, card_bill
                     from cards
                     where card_name = :cardName AND card_password = :password;
                     """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardName: ", NpgsqlTypes.NpgsqlDbType.Text, cardName);
        command.Parameters.AddWithValue("password: ", NpgsqlTypes.NpgsqlDbType.Text, password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync(CancellationToken.None);

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new Card(
            Id: reader.GetInt64(0),
            CardName: reader.GetString(1),
            OwnerId: reader.GetInt32(2),
            Password: reader.GetString(3),
            Bill: reader.GetInt64(4));
    }

    public async Task<Card?> AddNewCard(string cardName, string password, long userId)
    {
        string sql =
            "insert into cards(card_name, owner_card_id, card_password, card_bill) values (@cardName, @userId, @password, @card_bill)";

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardName: ", cardName);
        command.Parameters.AddWithValue("userId: ", userId);
        command.Parameters.AddWithValue("password: ", password);
        command.Parameters.AddWithValue("card_bill: ", 0);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
        {
            return null;
        }

        return new Card(
            Id: reader.GetInt64(0),
            CardName: reader.GetString(1),
            OwnerId: reader.GetInt32(2),
            Password: reader.GetString(3),
            Bill: reader.GetInt64(4));
    }

    public async Task<bool> DeleteCard(string cardName, string password, long userId)
    {
        string sql = """
                     delete from cards
                     where card_name = @cardName";
                     """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardName: ", cardName);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
        {
            return false;
        }

        return true;
    }
}