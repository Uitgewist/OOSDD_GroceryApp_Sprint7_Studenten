using System.Diagnostics;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class DiscountService : IDiscountService
    {
        private Discount? _todayDiscount;
        private DateTime _lastGeneratedDate = DateTime.MinValue;
        private readonly Random _random = new();

        public Discount? GetTodayDiscount()
        {
            // Check if today's discount is already generated
            if (_lastGeneratedDate.Date == DateTime.Today)
            {
                return _todayDiscount;
            }
            return null;
        }
        public Discount CreateNewDiscount(IEnumerable<Product> products)
        {
            var productList = new List<Product>(products);
            // Clear any existing discounts
            foreach (var p in productList)
                p.ClearDiscount();


            // Pick random product and pick a random discount
            var randomProduct = productList[_random.Next(productList.Count)];
            var randomDiscount = _random.Next(10, 51);

            randomProduct.ApplyDiscount(randomDiscount);

            _todayDiscount = new Discount(randomProduct, randomDiscount);
            _lastGeneratedDate = DateTime.Today;

            return _todayDiscount;
        }
    }
}
