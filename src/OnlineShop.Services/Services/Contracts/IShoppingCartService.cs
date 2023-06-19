using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services;

public interface IShoppingCartService
{
    void AddItem(CartItemDto cartItem, int qty);
    void RemoveItem(CartItemDto cartItem);
    void RemoveItem(long id);
    void Clear();
    IEnumerable<CartItemDto> GetItems();
    event Action<int> OnShoppingCartChanged;
    void RaiseEventOnShoppingCartChanged(int totalQty);
    
}