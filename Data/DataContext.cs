using ItemCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemCheckout.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<NamedItem> NamedItems { get; set; }
    public DbSet<HistoryLog> HistoryLogs { get; set; }
}