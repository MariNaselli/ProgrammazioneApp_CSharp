using MauiAppTaskList.ViewModel;

namespace MauiAppTaskList
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }

}
