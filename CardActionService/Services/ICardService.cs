using CardActionService.Models;
namespace CardActionService.Services;

public interface ICardService
{
    Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber);
}
