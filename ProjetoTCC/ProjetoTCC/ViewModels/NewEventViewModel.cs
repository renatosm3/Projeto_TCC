using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC
{
    class NewEventViewModel : BaseViewModel
    {
        public Command ConfirmCommand { get; }

        public NewEventViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<ChatViewModel>();
        }
    }
}
