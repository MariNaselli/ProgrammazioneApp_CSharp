using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ModelsViews;

public partial class CreateAccountViewModel : ObservableObject
{
    public ICommand NavigateBackCommand { get; }

    public CreateAccountViewModel()
    {
        NavigateBackCommand = new Command<string>(OnNavigateBack);
    }

    private async void OnNavigateBack(string route)
    {
        await Shell.Current.GoToAsync($"//{route}");
    }
}
