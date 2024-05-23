using MauiAppDemo.ModelsViews;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginView));
            Routing.RegisterRoute("home", typeof(HomePageView));
            Routing.RegisterRoute("createaccount", typeof(CreateAccountView));

            BindingContext = new HomePageViewModel();
        }
    }
}
