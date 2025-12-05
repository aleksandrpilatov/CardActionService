using CardActionService.Models;
namespace CardActionService.DTO;

public record CardActionsResponse(string UserId, string CardNumber,  CardDetails Details, IEnumerable<string> AllowedActions);

