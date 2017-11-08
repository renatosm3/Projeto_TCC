using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        public Command ConfirmCommand { get; }

        public RegisterViewModel() {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<MainViewModel>();
        }
    }
}
