using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.Scenarios.CardScenarios.AddCard;
using Presentation.Console.Scenarios.CardScenarios.DeleteCard;
using Presentation.Console.Scenarios.CardScenarios.LoginCard;
using Presentation.Console.Scenarios.CardScenarios.ViewInformationCard;
using Presentation.Console.Scenarios.TransactionScenarios.DepositMoney;
using Presentation.Console.Scenarios.TransactionScenarios.GetMoney;
using Presentation.Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;
using Presentation.Console.Scenarios.UserScenarios.AddUser;
using Presentation.Console.Scenarios.UserScenarios.DeleteUser;
using Presentation.Console.Scenarios.UserScenarios.LoginUser;

namespace Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteUserScenarioProvider>();

        collection.AddScoped<IScenarioProvider, LoginCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewInformationScenarioProvider>();

        collection.AddScoped<IScenarioProvider, GetMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewHistoryTransactionScenarioProvider>();

        return collection;
    }
}