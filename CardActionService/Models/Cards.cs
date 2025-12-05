namespace CardActionService.Models;

public enum CardType
{
    Prepaid,
    Debit,
    Credit
}

public enum CardStatus
{
    Ordered,
    Inactive,
    Active,
    Restricted,
    Blocked,
    Expired,
    Closed
}

public enum CardAction
{
    ACTION1, 
    ACTION2, 
    ACTION3, 
    ACTION4, 
    ACTION5, 
    ACTION6, 
    ACTION7,
    ACTION8, 
    ACTION9, 
    ACTION10, 
    ACTION11, 
    ACTION12, 
    ACTION13
}

public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);


