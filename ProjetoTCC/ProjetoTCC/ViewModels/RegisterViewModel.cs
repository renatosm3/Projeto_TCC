using Xamarin.Forms;

namespace ProjetoTCC
{
    public class RegisterViewModel : BaseViewModel
    {

        public Command ConfirmCommand { get; }

        public RegisterViewModel() {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<LoginViewModel>();
        }
    }
}
