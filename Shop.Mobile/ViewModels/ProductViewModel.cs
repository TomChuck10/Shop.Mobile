using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shop.Mobile.Models;
using Shop.Mobile.Services;
using Shop.Mobile.Views;
using System.Collections.ObjectModel;

namespace Shop.Mobile.ViewModels
{
    public partial class ProductsViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        public ObservableCollection<Product> Products { get; } = new();

        [ObservableProperty]
        bool isLoading;

        public ProductsViewModel(ProductService productService)
        {
            _productService = productService;
            LoadProductsCommand.Execute(null);

        }

        [RelayCommand]
        async Task LoadProductsAsync()
        {
            if (IsLoading) return;

            try
            {
                IsLoading = true;

                var products = await _productService.GetProductsAsync();

                if (Products.Count > 0)
                    Products.Clear();

                foreach (var product in products)
                    Products.Add(product);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Błąd", $"Nie udało się pobrać danych: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Product product)
        {
            if (product is null) return;

            await Shell.Current.GoToAsync(nameof(ProductDetailsPage), new Dictionary<string, object>
            {
                { "Product", product }
            });
        }
    }
}