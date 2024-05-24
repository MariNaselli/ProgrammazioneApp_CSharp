using MauiAppDemo.ModelsViews;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateAccountView), typeof(CreateAccountView));
            Routing.RegisterRoute(nameof(HomePageView), typeof(HomePageView));
        }
    }
}
