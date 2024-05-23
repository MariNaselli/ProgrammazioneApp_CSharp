using MauiAppLogin.ModelView;

namespace MauiAppLogin.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel lvm)
	{
		InitializeComponent();
		BindingContext = lvm;
	}
}