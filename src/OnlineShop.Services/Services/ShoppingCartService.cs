using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services.Services;

public class ShoppingCartService : IShoppingCartService
{
    private static List<CartItemDto> _cartItems = new();
    public event Action<int>? OnShoppingCartChanged;
    
    public  void AddItem(CartItemDto cartItem, int qty)
    {
        var item = GetCartItem(cartItem.ProductId);
        if (item == null)
        {
            cartItem.Qty += qty;
            _cartItems.Add(cartItem);
        }
        else
        {
            item.Qty += qty;
        }
    }

    public void RemoveItem(CartItemDto cartItem)
    {
        var item = GetCartItem(cartItem.ProductId);
        if (item is {Qty: > 1})
        {
            item.Qty -= 1;
        }
        else
        {
            if (item != null) 
                _cartItems.Remove(item);
        }
    }

    private static CartItemDto? GetCartItem(long id)
    {
        var item = _cartItems.FirstOrDefault(x => x.ProductId == id);
        return item;
    }

    public void RemoveItem(long id)
    {
        var item = GetCartItem(id);
        if (item != null)
        {
            _cartItems.Remove(item);
        }
    }

    public void Clear()
    {
        _cartItems.Clear();
    }

    public  IEnumerable<CartItemDto> GetItems()
    {
        return _cartItems;
    }

   
    public void RaiseEventOnShoppingCartChanged(int totalQty)
    {
        OnShoppingCartChanged?.Invoke(totalQty);
    }

    
}