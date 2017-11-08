using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoTCC.ViewModels;

namespace ProjetoTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();

            BindingContext = new RegisterViewModel();
		}
	}
}