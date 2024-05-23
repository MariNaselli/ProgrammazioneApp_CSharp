//Aca esta la logica de la inicializacion de la app y define el 
//MainPage o la appShell como la pagina principal 

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
