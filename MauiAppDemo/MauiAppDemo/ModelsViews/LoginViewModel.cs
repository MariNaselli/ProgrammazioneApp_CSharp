using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.ModelsViews;

public partial class LoginViewModel : ObservableObject
{

    
    public LoginViewModel()
    {
        User = string.Empty;
        Password = string.Empty;
        IsOk = false;
    }

    [ObservableProperty]
    string user;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    bool isOk;

    [RelayCommand]
    void Login()
    {
        if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }

        IsOk = false;

        if (User == "admin" && Password == "admin")
        {
            IsOk = true;

        }

    }
}
