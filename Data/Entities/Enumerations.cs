namespace ItemCheckout.Data.Entities;

public enum ItemType
{
    Vest = 1,
    Torch = 2,
    MarkingTape = 3
}

public enum NamedItemType
{
    Radio = 1,
    Tablet = 2,
    Powerbank = 3,
    Shelter = 4,
    Jervenduk = 5,
    Headlamp = 6,
    FirstAidKit = 7
}

public enum NamedItemStatus
{
    CheckedIn,
    CheckedOut
}

public enum HistoryLogItemType
{
    Item,
    NamedItem
}