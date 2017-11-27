using Xamarin.Forms;
using ProjetoTCC.ViewModels;

namespace ProjetoTCC.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
