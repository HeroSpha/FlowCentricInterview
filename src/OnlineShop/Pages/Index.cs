using Microsoft.AspNetCore.Components;
using OnlineShop.Extensions;
using OnlineShop.Services;
using OnlineShop.Services.Models;

namespace OnlineShop.Pages;

public partial class Index : WPBaseComponent
{
    private IQueryable<ProductDto> products;
    [Inject]
    private IProductService ProductService { get; set; }
    [Inject] public IShoppingCartService ShoppingCartService { get; set; }
    private string? inputValue;
    private async void HandleTextChanged(ChangeEventArgs e)
    {
        inputValue = e.Value?.ToString();
        products = products.Where(x => x.ProductName
            .ContainsIgnoreCase(inputValue!) 
                                       || x.CategoryName.ContainsIgnoreCase(inputValue!));
        //await GetProducts();
    }
    protected override async Task OnInitializedAsync()
    {
        try
        {
            await GetProducts();
            var shoppingCartItems = ShoppingCartService.GetItems();
            var totalQty = shoppingCartItems.Sum(i => i.Qty);
            
            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task GetProducts()
    {
        var items = await ProductService.GetProductsAsync();
        products = new EnumerableQuery<ProductDto>(items);
        Console.Write(products.Count());
    }

    protected IOrderedQueryable<IGrouping<string, ProductDto>> GetGroupedProductsByCategory()
    {
        return from product in products
            group product by product.CategoryName
            into prodByCatGroup
            orderby prodByCatGroup.Key
            select prodByCatGroup;
    }

    protected string GetCategoryName(IGrouping<string, ProductDto> groupedProduct)
    {
        return groupedProduct.FirstOrDefault(pg => pg.CategoryName == groupedProduct.Key)!.CategoryName;
    }

}