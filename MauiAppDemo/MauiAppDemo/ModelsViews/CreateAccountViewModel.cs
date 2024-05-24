using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ModelsViews;

public partial class CreateAccountViewModel : ObservableObject
{

    [ObservableProperty]
    private string user;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string confirmPassword;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string lastName;

    [ObservableProperty]
    private string address;

    [ObservableProperty]
    private ObservableCollection<string> country;

    [ObservableProperty]
    private bool acceptsPrivacyPolicy;

    [ObservableProperty]
    private bool acceptsMarketing;

    public CreateAccountViewModel()
    {

    }

    [RelayCommand]
    public async Task OnNavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task CreateAccount()
    {
        if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword) ||
            string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Address))
            {
            //
            return;
            }

            if (Password != ConfirmPassword)
            {
            //
            return;
            }

            await Shell.Current.GoToAsync(nameof(HomePageView));
    }
}
