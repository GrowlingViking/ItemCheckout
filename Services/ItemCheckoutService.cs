using ItemCheckout.Data;
using ItemCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemCheckout.Services;

public interface IItemCheckoutService
{
    Task<List<NamedItem>> GetNamedItemsAsync();
    Task<List<Item>> GetItemsAsync();
    Task<NamedItem> CreateNamedItem(NamedItem namedItem);
}

public class ItemCheckoutService: IItemCheckoutService
{
    private readonly DataContext _dataContext;

    public ItemCheckoutService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<NamedItem>> GetNamedItemsAsync()
    {
        return await _dataContext.NamedItems.ToListAsync();
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _dataContext.Items.ToListAsync();
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

        var result = await _dataContext.NamedItems.AddAsync(namedItem);

       await  _dataContext.SaveChangesAsync();

        return result.Entity;
    }
}