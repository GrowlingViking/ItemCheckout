using ItemCheckout.Data;
using ItemCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemCheckout.Services;

public interface IItemCheckoutService
{
    Task<List<NamedItem>> GetNamedItemsAsync();
    Task<List<Item>> GetItemsAsync();
    Task<NamedItem> GetNamedItemAsync(int namedItemId);
    Task<NamedItem> CreateNamedItem(NamedItem namedItem);
    Task DeleteNamedItem(int namedItemId);
    Task<NamedItem> UpdateNamedItem(NamedItem updatedNamedItem);
}

public class ItemCheckoutService(DataContext dataContext) : IItemCheckoutService
{
    public async Task<List<NamedItem>> GetNamedItemsAsync()
    {
        return await dataContext.NamedItems.ToListAsync();
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await dataContext.Items.ToListAsync();
    }

    public async Task<NamedItem> GetNamedItemAsync(int namedItemId)
    {
        var namedItem = await dataContext.FindAsync<NamedItem>(namedItemId);

        if (namedItem == null)
        {
            throw new ArgumentException("Named Item not found");
        }
        
        return namedItem;
    }

    public async Task<NamedItem> CreateNamedItem(NamedItem namedItem)
    {
        if (namedItem.Id != 0)
        {
            throw new ArgumentException("Id must be 0");
        }

        namedItem.Status = NamedItemStatus.CheckedIn;
        namedItem.LastCheckedPerson = "";
        namedItem.LastCheckedOut = new DateTimeOffset();

        var result = await dataContext.NamedItems.AddAsync(namedItem);

        await  dataContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<NamedItem> UpdateNamedItem(NamedItem updatedNamedItem)
    {
        if (updatedNamedItem.Id == 0)
        {
            throw new ArgumentException("Named Item Id cannot be 0");
        }

        var dbNamedItem = await dataContext.FindAsync<NamedItem>(updatedNamedItem.Id);

        if (dbNamedItem == null)
        {
            throw new ArgumentException("Named Item not found");
        }
        
        dbNamedItem.Name = updatedNamedItem.Name;
        dbNamedItem.Status = updatedNamedItem.Status;
        dbNamedItem.ItemType = updatedNamedItem.ItemType;

        dbNamedItem = dataContext.Update(dbNamedItem).Entity;

        return dbNamedItem;
    }

    public async Task DeleteNamedItem(int namedItemId)
    {
        var item = await dataContext.NamedItems.FindAsync(namedItemId);

        if (item == null)
        {
            throw new ArgumentException("Named Item not found");
        }

        dataContext.NamedItems.Remove(item);
        await dataContext.SaveChangesAsync();
    }
}