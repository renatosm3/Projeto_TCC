using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoTCC.ViewModels;

namespace ProjetoTCC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
		public LocationPage ()
		{
			InitializeComponent ();

            BindingContext = new LocationViewModel();
		}
	}
}