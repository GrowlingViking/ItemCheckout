using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemCheckout.Data.Entities;

public class NamedItem
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public NamedItemType ItemType { get; set; }
    public NamedItemStatus Status { get; set; }
    public DateTimeOffset LastCheckedOut { get; set; }
    public string? LastCheckedPerson { get; set; }
}