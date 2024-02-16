using MrDuck.ViewModels;

namespace MrDuck.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = Bootstrap.GetService<MainPageVM>();
        }
    }
}
