using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel(IProductService productService, IDiscountService discountService)
        {
            _productService = productService;
            _discountService = discountService;

            Products = new ObservableCollection<Product>();
            LoadProducts();
        }

        public void LoadProducts()
        {
            Products.Clear();

            var allProducts = _productService.GetAll();
            var todayDiscount = _discountService.GetTodayDiscount();

            foreach (var p in allProducts)
            {
                if (todayDiscount != null && todayDiscount.Product.Id == p.Id)
                    p.ApplyDiscount(todayDiscount.DiscountPercentage);
                else
                    p.ClearDiscount();

                Products.Add(p);
            }
        }
        [RelayCommand]
        public void NewDiscount()
        {
            _discountService.CreateNewDiscount(_productService.GetAll());

            LoadProducts();
        }
    }
}
