using CardActionService.DTO;
using CardActionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardActionService.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/cards/{cardNumber}")]
    public class CardActionsController(ICardService cardService, ICardActionService cardActionService, ILogger<CardActionsController> logger) : ControllerBase
    {     
        [HttpGet("actions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllowedActions([FromRoute] GetCardActionsRequest request)
        {
            var cardDetails = await cardService.GetCardDetailsAsync(request.UserId!, request.CardNumber!);

            if (cardDetails == null)
            {
                logger.LogWarning("Card not found. UserId: {UserId}, CardNumber: {CardNumber}", request.UserId!, request.CardNumber!);
                return NotFound($"Card with number {request.CardNumber!} for user {request.UserId!} not found.");
            }

            var allowedActions = cardActionService.GetAllowedActions(cardDetails);
            var response = new CardActionsResponse(request.UserId!, request.CardNumber!, cardDetails, allowedActions);

            return Ok(response);
        }
    }
}
