using CardActionService.Models;
namespace CardActionService.Services;

public interface ICardActionService
{
    IEnumerable<string> GetAllowedActions(CardDetails cardDetails);
}
