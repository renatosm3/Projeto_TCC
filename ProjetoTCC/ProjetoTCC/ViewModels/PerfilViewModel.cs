using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoTCC.ViewModels
{
    class PerfilViewModel : BaseViewModel
    {
        public Command ConfirmCommand { get; }

        public PerfilViewModel()
        {
            ConfirmCommand = new Command(ExecuteConfirmCommand);
        }

        async void ExecuteConfirmCommand()
        {
            await PushAsync<PerfilViewModel>();
        }
    }
}
