namespace ItemCheckout.Data.Entities;

public class NamedItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public NamedItemType ItemType { get; set; }
    public NamedItemStatus Status { get; set; }
    public DateTimeOffset LastCheckedOut { get; set; }
    public string? LastCheckedPerson { get; set; }
}