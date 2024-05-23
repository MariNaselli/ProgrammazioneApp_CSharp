using MauiAppLogin.ModelView;
using MauiAppLogin.Views;

namespace MauiAppLogin
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
