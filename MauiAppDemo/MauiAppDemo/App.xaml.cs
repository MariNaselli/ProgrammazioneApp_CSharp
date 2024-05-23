using MauiAppDemo.ModelsViews;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class App : Application
    {
        public App(LoginViewModel lvm)
        {
            InitializeComponent();

            MainPage = new LoginView(lvm);
        }
    }
}
