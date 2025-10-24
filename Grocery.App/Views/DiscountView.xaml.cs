using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class DiscountView : ContentPage
{
    public DiscountView(DiscountViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
