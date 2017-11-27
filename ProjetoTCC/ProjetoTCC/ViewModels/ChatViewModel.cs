using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        public Command ParticipantesCommand { get; }


        public ChatViewModel()
        {
            ParticipantesCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<PerfilViewModel>();
        }
    }
}
