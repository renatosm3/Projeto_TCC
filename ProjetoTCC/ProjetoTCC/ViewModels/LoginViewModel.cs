using System;
using Xamarin.Forms;

namespace ProjetoTCC
{
    class LoginViewModel : BaseViewModel
    {
        Page page;

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


        public Command RegistrarCommand { get; }

        public Command LoginCommand { get; }
        
        public Command ConectarCommand { get; }


        ITwilio twilio;

        
        public LoginViewModel(Page page)
        {
            this.page = page;
            RegistrarCommand = new Command(async () => await PushAsync<RegisterViewModel>());
            LoginCommand = new Command(async () => await PushAsync<LocationViewModel>());

            twilio = DependencyService.Get<ITwilio>();

            ConectarCommand = new Command(async () =>
            {
                var sucesso = false;
                string mensagem = string.Empty;
                try
                {
                    IsBusy = true;
                    sucesso = await twilio.Inicializar();
                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                }
                finally
                {
                    IsBusy = false;
                }

                if (sucesso)
                {
                    await page.Navigation.PushAsync(new ChatPage());
                    //await PushAsync<ChatViewModel>();
                }
                else
                {
                    await page.DisplayAlert("Erro!", $"Impossível conectar", "Fechar");
                }
            });
        }
    }
}
