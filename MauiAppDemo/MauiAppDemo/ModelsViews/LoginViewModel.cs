using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.ModelsViews;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    private string user = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    //[ObservableProperty]
    //private bool isOk = false;

    public IAsyncRelayCommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new AsyncRelayCommand(OnLoginClickedAsync);
        NavigateToCreateAccountCommand = new AsyncRelayCommand(NavigateToCreateAccountAsync);
    }

    private async Task OnLoginClickedAsync()
    {
        if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Please enter both username and password.", "OK");
            }
            return;
        }

        //IsOk = false;

        if (User == "admin" && Password == "admin")
        {
            //IsOk = true;
            await Shell.Current.GoToAsync("//home");
        }
        else
        {
            //IsOk = false;
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password. Please try again.", "OK");
            }

        }
    }

    public IAsyncRelayCommand NavigateToCreateAccountCommand { get; }


    private async Task NavigateToCreateAccountAsync()
    {
        await Shell.Current.GoToAsync("//createaccount");
    }
}
