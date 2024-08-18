using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemCheckout.Data.Entities;

public class HistoryLog
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public HistoryLogItemType HistoryLogItemType { get; set; }
    public int ItemId { get; set; }
    public string Action { get; set; }
    public DateTimeOffset PerformedDate { get; set; }
    public string PerformedBy { get; set; }
}