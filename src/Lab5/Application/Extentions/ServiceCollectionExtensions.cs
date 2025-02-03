using Application.Cards;
using Application.Contracts.Cards;
using Application.Contracts.Transactions;
using Application.Contracts.Users;
using Application.Models.CurrentStates;
using Application.Transactions;
using Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<ICardService, CardService>();
        collection.AddScoped<ITransactionService, TransactionService>();

        collection.AddSingleton<CurrentState>();
        collection.AddSingleton<ICurrentState>(
            p => p.GetRequiredService<CurrentState>());

        return collection;
    }
}