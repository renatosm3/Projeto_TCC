using Xamarin.Forms;

namespace ProjetoTCC
{
    class LocationViewModel : BaseViewModel
    {
        private string pais;
        

        private string estado;


        private string cidade;

        public Command FollowCommand { get; }

        public LocationViewModel() {
            FollowCommand = new Command(ExecuteFollowCommand);
        }

        async void ExecuteFollowCommand() {
            await PushAsync<FollowViewModel>();
        }
    }
}
