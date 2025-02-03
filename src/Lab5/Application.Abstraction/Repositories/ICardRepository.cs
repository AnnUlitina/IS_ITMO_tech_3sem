using Application.Models.CardModel;

namespace Application.Abstraction.Repositories;

public interface ICardRepository
{
    Task<IEnumerable<Card>> GetAllCards(long userId);
    Task<Card?> AddNewCard(string cardName, string password, long userId);
    Task<bool> DeleteCard(string cardName, string password, long userId);
    Task<Card?> FindUserByCardName(string cardName, string password, long userId);
}