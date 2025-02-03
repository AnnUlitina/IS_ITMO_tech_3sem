using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Application.Abstraction.Repositories;
using Application.Contracts.Cards;
using Application.Models.CardModel;
using Application.Models.CurrentStates;
using Application.Models.ResultModel;

namespace Application.Cards;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class CardService : ICardService
{
    private readonly ICardRepository _repository;
    private readonly CurrentState _currentState;

    public CardService(ICardRepository repository, CurrentState currentState)
    {
        _repository = repository;
        _currentState = currentState;
    }

    public async Task<Result> LoginCard(string cardName, string password)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        if (_currentState.User != null)
        {
            Task<Card?> cardTask =
                _repository.FindUserByCardName(cardName, Convert.ToBase64String(hash), _currentState.User.Id);

            Card? card = await cardTask;
            _currentState.Card = card;

            if (Convert.ToBase64String(hash) == card?.Password)
            {
                _currentState.Card = card;
                return new Result(new ResultType.Success(), "successful login" + cardName);
            }
        }

        return new Result(new ResultType.Failure(), "wrong password for '" + cardName + "'");
    }

    public async Task<Result> CreateCard(string cardName, string password, long userId)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<Card?> cardTask = _repository.AddNewCard(cardName, Convert.ToBase64String(hash), userId);
        Card? card = await cardTask;
        _currentState.Card = card;

        if (card is null)
        {
            return new Result(new ResultType.Failure(), "card '" + cardName + "' failed added");
        }

        _currentState.Card = card;
        return new Result(new ResultType.Success(), "card '" + cardName + "' success added");
    }

    public async Task<Result> DeleteCard(string cardName, string password, long userId)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<bool> cardTask = _repository.DeleteCard(cardName, Convert.ToBase64String(hash), userId);
        bool deleted = await cardTask;

        if (deleted)
        {
            _currentState.Card = null;
            return new Result(new ResultType.Success(), "Success deleted");
        }

        return new Result(new ResultType.Failure(), "delete is failure");
    }

    public async Task<IEnumerable<Card>> GetAllCard(long userId)
    {
        return await _repository.GetAllCards(userId);
    }
}