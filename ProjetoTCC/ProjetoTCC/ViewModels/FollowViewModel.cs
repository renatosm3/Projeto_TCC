using Xamarin.Forms;

namespace ProjetoTCC
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
