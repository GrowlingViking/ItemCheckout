using ItemCheckout.Data;

namespace ItemCheckout.Services;

public class ItemCheckoutService
{
    private readonly DataContext _dataContext;

    public ItemCheckoutService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    
}