using CardActionService.Models;
using CardActionService.Rules;
using CardActionService.Rules.Actions;
using CardActionService.Services;

namespace CardActionService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddSingleton<ICardService, CardService>();
        services.AddScoped<ICardActionService, CardActionService.Services.CardActionService>();

        services.AddActionRules();
        return services;
    }

    private static IServiceCollection AddActionRules(this IServiceCollection services)
    {
        services.AddTransient<IActionRule, Action1Rule>();
        services.AddTransient<IActionRule, Action2Rule>();
        services.AddTransient<IActionRule>(sp => new AlwaysAllowedRule(CardAction.ACTION3));
        services.AddTransient<IActionRule>(sp => new AlwaysAllowedRule(CardAction.ACTION4));
        services.AddTransient<IActionRule, Action5Rule>();
        services.AddTransient<IActionRule, Action6Rule>();
        services.AddTransient<IActionRule, Action7Rule>();
        services.AddTransient<IActionRule, Action8Rule>();
        services.AddTransient<IActionRule>(sp => new AlwaysAllowedRule(CardAction.ACTION9));
        services.AddTransient<IActionRule>(sp => new ActiveOrPendingRule(CardAction.ACTION10));
        services.AddTransient<IActionRule, Action11Rule>();
        services.AddTransient<IActionRule>(sp => new ActiveOrPendingRule(CardAction.ACTION12));
        services.AddTransient<IActionRule>(sp => new ActiveOrPendingRule(CardAction.ACTION13));

        return services;
    }
}
