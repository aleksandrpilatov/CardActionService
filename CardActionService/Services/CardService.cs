using CardActionService.Models;
namespace CardActionService.Services;

public class CardService : ICardService
{
    private readonly Dictionary<string, Dictionary<string, CardDetails>> _userCards = CreateSampleUserCards();

    public async Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber)
    {
        await Task.Delay(50);

        if (string.IsNullOrWhiteSpace(userId) || !_userCards.TryGetValue(userId, out var cards)
            || string.IsNullOrWhiteSpace(cardNumber) || !cards.TryGetValue(cardNumber, out var cardDetails))
        {
            return null;
        }
        return cardDetails;
    }

    private static Dictionary<string, Dictionary<string, CardDetails>> CreateSampleUserCards()
    {
        var userCards = new Dictionary<string, Dictionary<string, CardDetails>>();

        for (var i = 1; i <= 3; i++)
        {
            var cards = new Dictionary<string, CardDetails>();
            var cardIndex = 1;

            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardStatus cardStatus in Enum.GetValues(typeof(CardStatus)))
                {
                    var cardNumber = $"Card{i}{cardIndex}";
                    cards.Add(cardNumber,
                        new CardDetails(
                            CardNumber: cardNumber,
                            CardType: cardType,
                            CardStatus: cardStatus,                            
                            IsPinSet: cardIndex % 2 == 0));
                    cardIndex++;
                }
            }
            userCards.Add($"User{i}", cards);
        }
        return userCards;
    }
}
