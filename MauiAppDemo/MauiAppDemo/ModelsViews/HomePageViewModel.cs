using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDemo.ModelsViews;

public partial class HomePageViewModel : ObservableObject
{

    public HomePageViewModel()
    {
    }

    [RelayCommand]   
    private async Task OnNavigateBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
