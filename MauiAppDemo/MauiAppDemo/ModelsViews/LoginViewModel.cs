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
    private string user;

    [ObservableProperty]
    private string password;

    //[ObservableProperty]
    //private bool isOk = false;


    public LoginViewModel()
    {
        
    }

    [RelayCommand]
    public async Task Login()
    {
        if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Please enter both username and password.", "OK");
            }
            
        }

        //IsOk = false;

        if (User == "admin" && Password == "admin")
        {
            //IsOk = true;
            await Shell.Current.GoToAsync(nameof(HomePageView));
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

    [RelayCommand]
    public async Task NavigateToCreateAccountAsync()
    {
        await Shell.Current.GoToAsync(nameof(CreateAccountView));
    }
}
