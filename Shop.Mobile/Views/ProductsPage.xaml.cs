using Shop.Mobile.ViewModels;

namespace Shop.Mobile.Views;

public partial class ProductsPage : ContentPage
{
    public ProductsPage(ProductsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}