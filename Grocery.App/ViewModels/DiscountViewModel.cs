using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class DiscountViewModel : ObservableObject
    {
        private readonly IDiscountService _discountService;
        private readonly IProductRepository _productRepository;

        [ObservableProperty]
        private Discount? todayDiscount;

        public ObservableCollection<Product> Products { get; }

        public DiscountViewModel(IDiscountService discountService, IProductRepository productRepository)
        {
            _discountService = discountService;
            _productRepository = productRepository;

            Products = new ObservableCollection<Product>(_productRepository.GetAll());

            LoadTodayDiscount();
        }

        [RelayCommand]
        public void LoadTodayDiscount()
        {
            // Get today’s discount, or generate a new one if needed
            TodayDiscount = _discountService.GetTodayDiscount();
            if (TodayDiscount == null)
                TodayDiscount = _discountService.CreateNewDiscount(Products);
        }
    }
}
