using System.Text;

namespace Shared;

public record CartItemDto(long ProductId, string ProductName, string CategoryName, decimal UnitPrice)
{
    public int Qty { get; set; }
}