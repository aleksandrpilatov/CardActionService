using CardActionService.Models;
namespace CardActionService.Rules.Actions;

public class Action1Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION1;
    public bool IsAllowed(CardDetails details) => details.CardStatus == CardStatus.Active;
}

public class Action2Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION2;
    public bool IsAllowed(CardDetails details) => details.CardStatus == CardStatus.Inactive;
}

public class AlwaysAllowedRule : IActionRule
{
    private readonly CardAction _action;
    public AlwaysAllowedRule(CardAction action) => _action = action;
    public CardAction Action => _action;
    public bool IsAllowed(CardDetails details) => true;
}

public class Action5Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION5;
    public bool IsAllowed(CardDetails details) => details.CardType == CardType.Credit;
}

public class Action6Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION6;
    private static readonly HashSet<CardStatus> AllowedStatuses = new()
    {
       CardStatus.Ordered,
       CardStatus.Inactive,
       CardStatus.Active,
       CardStatus.Blocked
    };
    public bool IsAllowed(CardDetails details) => AllowedStatuses.Contains(details.CardStatus) && details.IsPinSet;
}

public class Action7Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION7;
    public bool IsAllowed(CardDetails details)
    {
        switch (details.CardStatus)
        {
            case CardStatus.Ordered:
            case CardStatus.Inactive:
            case CardStatus.Active:
                return !details.IsPinSet;

            case CardStatus.Blocked:
                return details.IsPinSet;

            default:
                return false;
        }
    }
}

public class Action8Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION8;
    private static readonly HashSet<CardStatus> AllowedStatuses = new()
    {
       CardStatus.Ordered, 
       CardStatus.Inactive, 
       CardStatus.Active, 
       CardStatus.Blocked
    };
    public bool IsAllowed(CardDetails details) => AllowedStatuses.Contains(details.CardStatus);
}

public class ActiveOrPendingRule : IActionRule
{
    private readonly CardAction _action;
    public ActiveOrPendingRule(CardAction action) => _action = action;
    public CardAction Action => _action;
    private static readonly HashSet<CardStatus> AllowedStatuses = new()
    {
       CardStatus.Ordered,
       CardStatus.Inactive,
       CardStatus.Active
    };
    public bool IsAllowed(CardDetails details) => AllowedStatuses.Contains(details.CardStatus);
}

public class Action11Rule : IActionRule
{
    public CardAction Action => CardAction.ACTION11;
    public bool IsAllowed(CardDetails details) => details.CardStatus == CardStatus.Inactive || details.CardStatus == CardStatus.Active;
}
