using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string user;

        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { SetProperty(ref senha, value); }
        }


        public Command RegisterCommand { get; }

        public Command LoginCommand { get; }

        public LoginViewModel() {
            RegisterCommand = new Command(ExecuteRegisterCommand);
            LoginCommand = new Command(ExecuteLoginCommand);
        }

        async void ExecuteRegisterCommand() {
            await PushAsync<RegisterViewModel>();
        }

        async void ExecuteLoginCommand() {
            await PushAsync<LocationViewModel>();
        }


        public Command Go { get; }
        async void ExecuteGoCommand()
        {
            await PushAsync<PerfilViewModel>();
        }
    }
}
