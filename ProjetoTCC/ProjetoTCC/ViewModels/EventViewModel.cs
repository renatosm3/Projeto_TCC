using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC
{
    public class EventViewModel : BaseViewModel
    {

        public Command ConfirmCommand { get; }

        public EventViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<NewEventViewModel>();
        }
    }
}