namespace ItemCheckout.Data.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemType ItemType { get; set; }
    public int Total { get; set; }
}