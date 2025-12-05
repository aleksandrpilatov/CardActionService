using Microsoft.AspNetCore.Mvc;

namespace CardActionService.DTO;

public record GetCardActionsRequest
{
    [FromRoute]
    public string? UserId { get; init; }

    [FromRoute]
    public string? CardNumber { get; init; }
}
