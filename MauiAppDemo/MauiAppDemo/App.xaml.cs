using MauiAppDemo.ModelsViews;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }
}
