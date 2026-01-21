using Shop.Mobile.Views;

namespace Shop.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ProductDetailsPage), typeof(ProductDetailsPage));
    }
}