using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IDiscountService
    {
        Discount? GetTodayDiscount();
        Discount CreateNewDiscount(IEnumerable<Product> products);
    }
}
