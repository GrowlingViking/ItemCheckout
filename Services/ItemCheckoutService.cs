using ItemCheckout.Data;
using ItemCheckout.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemCheckout.Services;

public interface IItemCheckoutService
{
    Task<List<NamedItem>> GetNamedItemsAsync();
    Task<List<Item>> GetItemsAsync();
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
}