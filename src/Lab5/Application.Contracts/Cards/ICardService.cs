using Application.Models.CardModel;
using Application.Models.ResultModel;

namespace Application.Contracts.Cards;

public interface ICardService
{
    Task<IEnumerable<Card>> GetAllCard(long userId);
    Task<Result> LoginCard(string cardName, string password);

    Task<Result> CreateCard(string cardName, string password, long userId);
    Task<Result> DeleteCard(string cardName, string password, long userId);
}