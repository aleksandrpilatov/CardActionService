using CardActionService.Models;
using CardActionService.Rules;

namespace CardActionService.Services;

public class CardActionService(IEnumerable<IActionRule> rules) : ICardActionService
{
    public IEnumerable<string> GetAllowedActions(CardDetails cardDetails)
    {
        if (cardDetails == null)
        {
            return Enumerable.Empty<string>();
        }
        return rules
            .Where(rule => rule.IsAllowed(cardDetails))
            .Select(rule => rule.Action.ToString())
            .OrderBy(a => a) 
            .ToList();
    }
}
