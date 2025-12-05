using CardActionService.Models;
namespace CardActionService.Rules;

public interface IActionRule
{
    CardAction Action { get; }
    bool IsAllowed(CardDetails details);
}
