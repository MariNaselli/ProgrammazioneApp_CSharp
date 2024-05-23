using MauiAppDemo.ModelsViews;

namespace MauiAppDemo.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel lvm)
    {
        InitializeComponent();
        BindingContext = lvm;
    }
}