using CommunityToolkit.Mvvm.ComponentModel;
using Shop.Mobile.Models;

namespace Shop.Mobile.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Product product;
    }
}