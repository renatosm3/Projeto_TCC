using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC
{
    class ParticipantesViewModel : BaseViewModel
    {
        public Command ConfirmCommand { get; }

        public ParticipantesViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<PerfilViewModel>();
        }
    }
}
