using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    class FollowViewModel : BaseViewModel
    {

        public Command ConfirmCommand { get; }
        

        public FollowViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<EventViewModel>();
        }

    }
}
